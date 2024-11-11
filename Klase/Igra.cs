using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klase
{
    internal class Igra
    {
        private string naziv, opis, vrsta, izdavac;
        private DateTime datumIzdavanja;
        private double cijena;

        public void UpisiNaziv(string naziv)
        {
            if (string.IsNullOrEmpty(naziv))
                throw new ArgumentException("Naziv ne smije biti prazan");
            this.naziv = naziv;
        }
        public string CitajNaziv()
        {
            return this.naziv;
        }

        //public properties
        //get-set par za naziv
        public string Naziv
        {
            get 
            { 
                return this.naziv; 
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Naziv ne smije biti prazan");
                this.naziv = value;
            }
        }

        public string Opis
        {
            get
            {
                return this.opis;
            }
            set
            {
                this.opis = value;
            }
        }
        public string Vrsta
        {
            get
            {
                return this.vrsta;
            }
            set
            {
                this.vrsta = value;
            }
        }
        public DateTime DatumIzdavanja
        {
            get
            {
                return this.datumIzdavanja;
            }
            set
            {
                this.datumIzdavanja = value;
            }
        }

        public double Cijena
        {
            get
            {
                return this.cijena;
            }
            set
            {
                this.cijena = value;
            }
        }
        public string Izdavac
        {
            get
            {
                return this.izdavac;
            }
            set
            {
                this.izdavac = value;
            }
        }

    }
}
