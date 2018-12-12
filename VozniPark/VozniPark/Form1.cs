using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VozniPark
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVozila_Click(object sender, EventArgs e)
        {
            flpPodmeni.Controls.Clear();

            Button btnPregled = new Button();
            btnPregled.Text = "Pregled svih vozila";
            btnPregled.FlatStyle = FlatStyle.Flat;
            btnPregled.Width = flpPodmeni.Width;
            flpPodmeni.Controls.Add(btnPregled);

            Button btnDodaj = new Button();
            btnDodaj.Text = "Dodaj novo vozilo";
            btnDodaj.FlatStyle = FlatStyle.Flat;
            btnDodaj.Width = flpPodmeni.Width;
            flpPodmeni.Controls.Add(btnDodaj);

            Button btnRegistracija = new Button();
            btnRegistracija.Text = "Unesi podatke o registraciji";
            btnRegistracija.FlatStyle = FlatStyle.Flat;
            btnRegistracija.Width = flpPodmeni.Width;
            flpPodmeni.Controls.Add(btnRegistracija);
        }

        private void btnZaposleni_Click(object sender, EventArgs e)
        {
            flpPodmeni.Controls.Clear();

            Button btnPregled = new Button();
            btnPregled.Text = "Pregled svih zaposlenih";
            btnPregled.FlatStyle = FlatStyle.Flat;
            btnPregled.Width = flpPodmeni.Width;
            flpPodmeni.Controls.Add(btnPregled);

            Button btnDodaj = new Button();
            btnDodaj.Text = "Dodaj novog zaposlenog";
            btnDodaj.FlatStyle = FlatStyle.Flat;
            btnDodaj.Width = flpPodmeni.Width;
            flpPodmeni.Controls.Add(btnDodaj);
        }

        private void btnZaduzenja_Click(object sender, EventArgs e)
        {
            flpPodmeni.Controls.Clear();

            Button btnPregled = new Button();
            btnPregled.Text = "Pregled trenutnih zaduzenja";
            btnPregled.FlatStyle = FlatStyle.Flat;
            btnPregled.Width = flpPodmeni.Width;
            flpPodmeni.Controls.Add(btnPregled);

            Button btnZaduzi = new Button();
            btnZaduzi.Text = "Zaduzi vozilo";
            btnZaduzi.FlatStyle = FlatStyle.Flat;
            btnZaduzi.Width = flpPodmeni.Width;
            flpPodmeni.Controls.Add(btnZaduzi);

            Button btnRazduzi = new Button();
            btnRazduzi.Text = "Razduzi vozilo";
            btnRazduzi.FlatStyle = FlatStyle.Flat;
            btnRazduzi.Width = flpPodmeni.Width;
            flpPodmeni.Controls.Add(btnRazduzi);

            Button btnIstorija = new Button();
            btnIstorija.Text = "Istorija zaduzenja";
            btnIstorija.FlatStyle = FlatStyle.Flat;
            btnIstorija.Width = flpPodmeni.Width;
            flpPodmeni.Controls.Add(btnIstorija);
        }

        private void btnServis_Click(object sender, EventArgs e)
        {
            flpPodmeni.Controls.Clear();

            Button btnPregled = new Button();
            btnPregled.Text = "Pregled svih servisa";
            btnPregled.FlatStyle = FlatStyle.Flat;
            btnPregled.Width = flpPodmeni.Width;
            flpPodmeni.Controls.Add(btnPregled);

            Button btnDodaj = new Button();
            btnDodaj.Text = "Unesi podatke o servisu";
            btnDodaj.FlatStyle = FlatStyle.Flat;
            btnDodaj.Width = flpPodmeni.Width;
            flpPodmeni.Controls.Add(btnDodaj);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnVozila_Click(sender, e);
        }
    }
}
