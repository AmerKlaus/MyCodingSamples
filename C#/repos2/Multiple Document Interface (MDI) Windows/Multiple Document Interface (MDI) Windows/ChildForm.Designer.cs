﻿namespace Multiple_Document_Interface__MDI__Windows
{
    partial class ChildForm
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
            this.displayPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.displayPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // displayPictureBox
            // 
            this.displayPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.displayPictureBox.ErrorImage = null;
            this.displayPictureBox.Location = new System.Drawing.Point(12, 12);
            this.displayPictureBox.Name = "displayPictureBox";
            this.displayPictureBox.Size = new System.Drawing.Size(361, 315);
            this.displayPictureBox.TabIndex = 0;
            this.displayPictureBox.TabStop = false;
            // 
            // ChildForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 339);
            this.Controls.Add(this.displayPictureBox);
            this.Name = "ChildForm";
            this.Text = "UsingMDI";
            ((System.ComponentModel.ISupportInitialize)(this.displayPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox displayPictureBox;
    }
}