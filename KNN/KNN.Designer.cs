namespace KNN
{
    partial class KNNForm
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
            this.cBMetryka = new System.Windows.Forms.ComboBox();
            this.ofdSystemTestowy = new System.Windows.Forms.OpenFileDialog();
            this.ofdSystemTreningowy = new System.Windows.Forms.OpenFileDialog();
            this.btnWczytaj = new System.Windows.Forms.Button();
            this.gBDane = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnTST = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTRN = new System.Windows.Forms.Button();
            this.gBUstawienia = new System.Windows.Forms.GroupBox();
            this.cBKnn = new System.Windows.Forms.ComboBox();
            this.lblKnn = new System.Windows.Forms.Label();
            this.lblMetryka = new System.Windows.Forms.Label();
            this.gBWyniki = new System.Windows.Forms.GroupBox();
            this.btnWyniki = new System.Windows.Forms.Button();
            this.gBDane.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gBUstawienia.SuspendLayout();
            this.gBWyniki.SuspendLayout();
            this.SuspendLayout();
            // 
            // cBMetryka
            // 
            this.cBMetryka.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBMetryka.FormattingEnabled = true;
            this.cBMetryka.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cBMetryka.Location = new System.Drawing.Point(8, 43);
            this.cBMetryka.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cBMetryka.Name = "cBMetryka";
            this.cBMetryka.Size = new System.Drawing.Size(199, 24);
            this.cBMetryka.TabIndex = 1;
            this.cBMetryka.SelectedIndexChanged += new System.EventHandler(this.cBMetryka_SelectedIndexChanged);
            // 
            // ofdSystemTestowy
            // 
            this.ofdSystemTestowy.FileName = "SystemTestowy";
            // 
            // ofdSystemTreningowy
            // 
            this.ofdSystemTreningowy.FileName = "Treningowy";
            // 
            // btnWczytaj
            // 
            this.btnWczytaj.Location = new System.Drawing.Point(96, 140);
            this.btnWczytaj.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnWczytaj.Name = "btnWczytaj";
            this.btnWczytaj.Size = new System.Drawing.Size(100, 28);
            this.btnWczytaj.TabIndex = 0;
            this.btnWczytaj.Text = "Wczytaj";
            this.btnWczytaj.UseVisualStyleBackColor = true;
            this.btnWczytaj.Click += new System.EventHandler(this.btnWczytaj_Click);
            // 
            // gBDane
            // 
            this.gBDane.Controls.Add(this.groupBox2);
            this.gBDane.Controls.Add(this.groupBox1);
            this.gBDane.Controls.Add(this.btnWczytaj);
            this.gBDane.Location = new System.Drawing.Point(16, 15);
            this.gBDane.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gBDane.Name = "gBDane";
            this.gBDane.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gBDane.Size = new System.Drawing.Size(331, 177);
            this.gBDane.TabIndex = 1;
            this.gBDane.TabStop = false;
            this.gBDane.Text = "Dane";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnTST);
            this.groupBox2.Location = new System.Drawing.Point(167, 23);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(143, 110);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "System Testowy";
            // 
            // btnTST
            // 
            this.btnTST.Location = new System.Drawing.Point(24, 44);
            this.btnTST.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTST.Name = "btnTST";
            this.btnTST.Size = new System.Drawing.Size(100, 28);
            this.btnTST.TabIndex = 0;
            this.btnTST.Text = "Pokaż TST";
            this.btnTST.UseVisualStyleBackColor = true;
            this.btnTST.Click += new System.EventHandler(this.btnTST_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTRN);
            this.groupBox1.Location = new System.Drawing.Point(8, 23);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(161, 110);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "System Treningowy";
            // 
            // btnTRN
            // 
            this.btnTRN.Location = new System.Drawing.Point(24, 44);
            this.btnTRN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTRN.Name = "btnTRN";
            this.btnTRN.Size = new System.Drawing.Size(100, 28);
            this.btnTRN.TabIndex = 0;
            this.btnTRN.Text = "Pokaz TRN";
            this.btnTRN.UseVisualStyleBackColor = true;
            this.btnTRN.Click += new System.EventHandler(this.btnTRN_Click);
            // 
            // gBUstawienia
            // 
            this.gBUstawienia.Controls.Add(this.cBKnn);
            this.gBUstawienia.Controls.Add(this.lblKnn);
            this.gBUstawienia.Controls.Add(this.cBMetryka);
            this.gBUstawienia.Controls.Add(this.lblMetryka);
            this.gBUstawienia.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.gBUstawienia.Location = new System.Drawing.Point(355, 15);
            this.gBUstawienia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gBUstawienia.Name = "gBUstawienia";
            this.gBUstawienia.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gBUstawienia.Size = new System.Drawing.Size(225, 177);
            this.gBUstawienia.TabIndex = 2;
            this.gBUstawienia.TabStop = false;
            this.gBUstawienia.Text = "Ustawienia";
            // 
            // cBKnn
            // 
            this.cBKnn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBKnn.FormattingEnabled = true;
            this.cBKnn.Location = new System.Drawing.Point(8, 97);
            this.cBKnn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cBKnn.Name = "cBKnn";
            this.cBKnn.Size = new System.Drawing.Size(199, 24);
            this.cBKnn.TabIndex = 3;
            this.cBKnn.SelectedIndexChanged += new System.EventHandler(this.cBKnn_SelectedIndexChanged);
            // 
            // lblKnn
            // 
            this.lblKnn.AutoSize = true;
            this.lblKnn.Location = new System.Drawing.Point(8, 78);
            this.lblKnn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKnn.Name = "lblKnn";
            this.lblKnn.Size = new System.Drawing.Size(40, 17);
            this.lblKnn.TabIndex = 2;
            this.lblKnn.Text = "k-NN";
            // 
            // lblMetryka
            // 
            this.lblMetryka.AutoSize = true;
            this.lblMetryka.Location = new System.Drawing.Point(8, 23);
            this.lblMetryka.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMetryka.Name = "lblMetryka";
            this.lblMetryka.Size = new System.Drawing.Size(58, 17);
            this.lblMetryka.TabIndex = 0;
            this.lblMetryka.Text = "Metryka";
            // 
            // gBWyniki
            // 
            this.gBWyniki.Controls.Add(this.btnWyniki);
            this.gBWyniki.Location = new System.Drawing.Point(589, 16);
            this.gBWyniki.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gBWyniki.Name = "gBWyniki";
            this.gBWyniki.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gBWyniki.Size = new System.Drawing.Size(153, 176);
            this.gBWyniki.TabIndex = 3;
            this.gBWyniki.TabStop = false;
            this.gBWyniki.Text = "Wyniki";
            // 
            // btnWyniki
            // 
            this.btnWyniki.Location = new System.Drawing.Point(28, 38);
            this.btnWyniki.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnWyniki.Name = "btnWyniki";
            this.btnWyniki.Size = new System.Drawing.Size(100, 54);
            this.btnWyniki.TabIndex = 0;
            this.btnWyniki.Text = "Pokaz wyniki";
            this.btnWyniki.UseVisualStyleBackColor = true;
            this.btnWyniki.Click += new System.EventHandler(this.btnWyniki_Click);
            // 
            // KNNForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 213);
            this.Controls.Add(this.gBWyniki);
            this.Controls.Add(this.gBUstawienia);
            this.Controls.Add(this.gBDane);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "KNNForm";
            this.Text = "KNN Tomasz Komoszeski";
            this.gBDane.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.gBUstawienia.ResumeLayout(false);
            this.gBUstawienia.PerformLayout();
            this.gBWyniki.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdSystemTestowy;
        private System.Windows.Forms.OpenFileDialog ofdSystemTreningowy;
        private System.Windows.Forms.Button btnWczytaj;
        private System.Windows.Forms.GroupBox gBDane;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnTST;
        private System.Windows.Forms.Button btnTRN;
        private System.Windows.Forms.GroupBox gBUstawienia;
        private System.Windows.Forms.GroupBox gBWyniki;
        private System.Windows.Forms.Label lblMetryka;
        private System.Windows.Forms.ComboBox cBKnn;
        private System.Windows.Forms.Label lblKnn;
        private System.Windows.Forms.Button btnWyniki;
        private System.Windows.Forms.ComboBox cBMetryka;
    }
}

