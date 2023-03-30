using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Discord_Webcam_Macro
{
    public partial class settingsForm : Form
    {
        public settingsForm()
        {
            InitializeComponent();
        }
        int modifier = 2;
        int secondkey = 8;
        private void secondKey_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Menu || e.KeyCode == Keys.Alt || e.KeyCode == Keys.ControlKey || e.KeyCode == Keys.LWin || e.KeyCode == Keys.RWin) return;
            secondKey.Text = e.KeyCode.ToString();
            secondKeyLabel.Text = "Second Key = " + ((int)e.KeyCode).ToString();
            secondkey = (int)e.KeyCode;
        }

        private void modifierBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            firstKeyLabel.Text = "First Key = " + modifierBox.SelectedIndex;
            modifier = modifierBox.SelectedIndex;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.modifier = modifier;
            Properties.Settings.Default.secondkey = secondkey;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            new hiddenMacroForm().registerMacro();
            this.Hide();
        }
    }
}
