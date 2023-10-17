namespace Multiple_Buttons
{
    partial class Form1
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
            this.firstButton = new System.Windows.Forms.Button();
            this.secondButton = new System.Windows.Forms.Button();
            this.thirdButton = new System.Windows.Forms.Button();
            this.myLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // firstButton
            // 
            this.firstButton.Location = new System.Drawing.Point(12, 33);
            this.firstButton.Name = "firstButton";
            this.firstButton.Size = new System.Drawing.Size(79, 23);
            this.firstButton.TabIndex = 0;
            this.firstButton.Text = "First Button";
            this.firstButton.UseVisualStyleBackColor = true;
            this.firstButton.Click += new System.EventHandler(this.firstButton_Click);
            // 
            // secondButton
            // 
            this.secondButton.Location = new System.Drawing.Point(130, 33);
            this.secondButton.Name = "secondButton";
            this.secondButton.Size = new System.Drawing.Size(94, 23);
            this.secondButton.TabIndex = 1;
            this.secondButton.Text = "Second Button";
            this.secondButton.UseVisualStyleBackColor = true;
            this.secondButton.Click += new System.EventHandler(this.secondButton_Click);
            // 
            // thirdButton
            // 
            this.thirdButton.Location = new System.Drawing.Point(263, 33);
            this.thirdButton.Name = "thirdButton";
            this.thirdButton.Size = new System.Drawing.Size(89, 23);
            this.thirdButton.TabIndex = 2;
            this.thirdButton.Text = "Third Button";
            this.thirdButton.UseVisualStyleBackColor = true;
            this.thirdButton.Click += new System.EventHandler(this.thirdButton_Click);
            // 
            // myLabel
            // 
            this.myLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.myLabel.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myLabel.Location = new System.Drawing.Point(37, 92);
            this.myLabel.Name = "myLabel";
            this.myLabel.Size = new System.Drawing.Size(291, 61);
            this.myLabel.TabIndex = 3;
            this.myLabel.Text = "Programming in Visual C# is fun!";
            this.myLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 185);
            this.Controls.Add(this.myLabel);
            this.Controls.Add(this.thirdButton);
            this.Controls.Add(this.secondButton);
            this.Controls.Add(this.firstButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button firstButton;
        private System.Windows.Forms.Button secondButton;
        private System.Windows.Forms.Button thirdButton;
        private System.Windows.Forms.Label myLabel;
    }
}

