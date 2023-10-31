namespace DateTimePicker_control
{
    partial class DateTimePickerForm
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
            this.dropOffLabel = new System.Windows.Forms.Label();
            this.deliveryDateLabel = new System.Windows.Forms.Label();
            this.dropOffDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.outputLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dropOffLabel
            // 
            this.dropOffLabel.AutoSize = true;
            this.dropOffLabel.Location = new System.Drawing.Point(42, 27);
            this.dropOffLabel.Name = "dropOffLabel";
            this.dropOffLabel.Size = new System.Drawing.Size(74, 13);
            this.dropOffLabel.TabIndex = 0;
            this.dropOffLabel.Text = "Drop off Date:";
            // 
            // deliveryDateLabel
            // 
            this.deliveryDateLabel.AutoSize = true;
            this.deliveryDateLabel.Location = new System.Drawing.Point(42, 106);
            this.deliveryDateLabel.Name = "deliveryDateLabel";
            this.deliveryDateLabel.Size = new System.Drawing.Size(120, 13);
            this.deliveryDateLabel.TabIndex = 1;
            this.deliveryDateLabel.Text = "Estimated Delivery Date";
            // 
            // dropOffDateTimePicker
            // 
            this.dropOffDateTimePicker.CustomFormat = "dddd, MMMM, d, yyyy";
            this.dropOffDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dropOffDateTimePicker.Location = new System.Drawing.Point(45, 61);
            this.dropOffDateTimePicker.Name = "dropOffDateTimePicker";
            this.dropOffDateTimePicker.Size = new System.Drawing.Size(203, 20);
            this.dropOffDateTimePicker.TabIndex = 2;
            this.dropOffDateTimePicker.ValueChanged += new System.EventHandler(this.dropOffDateTimePicker_ValueChanged);
            // 
            // outputLabel
            // 
            this.outputLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.outputLabel.Location = new System.Drawing.Point(45, 148);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(203, 24);
            this.outputLabel.TabIndex = 3;
            // 
            // DateTimePickerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 199);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.dropOffDateTimePicker);
            this.Controls.Add(this.deliveryDateLabel);
            this.Controls.Add(this.dropOffLabel);
            this.Name = "DateTimePickerForm";
            this.Text = "DateTimePickerTest";
            this.Load += new System.EventHandler(this.DateTimePickerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label dropOffLabel;
        private System.Windows.Forms.Label deliveryDateLabel;
        private System.Windows.Forms.DateTimePicker dropOffDateTimePicker;
        private System.Windows.Forms.Label outputLabel;
    }
}

