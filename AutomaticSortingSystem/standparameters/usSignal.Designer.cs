namespace AutomaticSortingSystem
{
    partial class usSignal
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
            this.txPrefix = new System.Windows.Forms.TextBox();
            this.txContent = new System.Windows.Forms.TextBox();
            this.txSufix = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txPrefix
            // 
            this.txPrefix.Location = new System.Drawing.Point(0, 19);
            this.txPrefix.Name = "txPrefix";
            this.txPrefix.Size = new System.Drawing.Size(67, 20);
            this.txPrefix.TabIndex = 0;
            this.txPrefix.TextChanged += new System.EventHandler(this.txPrefix_TextChanged);
            // 
            // txContent
            // 
            this.txContent.Location = new System.Drawing.Point(73, 19);
            this.txContent.Name = "txContent";
            this.txContent.Size = new System.Drawing.Size(67, 20);
            this.txContent.TabIndex = 1;
            this.txContent.TextChanged += new System.EventHandler(this.txContent_TextChanged);
            // 
            // txSufix
            // 
            this.txSufix.Location = new System.Drawing.Point(146, 19);
            this.txSufix.Name = "txSufix";
            this.txSufix.Size = new System.Drawing.Size(67, 20);
            this.txSufix.TabIndex = 2;
            this.txSufix.TextChanged += new System.EventHandler(this.txSufix_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Prefix";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sygnał";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(143, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Sufix";
            // 
            // usSignal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txSufix);
            this.Controls.Add(this.txContent);
            this.Controls.Add(this.txPrefix);
            this.Name = "usSignal";
            this.Size = new System.Drawing.Size(215, 43);
            this.Load += new System.EventHandler(this.usSignal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txPrefix;
        private System.Windows.Forms.TextBox txContent;
        private System.Windows.Forms.TextBox txSufix;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
