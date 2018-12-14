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

namespace VozniPark
{
    public partial class LookupForm : Form
    {
        public PropertyInterface myProperty;
        public string Key;
        public string Value;
        public LookupForm(PropertyInterface mp)
        {
            InitializeComponent();
            myProperty = mp;
            PopulateGrid();
        }

        private void PopulateGrid()
        {
           
            DataTable dt = new DataTable();

            
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text,
                myProperty.GetSelectQuery());

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
            DataGridViewRow row = lookupGrid.SelectedRows[0];
            var properties = myProperty.GetType().GetProperties();

            string columnName = properties.Where(x => x.GetCustomAttribute<LookupKey>() != null)
                .FirstOrDefault().GetCustomAttribute<SqlNameAttribute>().Name;

            Key = row.Cells[columnName].Value.ToString();

            columnName = properties.Where(x => x.GetCustomAttribute<LookupValue>() != null)
                .FirstOrDefault().GetCustomAttribute<SqlNameAttribute>().Name;

            Value = row.Cells[columnName].Value.ToString();

            this.Close();
        }
    }
}
