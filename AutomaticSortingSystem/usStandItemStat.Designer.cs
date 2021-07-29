namespace AutomaticSortingSystem
{
    partial class usStandItemStat
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
            this.prSorted = new System.Windows.Forms.ProgressBar();
            this.lbDirection = new System.Windows.Forms.Label();
            this.lbSorted = new System.Windows.Forms.Label();
            this.lbMissed = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // prSorted
            // 
            this.prSorted.ForeColor = System.Drawing.Color.Green;
            this.prSorted.Location = new System.Drawing.Point(111, 4);
            this.prSorted.Name = "prSorted";
            this.prSorted.Size = new System.Drawing.Size(60, 10);
            this.prSorted.TabIndex = 0;
            // 
            // lbDirection
            // 
            this.lbDirection.AutoSize = true;
            this.lbDirection.Location = new System.Drawing.Point(4, 4);
            this.lbDirection.Name = "lbDirection";
            this.lbDirection.Size = new System.Drawing.Size(35, 13);
            this.lbDirection.TabIndex = 2;
            this.lbDirection.Text = "label1";
            // 
            // lbSorted
            // 
            this.lbSorted.AutoSize = true;
            this.lbSorted.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbSorted.Location = new System.Drawing.Point(74, 4);
            this.lbSorted.Name = "lbSorted";
            this.lbSorted.Size = new System.Drawing.Size(35, 13);
            this.lbSorted.TabIndex = 5;
            this.lbSorted.Text = "9999";
            // 
            // lbMissed
            // 
            this.lbMissed.AutoSize = true;
            this.lbMissed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbMissed.ForeColor = System.Drawing.Color.DarkRed;
            this.lbMissed.Location = new System.Drawing.Point(177, 4);
            this.lbMissed.Name = "lbMissed";
            this.lbMissed.Size = new System.Drawing.Size(35, 13);
            this.lbMissed.TabIndex = 6;
            this.lbMissed.Text = "9999";
            // 
            // usStandItemStat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lbMissed);
            this.Controls.Add(this.lbSorted);
            this.Controls.Add(this.lbDirection);
            this.Controls.Add(this.prSorted);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "usStandItemStat";
            this.Size = new System.Drawing.Size(215, 20);
            this.Load += new System.EventHandler(this.usStandItemStat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar prSorted;
        private System.Windows.Forms.Label lbDirection;
        private System.Windows.Forms.Label lbSorted;
        private System.Windows.Forms.Label lbMissed;
    }
}
