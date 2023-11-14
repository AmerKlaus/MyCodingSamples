namespace LINQToFileDirectory
{
    partial class LINQToFileDirectoryForm
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
            this.resultsTextBox = new System.Windows.Forms.TextBox();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.messageLabel = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.directoryLabel = new System.Windows.Forms.Label();
            this.directoryTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // resultsTextBox
            // 
            this.resultsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resultsTextBox.Location = new System.Drawing.Point(12, 104);
            this.resultsTextBox.Multiline = true;
            this.resultsTextBox.Name = "resultsTextBox";
            this.resultsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.resultsTextBox.Size = new System.Drawing.Size(422, 293);
            this.resultsTextBox.TabIndex = 5;
            // 
            // pathTextBox
            // 
            this.pathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pathTextBox.Location = new System.Drawing.Point(12, 23);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(422, 20);
            this.pathTextBox.TabIndex = 4;
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(12, 7);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(106, 13);
            this.messageLabel.TabIndex = 3;
            this.messageLabel.Text = "Enter path to search:";
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(316, 49);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(114, 23);
            this.searchButton.TabIndex = 6;
            this.searchButton.Text = "Search Directory";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // directoryLabel
            // 
            this.directoryLabel.AutoSize = true;
            this.directoryLabel.Location = new System.Drawing.Point(12, 85);
            this.directoryLabel.Name = "directoryLabel";
            this.directoryLabel.Size = new System.Drawing.Size(52, 13);
            this.directoryLabel.TabIndex = 7;
            this.directoryLabel.Text = "Directory:";
            // 
            // directoryTextBox
            // 
            this.directoryTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.directoryTextBox.Location = new System.Drawing.Point(70, 78);
            this.directoryTextBox.Name = "directoryTextBox";
            this.directoryTextBox.Size = new System.Drawing.Size(360, 20);
            this.directoryTextBox.TabIndex = 8;
            // 
            // LINQToFileDirectoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 409);
            this.Controls.Add(this.directoryTextBox);
            this.Controls.Add(this.directoryLabel);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.resultsTextBox);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.messageLabel);
            this.Name = "LINQToFileDirectoryForm";
            this.Text = "LINQToFileDirectory";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox resultsTextBox;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label directoryLabel;
        private System.Windows.Forms.TextBox directoryTextBox;
    }
}

