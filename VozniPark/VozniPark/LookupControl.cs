using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VozniPark
{
    public partial class LookupControl : UserControl
    {
        PropertyInterface myInterface;
        public string Key;
        public string Value;

        public LookupControl(PropertyInterface property)
        {
            InitializeComponent();
            myInterface = property;
        }
        public void setLabel(string text)
        {
            lblLookup.Text = text;
        }

        private void btnLookup_Click(object sender, EventArgs e)
        {
            LookupForm lookupForm = new LookupForm(myInterface);

            lookupForm.ShowDialog();

            Key = lookupForm.Key;
            Value = lookupForm.Value;
            txtLookupID.Text = Key.ToString();
            txtLookupNaziv.Text = Value.ToString();
        }
    }
}
