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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lookupGrid = new System.Windows.Forms.DataGridView();
            this.btnReturn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.lookupGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // lookupGrid
            // 
            this.lookupGrid.AllowUserToAddRows = false;
            this.lookupGrid.AllowUserToResizeColumns = false;
            this.lookupGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(239)))), ((int)(((byte)(249)))));
            this.lookupGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.lookupGrid.BackgroundColor = System.Drawing.Color.White;
            this.lookupGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lookupGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.lookupGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lookupGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.lookupGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.lookupGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.lookupGrid.EnableHeadersVisualStyles = false;
            this.lookupGrid.Location = new System.Drawing.Point(13, 13);
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
            this.lookupGrid.RowHeadersVisible = false;
            this.lookupGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.lookupGrid.Size = new System.Drawing.Size(457, 260);
            this.lookupGrid.TabIndex = 0;
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
            this.ClientSize = new System.Drawing.Size(482, 391);
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