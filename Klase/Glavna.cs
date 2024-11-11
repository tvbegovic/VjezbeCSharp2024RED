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

namespace Klase
{
    public partial class Glavna : Form
    {
        
        public Glavna()
        {
            InitializeComponent();
        }

        private void btnUnesi_Click(object sender, EventArgs e)
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
            MessageBox.Show("Igra unesena");

        }
    }
}
