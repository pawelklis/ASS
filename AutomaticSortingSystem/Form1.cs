using ASS;
using AutomaticSortingSystem.devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutomaticSortingSystem
{
    public partial class Form1 : Form
    {
        CarouselType carousel;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            webBrowser1.Navigate("https://localhost:44327/test.aspx");

            carousel= new CarouselType();
            carousel = CarouselType.Load();
            
            carousel.OnParcelError += ParcelError;
            carousel.OnParcelDataOK += ParcelOK;

            //carousel.TurnOn();
            tabControl1.Dock = DockStyle.Fill;

            usStandsParameters stand = new usStandsParameters();
            stand.Left = 0;
            stand.Top = 0;
            stand.carousel = carousel;
            this.tabPage1.Controls.Add(stand);

            usdeviceList usd = new devices.usdeviceList();
            usd.carouselP = carousel;
            usd.dicts = carousel.Dicts;
            usd.Left = 0;
            usd.Top = 40;
            this.tabPage2.Controls.Add(usd);

            usStering uss = new usStering();
            uss.carousel = carousel;
            uss.Top = 0;
            uss.Left = 0;
            uss.Height = tabPage3.Height;
            this.tabPage3.Controls.Add(uss);

            usParcelsBuffor usb = new usParcelsBuffor();
            usb.carousel = carousel;
            usb.Top = 0;
            usb.Left = 300;
            usb.Height = tabPage3.Height;
            this.tabPage3.Controls.Add(usb);


            usParcelsAtLine usp = new usParcelsAtLine();
            usp.carousel = carousel;
            usp.Top = 300;
            usp.Left = stand.Left + stand.Width;
            usp.Height = tabPage3.Height;
            this.tabPage1.Controls.Add(usp);


            usParcelsBuffor usbb = new usParcelsBuffor();
            usbb.carousel = carousel;
            usbb.Top = 0;
            usbb.Left = stand.Width;
            usbb.Height = 300;
            this.tabPage1.Controls.Add(usbb);
            usbb.BringToFront();





            usOthersets uso = new usOthersets();
            uso.carousel = carousel;
            uso.Top = 0;
            uso.Left = 0;
            tabPage4.Controls.Add(uso);

            //usVizaulization usv = new usVizaulization();
            //usv.carousel = carousel;
            //usv.Dock = DockStyle.Fill;
            //tabPage5.Controls.Add(usv);


            usDirections usDirections = new usDirections();
            usDirections.Dock = DockStyle.Fill;
            usDirections.carousel = carousel;
            tabPage5.Controls.Add(usDirections);

          
        }

        void ParcelOK(object sender, ParcelType.ParcelEventArgs e)
        {
            pnError.Invoke(new Action(() => pnError.Visible = false));
        }
        void ParcelError(object sender, ParcelType.ParcelEventArgs e)
        {

            lbError.Invoke(new Action(() => lbError.Text = e.ParcelNumber + " " + e.ErrorMessage));

            SoundPlayer snd = new SoundPlayer(ASS.Properties.Resources.buzzer3_x);
            snd.Play();

            pnError.Invoke(new Action(() => pnError.Width = Screen.PrimaryScreen.WorkingArea.Width));
            pnError.Invoke(new Action(() => pnError.Height = 300));
            pnError.Invoke(new Action(() => pnError.Top = Screen.PrimaryScreen.WorkingArea.Height / 2 + 300));
            pnError.Invoke(new Action(() => pnError.Left = 0));
            pnError.Invoke(new Action(() => pnError.Visible = true));
            pnError.Invoke(new Action(() => pnError.BringToFront()));



        }

    }
}
