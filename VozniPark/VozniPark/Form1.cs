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
using System.Windows.Forms.VisualStyles;

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


        #region meniVozila
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
                btnPodmeni.FlatStyle = FlatStyle.Flat;
                btnPodmeni.Width = flpPodmeni.Width;
                btnPodmeni.Height = 55;                

                //btnPodmeni.Click += new System.EventHandler(this.btnVozila_Click);


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
            if (button.Name == "btnPregled")
            {
                pnlDashboard.Controls.Clear();
                DataGridView dtg = new DataGridView();
                pnlDashboard.Controls.Add(dtg);
                myProperty = new PropertyClassVozila();

                //refresujGrid();

                dgvDimeznije(dtg);
                pnlDashboard.Controls.Add(dtg);
                Panel panel = new Panel();
                Button Add = new Button();
                Add.Click += Add_Click;

                Button Update = new Button();
                Update.Click += Update_Click;

                Button Delete = new Button();
                Delete.Click += Delete_Click;

                Add.Text = "ADD";
                Delete.Text = "DELETE";
                Update.Text = "UPDATE";

                Add.Location = new Point(10, 10);
                Update.Location = new Point(95, 10);
                Delete.Location = new Point(180, 10);



                panel.Height = 100;
                panel.Width = 470;


                panel.Location = new Point(250, 150);
                panel.Controls.Add(Add);
                panel.Controls.Add(Delete);
                panel.Controls.Add(Update);
                pnlDashboard.Controls.Add(panel);
                PopulateGrid();

                

            }
            else if (button.Name == "btnDodajVozilo")
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
            else if (button.Name == "btnUnesiReg")
            {
                pnlDashboard.Controls.Clear();
            }

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            DataGridView dtg = pnlDashboard.Controls[0] as DataGridView;
            delete(dtg);
            MessageBox.Show("Vozilo je obrisano");

            Button button = sender as Button;
            button.Name = "btnPregled";

            BtnPodmeni_Click(button, e);

        }

        private void Update_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Add_Click(object sender, EventArgs e)
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
        }

        private void BtnDodajVozilo_Click(object sender, EventArgs e)
        {
            var properties = myProperty.GetType().GetProperties();

            foreach (var item in pnlDashboard.Controls)
            {
                if (item.GetType() == typeof(LookupControl))
                {
                    LookupControl input = item as LookupControl;
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

        #endregion


        #region meniZaposleni
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

                dgvDimeznije(dtg);


                FlowLayoutPanel flp = new FlowLayoutPanel();
                flp.FlowDirection = FlowDirection.LeftToRight;
                flp.Width = pnlDashboard.Width;
                flp.Location = new Point(10, 170);
                pnlDashboard.Controls.Add(dtg);
                pnlDashboard.Controls.Add(flp);
                for (int i = 0; i < 4; i++)
                {
                    Button btn = new Button();
                    if (i == 0)
                    {
                        state = StateEnum.Add;
                        btn.Name = "btnDodaj";
                        btn.Text = "Dodaj";
                        


                    }
                    if (i == 1)
                    {
                        state = StateEnum.Update;
                        btn.Name = "btnIzmjeni";
                        btn.Text = "Izmjeni";
                    }
                    if (i == 2)
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

                    btn.Click += Btn_Click;
                }
                PopulateGrid();


            }
            else if (button.Name == "btnDodajZaposlenog")
            {
                state = StateEnum.Add;
                pnlDashboard.Controls.Clear();
                myProperty = new PropertyClassZaposleni();
                PopulateControls();
                Button btnDodaj = new Button();
                btnDodaj.Text = "Dodaj";
                pnlDashboard.Controls.Add(btnDodaj);
                btnDodaj.Click += BtnDodaj_Click;
            }           
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            DataGridView dgv = sender as DataGridView;
            if (btn.Name == "btnDodaj")
            {
                state = StateEnum.Add;
                pnlDashboard.Controls.Clear();
                myProperty = new PropertyClassZaposleni();
                PopulateControls();

                FlowLayoutPanel flp = new FlowLayoutPanel();
                flp.FlowDirection = FlowDirection.LeftToRight;
                pnlDashboard.Controls.Add(flp);

                Button btnDodaj = new Button();
                btnDodaj.Text = "Dodaj";
                btnDodaj.Name = "btnDodaj";
                flp.Controls.Add(btnDodaj);
                btnDodaj.Click += BtnDodaj_Click;
                
            }
           else if(btn.Name == "btnIzmjeni")
            {
                state = StateEnum.Update;
            }
            else if (btn.Name == "btnObrisi")
            {
                btnZaposleni_Click(sender, e);
                BtnPodmeniZaposleni_Click(sender, e);
                DataGridView dtg = pnlDashboard.Controls[0] as DataGridView;
                delete(dtg);
                pnlDashboard.Controls.Clear();
                btnZaposleni_Click(sender, e);
                Button btnPregled = sender as Button;
                btn.Name = "btnPregled";
                BtnPodmeniZaposleni_Click(btnPregled, e);
                MessageBox.Show("Zaposleni je obrisan");

            }
            if(btn.Name == "btnDetaljno")
            {

            }
            
        }

        private void BtnObrisi_Click1(object sender, EventArgs e)
        {
            
        }

        private void BtnDodaj_Click(object sender, EventArgs e)
        {
            AddUpdate();
            pnlDashboard.Controls.Clear();
            MessageBox.Show("Dodan novi zaposleni!");
            btnZaposleni_Click(sender,e);
            Button btn = sender as Button;
            btn.Name = "btnDodajZaposlenog";
            BtnPodmeniZaposleni_Click(btn,e);
        }

        #endregion

        
        #region meniZaduzenja
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
                dgvDimeznije(dtg);

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
                state = StateEnum.Add;
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

                btnZaduzi.Click += BtnZaduzi_Click;


            }
            else if (button.Name == "btnRazduzi")
            {
                state = StateEnum.Update;
                pnlDashboard.Controls.Clear();
                DataGridView dtg = new DataGridView();
                myProperty = new PropertyClassZaduzenja();
                pnlDashboard.Controls.Add(dtg);
                PopulateGrid();
                dgvDimeznije(dtg);

                FlowLayoutPanel flpButon = new FlowLayoutPanel();
                flpButon.FlowDirection = FlowDirection.LeftToRight;
                flpButon.Width = pnlDashboard.Width;
                pnlDashboard.Controls.Add(flpButon);

                Button btnRazduzi = new Button();
                btnRazduzi.Text = "RAZDUZI";
                btnRazduzi.Name = "btnRazduzi";
                flpButon.Controls.Add(btnRazduzi);
            }

            else if (button.Name == "btnIstorija")
            {
                pnlDashboard.Controls.Clear();
            }
        }

        private void BtnZaduzi_Click(object sender, EventArgs e)
        {
            state = StateEnum.Add;
            AddUpdate();
            MessageBox.Show("Dodano je novo zaduzenje!");
            pnlDashboard.Controls.Clear();        
            btnZaduzenja_Click(sender, e);     
            BtnPodmeniZaduzenja_Click(sender, e);
        }

        private void BtnCrud_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button.Name == "btnDodaj")
            {
                state = StateEnum.Add;
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
                state = StateEnum.Update;
                myProperty = new PropertyClassZaduzenja();
                
                ucitajVrijednostiUPolja();
                FlowLayoutPanel flpButon = new FlowLayoutPanel();
                flpButon.FlowDirection = FlowDirection.LeftToRight;
                flpButon.Width = pnlDashboard.Width;
                pnlDashboard.Controls.Add(flpButon);

                Button btnZaduzi = new Button();
                btnZaduzi.Text = "Zaduzi";
                btnZaduzi.Name = "btnZaduzi";
                flpButon.Controls.Add(btnZaduzi);

                

            }
            else if ((button.Name == "btnIzbrisi"))
            {
                DataGridView dtg = pnlDashboard.Controls[0] as DataGridView;
                delete(dtg);
                Button btnPregled = sender as Button;
                btnPregled.Name = "btnPregled";

                //BtnPodmeniZaduzenja_Click(button, e);

                MessageBox.Show("Zaduzenje je izbrisano!");

                btnZaduzenja_Click(sender, e);
                BtnPodmeniZaduzenja_Click(sender, e);

            }


        }

        #endregion


        #region meniServis

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
                dgvDimeznije(dtg);

                pnlDashboard.Controls.Add(dtg);
                PopulateGrid();
            }
            else if (button.Name == "btnServis")
            {
                pnlDashboard.Controls.Clear();
            }
        }

        #endregion


        #region ostaleMetode
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

            
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                grid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
                else if (item.GetCustomAttribute<DateTimeAttribute>() != null)
                {
                    DateTimeControl dateTime = new DateTimeControl();
                    dateTime.Naziv = item.GetCustomAttribute<DisplayNameAttribute>().DisplayName;
                    pnlDashboard.Controls.Add(dateTime);

                    if (state == StateEnum.Add && dateTime.Naziv == "Datum razduzenja")  
                        dateTime.Enabled = false;

                    

                }
                else if (item.GetCustomAttribute<ForeignField>() != null)
                {
                    continue;
                }
                else
                {
                    InputControl ic = new InputControl();

                    ic.Naziv = item.GetCustomAttribute<DisplayNameAttribute>().DisplayName;


                    if (item.GetCustomAttribute<PrimaryKeyAttribute>() != null)
                    {
                        ic.Enabled = false;
                    }
                    
                    if (state == StateEnum.Update)
                    {
                        ic.UnosPolje = item.GetValue(myProperty).ToString();
                    }
                    if (ic.Naziv == "Predjena kilometraza" && state == StateEnum.Add)
                        ic.Enabled = false;
                    ic.UnosPolje = "0";
                    pnlDashboard.Controls.Add(ic);

                   

                }
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
            WindowState = FormWindowState.Normal;
            pnlSelected1.Visible = false;
            pnlSelected2.Visible = false;
            pnlSelected3.Visible = false;
            pnlSelected4.Visible = false;
        }

        public void AddUpdate()
        {
            var properties = myProperty.GetType().GetProperties();

            foreach (var item in pnlDashboard.Controls)
            {
                if (item.GetType() == typeof(LookupControl))
                {
                    LookupControl input = item as LookupControl;
                    string value = input.Key;

                    PropertyInfo property = properties.Where(x => input.Name == x.Name).FirstOrDefault();
                    property.SetValue(myProperty, Convert.ChangeType(value, property.PropertyType));
                }
                else if (item.GetType() == typeof(InputControl))
                {
                    InputControl input = item as InputControl;
                    if (!input.Enabled) continue;
                    string value = input.UnosPolje;

                    PropertyInfo property = properties.Where(x => input.Naziv == x.Name).FirstOrDefault();
                    property.SetValue(myProperty, Convert.ChangeType(value, property.PropertyType));
                }
                else if (item.GetType() == typeof(DateTimeControl))
                {
                    DateTimeControl date = item as DateTimeControl;
                    //if (!date.Enabled) continue;
                    DateTime value = date.Unos;

                    PropertyInfo property = properties.Where(x => date.Naziv == x.Name).FirstOrDefault();
                    property.SetValue(myProperty, Convert.ChangeType(value, property.PropertyType));
                }
            }
            if(state == StateEnum.Add)
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnectionString(), CommandType.Text,
                  myProperty.GetInsertQuery(), myProperty.GetInsertParameters().ToArray());
            else if(state == StateEnum.Update)
                SqlHelper.ExecuteNonQuery(SqlHelper.GetConnectionString(), CommandType.Text,
                 myProperty.GetUpdateQuery(), myProperty.GetUpdateParameters().ToArray());
        }

        public void delete(DataGridView dg)
        {
            DataGridViewRow row = dg.SelectedRows[0];
            var properties = myProperty.GetType().GetProperties();

            foreach (PropertyInfo item in properties)
            {
                string value = row.Cells[item.GetCustomAttribute<SqlNameAttribute>().Name]
                    .Value.ToString();

                item.SetValue(myProperty, Convert.ChangeType(value, item.PropertyType));
            }
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnectionString(), CommandType.Text,
                  myProperty.GetDeleteQuery(), myProperty.GetDeleteParameters().ToArray());
        }

        private void ucitajVrijednostiUPolja()
        {
            DataGridView grid = pnlDashboard.Controls[0] as DataGridView;
            var type = myProperty.GetType();
            var properties = type.GetProperties();
            int i = 0;
            foreach (DataGridViewCell cell in grid.SelectedRows[0].Cells)
            {
                string value = cell.Value.ToString();
                PropertyInfo property = properties.Where(x => grid.Columns[i].HeaderText == x.GetCustomAttribute<DisplayNameAttribute>().DisplayName).FirstOrDefault();
                property.SetValue(myProperty, Convert.ChangeType(value, property.PropertyType));

                i++;
            }

            pnlDashboard.Controls.Clear();
            PopulateControls();
            

            foreach (var item in pnlDashboard.Controls)
            {
                if (item.GetType() == typeof(InputControl))
                {
                    InputControl control = item as InputControl;

                    PropertyInfo property = properties.Where(x => control.Naziv == x.GetCustomAttribute<DisplayNameAttribute>().DisplayName).FirstOrDefault();
                    if (property != null)control.UnosPolje = property.GetValue(myProperty).ToString();
                }
                else if(item.GetType() == typeof(DateTimeControl))
                {
                    DateTimeControl control = item as DateTimeControl;
                    PropertyInfo property = properties.Where(x => control.Naziv == x.GetCustomAttribute<DisplayNameAttribute>().DisplayName).FirstOrDefault();
                    if (property != null) control.Unos = (DateTime)property.GetValue(myProperty);
                }
                else if (item.GetType() == typeof(LookupControl))
                {
                    LookupControl control = item as LookupControl;
                    PropertyInfo property = properties.Where(x => control.getLabel() == x.GetCustomAttribute<DisplayNameAttribute>().DisplayName).FirstOrDefault();
                    if (property != null) control.Key = property.GetValue(myProperty).ToString(); 
                }
            }
        }

        private void dgvDimeznije(DataGridView dtg)
        {
            dtg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtg.Location = new Point(50, 0);
            dtg.Height = 250;
            dtg.Width = pnlDashboard.Width - 50;
            dtg.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dtg.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
           
        }

        #endregion
    }
}

