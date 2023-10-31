using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualInheritanceTest
{
    public partial class VisualInheritanceTestForm :
        Visual_Inheritance.VisualInheritanceBaseForm
    {
        public VisualInheritanceTestForm()
        {
            InitializeComponent();
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "This program was created by Deitel & Associates.",
                "About This Program", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
