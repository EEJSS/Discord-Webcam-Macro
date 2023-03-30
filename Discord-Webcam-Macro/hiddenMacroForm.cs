using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Discord_Webcam_Macro
{
    public partial class hiddenMacroForm : Form
    {
        public hiddenMacroForm()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr handle);
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr handle, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern bool IsIconic(IntPtr handle);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(HandleRef hWnd, out RECT lpRect);
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;  
            public int Top;
            public int Right;
            public int Bottom;
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312)
            {
                IntPtr curWindow = GetForegroundWindow();
                Process[] p = Process.GetProcessesByName("Discord");
                for (int i = 0; i < p.Length; i++)
                {
                    IntPtr handle = p[i].MainWindowHandle;
                    if (IsIconic(handle)) ShowWindow(handle, 9);
                    SetForegroundWindow(handle);
                    if (!GetWindowRect(new HandleRef(p[i], p[i].MainWindowHandle), out RECT rct)) continue;
                    Point point = Cursor.Position;
                    Cursor.Position = new System.Drawing.Point(rct.Left + 120, (rct.Top + (rct.Bottom - rct.Top)) - 80);
                    mouse_event(0x02 | 0x04, (uint)Cursor.Position.X, (uint)Cursor.Position.Y, 0, 0);
                    Cursor.Position = point;
                }
                SetForegroundWindow(curWindow);
            }
            base.WndProc(ref m);
        }

        private void hiddenMacroForm_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            if (Properties.Settings.Default.secondkey == -1)
            {
                new settingsForm().ShowDialog();
            }
            else
            {
                registerMacro();
            }
        }
        
        // public so that it can be called from settingsForm
        public void registerMacro()
        {
            RegisterHotKey(this.Handle, this.GetHashCode(), Properties.Settings.Default.modifier, Properties.Settings.Default.secondkey);
        }
    }
}
