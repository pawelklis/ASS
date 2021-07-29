namespace AutomaticSortingSystem
{
    partial class usOthersets
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numwork = new System.Windows.Forms.NumericUpDown();
            this.numalltacts = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ckturnofftimer = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numparcelfactor = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numtactlenghtcm = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numstopcorection = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.txCamAdres = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.ckautowork = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ckPreview1 = new System.Windows.Forms.CheckBox();
            this.ckpreview2 = new System.Windows.Forms.CheckBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.txCamadres2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.numSTOPTacts = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.ckblack1 = new System.Windows.Forms.CheckBox();
            this.ckBlack2 = new System.Windows.Forms.CheckBox();
            this.numzum1 = new System.Windows.Forms.NumericUpDown();
            this.numzum2 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numwork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numalltacts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numparcelfactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numtactlenghtcm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numstopcorection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSTOPTacts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numzum1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numzum2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Interwał detekcji obrotu taśmy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Liczba markerów taktów";
            // 
            // numwork
            // 
            this.numwork.Location = new System.Drawing.Point(237, 44);
            this.numwork.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numwork.Name = "numwork";
            this.numwork.Size = new System.Drawing.Size(80, 20);
            this.numwork.TabIndex = 2;
            this.numwork.ValueChanged += new System.EventHandler(this.numwork_ValueChanged);
            // 
            // numalltacts
            // 
            this.numalltacts.Location = new System.Drawing.Point(237, 82);
            this.numalltacts.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numalltacts.Name = "numalltacts";
            this.numalltacts.Size = new System.Drawing.Size(80, 20);
            this.numalltacts.TabIndex = 3;
            this.numalltacts.ValueChanged += new System.EventHandler(this.numalltacts_ValueChanged);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(486, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Zapisz";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Gaszenie lamp timerem";
            // 
            // ckturnofftimer
            // 
            this.ckturnofftimer.AutoSize = true;
            this.ckturnofftimer.Location = new System.Drawing.Point(237, 120);
            this.ckturnofftimer.Name = "ckturnofftimer";
            this.ckturnofftimer.Size = new System.Drawing.Size(15, 14);
            this.ckturnofftimer.TabIndex = 6;
            this.ckturnofftimer.UseVisualStyleBackColor = true;
            this.ckturnofftimer.CheckedChanged += new System.EventHandler(this.ckturnofftimer_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Korekcja zajętych markerów";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(237, 154);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(206, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Współczynnik czujnika długości przesyłki";
            // 
            // numparcelfactor
            // 
            this.numparcelfactor.Location = new System.Drawing.Point(237, 188);
            this.numparcelfactor.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numparcelfactor.Name = "numparcelfactor";
            this.numparcelfactor.Size = new System.Drawing.Size(80, 20);
            this.numparcelfactor.TabIndex = 10;
            this.numparcelfactor.ValueChanged += new System.EventHandler(this.numparcelfactor_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 227);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Długość taktu [cm]";
            // 
            // numtactlenghtcm
            // 
            this.numtactlenghtcm.Location = new System.Drawing.Point(237, 225);
            this.numtactlenghtcm.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numtactlenghtcm.Name = "numtactlenghtcm";
            this.numtactlenghtcm.Size = new System.Drawing.Size(80, 20);
            this.numtactlenghtcm.TabIndex = 12;
            this.numtactlenghtcm.ValueChanged += new System.EventHandler(this.numtactlenghtcm_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 264);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Korekcja po zatrzymaniu";
            // 
            // numstopcorection
            // 
            this.numstopcorection.Location = new System.Drawing.Point(237, 262);
            this.numstopcorection.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numstopcorection.Name = "numstopcorection";
            this.numstopcorection.Size = new System.Drawing.Size(80, 20);
            this.numstopcorection.TabIndex = 14;
            this.numstopcorection.ValueChanged += new System.EventHandler(this.numstopcorection_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 303);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Adres kamery 1";
            // 
            // txCamAdres
            // 
            this.txCamAdres.Location = new System.Drawing.Point(178, 300);
            this.txCamAdres.Name = "txCamAdres";
            this.txCamAdres.Size = new System.Drawing.Size(312, 20);
            this.txCamAdres.TabIndex = 16;
            this.txCamAdres.TextChanged += new System.EventHandler(this.txCamAdres_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(509, 297);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(39, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "ON";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ckautowork
            // 
            this.ckautowork.AutoSize = true;
            this.ckautowork.Location = new System.Drawing.Point(302, 404);
            this.ckautowork.Name = "ckautowork";
            this.ckautowork.Size = new System.Drawing.Size(15, 14);
            this.ckautowork.TabIndex = 19;
            this.ckautowork.UseVisualStyleBackColor = true;
            this.ckautowork.CheckedChanged += new System.EventHandler(this.ckautowork_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 405);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(246, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Automatyczne ustawianie interwału detekcji STOP";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(660, 180);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(143, 130);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ckPreview1
            // 
            this.ckPreview1.AutoSize = true;
            this.ckPreview1.Location = new System.Drawing.Point(564, 302);
            this.ckPreview1.Name = "ckPreview1";
            this.ckPreview1.Size = new System.Drawing.Size(15, 14);
            this.ckPreview1.TabIndex = 21;
            this.ckPreview1.UseVisualStyleBackColor = true;
            this.ckPreview1.CheckedChanged += new System.EventHandler(this.ckPreview1_CheckedChanged);
            // 
            // ckpreview2
            // 
            this.ckpreview2.AutoSize = true;
            this.ckpreview2.Location = new System.Drawing.Point(564, 344);
            this.ckpreview2.Name = "ckpreview2";
            this.ckpreview2.Size = new System.Drawing.Size(15, 14);
            this.ckpreview2.TabIndex = 26;
            this.ckpreview2.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(660, 316);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(143, 130);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 25;
            this.pictureBox2.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(509, 339);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(39, 23);
            this.button3.TabIndex = 24;
            this.button3.Text = "ON";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txCamadres2
            // 
            this.txCamadres2.Location = new System.Drawing.Point(178, 342);
            this.txCamadres2.Name = "txCamadres2";
            this.txCamadres2.Size = new System.Drawing.Size(312, 20);
            this.txCamadres2.TabIndex = 23;
            this.txCamadres2.TextChanged += new System.EventHandler(this.txCamadres2_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 345);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Adres kamery 2";
            // 
            // numSTOPTacts
            // 
            this.numSTOPTacts.Location = new System.Drawing.Point(237, 443);
            this.numSTOPTacts.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numSTOPTacts.Name = "numSTOPTacts";
            this.numSTOPTacts.Size = new System.Drawing.Size(80, 20);
            this.numSTOPTacts.TabIndex = 28;
            this.numSTOPTacts.ValueChanged += new System.EventHandler(this.numSTOPTacts_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 445);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Takty czujnika stop";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(613, 344);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 14);
            this.checkBox2.TabIndex = 30;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(613, 302);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(15, 14);
            this.checkBox3.TabIndex = 29;
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // ckblack1
            // 
            this.ckblack1.AutoSize = true;
            this.ckblack1.Location = new System.Drawing.Point(564, 264);
            this.ckblack1.Name = "ckblack1";
            this.ckblack1.Size = new System.Drawing.Size(15, 14);
            this.ckblack1.TabIndex = 31;
            this.ckblack1.UseVisualStyleBackColor = true;
            this.ckblack1.CheckedChanged += new System.EventHandler(this.ckblack1_CheckedChanged);
            // 
            // ckBlack2
            // 
            this.ckBlack2.AutoSize = true;
            this.ckBlack2.Location = new System.Drawing.Point(564, 376);
            this.ckBlack2.Name = "ckBlack2";
            this.ckBlack2.Size = new System.Drawing.Size(15, 14);
            this.ckBlack2.TabIndex = 32;
            this.ckBlack2.UseVisualStyleBackColor = true;
            this.ckBlack2.CheckedChanged += new System.EventHandler(this.ckBlack2_CheckedChanged);
            // 
            // numzum1
            // 
            this.numzum1.Location = new System.Drawing.Point(600, 262);
            this.numzum1.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numzum1.Name = "numzum1";
            this.numzum1.Size = new System.Drawing.Size(42, 20);
            this.numzum1.TabIndex = 33;
            this.numzum1.ValueChanged += new System.EventHandler(this.numzum1_ValueChanged);
            // 
            // numzum2
            // 
            this.numzum2.Location = new System.Drawing.Point(600, 370);
            this.numzum2.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numzum2.Name = "numzum2";
            this.numzum2.Size = new System.Drawing.Size(42, 20);
            this.numzum2.TabIndex = 34;
            this.numzum2.ValueChanged += new System.EventHandler(this.numzum2_ValueChanged);
            // 
            // usOthersets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.numzum2);
            this.Controls.Add(this.numzum1);
            this.Controls.Add(this.ckBlack2);
            this.Controls.Add(this.ckblack1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.numSTOPTacts);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.ckpreview2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txCamadres2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.ckPreview1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ckautowork);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txCamAdres);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numstopcorection);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numtactlenghtcm);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numparcelfactor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ckturnofftimer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numalltacts);
            this.Controls.Add(this.numwork);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "usOthersets";
            this.Size = new System.Drawing.Size(990, 478);
            this.Load += new System.EventHandler(this.usOthersets_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numwork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numalltacts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numparcelfactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numtactlenghtcm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numstopcorection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSTOPTacts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numzum1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numzum2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numwork;
        private System.Windows.Forms.NumericUpDown numalltacts;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckturnofftimer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numparcelfactor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numtactlenghtcm;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numstopcorection;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txCamAdres;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox ckautowork;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox ckPreview1;
        private System.Windows.Forms.CheckBox ckpreview2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txCamadres2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numSTOPTacts;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox ckblack1;
        private System.Windows.Forms.CheckBox ckBlack2;
        private System.Windows.Forms.NumericUpDown numzum1;
        private System.Windows.Forms.NumericUpDown numzum2;
    }
}
