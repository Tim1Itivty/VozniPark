using System;
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
using MetroFramework.Forms;
using MetroFramework;
using System.Text.RegularExpressions;

namespace VozniPark
{
    public partial class DodajModelForm : MetroForm
    {
        public PropertyInterface myProperty;
        bool poljaIspravnoPopunjena=false;

        public DodajModelForm()
        {
            InitializeComponent();
            myProperty = new PropertyClassModel();
            PopulateControls();

            Button btnDodajModel = new Button();
            btnDodajModel.Text = "DODAJ";
            btnDodajModel.Name = "btnDodajModel";
            btnDodajModel.Visible = true;
            btnDodajModel.FlatStyle = FlatStyle.Flat;
            btnDodajModel.BackColor = Color.FromArgb(23, 165, 232);
            btnDodajModel.ForeColor = Color.White;
            btnDodajModel.Size = new Size(120, 34);
            btnDodajModel.Margin = new Padding(135, 10, 3, 3);

            flpModel.Controls.Add(btnDodajModel);

            btnDodajModel.Click += BtnDodajModel_Click;
        }

        private void BtnDodajModel_Click(object sender, EventArgs e)
        {
          
           poljaIspravnoPopunjena= Add(poljaIspravnoPopunjena);


            if (poljaIspravnoPopunjena == false)
            {
                DialogResult = DialogResult.OK;
                CustomMessageBox dodanModel = new CustomMessageBox("Dodan novi model", "Dodan je novi model vozila!", MessageBoxIcon.Information);
            }
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

        public bool Add(bool poljaIspravnoPopunjena)
        {
            var properties = myProperty.GetType().GetProperties();
            bool nepravlinoIspunjenoPolje = false;
            string poruka = "";


            foreach (var item in flpModel.Controls)
            {
                if (item.GetType() == typeof(LookupControl))
                {
                    LookupControl input = item as LookupControl;
                    string value = input.Key;

                    if (value == "" || value == null)
                    {
                        nepravlinoIspunjenoPolje = true;
                        if (poruka == "")
                            poruka += "Morate popuniti sva polja.\n";
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


                    if (value == "" || value == null)
                    {
                        nepravlinoIspunjenoPolje = true;
                        if (poruka == "")
                            poruka += "Morate popuniti sva polja.\n";
                    }
                    else if (input.Naziv == "Naziv" && Regex.IsMatch(value, @"[0-9@#%&',.\s-+$]") )
                    {
                        nepravlinoIspunjenoPolje = true;
                        poruka += input.Naziv + " ne smije sadrzavati brojeve i specijalne karaktere .\n";
                    }
                    else
                    {
                        PropertyInfo property = properties.Where(x => input.Naziv == x.GetCustomAttribute<DisplayNameAttribute>().DisplayName).FirstOrDefault();
                        property.SetValue(myProperty, Convert.ChangeType(value, property.PropertyType));
                    }
                }
            }
                if (nepravlinoIspunjenoPolje == true)
                {
                    CustomMessageBox mb = new CustomMessageBox("Greska", poruka, MessageBoxIcon.Error);
                    poljaIspravnoPopunjena = true;
                return poljaIspravnoPopunjena;
                }
                else
                {

                    SqlHelper.ExecuteNonQuery(SqlHelper.GetConnectionString(), CommandType.Text,
                      myProperty.GetInsertQuery(), myProperty.GetInsertParameters().ToArray());

                    poljaIspravnoPopunjena = false;
                return poljaIspravnoPopunjena;
                }




            
        }

        private void DodajModelForm_Load(object sender, EventArgs e)
        {

        }
    }
    
}
