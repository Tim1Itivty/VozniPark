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
    public partial class LookupForm : MetroFramework.Forms.MetroForm
    {
        public PropertyInterface myProperty;
        public string Key;
        public string Value;
        public LookupForm(PropertyInterface mp)
        {
            InitializeComponent();
            myProperty = mp;

            if(mp.GetType() == typeof(PropertyClassZaposleni))
            {
                this.Text = "Zaposleni";
            }
            else if (mp.GetType() == typeof(PropertyClassModel))
            {
                this.Text = "Model";
                btnNoviModel.Visible = true;
              
            }
            else if (mp.GetType() == typeof(PropertyClassVozila))
            {
                this.Text = "Vozila";
            }
            else if (mp.GetType() == typeof(PropertyClassProizvodjac))
            {
                this.Text = "Proizvodjaci";
            }

            PopulateGrid();

            formatiranejGrida();



            lookupGrid.CellDoubleClick += btnReturn_Click;
        }

        private void PopulateGrid()
        {
           
            DataTable dt = new DataTable();
            
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text,
                myProperty.GetLookupQuery());

            dt.Load(reader);
            reader.Close();

            lookupGrid.DataSource = dt;
      
            var type = myProperty.GetType();
            var properties = type.GetProperties();

            foreach (DataGridViewColumn item in lookupGrid.Columns)
            {
                item.HeaderText = properties.Where(x => x.GetCustomAttributes<SqlNameAttribute>().FirstOrDefault().Name == item.HeaderText
                                      ).FirstOrDefault().GetCustomAttributes<DisplayNameAttribute>().FirstOrDefault().DisplayName;
            }

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            btnReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(209)))), ((int)(((byte)(249)))));
            DataGridViewRow row = lookupGrid.SelectedRows[0];
            var properties = myProperty.GetType().GetProperties();

            string columnName = properties.Where(x => x.GetCustomAttribute<LookupKey>() != null)
                .FirstOrDefault().GetCustomAttribute<SqlNameAttribute>().Name;

            Key = row.Cells[columnName].Value.ToString();

            List<string> columnNames = new List<string>();
            foreach(var item in properties)
            {
                if(item.GetCustomAttribute<LookupValue>() != null)
                {
                    columnNames.Add(item.GetCustomAttribute<SqlNameAttribute>().Name);
                }
            }

            foreach(var item in columnNames)
            {
                 Value += row.Cells[item].Value.ToString() + " ";
            }
            
            DialogResult = DialogResult.OK;
        }

        private void btnNoviModel_Click(object sender, EventArgs e)
        {
            DodajModelForm dodajModelF = new DodajModelForm();
            dodajModelF.ShowDialog();
            if (dodajModelF.DialogResult == DialogResult.OK)
            {
                lookupGrid.DataSource = null;
                PopulateGrid();
            }
            formatiranejGrida();
        }


        public void formatiranejGrida()
        {
            for (int i = 0; i < lookupGrid.Columns.Count; i++)
            {
                if (i == 0)
                {
                    lookupGrid.Columns[0].Width = 65;
                }
                else
                    lookupGrid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
        }

        private void btnNoviModel_MouseHover(object sender, EventArgs e)
        {
            btnNoviModel.BackColor = Color.FromArgb(5, 56, 107);
            btnNoviModel.ForeColor = Color.White;
        }

        private void btnNoviModel_MouseLeave(object sender, EventArgs e)
        {
            btnNoviModel.BackColor = Color.White;
            btnNoviModel.ForeColor = Color.FromArgb(5, 56, 107);
        }
    }
}
