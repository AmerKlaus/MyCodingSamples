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
    public partial class Cart : Form
    {
        private string connectionString = GlobalVariables.Connection;

        private List<CartItem> cartItems = new List<CartItem>();
        private int userId = GlobalVariables.CurrentId;
        public Cart()
        {
            InitializeComponent();
            LoadCartItems();
        }

        private void LoadCartItems()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT Book.bookName, Book.Price FROM Cart " +
                                   "JOIN Book ON Cart.bookId = Book.bookId " +
                                   "WHERE Cart.userId = @UserId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string bookName = reader["bookName"].ToString();
                                double price = Convert.ToDouble(reader["Price"]);
                                cartItems.Add(new CartItem { BookName = bookName, Price = price });
                            }
                        }
                    }
                }

                DisplayCartItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading cart items: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayCartItems()
        {
            cartListBox.Items.Clear();

            foreach (var item in cartItems)
            {
                cartListBox.Items.Add($"{item.BookName} - ${item.Price}");
            }

            UpdateTotalCostLabel();
        }

        private void UpdateTotalCostLabel()
        {
            double totalCost = cartItems.Sum(item => item.Price);
            totalCostLabel.Text = $"Total Cost: ${totalCost.ToString("0.00")}";
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            Form home = new Home();
            home.Show();

            this.Close();
        }

        private void removeItemButton_Click(object sender, EventArgs e)
        {
            if (cartListBox.SelectedIndex != -1)
            {
                try
                {
                    // Get the selected book's name from the cartListBox
                    string selectedBookName = cartItems[cartListBox.SelectedIndex].BookName;

                    // Remove the item from the cartListBox
                    cartItems.RemoveAt(cartListBox.SelectedIndex);
                    DisplayCartItems();

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Remove the item from the Cart table
                        string removeFromCartQuery = "DELETE FROM Cart WHERE userId = @UserId AND bookId IN (SELECT bookId FROM Book WHERE bookName = @BookName)";

                        using (SqlCommand removeFromCartCommand = new SqlCommand(removeFromCartQuery, connection))
                        {
                            removeFromCartCommand.Parameters.AddWithValue("@UserId", userId);
                            removeFromCartCommand.Parameters.AddWithValue("@BookName", selectedBookName);

                            removeFromCartCommand.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Item removed from the cart.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error removing item from cart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void confirmPurchaseButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameTextBox.Text) &&
                !string.IsNullOrWhiteSpace(addressTextBox.Text) &&
                !string.IsNullOrWhiteSpace(cardTextBox.Text))
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Get cart items for the current user
                        string cartQuery = "SELECT * FROM Cart WHERE UserId = @UserId";

                        using (SqlCommand cartCommand = new SqlCommand(cartQuery, connection))
                        {
                            cartCommand.Parameters.AddWithValue("@UserId", userId);

                            SqlDataAdapter cartAdapter = new SqlDataAdapter(cartCommand);
                            DataTable cartDataTable = new DataTable();
                            cartAdapter.Fill(cartDataTable);

                            // Add each cart item to the LibraryTable
                            foreach (DataRow cartRow in cartDataTable.Rows)
                            {
                                int bookId = (int)cartRow["bookId"];

                                // Check if the book is not already in the library
                                string checkLibraryQuery = "SELECT COUNT(*) FROM Library WHERE userId = @UserId AND bookId = @BookId";

                                using (SqlCommand checkLibraryCommand = new SqlCommand(checkLibraryQuery, connection))
                                {
                                    checkLibraryCommand.Parameters.AddWithValue("@UserId", userId);
                                    checkLibraryCommand.Parameters.AddWithValue("@BookId", bookId);

                                    int count = (int)checkLibraryCommand.ExecuteScalar();

                                    if (count == 0)
                                    {
                                        // Book is not in the library, add it
                                        string addToLibraryQuery = "INSERT INTO Library (userId, bookId) VALUES (@UserId, @BookId)";

                                        using (SqlCommand addToLibraryCommand = new SqlCommand(addToLibraryQuery, connection))
                                        {
                                            addToLibraryCommand.Parameters.AddWithValue("@UserId", userId);
                                            addToLibraryCommand.Parameters.AddWithValue("@BookId", bookId);

                                            addToLibraryCommand.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }

                            cartListBox.Items.Clear();

                            // Clear the cart after adding items to the library
                            string clearCartQuery = "DELETE FROM Cart WHERE userId = @UserId";

                            using (SqlCommand clearCartCommand = new SqlCommand(clearCartQuery, connection))
                            {
                                clearCartCommand.Parameters.AddWithValue("@UserId", userId);
                                clearCartCommand.ExecuteNonQuery();
                            }

                            Library libraryForm = new Library();
                            libraryForm.LoadBooks();
                        }
                    }

                    MessageBox.Show("Purchase confirmed. Items added to the library.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error confirming purchase: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"Must fill out payment form!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class CartItem
    {
        public string BookName { get; set; }
        public double Price { get; set; }
    }
}
