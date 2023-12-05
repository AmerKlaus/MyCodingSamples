using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Read_E_Books
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void libraryButton_Click(object sender, EventArgs e)
        {
            Form library = new Library();
            library.Show();

            this.Close();
        }

        private void shopButton_Click(object sender, EventArgs e)
        {
            Form shop = new Shop();
            shop.Show();

            this.Close();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Form welcome = new welcomeForm();
            welcome.Show();

            this.Close();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            Form settings = new Settings();
            settings.Show();

            this.Close();
        }
    }
}
