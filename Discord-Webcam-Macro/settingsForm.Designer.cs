
namespace Discord_Webcam_Macro
{
    partial class settingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.saveBtn = new System.Windows.Forms.Button();
            this.secondKey = new System.Windows.Forms.TextBox();
            this.modifierBox = new System.Windows.Forms.ComboBox();
            this.firstKeyLabel = new System.Windows.Forms.Label();
            this.secondKeyLabel = new System.Windows.Forms.Label();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(12, 143);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(151, 23);
            this.saveBtn.TabIndex = 0;
            this.saveBtn.Text = "Save Settings";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // secondKey
            // 
            this.secondKey.Location = new System.Drawing.Point(12, 117);
            this.secondKey.Name = "secondKey";
            this.secondKey.Size = new System.Drawing.Size(151, 20);
            this.secondKey.TabIndex = 1;
            this.secondKey.Text = "Back";
            this.secondKey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.secondKey_KeyUp);
            // 
            // modifierBox
            // 
            this.modifierBox.FormattingEnabled = true;
            this.modifierBox.Items.AddRange(new object[] {
            "None",
            "Alt",
            "Control",
            "Shift",
            "WinKey"});
            this.modifierBox.Location = new System.Drawing.Point(12, 77);
            this.modifierBox.Name = "modifierBox";
            this.modifierBox.Size = new System.Drawing.Size(151, 21);
            this.modifierBox.TabIndex = 2;
            this.modifierBox.Text = "Control";
            this.modifierBox.SelectedIndexChanged += new System.EventHandler(this.modifierBox_SelectedIndexChanged);
            // 
            // firstKeyLabel
            // 
            this.firstKeyLabel.AutoSize = true;
            this.firstKeyLabel.Location = new System.Drawing.Point(12, 61);
            this.firstKeyLabel.Name = "firstKeyLabel";
            this.firstKeyLabel.Size = new System.Drawing.Size(65, 13);
            this.firstKeyLabel.TabIndex = 3;
            this.firstKeyLabel.Text = "First Key = 2";
            // 
            // secondKeyLabel
            // 
            this.secondKeyLabel.AutoSize = true;
            this.secondKeyLabel.Location = new System.Drawing.Point(12, 101);
            this.secondKeyLabel.Name = "secondKeyLabel";
            this.secondKeyLabel.Size = new System.Drawing.Size(83, 13);
            this.secondKeyLabel.TabIndex = 4;
            this.secondKeyLabel.Text = "Second Key = 8";
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Location = new System.Drawing.Point(12, 9);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(145, 52);
            this.welcomeLabel.TabIndex = 5;
            this.welcomeLabel.Text = "It seems to be your first time \r\nopening this program. \r\nSelect your macro then s" +
    "ave.\r\n----------------------------------------------";
            // 
            // settingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(178, 175);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.secondKeyLabel);
            this.Controls.Add(this.firstKeyLabel);
            this.Controls.Add(this.modifierBox);
            this.Controls.Add(this.secondKey);
            this.Controls.Add(this.saveBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "settingsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TextBox secondKey;
        private System.Windows.Forms.ComboBox modifierBox;
        private System.Windows.Forms.Label firstKeyLabel;
        private System.Windows.Forms.Label secondKeyLabel;
        private System.Windows.Forms.Label welcomeLabel;
    }
}