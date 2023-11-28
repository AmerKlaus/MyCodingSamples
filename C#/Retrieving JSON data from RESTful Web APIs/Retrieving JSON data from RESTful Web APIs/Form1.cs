using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using Newtonsoft.Json;
using System.Xml.Linq;
using JSONRestAPIReadConsole;

namespace Retrieving_JSON_data_from_RESTful_Web_APIs
{
    public partial class Form1 : Form
    {

        private Rootobject employeeData;
        private int currentIndex = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void GetEmployeeData()
        {
            try
            {
                var client = new RestClient("http://dummy.restapiexample.com/api/v1/");
                var requestObject = new RestRequest("employees");
                var response = client.Execute(requestObject);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string rawResponse = response.Content;
                    employeeData = JsonConvert.DeserializeObject<Rootobject>(rawResponse);
                }
                else
                {
                    MessageBox.Show($"Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }


        private void DisplayCurrentRecord()
        {
            if (employeeData != null && employeeData.data != null && employeeData.data.Length > 0)
            {
                var currentRecord = employeeData.data[currentIndex];

                idTextBox.Text = currentRecord.id.ToString();
                nameTextBox.Text = currentRecord.employee_name;
                salaryTextBox.Text = currentRecord.employee_salary.ToString();
                ageTextBox.Text = currentRecord.employee_age.ToString();
            }
            else
            {
                MessageBox.Show("No data available.");
            }
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                DisplayCurrentRecord();
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (employeeData != null && currentIndex < employeeData.data.Length - 1)
            {
                currentIndex++;
                DisplayCurrentRecord();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
