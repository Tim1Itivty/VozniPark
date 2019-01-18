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
using MetroFramework;
using MetroFramework.Forms;
using MetroFramework.Controls;
using System.Text.RegularExpressions;

namespace VozniPark
{
    // colors: #05668D , #028090 , #00A896 , #02C39A , #F0F3BD
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        bool tacno;
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
                buttonDesign(btnPodmeni);
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
                pnlDashboard.Controls.Add(dtg);
                FlowLayoutPanel panel = new FlowLayoutPanel();
                MetroTile Add = new MetroTile();
                Add.Click += Add_Click;

                MetroTile Update = new MetroTile();
                Update.Click += Update_Click;

                MetroTile Delete = new MetroTile();
                Delete.Click += Delete_Click;

                MetroTile btnDetalji = new MetroTile();
                btnDetalji.Text = "DETALJNO";
                btnDetalji.Width = 110;
                btnDetalji.Height = 40;

                btnDetalji.Click += Detalji_Click;
                crudButtonDesign(btnDetalji);

                Add.Text = "DODAJ";
                Add.Name = "btnDodajVozilo";
                crudButtonDesign(Add);
                Delete.Text = "OBRISI";
                crudButtonDesign(Delete);
                Update.Text = "IZMIJENI";
                crudButtonDesign(Update);

                panel.Height = 100;
                panel.Width = 970;
                panel.Padding = new Padding(50, 0, 0, 0);
                panel.Controls.Add(Add);
                panel.Controls.Add(Update);
                panel.Controls.Add(Delete);
                panel.Controls.Add(btnDetalji);
                pnlDashboard.Controls.Add(panel);

