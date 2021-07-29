namespace AutomaticSortingSystem.devices
{
    partial class usdevice
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.numspeed = new System.Windows.Forms.NumericUpDown();
            this.numDelay = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.portstatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numspeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(528, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // numspeed
            // 
            this.numspeed.Location = new System.Drawing.Point(3, 63);
            this.numspeed.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numspeed.Name = "numspeed";
            this.numspeed.Size = new System.Drawing.Size(120, 20);
            this.numspeed.TabIndex = 3;
            this.numspeed.ValueChanged += new System.EventHandler(this.numspeed_ValueChanged);
            // 
            // numDelay
            // 
            this.numDelay.Location = new System.Drawing.Point(129, 63);
            this.numDelay.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numDelay.Name = "numDelay";
            this.numDelay.Size = new System.Drawing.Size(120, 20);
            this.numDelay.TabIndex = 4;
            this.numDelay.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Prędkość portu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(126, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Opóźnienie odczytu";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(35, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(496, 20);
            this.textBox1.TabIndex = 7;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // portstatus
            // 
            this.portstatus.AutoSize = true;
            this.portstatus.Location = new System.Drawing.Point(450, 63);
            this.portstatus.Name = "portstatus";
            this.portstatus.Size = new System.Drawing.Size(73, 13);
            this.portstatus.TabIndex = 8;
            this.portstatus.Text = "Disconnected";
            // 
            // usdevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.portstatus);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numDelay);
            this.Controls.Add(this.numspeed);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Name = "usdevice";
            this.Size = new System.Drawing.Size(537, 91);
            this.Load += new System.EventHandler(this.usdevice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numspeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.NumericUpDown numspeed;
        private System.Windows.Forms.NumericUpDown numDelay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label portstatus;
    }
}
