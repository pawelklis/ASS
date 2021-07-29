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
    public partial class usStandsParameters : UserControl
    {

        public CarouselType carousel { get; set; }

        public usStandsParameters()
        {
            InitializeComponent();
        }

        private void usStandsParameters_Load(object sender, EventArgs e)
        {

            cbSelectedStand.DataSource = carousel.Dicts.Stands;
            cbSelectedStand.DisplayMember = "Name";
            cbSelectedStand.ValueMember = "Name";
            cbSelectedStand.SelectedIndex = 0;

            Bind();
        }

        void Bind()
        {
            this.panel1.Controls.Clear();
            foreach(var s in carousel.Dicts.Stands)
            {
                if (s.Name == cbSelectedStand.SelectedValue.ToString())
                {
                    usStand stand = new usStand();
                    stand.carousel = carousel;
                    stand.stand = s;
                    stand.dicts = carousel.Dicts;
                    stand.Left = 0;
                    stand.Top = 0;
                    this.panel1.Controls.Add(stand);

                    break;
                }
            }
        }

        private void cbSelectedStand_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bind();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            carousel.Save();
        }
    }
}
