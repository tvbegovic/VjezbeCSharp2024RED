﻿
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

namespace DemoBaza
{
  public partial class Glavna : Form
  {
    public Glavna()
    {
      InitializeComponent();
    }

    private void btnSelectAll_Click(object sender, EventArgs e)
    {
      if(!CheckConnectionString(out string connectionString))
      {
        return;
      }
      //Napisati kod koji će vratiti sve zapise iz tablice Game i prikazati u gridu dgvAll
      using(var connection = new SqlConnection(connectionString))
        {
                //1. verzija - samo tablica Game
                /*List<Game> games = connection.Query<Game>("SELECT * FROM Game").ToList();*/
                //2. verzija - podaci iz drugih tablica
                List<Game> games = connection.Query<Game>(
                    @"SELECT Game.*, Genre.name Genre, 
                    Publisher.name Publisher, Developer.name Developer
                    FROM Game 
                    LEFT OUTER JOIN Genre ON Game.idGenre = Genre.id
                    LEFT OUTER JOIN Company Publisher ON Game.idPublisher = Publisher.id
                    LEFT OUTER JOIN Company Developer ON Game.idDeveloper = Developer.id"
                    ).ToList();
                dgvAll.DataSource = games;
        }
      
      
    }

    private void btnSelectCriteria_Click(object sender, EventArgs e)
    {
      if(!CheckConnectionString(out string connectionString))
      {
        return;
      }
      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        
       
        int? idGenre = null;
        if (int.TryParse(txtGenre.Text, out int tempInt))
        {
          idGenre = tempInt;
        }
        decimal? priceFrom = null;
        if(decimal.TryParse(txtPriceFrom.Text, out decimal tempDecimal))
        {  
          priceFrom = tempDecimal; 
        }
        decimal? priceTo = null;
        if (decimal.TryParse(txtPriceTo.Text, out tempDecimal))
        {
          priceTo = tempDecimal;
        }
        int? idPublisher = null;
        if (int.TryParse(txtPublisher.Text, out tempInt))
        {
          idPublisher = tempInt;
        }
                string text = txtNameContains.Text;
                //napisati SQL sa parametrima i vratiti zapise koji odgovaraju kriterijima
        string sql = @"SELECT * FROM Game
        WHERE (idGenre = @idGenre OR @idGenre IS NULL)
        AND (idPublisher = @idPublisher OR @idPublisher IS NULL)
        AND (price >= @priceFrom OR @priceFrom IS NULL)
        AND (price <= @priceTo OR @priceTo IS NULL)
        AND (title LIKE @text OR @text IS NULL)";
        var parameters = new { idGenre, priceFrom, priceTo, idPublisher, text = $"%{text}%" };
        var games = connection.Query<Game>(sql, parameters);
                dgvSelectCriteria.DataSource = games;
                    //Prikazati sve u gridu dgvSelectCriteria + broj zapisa u labeli
                    Cursor.Current = Cursors.WaitCursor;
        
      }

    }

   

    private void btnSelectOne_Click(object sender, EventArgs e)
    {
      if (!CheckConnectionString(out string connectionString))
        return;
      using (var connection = new SqlConnection(connectionString))
      {
        int? id = null;
        if (int.TryParse(txtIdSelectOne.Text, out int tempInt))
        {
          id = tempInt;
        } else
        {
          MessageBox.Show("Pogrešan format");
          return;
        }
        Cursor.Current = Cursors.WaitCursor;
        var parameters = new { id };
                //Pozvati SQL koji će vratiti jedan zapis sa zadanim id-om
        string sql = "SELECT * FROM Game WHERE id = @id";
        Game game = connection.QueryFirstOrDefault<Game>(sql, parameters);
        if(game == null)
        {
            lblIdValue.Text = "";
            lblTitleValue.Text = "";
            lblPublisherValue.Text = "";
            lblPriceValue.Text = "";
            lblDeveloperValue.Text = "";
            lblReleaseDateValue.Text = "";
            lblGenreValue.Text = "";
            return;
        }
        //Provjeriti ako zapis postoji, ako ne očistiti formu i izaći
        Cursor.Current = Cursors.Default;

        //Otkomentirati kod ispod
        lblIdValue.Text = game.Id.ToString();
        lblTitleValue.Text = game.Title;
        lblGenreValue.Text = game.IdGenre.HasValue ? game.IdGenre.ToString() : "N/A";
        lblPublisherValue.Text = game.IdPublisher.HasValue ? game.IdPublisher.ToString() : "N/A";
        lblDeveloperValue.Text = game.IdDeveloper.HasValue ? game.IdDeveloper.ToString() : "N/A";
        lblPriceValue.Text = game.Price.HasValue ? game.Price.Value.ToString("C") : "N/A";
        lblReleaseDateValue.Text = game.ReleaseDate.HasValue ? game.ReleaseDate.Value.ToString("d") : "N/A";
      }
    }

    

