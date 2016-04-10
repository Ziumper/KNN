namespace KNN
{
    partial class Wyswietlacz
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
            this.rtbZawartosc = new System.Windows.Forms.RichTextBox();
            this.lblOpis = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtbZawartosc
            // 
            this.rtbZawartosc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbZawartosc.Location = new System.Drawing.Point(12, 27);
            this.rtbZawartosc.Name = "rtbZawartosc";
            this.rtbZawartosc.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.rtbZawartosc.Size = new System.Drawing.Size(494, 175);
            this.rtbZawartosc.TabIndex = 0;
            this.rtbZawartosc.Text = "";
            // 
            // lblOpis
            // 
            this.lblOpis.AutoSize = true;
            this.lblOpis.Location = new System.Drawing.Point(9, 9);
            this.lblOpis.Name = "lblOpis";
            this.lblOpis.Size = new System.Drawing.Size(35, 13);
            this.lblOpis.TabIndex = 1;
            this.lblOpis.Text = "label1";
            // 
            // Wyswietlacz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 214);
            this.Controls.Add(this.lblOpis);
            this.Controls.Add(this.rtbZawartosc);
            this.MinimumSize = new System.Drawing.Size(534, 252);
            this.Name = "Wyswietlacz";
            this.Text = "Wyswietlacz";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbZawartosc;
        private System.Windows.Forms.Label lblOpis;
    }
}