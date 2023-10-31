using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeView_control
{
    public partial class TreeViewDirectoryStructureForm : Form
    {
        string substringDirectory;
        public TreeViewDirectoryStructureForm()
        {
            InitializeComponent();
        }

        public void PopulateTreeView(string directoryValue, TreeNode parentNode)
        {
            string[] directoryArray =
                Directory.GetDirectories(directoryValue);

            try
            {
                if (directoryArray.Length != 0)
                {
                    foreach (string directory in directoryArray)
                    {
                        substringDirectory =
                            Path.GetFileNameWithoutExtension(directory);

                        TreeNode myNode = new TreeNode(substringDirectory);

                        parentNode.Nodes.Add(myNode);

                        PopulateTreeView(directory, myNode);
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                parentNode.Nodes.Add("Access denied");
            }
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            directoryTreeView.Nodes.Clear();

            if (Directory.Exists(inputTextBox.Text))
            {
                directoryTreeView.Nodes.Add(inputTextBox.Text);

                PopulateTreeView(
                    inputTextBox.Text, directoryTreeView.Nodes[0]);
            }
            else
            {
                MessageBox.Show(inputTextBox.Text + " could not be found.",
                    "Directory Not Found", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
