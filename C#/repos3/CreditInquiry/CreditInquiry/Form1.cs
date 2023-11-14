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
using BankLibrary;

namespace CreditInquiry
{
    public partial class CreditInquiryForm : Form
    {
        private FileStream input;
        private StreamReader fileReader;
        public CreditInquiryForm()
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
                if (string.IsNullOrEmpty(fileName))
                {
                    MessageBox.Show("Invalid File Name", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    input = new FileStream(fileName,
                        FileMode.Open, FileAccess.Read);

                    fileReader = new StreamReader(input);

                    openButton.Enabled = false;
                    creditButton.Enabled = true;
                    debitButton.Enabled = true;
                    zeroButton.Enabled = true;
                }
            }
        }

        private void getBalances_click(object sender, EventArgs e)
        {
            Button senderButton = (Button)sender;

            string accountType = senderButton.Text;

            try
            {
                input.Seek(0, SeekOrigin.Begin);

                displayTextBox.Text =
                    $"Accounts with {accountType}{Environment.NewLine}";

                while (true)
                {
                    string inputRecord = fileReader.ReadLine();

                    if (inputRecord == null)
                    {
                        return;
                    }

                    string[] inputFields = inputRecord.Split(',');

                    var record =
                        new Record(int.Parse(inputFields[0]), inputFields[1],
                            inputFields[2], decimal.Parse(inputFields[3]));

                    if (ShouldDisplay(record.Balance, accountType))
                    {
                        displayTextBox.AppendText($"{record.Account}\t" +
                            $"{record.FirstName}\t{record.LastName}\t" +
                            $"{record.Balance:C}{Environment.NewLine}");
                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Cannot Read File", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ShouldDisplay(decimal balance, string accountType)
        {
            if (balance > 0M && accountType == "Credit Balances")
            {
                return true;
            }
            else if (balance < 0M && accountType == "Debit Balances")
            {
                return true;
            }
            else if (balance == 0 && accountType == "Zero Balances")
            {
                return true;
            }

            return false;
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            try
            {
                fileReader?.Close();
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
