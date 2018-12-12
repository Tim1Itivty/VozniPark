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
            this.pnlMeni = new System.Windows.Forms.Panel();
            this.btnServis = new System.Windows.Forms.Button();
            this.btnZaposleni = new System.Windows.Forms.Button();
            this.btnZaduzenja = new System.Windows.Forms.Button();
            this.pnlWorkspace = new System.Windows.Forms.Panel();
            this.btnQuit = new System.Windows.Forms.Button();
            this.flpPodmeni = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlMeni.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVozila
            // 
            this.btnVozila.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnVozila.FlatAppearance.BorderSize = 0;
            this.btnVozila.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVozila.Font = new System.Drawing.Font("Raavi", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVozila.Location = new System.Drawing.Point(-1, -1);
            this.btnVozila.Name = "btnVozila";
            this.btnVozila.Size = new System.Drawing.Size(227, 46);
            this.btnVozila.TabIndex = 0;
            this.btnVozila.Text = "Vozila";
            this.btnVozila.UseVisualStyleBackColor = false;
            // 
            // pnlMeni
            // 
            this.pnlMeni.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlMeni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMeni.Controls.Add(this.btnServis);
            this.pnlMeni.Controls.Add(this.btnZaposleni);
            this.pnlMeni.Controls.Add(this.btnZaduzenja);
            this.pnlMeni.Controls.Add(this.btnVozila);
            this.pnlMeni.Location = new System.Drawing.Point(12, 52);
            this.pnlMeni.Name = "pnlMeni";
            this.pnlMeni.Size = new System.Drawing.Size(227, 399);
            this.pnlMeni.TabIndex = 1;
            // 
            // btnServis
            // 
            this.btnServis.AutoSize = true;
            this.btnServis.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnServis.FlatAppearance.BorderSize = 0;
            this.btnServis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServis.Font = new System.Drawing.Font("Raavi", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServis.Location = new System.Drawing.Point(-1, 137);
            this.btnServis.Name = "btnServis";
            this.btnServis.Size = new System.Drawing.Size(227, 46);
            this.btnServis.TabIndex = 0;
            this.btnServis.Text = "Servis";
            this.btnServis.UseVisualStyleBackColor = false;
            // 
            // btnZaposleni
            // 
            this.btnZaposleni.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnZaposleni.FlatAppearance.BorderSize = 0;
            this.btnZaposleni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZaposleni.Font = new System.Drawing.Font("Raavi", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZaposleni.Location = new System.Drawing.Point(-1, 45);
            this.btnZaposleni.Name = "btnZaposleni";
            this.btnZaposleni.Size = new System.Drawing.Size(227, 46);
            this.btnZaposleni.TabIndex = 0;
            this.btnZaposleni.Text = "Zaposleni";
            this.btnZaposleni.UseVisualStyleBackColor = false;
            // 
            // btnZaduzenja
            // 
            this.btnZaduzenja.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnZaduzenja.FlatAppearance.BorderSize = 0;
            this.btnZaduzenja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZaduzenja.Font = new System.Drawing.Font("Raavi", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZaduzenja.Location = new System.Drawing.Point(-1, 91);
            this.btnZaduzenja.Name = "btnZaduzenja";
            this.btnZaduzenja.Size = new System.Drawing.Size(227, 46);
            this.btnZaduzenja.TabIndex = 0;
            this.btnZaduzenja.Text = "Zaduzenja";
            this.btnZaduzenja.UseVisualStyleBackColor = false;
            // 
            // pnlWorkspace
            // 
            this.pnlWorkspace.Location = new System.Drawing.Point(435, 52);
            this.pnlWorkspace.Name = "pnlWorkspace";
            this.pnlWorkspace.Size = new System.Drawing.Size(605, 399);
            this.pnlWorkspace.TabIndex = 3;
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(912, 563);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 4;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // flpPodmeni
            // 
            this.flpPodmeni.Location = new System.Drawing.Point(245, 51);
            this.flpPodmeni.Name = "flpPodmeni";
            this.flpPodmeni.Size = new System.Drawing.Size(184, 400);
            this.flpPodmeni.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 627);
            this.Controls.Add(this.flpPodmeni);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.pnlWorkspace);
            this.Controls.Add(this.pnlMeni);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.pnlMeni.ResumeLayout(false);
            this.pnlMeni.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVozila;
        private System.Windows.Forms.Panel pnlMeni;
        private System.Windows.Forms.Button btnServis;
        private System.Windows.Forms.Button btnZaposleni;
        private System.Windows.Forms.Button btnZaduzenja;
        private System.Windows.Forms.Panel pnlWorkspace;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.FlowLayoutPanel flpPodmeni;
    }
}

