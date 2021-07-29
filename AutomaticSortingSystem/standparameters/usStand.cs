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
    public partial class usStand : UserControl
    {

        public StandType stand { get; set; }
        public Dicts dicts { get; set; }
        public CarouselType carousel { get; set; }

        public usStand()
        {
            InitializeComponent();
        }

        private void usStand_Load(object sender, EventArgs e)
        {

            this.panel1.Controls.Clear();

            txName.Text = stand.Name;

            int tp = 0;


            usStandItem item1 = new usStandItem();
            item1.carousel = carousel;
            item1.standitem = stand.StandItem1;
            item1.dicts = dicts;
            item1.Left = 5;
            item1.Top = tp;
            this.panel1.Controls.Add(item1);
            

            usStandItem item2 = new usStandItem();
            item2.carousel = carousel;
            item2.standitem = stand.StandItem2;
            item2.dicts = dicts;
            item2.Left = 0+5+ item1.Width *1;
            item2.Top = tp;
            this.panel1.Controls.Add(item2);

            usStandItem item3 = new usStandItem();
            item3.carousel = carousel;
            item3.standitem = stand.StandItem3;
            item3.dicts = dicts;
            item3.Left = 0+5 + item1.Width * 2;
            item3.Top = tp;
            this.panel1.Controls.Add(item3);

            usStandItem item4 = new usStandItem();
            item4.carousel = carousel;
            item4.standitem = stand.StandItem4;
            item4.dicts = dicts;
            item4.Left = 0+5 + item1.Width * 3;
            item4.Top = tp;
            this.panel1.Controls.Add(item4);


        }

        private void txName_TextChanged(object sender, EventArgs e)
        {
            stand.Name = txName.Text;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }
    }
}
