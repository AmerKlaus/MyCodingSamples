namespace Read_E_Books
{
    partial class Library
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
            this.libraryBooksGridView = new System.Windows.Forms.DataGridView();
            this.ebookBookDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.viewBookButton = new System.Windows.Forms.Button();
            this.homeButton = new System.Windows.Forms.Button();
            this.ebookDatabaseDataSet = new Read_E_Books.EbookDatabaseDataSet();
            this.ebookDatabaseDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.libraryLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.libraryBooksGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ebookBookDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ebookDatabaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ebookDatabaseDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // libraryBooksGridView
            // 
            this.libraryBooksGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.libraryBooksGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.libraryBooksGridView.Location = new System.Drawing.Point(110, 54);
            this.libraryBooksGridView.Name = "libraryBooksGridView";
            this.libraryBooksGridView.RowHeadersWidth = 102;
            this.libraryBooksGridView.Size = new System.Drawing.Size(447, 220);
            this.libraryBooksGridView.TabIndex = 8;
            this.libraryBooksGridView.SelectionChanged += new System.EventHandler(this.libraryBooksGridView_SelectionChanged);
            // 
            // viewBookButton
            // 
            this.viewBookButton.Location = new System.Drawing.Point(460, 283);
            this.viewBookButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.viewBookButton.Name = "viewBookButton";
            this.viewBookButton.Size = new System.Drawing.Size(96, 44);
            this.viewBookButton.TabIndex = 9;
            this.viewBookButton.Text = "View";
            this.viewBookButton.UseVisualStyleBackColor = true;
            this.viewBookButton.Click += new System.EventHandler(this.viewBookButton_Click);
            // 
            // homeButton
            // 
            this.homeButton.Location = new System.Drawing.Point(4, 5);
            this.homeButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(79, 32);
            this.homeButton.TabIndex = 10;
            this.homeButton.Text = "Home";
            this.homeButton.UseVisualStyleBackColor = true;
            this.homeButton.Click += new System.EventHandler(this.homeButton_Click);
            // 
            // ebookDatabaseDataSet
            // 
            this.ebookDatabaseDataSet.DataSetName = "EbookDatabaseDataSet";
            this.ebookDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ebookDatabaseDataSetBindingSource
            // 
            this.ebookDatabaseDataSetBindingSource.DataSource = this.ebookDatabaseDataSet;
            this.ebookDatabaseDataSetBindingSource.Position = 0;
            // 
            // libraryLabel
            // 
            this.libraryLabel.AutoSize = true;
            this.libraryLabel.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.libraryLabel.ForeColor = System.Drawing.Color.Green;
            this.libraryLabel.Location = new System.Drawing.Point(269, 5);
            this.libraryLabel.Name = "libraryLabel";
            this.libraryLabel.Size = new System.Drawing.Size(152, 30);
            this.libraryLabel.TabIndex = 11;
            this.libraryLabel.Text = "Your Library";
            // 
            // Library
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 345);
            this.Controls.Add(this.libraryLabel);
            this.Controls.Add(this.homeButton);
            this.Controls.Add(this.viewBookButton);
            this.Controls.Add(this.libraryBooksGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.MaximizeBox = false;
            this.Name = "Library";
            this.Text = "Library";
            ((System.ComponentModel.ISupportInitialize)(this.libraryBooksGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ebookBookDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ebookDatabaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ebookDatabaseDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView libraryBooksGridView;
        private System.Windows.Forms.BindingSource ebookBookDataSetBindingSource;
        //private EbookBookDataSet ebookBookDataSet;
        private System.Windows.Forms.Button viewBookButton;
        private System.Windows.Forms.Button homeButton;
        private System.Windows.Forms.BindingSource ebookDatabaseDataSetBindingSource;
        private EbookDatabaseDataSet ebookDatabaseDataSet;
        private System.Windows.Forms.Label libraryLabel;
    }
}