using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VozniPark
{
    public partial class CustomMessageBox : Form
    {
        Color bojaDugmeta;
        public CustomMessageBox(string headline, string message, MessageBoxIcon icon)
        {
            InitializeComponent();
            if(icon == MessageBoxIcon.Error)
            {
                this.BackgroundImage = global::VozniPark.Properties.Resources.error_background;
                bojaDugmeta = Color.DarkRed;
            }
            if(icon == MessageBoxIcon.Information)
            {
                this.BackgroundImage = global::VozniPark.Properties.Resources.info_background;
                bojaDugmeta = Color.CornflowerBlue;
            }
            if(icon == MessageBoxIcon.Exclamation)
            {
                this.BackgroundImage = global::VozniPark.Properties.Resources.success_background;
                bojaDugmeta = Color.DarkGreen;
            }
            lblHeadline.Text = headline;
            lblMessage.Text = message;
            this.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.DarkRed;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.Transparent;
        }

        private void btnOK_MouseEnter(object sender, EventArgs e)
        {
            btnOK.BackColor = bojaDugmeta;
        }

        private void btnOK_MouseLeave(object sender, EventArgs e)
        {
            btnOK.BackColor = Color.Transparent;
        }
    }
}
