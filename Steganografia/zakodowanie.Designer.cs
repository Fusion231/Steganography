namespace Steganografia
{
    partial class zakodowanie
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
            this.wybierz = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.podglad = new System.Windows.Forms.PictureBox();
            this.sciezka = new System.Windows.Forms.TextBox();
            this.ukrytyZdjecie = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.wybierzukryty = new System.Windows.Forms.Button();
            this.wykonaj = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.rodzajwyjscie = new System.Windows.Forms.Label();
            this.rodzajwejscie = new System.Windows.Forms.Label();
            this.wyjscie = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.Label();
            this.pozakodowaniu = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.procenty = new System.Windows.Forms.Label();
            this.rozmiar = new System.Windows.Forms.Label();
            this.nazwawav = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.aktywnyChild = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.error = new System.Windows.Forms.Label();
            this.play = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.podglad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ukrytyZdjecie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pozakodowaniu)).BeginInit();
            this.aktywnyChild.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.play)).BeginInit();
            this.SuspendLayout();
            // 
            // wybierz
            // 
            this.wybierz.Location = new System.Drawing.Point(12, 224);
            this.wybierz.Name = "wybierz";
            this.wybierz.Size = new System.Drawing.Size(90, 20);
            this.wybierz.TabIndex = 0;
            this.wybierz.Text = "Wybierz obraz";
            this.wybierz.UseVisualStyleBackColor = true;
            this.wybierz.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // podglad
            // 
            this.podglad.Location = new System.Drawing.Point(64, 24);
            this.podglad.Name = "podglad";
            this.podglad.Size = new System.Drawing.Size(188, 167);
            this.podglad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.podglad.TabIndex = 1;
            this.podglad.TabStop = false;
            // 
            // sciezka
            // 
            this.sciezka.Location = new System.Drawing.Point(108, 224);
            this.sciezka.Name = "sciezka";
            this.sciezka.Size = new System.Drawing.Size(144, 20);
            this.sciezka.TabIndex = 2;
            // 
            // ukrytyZdjecie
            // 
            this.ukrytyZdjecie.Location = new System.Drawing.Point(582, 24);
            this.ukrytyZdjecie.Name = "ukrytyZdjecie";
            this.ukrytyZdjecie.Size = new System.Drawing.Size(188, 167);
            this.ukrytyZdjecie.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ukrytyZdjecie.TabIndex = 3;
            this.ukrytyZdjecie.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(626, 224);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(144, 20);
            this.textBox1.TabIndex = 5;
            // 
            // wybierzukryty
            // 
            this.wybierzukryty.Location = new System.Drawing.Point(530, 224);
            this.wybierzukryty.Name = "wybierzukryty";
            this.wybierzukryty.Size = new System.Drawing.Size(90, 20);
            this.wybierzukryty.TabIndex = 4;
            this.wybierzukryty.Text = "Wybierz plik";
            this.wybierzukryty.UseVisualStyleBackColor = true;
            this.wybierzukryty.Click += new System.EventHandler(this.wybierzukryty_Click);
            // 
            // wykonaj
            // 
            this.wykonaj.Location = new System.Drawing.Point(336, 376);
            this.wykonaj.Name = "wykonaj";
            this.wykonaj.Size = new System.Drawing.Size(159, 64);
            this.wykonaj.TabIndex = 6;
            this.wykonaj.Text = "Zakoduj";
            this.wykonaj.UseVisualStyleBackColor = true;
            this.wykonaj.Click += new System.EventHandler(this.wykonaj_Click);
            // 
            // rodzajwyjscie
            // 
            this.rodzajwyjscie.AutoSize = true;
            this.rodzajwyjscie.Location = new System.Drawing.Point(623, 247);
            this.rodzajwyjscie.Name = "rodzajwyjscie";
            this.rodzajwyjscie.Size = new System.Drawing.Size(68, 13);
            this.rodzajwyjscie.TabIndex = 8;
            this.rodzajwyjscie.Text = "Rodzaj pliku:";
            // 
            // rodzajwejscie
            // 
            this.rodzajwejscie.AutoSize = true;
            this.rodzajwejscie.Location = new System.Drawing.Point(105, 247);
            this.rodzajwejscie.Name = "rodzajwejscie";
            this.rodzajwejscie.Size = new System.Drawing.Size(68, 13);
            this.rodzajwejscie.TabIndex = 9;
            this.rodzajwejscie.Text = "Rodzaj pliku:";
            // 
            // wyjscie
            // 
            this.wyjscie.Location = new System.Drawing.Point(12, 431);
            this.wyjscie.Name = "wyjscie";
            this.wyjscie.Size = new System.Drawing.Size(98, 37);
            this.wyjscie.TabIndex = 10;
            this.wyjscie.Text = "Wyjscie";
            this.wyjscie.UseVisualStyleBackColor = true;
            this.wyjscie.Click += new System.EventHandler(this.wyjscie_Click);
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(105, 269);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(65, 13);
            this.status.TabIndex = 11;
            this.status.Text = "Status pliku:";
            // 
            // pozakodowaniu
            // 
            this.pozakodowaniu.Location = new System.Drawing.Point(282, 24);
            this.pozakodowaniu.Name = "pozakodowaniu";
            this.pozakodowaniu.Size = new System.Drawing.Size(188, 167);
            this.pozakodowaniu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pozakodowaniu.TabIndex = 12;
            this.pozakodowaniu.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(333, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Po zakodowaniu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 291);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Pojemność nośnika:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(410, 269);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Ilosc bitów:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(356, 302);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "R:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(435, 302);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "G:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(510, 302);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "B:";
            // 
            // comboBox1
            // 
            this.comboBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.comboBox1.Location = new System.Drawing.Point(380, 299);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(42, 21);
            this.comboBox1.TabIndex = 19;
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox2_SelectedValueChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.comboBox2.Location = new System.Drawing.Point(459, 299);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(42, 21);
            this.comboBox2.TabIndex = 20;
            this.comboBox2.SelectedValueChanged += new System.EventHandler(this.comboBox2_SelectedValueChanged);
            // 
            // comboBox3
            // 
            this.comboBox3.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.comboBox3.Location = new System.Drawing.Point(530, 299);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(42, 21);
            this.comboBox3.TabIndex = 21;
            this.comboBox3.SelectedValueChanged += new System.EventHandler(this.comboBox2_SelectedValueChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(108, 307);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(127, 21);
            this.progressBar1.TabIndex = 22;
            // 
            // procenty
            // 
            this.procenty.AutoSize = true;
            this.procenty.Location = new System.Drawing.Point(208, 291);
            this.procenty.Name = "procenty";
            this.procenty.Size = new System.Drawing.Size(21, 13);
            this.procenty.TabIndex = 23;
            this.procenty.Text = "0%";
            // 
            // rozmiar
            // 
            this.rozmiar.AutoSize = true;
            this.rozmiar.Location = new System.Drawing.Point(113, 355);
            this.rozmiar.Name = "rozmiar";
            this.rozmiar.Size = new System.Drawing.Size(29, 13);
            this.rozmiar.TabIndex = 24;
            this.rozmiar.Text = "0 kB";
            this.rozmiar.Click += new System.EventHandler(this.rozmiar_Click);
            // 
            // nazwawav
            // 
            this.nazwawav.AutoSize = true;
            this.nazwawav.Location = new System.Drawing.Point(105, 123);
            this.nazwawav.Name = "nazwawav";
            this.nazwawav.Size = new System.Drawing.Size(68, 13);
            this.nazwawav.TabIndex = 26;
            this.nazwawav.Text = "Rodzaj pliku:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(356, 307);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Na sample:";
            // 
            // comboBox4
            // 
            this.comboBox4.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(422, 302);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(42, 21);
            this.comboBox4.TabIndex = 28;
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedValueChanged);
            // 
            // aktywnyChild
            // 
            this.aktywnyChild.Controls.Add(this.label10);
            this.aktywnyChild.Controls.Add(this.label9);
            this.aktywnyChild.Controls.Add(this.comboBox4);
            this.aktywnyChild.Controls.Add(this.label8);
            this.aktywnyChild.Controls.Add(this.label7);
            this.aktywnyChild.Controls.Add(this.error);
            this.aktywnyChild.Controls.Add(this.label4);
            this.aktywnyChild.Controls.Add(this.label5);
            this.aktywnyChild.Controls.Add(this.wyjscie);
            this.aktywnyChild.Controls.Add(this.wykonaj);
            this.aktywnyChild.Controls.Add(this.rozmiar);
            this.aktywnyChild.Controls.Add(this.ukrytyZdjecie);
            this.aktywnyChild.Controls.Add(this.comboBox3);
            this.aktywnyChild.Controls.Add(this.textBox1);
            this.aktywnyChild.Controls.Add(this.comboBox2);
            this.aktywnyChild.Controls.Add(this.wybierzukryty);
            this.aktywnyChild.Controls.Add(this.comboBox1);
            this.aktywnyChild.Controls.Add(this.rodzajwyjscie);
            this.aktywnyChild.Controls.Add(this.label6);
            this.aktywnyChild.Controls.Add(this.label3);
            this.aktywnyChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aktywnyChild.Location = new System.Drawing.Point(0, 0);
            this.aktywnyChild.Name = "aktywnyChild";
            this.aktywnyChild.Size = new System.Drawing.Size(863, 493);
            this.aktywnyChild.TabIndex = 31;
            this.aktywnyChild.Paint += new System.Windows.Forms.PaintEventHandler(this.aktywnyChild_Paint);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(113, 331);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(141, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Wolne / Wykorzystane (kB):";
            // 
            // error
            // 
            this.error.AutoSize = true;
            this.error.Location = new System.Drawing.Point(333, 443);
            this.error.Name = "error";
            this.error.Size = new System.Drawing.Size(65, 13);
            this.error.TabIndex = 32;
            this.error.Text = "Status pliku:";
            // 
            // play
            // 
            this.play.Cursor = System.Windows.Forms.Cursors.Hand;
            this.play.Location = new System.Drawing.Point(12, 90);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(78, 78);
            this.play.TabIndex = 25;
            this.play.TabStop = false;
            this.play.Click += new System.EventHandler(this.play_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(113, 376);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Całkowita pojemnosc (kB):";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(113, 402);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 34;
            this.label10.Text = "0 kB";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // zakodowanie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 493);
            this.Controls.Add(this.nazwawav);
            this.Controls.Add(this.play);
            this.Controls.Add(this.procenty);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pozakodowaniu);
            this.Controls.Add(this.status);
            this.Controls.Add(this.rodzajwejscie);
            this.Controls.Add(this.sciezka);
            this.Controls.Add(this.podglad);
            this.Controls.Add(this.wybierz);
            this.Controls.Add(this.aktywnyChild);
            this.Name = "zakodowanie";
            this.Text = "obraz";
            this.Load += new System.EventHandler(this.zakodowanie_Load);
            ((System.ComponentModel.ISupportInitialize)(this.podglad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ukrytyZdjecie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pozakodowaniu)).EndInit();
            this.aktywnyChild.ResumeLayout(false);
            this.aktywnyChild.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.play)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button wybierz;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox podglad;
        private System.Windows.Forms.TextBox sciezka;
        private System.Windows.Forms.PictureBox ukrytyZdjecie;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button wybierzukryty;
        private System.Windows.Forms.Button wykonaj;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label rodzajwyjscie;
        private System.Windows.Forms.Label rodzajwejscie;
        private System.Windows.Forms.Button wyjscie;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.PictureBox pozakodowaniu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label procenty;
        private System.Windows.Forms.Label rozmiar;
        private System.Windows.Forms.Label nazwawav;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Panel aktywnyChild;
        private System.Windows.Forms.PictureBox play;
        private System.Windows.Forms.Label error;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
    }
}