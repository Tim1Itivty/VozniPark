namespace VozniPark
{
    partial class DodajModelForm
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
            this.flpModel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpModel
            // 
            this.flpModel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpModel.Location = new System.Drawing.Point(23, 62);
            this.flpModel.Name = "flpModel";
            this.flpModel.Size = new System.Drawing.Size(544, 142);
            this.flpModel.TabIndex = 0;
            // 
            // DodajModelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 227);
            this.Controls.Add(this.flpModel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DodajModelForm";
            this.Resizable = false;
            this.Text = "Dodaj model";
            this.Load += new System.EventHandler(this.DodajModelForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpModel;
    }
}