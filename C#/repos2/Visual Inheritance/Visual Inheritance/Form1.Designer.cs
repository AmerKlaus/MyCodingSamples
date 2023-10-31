namespace Visual_Inheritance
{
    partial class VisualInheritanceBaseForm
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
            this.bugLabel = new System.Windows.Forms.Label();
            this.learnMoreButton = new System.Windows.Forms.Button();
            this.copyrightLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bugLabel
            // 
            this.bugLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bugLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bugLabel.Location = new System.Drawing.Point(12, 9);
            this.bugLabel.Name = "bugLabel";
            this.bugLabel.Size = new System.Drawing.Size(271, 40);
            this.bugLabel.TabIndex = 0;
            this.bugLabel.Text = "Bugs, Bugs, Bugs";
            this.bugLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // learnMoreButton
            // 
            this.learnMoreButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.learnMoreButton.Location = new System.Drawing.Point(12, 67);
            this.learnMoreButton.Name = "learnMoreButton";
            this.learnMoreButton.Size = new System.Drawing.Size(125, 49);
            this.learnMoreButton.TabIndex = 1;
            this.learnMoreButton.Text = "Learn More";
            this.learnMoreButton.UseVisualStyleBackColor = true;
            this.learnMoreButton.Click += new System.EventHandler(this.learnMoreButton_Click);
            // 
            // copyrightLabel
            // 
            this.copyrightLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.copyrightLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyrightLabel.Location = new System.Drawing.Point(12, 132);
            this.copyrightLabel.Name = "copyrightLabel";
            this.copyrightLabel.Size = new System.Drawing.Size(271, 22);
            this.copyrightLabel.TabIndex = 2;
            this.copyrightLabel.Text = "Copyright 2017, by Deitel & Associates, Inc.";
            this.copyrightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VisualInheritanceBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 163);
            this.Controls.Add(this.copyrightLabel);
            this.Controls.Add(this.learnMoreButton);
            this.Controls.Add(this.bugLabel);
            this.Name = "VisualInheritanceBaseForm";
            this.Text = "VisualInheritanceBase";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label bugLabel;
        private System.Windows.Forms.Button learnMoreButton;
        private System.Windows.Forms.Label copyrightLabel;
    }
}

