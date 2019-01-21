namespace VozniPark
{
    partial class InputControl
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
            this.txtInput = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // lblInput
            // 
            this.lblInput.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblInput.Location = new System.Drawing.Point(3, 9);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(175, 32);
            this.lblInput.TabIndex = 0;
            // 
            // txtInput
            // 
            // 
            // 
            // 
            this.txtInput.CustomButton.Image = null;
            this.txtInput.CustomButton.Location = new System.Drawing.Point(226, 1);
            this.txtInput.CustomButton.Name = "";
            this.txtInput.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtInput.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtInput.CustomButton.TabIndex = 1;
            this.txtInput.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtInput.CustomButton.UseSelectable = true;
            this.txtInput.CustomButton.Visible = false;
            this.txtInput.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtInput.Lines = new string[0];
            this.txtInput.Location = new System.Drawing.Point(212, 14);
            this.txtInput.MaxLength = 32767;
            this.txtInput.Name = "txtInput";
            this.txtInput.PasswordChar = '\0';
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtInput.SelectedText = "";
            this.txtInput.SelectionLength = 0;
            this.txtInput.SelectionStart = 0;
            this.txtInput.ShortcutsEnabled = true;
            this.txtInput.Size = new System.Drawing.Size(249, 23);
            this.txtInput.TabIndex = 1;
            this.txtInput.UseSelectable = true;
            this.txtInput.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtInput.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // InputControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.lblInput);
            this.Name = "InputControl";
            this.Size = new System.Drawing.Size(502, 49);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblInput;
        private MetroFramework.Controls.MetroTextBox txtInput;
    }
}
