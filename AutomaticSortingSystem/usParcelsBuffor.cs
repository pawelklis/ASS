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
    public partial class usParcelsBuffor : UserControl
    {
        public CarouselType carousel { get; set; }
        public usParcelsBuffor()
        {
            InitializeComponent();
        }

        private void usParcelsBuffor_Load(object sender, EventArgs e)
        {

        

            timer1.Interval = 100;
            timer1.Start();
        }

     

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (carousel != null)
            {
                lbBuffer.Text = carousel.ParcelsBuffer.Count.ToString();
                


                listBox1.Items.Clear();
                try
                {
                 foreach(var p in carousel.ParcelsBuffer)
                    {
                        listBox1.Items.Add(p.Number + " " + p.Destination.Direction.Name );
                    }
                }
                catch (Exception)
                {

          
                }
   
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
