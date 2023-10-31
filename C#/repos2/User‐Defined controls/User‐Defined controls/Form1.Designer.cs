namespace User_Defined_controls
{
    partial class clockForm
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
            this.clockUserControl = new User_Defined_controls.ClockUserControl();
            this.SuspendLayout();
            // 
            // clockUserControl
            // 
            this.clockUserControl.AllowDrop = true;
            this.clockUserControl.BackColor = System.Drawing.Color.White;
            this.clockUserControl.Location = new System.Drawing.Point(12, 12);
            this.clockUserControl.Name = "clockUserControl";
            this.clockUserControl.Size = new System.Drawing.Size(256, 197);
            this.clockUserControl.TabIndex = 0;
            // 
            // clockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 221);
            this.Controls.Add(this.clockUserControl);
            this.Name = "clockForm";
            this.Text = "Clock";
            this.ResumeLayout(false);

        }

        #endregion

        private ClockUserControl clockUserControl;
    }
}

