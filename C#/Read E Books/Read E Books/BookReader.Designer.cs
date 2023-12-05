namespace Read_E_Books
{
    partial class BookReader
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
            this.bookContentTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // libraryButton
            // 
            this.libraryButton.Location = new System.Drawing.Point(12, 11);
            this.libraryButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.libraryButton.Name = "libraryButton";
            this.libraryButton.Size = new System.Drawing.Size(98, 31);
            this.libraryButton.TabIndex = 0;
            this.libraryButton.Text = "< Back to Library";
            this.libraryButton.UseVisualStyleBackColor = true;
            this.libraryButton.Click += new System.EventHandler(this.libraryButton_Click);
            // 
            // bookContentTextBox
            // 
            this.bookContentTextBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookContentTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.bookContentTextBox.Location = new System.Drawing.Point(20, 59);
            this.bookContentTextBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.bookContentTextBox.Multiline = true;
            this.bookContentTextBox.Name = "bookContentTextBox";
            this.bookContentTextBox.ReadOnly = true;
            this.bookContentTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.bookContentTextBox.Size = new System.Drawing.Size(299, 268);
            this.bookContentTextBox.TabIndex = 1;
            // 
            // BookReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 341);
            this.Controls.Add(this.bookContentTextBox);
            this.Controls.Add(this.libraryButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.MaximizeBox = false;
            this.Name = "BookReader";
            this.Text = "BookReader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button libraryButton;
        private System.Windows.Forms.TextBox bookContentTextBox;
    }
}