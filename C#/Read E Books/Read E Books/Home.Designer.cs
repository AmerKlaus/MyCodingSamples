namespace Read_E_Books
{
    partial class Home
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
            this.libraryButton = new System.Windows.Forms.Button();
            this.shopButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.homeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // libraryButton
            // 
            this.libraryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.1F);
            this.libraryButton.Location = new System.Drawing.Point(177, 114);
            this.libraryButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.libraryButton.Name = "libraryButton";
            this.libraryButton.Size = new System.Drawing.Size(327, 54);
            this.libraryButton.TabIndex = 0;
            this.libraryButton.Text = "My Library";
            this.libraryButton.UseVisualStyleBackColor = true;
            this.libraryButton.Click += new System.EventHandler(this.libraryButton_Click);
            // 
            // shopButton
            // 
            this.shopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.1F);
            this.shopButton.Location = new System.Drawing.Point(177, 195);
            this.shopButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.shopButton.Name = "shopButton";
            this.shopButton.Size = new System.Drawing.Size(327, 54);
            this.shopButton.TabIndex = 1;
            this.shopButton.Text = "Bookstore";
            this.shopButton.UseVisualStyleBackColor = true;
            this.shopButton.Click += new System.EventHandler(this.shopButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.Location = new System.Drawing.Point(520, 5);
            this.settingsButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(72, 37);
            this.settingsButton.TabIndex = 2;
            this.settingsButton.Text = "Settings";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(598, 5);
            this.logoutButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(72, 37);
            this.logoutButton.TabIndex = 3;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // homeLabel
            // 
            this.homeLabel.AutoSize = true;
            this.homeLabel.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homeLabel.ForeColor = System.Drawing.Color.Green;
            this.homeLabel.Location = new System.Drawing.Point(304, 33);
            this.homeLabel.Name = "homeLabel";
            this.homeLabel.Size = new System.Drawing.Size(80, 30);
            this.homeLabel.TabIndex = 12;
            this.homeLabel.Text = "Home";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 345);
            this.Controls.Add(this.homeLabel);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.shopButton);
            this.Controls.Add(this.libraryButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.MaximizeBox = false;
            this.Name = "Home";
            this.Text = "Home";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button libraryButton;
        private System.Windows.Forms.Button shopButton;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Label homeLabel;
    }
}