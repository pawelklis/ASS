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

namespace AutomaticSortingSystem.devices
{
    public partial class usdeviceList : UserControl
    {
        public CarouselType carouselP { get; set; }
        public Dicts dicts { get; set; }
        public usdeviceList()
        {
            InitializeComponent();
        }

        private void usdeviceList_Load(object sender, EventArgs e)
        {
            Bind();


        }
        void Bind()
        {
            usdevice dev;

            dev = new usdevice();
            dev.DeviceName = "scanner1";
            dev.dicts = dicts;
            dev.Top = 0;
            dev.Left = 0;
            dev.carousel = carouselP;
            this.panel1.Controls.Add(dev);

            dev = new usdevice();
            dev.DeviceName = "signaling";
            dev.dicts = dicts;
            dev.Top = 0+ dev.Height *1;
            dev.Left = 0;
            dev.carousel = carouselP;
            this.panel1.Controls.Add(dev);

            dev = new usdevice();
            dev.DeviceName = "startsensor";
            dev.dicts = dicts;
            dev.Top = 0 + dev.Height * 2;
            dev.Left = 0;
            dev.carousel = carouselP;
            this.panel1.Controls.Add(dev);

            dev = new usdevice();
            dev.DeviceName = "stopsensor";
            dev.dicts = dicts;
            dev.Top = 0 + dev.Height * 3;
            dev.Left = 0;
            dev.carousel = carouselP;
            this.panel1.Controls.Add(dev);

            dev = new usdevice();
            dev.DeviceName = "tactsensor";
            dev.dicts = dicts;
            dev.Top = 0 + dev.Height * 4;
            dev.Left = 0;
            dev.carousel = carouselP;
            this.panel1.Controls.Add(dev);

            dev = new usdevice();
            dev.DeviceName = "lenghtsensor";
            dev.dicts = dicts;
            dev.Top = 0 + dev.Height * 4;
            dev.Left = 0;
            dev.carousel = carouselP;
            this.panel1.Controls.Add(dev);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            carouselP.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            Bind();
        }
    }
}
