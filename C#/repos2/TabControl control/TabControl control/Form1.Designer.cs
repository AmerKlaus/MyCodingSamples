namespace TabControl_control
{
    partial class UsingTabsForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.colorPage = new System.Windows.Forms.TabPage();
            this.sizePage = new System.Windows.Forms.TabPage();
            this.messagePage = new System.Windows.Forms.TabPage();
            this.aboutPage = new System.Windows.Forms.TabPage();
            this.displayLabel = new System.Windows.Forms.Label();
            this.blackRadioButton = new System.Windows.Forms.RadioButton();
            this.redRadioButton = new System.Windows.Forms.RadioButton();
            this.greenRadioButton = new System.Windows.Forms.RadioButton();
            this.size20RadioButton = new System.Windows.Forms.RadioButton();
            this.size16RadioButton = new System.Windows.Forms.RadioButton();
            this.size12RadioButton = new System.Windows.Forms.RadioButton();
            this.goodbyeRadioButton = new System.Windows.Forms.RadioButton();
            this.helloRadioButton = new System.Windows.Forms.RadioButton();
            this.aboutLabel = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.colorPage.SuspendLayout();
            this.sizePage.SuspendLayout();
            this.messagePage.SuspendLayout();
            this.aboutPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.AllowDrop = true;
            this.tabControl.Controls.Add(this.colorPage);
            this.tabControl.Controls.Add(this.sizePage);
            this.tabControl.Controls.Add(this.messagePage);
            this.tabControl.Controls.Add(this.aboutPage);
            this.tabControl.Location = new System.Drawing.Point(19, 28);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(230, 157);
            this.tabControl.TabIndex = 0;
            // 
            // colorPage
            // 
            this.colorPage.BackColor = System.Drawing.SystemColors.Control;
            this.colorPage.Controls.Add(this.greenRadioButton);
            this.colorPage.Controls.Add(this.redRadioButton);
            this.colorPage.Controls.Add(this.blackRadioButton);
            this.colorPage.Location = new System.Drawing.Point(4, 22);
            this.colorPage.Name = "colorPage";
            this.colorPage.Size = new System.Drawing.Size(222, 131);
            this.colorPage.TabIndex = 0;
            this.colorPage.Text = "Color";
            // 
            // sizePage
            // 
            this.sizePage.BackColor = System.Drawing.SystemColors.Control;
            this.sizePage.Controls.Add(this.size20RadioButton);
            this.sizePage.Controls.Add(this.size16RadioButton);
            this.sizePage.Controls.Add(this.size12RadioButton);
            this.sizePage.Location = new System.Drawing.Point(4, 22);
            this.sizePage.Name = "sizePage";
            this.sizePage.Size = new System.Drawing.Size(222, 131);
            this.sizePage.TabIndex = 1;
            this.sizePage.Text = "Size";
            // 
            // messagePage
            // 
            this.messagePage.BackColor = System.Drawing.SystemColors.Control;
            this.messagePage.Controls.Add(this.goodbyeRadioButton);
            this.messagePage.Controls.Add(this.helloRadioButton);
            this.messagePage.Location = new System.Drawing.Point(4, 22);
            this.messagePage.Name = "messagePage";
            this.messagePage.Size = new System.Drawing.Size(222, 131);
            this.messagePage.TabIndex = 2;
            this.messagePage.Text = "Message";
            // 
            // aboutPage
            // 
            this.aboutPage.BackColor = System.Drawing.SystemColors.Control;
            this.aboutPage.Controls.Add(this.aboutLabel);
            this.aboutPage.Location = new System.Drawing.Point(4, 22);
            this.aboutPage.Name = "aboutPage";
            this.aboutPage.Size = new System.Drawing.Size(222, 131);
            this.aboutPage.TabIndex = 3;
            this.aboutPage.Text = "About";
            // 
            // displayLabel
            // 
            this.displayLabel.AutoSize = true;
            this.displayLabel.Location = new System.Drawing.Point(134, 213);
            this.displayLabel.Name = "displayLabel";
            this.displayLabel.Size = new System.Drawing.Size(0, 13);
            this.displayLabel.TabIndex = 1;
            // 
            // blackRadioButton
            // 
            this.blackRadioButton.AutoSize = true;
            this.blackRadioButton.Location = new System.Drawing.Point(3, 3);
            this.blackRadioButton.Name = "blackRadioButton";
            this.blackRadioButton.Size = new System.Drawing.Size(52, 17);
            this.blackRadioButton.TabIndex = 2;
            this.blackRadioButton.TabStop = true;
            this.blackRadioButton.Text = "Black";
            this.blackRadioButton.UseVisualStyleBackColor = true;
            this.blackRadioButton.CheckedChanged += new System.EventHandler(this.blackRadioButton_CheckedChanged);
            // 
            // redRadioButton
            // 
            this.redRadioButton.AutoSize = true;
            this.redRadioButton.Location = new System.Drawing.Point(3, 26);
            this.redRadioButton.Name = "redRadioButton";
            this.redRadioButton.Size = new System.Drawing.Size(45, 17);
            this.redRadioButton.TabIndex = 3;
            this.redRadioButton.TabStop = true;
            this.redRadioButton.Text = "Red";
            this.redRadioButton.UseVisualStyleBackColor = true;
            this.redRadioButton.CheckedChanged += new System.EventHandler(this.redRadioButton_CheckedChanged);
            // 
            // greenRadioButton
            // 
            this.greenRadioButton.AutoSize = true;
            this.greenRadioButton.Location = new System.Drawing.Point(3, 49);
            this.greenRadioButton.Name = "greenRadioButton";
            this.greenRadioButton.Size = new System.Drawing.Size(54, 17);
            this.greenRadioButton.TabIndex = 4;
            this.greenRadioButton.TabStop = true;
            this.greenRadioButton.Text = "Green";
            this.greenRadioButton.UseVisualStyleBackColor = true;
            this.greenRadioButton.CheckedChanged += new System.EventHandler(this.greenRadioButton_CheckedChanged);
            // 
            // size20RadioButton
            // 
            this.size20RadioButton.AutoSize = true;
            this.size20RadioButton.Location = new System.Drawing.Point(3, 49);
            this.size20RadioButton.Name = "size20RadioButton";
            this.size20RadioButton.Size = new System.Drawing.Size(63, 17);
            this.size20RadioButton.TabIndex = 7;
            this.size20RadioButton.TabStop = true;
            this.size20RadioButton.Text = "20 point";
            this.size20RadioButton.UseVisualStyleBackColor = true;
            this.size20RadioButton.CheckedChanged += new System.EventHandler(this.size20RadioButton_CheckedChanged);
            // 
            // size16RadioButton
            // 
            this.size16RadioButton.AutoSize = true;
            this.size16RadioButton.Location = new System.Drawing.Point(3, 26);
            this.size16RadioButton.Name = "size16RadioButton";
            this.size16RadioButton.Size = new System.Drawing.Size(63, 17);
            this.size16RadioButton.TabIndex = 6;
            this.size16RadioButton.TabStop = true;
            this.size16RadioButton.Text = "16 point";
            this.size16RadioButton.UseVisualStyleBackColor = true;
            this.size16RadioButton.CheckedChanged += new System.EventHandler(this.size16RadioButton_CheckedChanged);
            // 
            // size12RadioButton
            // 
            this.size12RadioButton.AutoSize = true;
            this.size12RadioButton.Location = new System.Drawing.Point(3, 3);
            this.size12RadioButton.Name = "size12RadioButton";
            this.size12RadioButton.Size = new System.Drawing.Size(63, 17);
            this.size12RadioButton.TabIndex = 5;
            this.size12RadioButton.TabStop = true;
            this.size12RadioButton.Text = "12 point";
            this.size12RadioButton.UseVisualStyleBackColor = true;
            this.size12RadioButton.CheckedChanged += new System.EventHandler(this.size12RadioButton_CheckedChanged);
            // 
            // goodbyeRadioButton
            // 
            this.goodbyeRadioButton.AutoSize = true;
            this.goodbyeRadioButton.Location = new System.Drawing.Point(3, 26);
            this.goodbyeRadioButton.Name = "goodbyeRadioButton";
            this.goodbyeRadioButton.Size = new System.Drawing.Size(71, 17);
            this.goodbyeRadioButton.TabIndex = 6;
            this.goodbyeRadioButton.TabStop = true;
            this.goodbyeRadioButton.Text = "Goodbye!";
            this.goodbyeRadioButton.UseVisualStyleBackColor = true;
            this.goodbyeRadioButton.CheckedChanged += new System.EventHandler(this.goodbyeRadioButton_CheckedChanged);
            // 
            // helloRadioButton
            // 
            this.helloRadioButton.AutoSize = true;
            this.helloRadioButton.Location = new System.Drawing.Point(3, 3);
            this.helloRadioButton.Name = "helloRadioButton";
            this.helloRadioButton.Size = new System.Drawing.Size(52, 17);
            this.helloRadioButton.TabIndex = 5;
            this.helloRadioButton.TabStop = true;
            this.helloRadioButton.Text = "Hello!";
            this.helloRadioButton.UseVisualStyleBackColor = true;
            this.helloRadioButton.CheckedChanged += new System.EventHandler(this.helloRadioButton_CheckedChanged);
            // 
            // aboutLabel
            // 
            this.aboutLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.aboutLabel.Location = new System.Drawing.Point(3, 9);
            this.aboutLabel.Name = "aboutLabel";
            this.aboutLabel.Size = new System.Drawing.Size(216, 48);
            this.aboutLabel.TabIndex = 2;
            this.aboutLabel.Text = "Tabs are used to organize controls and conserve screen space.";
            // 
            // UsingTabsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 279);
            this.Controls.Add(this.displayLabel);
            this.Controls.Add(this.tabControl);
            this.Name = "UsingTabsForm";
            this.Text = "UsingTabs";
            this.tabControl.ResumeLayout(false);
            this.colorPage.ResumeLayout(false);
            this.colorPage.PerformLayout();
            this.sizePage.ResumeLayout(false);
            this.sizePage.PerformLayout();
            this.messagePage.ResumeLayout(false);
            this.messagePage.PerformLayout();
            this.aboutPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage colorPage;
        private System.Windows.Forms.TabPage sizePage;
        private System.Windows.Forms.TabPage messagePage;
        private System.Windows.Forms.TabPage aboutPage;
        private System.Windows.Forms.Label displayLabel;
        private System.Windows.Forms.RadioButton greenRadioButton;
        private System.Windows.Forms.RadioButton redRadioButton;
        private System.Windows.Forms.RadioButton blackRadioButton;
        private System.Windows.Forms.RadioButton size20RadioButton;
        private System.Windows.Forms.RadioButton size16RadioButton;
        private System.Windows.Forms.RadioButton size12RadioButton;
        private System.Windows.Forms.RadioButton goodbyeRadioButton;
        private System.Windows.Forms.RadioButton helloRadioButton;
        private System.Windows.Forms.Label aboutLabel;
    }
}

