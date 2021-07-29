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
    public partial class usDirections : UserControl
    {
        public CarouselType carousel { get; set; }
        public usDirections()
        {
            InitializeComponent();
        }

        private void usDirections_Load(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("nazwa");
            dt.Columns.Add("pnaod");
            dt.Columns.Add("pnado");
            dt.Columns.Add("wsr");

            foreach(var d in carousel.Dicts.Directions)
            {
                foreach(var i in d.DirectionsPNAList)
                {
                    dt.Rows.Add(d.Name, i.PnaFrom, i.PnaTo, i.WSR);
                }
            }


            dg1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            carousel.Dicts.Directions.Clear();

            for (int i = 0; i < dg1.Rows.Count - 1; i++)
            {
                string nazwa = dg1.Rows[i].Cells["nazwa"].Value.ToString();
                string pnaOdd = dg1.Rows[i].Cells["pnaod"].Value.ToString();
                string pnaDod = dg1.Rows[i].Cells["pnado"].Value.ToString();
                string wsr = dg1.Rows[i].Cells["wsr"].Value.ToString();

                DirectionType kierunek = getKierunekFromKierunki(nazwa,carousel.Dicts.Directions);

                DirectionItemType item = new DirectionItemType();
                item.PnaFrom = pnaOdd;
                item.PnaTo = pnaDod;
                item.WSR = wsr;

                kierunek.DirectionsPNAList.Add(item);

            }

            carousel.Save();
        }

        DirectionType getKierunekFromKierunki(string nazwa, List<DirectionType> kierunki)
        {
            foreach (var k in kierunki)
            {
                if (k.Name == nazwa)
                {
                    return k;
                }
            }

            DirectionType kierunek = new DirectionType();
            kierunek.Name = nazwa;

            kierunki.Add(kierunek);
            return kierunek;
        }


    }
}
