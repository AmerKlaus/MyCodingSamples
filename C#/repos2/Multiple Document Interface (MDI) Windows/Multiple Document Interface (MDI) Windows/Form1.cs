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

        private void lavendar1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var child1 = new ChildForm(
                "Lavender Flowers", "lavenderflowers");
            child1.MdiParent = this;
            child1.Show();
        }

        private void purple2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var child1 = new ChildForm(
                "Purple Flowers", "purpleflowers");
            child1.MdiParent = this;
            child1.Show();

            var child2 = new ChildForm(
                "Purple Flowers", "purpleflowers");
            child2.MdiParent = this;
            child2.Show();
        }

        private void yellow3ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var child1 = new ChildForm(
               "Yellow Flowers", "yellowflowers");
            child1.MdiParent = this;
            child1.Show();

            var child2 = new ChildForm(
               "Yellow Flowers", "yellowflowers");
            child2.MdiParent = this;
            child2.Show();

            var child3 = new ChildForm(
               "Yellow Flowers", "yellowflowers");
            child3.MdiParent = this;
            child3.Show();
        }
    }
}
