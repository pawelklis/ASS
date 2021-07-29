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
    public partial class usStandStat : UserControl
    {

        public StandType stand { get; set; }

        public usStandStat()
        {
            InitializeComponent();
        }

        private void usStandStat_Load(object sender, EventArgs e)
        {
            label1.Text = stand.Name;

            int ll = 180;

            usStandItemStat us;
            us = new usStandItemStat();
            us.item = stand.StandItem1;
            us.Left = ll;
            us.Top = 0;
            this.Controls.Add(us);

            us = new usStandItemStat();
            us.item = stand.StandItem2;
            us.Left =ll+ us.Width * 1;
            us.Top = 0;
            this.Controls.Add(us);

            us = new usStandItemStat();
            us.item = stand.StandItem3;
            us.Left = ll + us.Width * 2;
            us.Top = 0;
            this.Controls.Add(us);

            us = new usStandItemStat();
            us.item = stand.StandItem4;
            us.Left = ll + us.Width * 3;
            us.Top = 0;
            this.Controls.Add(us);

            this.Width = us.Width * 4 + 4 + ll;
        } 


        public void RefreshData()
        {
            foreach(var c in this.Controls)
            {
                if(c.GetType() == typeof(usStandItemStat))
                {
                     usStandItemStat uc = (usStandItemStat)c;
                    uc.BindAsync();
                }
            }
        }


    }
}
