namespace RadioButton_control
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
            this.displayButton = new System.Windows.Forms.Button();
            this.buttonType = new System.Windows.Forms.GroupBox();
            this.retryCancelRadioButton = new System.Windows.Forms.RadioButton();
            this.yesNoRadioButton = new System.Windows.Forms.RadioButton();
            this.yesNoCancelRadioButton = new System.Windows.Forms.RadioButton();
            this.abortRetryIgnoreRadioButton = new System.Windows.Forms.RadioButton();
            this.okCancelRadioButton = new System.Windows.Forms.RadioButton();
            this.okRadioButton = new System.Windows.Forms.RadioButton();
            this.iconType = new System.Windows.Forms.GroupBox();
            this.warningRadioButton = new System.Windows.Forms.RadioButton();
            this.stopRadioButton = new System.Windows.Forms.RadioButton();
            this.questionRadioButton = new System.Windows.Forms.RadioButton();
            this.informationRadioButton = new System.Windows.Forms.RadioButton();
            this.handRadioButton = new System.Windows.Forms.RadioButton();
            this.exclamationRadioButton = new System.Windows.Forms.RadioButton();
            this.errorRadioButton = new System.Windows.Forms.RadioButton();
            this.asteriskRadioButton = new System.Windows.Forms.RadioButton();
            this.displayLabel = new System.Windows.Forms.Label();
            this.buttonType.SuspendLayout();
            this.iconType.SuspendLayout();
            this.SuspendLayout();
            // 
            // displayButton
            // 
            this.displayButton.Location = new System.Drawing.Point(12, 174);
            this.displayButton.Name = "displayButton";
            this.displayButton.Size = new System.Drawing.Size(153, 47);
            this.displayButton.TabIndex = 0;
            this.displayButton.Text = "Display";
            this.displayButton.UseVisualStyleBackColor = true;
            this.displayButton.Click += new System.EventHandler(this.displayButton_Click);
            // 
            // buttonType
            // 
            this.buttonType.Controls.Add(this.retryCancelRadioButton);
            this.buttonType.Controls.Add(this.yesNoRadioButton);
            this.buttonType.Controls.Add(this.yesNoCancelRadioButton);
            this.buttonType.Controls.Add(this.abortRetryIgnoreRadioButton);
            this.buttonType.Controls.Add(this.okCancelRadioButton);
            this.buttonType.Controls.Add(this.okRadioButton);
            this.buttonType.Location = new System.Drawing.Point(12, 12);
            this.buttonType.Name = "buttonType";
            this.buttonType.Size = new System.Drawing.Size(153, 160);
            this.buttonType.TabIndex = 1;
            this.buttonType.TabStop = false;
            this.buttonType.Text = "Button Type";
            // 
            // retryCancelRadioButton
            // 
            this.retryCancelRadioButton.AutoSize = true;
            this.retryCancelRadioButton.Location = new System.Drawing.Point(6, 134);
            this.retryCancelRadioButton.Name = "retryCancelRadioButton";
            this.retryCancelRadioButton.Size = new System.Drawing.Size(83, 17);
            this.retryCancelRadioButton.TabIndex = 5;
            this.retryCancelRadioButton.TabStop = true;
            this.retryCancelRadioButton.Text = "RetryCancel";
            this.retryCancelRadioButton.UseVisualStyleBackColor = true;
            this.retryCancelRadioButton.CheckedChanged += new System.EventHandler(this.buttonType_CheckedChanged);
            // 
            // yesNoRadioButton
            // 
            this.yesNoRadioButton.AutoSize = true;
            this.yesNoRadioButton.Location = new System.Drawing.Point(6, 111);
            this.yesNoRadioButton.Name = "yesNoRadioButton";
            this.yesNoRadioButton.Size = new System.Drawing.Size(57, 17);
            this.yesNoRadioButton.TabIndex = 4;
            this.yesNoRadioButton.TabStop = true;
            this.yesNoRadioButton.Text = "YesNo";
            this.yesNoRadioButton.UseVisualStyleBackColor = true;
            this.yesNoRadioButton.CheckedChanged += new System.EventHandler(this.buttonType_CheckedChanged);
            // 
            // yesNoCancelRadioButton
            // 
            this.yesNoCancelRadioButton.AutoSize = true;
            this.yesNoCancelRadioButton.Location = new System.Drawing.Point(6, 88);
            this.yesNoCancelRadioButton.Name = "yesNoCancelRadioButton";
            this.yesNoCancelRadioButton.Size = new System.Drawing.Size(90, 17);
            this.yesNoCancelRadioButton.TabIndex = 3;
            this.yesNoCancelRadioButton.TabStop = true;
            this.yesNoCancelRadioButton.Text = "YesNoCancel";
            this.yesNoCancelRadioButton.UseVisualStyleBackColor = true;
            this.yesNoCancelRadioButton.CheckedChanged += new System.EventHandler(this.buttonType_CheckedChanged);
            // 
            // abortRetryIgnoreRadioButton
            // 
            this.abortRetryIgnoreRadioButton.AutoSize = true;
            this.abortRetryIgnoreRadioButton.Location = new System.Drawing.Point(6, 65);
            this.abortRetryIgnoreRadioButton.Name = "abortRetryIgnoreRadioButton";
            this.abortRetryIgnoreRadioButton.Size = new System.Drawing.Size(105, 17);
            this.abortRetryIgnoreRadioButton.TabIndex = 2;
            this.abortRetryIgnoreRadioButton.TabStop = true;
            this.abortRetryIgnoreRadioButton.Text = "AbortRetryIgnore";
            this.abortRetryIgnoreRadioButton.UseVisualStyleBackColor = true;
            this.abortRetryIgnoreRadioButton.CheckedChanged += new System.EventHandler(this.buttonType_CheckedChanged);
            // 
            // okCancelRadioButton
            // 
            this.okCancelRadioButton.AutoSize = true;
            this.okCancelRadioButton.Location = new System.Drawing.Point(6, 42);
            this.okCancelRadioButton.Name = "okCancelRadioButton";
            this.okCancelRadioButton.Size = new System.Drawing.Size(73, 17);
            this.okCancelRadioButton.TabIndex = 1;
            this.okCancelRadioButton.TabStop = true;
            this.okCancelRadioButton.Text = "OKCancel";
            this.okCancelRadioButton.UseVisualStyleBackColor = true;
            this.okCancelRadioButton.CheckedChanged += new System.EventHandler(this.buttonType_CheckedChanged);
            // 
            // okRadioButton
            // 
            this.okRadioButton.AutoSize = true;
            this.okRadioButton.Location = new System.Drawing.Point(6, 19);
            this.okRadioButton.Name = "okRadioButton";
            this.okRadioButton.Size = new System.Drawing.Size(40, 17);
            this.okRadioButton.TabIndex = 0;
            this.okRadioButton.TabStop = true;
            this.okRadioButton.Text = "OK";
            this.okRadioButton.UseVisualStyleBackColor = true;
            this.okRadioButton.CheckedChanged += new System.EventHandler(this.buttonType_CheckedChanged);
            // 
            // iconType
            // 
            this.iconType.Controls.Add(this.warningRadioButton);
            this.iconType.Controls.Add(this.stopRadioButton);
            this.iconType.Controls.Add(this.questionRadioButton);
            this.iconType.Controls.Add(this.informationRadioButton);
            this.iconType.Controls.Add(this.handRadioButton);
            this.iconType.Controls.Add(this.exclamationRadioButton);
            this.iconType.Controls.Add(this.errorRadioButton);
            this.iconType.Controls.Add(this.asteriskRadioButton);
            this.iconType.Location = new System.Drawing.Point(171, 12);
            this.iconType.Name = "iconType";
            this.iconType.Size = new System.Drawing.Size(153, 209);
            this.iconType.TabIndex = 2;
            this.iconType.TabStop = false;
            this.iconType.Text = "Icon";
            // 
            // warningRadioButton
            // 
            this.warningRadioButton.AutoSize = true;
            this.warningRadioButton.Location = new System.Drawing.Point(6, 180);
            this.warningRadioButton.Name = "warningRadioButton";
            this.warningRadioButton.Size = new System.Drawing.Size(65, 17);
            this.warningRadioButton.TabIndex = 7;
            this.warningRadioButton.TabStop = true;
            this.warningRadioButton.Text = "Warning";
            this.warningRadioButton.UseVisualStyleBackColor = true;
            this.warningRadioButton.CheckedChanged += new System.EventHandler(this.iconType_CheckedChanged);
            // 
            // stopRadioButton
            // 
            this.stopRadioButton.AutoSize = true;
            this.stopRadioButton.Location = new System.Drawing.Point(6, 157);
            this.stopRadioButton.Name = "stopRadioButton";
            this.stopRadioButton.Size = new System.Drawing.Size(47, 17);
            this.stopRadioButton.TabIndex = 6;
            this.stopRadioButton.TabStop = true;
            this.stopRadioButton.Text = "Stop";
            this.stopRadioButton.UseVisualStyleBackColor = true;
            this.stopRadioButton.CheckedChanged += new System.EventHandler(this.iconType_CheckedChanged);
            // 
            // questionRadioButton
            // 
            this.questionRadioButton.AutoSize = true;
            this.questionRadioButton.Location = new System.Drawing.Point(6, 134);
            this.questionRadioButton.Name = "questionRadioButton";
            this.questionRadioButton.Size = new System.Drawing.Size(67, 17);
            this.questionRadioButton.TabIndex = 5;
            this.questionRadioButton.TabStop = true;
            this.questionRadioButton.Text = "Question";
            this.questionRadioButton.UseVisualStyleBackColor = true;
            this.questionRadioButton.CheckedChanged += new System.EventHandler(this.iconType_CheckedChanged);
            // 
            // informationRadioButton
            // 
            this.informationRadioButton.AutoSize = true;
            this.informationRadioButton.Location = new System.Drawing.Point(6, 111);
            this.informationRadioButton.Name = "informationRadioButton";
            this.informationRadioButton.Size = new System.Drawing.Size(77, 17);
            this.informationRadioButton.TabIndex = 4;
            this.informationRadioButton.TabStop = true;
            this.informationRadioButton.Text = "Information";
            this.informationRadioButton.UseVisualStyleBackColor = true;
            this.informationRadioButton.CheckedChanged += new System.EventHandler(this.iconType_CheckedChanged);
            // 
            // handRadioButton
            // 
            this.handRadioButton.AutoSize = true;
            this.handRadioButton.Location = new System.Drawing.Point(6, 88);
            this.handRadioButton.Name = "handRadioButton";
            this.handRadioButton.Size = new System.Drawing.Size(51, 17);
            this.handRadioButton.TabIndex = 3;
            this.handRadioButton.TabStop = true;
            this.handRadioButton.Text = "Hand";
            this.handRadioButton.UseVisualStyleBackColor = true;
            this.handRadioButton.CheckedChanged += new System.EventHandler(this.iconType_CheckedChanged);
            // 
            // exclamationRadioButton
            // 
            this.exclamationRadioButton.AutoSize = true;
            this.exclamationRadioButton.Location = new System.Drawing.Point(6, 65);
            this.exclamationRadioButton.Name = "exclamationRadioButton";
            this.exclamationRadioButton.Size = new System.Drawing.Size(82, 17);
            this.exclamationRadioButton.TabIndex = 2;
            this.exclamationRadioButton.TabStop = true;
            this.exclamationRadioButton.Text = "Exclamation";
            this.exclamationRadioButton.UseVisualStyleBackColor = true;
            this.exclamationRadioButton.CheckedChanged += new System.EventHandler(this.iconType_CheckedChanged);
            // 
            // errorRadioButton
            // 
            this.errorRadioButton.AutoSize = true;
            this.errorRadioButton.Location = new System.Drawing.Point(6, 42);
            this.errorRadioButton.Name = "errorRadioButton";
            this.errorRadioButton.Size = new System.Drawing.Size(47, 17);
            this.errorRadioButton.TabIndex = 1;
            this.errorRadioButton.TabStop = true;
            this.errorRadioButton.Text = "Error";
            this.errorRadioButton.UseVisualStyleBackColor = true;
            this.errorRadioButton.CheckedChanged += new System.EventHandler(this.iconType_CheckedChanged);
            // 
            // asteriskRadioButton
            // 
            this.asteriskRadioButton.AutoSize = true;
            this.asteriskRadioButton.Location = new System.Drawing.Point(6, 19);
            this.asteriskRadioButton.Name = "asteriskRadioButton";
            this.asteriskRadioButton.Size = new System.Drawing.Size(62, 17);
            this.asteriskRadioButton.TabIndex = 0;
            this.asteriskRadioButton.TabStop = true;
            this.asteriskRadioButton.Text = "Asterisk";
            this.asteriskRadioButton.UseVisualStyleBackColor = true;
            this.asteriskRadioButton.CheckedChanged += new System.EventHandler(this.iconType_CheckedChanged);
            // 
            // displayLabel
            // 
            this.displayLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.displayLabel.Location = new System.Drawing.Point(12, 229);
            this.displayLabel.Name = "displayLabel";
            this.displayLabel.Size = new System.Drawing.Size(312, 33);
            this.displayLabel.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 271);
            this.Controls.Add(this.displayLabel);
            this.Controls.Add(this.iconType);
            this.Controls.Add(this.buttonType);
            this.Controls.Add(this.displayButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.buttonType.ResumeLayout(false);
            this.buttonType.PerformLayout();
            this.iconType.ResumeLayout(false);
            this.iconType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button displayButton;
        private System.Windows.Forms.GroupBox buttonType;
        private System.Windows.Forms.RadioButton retryCancelRadioButton;
        private System.Windows.Forms.RadioButton yesNoRadioButton;
        private System.Windows.Forms.RadioButton yesNoCancelRadioButton;
        private System.Windows.Forms.RadioButton abortRetryIgnoreRadioButton;
        private System.Windows.Forms.RadioButton okCancelRadioButton;
        private System.Windows.Forms.RadioButton okRadioButton;
        private System.Windows.Forms.GroupBox iconType;
        private System.Windows.Forms.RadioButton warningRadioButton;
        private System.Windows.Forms.RadioButton stopRadioButton;
        private System.Windows.Forms.RadioButton questionRadioButton;
        private System.Windows.Forms.RadioButton informationRadioButton;
        private System.Windows.Forms.RadioButton handRadioButton;
        private System.Windows.Forms.RadioButton exclamationRadioButton;
        private System.Windows.Forms.RadioButton errorRadioButton;
        private System.Windows.Forms.RadioButton asteriskRadioButton;
        private System.Windows.Forms.Label displayLabel;
    }
}

