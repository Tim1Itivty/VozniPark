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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lookupGrid = new System.Windows.Forms.DataGridView();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnNoviModel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.lookupGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // lookupGrid
            // 
            this.lookupGrid.AllowUserToAddRows = false;
            this.lookupGrid.AllowUserToResizeColumns = false;
            this.lookupGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(239)))), ((int)(((byte)(249)))));
            this.lookupGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.lookupGrid.BackgroundColor = System.Drawing.Color.White;
            this.lookupGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lookupGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.lookupGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lookupGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.lookupGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.lookupGrid.DefaultCellStyle = dataGridViewCellStyle6;
            this.lookupGrid.EnableHeadersVisualStyles = false;
            this.lookupGrid.Location = new System.Drawing.Point(13, 59);
            this.lookupGrid.MultiSelect = false;
            this.lookupGrid.Name = "lookupGrid";
            this.lookupGrid.ReadOnly = true;
            this.lookupGrid.RowHeadersVisible = false;
            this.lookupGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.lookupGrid.Size = new System.Drawing.Size(457, 260);
            this.lookupGrid.TabIndex = 0;
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(165)))), ((int)(((byte)(232)))));
            this.btnReturn.FlatAppearance.BorderSize = 0;
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReturn.Location = new System.Drawing.Point(181, 336);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(120, 34);
            this.btnReturn.TabIndex = 1;
            this.btnReturn.Text = "OK";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnNoviModel
            // 
            this.btnNoviModel.BackColor = System.Drawing.Color.White;
            this.btnNoviModel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(165)))), ((int)(((byte)(232)))));
            this.btnNoviModel.FlatAppearance.BorderSize = 2;
            this.btnNoviModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNoviModel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNoviModel.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnNoviModel.Location = new System.Drawing.Point(330, 336);
            this.btnNoviModel.Name = "btnNoviModel";
            this.btnNoviModel.Size = new System.Drawing.Size(120, 34);
            this.btnNoviModel.TabIndex = 2;
            this.btnNoviModel.Text = "Novi model";
            this.btnNoviModel.UseVisualStyleBackColor = false;
            this.btnNoviModel.Visible = false;
            this.btnNoviModel.Click += new System.EventHandler(this.btnNoviModel_Click);
            this.btnNoviModel.MouseLeave += new System.EventHandler(this.btnNoviModel_MouseLeave);
            this.btnNoviModel.MouseHover += new System.EventHandler(this.btnNoviModel_MouseHover);
            // 
            // LookupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 391);
            this.Controls.Add(this.btnNoviModel);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.lookupGrid);
            this.Name = "LookupForm";
            ((System.ComponentModel.ISupportInitialize)(this.lookupGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView lookupGrid;
        private System.Windows.Forms.Button btnReturn;
        private Button btnNoviModel;
    }
}