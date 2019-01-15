﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VozniPark.PropertiesClass;
using VozniPark.AttributesClass;

namespace VozniPark
{
    public partial class DodajModelForm : Form
    {
        public PropertyInterface myProperty;

        public DodajModelForm()
        {
            InitializeComponent();
            myProperty = new PropertyClassModel();
            PopulateControls();

            Button btnDodajModel = new Button();
            btnDodajModel.Text = "DODAJ";
            btnDodajModel.Name = "btnDodajModel";
            btnDodajModel.Visible = true;

            flpModel.Controls.Add(btnDodajModel);

            btnDodajModel.Click += BtnDodajModel_Click;
        }

        private void BtnDodajModel_Click(object sender, EventArgs e)
        {
            Add();
            DialogResult = DialogResult.OK;
            MessageBox.Show("Dodan je novi model vozila!");
        }

        public void PopulateControls()
        {
            foreach (PropertyInfo item in myProperty.GetType().GetProperties())
            {
                if (item.GetCustomAttribute<ForeignKeyAttribute>() != null)
                {
                    PropertyClassProizvodjac foreignInterface = Assembly.GetExecutingAssembly().
                        CreateInstance(item.GetCustomAttribute<ForeignKeyAttribute>().referencedClass) as PropertyClassProizvodjac;

                    LookupControl lookup = new LookupControl(foreignInterface);
                    lookup.Name = item.Name;
                    lookup.setLabel(item.GetCustomAttribute<DisplayNameAttribute>().DisplayName);

                    flpModel.Controls.Add(lookup);
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

                    flpModel.Controls.Add(ic);
                }               
            }
        }

        public void Add()
        {
            var properties = myProperty.GetType().GetProperties();

            foreach (var item in flpModel.Controls)
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

                    PropertyInfo property = properties.Where(x => input.Naziv == x.GetCustomAttribute<DisplayNameAttribute>().DisplayName).FirstOrDefault();
                    property.SetValue(myProperty, Convert.ChangeType(value, property.PropertyType));

                    SqlHelper.ExecuteNonQuery(SqlHelper.GetConnectionString(), CommandType.Text,
                      myProperty.GetInsertQuery(), myProperty.GetInsertParameters().ToArray());
                }
            }
        }
    }
}
