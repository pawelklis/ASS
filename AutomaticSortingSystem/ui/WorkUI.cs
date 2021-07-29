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

namespace AutomaticSortingSystem.ui
{
    public partial class WorkUI : UserControl
    {

        public CarouselType carousel;
        public WorkUI()
        {
            InitializeComponent();
        }

        private void WorkUI_Load(object sender, EventArgs e)
        {

            
            carousel = CarouselType.Load();
            carousel.TurnOn();


            uiSensors us = new uiSensors();
            us.carousel = carousel;
            us.Dock = DockStyle.Left;

            topPanel.Controls.Add(us);

            //pictureBox1.Top = panel1.Top + panel1.Height;
            //pictureBox1.Left = panel1.Width / 2 - pictureBox1.Width / 2;
        }



        private void panel1_Resize(object sender, EventArgs e)
        {
   
        }
    }
}