                PopulateGrid();
                dgvDimeznije(dtg);
            }
            else if (button.Name == "btnDodajVozilo")
            {
                state = StateEnum.Add;
                pnlDashboard.Controls.Clear();
                myProperty = new PropertyClassVozila();

                PopulateControls("Dodajte novo vozilo");

                FlowLayoutPanel panel = new FlowLayoutPanel();
                Button btnDodajVozilo = new Button();
                Button btnOtkazi = new Button();

                btnDodajVozilo.Text = "DODAJ VOZILO";

                btnOtkazi.Text = "OTKAZI";

                btnDodajVozilo.Click += BtnDodajVozilo_Click;
                btnOtkazi.Click += BtnOtkazi_Click;
                btnOtkazi.Visible = true;

                panel.Height = 100;
                panel.Width = 470;

                panel.Controls.Add(btnDodajVozilo);
                panel.Controls.Add(btnOtkazi);

                pnlDashboard.Controls.Add(panel);

            }
            else if (button.Name == "btnUnesiReg")
            {
                pnlDashboard.Controls.Clear();
                DataGridView dtg = new DataGridView();
                pnlDashboard.Controls.Add(dtg);
                myProperty = new PropertyClassRegistracija();

                pnlDashboard.Controls.Add(dtg);
                FlowLayoutPanel panel = new FlowLayoutPanel();
                Button Registruj = new Button();
                Registruj.Click += Registruj_Click;
                Registruj.Text = "REGISTRUJ VOZILO";

                panel.Height = 100;
                panel.Width = 470;
                panel.Controls.Add(Registruj);

                pnlDashboard.Controls.Add(panel);
                PopulateGrid();
                dgvDimeznije(dtg);
            }
        }

        private void Registruj_Click(object sender, EventArgs e)
        {
            state = StateEnum.Add;
            myProperty = new PropertyClassRegistracija();
            DataGridView grid = pnlDashboard.Controls[0] as DataGridView;

            ucitajVrijednostiUPolja();

            FlowLayoutPanel panel = new FlowLayoutPanel();
            Button btnDodajRegistraciju = new Button();
            Button btnOtkazi2 = new Button();

            btnDodajRegistraciju.Text = "SACUVAJ";

            btnOtkazi2.Text = "OTKAZI";

            btnDodajRegistraciju.Click += BtnDodajRegistraciju_Click;
            btnOtkazi2.Click += BtnOtkazi2_Click;
            panel.Height = 100;
            panel.Width = 470;

            panel.Controls.Add(btnOtkazi2);
            panel.Controls.Add(btnDodajRegistraciju);

            pnlDashboard.Controls.Add(panel);
        }

        private void BtnOtkazi2_Click(object sender, EventArgs e)
        {
            pnlDashboard.Controls.Clear();
            DataGridView dtg = new DataGridView();
            pnlDashboard.Controls.Add(dtg);
            myProperty = new PropertyClassRegistracija();
            dgvDimeznije(dtg);
            pnlDashboard.Controls.Add(dtg);
            FlowLayoutPanel panel = new FlowLayoutPanel();
            Button Registruj = new Button();
            Registruj.Click += Registruj_Click;

            Registruj.Text = "REGISTRUJ VOZILO";

            panel.Height = 100;
            panel.Width = 470;

            panel.Controls.Add(Registruj);

            pnlDashboard.Controls.Add(panel);
            PopulateGrid();
        }

        private void BtnDodajRegistraciju_Click(object sender, EventArgs e)
        {
            state = StateEnum.Add;
            AddUpdate();

            if (tacno == false) {
                MetroMessageBox.Show(this, "Registracija je sačuvana!", "Obaviještenje", MessageBoxButtons.OK, MessageBoxIcon.Information, 90); }



            pnlDashboard.Controls.Clear();
            DataGridView dtg = new DataGridView();
            pnlDashboard.Controls.Add(dtg);
            myProperty = new PropertyClassRegistracija();
            pnlDashboard.Controls.Add(dtg);
            FlowLayoutPanel panel = new FlowLayoutPanel();
            Button Registruj = new Button();
            Registruj.Click += Registruj_Click;
            Registruj.Text = "REGISTRUJ VOZILO";

            panel.Height = 100;
            panel.Width = 470;

            panel.Controls.Add(Registruj);

            pnlDashboard.Controls.Add(panel);
            PopulateGrid();
            dgvDimeznije(dtg);
        }


        private void Detalji_Click(object sender, EventArgs e)
        {
            MetroForm DetaljanPregledVozilaForm = new MetroForm();
            DetaljanPregledVozilaForm.Show();
            detaljnoFormaLoad(DetaljanPregledVozilaForm, 860, 420);
            DetaljanPregledVozilaForm.Size = new Size(860, 420);
            DetaljanPregledVozilaForm.Text = "Informacije o vozilu";
            DetaljanPregledVozilaForm.Resizable = false;
            DetaljanPregledVozilaForm.Movable = false;
            DetaljanPregledVozilaForm.MaximizeBox = false;
            DetaljanPregledVozilaForm.MinimizeBox = false;
            DetaljanPregledVozilaForm.FormClosed += DetaljanPregledZaposlenog_FormClosed;
            DataGridView a = pnlDashboard.Controls[0] as DataGridView;
            SqlConnection sqlConnection = new SqlConnection(SqlHelper.GetConnectionString());

            //Pristup podacima Lijevi panel
            FlowLayoutPanel pnlLijevi = new FlowLayoutPanel();
            pnlLijevi.Dock = DockStyle.Left;
            pnlLijevi.Padding = new Padding(5);
            pnlLijevi.Font = new Font("Segoe UI", 12);
            pnlLijevi.ForeColor = Color.White;
            DetaljanPregledVozilaForm.Controls.Add(pnlLijevi);
            pnlLijevi.FlowDirection = FlowDirection.TopDown;
            pnlLijevi.BackColor = Color.FromArgb(5, 56, 107);
            pnlLijevi.FlowDirection = FlowDirection.TopDown;
            pnlLijevi.BorderStyle = System.Windows.Forms.BorderStyle.None;

            string QueryDetaljiVozila = "Exec dbo.spDetaljaPregledVozila  @VoziloID";
            SqlCommand cmdDetaljiVozila = new SqlCommand(QueryDetaljiVozila, sqlConnection);

            cmdDetaljiVozila.Parameters.Add(new SqlParameter("@VoziloID", SqlDbType.Int));
            cmdDetaljiVozila.Parameters["@VoziloID"].Value = Convert.ToInt32(a.SelectedRows[0].Cells[0].Value.ToString());

            DataTable detaljiDT = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(cmdDetaljiVozila);
            da.Fill(detaljiDT);

            // Kontrole za ispis podataka

            Label lblVozilo = new Label();
            Label lblGodina = new Label();
            Label lblVrata = new Label();
            Label lblBoja = new Label();
            Label lblKilometraza = new Label();
            Label lblDostupnost = new Label();

            
            lblVozilo.Text = "Vozilo \n";
            lblVozilo.Text += detaljiDT.Rows[0].ItemArray[1].ToString();
            lblVozilo.Text += " " + detaljiDT.Rows[0].ItemArray[2].ToString() + "\n \n";

            lblGodina.Text = "Godina proizvodnje \n";
            lblGodina.Text += detaljiDT.Rows[0].ItemArray[3].ToString() + ". \n \n";

            lblVrata.Text = "Broj vrata \n";
            lblVrata.Text += detaljiDT.Rows[0].ItemArray[4].ToString() + " \n \n";

            lblBoja.Text = "Boja \n";
            lblBoja.Text += detaljiDT.Rows[0].ItemArray[5].ToString() + " \n \n";

            lblKilometraza.Text = "Kilometraza \n";
            lblKilometraza.Text += detaljiDT.Rows[0].ItemArray[6].ToString() + " \n \n";

            if (detaljiDT.Rows[0].ItemArray[7].ToString() == "False")
            {
                lblDostupnost.Text = "Zauzeto \n ";
                lblDostupnost.ForeColor = Color.IndianRed;
            }
            else
            {
                lblDostupnost.Text = "Slobodno";
                lblDostupnost.ForeColor = Color.LimeGreen;
            }

            pnlLijevi.Controls.Add(lblVozilo);
            pnlLijevi.Controls.Add(lblGodina);
            pnlLijevi.Controls.Add(lblVrata);
            pnlLijevi.Controls.Add(lblBoja);
            pnlLijevi.Controls.Add(lblKilometraza);
            pnlLijevi.Controls.Add(lblDostupnost);

            foreach (var item in pnlLijevi.Controls)
            {
                if (item.GetType() == typeof(Label))
                {
                    Label j = item as Label;
                    j.AutoSize = true;
                    j.Font = new Font(j.Font.FontFamily, 11);

                }

            }

            FlowLayoutPanel pnlDesni = new FlowLayoutPanel();
            pnlDesni.Dock = DockStyle.Right;
            pnlDesni.Size = new Size (640, DetaljanPregledVozilaForm.Height);
            pnlDesni.Padding = new Padding(20, 10, 10, 20);
            pnlDesni.BorderStyle = System.Windows.Forms.BorderStyle.None;
            DetaljanPregledVozilaForm.Controls.Add(pnlDesni);

            // DGV SERVISI SELEKTOVANOG VOZILA
            string QueryServisiVozila = "Exec [dbo].[DetaljanPrikazServisa]  @VoziloID";
            SqlCommand cmdServisVozila = new SqlCommand(QueryServisiVozila, sqlConnection);
            cmdServisVozila.Parameters.Add(new SqlParameter("@VoziloID", SqlDbType.Int));
            cmdServisVozila.Parameters["@VoziloID"].Value = Convert.ToInt32(a.SelectedRows[0].Cells[0].Value.ToString());
            DataTable detaljiServisDT = new DataTable();
            da = new SqlDataAdapter(cmdServisVozila);
            da.Fill(detaljiServisDT);
            DataGridView dgvServisi = new DataGridView();
            dgvServisi.DataSource = detaljiServisDT;

            DetaljnoDgvDimenzije(dgvServisi);
            
            // DGV REGISTRACIJE SELEKTOVANOG VOZILA
            string QueryRegistracijeVozila = "Exec [dbo].[SveRegistracijeZaVozilo]  @VoziloID";
            SqlCommand cmdRegistracijeVozila = new SqlCommand(QueryRegistracijeVozila, sqlConnection);
            cmdRegistracijeVozila.Parameters.Add(new SqlParameter("@VoziloID", SqlDbType.Int));
            cmdRegistracijeVozila.Parameters["@VoziloID"].Value = Convert.ToInt32(a.SelectedRows[0].Cells[0].Value.ToString());
            DataTable detaljiRegistracijaDT = new DataTable();
            da = new SqlDataAdapter(cmdRegistracijeVozila);
            da.Fill(detaljiRegistracijaDT);
            DataGridView dgvRegistracije = new DataGridView();
            dgvRegistracije.DataSource = detaljiRegistracijaDT;

            DetaljnoDgvDimenzije(dgvRegistracije);
            
            // DGV ZADUZENJA SELEKTOVANOG VOZILA
            string QueryZaduzenjaVozila = "Exec [dbo].[VoziloDetaljanPregledZaduzenja]  @VoziloID";
            SqlCommand cmdZaduzenjaVozila = new SqlCommand(QueryZaduzenjaVozila, sqlConnection);
            cmdZaduzenjaVozila.Parameters.Add(new SqlParameter("@VoziloID", SqlDbType.Int));
            cmdZaduzenjaVozila.Parameters["@VoziloID"].Value = Convert.ToInt32(a.SelectedRows[0].Cells[0].Value.ToString());
            DataTable detaljiZaduzenjaDT = new DataTable();
            da = new SqlDataAdapter(cmdZaduzenjaVozila);
            da.Fill(detaljiZaduzenjaDT);
            DataGridView dgvZaduzenja = new DataGridView();
            dgvZaduzenja.DataSource = detaljiZaduzenjaDT;

            DetaljnoDgvDimenzije(dgvZaduzenja);

            // TAB CONTROL ZA PREGLED SVIH GRIDOVA

            MetroTabControl mtc = new MetroTabControl();
            mtc.TabPages.Add("Servisi");
            mtc.TabPages.Add("Registracije");
            mtc.TabPages.Add("Zaduzenja");
            mtc.Size = new Size(560, 320);
            pnlDesni.Controls.Add(mtc);

            mtc.TabPages[0].Controls.Add(dgvServisi);
            mtc.TabPages[1].Controls.Add(dgvRegistracije);
            mtc.TabPages[2].Controls.Add(dgvZaduzenja);

            
            
            

        }

        private void DetaljnoDgvDimenzije(DataGridView dtg)
        {
            dtg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtg.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dtg.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtg.BackgroundColor = Color.White;
            dtg.RowHeadersVisible = false;
            dtg.Width = 560;

            dtg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dtg.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dtg.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dtg.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dtg.DefaultCellStyle.SelectionBackColor = Color.FromArgb(126, 180, 247);
            dtg.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dtg.BackgroundColor = Color.White;
            dtg.EnableHeadersVisualStyles = false;
            dtg.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dtg.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dtg.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dtg.ColumnHeadersDefaultCellStyle.Padding = new Padding(5, 0, 0, 0);
            dtg.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", (float)10.25);
            dtg.AllowUserToAddRows = false;
            dtg.AllowUserToResizeColumns = false;
            dtg.AllowUserToResizeRows = false;
            dtg.ReadOnly = true;
            dtg.ColumnHeadersHeight = 45;
            dtg.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtg.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", (float)8.75);
            dtg.DefaultCellStyle.Padding = new Padding(3, 0, 0, 0);
            dtg.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            if (dtg.Rows.Count > 0) dtg.Rows[0].Selected = true;

           
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            DataGridView dtg = pnlDashboard.Controls[0] as DataGridView;
            string provjera = delete(dtg);
            if (provjera != "Greska")
                MessageBox.Show("Vozilo je obrisano!");
            Button button = sender as Button;
            button.Name = "btnPregled";

            BtnPodmeni_Click(button, e);
        }


        private void Update_Click(object sender, EventArgs e)
        {
            state = StateEnum.Update;
            myProperty = new PropertyClassVozila();
            DataGridView grid = pnlDashboard.Controls[0] as DataGridView;
            ucitajVrijednostiUPolja();
            FlowLayoutPanel panel = new FlowLayoutPanel();
            Button btnDodajVozilo = new Button();
            Button btnOtkazi = new Button();

            btnDodajVozilo.Text = "SACUVAJ";
            btnOtkazi.Text = "OTKAZI";

            btnDodajVozilo.Click += BtnDodajVozilo_Click;
            btnOtkazi.Click += BtnOtkazi_Click;
            panel.Height = 100;
            panel.Width = 470;

            panel.Controls.Add(btnDodajVozilo);
            panel.Controls.Add(btnOtkazi);

            pnlDashboard.Controls.Add(panel);
        }

        private void Add_Click(object sender, EventArgs e)
        {
            state = StateEnum.Add;
            pnlDashboard.Controls.Clear();
            myProperty = new PropertyClassVozila();
            PopulateControls("Dodajte novo vozilo");
            btnVozila_Click(sender, e);
            Button btn = sender as Button;
            btn.Name = "btnDodajVozilo";
            BtnPodmeni_Click(btn, e);
        }

        private void BtnDodajVozilo_Click(object sender, EventArgs e)
        {
            AddUpdate();

            if (state == StateEnum.Add)
            {
                if (tacno == false)
                {
                    MessageBox.Show("Vozilo je sacuvano!");
                }

                pnlDashboard.Controls.Clear();
                myProperty = new PropertyClassVozila();

                    PopulateControls("Dodajte novo vozilo");

                FlowLayoutPanel panel = new FlowLayoutPanel();
                Button btnDodajVozilo = new Button();
                Button btnOtkazi = new Button();
                btnDodajVozilo.Text = "DODAJ VOZILO";
                btnOtkazi.Text = "OTKAZI";

                btnDodajVozilo.Click += BtnDodajVozilo_Click;
                btnOtkazi.Click += BtnOtkazi_Click;
                btnOtkazi.Visible = true;

                panel.Height = 100;
                panel.Width = 470;

                panel.Controls.Add(btnDodajVozilo);
                panel.Controls.Add(btnOtkazi);
                pnlDashboard.Controls.Add(panel);
            }
            else if (state == StateEnum.Update)
            {

                if (tacno == false)
                {
                    MessageBox.Show("Vozilo je izmijenjeno!");
                }
                Button button = sender as Button;
                button.Name = "btnPregled";
                BtnPodmeni_Click(button, e);
            }
        }

        private void BtnOtkazi_Click(object sender, EventArgs e)
        {
            if (state == StateEnum.Add)
            {
                pnlDashboard.Controls.Clear();
                DataGridView dtg = new DataGridView();
                pnlDashboard.Controls.Add(dtg);
                myProperty = new PropertyClassVozila();
                pnlDashboard.Controls.Add(dtg);
                FlowLayoutPanel panel = new FlowLayoutPanel();
                MetroTile Add = new MetroTile();
                Add.Click += Add_Click;

                MetroTile Update = new MetroTile();
                Update.Click += Update_Click;

                MetroTile Delete = new MetroTile();
                Delete.Click += Delete_Click;

                MetroTile btnDetalji = new MetroTile();
                btnDetalji.Text = "DETALJNO";
                btnDetalji.Width = 110;
                btnDetalji.Height = 40;

                btnDetalji.Click += Detalji_Click;
                crudButtonDesign(btnDetalji);

                Add.Text = "DODAJ";
                Add.Name = "btnDodajVozilo";
                crudButtonDesign(Add);
                Delete.Text = "OBRISI";
                crudButtonDesign(Delete);
                Update.Text = "IZMIJENI";
                crudButtonDesign(Update);

                panel.Height = 100;
                panel.Width = 970;
                panel.Padding = new Padding(50, 0, 0, 0);
                panel.Controls.Add(Add);
                panel.Controls.Add(Update);
                panel.Controls.Add(Delete);
                panel.Controls.Add(btnDetalji);
                pnlDashboard.Controls.Add(panel);

                PopulateGrid();
                dgvDimeznije(dtg);
            }
            else if (state == StateEnum.Update)
            {
                pnlDashboard.Controls.Clear();
                DataGridView dtg = new DataGridView();
                pnlDashboard.Controls.Add(dtg);
                myProperty = new PropertyClassVozila();
                pnlDashboard.Controls.Add(dtg);
                FlowLayoutPanel panel = new FlowLayoutPanel();
                MetroTile Add = new MetroTile();
                Add.Click += Add_Click;

                MetroTile Update = new MetroTile();
                Update.Click += Update_Click;

                MetroTile Delete = new MetroTile();
                Delete.Click += Delete_Click;

                MetroTile btnDetalji = new MetroTile();
                btnDetalji.Text = "DETALJNO";
                btnDetalji.Width = 110;
                btnDetalji.Height = 40;

                btnDetalji.Click += Detalji_Click;
                crudButtonDesign(btnDetalji);

                Add.Text = "DODAJ";
                Add.Name = "btnDodajVozilo";
                crudButtonDesign(Add);
                Delete.Text = "OBRISI";
                crudButtonDesign(Delete);
                Update.Text = "IZMIJENI";
                crudButtonDesign(Update);

                panel.Height = 100;
                panel.Width = 970;
                panel.Padding = new Padding(50, 0, 0, 0);
                panel.Controls.Add(Add);
                panel.Controls.Add(Update);
                panel.Controls.Add(Delete);
                panel.Controls.Add(btnDetalji);
                pnlDashboard.Controls.Add(panel);

                PopulateGrid();
                dgvDimeznije(dtg);
            }
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
                buttonDesign(btnPodmeniZaposleni);

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
                flp.Padding = new Padding(50, 0, 0, 0);
                flp.Width = pnlDashboard.Width;
                pnlDashboard.Controls.Add(dtg);
                pnlDashboard.Controls.Add(flp);
                for (int i = 0; i < 4; i++)
                {
                    MetroTile btn = new MetroTile();
                    if (i == 0)
                    {
                        btn.Name = "btnDodajZaposlenog";
                        btn.Text = "DODAJ";
                        crudButtonDesign(btn);
                    }
                    if (i == 1)
                    {
                        btn.Name = "btnIzmjeni";
                        btn.Text = "IZMIJENI";
                        crudButtonDesign(btn);
                    }
                    if (i == 2)
                    {
                        btn.Name = "btnObrisi";
                        btn.Text = "OBRISI";
                        crudButtonDesign(btn);
                    }
                    if (i == 3)
                    {
                        btn.Name = "btnDetaljno";
                        btn.Text = "DETALJNO";
                        crudButtonDesign(btn);
                    }
                    flp.Controls.Add(btn);

                    btn.Click += Btn_Click;
                }
                PopulateGrid();
                dgvDimeznije(dtg);

            }
            else if (button.Name == "btnDodajZaposlenog")
            {
                state = StateEnum.Add;
                pnlDashboard.Controls.Clear();
                myProperty = new PropertyClassZaposleni();
                PopulateControls("Dodajte novog zaposlenog");
                Button btnDodaj = new Button();
                btnDodaj.Text = "DODAJ";
                Button btnOtkazi = new Button();
                btnOtkazi.Name = "btnOtkazi";
                btnOtkazi.Text = "OTKAZI";
                FlowLayoutPanel flp = new FlowLayoutPanel();
                flp.FlowDirection = FlowDirection.LeftToRight;
                flp.Controls.Add(btnDodaj);
                flp.Controls.Add(btnOtkazi);
                pnlDashboard.Controls.Add(flp);
                btnDodaj.Click += BtnDodaj_Click;
                btnOtkazi.Click += BtnOtkazi_Click1;
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            MetroTile btn = sender as MetroTile;
            DataGridView dgv = sender as DataGridView;
            if (btn.Name == "btnDodajZaposlenog")
            {
                state = StateEnum.Add;
                pnlDashboard.Controls.Clear();
                myProperty = new PropertyClassZaposleni();
                PopulateControls("Dodajte novog zaposlenog");

                FlowLayoutPanel flp = new FlowLayoutPanel();
                flp.FlowDirection = FlowDirection.LeftToRight;
                pnlDashboard.Controls.Add(flp);

                Button btnDodaj = new Button();
                Button btnOtkazi = new Button();
                btnDodaj.Text = "DODAJ";
                btnDodaj.Name = "btnDodaj";
                btnOtkazi.Name = "btnOtkazi";
                btnOtkazi.Text = "OTKAZI";

                flp.Controls.Add(btnDodaj);
                flp.Controls.Add(btnOtkazi);
                btnDodaj.Click += BtnDodaj_Click;
                btnOtkazi.Click += BtnOtkazi_Click1;

            }
            else if (btn.Name == "btnIzmjeni")
            {
                state = StateEnum.Update;
                myProperty = new PropertyClassZaposleni();
                ucitajVrijednostiUPolja();
                FlowLayoutPanel flpButton = new FlowLayoutPanel();
                flpButton.FlowDirection = FlowDirection.LeftToRight;
                flpButton.Width = pnlDashboard.Width;
                pnlDashboard.Controls.Add(flpButton);
                Button btnIzmjeni = new Button();
                Button btnOtkazi = new Button();
                btnIzmjeni.Text = "IZMIJENI";
                btnIzmjeni.Name = "btnIzmjeni";
                btnOtkazi.Name = "btnOtkazi";
                btnOtkazi.Text = "OTKAZI";
                flpButton.Controls.Add(btnIzmjeni);
                flpButton.Controls.Add(btnOtkazi);
                btnIzmjeni.Click += BtnIzmjeni_Click;
                btnOtkazi.Click += BtnOtkazi_Click1;
            }
            else if (btn.Name == "btnObrisi")
            {
                DataGridView dtg = pnlDashboard.Controls[0] as DataGridView;
                delete(dtg);
                MessageBox.Show("Zaposleni je obrisan!");
                pnlDashboard.Controls.Clear();
                btnZaposleni_Click(sender, e);
                Button btnPregled = sender as Button;
                btn.Name = "btnPregled";
                BtnPodmeniZaposleni_Click(btnPregled, e);
            }
            else if (btn.Name == "btnDetaljno")
            {
                Button btnDetaljno = new Button();
                btnDetaljno.Name = "btnDetaljno";
                BtnDetaljno_Click();
            }

        }

        private void BtnOtkazi_Click1(object sender, EventArgs e)
        {
            btnZaposleni_Click(sender, e);
            Button podmeniZaposleni = sender as Button;
            podmeniZaposleni.Name = "btnPregled";
            BtnPodmeniZaposleni_Click(podmeniZaposleni, e);
        }

        private void BtnDetaljno_Click()
        {
            MetroForm DetaljanPregledZaposlenog = new MetroForm();
            DetaljanPregledZaposlenog.Text = "Informacije o zaduzivanju zaposlenog";
            DetaljanPregledZaposlenog.StartPosition = FormStartPosition.Manual;
            DetaljanPregledZaposlenog.Location = new Point(this.Location.X + 175, this.Location.Y + 150);
            DetaljanPregledZaposlenog.Resizable = false;
            DetaljanPregledZaposlenog.Movable = false;
            DetaljanPregledZaposlenog.MaximizeBox = false;
            DetaljanPregledZaposlenog.MinimizeBox = false;
            DetaljanPregledZaposlenog.Show();
            DetaljanPregledZaposlenog.FormClosed += DetaljanPregledZaposlenog_FormClosed;

            detaljnoFormaLoad(DetaljanPregledZaposlenog, 1020, 350);

            FlowLayoutPanel flpZaposleniDetaljno = new FlowLayoutPanel();
            flpZaposleniDetaljno.BackColor = Color.FromArgb(5, 56, 107);
            flpZaposleniDetaljno.Dock = DockStyle.Left;
            flpZaposleniDetaljno.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            DetaljanPregledZaposlenog.Controls.Add(flpZaposleniDetaljno);
            flpZaposleniDetaljno.FlowDirection = FlowDirection.TopDown;
            flpZaposleniDetaljno.BorderStyle = System.Windows.Forms.BorderStyle.None;

            FlowLayoutPanel flpZaduzenja = new FlowLayoutPanel();
            flpZaduzenja.Dock = DockStyle.Right;
            flpZaduzenja.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            flpZaduzenja.Padding = new Padding(10, 0, 0, 0);
            flpZaduzenja.Width = DetaljanPregledZaposlenog.Width - flpZaposleniDetaljno.Width - 40;
            flpZaduzenja.BorderStyle = System.Windows.Forms.BorderStyle.None;
            DetaljanPregledZaposlenog.Controls.Add(flpZaduzenja);


            string Query = "EXEC dbo.DetaljanPregledZaposlenog @ZaposleniID";
            SqlConnection sqlConnection = new SqlConnection(SqlHelper.GetConnectionString());
            SqlCommand cmd = new SqlCommand(Query, sqlConnection);
            DataGridView grid = pnlDashboard.Controls[0] as DataGridView;

            SqlParameter sqlParameter = new SqlParameter("@ZaposleniID", SqlDbType.Int);
            cmd.Parameters.Add(sqlParameter);
            cmd.Parameters["@ZaposleniID"].Value = Convert.ToInt32(grid.SelectedRows[0].Cells[0].Value.ToString());

            DataTable dt = new DataTable();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            sqlDataAdapter.Fill(dt);

            Label lblZaposleniID = new Label();
            Label lblIme = new Label();
            Label lblPrezime = new Label();
            Label lblRadnoMjesto = new Label();

            lblZaposleniID.Text = "ID\n";
            lblZaposleniID.Text += dt.Rows[0].ItemArray[0].ToString() + "\n";

            lblIme.Text = "Ime\n";
            lblIme.Text += dt.Rows[0].ItemArray[1].ToString() + "\n";

            lblPrezime.Text = "Prezime\n";
            lblPrezime.Text += dt.Rows[0].ItemArray[2].ToString() + "\n";

            lblRadnoMjesto.Text = "Radno mjesto\n";
            lblRadnoMjesto.Text += dt.Rows[0].ItemArray[3].ToString() + "\n";

            flpZaposleniDetaljno.Controls.Add(lblZaposleniID);
            flpZaposleniDetaljno.Controls.Add(lblIme);
            flpZaposleniDetaljno.Controls.Add(lblPrezime);
            flpZaposleniDetaljno.Controls.Add(lblRadnoMjesto);

            foreach (var item in flpZaposleniDetaljno.Controls)
            {
                if (item.GetType() == typeof(Label))
                {
                    Label lbl = item as Label;
                    lbl.AutoSize = true;
                    lbl.Font = new Font("Segoe UI", 12);
                    lbl.ForeColor = Color.White;
                    lbl.Margin = new Padding(15, 5, 0, 5);
                }
            }

            string QueryZaduzenja = "exec dbo.[SvaZaduzenjaJednogZaposlenog] @ZaposleniID";
            SqlCommand command = new SqlCommand(QueryZaduzenja, sqlConnection);
            command.Parameters.Add(new SqlParameter("@ZaposleniID", SqlDbType.Int));
            command.Parameters["@ZaposleniID"].Value = Convert.ToInt32(grid.SelectedRows[0].Cells[0].Value.ToString());

            DataTable table = new DataTable();
            sqlDataAdapter = new SqlDataAdapter(command);
            sqlDataAdapter.Fill(table);
            DataGridView zaduzenjaGrid = new DataGridView();
            zaduzenjaGrid.DataSource = table;
            flpZaduzenja.Controls.Add(zaduzenjaGrid);
            dgvDimeznije(zaduzenjaGrid);
            zaduzenjaGrid.Width = flpZaduzenja.Width;

            foreach (DataGridViewColumn item in zaduzenjaGrid.Columns)
            {
                item.Width += 70;
            }

        }

        private void BtnIzmjeni_Click(object sender, EventArgs e)
        {
            AddUpdate();
            pnlDashboard.Controls.Clear();
            btnZaposleni_Click(sender, e);
            Button btn = sender as Button;
            btn.Name = "btnPregled";
            BtnPodmeniZaposleni_Click(btn, e);
        }

        private void BtnDodaj_Click(object sender, EventArgs e)
        {
            AddUpdate();
            pnlDashboard.Controls.Clear();

            if (tacno == false)
            {
                MessageBox.Show("Dodan novi zaposleni!");
            }

            btnZaposleni_Click(sender, e);
            Button btn = sender as Button;
            btn.Name = "btnDodajZaposlenog";
            BtnPodmeniZaposleni_Click(btn, e);
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
                buttonDesign(btnPodmeniZaduzenja);
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

                FlowLayoutPanel flpButoni = new FlowLayoutPanel();
                flpButoni.FlowDirection = FlowDirection.LeftToRight;
                flpButoni.Padding = new Padding(50, 0, 0, 0);
                flpButoni.Width = pnlDashboard.Width;

                pnlDashboard.Controls.Add(dtg);
                pnlDashboard.Controls.Add(flpButoni);

                for (int i = 0; i < 3; i++)
                {
                    MetroTile btnCrud = new MetroTile();
                    if (i == 0)
                    {
                        btnCrud.Text = "ZADUZI";
                        btnCrud.Name = "btnDodaj";
                    }
                    if (i == 1)
                    {
                        btnCrud.Text = "IZMIJENI";
                        btnCrud.Name = "btnIzmijeni";
                    }
                    if (i == 2)
                    {
                        btnCrud.Text = "OBRISI";
                        btnCrud.Name = "btnIzbrisi";
                    }
                    crudButtonDesign(btnCrud);
                    flpButoni.Controls.Add(btnCrud);
                    btnCrud.Click += BtnCrud_Click;
                }

                PopulateGrid();
                dgvDimeznije(dtg);
            }
            else if (button.Name == "btnZaduzi")
            {
                state = StateEnum.Add;
                pnlDashboard.Controls.Clear();
                myProperty = new PropertyClassZaduzenja();
                PopulateControls("Dodajte novo zaduzenje");

                FlowLayoutPanel flpButon = new FlowLayoutPanel();
                flpButon.FlowDirection = FlowDirection.LeftToRight;
                flpButon.Width = pnlDashboard.Width;
                pnlDashboard.Controls.Add(flpButon);

                Button btnZaduzi = new Button();
                btnZaduzi.Text = "ZADUZI";
                btnZaduzi.Name = "btnZaduzi";
                flpButon.Controls.Add(btnZaduzi);

                btnZaduzi.Click += BtnZaduzi_Click;

                Button btnOtkazi = new Button();
                btnOtkazi.Name = "btnOtkazi";
                btnOtkazi.Text = "OTKAZI";
                flpButon.Controls.Add(btnOtkazi);

                btnOtkazi.Click += BtnOtkazi_Click2;
            }
            else if (button.Name == "btnRazduzi" || button.Name == "btnOtkaziRazduzenje")
            {
                state = StateEnum.Razduzi;
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

                btnRazduzi.Click += BtnRazduzi_Click;


            }
            //ISTORIJA ZADUZIVANJA
            else if (button.Name == "btnIstorija")
            {
                pnlDashboard.Controls.Clear();
                DataGridView dtg = new DataGridView();
                myProperty = new PropertyClassIstorijaZaduzenja();
                FlowLayoutPanel flpanel = new FlowLayoutPanel();
                flpanel.Height = 100;
                flpanel.Width = 470;
                MetroTile btnPretraga = new MetroTile();
                btnPretraga.Name = "btnPretraga";
                btnPretraga.Text = "PRETRAGA";
                crudButtonDesign(btnPretraga);
                dgvDimeznije(dtg);
                pnlDashboard.Controls.Add(dtg);
                flpanel.Controls.Add(btnPretraga);
                pnlDashboard.Controls.Add(flpanel);
                btnPretraga.Click += BtnPretraga_Click;
                PopulateGrid();
            }
        }

        private void BtnPretraga_Click(object sender, EventArgs e)
        {
            
            MetroTile btnPretraga = sender as MetroTile;
            
            FlowLayoutPanel flpanel = btnPretraga.Parent as FlowLayoutPanel;
           
            if (btnPretraga.Text == "PRETRAGA")
            {
                btnPretraga.Text = "PRETRAZI";

                FlowLayoutPanel panel = new FlowLayoutPanel();
                panel.Size = new Size(219, 100);
                MetroDateTime dateTimePicker1 = new MetroDateTime();
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss";
                dateTimePicker1.MinDate = new DateTime(2018, 1, 1);
                dateTimePicker1.MaxDate = DateTime.Today;

                MetroDateTime dateTimePicker2 = new MetroDateTime();
                dateTimePicker2.Format = DateTimePickerFormat.Custom;
                dateTimePicker2.CustomFormat = "MM/dd/yyyy hh:mm:ss";
                dateTimePicker2.MaxDate = DateTime.Today;

                dateTimePicker1.Value = dateTimePicker1.MinDate;
                dateTimePicker2.Value = dateTimePicker2.MaxDate;



                panel.Controls.Add(dateTimePicker1);
                panel.Controls.Add(dateTimePicker2);

                flpanel.Controls.Add(panel);
            }

            else if (btnPretraga.Text == "PRETRAZI")
            {
                DataGridView dtg = pnlDashboard.Controls[0] as DataGridView;
                FlowLayoutPanel panel = pnlDashboard.Controls[1].Controls[1] as FlowLayoutPanel;

                DateTimePicker dateTimePicker1 = pnlDashboard.Controls[1].Controls[1].Controls[0] as DateTimePicker;
                DateTimePicker dateTimePicker2 = pnlDashboard.Controls[1].Controls[1].Controls[1] as DateTimePicker;
                string QueryIstorijaZaduzenja = "Select * from dbo.IstorijaZaduzenjaPretraga(@datum1,@datum2)";
                SqlConnection konekcija = new SqlConnection(SqlHelper.GetConnectionString());
                SqlCommand sqlCommand = new SqlCommand(QueryIstorijaZaduzenja, konekcija);


                SqlParameter parametar = new SqlParameter("@datum1", SqlDbType.Date);
                SqlParameter parameter2 = new SqlParameter("@datum2", SqlDbType.Date);


                sqlCommand.Parameters.Add(parametar);
                sqlCommand.Parameters.Add(parameter2);
                parametar.Value = dateTimePicker1.Value;
                parameter2.Value = dateTimePicker2.Value;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                adapter.Fill(dt);
                dtg.DataSource = dt;
                // pnlDashboard.Controls.SetChildIndex(dtg, 0);




                flpanel.Controls.RemoveAt(1);
                btnPretraga.Text = "PRETRAGA";
            }


        }

        private void BtnPretrazi_Click(object sender, EventArgs e)
        {
            DataGridView dtg = pnlDashboard.Controls[0] as DataGridView;

            DateTimePicker dateTimePicker1 = pnlDashboard.Controls[1].Controls[1] as DateTimePicker;
            DateTimePicker dateTimePicker2 = pnlDashboard.Controls[1].Controls[2] as DateTimePicker;
            string QueryIstorijaZaduzenja = "Select * from dbo.IstorijaZaduzenjaPretraga(@datum1,@datum2)";
            SqlConnection konekcija = new SqlConnection(SqlHelper.GetConnectionString());
            SqlCommand sqlCommand = new SqlCommand(QueryIstorijaZaduzenja, konekcija);


            SqlParameter parametar = new SqlParameter("@datum1", SqlDbType.Date);
            SqlParameter parameter2 = new SqlParameter("@datum2", SqlDbType.Date);


            sqlCommand.Parameters.Add(parametar);
            sqlCommand.Parameters.Add(parameter2);
            parametar.Value = dateTimePicker1.Value;
            parameter2.Value = dateTimePicker2.Value;
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            adapter.Fill(dt);
            dtg.DataSource = dt;
            pnlDashboard.Controls.SetChildIndex(dtg, 0);
        }





        private void BtnRazduzi_Click(object sender, EventArgs e)
        {
            state = StateEnum.Razduzi;
            myProperty = new PropertyClassZaduzenja();

            ucitajVrijednostiUPolja();
            FlowLayoutPanel flpButon = new FlowLayoutPanel();
            flpButon.FlowDirection = FlowDirection.LeftToRight;
            flpButon.Width = pnlDashboard.Width;
            pnlDashboard.Controls.Add(flpButon);

            Button btnSacuvaj = new Button();
            btnSacuvaj.Text = "SACUVAJ";
            btnSacuvaj.Name = "btnSacuvaj";
            flpButon.Controls.Add(btnSacuvaj);

            btnSacuvaj.Click += BtnSacuvaj_Click;

            Button btnOtkaziRazduzenje = new Button();
            btnOtkaziRazduzenje.Name = "btnOtkaziRazduzenje";
            btnOtkaziRazduzenje.Text = "OTKAZI";
            flpButon.Controls.Add(btnOtkaziRazduzenje);

            btnOtkaziRazduzenje.Click += BtnPodmeniZaduzenja_Click;
        }

        private void BtnZaduzi_Click(object sender, EventArgs e)
        {
            state = StateEnum.Add;
            AddUpdate();

            if (tacno == false)
            {
                MessageBox.Show("Dodano je novo zaduzenje!");
            }

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
                PopulateControls("Dodajte novo zaduzenje");

                FlowLayoutPanel flpButon = new FlowLayoutPanel();
                flpButon.FlowDirection = FlowDirection.LeftToRight;
                flpButon.Width = pnlDashboard.Width;
                pnlDashboard.Controls.Add(flpButon);

                Button btnZaduzi = new Button();
                btnZaduzi.Text = "ZADUZI";
                btnZaduzi.Name = "btnZaduzi";
                flpButon.Controls.Add(btnZaduzi);
                btnZaduzi.Click += BtnZaduzi_Click;

            }
            else if (button.Name == "btnIzmijeni")
            {
                state = StateEnum.Update;
                myProperty = new PropertyClassZaduzenja();

                ucitajVrijednostiUPolja();
                FlowLayoutPanel flpButton = new FlowLayoutPanel();
                flpButton.FlowDirection = FlowDirection.LeftToRight;
                flpButton.Width = pnlDashboard.Width;
                pnlDashboard.Controls.Add(flpButton);

                Button btnSacuvaj = new Button();
                btnSacuvaj.Text = "SACUVAJ";
                btnSacuvaj.Name = "btnSacuvaj";
                flpButton.Controls.Add(btnSacuvaj);

                btnSacuvaj.Click += BtnSacuvaj_Click;

                Button btnOtkazi = new Button();
                btnOtkazi.Name = "btnOtkazi";
                btnOtkazi.Text = "OTKAZI";
                flpButton.Controls.Add(btnOtkazi);

                btnOtkazi.Click += BtnOtkazi_Click2;

            }
            else if ((button.Name == "btnIzbrisi"))
            {
                DataGridView dtg = pnlDashboard.Controls[0] as DataGridView;
                delete(dtg);
                Button btnPregled = sender as Button;
                btnPregled.Name = "btnPregled";

                MessageBox.Show("Zaduzenje je izbrisano!");

                btnZaduzenja_Click(sender, e);
                BtnPodmeniZaduzenja_Click(sender, e);

            }
        }

        private void BtnOtkazi_Click2(object sender, EventArgs e)
        {
            btnZaduzenja_Click(sender, e);
            Button podmeniTrenutna = sender as Button;
            podmeniTrenutna.Name = "btnPregled";
            BtnPodmeniZaduzenja_Click(podmeniTrenutna, e);
        }

        private void BtnSacuvaj_Click(object sender, EventArgs e)
        {
            state = StateEnum.Razduzi;
            AddUpdate();
            if (tacno == false)
            {
                MessageBox.Show("Uspjesna izmjena!");
            }


            pnlDashboard.Controls.Clear();
            btnZaduzenja_Click(sender, e);
            Button podmeniTrenutna = sender as Button;
            podmeniTrenutna.Name = "btnPregled";
            BtnPodmeniZaduzenja_Click(podmeniTrenutna, e);
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

            for (int i = 0; i < 3; i++)
            {
                Button btnPodmeniServis = new Button();
                buttonDesign(btnPodmeniServis);
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
                if (i == 2)
                {
                    btnPodmeniServis.Text = "Tocenje goriva";
                    btnPodmeniServis.Name = "btnGorivo";
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

                pnlDashboard.Controls.Add(dtg);
                myProperty = new PropertyClassServisiranjeVozila();
                PropertyInterface pi;
                dgvDimeznije(dtg);
                pnlDashboard.Controls.Add(dtg);
                FlowLayoutPanel panel = new FlowLayoutPanel();
                panel.Padding = new Padding(50, 0, 0, 0);
                MetroTile AddServis = new MetroTile();
                AddServis.Click += AddServis_Click;

                MetroTile UpdateServis = new MetroTile();
                UpdateServis.Click += UpdateServis_Click;

                MetroTile DeleteServis = new MetroTile();
                DeleteServis.Click += DeleteServis_Click;

                MetroTile Pretraga = new MetroTile();
                Pretraga.Click += Pretraga_Click;



                AddServis.Text = "DODAJ";
                crudButtonDesign(AddServis);
                DeleteServis.Text = "OBRISI";
                crudButtonDesign(DeleteServis);
                UpdateServis.Text = "IZMIJENI";
                crudButtonDesign(UpdateServis);
                Pretraga.Text = "Pretraga servisa";

                panel.Height = 100;
                panel.Width = 770;
                panel.Controls.Add(AddServis);
                panel.Controls.Add(UpdateServis);
                panel.Controls.Add(DeleteServis);
                panel.Controls.Add(Pretraga);

                pnlDashboard.Controls.Add(panel);



                FlowLayoutPanel nov = new FlowLayoutPanel();








                nov.Height = 100;
                nov.Width = 470;


                pnlDashboard.Controls.Add(nov);
                PopulateGrid();
            }
            else if (button.Name == "btnServis")
            {
                state = StateEnum.Add;
                pnlDashboard.Controls.Clear();
                myProperty = new PropertyClassServisiranjeVozila();

                PopulateControls("Unesite podatke o servisu");

                FlowLayoutPanel panel = new FlowLayoutPanel();
                Button btnDodajServis = new Button();
                Button btnOtkazi1 = new Button();
                btnDodajServis.Text = "DODAJ SERVIS";
                btnOtkazi1.Text = "OTKAZI";

                btnDodajServis.Click += BtnDodajServis_Click;
                btnOtkazi1.Click += BtnOtkazi1_Click;
                btnOtkazi1.Visible = true;

                panel.Height = 100;
                panel.Width = 470;
                panel.Controls.Add(btnDodajServis);
                panel.Controls.Add(btnOtkazi1);
                pnlDashboard.Controls.Add(panel);
            }
            else if (button.Name == "btnGorivo")
            {
                pnlDashboard.Controls.Clear();
                DataGridView dtg = new DataGridView();
                pnlDashboard.Controls.Add(dtg);
                myProperty = new PropertyClassGorivo();

                dgvDimeznije(dtg);
                pnlDashboard.Controls.Add(dtg);
                FlowLayoutPanel panel = new FlowLayoutPanel();
                panel.Padding = new Padding(50, 0, 0, 0);
                MetroTile AddGorivo = new MetroTile();
                AddGorivo.Click += AddGorivo_Click;

                MetroTile UpdateGorivo = new MetroTile();
                UpdateGorivo.Click += UpdateGorivo_Click;

                MetroTile DeleteGorivo = new MetroTile();
                DeleteGorivo.Click += DeleteGorivo_Click;

                MetroTile PretragaGorivo = new MetroTile();
                PretragaGorivo.Click += PretragaGorivo_Click;

                AddGorivo.Text = "DODAJ";
                crudButtonDesign(AddGorivo);
                DeleteGorivo.Text = "OBRISI";
                crudButtonDesign(DeleteGorivo);
                UpdateGorivo.Text = "IZMIJENI";
                crudButtonDesign(UpdateGorivo);
                PretragaGorivo.Text = "Pretraga";

                panel.Height = 100;
                panel.Width = 670;
                panel.Controls.Add(AddGorivo);
                panel.Controls.Add(UpdateGorivo);
                panel.Controls.Add(DeleteGorivo);
                panel.Controls.Add(PretragaGorivo);
                pnlDashboard.Controls.Add(panel);
                PopulateGrid();
            }
        }

        private void PretragaGorivo_Click(object sender, EventArgs e)
        {
            Button PretragaGorivo = sender as Button;
            if (PretragaGorivo.Text == "Pretraga")
            {
                FlowLayoutPanel panel = PretragaGorivo.Parent as FlowLayoutPanel;
                FlowLayoutPanel noviPanel = new FlowLayoutPanel();

                DateTimePicker prvi = new DateTimePicker();
                DateTimePicker drugi = new DateTimePicker();

                prvi.MinDate = new DateTime(2018, 01, 01);
                prvi.MaxDate = DateTime.Now;
                prvi.Value = prvi.MinDate;

                drugi.MaxDate = DateTime.Now;
                drugi.Value = drugi.MaxDate;

                noviPanel.Controls.Add(prvi);
                noviPanel.Controls.Add(drugi);
                panel.Controls.Add(noviPanel);


                PretragaGorivo.Text = "Pretrazi";

            }
            else
            {



                DataGridView dtg = pnlDashboard.Controls[0] as DataGridView;
                FlowLayoutPanel panel = pnlDashboard.Controls[1] as FlowLayoutPanel;
                FlowLayoutPanel noviPanel = pnlDashboard.Controls[1].Controls[1] as FlowLayoutPanel;


                DateTimePicker prvi = pnlDashboard.Controls[1].Controls[4].Controls[0] as DateTimePicker;
                DateTimePicker drugi = pnlDashboard.Controls[1].Controls[4].Controls[1] as DateTimePicker;




                myProperty = new PropertyClassGorivo();
                PropertyInterface pi;



                string PretragaServis = "SELECT * FROM dbo.pretragaGorivo(@datum1,@datum2)";

                SqlConnection konekcija = new SqlConnection(SqlHelper.GetConnectionString());
                SqlCommand sqlcom = new SqlCommand(PretragaServis, konekcija);


                SqlParameter parametar = new SqlParameter("@datum1", SqlDbType.Date);
                SqlParameter parametar2 = new SqlParameter("@datum2", SqlDbType.Date);



                sqlcom.Parameters.Add(parametar);
                sqlcom.Parameters.Add(parametar2);

                parametar.Value = prvi.Value;
                parametar2.Value = drugi.Value;

                DataTable dt = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(sqlcom);
                adapter.Fill(dt);

                dtg.DataSource = dt;

                PretragaGorivo.Text = "Pretraga";

                panel.Controls.RemoveAt(4);


            }
        }

        private void Pretraga_Click(object sender, EventArgs e)
        {

            Button Pretraga = sender as Button;
            if (Pretraga.Text == "Pretraga servisa")
            {
                FlowLayoutPanel panel = Pretraga.Parent as FlowLayoutPanel;
                FlowLayoutPanel noviPanel = new FlowLayoutPanel();

                DateTimePicker prvi = new DateTimePicker();
                DateTimePicker drugi = new DateTimePicker();

                prvi.MinDate = new DateTime(2018, 01, 01);
                prvi.MaxDate = DateTime.Now;
                prvi.Value = prvi.MinDate;

                drugi.MaxDate = DateTime.Now;
                drugi.Value = drugi.MaxDate;

                noviPanel.Controls.Add(prvi);
                noviPanel.Controls.Add(drugi);
                panel.Controls.Add(noviPanel);


                Pretraga.Text = "Pretrazi";

            }
            else {



                DataGridView dtg = pnlDashboard.Controls[0] as DataGridView;
                FlowLayoutPanel panel = pnlDashboard.Controls[1] as FlowLayoutPanel;
                FlowLayoutPanel noviPanel = pnlDashboard.Controls[1].Controls[4] as FlowLayoutPanel;


                DateTimePicker prvi = pnlDashboard.Controls[1].Controls[4].Controls[0] as DateTimePicker;
                DateTimePicker drugi = pnlDashboard.Controls[1].Controls[4].Controls[1] as DateTimePicker;




                myProperty = new PropertyClassServisiranjeVozila();
                PropertyInterface pi;



                string PretragaServisa = "SELECT * FROM dbo.pretraga(@datum1,@datum2)";

                SqlConnection konekcija = new SqlConnection(SqlHelper.GetConnectionString());
                SqlCommand sqlcom = new SqlCommand(PretragaServisa, konekcija);


                SqlParameter parametar = new SqlParameter("@datum1", SqlDbType.Date);
                SqlParameter parametar2 = new SqlParameter("@datum2", SqlDbType.Date);



                sqlcom.Parameters.Add(parametar);
                sqlcom.Parameters.Add(parametar2);

                parametar.Value = prvi.Value;
                parametar2.Value = drugi.Value;

                DataTable dt = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(sqlcom);
                adapter.Fill(dt);

                dtg.DataSource = dt;

                Pretraga.Text = "Pretraga servisa";

                panel.Controls.RemoveAt(4);


            }




        }



        private void DeleteGorivo_Click(object sender, EventArgs e)
        {
            DataGridView dtg = pnlDashboard.Controls[0] as DataGridView;
            delete(dtg);
            MessageBox.Show("Gorivo sklonjeno!!!");

            Button button = sender as Button;
            button.Name = "btnGorivo";

            BtnPodmeniServis_Click(button, e);
        }

        private void UpdateGorivo_Click(object sender, EventArgs e)
        {
            state = StateEnum.Update;
            myProperty = new PropertyClassGorivo();
            DataGridView grid = pnlDashboard.Controls[0] as DataGridView;
            ucitajVrijednostiUPolja();
            FlowLayoutPanel panel = new FlowLayoutPanel();
            Button btnDodajGorivo = new Button();
            Button btnOtkaziGorivo = new Button();
            btnDodajGorivo.Text = "SACUVAJ";
            btnOtkaziGorivo.Text = "OTKAZI";

            btnDodajGorivo.Click += BtnDodajGorivo_Click;
            btnOtkaziGorivo.Click += BtnOtkaziGorivo_Click;

            panel.Height = 100;
            panel.Width = 470;
            panel.Controls.Add(btnDodajGorivo);
            panel.Controls.Add(btnOtkaziGorivo);
            pnlDashboard.Controls.Add(panel);
        }

        private void AddGorivo_Click(object sender, EventArgs e)
        {
            state = StateEnum.Add;
            pnlDashboard.Controls.Clear();
            myProperty = new PropertyClassGorivo();

            PopulateControls("Unesite podatke o tocenju goriva");

            FlowLayoutPanel panel = new FlowLayoutPanel();
            Button btnDodajGorivo = new Button();
            Button btnOtkaziGorivo = new Button();
            btnDodajGorivo.Text = "SACUVAJ";
            btnOtkaziGorivo.Text = "OTKAZI";

            btnDodajGorivo.Click += BtnDodajGorivo_Click;
            btnOtkaziGorivo.Click += BtnOtkaziGorivo_Click;


            panel.Height = 100;
            panel.Width = 470;
            panel.Controls.Add(btnDodajGorivo);
            panel.Controls.Add(btnOtkaziGorivo);
            pnlDashboard.Controls.Add(panel);
        }

        private void BtnOtkaziGorivo_Click(object sender, EventArgs e)
        {
            if (state == StateEnum.Add)
            {
                pnlDashboard.Controls.Clear();
                DataGridView dtg = new DataGridView();
                pnlDashboard.Controls.Add(dtg);
                myProperty = new PropertyClassGorivo();

                dgvDimeznije(dtg);
                pnlDashboard.Controls.Add(dtg);
                FlowLayoutPanel panel = new FlowLayoutPanel();
                panel.Padding = new Padding(50, 0, 0, 0);

                MetroTile AddGorivo = new MetroTile();
                AddGorivo.Click += AddGorivo_Click;

                MetroTile UpdateGorivo = new MetroTile();
                UpdateGorivo.Click += UpdateGorivo_Click;

                MetroTile DeleteGorivo = new MetroTile();
                DeleteGorivo.Click += DeleteGorivo_Click;

                MetroTile PretragaGorivo = new MetroTile();
                PretragaGorivo.Click += PretragaGorivo_Click;

                AddGorivo.Text = "DODAJ";
                crudButtonDesign(AddGorivo);
                DeleteGorivo.Text = "OBRISI";
                crudButtonDesign(DeleteGorivo);
                UpdateGorivo.Text = "IZMIJENI";
                crudButtonDesign(UpdateGorivo);
                PretragaGorivo.Text = "Pretraga";

                panel.Height = 100;
                panel.Width = 670;
                panel.Controls.Add(AddGorivo);
                panel.Controls.Add(UpdateGorivo);
                panel.Controls.Add(DeleteGorivo);
                panel.Controls.Add(PretragaGorivo);
                pnlDashboard.Controls.Add(panel);
                PopulateGrid();
            }
            else if (state == StateEnum.Update)
            {
                pnlDashboard.Controls.Clear();
                DataGridView dtg = new DataGridView();
                pnlDashboard.Controls.Add(dtg);
                myProperty = new PropertyClassGorivo();

                dgvDimeznije(dtg);
                pnlDashboard.Controls.Add(dtg);
                FlowLayoutPanel panel = new FlowLayoutPanel();
                panel.Padding = new Padding(50, 0, 0, 0);

                MetroTile AddGorivo = new MetroTile();
                AddGorivo.Click += AddGorivo_Click;

                MetroTile UpdateGorivo = new MetroTile();
                UpdateGorivo.Click += UpdateGorivo_Click;

                MetroTile DeleteGorivo = new MetroTile();
                DeleteGorivo.Click += DeleteGorivo_Click;

                MetroTile PretragaGorivo = new MetroTile();
                PretragaGorivo.Click += PretragaGorivo_Click;

                AddGorivo.Text = "DODAJ";
                crudButtonDesign(AddGorivo);
                DeleteGorivo.Text = "OBRISI";
                crudButtonDesign(DeleteGorivo);
                UpdateGorivo.Text = "IZMIJENI";
                crudButtonDesign(UpdateGorivo);
                PretragaGorivo.Text = "Pretraga";

                panel.Height = 100;
                panel.Width = 670;
                panel.Controls.Add(AddGorivo);
                panel.Controls.Add(UpdateGorivo);
                panel.Controls.Add(DeleteGorivo);
                panel.Controls.Add(PretragaGorivo);
                pnlDashboard.Controls.Add(panel);
                PopulateGrid();
            }
        }

        private void BtnDodajGorivo_Click(object sender, EventArgs e)
        {
            AddUpdate();

            if (state == StateEnum.Add)
            {

                if (tacno == false)
                {
                    MessageBox.Show("Uspjesno uneseni podaci o sipanju goriva!");
                }


                pnlDashboard.Controls.Clear();
                myProperty = new PropertyClassGorivo();

                PopulateControls("Unesite podatke o tocenju goriva");

                FlowLayoutPanel panel = new FlowLayoutPanel();
                Button btnDodajGorivo = new Button();
                Button btnOtkaziGorivo = new Button();
                btnDodajGorivo.Text = "SACUVAJ";
                btnOtkaziGorivo.Text = "OTKAZI";

                btnDodajGorivo.Click += BtnDodajGorivo_Click;
                btnOtkaziGorivo.Click += BtnOtkaziGorivo_Click;

                panel.Height = 100;
                panel.Width = 470;
                panel.Controls.Add(btnDodajGorivo);
                panel.Controls.Add(btnOtkaziGorivo);
                pnlDashboard.Controls.Add(panel);
            }
            else if (state == StateEnum.Update)
            {
                myProperty = new PropertyClassServisiranjeVozila();

                if (tacno == false)
                {
                    MessageBox.Show("Izmijenjeno sipanje goriva");
                }


                pnlDashboard.Controls.Clear();
                DataGridView dtg = new DataGridView();
                pnlDashboard.Controls.Add(dtg);
                myProperty = new PropertyClassGorivo();

                dgvDimeznije(dtg);
                pnlDashboard.Controls.Add(dtg);
                FlowLayoutPanel panel = new FlowLayoutPanel();
                Button AddGorivo = new Button();
                AddGorivo.Click += AddGorivo_Click;

                Button UpdateGorivo = new Button();
                UpdateGorivo.Click += UpdateGorivo_Click;

                Button DeleteGorivo = new Button();
                DeleteGorivo.Click += DeleteGorivo_Click;

                AddGorivo.Text = "DODAJ";
                DeleteGorivo.Text = "IZBRISI";
                UpdateGorivo.Text = "IZMIJENI";

                panel.Height = 100;
                panel.Width = 470;
                panel.Controls.Add(AddGorivo);
                panel.Controls.Add(DeleteGorivo);
                panel.Controls.Add(UpdateGorivo);
                pnlDashboard.Controls.Add(panel);
                PopulateGrid();
            }
        }

        private void BtnGorivo_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnOtkazi1_Click(object sender, EventArgs e)
        {
            if (state == StateEnum.Add)
            {
                pnlDashboard.Controls.Clear();
                DataGridView dtg = new DataGridView();

                pnlDashboard.Controls.Add(dtg);
                myProperty = new PropertyClassServisiranjeVozila();
                PropertyInterface pi;
                dgvDimeznije(dtg);
                pnlDashboard.Controls.Add(dtg);
                FlowLayoutPanel panel = new FlowLayoutPanel();
                panel.Padding = new Padding(50, 0, 0, 0);
                MetroTile AddServis = new MetroTile();
                AddServis.Click += AddServis_Click;

                MetroTile UpdateServis = new MetroTile();
                UpdateServis.Click += UpdateServis_Click;

                MetroTile DeleteServis = new MetroTile();
                DeleteServis.Click += DeleteServis_Click;

                MetroTile Pretraga = new MetroTile();
                Pretraga.Click += Pretraga_Click;



                AddServis.Text = "DODAJ";
                crudButtonDesign(AddServis);
                DeleteServis.Text = "OBRISI";
                crudButtonDesign(DeleteServis);
                UpdateServis.Text = "IZMIJENI";
                crudButtonDesign(UpdateServis);
                Pretraga.Text = "Pretraga servisa";

                panel.Height = 100;
                panel.Width = 770;
                panel.Controls.Add(AddServis);
                panel.Controls.Add(UpdateServis);
                panel.Controls.Add(DeleteServis);
                panel.Controls.Add(Pretraga);

                pnlDashboard.Controls.Add(panel);



                FlowLayoutPanel nov = new FlowLayoutPanel();








                nov.Height = 100;
                nov.Width = 470;


                pnlDashboard.Controls.Add(nov);
                PopulateGrid();
            }
            else if (state == StateEnum.Update)
            {
                pnlDashboard.Controls.Clear();
                DataGridView dtg = new DataGridView();

                pnlDashboard.Controls.Add(dtg);
                myProperty = new PropertyClassServisiranjeVozila();
                PropertyInterface pi;
                dgvDimeznije(dtg);
                pnlDashboard.Controls.Add(dtg);
                FlowLayoutPanel panel = new FlowLayoutPanel();
                panel.Padding = new Padding(50, 0, 0, 0);
                MetroTile AddServis = new MetroTile();
                AddServis.Click += AddServis_Click;

                MetroTile UpdateServis = new MetroTile();
                UpdateServis.Click += UpdateServis_Click;

                MetroTile DeleteServis = new MetroTile();
                DeleteServis.Click += DeleteServis_Click;

                MetroTile Pretraga = new MetroTile();
                Pretraga.Click += Pretraga_Click;



                AddServis.Text = "DODAJ";
                crudButtonDesign(AddServis);
                DeleteServis.Text = "OBRISI";
                crudButtonDesign(DeleteServis);
                UpdateServis.Text = "IZMIJENI";
                crudButtonDesign(UpdateServis);
                Pretraga.Text = "Pretraga servisa";

                panel.Height = 100;
                panel.Width = 770;
                panel.Controls.Add(AddServis);
                panel.Controls.Add(UpdateServis);
                panel.Controls.Add(DeleteServis);
                panel.Controls.Add(Pretraga);

                pnlDashboard.Controls.Add(panel);



                FlowLayoutPanel nov = new FlowLayoutPanel();








                nov.Height = 100;
                nov.Width = 470;


                pnlDashboard.Controls.Add(nov);
                PopulateGrid();
            }
        }

        private void BtnDodajServis_Click(object sender, EventArgs e)
        {
            AddUpdate();

            if (state == StateEnum.Add)
            {

                if (tacno == false)
                {
                    MessageBox.Show("Unesen servis");
                }
                pnlDashboard.Controls.Clear();
                myProperty = new PropertyClassServisiranjeVozila();

                    PopulateControls("Unesite podatke o servisiranju");
                
                    FlowLayoutPanel panel = new FlowLayoutPanel();
                    Button btnDodajServis = new Button();
                    Button btnOtkazi1 = new Button();
                    btnDodajServis.Text = "SACUVAJ";
                
                    btnOtkazi1.Text = "OTKAZI";

                btnDodajServis.Click += BtnDodajServis_Click;
                btnOtkazi1.Click += BtnOtkazi1_Click;

                btnOtkazi1.Visible = true;

                panel.Height = 100;
                panel.Width = 470;

                panel.Controls.Add(btnDodajServis);
                panel.Controls.Add(btnOtkazi1);

                pnlDashboard.Controls.Add(panel);
            }
            else if (state == StateEnum.Update)
            {
                myProperty = new PropertyClassServisiranjeVozila();


                if (tacno == false)
                {
                    MessageBox.Show("Podaci o servisu su izmijenjeni!");
                }


                Button button = sender as Button;
                button.Name = "btnServis";
                BtnPodmeniServis_Click(button, e);
            }
        }

        private void DeleteServis_Click(object sender, EventArgs e)
        {
            DataGridView dtg = pnlDashboard.Controls[0] as DataGridView;
            delete(dtg);
            MessageBox.Show("Servis je obrisan!");

            Button button = sender as Button;
            button.Name = "btnPregled";

            BtnPodmeniServis_Click(button, e);
        }

        private void UpdateServis_Click(object sender, EventArgs e)
        {
            state = StateEnum.Update;
            myProperty = new PropertyClassServisiranjeVozila();
            DataGridView grid = pnlDashboard.Controls[0] as DataGridView;

            ucitajVrijednostiUPolja();
            FlowLayoutPanel panel = new FlowLayoutPanel();
            Button btnDodajServis = new Button();
            Button btnOtkazi1 = new Button();
            btnDodajServis.Text = "DODAJ SERVIS";

            btnOtkazi1.Text = "OTKAZI";

            btnDodajServis.Click += BtnDodajServis_Click;
            btnOtkazi1.Click += BtnOtkazi1_Click;

            panel.Height = 100;
            panel.Width = 470;

            panel.Controls.Add(btnDodajServis);
            panel.Controls.Add(btnOtkazi1);
            pnlDashboard.Controls.Add(panel);
        }

        private void AddServis_Click(object sender, EventArgs e)
        {
            state = StateEnum.Add;
            pnlDashboard.Controls.Clear();
            myProperty = new PropertyClassServisiranjeVozila();

            PopulateControls("Unesite podatke o servisiranju");

            FlowLayoutPanel panel = new FlowLayoutPanel();
            Button btnDodajServis = new Button();
            Button btnOtkazi1 = new Button();
            btnDodajServis.Text = "DODAJ SERVIS";
            btnOtkazi1.Text = "OTKAZI";

            btnDodajServis.Click += BtnDodajServis_Click;
            btnOtkazi1.Click += BtnOtkazi1_Click;
            btnOtkazi1.Visible = true;

            panel.Height = 100;
            panel.Width = 470;
            panel.Controls.Add(btnDodajServis);
            panel.Controls.Add(btnOtkazi1);
            pnlDashboard.Controls.Add(panel);

        }

        #endregion


        #region ostaleMetode
        private void PopulateGrid()
        {
            pnlDashboard.Padding = new Padding(0, 0, 0, 0);
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
                if (grid.Columns[i].Name == "Boja" || grid.Columns[i].Name == "BrojVrata" || grid.Columns[i].Name == "Dostupnost" || grid.Columns[i].Name == "GodinaProizvodnje")
                {
                    grid.Columns[i].Width = 100;

                }

                else if (grid.Columns[i].Name == "Kilometraza")
                    grid.Columns[i].DefaultCellStyle.Format = "#,0.###";

                else
                    grid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }



        }

        public void PopulateControls(string naslov)
        {
           
            pnlDashboard.Padding = new Padding(100, 0, 0, 0);
            Label lblNaslov = new Label();
            lblNaslov.Name = "lblNaslov";
            lblNaslov.Text = naslov;
            lblNaslov.AutoSize = true;
           
            pnlDashboard.Controls.Add(lblNaslov);

            foreach (PropertyInfo item in myProperty.GetType().GetProperties())
            {
                if (item.GetCustomAttribute<ForeignKeyAttribute>() != null)
                {
                    PropertyInterface foreignInterface = Assembly.GetExecutingAssembly().
                        CreateInstance(item.GetCustomAttribute<ForeignKeyAttribute>().referencedClass) as PropertyInterface;

                    LookupControl lookup = new LookupControl(foreignInterface);

                    lookup.Name = item.Name;
                    lookup.setLabel(item.GetCustomAttribute<DisplayNameAttribute>().DisplayName);


                    if (state == StateEnum.Update && lookup.Name == "Model ID") lookup.Enabled = false;

                    else if (item.GetCustomAttribute<ForeignField>() != null) continue;

                    pnlDashboard.Controls.Add(lookup);

                    if (state == StateEnum.Razduzi) lookup.Enabled = false;

                }
                else if (item.GetCustomAttribute<DateTimeAttribute>() != null)
                {
                    DateTimeControl dateTime = new DateTimeControl();
                    dateTime.Naziv = item.GetCustomAttribute<DisplayNameAttribute>().DisplayName;
                    pnlDashboard.Controls.Add(dateTime);

                    if (state == StateEnum.Add && dateTime.Naziv == "Datum razduzenja")
                        dateTime.Enabled = false;
                    if (state == StateEnum.Razduzi && dateTime.Naziv != "Datum razduzenja")
                        dateTime.Enabled = false;
                    if (state == StateEnum.Update && dateTime.Naziv == "Datum razduzenja")
                        dateTime.Enabled = false;
                }
                else if (item.GetCustomAttribute<ForeignField>() != null) continue;

                else if (item.GetCustomAttribute<PrimaryKeyAttribute>() != null) continue;

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
                        if (item.GetValue(myProperty) != null)
                            ic.UnosPolje = item.GetValue(myProperty).ToString();
                        else
                            ic.UnosPolje = "";
                    }

                    if (ic.Naziv == "Dostupnost")
                    {
                        ic.Visible = false;
                        ic.UnosPolje = "True";
                    }

                    if (ic.Naziv == "Predjena kilometraza" && (state == StateEnum.Add || state == StateEnum.Update))
                    {
                        ic.Enabled = false;
                        ic.UnosPolje = "0";
                    }
                    
                    pnlDashboard.Controls.Add(ic);
                }
            }
        }

        private Button startButtonClick()
        {
            Button btn = new Button();
            btn.Name = "btnPregled";
            return btn;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            pnlSelected1.Visible = false;
            pnlSelected2.Visible = false;
            pnlSelected3.Visible = false;
            pnlSelected4.Visible = false;
            btnVozila_Click(sender, e);
            BtnPodmeni_Click(startButtonClick(), e);
        }

        public void AddUpdate()
        {
            var properties = myProperty.GetType().GetProperties();
            int brojac = 0;
        
            

            string poruka = "";

            foreach (var item in pnlDashboard.Controls)
            {
                if (item.GetType() == typeof(LookupControl))
                {
                    LookupControl input = item as LookupControl;
                    string value = input.Key;

                    if (value == null || value == "")
                    {
                        brojac += 1;
                        if(poruka=="")
                        poruka += "Nisu sva polja popunjena.";
                    }
                    else
                    {
                        PropertyInfo property = properties.Where(x => input.Name == x.Name).FirstOrDefault();
                        property.SetValue(myProperty, Convert.ChangeType(value, property.PropertyType));
                    }
                }
                else if (item.GetType() == typeof(InputControl))
                {
                    InputControl input = item as InputControl;
                    if (!input.Enabled) continue;
                    string value = input.UnosPolje;


                   


                    if ((value == null || value == "") )
                    {
                       brojac += 1;
                        if(poruka=="")
                        poruka += "Nisu sva polja popunjena.";
                    }
                    else if (input.Naziv == "Kilometraza" && Regex.IsMatch(value, @"[a-zA-Z]"))
                    {

                        brojac += 1;
                        poruka += "Kilometraza ne smije sadrzavati slova";

                    }
                    else if (input.Naziv == "Boja" && Regex.IsMatch(value, @"[0-9]"))
                    {

                        brojac += 1;
                        poruka += "Boja ne smije sadrzavati brojeve.";

                    }
                    else if (input.Naziv == "Ime" && Regex.IsMatch(value, @"[0-9]"))
                    {

                        brojac += 1;
                        poruka += "Ime ne smije sadrzavati brojeve.";

                    }
                    else if (input.Naziv == "Prezime" && Regex.IsMatch(value, @"[0-9]"))
                    {

                        brojac += 1;
                        poruka += "Prezime ne smije sadrzavati brojeve.";

                    }
                    else if (input.Naziv == "Radno mjesto" && Regex.IsMatch(value, @"[0-9]"))
                    {

                        brojac += 1;
                        poruka += "Radno mjesto ne smije sadrzavati brojeve.";

                    }
                    else if (input.Naziv == "Broj vrata" && Regex.IsMatch(value, @"[a-zA-Z]"))
                    {

                        brojac += 1;
                        poruka += "Broj vrata ne smije sadrzavati slova.";

                    }
                    else if (input.Naziv == "Cijena servisa" && Regex.IsMatch(value, @"[a-zA-Z]"))
                    {

                        brojac += 1;
                        poruka += "Cijena servisa ne smije sadrzavati slova.";

                    }
                    else if (input.Naziv == "Kolicina  goriva" && Regex.IsMatch(value, @"[a-zA-Z]"))
                    {
                        
                        brojac += 1;
                        poruka += "Kolicina goriva ne smije sadrzavati slova.";
                     
                    }
                    else if (input.Naziv == "Cijena" && Regex.IsMatch(value, @"[a-zA-Z]"))
                    {
                        

                        brojac += 1;
                        poruka += "Cijena goriva ne smije sadrzavati slova.";

                    }
                    else if (input.Naziv == "Godina proizvodnje" && Regex.IsMatch(value, @"[a-zA-Z]"))
                    {

                        brojac += 1;
                        poruka += "Godina proizvodnje ne smije sadrzavati slova.";

                    }
                    else
                    {
                        PropertyInfo property = properties.Where(x => input.Naziv == x.GetCustomAttribute<DisplayNameAttribute>().DisplayName).FirstOrDefault();
                        property.SetValue(myProperty, Convert.ChangeType(value, property.PropertyType));
                    }

                }
                else if (item.GetType() == typeof(DateTimeControl))
                {
                    DateTimeControl date = item as DateTimeControl;
                    DateTime value = date.Unos;
                    PropertyInfo property = properties.Where(x => x.GetCustomAttribute<DisplayNameAttribute>().DisplayName == date.Naziv).FirstOrDefault();
                    property.SetValue(myProperty, Convert.ChangeType(value, property.PropertyType));
                }
            }
            if (state == StateEnum.Add &&brojac ==0)
                SqlHelper.ExecuteNonQuery(SqlHelper.GetConnectionString(), CommandType.Text,
                      myProperty.GetInsertQuery(), myProperty.GetInsertParameters().ToArray());
            else if (state == StateEnum.Update &&  brojac == 0  )
                SqlHelper.ExecuteNonQuery(SqlHelper.GetConnectionString(), CommandType.Text,
                 myProperty.GetUpdateQuery(), myProperty.GetUpdateParameters().ToArray());
            else if (state == StateEnum.Razduzi)
            {
                PropertyClassZaduzenja property = myProperty as PropertyClassZaduzenja; //razduzi nije dio interfejsa pa kastujem myProperty u zaduzenja da bih vidjela razduziQuery
                SqlHelper.ExecuteNonQuery(SqlHelper.GetConnectionString(), CommandType.Text,
                 property.RazduziQuery(), property.GetRazduziParameters().ToArray());
            }     
            else if (brojac>0 )
            {
                MessageBox.Show(poruka);
                tacno = true;

            }          
            else if (  brojac == 0 )
            {
                
                tacno = false;

            }
        }

        public string delete(DataGridView dg)
        {
            DataGridViewRow row = dg.SelectedRows[0];
            var properties = myProperty.GetType().GetProperties();

            foreach (PropertyInfo item in properties)
            {
                if (item.GetCustomAttribute<PrimaryKeyAttribute>() != null)
                {
                    string value = row.Cells[item.GetCustomAttribute<SqlNameAttribute>().Name]
                        .Value.ToString();

                    item.SetValue(myProperty, Convert.ChangeType(value, item.PropertyType));
                }
                if (item.GetCustomAttribute<SqlNameAttribute>().Name == "VozilaID")
                {
                    string value = row.Cells[item.GetCustomAttribute<SqlNameAttribute>().Name]
                        .Value.ToString();

                    item.SetValue(myProperty, Convert.ChangeType(value, item.PropertyType));
                }
            }


            if (myProperty.GetType() == typeof(PropertyClassVozila) || myProperty.GetType() == typeof(PropertyClassRegistracija))
            {
                if (row.Cells["Dostupnost"].Value.ToString() == "Dostupno")
                {
                    SqlHelper.ExecuteNonQuery(SqlHelper.GetConnectionString(), CommandType.Text,
                  myProperty.GetDeleteQuery(), myProperty.GetDeleteParameters().ToArray());
                    return "Uspijeh";
                }
                else
                {
                    MetroMessageBox.Show(this, "Vozilo je zaduzeno", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error, 90);
                    return "Greska";
                }

            }
            else
                return "Uspijeh";


        }

        private void ucitajVrijednostiUPolja()
        {
            DataGridView grid = pnlDashboard.Controls[0] as DataGridView;
            var type = myProperty.GetType();
            var properties = type.GetProperties();
            int i = 0;
            
            foreach (DataGridViewCell cell in grid.SelectedRows[0].Cells)
            {
                if ((state == StateEnum.Update || state == StateEnum.Razduzi) && myProperty.GetType() == typeof(PropertyClassZaduzenja))
                {
                    if (grid.Columns[i].HeaderText == "Datum razduzenja")
                    {
                        string value = DateTime.Now.ToString();

                        PropertyInfo property = properties.Where(x => grid.Columns[i].HeaderText == x.GetCustomAttribute<DisplayNameAttribute>().DisplayName).FirstOrDefault();
                        property.SetValue(myProperty, Convert.ChangeType(value, property.PropertyType));
                    }
                    else if(grid.Columns[i].HeaderText == "Predjena kilometraza")
                    {
                        string value = "0";

                        PropertyInfo property = properties.Where(x => grid.Columns[i].HeaderText == x.GetCustomAttribute<DisplayNameAttribute>().DisplayName).FirstOrDefault();
                        property.SetValue(myProperty, Convert.ChangeType(value, property.PropertyType));
                    }
                    else
                    {
                        string value = cell.Value.ToString();

                        PropertyInfo property = properties.Where(x => grid.Columns[i].HeaderText == x.GetCustomAttribute<DisplayNameAttribute>().DisplayName).FirstOrDefault();
                        property.SetValue(myProperty, Convert.ChangeType(value, property.PropertyType));
                    }

                }
                
              else if (state == StateEnum.Add && myProperty.GetType() == typeof(PropertyClassRegistracija))
                {
                    
                    if (grid.Columns[i].HeaderText == "Datum registracije" || grid.Columns[i].HeaderText == "Datum isteka registracije")
                    {
                        string value = DateTime.Now.ToString();

                        PropertyInfo property = properties.Where(x => grid.Columns[i].HeaderText == x.GetCustomAttribute<DisplayNameAttribute>().DisplayName).FirstOrDefault();
                        property.SetValue(myProperty, Convert.ChangeType(value, property.PropertyType));
                    }
                    else if (grid.Columns[i].HeaderText == "Registarski broj")
                    {
                        string value = cell.Value.ToString();

                        PropertyInfo property = properties.Where(x => grid.Columns[i].HeaderText == x.GetCustomAttribute<DisplayNameAttribute>().DisplayName).FirstOrDefault();
                        property.SetValue(myProperty, Convert.ChangeType(value, property.PropertyType));
                    }
                    else if (grid.Columns[i].Name == "RegistracijaID" || (grid.Columns[i].Name == "Cijena")) { }

                    else
                    {
                        
                        string value = cell.Value.ToString();
                        if (value == "Dostupno")
                        {
                            PropertyInfo property = properties.Where(x => grid.Columns[i].HeaderText == x.GetCustomAttribute<DisplayNameAttribute>().DisplayName).FirstOrDefault();
                            property.SetValue(myProperty, Convert.ChangeType(true, property.PropertyType));
                        }
                        else if (value == "Nije dostupno")
                        {
                            PropertyInfo property = properties.Where(x => grid.Columns[i].HeaderText == x.GetCustomAttribute<DisplayNameAttribute>().DisplayName).FirstOrDefault();
                            property.SetValue(myProperty, Convert.ChangeType(false, property.PropertyType));
                        }
                        else
                        {
                            PropertyInfo property = properties.Where(x => grid.Columns[i].HeaderText == x.GetCustomAttribute<DisplayNameAttribute>().DisplayName).FirstOrDefault();
                            property.SetValue(myProperty, Convert.ChangeType(value, property.PropertyType));
                        }
                    }
                }
                else
                {
                    string value = cell.Value.ToString();

                    if(value == "Dostupno")
                    {
                        PropertyInfo property = properties.Where(x => grid.Columns[i].HeaderText == x.GetCustomAttribute<DisplayNameAttribute>().DisplayName).FirstOrDefault();
                        property.SetValue(myProperty, Convert.ChangeType(true, property.PropertyType));
                    }
                    else if(value == "Nije dostupno")
                    {
                        PropertyInfo property = properties.Where(x => grid.Columns[i].HeaderText == x.GetCustomAttribute<DisplayNameAttribute>().DisplayName).FirstOrDefault();
                        property.SetValue(myProperty, Convert.ChangeType(false, property.PropertyType));
                    }
                    else
                    {
                        PropertyInfo property = properties.Where(x => grid.Columns[i].HeaderText == x.GetCustomAttribute<DisplayNameAttribute>().DisplayName).FirstOrDefault();
                        property.SetValue(myProperty, Convert.ChangeType(value, property.PropertyType));
                    }
                    
                }
                i++;
            } 
            
            pnlDashboard.Controls.Clear();
            PopulateControls("Izvrsite izmjenu");
            
            foreach (var item in pnlDashboard.Controls)
            {
                if (item.GetType() == typeof(InputControl))
                {
                    InputControl control = item as InputControl;

                    PropertyInfo property = properties.Where(x => control.Naziv == x.GetCustomAttribute<DisplayNameAttribute>().DisplayName).FirstOrDefault();
                    if (property.GetValue(myProperty) != null) control.UnosPolje = property.GetValue(myProperty).ToString();
                }
                else if (item.GetType() == typeof(DateTimeControl))
                {
                    DateTimeControl control = item as DateTimeControl;
                    PropertyInfo property = properties.Where(x => control.Naziv == x.GetCustomAttribute<DisplayNameAttribute>().DisplayName).FirstOrDefault();
                   
                        if (property.GetValue(myProperty) != null) control.Unos = (DateTime)property.GetValue(myProperty);
                }
                else if (item.GetType() == typeof(LookupControl))
                {
                    LookupControl control = item as LookupControl;
                    PropertyInfo property = properties.Where(x => control.getLabel() == x.GetCustomAttribute<DisplayNameAttribute>().DisplayName).FirstOrDefault();
                    if (property != null) control.Key = property.GetValue(myProperty).ToString();
                    
                        
                    PropertyInfo property2 = properties.Where(x => x.GetCustomAttribute<ForeignField>() != null && control.getLabel() == x.GetCustomAttribute<ForeignField>().tableKey).FirstOrDefault();
                    if (property2 != null) control.Value = property2.GetValue(myProperty).ToString();
                        
                }
            }
        }

        private void dgvDimeznije(DataGridView dtg)
        {
            dtg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtg.Location = new Point(50, 0);
            dtg.Height = 500;
            dtg.Width = pnlDashboard.Width - 30;
            dtg.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dtg.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtg.BackgroundColor = Color.White;
            dtg.RowHeadersVisible = false;

            dtg.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dtg.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dtg.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dtg.DefaultCellStyle.SelectionBackColor = Color.FromArgb(126, 180, 247);
            dtg.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dtg.BackgroundColor = Color.White;
            dtg.EnableHeadersVisualStyles = false;
            dtg.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dtg.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dtg.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dtg.ColumnHeadersDefaultCellStyle.Padding = new Padding(5, 0, 0, 0);
            dtg.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", (float)10.25);
            dtg.AllowUserToAddRows = false;
            dtg.AllowUserToResizeColumns = false;
            dtg.AllowUserToResizeRows = false;
            dtg.ReadOnly = true;
            dtg.ColumnHeadersHeight = 45;
            dtg.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", (float)8.75);
            dtg.DefaultCellStyle.Padding = new Padding(3, 0, 0, 0);

            if (dtg.Rows.Count > 0) dtg.Rows[0].Selected = true;

            foreach (DataGridViewColumn item in dtg.Columns)
            {
                if (item.Name.Contains("ID"))
                    item.Visible = false;
                
            }
            if(myProperty.GetType() == typeof(PropertyClassVozila))
            {
                foreach (DataGridViewRow item in dtg.Rows)
                {
                    if (item.Cells[7].Value.ToString() == "Dostupno")
                    {
                        item.Cells[7].Style.ForeColor = Color.LimeGreen;
                    }
                    else if (item.Cells[7].Value.ToString() == "Nije dostupno")
                    {
                        item.Cells[7].Style.ForeColor = Color.Red;
                    }
                }
            }
            else if(myProperty.GetType() == typeof(PropertyClassRegistracija))
            {
                foreach (DataGridViewRow item in dtg.Rows)
                {
                    if (item.Cells[6].Value.ToString() == "Dostupno")
                    {
                        item.Cells[6].Style.ForeColor = Color.LimeGreen;
                    }
                    else if (item.Cells[6].Value.ToString() == "Nije dostupno")
                    {
                        item.Cells[6].Style.ForeColor = Color.Red;
                    }
                }
            }
            
        }

        private void buttonDesign(Button btnPodmeni)
        {
            btnPodmeni.BackColor = System.Drawing.Color.FromArgb(203, 214, 216);
            btnPodmeni.FlatAppearance.BorderSize = 0;
            btnPodmeni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnPodmeni.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnPodmeni.ForeColor = System.Drawing.Color.FromArgb(5, 56, 107);
            btnPodmeni.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            btnPodmeni.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            btnPodmeni.TabIndex = 0;
            btnPodmeni.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnPodmeni.UseVisualStyleBackColor = false;
            btnPodmeni.FlatStyle = FlatStyle.Flat;
            btnPodmeni.Width = flpPodmeni.Width - 6;
            btnPodmeni.Height = 55;
            btnPodmeni.MouseEnter += BtnPodmeni_MouseEnter;
            btnPodmeni.MouseLeave += BtnPodmeni_MouseLeave;
        }

        private void BtnPodmeni_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = System.Drawing.Color.FromArgb(203, 214, 216);
            btn.ForeColor = Color.FromArgb(5, 56, 107);
        }

        private void BtnPodmeni_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.FromArgb(5, 56, 107);
            btn.ForeColor = Color.Linen;
        }

        private void crudButtonDesign(MetroTile btn)
        {
            btn.Size = new Size(95, 95);
            btn.UseCustomBackColor = true;
            btn.BackColor = Color.FromArgb(5, 56, 107);
            btn.UseTileImage = true;
            btn.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            btn.TileTextFontSize = MetroTileTextSize.Small;
            if (btn.Text.Contains("DODAJ"))
            {
                if (btn.Name.Contains("Zaposlenog"))
                    btn.TileImage = global::VozniPark.Properties.Resources.icons8_add_user_male_50;
                else if (btn.Name.Contains("Vozilo"))
                    btn.TileImage = global::VozniPark.Properties.Resources.icons8_traffic_jam_50;
                else
                    btn.TileImage = global::VozniPark.Properties.Resources.icons8_add_property_50;

            }
            else if (btn.Text.Contains("OBRISI"))
                btn.TileImage = global::VozniPark.Properties.Resources.icons8_close_window_50;
            else if (btn.Text.Contains("IZMIJENI"))
                btn.TileImage = global::VozniPark.Properties.Resources.icons8_edit_file_50;
            else if (btn.Text.Contains("DETALJNO"))
                btn.TileImage = global::VozniPark.Properties.Resources.icons8_more_filled_50;
            else if (btn.Text.Contains("ZADUZI"))
                btn.TileImage = global::VozniPark.Properties.Resources.icons8_lease_filled_50;
            else if (btn.Text.Contains("PRETRA"))
                btn.TileImage = global::VozniPark.Properties.Resources.icons8_google_web_search_filled_50;
            
        }

        private void detaljnoFormaLoad(MetroForm forma, int x, int y)
        {
            forma.StartPosition = FormStartPosition.CenterScreen;
            for (int i = 0, j = 0; i < x; i += (int)x/10)
            {
                if (forma.Location.X > 340)
                    forma.Location = new Point(1362 - i, 673 - j);

                forma.Size = new Size(i, j);

                if (j < y)
                    j += (int)y/10;
            }

        }
        private void DetaljanPregledZaposlenog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Activate();
        }

        #endregion


    }
}

