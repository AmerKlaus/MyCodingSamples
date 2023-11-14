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

namespace LINQToFileDirectory
{
    public partial class LINQToFileDirectoryForm : Form
    {
        Dictionary<string, int> found = new Dictionary<string, int>();
        public LINQToFileDirectoryForm()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(pathTextBox.Text) && 
                !Directory.Exists(pathTextBox.Text))
            {
                MessageBox.Show("Invalid Directory", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string currentDirectory =
                    (!string.IsNullOrEmpty(pathTextBox.Text)) ?
                    pathTextBox.Text : Directory.GetCurrentDirectory();

                directoryTextBox.Text = currentDirectory;

                pathTextBox.Clear();
                resultsTextBox.Clear();

                SearchDirectory(currentDirectory);

                CleanDirectory(currentDirectory);

                foreach (var current in found.Keys)
                {
                    resultsTextBox.AppendText(
                        $"* Found {found[current]} {current} files." +
                        Environment.NewLine);
                }

                found.Clear();
            }
        }

        private void SearchDirectory(string folder)
        {
            string[] files = Directory.GetFiles(folder);

            string[] directories = Directory.GetDirectories(folder);

            var extensions =
                from file in files
                group file by Path.GetExtension(file);

            foreach (var extension in extensions)
            {
                if (found.ContainsKey(extension.Key))
                {
                    found[extension.Key] += extension.Count();
                }
                else
                {
                    found[extension.Key] = extension.Count();
                }
            }

            foreach (var subdirectory in directories)
            {
                SearchDirectory(subdirectory);
            }
        }

        private void CleanDirectory(string folder)
        {
            string[] files = Directory.GetFiles(folder);

            string[] directories = Directory.GetDirectories(folder);

            var backupFiles =
                from file in files
                where Path.GetExtension(file) == ".bak"
                select file;

            foreach (var backup in backupFiles)
            {
                DialogResult result = MessageBox.Show(
                    $"Found backup file {Path.GetFileName(backup)}. Delete?",
                    "Delete Backup", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    File.Delete(backup);
                    --found[".bak"];

                    if(found[".bak"] == 0)
                    {
                        found.Remove(".bak");
                    }
                }
            }

            foreach (var subdirectory in directories)
            {
                CleanDirectory(subdirectory);
            }
        }
    }
}
