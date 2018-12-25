using System.Drawing;
using System.Windows.Forms;

namespace VozniPark
{
    partial class LookupForm
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
            this.lookupGrid = new System.Windows.Forms.DataGridView();
            this.btnReturn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.lookupGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // lookupGrid
            // 
            this.lookupGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lookupGrid.Location = new System.Drawing.Point(13, 54);
            this.lookupGrid.Name = "lookupGrid";
            this.lookupGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.lookupGrid.Size = new System.Drawing.Size(338, 260);
            this.lookupGrid.TabIndex = 0;
            this.lookupGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lookupGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            this.lookupGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.lookupGrid.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            this.lookupGrid.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            this.lookupGrid.BackgroundColor = Color.White;
            this.lookupGrid.EnableHeadersVisualStyles = false;
            this.lookupGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.lookupGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            this.lookupGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.lookupGrid.AllowUserToAddRows = false;
            this.lookupGrid.AllowUserToResizeColumns = false;
            this.lookupGrid.AllowUserToResizeRows = false;
            this.lookupGrid.ReadOnly = true;
            this.lookupGrid.ColumnHeadersHeight = 45;
            this.lookupGrid.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
            this.lookupGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.lookupGrid.CellBorderStyle = DataGridViewCellBorderStyle.None;
            this.lookupGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.lookupGrid.BackgroundColor = Color.White;
            this.lookupGrid.RowHeadersVisible = false;
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(132, 330);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 23);
            this.btnReturn.TabIndex = 1;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // LookupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 391);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.lookupGrid);
            this.Name = "LookupForm";
            this.Text = "LookupForm";
            ((System.ComponentModel.ISupportInitialize)(this.lookupGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView lookupGrid;
        private System.Windows.Forms.Button btnReturn;
    }
}