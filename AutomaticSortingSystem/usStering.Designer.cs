namespace AutomaticSortingSystem
{
    partial class usStering
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelIsWorking = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbLastTact = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbSuposedTact = new System.Windows.Forms.Label();
            this.lbtacttime = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lbworkdetect = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(26, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(246, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "Uruchom maszynę";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelIsWorking
            // 
            this.labelIsWorking.AutoSize = true;
            this.labelIsWorking.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelIsWorking.Location = new System.Drawing.Point(125, 80);
            this.labelIsWorking.Name = "labelIsWorking";
            this.labelIsWorking.Size = new System.Drawing.Size(51, 20);
            this.labelIsWorking.TabIndex = 1;
            this.labelIsWorking.Text = "STOP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Status (PRACA/STOP)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(3, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ostatni takt:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(3, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Spodziewany takt:";
            // 
            // lbLastTact
            // 
            this.lbLastTact.AutoSize = true;
            this.lbLastTact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbLastTact.Location = new System.Drawing.Point(138, 100);
            this.lbLastTact.Name = "lbLastTact";
            this.lbLastTact.Size = new System.Drawing.Size(18, 20);
            this.lbLastTact.TabIndex = 5;
            this.lbLastTact.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(3, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Czas taktu";
            // 
            // lbSuposedTact
            // 
            this.lbSuposedTact.AutoSize = true;
            this.lbSuposedTact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbSuposedTact.Location = new System.Drawing.Point(138, 139);
            this.lbSuposedTact.Name = "lbSuposedTact";
            this.lbSuposedTact.Size = new System.Drawing.Size(18, 20);
            this.lbSuposedTact.TabIndex = 6;
            this.lbSuposedTact.Text = "0";
            // 
            // lbtacttime
            // 
            this.lbtacttime.AutoSize = true;
            this.lbtacttime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbtacttime.Location = new System.Drawing.Point(94, 181);
            this.lbtacttime.Name = "lbtacttime";
            this.lbtacttime.Size = new System.Drawing.Size(18, 20);
            this.lbtacttime.TabIndex = 8;
            this.lbtacttime.Text = "0";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(23, 327);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Włącz lampy";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(23, 356);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(134, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Wyłącz lampy";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(14, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Czas wykrycia STOP";
            // 
            // lbworkdetect
            // 
            this.lbworkdetect.AutoSize = true;
            this.lbworkdetect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbworkdetect.Location = new System.Drawing.Point(19, 291);
            this.lbworkdetect.Name = "lbworkdetect";
            this.lbworkdetect.Size = new System.Drawing.Size(18, 20);
            this.lbworkdetect.TabIndex = 12;
            this.lbworkdetect.Text = "0";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(197, 327);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 52);
            this.button4.TabIndex = 13;
            this.button4.Text = "Zeruj takty";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // usStering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.button4);
            this.Controls.Add(this.lbworkdetect);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lbtacttime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbSuposedTact);
            this.Controls.Add(this.lbLastTact);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelIsWorking);
            this.Controls.Add(this.button1);
            this.Name = "usStering";
            this.Size = new System.Drawing.Size(470, 420);
            this.Load += new System.EventHandler(this.usStering_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelIsWorking;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbLastTact;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbSuposedTact;
        private System.Windows.Forms.Label lbtacttime;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbworkdetect;
        private System.Windows.Forms.Button button4;
    }
}
