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
using VozniPark.AttributesClass;
using System.Reflection;
using VozniPark.PropertiesClass;

namespace VozniPark
{
    // colors: #05668D , #028090 , #00A896 , #02C39A , #F0F3BD
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public PropertyInterface myProperty;
        
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
                //btnPodmeni.Click += new System.EventHandler(this.btnVozila_Click);

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
                btnPodmeni.Click += BtnPodmeni_Click;

                flpPodmeni.Controls.Add(btnPodmeni);
            }
        }

        private void BtnPodmeni_Click(object sender, EventArgs e)
        {
            pnlDashboard.Controls.Clear();
            Button button = sender as Button;
            if (button.Name == "btnPregled") {
                DataGridView dtg = new DataGridView();
                myProperty = new PropertyClassVozila();
                
                //refresujGrid();
               
                pnlDashboard.Controls.Add(dtg);
                PopulateGrid();

            }
            else if(button.Name == "btnDodajVozilo")
            {
                
            }
            else if(button.Name == "btnUnesiReg")
            {

            }
                
        }

        private void btnZaposleni_Click(object sender, EventArgs e)
        {
            flpPodmeni.Controls.Clear();

            for (int i = 0; i < 2; i++)
            {
                Button btnPodmeniZaposleni = new Button();
                btnPodmeniZaposleni.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(128)))), ((int)(((byte)(144)))));
                btnPodmeniZaposleni.FlatAppearance.BorderSize = 0;
                btnPodmeniZaposleni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btnPodmeniZaposleni.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btnPodmeniZaposleni.ForeColor = System.Drawing.Color.Linen;
                btnPodmeniZaposleni.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                btnPodmeniZaposleni.TabIndex = 0;
                btnPodmeniZaposleni.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                btnPodmeniZaposleni.UseVisualStyleBackColor = false;
                //btnPodmeniZaposleni.Click += new System.EventHandler(this.btnVozila_Click);

                btnPodmeniZaposleni.Width = flpPodmeni.Width;
                btnPodmeniZaposleni.Height = 55;

                btnPodmeniZaposleni.FlatStyle = FlatStyle.Flat;
                if (i == 0)
                {
                    btnPodmeniZaposleni.Text = "Pregled svih zaposlenih";
                    btnPodmeniZaposleni.Name = "btnPregled";
                }
                if (i == 1)
                {
                    btnPodmeniZaposleni.Text = "Dodaj novog zaposlenog";
                    btnPodmeniZaposleni.Name = "btnDodajZaposlenog";
                }
                btnPodmeniZaposleni.Click += BtnPodmeniZaposleni_Click;
                flpPodmeni.Controls.Add(btnPodmeniZaposleni);
            }
            
        }

        private void BtnPodmeniZaposleni_Click(object sender, EventArgs e)
        {
           
            Button button = sender as Button;
            if (button.Name == "btnPregled") { }
            else if (button.Name == "btnDodajZaposlenog") { }
        }

        private void btnZaduzenja_Click(object sender, EventArgs e)
        {
            flpPodmeni.Controls.Clear();

            for (int i = 0; i < 4; i++)
            {
                Button btnPodmeniZaduzenja = new Button();
                btnPodmeniZaduzenja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(128)))), ((int)(((byte)(144)))));
                btnPodmeniZaduzenja.FlatAppearance.BorderSize = 0;
                btnPodmeniZaduzenja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btnPodmeniZaduzenja.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btnPodmeniZaduzenja.ForeColor = System.Drawing.Color.Linen;
                btnPodmeniZaduzenja.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                btnPodmeniZaduzenja.TabIndex = 0;
                btnPodmeniZaduzenja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                btnPodmeniZaduzenja.UseVisualStyleBackColor = false;
                //btnPodmeniZaduzenja.Click += new System.EventHandler(this.btnVozila_Click);

                btnPodmeniZaduzenja.Width = flpPodmeni.Width;
                btnPodmeniZaduzenja.Height = 55;

                btnPodmeniZaduzenja.FlatStyle = FlatStyle.Flat;
                if (i == 0)
                {
                    btnPodmeniZaduzenja.Text = "Pregled trenutnih zaduzenja";
                    btnPodmeniZaduzenja.Name = "btnPregled";
                }
                if (i == 1)
                {
                    btnPodmeniZaduzenja.Text = "Zaduzi vozilo";
                    btnPodmeniZaduzenja.Name = "btnZaduzi";
                }
                if (i == 2)
                {
                    btnPodmeniZaduzenja.Text = "Razduzi vozilo";
                    btnPodmeniZaduzenja.Name = "btnRazduzi";
                }
                if (i == 3)
                {
                    btnPodmeniZaduzenja.Text = "Istorija zaduzivanja";
                    btnPodmeniZaduzenja.Name = "btnIstorija";
                }
                btnPodmeniZaduzenja.Click += BtnPodmeniZaduzenja_Click;
                flpPodmeni.Controls.Add(btnPodmeniZaduzenja);
            }
            
        }

        private void BtnPodmeniZaduzenja_Click(object sender, EventArgs e)
        {
            pnlDashboard.Controls.Clear();
            Button button = sender as Button;
            if (button.Name == "btnPregled")
            {
                DataGridView dtg = new DataGridView();
                myProperty = new PropertyClassZaduzenja();

                //refresujGrid();

                pnlDashboard.Controls.Add(dtg);
                PopulateGrid();

            }
            else if (button.Name == "btnZaduzi") { }
            else if (button.Name == "btnRazduzi") { }
            else if (button.Name == "btnIstorija") { }
        }

        private void btnServis_Click(object sender, EventArgs e)
        {
            flpPodmeni.Controls.Clear();

            for (int i = 0; i < 2; i++)
            {
                Button btnPodmeniServis = new Button();
                btnPodmeniServis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(128)))), ((int)(((byte)(144)))));
                btnPodmeniServis.FlatAppearance.BorderSize = 0;
                btnPodmeniServis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btnPodmeniServis.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btnPodmeniServis.ForeColor = System.Drawing.Color.Linen;
                btnPodmeniServis.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                btnPodmeniServis.TabIndex = 0;
                btnPodmeniServis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                btnPodmeniServis.UseVisualStyleBackColor = false;
                //btnPodmeniServis.Click += new System.EventHandler(this.btnVozila_Click);

                btnPodmeniServis.Width = flpPodmeni.Width;
                btnPodmeniServis.Height = 55;

                btnPodmeniServis.FlatStyle = FlatStyle.Flat;
                if (i == 0)
                {
                    btnPodmeniServis.Text = "Pregled svih servisa";
                    btnPodmeniServis.Name = "btnPregled";
                }
                if (i == 1)
                {
                    btnPodmeniServis.Text = "Unsei podatke o servisu";
                    btnPodmeniServis.Name = "btnServis";
                }
                btnPodmeniServis.Click += BtnPodmeniServis_Click;
                flpPodmeni.Controls.Add(btnPodmeniServis);
            }          
        }

        private void BtnPodmeniServis_Click(object sender, EventArgs e)
        {
            pnlDashboard.Controls.Clear();
            Button button = sender as Button;
            if (button.Name == "btnPregled")
            {
                DataGridView dtg = new DataGridView();
                myProperty = new PropertyClassServisiranjeVozila();

                //refresujGrid();

                pnlDashboard.Controls.Add(dtg);
                PopulateGrid();
            }
            else if (button.Name == "btnServis") { }
        }
        private void PopulateGrid()
        {          
                DataTable dt = new DataTable();

                DataGridView grid = pnlDashboard.Controls[0] as DataGridView;
                SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text,
                    myProperty.GetSelectQuery());

                dt.Load(reader);
                reader.Close();

                grid.DataSource = dt;


                var type = myProperty.GetType();
                var properties = type.GetProperties();

                foreach (DataGridViewColumn item in grid.Columns)
                {
                    item.HeaderText = properties.Where(x => x.GetCustomAttributes<SqlNameAttribute>().FirstOrDefault().Name == item.HeaderText
                                          ).FirstOrDefault().GetCustomAttributes<DisplayNameAttribute>().FirstOrDefault().DisplayName;
                }
            
        }

    }
}
