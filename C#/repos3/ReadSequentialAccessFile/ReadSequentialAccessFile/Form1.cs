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
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;


namespace ReadSequentialAccessFile
{
    public partial class ReadSequentialAccessFileForm : BankUIForm
    {
        private BinaryFormatter reader = new BinaryFormatter();
        private FileStream input;
        public ReadSequentialAccessFileForm()
        {
            InitializeComponent();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            DialogResult result;
            string fileName;

            using (OpenFileDialog fileChooser = new OpenFileDialog())
            {
                result = fileChooser.ShowDialog();
                fileName = fileChooser.FileName;
            }

            if (result == DialogResult.OK)
            {
                ClearTextBoxes();

                if (string.IsNullOrEmpty(fileName))
                {
                    MessageBox.Show("Invalid File Name", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    input = new FileStream(
                        fileName, FileMode.Open, FileAccess.Read);

                    openButton.Enabled = false;
                    nextButton.Enabled = true;
                }
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            try
            {
                RecordSerializable record =
                    (RecordSerializable)reader.Deserialize(input);

                var values = new string[] {
                    record.Account.ToString(),
                    record.FirstName.ToString(),
                    record.LastName.ToString(),
                    record.Balance.ToString()
                };

                SetTextBoxValues(values);
            }
            catch (SerializationException)
            {
                input?.Close();
                openButton.Enabled = true;
                nextButton.Enabled = false;

                ClearTextBoxes();

                MessageBox.Show("No more records in file", string.Empty,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
