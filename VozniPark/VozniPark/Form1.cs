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
    // colors: #05668D , #028090 , #00A896 , #02C39A , #F0F3BD
    public partial class Form1 : MetroFramework.Forms.MetroForm
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

            for (int i = 0; i < 3; i++)
            {
                Button btnPodmeni = new Button();
                btnPodmeni.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(128)))), ((int)(((byte)(144)))));
                btnPodmeni.FlatAppearance.BorderSize = 0;
                btnPodmeni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btnPodmeni.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btnPodmeni.ForeColor = System.Drawing.Color.Linen;
                btnPodmeni.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                btnPodmeni.TabIndex = 0;
                btnPodmeni.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                btnPodmeni.UseVisualStyleBackColor = false;
                btnPodmeni.Click += new System.EventHandler(this.btnVozila_Click);

                btnPodmeni.Width = flpPodmeni.Width;
                btnPodmeni.Height = 55;

                btnPodmeni.FlatStyle = FlatStyle.Flat;
                if (i == 0)
                {
                    btnPodmeni.Text = "Pregled svih vozila";
                    btnPodmeni.Name = "btnPregled";
                }
                if (i == 1)
                {
                    btnPodmeni.Text = "Dodaj novo vozilo";
                    btnPodmeni.Name = "btnDodajVozilo";
                }
                if (i == 2)
                {
                    btnPodmeni.Text = "Unesi podatke o registraciji";
                    btnPodmeni.Name = "btnUnesiReg";
                }

                flpPodmeni.Controls.Add(btnPodmeni);
            }
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

        
    }
}
