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
            this.cBMetryka.Items.AddRange(new object[] {
            "Euklidesa",
            "Canbera",
            "Czebyszewa",
            "Manhattan",
            "Bez. współ. korel. Pearsona"});
            this.cBMetryka.Location = new System.Drawing.Point(6, 35);
            this.cBMetryka.Name = "cBMetryka";
            this.cBMetryka.Size = new System.Drawing.Size(150, 21);
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
            this.btnWczytaj.Location = new System.Drawing.Point(72, 114);
            this.btnWczytaj.Name = "btnWczytaj";
            this.btnWczytaj.Size = new System.Drawing.Size(75, 23);
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
            this.gBDane.Location = new System.Drawing.Point(12, 12);
            this.gBDane.Name = "gBDane";
            this.gBDane.Size = new System.Drawing.Size(248, 144);
            this.gBDane.TabIndex = 1;
            this.gBDane.TabStop = false;
            this.gBDane.Text = "Dane";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnTST);
            this.groupBox2.Location = new System.Drawing.Point(125, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(107, 89);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "System Testowy";
            // 
            // btnTST
            // 
            this.btnTST.Location = new System.Drawing.Point(18, 36);
            this.btnTST.Name = "btnTST";
            this.btnTST.Size = new System.Drawing.Size(75, 23);
            this.btnTST.TabIndex = 0;
            this.btnTST.Text = "Pokaż TST";
            this.btnTST.UseVisualStyleBackColor = true;
            this.btnTST.Click += new System.EventHandler(this.btnTST_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTRN);
            this.groupBox1.Location = new System.Drawing.Point(6, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(121, 89);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "System Treningowy";
            // 
            // btnTRN
            // 
            this.btnTRN.Location = new System.Drawing.Point(18, 36);
            this.btnTRN.Name = "btnTRN";
            this.btnTRN.Size = new System.Drawing.Size(75, 23);
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
            this.gBUstawienia.Location = new System.Drawing.Point(266, 12);
            this.gBUstawienia.Name = "gBUstawienia";
            this.gBUstawienia.Size = new System.Drawing.Size(169, 144);
            this.gBUstawienia.TabIndex = 2;
            this.gBUstawienia.TabStop = false;
            this.gBUstawienia.Text = "Ustawienia";
            // 
            // cBKnn
            // 
            this.cBKnn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBKnn.FormattingEnabled = true;
            this.cBKnn.Location = new System.Drawing.Point(6, 79);
            this.cBKnn.Name = "cBKnn";
            this.cBKnn.Size = new System.Drawing.Size(150, 21);
            this.cBKnn.TabIndex = 3;
            this.cBKnn.SelectedIndexChanged += new System.EventHandler(this.cBKnn_SelectedIndexChanged);
            // 
            // lblKnn
            // 
            this.lblKnn.AutoSize = true;
            this.lblKnn.Location = new System.Drawing.Point(6, 63);
            this.lblKnn.Name = "lblKnn";
            this.lblKnn.Size = new System.Drawing.Size(32, 13);
            this.lblKnn.TabIndex = 2;
            this.lblKnn.Text = "k-NN";
            // 
            // lblMetryka
            // 
            this.lblMetryka.AutoSize = true;
            this.lblMetryka.Location = new System.Drawing.Point(6, 19);
            this.lblMetryka.Name = "lblMetryka";
            this.lblMetryka.Size = new System.Drawing.Size(45, 13);
            this.lblMetryka.TabIndex = 0;
            this.lblMetryka.Text = "Metryka";
            // 
            // gBWyniki
            // 
            this.gBWyniki.Controls.Add(this.btnWyniki);
            this.gBWyniki.Location = new System.Drawing.Point(442, 13);
            this.gBWyniki.Name = "gBWyniki";
            this.gBWyniki.Size = new System.Drawing.Size(115, 143);
            this.gBWyniki.TabIndex = 3;
            this.gBWyniki.TabStop = false;
            this.gBWyniki.Text = "Wyniki";
            // 
            // btnWyniki
            // 
            this.btnWyniki.Location = new System.Drawing.Point(21, 31);
            this.btnWyniki.Name = "btnWyniki";
            this.btnWyniki.Size = new System.Drawing.Size(75, 44);
            this.btnWyniki.TabIndex = 0;
            this.btnWyniki.Text = "Pokaz wyniki";
            this.btnWyniki.UseVisualStyleBackColor = true;
            this.btnWyniki.Click += new System.EventHandler(this.btnWyniki_Click);
            // 
            // KNNForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 173);
            this.Controls.Add(this.gBWyniki);
            this.Controls.Add(this.gBUstawienia);
            this.Controls.Add(this.gBDane);
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

