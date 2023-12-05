using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Read_E_Books
{
    public partial class Settings : Form
    {
        private string connectionString = GlobalVariables.Connection;
        private string loggedInUsername = GlobalVariables.CurrentUsername;
        public Settings()
        {
            InitializeComponent();
            LoadAccountInformation();
        }

        private void LoadAccountInformation()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM UserTable WHERE Username = @Username";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", loggedInUsername);

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {

                            accountTextBox.Text = $"Account Information:{Environment.NewLine}Username: {reader["Username"]}{Environment.NewLine}Order History:{Environment.NewLine}{GetOrderHistory()}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading account information: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetOrderHistory()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();


                    string query = "SELECT b.bookName FROM Book b " +
                                   "INNER JOIN Library l ON b.bookId = l.bookId " +
                                   "INNER JOIN UserTable u ON l.userId = u.userId " +
                                   "WHERE u.Username = @Username";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", loggedInUsername);

                        StringBuilder orderHistory = new StringBuilder();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                orderHistory.AppendLine(reader["bookName"].ToString());
                            }
                        }

                        return orderHistory.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving order history: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Error Retrieving Order History";
            }
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            Form home = new Home();
            home.Show();

            this.Close();
        }

        private void changeUsernameButton_Click(object sender, EventArgs e)
        {
            string newUsername = changeUsernameTextBox.Text;


            if (string.IsNullOrEmpty(newUsername))
            {
                MessageBox.Show("Username cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE UserTable SET Username = @NewUsername WHERE Username = @OldUsername";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NewUsername", newUsername);
                        command.Parameters.AddWithValue("@OldUsername", loggedInUsername);

                        command.ExecuteNonQuery();

                        MessageBox.Show("Username changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        loggedInUsername = newUsername;
                        LoadAccountInformation();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error changing username: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            string newPassword = changePasswordTextBox.Text;


            if (!IsPasswordValid(newPassword))
            {
                MessageBox.Show("Password must have at least one uppercase letter, one lowercase letter, one number, and be at least 8 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE UserTable SET Password = @NewPassword WHERE Username = @Username";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NewPassword", newPassword);
                        command.Parameters.AddWithValue("@Username", loggedInUsername);

                        command.ExecuteNonQuery();

                        MessageBox.Show("Password changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error changing password: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsPasswordValid(string password)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$";
            return Regex.IsMatch(password, pattern);
        }
    }
}
