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
    public partial class usSettings : UserControl
    {
        public CarouselType carousel { get; set; }

        public usSettings()
        {
            InitializeComponent();
        }

        private void usSettings_Load(object sender, EventArgs e)
        {

            devices.usdeviceList usd = new devices.usdeviceList();
            usd.carouselP = carousel;
            usd.dicts = carousel.Dicts;
            usd.Left = 0;
            usd.Top = 0;
            usd.Dock = DockStyle.Fill;
            this.tabPage1.Controls.Add(usd);

            usStandsParameters stand = new usStandsParameters();
            stand.Left = 0;
            stand.Top = 0;
            stand.Dock = DockStyle.Fill;
            stand.carousel = carousel;
            this.tabPage2.Controls.Add(stand);

            

            usOthersets uso = new usOthersets();
            uso.carousel = carousel;
            uso.Top = 0;
            uso.Left = 0;
            uso.Dock = DockStyle.Fill;
            tabPage3.Controls.Add(uso);

        }
    }
}
