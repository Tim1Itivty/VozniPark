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
    public partial class DateTimeControl : UserControl
    {
        public string Naziv
        {
            get { return lblInput.Text; }
            set { lblInput.Text = value; }
        }

        public DateTime Unos
        {
            get { return dtValue.Value; }
            set { dtValue.Value = value; }
        }
        public DateTimeControl()
        {
            InitializeComponent();
        }

        public DateTimeControl(string Naziv, DateTime Unos)
        {
            InitializeComponent();
            this.Naziv = Naziv;
            this.Unos = Unos;
        }
    }
}
