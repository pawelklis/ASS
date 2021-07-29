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
    public partial class uiSensors : UserControl
    {
        public CarouselType carousel;
        public uiSensors()
        {
            InitializeComponent();
        }

        private void uiSensors_Load(object sender, EventArgs e)
        {
            SetCTL();
        }



        void SetCTL()
        {
            if (carousel.TactSensor?.PortRS232.IsOpen() == true)
            {
                ctTactSensor.BackColor = Color.Green;
            }
            else
            {
                ctTactSensor.BackColor = Color.Red;
            }

            if (carousel.StartSensor?.PortRS232.IsOpen() == true)
            {
                ctStartSensor.BackColor = Color.Green;
            }
            else
            {
                ctStartSensor.BackColor = Color.Red;
            }

            if (carousel.StopSensor?.PortRS232.IsOpen() == true)
            {
                ctStopSensor.BackColor = Color.Green;
            }
            else
            {
                ctStopSensor.BackColor = Color.Red;
            }

            if (carousel.Scanner1?.PortRS232.IsOpen() == true)
            {
                ctScanner.BackColor = Color.Green;
            }
            else
            {
                ctScanner.BackColor = Color.Red;
            }

        }

    }
}
