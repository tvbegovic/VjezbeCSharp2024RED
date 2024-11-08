﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListaRijeci
{
    public partial class Glavna : Form
    {
        List<string> rijeci = new List<string>();
        public Glavna()
        {
            InitializeComponent();
        }

        private void btnDodajNaKraj_Click(object sender, EventArgs e)
        {
            string rijec = txtJednaRijec.Text;
            rijeci.Add(rijec);
            AzurirajListbox();
        }

        void AzurirajListbox()
        {
            lstPopis.DataSource = null;
            lstPopis.DataSource = rijeci;
        }

        private void btnDodajVise_Click(object sender, EventArgs e)
        {
            string textVise = txtViseRijeci.Text;
            string[] viseRijeci = textVise.Split(' ');
            rijeci.AddRange(viseRijeci);
            AzurirajListbox();
        }

        private void btnDodajNaPoziciju_Click(object sender, EventArgs e)
        {
            string rijec = txtJednaRijec.Text;
            string unos = txtPozicija.Text;
            bool ok = int.TryParse(unos, out int pozicija);
            if(!ok)
            {
                MessageBox.Show("pogrešan format");
                return;
            }
            if(pozicija < 0 || pozicija > rijeci.Count)
            {
                MessageBox.Show("Pozicija je izvan raspona");
                return;
            }
            rijeci.Insert(pozicija, rijec);
            AzurirajListbox();
        }

        private void btnUkloni_Click(object sender, EventArgs e)
        {
            int index = lstPopis.SelectedIndex;
            if (index >= 0)
            {
                rijeci.RemoveAt(index);
                AzurirajListbox();
            }
        }

        private void btnIsprazni_Click(object sender, EventArgs e)
        {
            rijeci.Clear();
            AzurirajListbox();
        }
    }
}
