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
    public partial class usStandItem : UserControl
    {
        public StandItemType standitem { get; set; }
        public Dicts dicts { get; set; }
        public CarouselType carousel { get; set; }
        public usStandItem()
        {
            InitializeComponent();
        }

        private void usStandItem_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();

            cbDirection.Items.Clear();
            foreach(var d in dicts.Directions)
            {
                cbDirection.Items.Add(d.Name);
            }

            cbDirection.Items.Insert(0, "");

            this.panel1.Controls.Clear();




            cbDirection.SelectedItem = standitem.Direction.Name;

            int tp = 0;

            usLamp lamp_1 = new usLamp();
            lamp_1.LampName = "Lampa 1";
            lamp_1.lamp = standitem.Lamp1;
            lamp_1.Left = 5;
            lamp_1.Top = tp;
            lamp_1.carouser = carousel;
            this.panel1.Controls.Add(lamp_1);

            usLamp lamp_2 = new usLamp();
            lamp_2.carouser = carousel;
            lamp_2.LampName = "Lampa 2";
            lamp_2.lamp = standitem.Lamp2;
            lamp_2.Left = 5 ;
            lamp_2.Top = tp + lamp_1.Height *1;
            this.panel1.Controls.Add(lamp_2);

            usLamp lamp_3 = new usLamp();
            lamp_3.carouser = carousel;
            lamp_3.LampName = "Lampa 3";
            lamp_3.lamp = standitem.Lamp3;
            lamp_3.Left = 5;
            lamp_3.Top = tp + lamp_1.Height * 2;
            this.panel1.Controls.Add(lamp_3);

            usLamp lamp_4 = new usLamp();
            lamp_4.carouser = carousel;
            lamp_4.LampName = "Lampa 4";
            lamp_4.lamp = standitem.Lamp4;
            lamp_4.Left = 5;
            lamp_4.Top = tp + lamp_1.Height * 3;
            this.panel1.Controls.Add(lamp_4);

        }

        private void cbDirection_SelectedIndexChanged(object sender, EventArgs e)
        {

            foreach(var d in dicts.Directions)
            {
                if (d.Name == cbDirection.SelectedItem.ToString())
                {
                    standitem.Direction = d;
                    break;
                }
            }            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbMissed.Text = standitem.MissedParcelsCount.ToString();
        }
    }
}
