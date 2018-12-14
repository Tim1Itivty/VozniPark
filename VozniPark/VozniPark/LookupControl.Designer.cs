namespace VozniPark
{
    partial class LookupControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblLookup = new MetroFramework.Controls.MetroLabel();
            this.txtLookupID = new MetroFramework.Controls.MetroTextBox();
            this.btnLookup = new MetroFramework.Controls.MetroButton();
            this.txtLookupNaziv = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // lblLookup
            // 
            this.lblLookup.Location = new System.Drawing.Point(4, 4);
            this.lblLookup.Name = "lblLookup";
            this.lblLookup.Size = new System.Drawing.Size(109, 23);
            this.lblLookup.TabIndex = 0;
            // 
            // txtLookupID
            // 
            // 
            // 
            // 
            this.txtLookupID.CustomButton.Image = null;
            this.txtLookupID.CustomButton.Location = new System.Drawing.Point(19, 1);
            this.txtLookupID.CustomButton.Name = "";
            this.txtLookupID.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtLookupID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtLookupID.CustomButton.TabIndex = 1;
            this.txtLookupID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtLookupID.CustomButton.UseSelectable = true;
            this.txtLookupID.CustomButton.Visible = false;
            this.txtLookupID.Lines = new string[0];
            this.txtLookupID.Location = new System.Drawing.Point(119, 4);
            this.txtLookupID.MaxLength = 32767;
            this.txtLookupID.Name = "txtLookupID";
            this.txtLookupID.PasswordChar = '\0';
            this.txtLookupID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtLookupID.SelectedText = "";
            this.txtLookupID.SelectionLength = 0;
            this.txtLookupID.SelectionStart = 0;
            this.txtLookupID.ShortcutsEnabled = true;
            this.txtLookupID.Size = new System.Drawing.Size(41, 23);
            this.txtLookupID.TabIndex = 1;
            this.txtLookupID.UseSelectable = true;
            this.txtLookupID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtLookupID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnLookup
            // 
            this.btnLookup.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnLookup.Location = new System.Drawing.Point(167, 4);
            this.btnLookup.Name = "btnLookup";
            this.btnLookup.Size = new System.Drawing.Size(33, 23);
            this.btnLookup.TabIndex = 2;
            this.btnLookup.Text = "...";
            this.btnLookup.UseSelectable = true;
            this.btnLookup.Click += new System.EventHandler(this.btnLookup_Click);
            // 
            // txtLookupNaziv
            // 
            // 
            // 
            // 
            this.txtLookupNaziv.CustomButton.Image = null;
            this.txtLookupNaziv.CustomButton.Location = new System.Drawing.Point(153, 1);
            this.txtLookupNaziv.CustomButton.Name = "";
            this.txtLookupNaziv.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtLookupNaziv.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtLookupNaziv.CustomButton.TabIndex = 1;
            this.txtLookupNaziv.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtLookupNaziv.CustomButton.UseSelectable = true;
            this.txtLookupNaziv.CustomButton.Visible = false;
            this.txtLookupNaziv.Lines = new string[0];
            this.txtLookupNaziv.Location = new System.Drawing.Point(206, 4);
            this.txtLookupNaziv.MaxLength = 32767;
            this.txtLookupNaziv.Name = "txtLookupNaziv";
            this.txtLookupNaziv.PasswordChar = '\0';
            this.txtLookupNaziv.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtLookupNaziv.SelectedText = "";
            this.txtLookupNaziv.SelectionLength = 0;
            this.txtLookupNaziv.SelectionStart = 0;
            this.txtLookupNaziv.ShortcutsEnabled = true;
            this.txtLookupNaziv.Size = new System.Drawing.Size(175, 23);
            this.txtLookupNaziv.TabIndex = 3;
            this.txtLookupNaziv.UseSelectable = true;
            this.txtLookupNaziv.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtLookupNaziv.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // LookupControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtLookupNaziv);
            this.Controls.Add(this.btnLookup);
            this.Controls.Add(this.txtLookupID);
            this.Controls.Add(this.lblLookup);
            this.Name = "LookupControl";
            this.Size = new System.Drawing.Size(386, 33);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblLookup;
        private MetroFramework.Controls.MetroTextBox txtLookupID;
        private MetroFramework.Controls.MetroButton btnLookup;
        private MetroFramework.Controls.MetroTextBox txtLookupNaziv;
    }
}
