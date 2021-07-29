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
    public partial class usParcelsAtLine : UserControl
    {
        public CarouselType carousel { get; set; }
        public usParcelsAtLine()
        {
            InitializeComponent();
        }

        private void usParcelsAtLine_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (carousel != null)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("numer");
                dt.Columns.Add("pna");
                dt.Columns.Add("kierunek");
                dt.Columns.Add("takt");
                dt.Columns.Add("taktdocelowy");
                dt.Columns.Add("lenght");
                dt.Columns.Add("korekcja");
                dt.Columns.Add("secondrun");
                dt.Columns.Add("runtime");
                try
                {
         foreach(var p in carousel.ParcelsOnRun)
                {
                    dt.Rows.Add(p.Number, p.DestinationPNA, p.Destination.Direction.Name, p.TactCount, p.Destination.Lamp2.TactsToTurnON - p.correctCounts, p.Lenght, p.correctCounts,p.SecondRunt,p.RunTime());
                }
                }
                catch (Exception)
                {

                   
                }
       

                dg1.DataSource = dt;
                
            }
        }
    }
}
