namespace ListView_control
{
    partial class ListViewTestForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListViewTestForm));
            this.locationLabel = new System.Windows.Forms.Label();
            this.displayLabel = new System.Windows.Forms.Label();
            this.browserListView = new System.Windows.Forms.ListView();
            this.fileFolderImageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Location = new System.Drawing.Point(12, 34);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(51, 13);
            this.locationLabel.TabIndex = 0;
            this.locationLabel.Text = "Location:";
            // 
            // displayLabel
            // 
            this.displayLabel.AutoSize = true;
            this.displayLabel.Location = new System.Drawing.Point(69, 34);
            this.displayLabel.Name = "displayLabel";
            this.displayLabel.Size = new System.Drawing.Size(0, 13);
            this.displayLabel.TabIndex = 1;
            // 
            // browserListView
            // 
            this.browserListView.HideSelection = false;
            this.browserListView.Location = new System.Drawing.Point(15, 50);
            this.browserListView.Name = "browserListView";
            this.browserListView.Size = new System.Drawing.Size(602, 174);
            this.browserListView.SmallImageList = this.fileFolderImageList;
            this.browserListView.TabIndex = 2;
            this.browserListView.UseCompatibleStateImageBehavior = false;
            this.browserListView.View = System.Windows.Forms.View.List;
            this.browserListView.Click += new System.EventHandler(this.browserListView_Click);
            // 
            // fileFolderImageList
            // 
            this.fileFolderImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("fileFolderImageList.ImageStream")));
            this.fileFolderImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.fileFolderImageList.Images.SetKeyName(0, "file.bmp");
            this.fileFolderImageList.Images.SetKeyName(1, "folder.bmp");
            // 
            // ListViewTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 236);
            this.Controls.Add(this.browserListView);
            this.Controls.Add(this.displayLabel);
            this.Controls.Add(this.locationLabel);
            this.Name = "ListViewTestForm";
            this.Text = "ListViewTest";
            this.Load += new System.EventHandler(this.ListViewTestForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.Label displayLabel;
        private System.Windows.Forms.ListView browserListView;
        private System.Windows.Forms.ImageList fileFolderImageList;
    }
}

