using BankLibrary;
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

namespace CreateFile
{
    public partial class CreateFileForm : BankUIForm
    {
        private StreamWriter fileWriter;
        public CreateFileForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            DialogResult result;
            string fileName;

            using (var fileChooser = new SaveFileDialog())
            {
                fileChooser.CheckFileExists = false;
                result = fileChooser.ShowDialog();
                fileName = fileChooser.FileName;
            }

            if (result == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    MessageBox.Show("Invalid File Name", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        var output = new FileStream(fileName,
                            FileMode.OpenOrCreate, FileAccess.Write);

                        fileWriter = new StreamWriter(output);

                        saveButton.Enabled = false;
                        enterButton.Enabled = true;
                    }

                    catch (IOException)
                    {
                        MessageBox.Show("Error opening file", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            string[] values = GetTextBoxValues();

            if (!string.IsNullOrEmpty(values[(int)TextBoxIndices.Account]))
            {
                try
                {
                    int accountNumber =
                        int.Parse(values[(int)TextBoxIndices.Account]);

                    if (accountNumber > 0)
                    {
                        var record = new Record(accountNumber,
                            values[(int)TextBoxIndices.First],
                            values[(int)TextBoxIndices.Last],
                            decimal.Parse(values[(int)TextBoxIndices.Balance]));

                        fileWriter.WriteLine(
                            $"{record.Account},{record.FirstName}," +
                            $"{record.LastName},{record.Balance}");
                    }
                    else
                    {
                        MessageBox.Show("Invalid Account Number", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch(IOException)
                {
                    MessageBox.Show("Error Writing to File", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch(FormatException)
                {
                    MessageBox.Show("Invalid Format", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                ClearTextBoxes();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            try
            {
                fileWriter?.Close();
            }
            catch (IOException)
            {
                MessageBox.Show("Cannot close file", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Application.Exit();
        }
    }
}
