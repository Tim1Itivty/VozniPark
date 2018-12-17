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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnVozila = new System.Windows.Forms.Button();
            this.btnZaduzenja = new System.Windows.Forms.Button();
            this.btnZaposleni = new System.Windows.Forms.Button();
            this.btnServis = new System.Windows.Forms.Button();
            this.pnlMeni = new System.Windows.Forms.Panel();
            this.pnlSelected4 = new System.Windows.Forms.Panel();
            this.pnlSelected2 = new System.Windows.Forms.Panel();
            this.pnlSelected3 = new System.Windows.Forms.Panel();
            this.pnlSelected1 = new System.Windows.Forms.Panel();
            this.flpPodmeni = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlDashboard = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlMeni.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVozila
            // 
            this.btnVozila.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(102)))), ((int)(((byte)(141)))));
            this.btnVozila.FlatAppearance.BorderSize = 0;
            this.btnVozila.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVozila.Font = new System.Drawing.Font("Century Gothic", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVozila.ForeColor = System.Drawing.Color.Linen;
            this.btnVozila.Image = ((System.Drawing.Image)(resources.GetObject("btnVozila.Image")));
            this.btnVozila.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVozila.Location = new System.Drawing.Point(0, 0);
            this.btnVozila.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVozila.Name = "btnVozila";
            this.btnVozila.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnVozila.Size = new System.Drawing.Size(202, 54);
            this.btnVozila.TabIndex = 0;
            this.btnVozila.Text = "    Vozila";
            this.btnVozila.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVozila.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVozila.UseVisualStyleBackColor = false;
            this.btnVozila.Click += new System.EventHandler(this.btnVozila_Click);
            // 
            // btnZaduzenja
            // 
            this.btnZaduzenja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(102)))), ((int)(((byte)(141)))));
            this.btnZaduzenja.FlatAppearance.BorderSize = 0;
            this.btnZaduzenja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZaduzenja.Font = new System.Drawing.Font("Century Gothic", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZaduzenja.ForeColor = System.Drawing.Color.Linen;
            this.btnZaduzenja.Image = ((System.Drawing.Image)(resources.GetObject("btnZaduzenja.Image")));
            this.btnZaduzenja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnZaduzenja.Location = new System.Drawing.Point(0, 110);
            this.btnZaduzenja.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnZaduzenja.Name = "btnZaduzenja";
            this.btnZaduzenja.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnZaduzenja.Size = new System.Drawing.Size(202, 54);
            this.btnZaduzenja.TabIndex = 0;
            this.btnZaduzenja.Text = "    Zaduzenja";
            this.btnZaduzenja.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnZaduzenja.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnZaduzenja.UseVisualStyleBackColor = false;
            this.btnZaduzenja.Click += new System.EventHandler(this.btnZaduzenja_Click);
            // 
            // btnZaposleni
            // 
            this.btnZaposleni.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(102)))), ((int)(((byte)(141)))));
            this.btnZaposleni.FlatAppearance.BorderSize = 0;
            this.btnZaposleni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZaposleni.Font = new System.Drawing.Font("Century Gothic", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZaposleni.ForeColor = System.Drawing.Color.Linen;
            this.btnZaposleni.Image = ((System.Drawing.Image)(resources.GetObject("btnZaposleni.Image")));
            this.btnZaposleni.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnZaposleni.Location = new System.Drawing.Point(0, 55);
            this.btnZaposleni.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnZaposleni.Name = "btnZaposleni";
            this.btnZaposleni.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnZaposleni.Size = new System.Drawing.Size(202, 54);
            this.btnZaposleni.TabIndex = 0;
            this.btnZaposleni.Text = "    Zaposleni";
            this.btnZaposleni.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnZaposleni.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnZaposleni.UseVisualStyleBackColor = false;
            this.btnZaposleni.Click += new System.EventHandler(this.btnZaposleni_Click);
            // 
            // btnServis
            // 
            this.btnServis.AutoSize = true;
            this.btnServis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(102)))), ((int)(((byte)(141)))));
            this.btnServis.FlatAppearance.BorderSize = 0;
            this.btnServis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServis.Font = new System.Drawing.Font("Century Gothic", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServis.ForeColor = System.Drawing.Color.Linen;
            this.btnServis.Image = ((System.Drawing.Image)(resources.GetObject("btnServis.Image")));
            this.btnServis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnServis.Location = new System.Drawing.Point(0, 165);
            this.btnServis.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnServis.Name = "btnServis";
            this.btnServis.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnServis.Size = new System.Drawing.Size(202, 54);
            this.btnServis.TabIndex = 0;
            this.btnServis.Text = "    Servis";
            this.btnServis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnServis.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnServis.UseVisualStyleBackColor = false;
            this.btnServis.Click += new System.EventHandler(this.btnServis_Click);
            // 
            // pnlMeni
            // 
            this.pnlMeni.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlMeni.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(102)))), ((int)(((byte)(141)))));
            this.pnlMeni.Controls.Add(this.pnlSelected4);
            this.pnlMeni.Controls.Add(this.pnlSelected2);
            this.pnlMeni.Controls.Add(this.pnlSelected3);
            this.pnlMeni.Controls.Add(this.pnlSelected1);
            this.pnlMeni.Controls.Add(this.btnServis);
            this.pnlMeni.Controls.Add(this.btnZaposleni);
            this.pnlMeni.Controls.Add(this.btnZaduzenja);
            this.pnlMeni.Controls.Add(this.btnVozila);
            this.pnlMeni.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMeni.Location = new System.Drawing.Point(0, 60);
            this.pnlMeni.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlMeni.Name = "pnlMeni";
            this.pnlMeni.Size = new System.Drawing.Size(202, 613);
            this.pnlMeni.TabIndex = 1;
            // 
            // pnlSelected4
            // 
            this.pnlSelected4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(150)))));
            this.pnlSelected4.Location = new System.Drawing.Point(0, 165);
            this.pnlSelected4.Name = "pnlSelected4";
            this.pnlSelected4.Size = new System.Drawing.Size(10, 54);
            this.pnlSelected4.TabIndex = 0;
            // 
            // pnlSelected2
            // 
            this.pnlSelected2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(150)))));
            this.pnlSelected2.Location = new System.Drawing.Point(0, 55);
            this.pnlSelected2.Name = "pnlSelected2";
            this.pnlSelected2.Size = new System.Drawing.Size(10, 54);
            this.pnlSelected2.TabIndex = 0;
            // 
            // pnlSelected3
            // 
            this.pnlSelected3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(150)))));
            this.pnlSelected3.Location = new System.Drawing.Point(0, 110);
            this.pnlSelected3.Name = "pnlSelected3";
            this.pnlSelected3.Size = new System.Drawing.Size(10, 54);
            this.pnlSelected3.TabIndex = 0;
            // 
            // pnlSelected1
            // 
            this.pnlSelected1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(150)))));
            this.pnlSelected1.Location = new System.Drawing.Point(0, 0);
            this.pnlSelected1.Name = "pnlSelected1";
            this.pnlSelected1.Size = new System.Drawing.Size(10, 54);
            this.pnlSelected1.TabIndex = 0;
            // 
            // flpPodmeni
            // 
            this.flpPodmeni.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpPodmeni.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(128)))), ((int)(((byte)(144)))));
            this.flpPodmeni.Dock = System.Windows.Forms.DockStyle.Left;
            this.flpPodmeni.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpPodmeni.Location = new System.Drawing.Point(202, 60);
            this.flpPodmeni.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flpPodmeni.Name = "flpPodmeni";
            this.flpPodmeni.Size = new System.Drawing.Size(233, 613);
            this.flpPodmeni.TabIndex = 5;
            // 
            // pnlDashboard
            // 
            this.pnlDashboard.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDashboard.Location = new System.Drawing.Point(435, 60);
            this.pnlDashboard.Name = "pnlDashboard";
            this.pnlDashboard.Size = new System.Drawing.Size(813, 613);
            this.pnlDashboard.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 673);
            this.Controls.Add(this.pnlDashboard);
            this.Controls.Add(this.flpPodmeni);
            this.Controls.Add(this.pnlMeni);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(0, 60, 21, 0);
            this.Text = "Vozni park";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.pnlMeni.ResumeLayout(false);
            this.pnlMeni.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnVozila;
        private System.Windows.Forms.Button btnZaduzenja;
        private System.Windows.Forms.Button btnZaposleni;
        private System.Windows.Forms.Button btnServis;
        private System.Windows.Forms.Panel pnlMeni;
        private System.Windows.Forms.FlowLayoutPanel flpPodmeni;
        private System.Windows.Forms.Panel pnlDashboard;
        private System.Windows.Forms.Panel pnlSelected1;
        private System.Windows.Forms.Panel pnlSelected4;
        private System.Windows.Forms.Panel pnlSelected2;
        private System.Windows.Forms.Panel pnlSelected3;
        private System.Windows.Forms.FlowLayoutPanel pnlDashboard;
    }
}

