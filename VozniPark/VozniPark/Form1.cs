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
        public StateEnum state;
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
            pnlSelected1.Visible = true;
            pnlSelected2.Visible = false;
            pnlSelected3.Visible = false;
            pnlSelected4.Visible = false;

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
           

            Button button = sender as Button;
            if (button.Name == "btnPregled") {
                pnlDashboard.Controls.Clear();
                DataGridView dtg = new DataGridView();
                myProperty = new PropertyClassVozila();
                
                //refresujGrid();
               
                pnlDashboard.Controls.Add(dtg);
                PopulateGrid();

                
                dtg.Height = 250;
                dtg.Location = new Point(50, 0);

               dtg.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
               dtg.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dtg.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dtg.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dtg.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dtg.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dtg.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dtg.Width = pnlDashboard.Width - 50;

            }
            else if(button.Name == "btnDodajVozilo")
            {
                pnlDashboard.Controls.Clear();
                myProperty = new PropertyClassVozila();
               
                PopulateControls();


                Button btnDodajVozilo = new Button();
                Button btnOtkazi = new Button();

                btnDodajVozilo.Location = new Point(70, 470);
                btnDodajVozilo.Text = "Dodaj vozilo";

                btnOtkazi.Location = new Point(270, 470);
                btnOtkazi.Text = "Ocisti polja";

                btnDodajVozilo.Click += BtnDodajVozilo_Click;
                btnOtkazi.Click += BtnOtkazi_Click;

                pnlDashboard.Controls.Add(btnDodajVozilo);
                pnlDashboard.Controls.Add(btnOtkazi);

               
                btnOtkazi.Visible = true;

            }
            else if(button.Name == "btnUnesiReg")
            {
                pnlDashboard.Controls.Clear();
            }
                
        }

        private void BtnDodajVozilo_Click(object sender, EventArgs e)
        {
            var properties = myProperty.GetType().GetProperties();

            foreach (var item in pnlDashboard.Controls)
            {
                if (item.GetType() == typeof( LookupControl))
                {
                    LookupControl input = item as  LookupControl;
                    string value = input.Key;

                    PropertyInfo property = properties.Where(x => input.Name == x.Name).FirstOrDefault();
                    property.SetValue(myProperty, Convert.ChangeType(value, property.PropertyType));
                }
                else if (item.GetType() == typeof(InputControl))
                {
                    InputControl input = item as InputControl;
                    string value = input.UnosPolje;

                    PropertyInfo property = properties.Where(x => input.Naziv == x.Name).FirstOrDefault();
                    property.SetValue(myProperty, Convert.ChangeType(value, property.PropertyType));
                }
            }
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnectionString(), CommandType.Text,
                  myProperty.GetInsertQuery(), myProperty.GetInsertParameters().ToArray());

            MessageBox.Show("Uneseno vozilo");

            pnlDashboard.Controls.Clear();
            myProperty = new PropertyClassVozila();

            PopulateControls();


            Button btnDodajVozilo = new Button();
            Button btnOtkazi = new Button();

            btnDodajVozilo.Location = new Point(70, 470);
            btnDodajVozilo.Text = "Dodaj vozilo";

            btnOtkazi.Location = new Point(270, 470);
            btnOtkazi.Text = "Ocisti polja";

            btnDodajVozilo.Click += BtnDodajVozilo_Click;
            btnOtkazi.Click += BtnOtkazi_Click;

            pnlDashboard.Controls.Add(btnDodajVozilo);
            pnlDashboard.Controls.Add(btnOtkazi);


            btnOtkazi.Visible = true;

        }

        private void BtnOtkazi_Click(object sender, EventArgs e)
        {
            pnlDashboard.Controls.Clear();
            myProperty = new PropertyClassVozila();

            PopulateControls();
            Button btnDodajVozilo = new Button();
            Button btnOtkazi = new Button();

            btnDodajVozilo.Location = new Point(70, 470);
            btnDodajVozilo.Text = "Dodaj vozilo";

            btnOtkazi.Location = new Point(270, 470);
            btnOtkazi.Text = "Ocisti polja";

            btnDodajVozilo.Click += BtnDodajVozilo_Click;
            btnOtkazi.Click += BtnOtkazi_Click;

            pnlDashboard.Controls.Add(btnDodajVozilo);
            pnlDashboard.Controls.Add(btnOtkazi);


            btnOtkazi.Visible = true;
        }

        private void btnZaposleni_Click(object sender, EventArgs e)
        {
            flpPodmeni.Controls.Clear();
            pnlSelected1.Visible = false;
            pnlSelected2.Visible = true;
            pnlSelected3.Visible = false;
            pnlSelected4.Visible = false;

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
            if (button.Name == "btnPregled")
            {
                pnlDashboard.Controls.Clear();
                DataGridView dtg = new DataGridView();
                myProperty = new PropertyClassZaposleni();                
                
                

                FlowLayoutPanel flp = new FlowLayoutPanel();
                flp.FlowDirection = FlowDirection.LeftToRight;
                flp.Width = pnlDashboard.Width;
                flp.Location = new Point(10, 170);
                pnlDashboard.Controls.Add(dtg);
                pnlDashboard.Controls.Add(flp);

                for (int i = 0; i < 4; i++)
                {
                    Button btn = new Button();
                    if(i == 0)
                    {
                        btn.Name = "btnDodaj";
                        btn.Text = "Dodaj";
                        btn.Click += Btn_Click;
             

                    }
                    if(i == 1)
                    {
                        btn.Name = "btnIzmjeni";
                        btn.Text = "Izmjeni";
                    }
                    if(i == 2)
                    {
                        btn.Name = "btnObrisi";
                        btn.Text = "Obrisi";
                    }
                    if (i == 3)
                    {
                        btn.Name = "btnDetaljno";
                        btn.Text = "Detaljno";
                    }
                    flp.Controls.Add(btn);

                    
                }
                PopulateGrid();


            }
            else if (button.Name == "btnDodajZaposlenog")
            {
                pnlDashboard.Controls.Clear();
                myProperty = new PropertyClassZaposleni();
                Button btnDodaj = new Button();
                btnDodaj.Text = "Dodaj zaposlenog";
                btnDodaj.Location = new Point(170, 270);
                pnlDashboard.Controls.Add(btnDodaj);
                myProperty = new PropertyClassZaposleni();               
                PopulateControls();
            }           
        }
        
        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Name == "btnDodaj")
            {
                PopulateControls();
                
                
            }
        }

       

       

        public void PopulateControls()
        {
         
            
            foreach (PropertyInfo item in myProperty.GetType().GetProperties())
            {

                if (item.GetCustomAttribute<ForeignKeyAttribute>() != null)
                {
                    PropertyInterface foreignInterface = Assembly.GetExecutingAssembly().
                        CreateInstance(item.GetCustomAttribute<ForeignKeyAttribute>().referencedClass) as PropertyInterface;

                    LookupControl lookup = new LookupControl(foreignInterface);
                    lookup.Name = item.Name;
                    lookup.setLabel(item.GetCustomAttribute<DisplayNameAttribute>().DisplayName);
                    
                    pnlDashboard.Controls.Add(lookup);
                }
                else { 
                    InputControl ic = new InputControl();
                    
                    ic.Naziv = item.Name;

                    
                    if (item.GetCustomAttribute<PrimaryKeyAttribute>() != null && state == StateEnum.Update)
                    {
                        ic.Enabled = false;
                    }

                    if(state == StateEnum.Update)
                    {
                        ic.UnosPolje = item.GetValue(myProperty).ToString();
                    }
                    
                    pnlDashboard.Controls.Add(ic);
                }

                
            }
           
        }

        private void btnZaduzenja_Click(object sender, EventArgs e)
        {
            flpPodmeni.Controls.Clear();
            pnlSelected3.Visible = true;
            pnlSelected1.Visible = false;
            pnlSelected2.Visible = false;
            pnlSelected3.Visible = true;
            pnlSelected4.Visible = false;

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
            
            Button button = sender as Button;
            if (button.Name == "btnPregled")
            {
                pnlDashboard.Controls.Clear();
                DataGridView dtg = new DataGridView();
                myProperty = new PropertyClassZaduzenja();

                //refresujGrid();

                FlowLayoutPanel flpButoni = new FlowLayoutPanel();
                flpButoni.FlowDirection = FlowDirection.LeftToRight;
                flpButoni.Width = pnlDashboard.Width;
               
                pnlDashboard.Controls.Add(dtg);
                pnlDashboard.Controls.Add(flpButoni);

                for (int i = 0; i < 3; i++)
                {
                    Button btnCrud = new Button();
                    if (i == 0)
                    {
                        btnCrud.Text = "DODAJ";
                        btnCrud.Name = "btnDodaj";
                    }
                    if (i == 1)
                    {
                        btnCrud.Text = "IZMIJENI";
                        btnCrud.Name = "btnIzmijeni";
                    }
                    if (i == 2)
                    {
                        btnCrud.Text = "IZBRISI";
                        btnCrud.Name = "btnIzbrisi";                       
                    }
                    flpButoni.Controls.Add(btnCrud);
                    btnCrud.Click += BtnCrud_Click;
                }
              
                PopulateGrid();
            }
            else if (button.Name == "btnZaduzi")
            {
                pnlDashboard.Controls.Clear();
                myProperty = new PropertyClassZaduzenja();
                PopulateControls();
                
                FlowLayoutPanel flpButon = new FlowLayoutPanel();
                flpButon.FlowDirection = FlowDirection.LeftToRight;
                flpButon.Width = pnlDashboard.Width;
                pnlDashboard.Controls.Add(flpButon);

                Button btnZaduzi = new Button();
                btnZaduzi.Text = "Zaduzi";
                btnZaduzi.Name = "btnZaduzi";
                flpButon.Controls.Add(btnZaduzi);
            }
            else if (button.Name == "btnRazduzi")
            {
                pnlDashboard.Controls.Clear();
                DataGridView dtg = new DataGridView();
                myProperty = new PropertyClassZaduzenja();
                pnlDashboard.Controls.Add(dtg);
                PopulateGrid();

                FlowLayoutPanel flpButon = new FlowLayoutPanel();
                flpButon.FlowDirection = FlowDirection.LeftToRight;
                flpButon.Width = pnlDashboard.Width;
                pnlDashboard.Controls.Add(flpButon);

                Button btnRazduzi = new Button();
                btnRazduzi.Text = "RAZDUZI";
                btnRazduzi.Name = "btnRazduzi";
                flpButon.Controls.Add(btnRazduzi);
            }
                      
            else if (button.Name == "btnIstorija") {
                pnlDashboard.Controls.Clear();
            }
        }

        private void BtnCrud_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button.Name == "btnDodaj")
            {
                pnlDashboard.Controls.Clear();
                myProperty = new PropertyClassZaduzenja();
                PopulateControls();

                FlowLayoutPanel flpButon = new FlowLayoutPanel();
                flpButon.FlowDirection = FlowDirection.LeftToRight;
                flpButon.Width = pnlDashboard.Width;
                pnlDashboard.Controls.Add(flpButon);

                Button btnZaduzi = new Button();
                btnZaduzi.Text = "Zaduzi";
                btnZaduzi.Name = "btnZaduzi";
                flpButon.Controls.Add(btnZaduzi);
            }
            else if (button.Name == "btnIzmijeni")
            {
            }
            else if ((button.Name == "btnIzbrisi"))
            {
            }

        }

        private void btnServis_Click(object sender, EventArgs e)
        {
            flpPodmeni.Controls.Clear();
            pnlSelected1.Visible = false;
            pnlSelected2.Visible = false;
            pnlSelected3.Visible = false;
            pnlSelected4.Visible = true;

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
                    btnPodmeniServis.Text = "Unesi podatke o servisu";
                    btnPodmeniServis.Name = "btnServis";
                }
                btnPodmeniServis.Click += BtnPodmeniServis_Click;
                flpPodmeni.Controls.Add(btnPodmeniServis);
            }          
        }

        private void BtnPodmeniServis_Click(object sender, EventArgs e)
        {
            
            Button button = sender as Button;
            if (button.Name == "btnPregled")
            {
                pnlDashboard.Controls.Clear();
                DataGridView dtg = new DataGridView();
                myProperty = new PropertyClassServisiranjeVozila();

                //refresujGrid();

                pnlDashboard.Controls.Add(dtg);
                PopulateGrid();
            }
            else if (button.Name == "btnServis") {
                pnlDashboard.Controls.Clear();
            }
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
        private void Form1_Activated(object sender, EventArgs e)
        {
            btnVozila_Click(sender, e);
            BtnPodmeni_Click(sender, e);
        }

        private void btnOtkazi_Click(object sender, EventArgs e)
        {

        }
    

        private void Form1_Load(object sender, EventArgs e)
        {
            pnlSelected1.Visible = false;
            pnlSelected2.Visible = false;
            pnlSelected3.Visible = false;
            pnlSelected4.Visible = false;
        }
    }
}

