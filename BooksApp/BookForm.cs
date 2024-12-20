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
    public partial class BookForm: Form
    {
      public int Id { get; set; }
      public BookForm()
      {
          InitializeComponent();
      }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      LoadGenres();
      if (Id == 0)
      {
        // Add mode: Clear all fields
        ClearControls();
        Text = "Add Book";
      }
      else
      {
        // Edit mode: Load the book details
        LoadBook(Id);
        Text = "Edit Book";
      }
    }

    private void LoadGenres()
    {
      try
      {
        using (var connection = new SqlConnection(Properties.Settings.Default.connString))
        {
          string query = @"SELECT * FROM Genre";
        //Napuniti listu genres iz upita
        var genres = connection.Query<Genre>(query);
          cbGenre.DataSource = genres;
          cbGenre.DisplayMember = "Name";
          cbGenre.ValueMember = "Id";
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show($"Error loading genres: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void ClearControls()
      {
        txtTitle.Text = string.Empty;
        txtAuthor.Text = string.Empty;
        cbGenre.SelectedIndex = -1;
        txtPublishedDate.Text = string.Empty;
        txtPrice.Text = string.Empty;
      }

      private void LoadBook(int id)
      {
        try
        {
          using (var connection = new SqlConnection(Properties.Settings.Default.connString))
          {
            string query = @"SELECT *
                          FROM Book
                          WHERE Id = @Id";
            var parameters = new { Id = id };
          //Napuniti varijablu book iz upita
          var book = connection.QueryFirstOrDefault<Book>(query, parameters);

            if (book != null)
            {
              txtTitle.Text = book.Title;
              txtAuthor.Text = book.Author;
              cbGenre.SelectedValue = book.GenreId;
              txtPublishedDate.Text = book.PublishedDate?.ToShortDateString() ?? string.Empty;
              txtPrice.Text = book.Price?.ToString("F2") ?? string.Empty;
            }
            else
            {
              MessageBox.Show("Book not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
              DialogResult = DialogResult.Cancel; // Close the form
            }
          }
        }
        catch (Exception ex)
        {
          MessageBox.Show($"Error loading book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          DialogResult = DialogResult.Cancel; // Close the form
        }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      try
      {
        // Create and populate the Book object
        Book book = new Book
        {
          Id = this.Id,
          Title = string.IsNullOrWhiteSpace(txtTitle.Text) ? null : txtTitle.Text,
          Author = string.IsNullOrWhiteSpace(txtAuthor.Text) ? null : txtAuthor.Text,
          GenreId = cbGenre.SelectedValue == null ? null : (int?)cbGenre.SelectedValue,
          PublishedDate = string.IsNullOrWhiteSpace(txtPublishedDate.Text)
                ? (DateTime?)null
                : DateTime.Parse(txtPublishedDate.Text),
          Price = string.IsNullOrWhiteSpace(txtPrice.Text)
                ? (decimal?)null
                : decimal.Parse(txtPrice.Text)
        };

        using (var connection = new SqlConnection(Properties.Settings.Default.connString))
        {
          if (Id == 0)
          {
            //Ubaciti INSERT upit dobiven SQL skriptom
            string insertQuery = @"INSERT INTO Book(
                Title,Author,GenreId,PublishedDate,Price
                ) OUTPUT inserted.id VALUES(
                @Title,@Author,@GenreId,@PublishedDate,@Price
                )";

            //Otkomentirati donji kod i dovršiti poziv
            book.Id = connection.ExecuteScalar<int>(insertQuery, book);
            MessageBox.Show("Book added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
          else
          {
            // Ubaciti UPDATE upit dobiven SQL skriptom
            string updateQuery = @"UPDATE Book SET               Title=@Title,Author=@Author,GenreId=@GenreId,PublishedDate=@PublishedDate,Price=@Price
                WHERE id = @id";

            //Izvršiti upit
            connection.Execute(updateQuery, book);
            MessageBox.Show("Book updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }

          // Close the form with DialogResult.OK
          this.DialogResult = DialogResult.OK;
          this.Close();
        }
      }
      catch (FormatException fe)
      {
        MessageBox.Show($"Invalid input: {fe.Message}", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
      }
      catch (Exception ex)
      {
        MessageBox.Show($"Error saving book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      Close();
    }
  }
}
