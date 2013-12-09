namespace QLBV
{
    partial class SetupForm
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
            this.telerikMetroBlueTheme1 = new Telerik.WinControls.Themes.TelerikMetroBlueTheme();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radTextBo_hostname = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radTextBox_username = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radTextBox_password = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radTextBox4 = new Telerik.WinControls.UI.RadTextBox();
            this.radButton_ok = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBo_hostname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox_username)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox_password)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton_ok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(12, 92);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(60, 18);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Host name";
            // 
            // radTextBo_hostname
            // 
            this.radTextBo_hostname.Location = new System.Drawing.Point(73, 92);
            this.radTextBo_hostname.Name = "radTextBo_hostname";
            this.radTextBo_hostname.Size = new System.Drawing.Size(174, 22);
            this.radTextBo_hostname.TabIndex = 1;
            this.radTextBo_hostname.ThemeName = "TelerikMetroBlue";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(12, 120);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(60, 18);
            this.radLabel2.TabIndex = 0;
            this.radLabel2.Text = "User name";
            // 
            // radTextBox_username
            // 
            this.radTextBox_username.Location = new System.Drawing.Point(73, 120);
            this.radTextBox_username.Name = "radTextBox_username";
            this.radTextBox_username.Size = new System.Drawing.Size(174, 22);
            this.radTextBox_username.TabIndex = 1;
            this.radTextBox_username.ThemeName = "TelerikMetroBlue";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(12, 148);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(53, 18);
            this.radLabel3.TabIndex = 0;
            this.radLabel3.Text = "Password";
            // 
            // radTextBox_password
            // 
            this.radTextBox_password.Location = new System.Drawing.Point(73, 148);
            this.radTextBox_password.Name = "radTextBox_password";
            this.radTextBox_password.PasswordChar = '*';
            this.radTextBox_password.Size = new System.Drawing.Size(174, 22);
            this.radTextBox_password.TabIndex = 1;
            this.radTextBox_password.Text = "User name";
            this.radTextBox_password.ThemeName = "TelerikMetroBlue";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(12, 176);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(53, 18);
            this.radLabel4.TabIndex = 0;
            this.radLabel4.Text = "Database";
            // 
            // radTextBox4
            // 
            this.radTextBox4.Location = new System.Drawing.Point(73, 176);
            this.radTextBox4.Name = "radTextBox4";
            this.radTextBox4.Size = new System.Drawing.Size(174, 22);
            this.radTextBox4.TabIndex = 1;
            this.radTextBox4.ThemeName = "TelerikMetroBlue";
            // 
            // radButton_ok
            // 
            this.radButton_ok.Location = new System.Drawing.Point(91, 229);
            this.radButton_ok.Name = "radButton_ok";
            this.radButton_ok.Size = new System.Drawing.Size(110, 24);
            this.radButton_ok.TabIndex = 2;
            this.radButton_ok.Text = "OK";
            this.radButton_ok.ThemeName = "TelerikMetroBlue";
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 279);
            this.Controls.Add(this.radButton_ok);
            this.Controls.Add(this.radTextBox4);
            this.Controls.Add(this.radTextBox_password);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.radTextBox_username);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radTextBo_hostname);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Name = "SetupForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Setup Database";
            this.ThemeName = "TelerikMetroBlue";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBo_hostname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox_username)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox_password)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton_ok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroBlueTheme telerikMetroBlueTheme1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox radTextBo_hostname;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox radTextBox_username;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadTextBox radTextBox_password;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadTextBox radTextBox4;
        private Telerik.WinControls.UI.RadButton radButton_ok;
    }
}
