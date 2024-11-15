using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klase
{
    public partial class Glavna : Form
    {
        List<Igra> igre = new List<Igra>();
        public Glavna()
        {
            InitializeComponent();
        }

        private void btnUnesi_Click(object sender, EventArgs e)
        {
            try
            {
                Igra igra1 = new Igra();
                igra1.Naziv = txtNaziv.Text;
                igra1.Opis = txtOpis.Text;
                igra1.Vrsta = txtVrsta.Text;
                string unos = txtDatum.Text;
                bool ok = DateTime.TryParse(unos, out DateTime datum);
                if (!ok)
                {
                    MessageBox.Show("Datum u pogrešnom formatu");
                    return;
                }
                igra1.DatumIzdavanja = datum;
                unos = txtCijena.Text;
                ok = double.TryParse(unos, out double cijena);
                if (!ok)
                {
                    MessageBox.Show("Cijena u pogrešnom formatu");
                    return;
                }
                igra1.Cijena = cijena;
                igra1.Izdavac = txtIzdavac.Text;
                igre.Add(igra1);
                AzurirajGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Pogreška: {ex.Message}");
            }

        }

        void AzurirajGrid()
        {
            dgvIgre.DataSource = null;
            dgvIgre.DataSource = igre;
        }

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("igre.txt");
            foreach (var igra in igre)
            {
                sw.WriteLine($"{igra.Naziv};{igra.Opis};{igra.Vrsta};{igra.DatumIzdavanja};{igra.Cijena};{igra.Izdavac}");

            }
            sw.Close();
        }

        private void btnUcitaj_Click(object sender, EventArgs e)
        {
            string[] redci = File.ReadAllLines("igre.txt");
            foreach (string red in redci)
            {
                string[] stupci = red.Split(';');
                Igra igra1 = new Igra();
                igra1.Naziv = stupci[0];
                igra1.Opis = stupci[1];
                igra1.Vrsta = stupci[2];
                bool ok = DateTime.TryParse(stupci[3], out DateTime datum);
                if(ok)
                    igra1.DatumIzdavanja = datum;
                ok = double.TryParse(stupci[4], out double cijena);
                if (ok)
                    igra1.Cijena = cijena;
                igra1.Izdavac = stupci[5];
                igre.Add(igra1);
            }
            AzurirajGrid();
        }
    }
}
