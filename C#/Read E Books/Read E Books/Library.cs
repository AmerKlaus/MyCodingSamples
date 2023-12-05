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
    public partial class Library : Form
    {
        private string connectionString = GlobalVariables.Connection;
        private int userId = GlobalVariables.CurrentId;
        private int selectedRowIndex = -1;

        public Library()
        {
            InitializeComponent();
            libraryBooksGridView.SelectionChanged += libraryBooksGridView_SelectionChanged;
            LoadBooks();
        }

        public void LoadBooks()
        {
            try
            {
                // Retrieve books from the user's library using the userId
                int userId = GlobalVariables.CurrentId;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT Book.bookId, bookName, Genre, numberOfPages, Price FROM Library " +
                                   "INNER JOIN Book ON Library.bookId = Book.bookId " +
                                   "WHERE userId = @UserId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        libraryBooksGridView.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading books: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            Form home = new Home();
            home.Show();

            this.Close();
        }

        private void viewBookButton_Click(object sender, EventArgs e)
        {
            if (libraryBooksGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = libraryBooksGridView.SelectedRows[0];

                int currentBookId = Convert.ToInt32(selectedRow.Cells["bookId"].Value.ToString());

                string content = GetBookContent(currentBookId);

                Form bookReader = new BookReader(content);
                bookReader.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a row before clicking View.");
            }
        }

        private string GetBookContent(int bookId)
        {
            string query = "SELECT Content FROM Book WHERE bookId = @BookId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BookId", bookId);

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        return result.ToString();
                    }
                }
            }

            return string.Empty;
        }

        private void libraryBooksGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (libraryBooksGridView.SelectedRows.Count > 0)
            {
                viewBookButton.Enabled = libraryBooksGridView.SelectedRows.Count > 0;
            }
            else
            {
                selectedRowIndex = -1;
            }
        }
    }
}
