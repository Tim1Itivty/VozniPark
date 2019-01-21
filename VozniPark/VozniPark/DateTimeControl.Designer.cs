namespace VozniPark
{
    partial class DateTimeControl
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
            this.lblInput = new MetroFramework.Controls.MetroLabel();
            this.dtValue = new MetroFramework.Controls.MetroDateTime();
            this.SuspendLayout();
            // 
            // lblInput
            // 
            this.lblInput.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblInput.Location = new System.Drawing.Point(3, 4);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(199, 34);
            this.lblInput.TabIndex = 2;
            // 
            // dtValue
            // 
            this.dtValue.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            this.dtValue.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtValue.Location = new System.Drawing.Point(212, 5);
            this.dtValue.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtValue.Name = "dtValue";
            this.dtValue.Size = new System.Drawing.Size(248, 29);
            this.dtValue.TabIndex = 3;
            // 
            // DateTimeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtValue);
            this.Controls.Add(this.lblInput);
            this.Name = "DateTimeControl";
            this.Size = new System.Drawing.Size(546, 41);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblInput;
        private MetroFramework.Controls.MetroDateTime dtValue;
    }
}
