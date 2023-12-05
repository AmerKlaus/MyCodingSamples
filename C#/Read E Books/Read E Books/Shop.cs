using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Read_E_Books
{
    public partial class Shop : Form
    {
        private string connectionString = GlobalVariables.Connection;
        private int selectedRowIndex = -1;
        public Shop()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            this.bookTableAdapter.SearchName(
                this.ebookDatabaseDataSet.Book, searchTextBox.Text);
        }

        private void showAllButton_Click(object sender, EventArgs e)
        {
            this.bookTableAdapter.Fill(this.ebookDatabaseDataSet.Book);
        }

        private void searchGenreButton_Click(object sender, EventArgs e)
        {
            this.bookTableAdapter.SearchGenre(
                this.ebookDatabaseDataSet.Book, searchTextBox.Text);
        }

        private void addCartButton_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex >= 0 && selectedRowIndex < bookDataGridView.Rows.Count)
            {
                DataGridViewRow selectedRow = bookDataGridView.Rows[selectedRowIndex];

                // Check if the selectedRow is not null
                if (selectedRow != null)
                {
                    // Create a list to store cell values
                    List<object> rowValues = new List<object>();

                    // Loop through the cells in the selected row
                    foreach (DataGridViewCell cell in selectedRow.Cells)
                    {
                        rowValues.Add(cell.Value);
                    }

                    // rowValues contains the values of all cells in the selected row
                    int selectedBookId = (int)rowValues[0];

                    string loggedInUsername = GlobalVariables.CurrentUsername;
                    int userId = GetUserIdByUsername(loggedInUsername);

                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = "INSERT INTO Cart (userId, bookId) VALUES (@UserId, @BookId)";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@UserId", userId);
                                command.Parameters.AddWithValue("@BookId", selectedBookId);

                                command.ExecuteNonQuery();

                                MessageBox.Show("Book added to cart successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error adding book to cart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("The selected row is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a valid book to add to the cart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetUserIdByUsername(string username)
        {
            int userId = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT UserId FROM UserTable WHERE Username = @Username";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);

                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            userId = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting user ID: {ex.Message}");
            }

            return userId;
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            Form home = new Home();
            home.Show();

            this.Close();
        }

        private void cartButton_Click(object sender, EventArgs e)
        {
            Form cart = new Cart();
            cart.Show();

            this.Close();
        }

        private void Shop_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ebookDatabaseDataSet.Book' table. You can move, or remove it, as needed.
            this.bookTableAdapter.Fill(this.ebookDatabaseDataSet.Book);
            bookDataGridView.SelectionChanged += bookDataGridView_SelectionChanged;
        }

        private void bookDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (bookDataGridView.SelectedRows.Count > 0)
            {
                selectedRowIndex = bookDataGridView.SelectedRows[0].Index;
            }
            else
            {
                selectedRowIndex = -1;
            }
        }
    }
}
