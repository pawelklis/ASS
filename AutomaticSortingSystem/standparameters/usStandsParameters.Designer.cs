﻿namespace AutomaticSortingSystem
{
    partial class usStandsParameters
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
            this.btnSave = new System.Windows.Forms.Button();
            this.cbSelectedStand = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(970, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(756, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(204, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Zapisz ustawienia";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbSelectedStand
            // 
            this.cbSelectedStand.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbSelectedStand.FormattingEnabled = true;
            this.cbSelectedStand.Location = new System.Drawing.Point(0, 25);
            this.cbSelectedStand.Name = "cbSelectedStand";
            this.cbSelectedStand.Size = new System.Drawing.Size(970, 21);
            this.cbSelectedStand.TabIndex = 7;
            this.cbSelectedStand.SelectedIndexChanged += new System.EventHandler(this.cbSelectedStand_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(970, 904);
            this.panel1.TabIndex = 8;
            // 
            // usStandsParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbSelectedStand);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Name = "usStandsParameters";
            this.Size = new System.Drawing.Size(970, 950);
            this.Load += new System.EventHandler(this.usStandsParameters_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbSelectedStand;
        private System.Windows.Forms.Panel panel1;
    }
}