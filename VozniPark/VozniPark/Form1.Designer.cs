namespace VozniPark
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnVozila = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnZaduzenja = new System.Windows.Forms.Button();
            this.btnZaposleni = new System.Windows.Forms.Button();
            this.btnServis = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnQuit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVozila
            // 
            this.btnVozila.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnVozila.FlatAppearance.BorderSize = 0;
            this.btnVozila.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVozila.Location = new System.Drawing.Point(-1, -1);
            this.btnVozila.Name = "btnVozila";
            this.btnVozila.Size = new System.Drawing.Size(187, 46);
            this.btnVozila.TabIndex = 0;
            this.btnVozila.Text = "Vozila";
            this.btnVozila.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnServis);
            this.panel1.Controls.Add(this.btnZaposleni);
            this.panel1.Controls.Add(this.btnZaduzenja);
            this.panel1.Controls.Add(this.btnVozila);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(187, 356);
            this.panel1.TabIndex = 1;
            // 
            // btnZaduzenja
            // 
            this.btnZaduzenja.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnZaduzenja.FlatAppearance.BorderSize = 0;
            this.btnZaduzenja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZaduzenja.Location = new System.Drawing.Point(-1, 91);
            this.btnZaduzenja.Name = "btnZaduzenja";
            this.btnZaduzenja.Size = new System.Drawing.Size(187, 46);
            this.btnZaduzenja.TabIndex = 0;
            this.btnZaduzenja.Text = "Zaduzenja";
            this.btnZaduzenja.UseVisualStyleBackColor = false;
            // 
            // btnZaposleni
            // 
            this.btnZaposleni.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnZaposleni.FlatAppearance.BorderSize = 0;
            this.btnZaposleni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZaposleni.Location = new System.Drawing.Point(-1, 45);
            this.btnZaposleni.Name = "btnZaposleni";
            this.btnZaposleni.Size = new System.Drawing.Size(187, 46);
            this.btnZaposleni.TabIndex = 0;
            this.btnZaposleni.Text = "Zaposleni";
            this.btnZaposleni.UseVisualStyleBackColor = false;
            // 
            // btnServis
            // 
            this.btnServis.AutoSize = true;
            this.btnServis.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnServis.FlatAppearance.BorderSize = 0;
            this.btnServis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServis.Location = new System.Drawing.Point(-1, 137);
            this.btnServis.Name = "btnServis";
            this.btnServis.Size = new System.Drawing.Size(187, 46);
            this.btnServis.TabIndex = 0;
            this.btnServis.Text = "Servis";
            this.btnServis.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(219, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(153, 355);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(379, 13);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(608, 355);
            this.panel3.TabIndex = 3;
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(896, 455);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 4;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 501);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVozila;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnServis;
        private System.Windows.Forms.Button btnZaposleni;
        private System.Windows.Forms.Button btnZaduzenja;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnQuit;
    }
}

