using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ASS;

namespace AutomaticSortingSystem
{
    public partial class usVizaulization : UserControl
    {
        public CarouselType carousel { get; set; }
        public usVizaulization()
        {
            InitializeComponent();
        }

        private void usVizaulization_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.AutoScroll = true;
            panel1.Width = this.Width - panel1.Left;

            int zakr = carousel.Dicts.AllTactsCount / 50;

            int linia1 = 0;
            int linia2 = 0;

            int lastleft = 0;

            int liczbalinii = (carousel.Dicts.AllTactsCount) / 2-zakr ;
            linia1 = liczbalinii;
            linia2 = carousel.Dicts.AllTactsCount - linia1 - zakr*2 ;

                int top = 10;
                int left = 20;

            for (int i = 0; i < linia1- zakr * 2; i++)
            {
                Button btn = new Button();
                btn.Name = i.ToString();
                btn.Top = top;
                btn.Left = left;
                btn.Width = panel1.Width / linia1/2;
                btn.Height = panel1.Width / linia1/2+5;
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = Color.Red;


                panel1.Controls.Add(btn);

                left += panel1.Width / linia1/2 + 2;
                lastleft = left;
            }

            top = 130;
            left = 20;

            for (int i = 0; i < linia2- zakr * 2; i++)
            {
                Button btn = new Button();
                btn.Name ="2"+ i.ToString();
                btn.Top = top;
                btn.Left = left;
                btn.Width = panel1.Width / linia1 / 2;
                btn.Height = panel1.Width / linia1 / 2+5;
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = Color.Red;


                panel1.Controls.Add(btn);

                left += panel1.Width / linia1 / 2 + 2;
            }

            top = 15;
            left = 5;

            for (int i = 0; i < zakr * 2; i++)
            {
                Button btn = new Button();
                btn.Name = "3" + i.ToString();
                btn.Top = top;
                btn.Left = left;
                btn.Width = panel1.Width / linia1 / 2+ 5;
                btn.Height = panel1.Width / linia1 / 2 ;
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = Color.Red;


                panel1.Controls.Add(btn);

                top += panel1.Width / linia1 / 2 + 2;
            }

            top = 15;
            left = lastleft+10;

            for (int i = 0; i < zakr * 2; i++)
            {
                Button btn = new Button();
                btn.Name = "4" + i.ToString();
                btn.Top = top;
                btn.Left = left;
                btn.Width = panel1.Width / linia1 / 2 + 5;
                btn.Height = panel1.Width / linia1 / 2;
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = Color.Red;


                panel1.Controls.Add(btn);

                top += panel1.Width / linia1 / 2 + 2;
            }
        }
    }
}
