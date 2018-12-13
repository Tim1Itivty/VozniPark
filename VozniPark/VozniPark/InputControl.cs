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
    public partial class InputControl : UserControl
    {
        
        public string Naziv
        {
            get { return lblInput.Text; }
            set { lblInput.Text = value; }
        }

        public string UnosPolje
        {
            get { return txtInput.Text; }
            set { txtInput.Text = value; }
        }

        public InputControl()
        {
            InitializeComponent();
        }

        public InputControl(string InputLabel, string InputTextBox)
        {
            InitializeComponent();
            Naziv = InputLabel;
            UnosPolje = InputTextBox;
        }

        
    }
}
