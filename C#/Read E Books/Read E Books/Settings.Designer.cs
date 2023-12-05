namespace Read_E_Books
{
    partial class Settings
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.changeUsernameTextBox = new System.Windows.Forms.TextBox();
            this.changePasswordTextBox = new System.Windows.Forms.TextBox();
            this.homeButton = new System.Windows.Forms.Button();
            this.changePasswordButton = new System.Windows.Forms.Button();
            this.changeUsernameButton = new System.Windows.Forms.Button();
            this.settingsLabel = new System.Windows.Forms.Label();
            this.accountTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.1F);
            this.label2.Location = new System.Drawing.Point(38, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.1F);
            this.label1.Location = new System.Drawing.Point(34, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Username:";
            // 
            // changeUsernameTextBox
            // 
            this.changeUsernameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.1F);
            this.changeUsernameTextBox.Location = new System.Drawing.Point(117, 107);
            this.changeUsernameTextBox.Name = "changeUsernameTextBox";
            this.changeUsernameTextBox.Size = new System.Drawing.Size(159, 23);
            this.changeUsernameTextBox.TabIndex = 13;
            // 
            // changePasswordTextBox
            // 
            this.changePasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.1F);
            this.changePasswordTextBox.Location = new System.Drawing.Point(117, 190);
            this.changePasswordTextBox.Name = "changePasswordTextBox";
            this.changePasswordTextBox.Size = new System.Drawing.Size(159, 23);
            this.changePasswordTextBox.TabIndex = 12;
            this.changePasswordTextBox.UseSystemPasswordChar = true;
            // 
            // homeButton
            // 
            this.homeButton.Location = new System.Drawing.Point(12, 12);
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(84, 23);
            this.homeButton.TabIndex = 11;
            this.homeButton.Text = "Home Button";
            this.homeButton.UseVisualStyleBackColor = true;
            this.homeButton.Click += new System.EventHandler(this.homeButton_Click);
            // 
            // changePasswordButton
            // 
            this.changePasswordButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.1F);
            this.changePasswordButton.Location = new System.Drawing.Point(279, 180);
            this.changePasswordButton.Name = "changePasswordButton";
            this.changePasswordButton.Size = new System.Drawing.Size(116, 50);
            this.changePasswordButton.TabIndex = 10;
            this.changePasswordButton.Text = "Set as new password";
            this.changePasswordButton.UseVisualStyleBackColor = true;
            this.changePasswordButton.Click += new System.EventHandler(this.changePasswordButton_Click);
            // 
            // changeUsernameButton
            // 
            this.changeUsernameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.1F);
            this.changeUsernameButton.Location = new System.Drawing.Point(279, 97);
            this.changeUsernameButton.Name = "changeUsernameButton";
            this.changeUsernameButton.Size = new System.Drawing.Size(115, 42);
            this.changeUsernameButton.TabIndex = 9;
            this.changeUsernameButton.Text = "Set as new username";
            this.changeUsernameButton.UseVisualStyleBackColor = true;
            this.changeUsernameButton.Click += new System.EventHandler(this.changeUsernameButton_Click);
            // 
            // settingsLabel
            // 
            this.settingsLabel.AutoSize = true;
            this.settingsLabel.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsLabel.ForeColor = System.Drawing.Color.Green;
            this.settingsLabel.Location = new System.Drawing.Point(286, 12);
            this.settingsLabel.Name = "settingsLabel";
            this.settingsLabel.Size = new System.Drawing.Size(108, 30);
            this.settingsLabel.TabIndex = 16;
            this.settingsLabel.Text = "Settings";
            // 
            // accountTextBox
            // 
            this.accountTextBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountTextBox.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.accountTextBox.Location = new System.Drawing.Point(401, 36);
            this.accountTextBox.Multiline = true;
            this.accountTextBox.Name = "accountTextBox";
            this.accountTextBox.ReadOnly = true;
            this.accountTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.accountTextBox.Size = new System.Drawing.Size(261, 297);
            this.accountTextBox.TabIndex = 17;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 345);
            this.Controls.Add(this.accountTextBox);
            this.Controls.Add(this.settingsLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.changeUsernameTextBox);
            this.Controls.Add(this.changePasswordTextBox);
            this.Controls.Add(this.homeButton);
            this.Controls.Add(this.changePasswordButton);
            this.Controls.Add(this.changeUsernameButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.MaximizeBox = false;
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox changeUsernameTextBox;
        private System.Windows.Forms.TextBox changePasswordTextBox;
        private System.Windows.Forms.Button homeButton;
        private System.Windows.Forms.Button changePasswordButton;
        private System.Windows.Forms.Button changeUsernameButton;
        private System.Windows.Forms.Label settingsLabel;
        private System.Windows.Forms.TextBox accountTextBox;
    }
}