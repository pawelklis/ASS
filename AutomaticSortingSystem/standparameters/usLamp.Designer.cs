namespace AutomaticSortingSystem
{
    partial class usLamp
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
            this.numToLampOn = new System.Windows.Forms.NumericUpDown();
            this.numToLampIoff = new System.Windows.Forms.NumericUpDown();
            this.btnLampColor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.numblinklenght = new System.Windows.Forms.NumericUpDown();
            this.numblinkinterval = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numToLampOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToLampIoff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numblinklenght)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numblinkinterval)).BeginInit();
            this.SuspendLayout();
            // 
            // numToLampOn
            // 
            this.numToLampOn.Location = new System.Drawing.Point(95, 20);
            this.numToLampOn.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numToLampOn.Name = "numToLampOn";
            this.numToLampOn.Size = new System.Drawing.Size(54, 20);
            this.numToLampOn.TabIndex = 0;
            this.numToLampOn.ValueChanged += new System.EventHandler(this.numToLampOn_ValueChanged);
            // 
            // numToLampIoff
            // 
            this.numToLampIoff.Location = new System.Drawing.Point(95, 46);
            this.numToLampIoff.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numToLampIoff.Name = "numToLampIoff";
            this.numToLampIoff.Size = new System.Drawing.Size(54, 20);
            this.numToLampIoff.TabIndex = 1;
            this.numToLampIoff.ValueChanged += new System.EventHandler(this.numToLampIoff_ValueChanged);
            // 
            // btnLampColor
            // 
            this.btnLampColor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnLampColor.Location = new System.Drawing.Point(165, 20);
            this.btnLampColor.Name = "btnLampColor";
            this.btnLampColor.Size = new System.Drawing.Size(40, 40);
            this.btnLampColor.TabIndex = 2;
            this.btnLampColor.UseVisualStyleBackColor = false;
            this.btnLampColor.Click += new System.EventHandler(this.btnLampColor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Takty włączenia";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Takty wyłączenia";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "label3";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(4, 90);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(66, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Pulsacja";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // numblinklenght
            // 
            this.numblinklenght.Location = new System.Drawing.Point(79, 87);
            this.numblinklenght.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numblinklenght.Name = "numblinklenght";
            this.numblinklenght.Size = new System.Drawing.Size(60, 20);
            this.numblinklenght.TabIndex = 7;
            this.numblinklenght.ValueChanged += new System.EventHandler(this.numblinklenght_ValueChanged);
            // 
            // numblinkinterval
            // 
            this.numblinkinterval.Location = new System.Drawing.Point(158, 87);
            this.numblinkinterval.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numblinkinterval.Name = "numblinkinterval";
            this.numblinkinterval.Size = new System.Drawing.Size(60, 20);
            this.numblinkinterval.TabIndex = 8;
            this.numblinkinterval.ValueChanged += new System.EventHandler(this.numblinkinterval_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(76, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Długość[ms]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(155, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Interwał[ms]";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(155, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 60);
            this.button1.TabIndex = 11;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(51, -1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(19, 21);
            this.button2.TabIndex = 12;
            this.button2.Text = "1";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(76, -1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(19, 21);
            this.button3.TabIndex = 13;
            this.button3.Text = "0";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // usLamp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numblinkinterval);
            this.Controls.Add(this.numblinklenght);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLampColor);
            this.Controls.Add(this.numToLampIoff);
            this.Controls.Add(this.numToLampOn);
            this.Controls.Add(this.button1);
            this.Name = "usLamp";
            this.Size = new System.Drawing.Size(223, 196);
            this.Load += new System.EventHandler(this.usLamp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numToLampOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToLampIoff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numblinklenght)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numblinkinterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numToLampOn;
        private System.Windows.Forms.NumericUpDown numToLampIoff;
        private System.Windows.Forms.Button btnLampColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NumericUpDown numblinklenght;
        private System.Windows.Forms.NumericUpDown numblinkinterval;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}
