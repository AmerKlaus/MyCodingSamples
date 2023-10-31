using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiple_Document_Interface__MDI__Windows
{
    public partial class UsingMDIForm : Form
    {
        public UsingMDIForm()
        {
            InitializeComponent();
        }

        private void lavendarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var child = new ChildForm(
                "Lavender Flowers", "lavenderflowers");
            child.MdiParent = this;
            child.Show();
        }

        private void purpleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var child = new ChildForm(
                "Purple Flowers", "purpleflowers");
            child.MdiParent = this;
            child.Show();
        }

        private void yellowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var child = new ChildForm(
                "Yellow Flowers", "yellowflowers");
            child.MdiParent = this;
            child.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void tileVerticalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }
    }
}
