using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Read_E_Books
{
    public partial class BookReader : Form
    {
        public string Content { get; set; }

        public BookReader()
        {
            InitializeComponent();
        }

        public BookReader(string content)
        {
            InitializeComponent();
            Content = content;
            bookContentTextBox.Text = Content;
        }

        private void libraryButton_Click(object sender, EventArgs e)
        {
            Form library = new Library();
            library.Show();

            this.Close();
        }
    }
}