    private void btnInsert_Click(object sender, EventArgs e)
    {
            //Kreirati objekt game i postaviti sve podatke iz forme
            Game game = new Game();
      game.Title = txtTitleInsert.Text;
      game.IdGenre = int.TryParse(txtIdGenreInsert.Text, out int tempInt) ? tempInt : (int?)null;
      game.IdPublisher = int.TryParse(txtPublisherInsert.Text, out tempInt) ? tempInt : (int?)null;
      game.IdDeveloper = int.TryParse(txtDeveloperInsert.Text, out tempInt) ? tempInt : (int?)null;
      game.Price = double.TryParse(txtPriceInsert.Text, out double tempDecimal) ? tempDecimal : (double?)null;
      game.ReleaseDate = DateTime.TryParse(txtReleaseDateInsert.Text, out DateTime tempDateTime) ? tempDateTime : (DateTime?)null;
      if (!CheckConnectionString(out string connectionString))
      {
        return;
      }
      using (var connection = new SqlConnection(connectionString))
      {
        try
        {
          Cursor.Current = Cursors.WaitCursor;
                    //Poslati SQL za unos novog zapisa i dohvatiti novi id.
        string sql = @"INSERT INTO Game(title, idGenre, idPublisher, idDeveloper, price, releaseDate) OUTPUT inserted.id
        VALUES(@title, @idGenre, @idPublisher, @idDeveloper, @price, @releaseDate)";
        game.Id = connection.ExecuteScalar<int>(sql, game);
                    //Ispisati novi id u labelu i poruku Uspješno unesen zapis
        lblIdInsert.Text = game.Id.ToString();
        lblInsertResult.Text = "Zapis uspješno kreiran";

        }
        catch (Exception ex)
        {
          //Ispisati grešku u labelu
        }
        finally
        {
          Cursor.Current = Cursors.Default;
        }
        
        
      }
    }

    private void btnClearFormInsert_Click(object sender, EventArgs e)
    {
      lblInsertResult.Text = string.Empty;
      lblIdInsert.Text = string.Empty;
      txtTitleInsert.Text = string.Empty;
      txtIdGenreInsert.Text = string.Empty;
      txtPublisherInsert.Text = string.Empty;
      txtDeveloperInsert.Text = string.Empty;
      txtPriceInsert.Text = string.Empty;
      txtReleaseDateInsert.Text = string.Empty;
      lblInsertResult.BackColor = Color.Transparent;
    }

    private void btnLoadUpdate_Click(object sender, EventArgs e)
    {
      if (!CheckConnectionString(out string connectionString))
        return;
      if (!int.TryParse(txtIdUpdate.Text, out int id))
      {
        MessageBox.Show("Id mora biti broj.");
        return;
      }
      using (var connection = new SqlConnection(connectionString))
      {
        Cursor.Current = Cursors.WaitCursor;
                //Dohvatiti igru sa zadanim id-om
        string sql = "SELECT * FROM Game WHERE id = @id";
        var parameters = new { id };
        Game game = connection.QueryFirstOrDefault<Game>(sql, parameters);
        Cursor.Current = Cursors.Default;
        //Ako igra ne postoji, ispisati poruku i izaći
        if(game == null)
        {
            MessageBox.Show("Igra sa zadanim id-om ne postoji");
            return;
        }
                //Otkomentirati kod ispod
        txtTitleUpdate.Text = game.Title;
        txtIdGenreUpdate.Text = game.IdGenre.HasValue ? game.IdGenre.ToString() : string.Empty;
        txtIdPublisherUpdate.Text = game.IdPublisher.HasValue ? game.IdPublisher.ToString() : string.Empty;
        txtIdDeveloperUpdate.Text = game.IdDeveloper.HasValue ? game.IdDeveloper.ToString() : string.Empty;
        txtPriceUpdate.Text = game.Price.HasValue ? game.Price.ToString() : string.Empty;
        txtReleaseDateUpdate.Text = game.ReleaseDate.HasValue ? game.ReleaseDate.Value.ToString("d") : string.Empty;
            }

    }

