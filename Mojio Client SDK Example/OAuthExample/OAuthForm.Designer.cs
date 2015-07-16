using System;
using System.ComponentModel;
using System.Windows.Forms;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
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
            this.getVehiclesButton = new System.Windows.Forms.Button();
            this.beginAsyncButton = new System.Windows.Forms.Button();
            this.getUserButton = new System.Windows.Forms.Button();
            this.getAllMojioButton = new System.Windows.Forms.Button();
            this.observeOldButton = new System.Windows.Forms.Button();
            this.vehicleIdTextBox = new System.Windows.Forms.TextBox();
            this.unsubscribeOldButton = new System.Windows.Forms.Button();
            this.getAllObserversButton = new System.Windows.Forms.Button();
            this.observeVehicleButton = new System.Windows.Forms.Button();
            this.observerIdTextBox = new System.Windows.Forms.TextBox();
            this.unobserveByIdButton = new System.Windows.Forms.Button();
            this.deleteObserverByIdButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.observerNameTextBox = new System.Windows.Forms.TextBox();
            this.codeWindowRichTextBox = new System.Windows.Forms.RichTextBox();
            this.clientCodeLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.consoleWindowRichTextBox = new System.Windows.Forms.RichTextBox();
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
            this.appIdTextBox.Text = "ENTER APPLICATION ID HERE";
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
            this.environmentModeGroupBox.Size = new System.Drawing.Size(412, 66);
            this.environmentModeGroupBox.TabIndex = 3;
            this.environmentModeGroupBox.TabStop = false;
            this.environmentModeGroupBox.Text = "Environment Mode";
            // 
            // sandboxRadioButton
            // 
            this.sandboxRadioButton.AutoSize = true;
            this.sandboxRadioButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sandboxRadioButton.Location = new System.Drawing.Point(19, 41);
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
            this.liveRadioButton.Location = new System.Drawing.Point(19, 20);
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
            this.redirecUrlTextBox.TabIndex = 2;
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
            this.redirectUrlLabel.TabIndex = 0;
            this.redirectUrlLabel.Text = "Redirect URL";
            // 
            // getUserTokenButton
            // 
            this.getUserTokenButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.getUserTokenButton.Location = new System.Drawing.Point(7, 137);
            this.getUserTokenButton.Margin = new System.Windows.Forms.Padding(2);
            this.getUserTokenButton.Name = "getUserTokenButton";
            this.getUserTokenButton.Size = new System.Drawing.Size(412, 24);
            this.getUserTokenButton.TabIndex = 4;
            this.getUserTokenButton.Text = "Get User Token!";
            this.getUserTokenButton.UseVisualStyleBackColor = true;
            this.getUserTokenButton.Click += new System.EventHandler(this.GetUserTokenButton_Click);
            // 
            // userTokeLabel
            // 
            this.userTokeLabel.AutoSize = true;
            this.userTokeLabel.Location = new System.Drawing.Point(21, 171);
            this.userTokeLabel.Name = "userTokeLabel";
            this.userTokeLabel.Size = new System.Drawing.Size(63, 13);
            this.userTokeLabel.TabIndex = 0;
            this.userTokeLabel.Text = "User Token";
            // 
            // userTokenTextBox
            // 
            this.userTokenTextBox.Location = new System.Drawing.Point(86, 167);
            this.userTokenTextBox.Name = "userTokenTextBox";
            this.userTokenTextBox.ReadOnly = true;
            this.userTokenTextBox.Size = new System.Drawing.Size(334, 20);
            this.userTokenTextBox.TabIndex = 5;
            // 
            // getVehiclesButton
            // 
            this.getVehiclesButton.Location = new System.Drawing.Point(7, 312);
            this.getVehiclesButton.Name = "getVehiclesButton";
            this.getVehiclesButton.Size = new System.Drawing.Size(412, 24);
            this.getVehiclesButton.TabIndex = 9;
            this.getVehiclesButton.Text = "Get All Vehicles";
            this.getVehiclesButton.UseVisualStyleBackColor = true;
            this.getVehiclesButton.Click += new System.EventHandler(this.getVehiclesButton_Click);
            // 
            // beginAsyncButton
            // 
            this.beginAsyncButton.Location = new System.Drawing.Point(7, 207);
            this.beginAsyncButton.Name = "beginAsyncButton";
            this.beginAsyncButton.Size = new System.Drawing.Size(412, 24);
            this.beginAsyncButton.TabIndex = 6;
            this.beginAsyncButton.Text = "Begin Async";
            this.beginAsyncButton.UseVisualStyleBackColor = true;
            this.beginAsyncButton.Click += new System.EventHandler(this.beginAsyncButton_Click);
            // 
            // getUserButton
            // 
            this.getUserButton.Location = new System.Drawing.Point(7, 253);
            this.getUserButton.Name = "getUserButton";
            this.getUserButton.Size = new System.Drawing.Size(412, 24);
            this.getUserButton.TabIndex = 7;
            this.getUserButton.Text = "Get User";
            this.getUserButton.UseVisualStyleBackColor = true;
            this.getUserButton.Click += new System.EventHandler(this.getUserButton_Click);
            // 
            // getAllMojioButton
            // 
            this.getAllMojioButton.Location = new System.Drawing.Point(7, 283);
            this.getAllMojioButton.Name = "getAllMojioButton";
            this.getAllMojioButton.Size = new System.Drawing.Size(412, 24);
            this.getAllMojioButton.TabIndex = 8;
            this.getAllMojioButton.Text = "Get All Mojios";
            this.getAllMojioButton.UseVisualStyleBackColor = true;
            this.getAllMojioButton.Click += new System.EventHandler(this.getAllMojioButton_Click);
            // 
            // observeOldButton
            // 
            this.observeOldButton.Enabled = false;
            this.observeOldButton.Location = new System.Drawing.Point(7, 442);
            this.observeOldButton.Name = "observeOldButton";
            this.observeOldButton.Size = new System.Drawing.Size(412, 24);
            this.observeOldButton.TabIndex = 13;
            this.observeOldButton.Text = "Observer Vehicle (Old)";
            this.observeOldButton.UseVisualStyleBackColor = true;
            this.observeOldButton.Click += new System.EventHandler(this.observeOldButton_Click);
            // 
            // vehicleIdTextBox
            // 
            this.vehicleIdTextBox.Location = new System.Drawing.Point(7, 415);
            this.vehicleIdTextBox.Name = "vehicleIdTextBox";
            this.vehicleIdTextBox.Size = new System.Drawing.Size(412, 20);
            this.vehicleIdTextBox.TabIndex = 12;
            this.vehicleIdTextBox.Text = "Vehicle Id To Observer";
            this.vehicleIdTextBox.Click += new System.EventHandler(this.vehicleIdTextBox_Click);
            // 
            // unsubscribeOldButton
            // 
            this.unsubscribeOldButton.Enabled = false;
            this.unsubscribeOldButton.Location = new System.Drawing.Point(7, 556);
            this.unsubscribeOldButton.Name = "unsubscribeOldButton";
            this.unsubscribeOldButton.Size = new System.Drawing.Size(412, 24);
            this.unsubscribeOldButton.TabIndex = 0;
            this.unsubscribeOldButton.Text = "Unsubscribe Observer (Old)";
            this.unsubscribeOldButton.UseVisualStyleBackColor = true;
            this.unsubscribeOldButton.Click += new System.EventHandler(this.unsubscribeOldButton_Click);
            // 
            // getAllObserversButton
            // 
            this.getAllObserversButton.Location = new System.Drawing.Point(7, 340);
            this.getAllObserversButton.Name = "getAllObserversButton";
            this.getAllObserversButton.Size = new System.Drawing.Size(412, 24);
            this.getAllObserversButton.TabIndex = 10;
            this.getAllObserversButton.Text = "Get All Observers";
            this.getAllObserversButton.UseVisualStyleBackColor = true;
            this.getAllObserversButton.Click += new System.EventHandler(this.getAllObserversButton_Click);
            // 
            // observeVehicleButton
            // 
            this.observeVehicleButton.Location = new System.Drawing.Point(8, 472);
            this.observeVehicleButton.Name = "observeVehicleButton";
            this.observeVehicleButton.Size = new System.Drawing.Size(412, 24);
            this.observeVehicleButton.TabIndex = 14;
            this.observeVehicleButton.Text = "Observe Vehicle (New)";
            this.observeVehicleButton.UseVisualStyleBackColor = true;
            this.observeVehicleButton.Click += new System.EventHandler(this.observeVehicleButton_Click);
            // 
            // observerIdTextBox
            // 
            this.observerIdTextBox.Location = new System.Drawing.Point(8, 525);
            this.observerIdTextBox.Name = "observerIdTextBox";
            this.observerIdTextBox.Size = new System.Drawing.Size(412, 20);
            this.observerIdTextBox.TabIndex = 15;
            this.observerIdTextBox.Text = "Observer Id";
            this.observerIdTextBox.Click += new System.EventHandler(this.ObserverIdTextBox_Click);
            // 
            // unobserveByIdButton
            // 
            this.unobserveByIdButton.Location = new System.Drawing.Point(8, 584);
            this.unobserveByIdButton.Name = "unobserveByIdButton";
            this.unobserveByIdButton.Size = new System.Drawing.Size(412, 24);
            this.unobserveByIdButton.TabIndex = 16;
            this.unobserveByIdButton.Text = "Unobserve Observer (New)";
            this.unobserveByIdButton.UseVisualStyleBackColor = true;
            this.unobserveByIdButton.Click += new System.EventHandler(this.unobserveByIdButton_Click);
            // 
            // deleteObserverByIdButton
            // 
            this.deleteObserverByIdButton.Location = new System.Drawing.Point(8, 612);
            this.deleteObserverByIdButton.Name = "deleteObserverByIdButton";
            this.deleteObserverByIdButton.Size = new System.Drawing.Size(412, 24);
            this.deleteObserverByIdButton.TabIndex = 17;
            this.deleteObserverByIdButton.Text = "Delete Observer";
            this.deleteObserverByIdButton.UseVisualStyleBackColor = true;
            this.deleteObserverByIdButton.Click += new System.EventHandler(this.deleteObserverByIdButton_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(5, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(420, 4);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(4, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(420, 4);
            this.label2.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(3, 375);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(420, 4);
            this.label3.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(3, 509);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(420, 4);
            this.label4.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(3, 650);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(420, 4);
            this.label5.TabIndex = 25;
            // 
            // observerNameTextBox
            // 
            this.observerNameTextBox.Location = new System.Drawing.Point(7, 389);
            this.observerNameTextBox.Name = "observerNameTextBox";
            this.observerNameTextBox.Size = new System.Drawing.Size(412, 20);
            this.observerNameTextBox.TabIndex = 11;
            this.observerNameTextBox.Text = "Observer Name";
            this.observerNameTextBox.Click += new System.EventHandler(this.observerNameTextBox_Click);
            // 
            // codeWindowRichTextBox
            // 
            this.codeWindowRichTextBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeWindowRichTextBox.Location = new System.Drawing.Point(450, 30);
            this.codeWindowRichTextBox.Name = "codeWindowRichTextBox";
            this.codeWindowRichTextBox.Size = new System.Drawing.Size(486, 286);
            this.codeWindowRichTextBox.TabIndex = 18;
            this.codeWindowRichTextBox.Text = "";
            // 
            // clientCodeLabel
            // 
            this.clientCodeLabel.AutoSize = true;
            this.clientCodeLabel.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientCodeLabel.Location = new System.Drawing.Point(450, 7);
            this.clientCodeLabel.Name = "clientCodeLabel";
            this.clientCodeLabel.Size = new System.Drawing.Size(141, 20);
            this.clientCodeLabel.TabIndex = 28;
            this.clientCodeLabel.Text = "C#: Mojio Client Code";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(454, 340);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 20);
            this.label6.TabIndex = 29;
            this.label6.Text = "Console";
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(442, 329);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(500, 4);
            this.label7.TabIndex = 30;
            // 
            // consoleWindowRichTextBox
            // 
            this.consoleWindowRichTextBox.BackColor = System.Drawing.SystemColors.WindowText;
            this.consoleWindowRichTextBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consoleWindowRichTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.consoleWindowRichTextBox.Location = new System.Drawing.Point(450, 363);
            this.consoleWindowRichTextBox.Name = "consoleWindowRichTextBox";
            this.consoleWindowRichTextBox.Size = new System.Drawing.Size(486, 291);
            this.consoleWindowRichTextBox.TabIndex = 19;
            this.consoleWindowRichTextBox.Text = "";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 665);
            this.Controls.Add(this.consoleWindowRichTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.clientCodeLabel);
            this.Controls.Add(this.codeWindowRichTextBox);
            this.Controls.Add(this.observerNameTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deleteObserverByIdButton);
            this.Controls.Add(this.unobserveByIdButton);
            this.Controls.Add(this.observerIdTextBox);
            this.Controls.Add(this.observeVehicleButton);
            this.Controls.Add(this.getAllObserversButton);
            this.Controls.Add(this.unsubscribeOldButton);
            this.Controls.Add(this.vehicleIdTextBox);
            this.Controls.Add(this.observeOldButton);
            this.Controls.Add(this.getAllMojioButton);
            this.Controls.Add(this.getUserButton);
            this.Controls.Add(this.beginAsyncButton);
            this.Controls.Add(this.getVehiclesButton);
            this.Controls.Add(this.userTokenTextBox);
            this.Controls.Add(this.userTokeLabel);
            this.Controls.Add(this.getUserTokenButton);
            this.Controls.Add(this.redirectUrlLabel);
            this.Controls.Add(this.redirecUrlTextBox);
            this.Controls.Add(this.environmentModeGroupBox);
            this.Controls.Add(this.appIdTextBox);
            this.Controls.Add(this.appIdLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainWindow";
            this.Text = "C# Client Code Generator";
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
        private System.Windows.Forms.Button getVehiclesButton;
        private System.Windows.Forms.Button beginAsyncButton;
        private System.Windows.Forms.Button getUserButton;
        private System.Windows.Forms.Button getAllMojioButton;
        private System.Windows.Forms.Button observeOldButton;
        private System.Windows.Forms.TextBox vehicleIdTextBox;
        private System.Windows.Forms.Button unsubscribeOldButton;
        private System.Windows.Forms.Button getAllObserversButton;
        private System.Windows.Forms.Button observeVehicleButton;
        private System.Windows.Forms.TextBox observerIdTextBox;
        private System.Windows.Forms.Button unobserveByIdButton;
        private System.Windows.Forms.Button deleteObserverByIdButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox observerNameTextBox;
        private System.Windows.Forms.RichTextBox codeWindowRichTextBox;
        private System.Windows.Forms.Label clientCodeLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox consoleWindowRichTextBox;
    }
}

