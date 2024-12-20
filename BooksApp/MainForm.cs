using BooksApp.DomainClasses;
using Dapper;
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

namespace BooksApp
{
  public partial class MainForm : Form
  {
    
    public MainForm()
    {
      InitializeComponent();
    }
    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      LoadAll();
    }
    private void LoadAll()
    {
      try
      {
        using (var connection = new SqlConnection(Properties.Settings.Default.connString))
        {
          //napisati sql upit za dovhvat svih knjiga + žanrova (LEFT JOIN)
          string query = @"SELECT * FROM Book";

          booksGridView.AutoGenerateColumns = false;
          //otkomentirati nakon što se definira upit
          var books = connection.Query<Book>(query).ToList();
          booksGridView.DataSource = books;

          query = @"SELECT * FROM Genre";
          //Pozvati upit za dohvat svih žanrova
          var genres = connection.Query<Genre>(query).ToList();
          genresGridView.DataSource = genres;

          query = @"SELECT * FROM [user]";
          var users = connection.Query<User>(query).ToList();
          usersGridView.DataSource = users;
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show($"Error loading books: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void btnDeleteBook_Click(object sender, EventArgs e)
    {
      if (booksGridView.SelectedRows.Count == 0)
      {
        MessageBox.Show("Please select a book to delete.", "Delete Book", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      var selectedRow = booksGridView.SelectedRows[0];
      var bookId = Convert.ToInt32(selectedRow.Cells["colId"].Value);

      var confirmResult = MessageBox.Show("Are you sure you want to delete this book?",
                                          "Confirm Delete",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);

      if (confirmResult == DialogResult.Yes)
      {
        try
        {
          using (var connection = new SqlConnection(Properties.Settings.Default.connString))
          {
            string query = "DELETE FROM Book WHERE Id = @Id";
            var parameters = new { Id = bookId };
            //Pozvati Dapper naredbu da se izvrši brisanje knjige
            MessageBox.Show("Book deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Reload books after deletion
            LoadAll();
          }
        }
        catch (Exception ex)
        {
          MessageBox.Show($"Error deleting book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
      try
      {
        using (var connection = new SqlConnection(Properties.Settings.Default.connString))
        {
          // Napisati upit za pretragu
          string query = @"SELECT * FROM Book
            WHERE
            (Title LIKE @title OR @title IS NULL) AND
            (Author LIKE @author OR @author IS NULL)";

          // Initialize parameters
          var parameters = new
          {
            Title = string.IsNullOrWhiteSpace(txtSearchTitle.Text) ? null : $"%{txtSearchTitle.Text}%",
            Author = string.IsNullOrWhiteSpace(txtSearchAuthor.Text) ? null : $"%{txtSearchAuthor.Text}%"
          };

            //Izvršiti upit i dohvatiti rezultate u listu filteredBooks
            var filteredBooks = connection.Query<Book>(query, parameters);

          // Update DataGridView
          booksGridView.DataSource = filteredBooks;
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show($"Error searching for books: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
      txtSearchAuthor.Text = string.Empty;
      txtSearchTitle.Text = string.Empty;
      LoadAll();
    }

    private void btnAddBook_Click(object sender, EventArgs e)
    {
      using (var bookForm = new BookForm())
      {
        bookForm.Id = 0; // Set to 0 for Add mode
        var result = bookForm.ShowDialog();

        if (result == DialogResult.OK)
        {
          LoadAll(); // Refresh the books list
        }
      }
    }

    private void btnEditBook_Click(object sender, EventArgs e)
    {
      if (booksGridView.SelectedRows.Count == 0)
      {
        MessageBox.Show("Please select a book to edit.", "Edit Book", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      var selectedRow = booksGridView.SelectedRows[0];
      var bookId = Convert.ToInt32(selectedRow.Cells["colId"].Value); // Assume "Id" is the name of the column

      using (var bookForm = new BookForm())
      {
        bookForm.Id = bookId; // Pass the selected book's Id
        var result = bookForm.ShowDialog();

        if (result == DialogResult.OK)
        {
          LoadAll(); // Refresh the books list
        }
      }
    }
  }
}
