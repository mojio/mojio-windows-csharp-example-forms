namespace OAuthExample
{
    partial class MainWindow
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
            this.appIdLabel = new System.Windows.Forms.Label();
            this.appIdTextBox = new System.Windows.Forms.TextBox();
            this.environmentModeGroupBox = new System.Windows.Forms.GroupBox();
            this.sandboxRadioButton = new System.Windows.Forms.RadioButton();
            this.liveRadioButton = new System.Windows.Forms.RadioButton();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.redirecUrlTextBox = new System.Windows.Forms.TextBox();
            this.redirectUrlLabel = new System.Windows.Forms.Label();
            this.getUserTokenButton = new System.Windows.Forms.Button();
            this.userTokeLabel = new System.Windows.Forms.Label();
            this.userTokenTextBox = new System.Windows.Forms.TextBox();
            this.environmentModeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // appIdLabel
            // 
            this.appIdLabel.AutoSize = true;
            this.appIdLabel.Location = new System.Drawing.Point(44, 11);
            this.appIdLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.appIdLabel.Name = "appIdLabel";
            this.appIdLabel.Size = new System.Drawing.Size(40, 13);
            this.appIdLabel.TabIndex = 0;
            this.appIdLabel.Text = "App ID";
            // 
            // appIdTextBox
            // 
            this.appIdTextBox.Location = new System.Drawing.Point(86, 6);
            this.appIdTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.appIdTextBox.Name = "appIdTextBox";
            this.appIdTextBox.Size = new System.Drawing.Size(334, 20);
            this.appIdTextBox.TabIndex = 1;
            this.appIdTextBox.Text = "ENTER GUID HERE";
            this.appIdTextBox.Click += new System.EventHandler(this.AppIdTextBox_Click);
            // 
            // environmentModeGroupBox
            // 
            this.environmentModeGroupBox.Controls.Add(this.sandboxRadioButton);
            this.environmentModeGroupBox.Controls.Add(this.liveRadioButton);
            this.environmentModeGroupBox.Location = new System.Drawing.Point(7, 63);
            this.environmentModeGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.environmentModeGroupBox.Name = "environmentModeGroupBox";
            this.environmentModeGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.environmentModeGroupBox.Size = new System.Drawing.Size(412, 88);
            this.environmentModeGroupBox.TabIndex = 2;
            this.environmentModeGroupBox.TabStop = false;
            this.environmentModeGroupBox.Text = "Environment Mode";
            // 
            // sandboxRadioButton
            // 
            this.sandboxRadioButton.AutoSize = true;
            this.sandboxRadioButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sandboxRadioButton.Location = new System.Drawing.Point(19, 54);
            this.sandboxRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.sandboxRadioButton.Name = "sandboxRadioButton";
            this.sandboxRadioButton.Size = new System.Drawing.Size(67, 17);
            this.sandboxRadioButton.TabIndex = 1;
            this.sandboxRadioButton.TabStop = true;
            this.sandboxRadioButton.Text = "Sandbox";
            this.sandboxRadioButton.UseVisualStyleBackColor = true;
            this.sandboxRadioButton.CheckedChanged += new System.EventHandler(this.SandboxRadioButton_CheckedChanged);
            // 
            // liveRadioButton
            // 
            this.liveRadioButton.AutoSize = true;
            this.liveRadioButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.liveRadioButton.Location = new System.Drawing.Point(19, 25);
            this.liveRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.liveRadioButton.Name = "liveRadioButton";
            this.liveRadioButton.Size = new System.Drawing.Size(45, 17);
            this.liveRadioButton.TabIndex = 0;
            this.liveRadioButton.TabStop = true;
            this.liveRadioButton.Text = "Live";
            this.liveRadioButton.UseVisualStyleBackColor = true;
            this.liveRadioButton.CheckedChanged += new System.EventHandler(this.LiveRadioButton_CheckedChanged);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // redirecUrlTextBox
            // 
            this.redirecUrlTextBox.Location = new System.Drawing.Point(86, 33);
            this.redirecUrlTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.redirecUrlTextBox.Name = "redirecUrlTextBox";
            this.redirecUrlTextBox.Size = new System.Drawing.Size(334, 20);
            this.redirecUrlTextBox.TabIndex = 3;
            this.redirecUrlTextBox.Text = "ENTER REDIRECT URL HERE";
            this.redirecUrlTextBox.Click += new System.EventHandler(this.RedirecUrlTextBox_Click);
            // 
            // redirectUrlLabel
            // 
            this.redirectUrlLabel.AutoSize = true;
            this.redirectUrlLabel.Location = new System.Drawing.Point(12, 37);
            this.redirectUrlLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.redirectUrlLabel.Name = "redirectUrlLabel";
            this.redirectUrlLabel.Size = new System.Drawing.Size(72, 13);
            this.redirectUrlLabel.TabIndex = 4;
            this.redirectUrlLabel.Text = "Redirect URL";
            // 
            // getUserTokenButton
            // 
            this.getUserTokenButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.getUserTokenButton.Location = new System.Drawing.Point(7, 163);
            this.getUserTokenButton.Margin = new System.Windows.Forms.Padding(2);
            this.getUserTokenButton.Name = "getUserTokenButton";
            this.getUserTokenButton.Size = new System.Drawing.Size(413, 47);
            this.getUserTokenButton.TabIndex = 5;
            this.getUserTokenButton.Text = "Get User Token!";
            this.getUserTokenButton.UseVisualStyleBackColor = true;
            this.getUserTokenButton.Click += new System.EventHandler(this.GetUserTokenButton_Click);
            // 
            // userTokeLabel
            // 
            this.userTokeLabel.AutoSize = true;
            this.userTokeLabel.Location = new System.Drawing.Point(21, 223);
            this.userTokeLabel.Name = "userTokeLabel";
            this.userTokeLabel.Size = new System.Drawing.Size(63, 13);
            this.userTokeLabel.TabIndex = 6;
            this.userTokeLabel.Text = "User Token";
            // 
            // userTokenTextBox
            // 
            this.userTokenTextBox.Location = new System.Drawing.Point(86, 219);
            this.userTokenTextBox.Name = "userTokenTextBox";
            this.userTokenTextBox.ReadOnly = true;
            this.userTokenTextBox.Size = new System.Drawing.Size(334, 20);
            this.userTokenTextBox.TabIndex = 7;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 245);
            this.Controls.Add(this.userTokenTextBox);
            this.Controls.Add(this.userTokeLabel);
            this.Controls.Add(this.getUserTokenButton);
            this.Controls.Add(this.redirectUrlLabel);
            this.Controls.Add(this.redirecUrlTextBox);
            this.Controls.Add(this.environmentModeGroupBox);
            this.Controls.Add(this.appIdTextBox);
            this.Controls.Add(this.appIdLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainWindow";
            this.Text = "OAuth Example";
            this.environmentModeGroupBox.ResumeLayout(false);
            this.environmentModeGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label appIdLabel;
        private System.Windows.Forms.TextBox appIdTextBox;
        private System.Windows.Forms.GroupBox environmentModeGroupBox;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.TextBox redirecUrlTextBox;
        private System.Windows.Forms.Label redirectUrlLabel;
        private System.Windows.Forms.RadioButton sandboxRadioButton;
        private System.Windows.Forms.RadioButton liveRadioButton;
        private System.Windows.Forms.Button getUserTokenButton;
        private System.Windows.Forms.Label userTokeLabel;
        private System.Windows.Forms.TextBox userTokenTextBox;
    }
}

