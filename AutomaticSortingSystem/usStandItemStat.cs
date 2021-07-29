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
    public partial class usStandItemStat : UserControl
    {
        public StandItemType item;
        public usStandItemStat()
        {
            InitializeComponent();
        }

        private void usStandItemStat_Load(object sender, EventArgs e)
        {
            lbDirection.Text = item.Direction.Name;

            
        }


        public void BindAsync()
        {
            Task.Run(() => Bind());
        }

        private void Bind()
        {
            
            //lbDirection.Invoke(new Action(() => lbDirection.Text = item.Direction.Name));
         lbSorted.Invoke(new Action(() => lbSorted.Text = item.SortedParcels.ToString()));
          lbMissed.Invoke(new Action(() => lbMissed.Text = item.MissedParcelsCount.ToString()));

            double all = item.SortedParcels + item.MissedParcelsCount;

            int al = item.AllSortedParcels;
            if (al == 0)
                al = 1;
            double sorted = item.SortedParcels / (double)al;
            double missed = item.MissedParcelsCount / all;


            double ass = sorted * (double)100;
            if (ass > 100)
                ass = 100;

        prSorted.Invoke(new Action(() => prSorted.Value = (int)ass));
       //prMissed.Invoke(new Action(() => prMissed.Value = (int)missed*100));

        }
    }
}