    private bool CheckConnectionString(out string connectionString)
    {
      connectionString = txtConnectionString.Text;
      if (string.IsNullOrEmpty(connectionString))
      {
        MessageBox.Show("Connection string je obavezan.");
        return false;
      }
      return true;
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
      if (!CheckConnectionString(out string connectionString))
        return;
      
      if (!int.TryParse(txtIdUpdate.Text, out int id))
      {
        MessageBox.Show("Id mora biti broj.");
        return;
      }
        //Kreirati objekt game i postaviti sve podatke iz forme
        Game game = new Game();
            //Otkomentirati kod ispod
        game.Id = id;
        game.Title = txtTitleUpdate.Text;
        game.IdGenre = int.TryParse(txtIdGenreUpdate.Text, out int tempInt) ? tempInt : (int?)null;
        game.IdPublisher = int.TryParse(txtIdPublisherUpdate.Text, out tempInt) ? tempInt : (int?)null;
        game.IdDeveloper = int.TryParse(txtIdDeveloperUpdate.Text, out tempInt) ? tempInt : (int?)null;
        game.Price = double.TryParse(txtPriceUpdate.Text, out double tempDecimal) ? tempDecimal : (double?)null;
        game.ReleaseDate = DateTime.TryParse(txtReleaseDateUpdate.Text, out DateTime tempDateTime) ? tempDateTime : (DateTime?)null;
            using (var connection = new SqlConnection(connectionString))
      {
        try
        {
          Cursor.Current = Cursors.WaitCursor;
            //Pozvati SQL UPDATE i provjeriti broj ažuriranih redaka
            string sql = @"UPDATE Game SET title = @title, idGenre = @idGenre, idPublisher = @idPublisher, idDeveloper = @idDeveloper, price = @price,
	           releaseDate = @releaseDate
                WHERE id = @id";
           connection.Execute(sql, game);
          Cursor.Current = Cursors.Default;
        }
        catch (Exception ex)
        {
          lblUpdateResult.Text = ex.Message;
          lblUpdateResult.ForeColor = Color.Red;
        }
      }
    }

    private void btnClearUpdate_Click(object sender, EventArgs e)
    {
      txtIdUpdate.Text = string.Empty;
      txtTitleUpdate.Text = string.Empty;
      txtIdGenreUpdate.Text = string.Empty;
      txtIdPublisherUpdate.Text = string.Empty;
      txtIdDeveloperUpdate.Text = string.Empty;
      txtPriceUpdate.Text = string.Empty;
      txtReleaseDateUpdate.Text = string.Empty;
    }

    private void btnLoadDelete_Click(object sender, EventArgs e)
    {
      if(!CheckConnectionString(out string connectionString))
      {
        return;
      }
            //Učitaj sve zapise iz tablice Game i prikaži u gridu dgvDelete
    string sql = "SELECT * FROM Game";
    using(var connection = new SqlConnection(connectionString))
    {
        var igre = connection.Query<Game>(sql).ToList();
        dgvDelete.DataSource = igre;
    }
      //Koristi BindingList<Game> i Dapper
      
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      var selectedRow = dgvDelete.SelectedRows[0];
      if (selectedRow == null)
      {
        MessageBox.Show("Morate odabrati zapis.");
        return;
      }
      if (!CheckConnectionString(out string connectionString))
      {
        return;
      }
      if(MessageBox.Show("Da li ste sigurni da želite obrisati odabrani zapis?", "Brisanje", MessageBoxButtons.YesNo) != DialogResult.Yes)
      {
        return;
      }
      //Dohvati id odabranog zapisa
      using (var connection = new SqlConnection(connectionString))
      {
        try
        {
          Cursor.Current = Cursors.WaitCursor;
                    //Pozvati SQL DELETE i provjeriti broj obrisanih redaka
        string sql = "DELETE FROM Game WHERE id = @id";
        int id = (selectedRow.DataBoundItem as Game).Id;
        var parameters = new { id };
        connection.Execute(sql, parameters);
                    Cursor.Current = Cursors.Default;
        }
        catch (Exception ex)
        {
          lblDeleteResult.Text = ex.Message;
          lblDeleteResult.ForeColor = Color.Red;
        }
      }
    }
  }
}
