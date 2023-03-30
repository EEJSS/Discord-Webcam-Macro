using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr handle);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr handle, int nCmdShow);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
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
        public static class Constants
        {
            //windows message id for hotkey
            public const int WM_HOTKEY_MSG_ID = 0x0312;
        }
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
            {
                RECT rct;
                Process[] p = Process.GetProcessesByName("Discord");
                for (int i = 0; i < p.Length; i++)
                {
                    IntPtr handle = p[i].MainWindowHandle;
                    if (IsIconic(handle))
                    {
                        ShowWindow(handle, 9);
                    }
                    SetForegroundWindow(handle);
                    if (!GetWindowRect(new HandleRef(p[i], p[i].MainWindowHandle), out rct))
                    {
                        continue;
                    }
                    Cursor.Position = new System.Drawing.Point(rct.Left + ((rct.Right - rct.Left) / 2) - 30, (rct.Top + (rct.Bottom - rct.Top)) - 40);
                    mouse_event(0x02 | 0x04, (uint)Cursor.Position.X, (uint)Cursor.Position.Y, 0, 0);
                }
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
