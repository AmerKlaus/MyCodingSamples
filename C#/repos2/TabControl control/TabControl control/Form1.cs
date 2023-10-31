using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabControl_control
{
    public partial class UsingTabsForm : Form
    {
        public UsingTabsForm()
        {
            InitializeComponent();
        }

        private void blackRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            displayLabel.ForeColor = Color.Black;
        }

        private void redRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            displayLabel.ForeColor = Color.Red;
        }

        private void greenRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            displayLabel.ForeColor = Color.Green;
        }

        private void size12RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            displayLabel.Font = new Font(displayLabel.Font.Name, 12);
        }

        private void size16RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            displayLabel.Font = new Font(displayLabel.Font.Name, 16);
        }

        private void size20RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            displayLabel.Font = new Font(displayLabel.Font.Name, 20);
        }

        private void helloRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            displayLabel.Text = "Hello!";
        }

        private void goodbyeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            displayLabel.Text = "Goodbye!";
        }
    }
}
