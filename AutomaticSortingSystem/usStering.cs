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
using System.Media;

namespace AutomaticSortingSystem
{
    public partial class usStering : UserControl
    {
        public CarouselType carousel { get; set; }

        int tik { get; set; }

        int MAxTactTime { get; set; }
        public usStering()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(button1.Text=="Uruchom maszynę")
            {
                carousel.TurnOn();
                button1.Text = "Zatrzymaj maszynę";
            }
            else
            {
                carousel.TurnOff();
                button1.Text = "Uruchom maszynę";
            }

        }

        private bool NeedMaxReset { get; set; }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (carousel == null)
            {
                return;
            }

            if (NeedMaxReset == true)
            {
                MAxTactTime = 0;
                NeedMaxReset = false;
            }

            if (carousel.Isworking == true)
            {
                labelIsWorking.Text = "PRACA";
                labelIsWorking.ForeColor = Color.DarkGreen;
            }
            else
            {
                labelIsWorking.Text = "STOP";
                labelIsWorking.ForeColor = Color.Red;
                NeedMaxReset = true;
            }

            if (tik > 5000)
            {
                MAxTactTime = 0;
                tik = 0;
            }

 //           if(carousel.TactTime.TotalMilliseconds > 700)
 //           {
 //               if (carousel.Isworking == true)
 //               {  
 //SoundPlayer snd = new SoundPlayer(AutomaticSortingSystem.Properties.Resources.circlealarm);
 //               snd.Play();
 //               }
             
 //           }
            

            if (MAxTactTime < carousel.StatReport.TactTime.TotalMilliseconds)
                    MAxTactTime = (int)carousel.StatReport.TactTime.TotalMilliseconds;

            lbLastTact.Text = carousel.StatReport.LastTactTime.ToString() ;
            lbSuposedTact.Text = carousel.StatReport.SuppposedTactTime.ToString();
            lbtacttime.Text = carousel.StatReport.TactTime.ToString() + "\n " + carousel.StatReport.TactTime.TotalMilliseconds.ToString() + " [ms] \n max:" + MAxTactTime + " [ms] " + "\n Takty:" + carousel.StatReport.TactsCount;
            lbworkdetect.Text = carousel.Dicts.WorkdetectionIntervalMS.ToString() + "[ms]";
            tik += 1;
        }

        private void usStering_Load(object sender, EventArgs e)
        {
            tik = 4990;
            timer1.Interval = 100;
            timer1.Start();
            MAxTactTime = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {


    


            foreach(var s in carousel.Dicts.Stands)
            {
                if(s.Name=="Stanowisko 1")
                {
                    s.StandItem1.Lamp1.TurnOn(carousel.Signaling);
                    s.StandItem1.Lamp2.TurnOn(carousel.Signaling);
                    s.StandItem1.Lamp3.TurnOn(carousel.Signaling);
                    s.StandItem1.Lamp4.TurnOn(carousel.Signaling);

                    s.StandItem2.Lamp1.TurnOn(carousel.Signaling);
                    s.StandItem2.Lamp2.TurnOn(carousel.Signaling);
                    s.StandItem2.Lamp3.TurnOn(carousel.Signaling);
                    s.StandItem2.Lamp4.TurnOn(carousel.Signaling);

                    s.StandItem3.Lamp1.TurnOn(carousel.Signaling);
                    s.StandItem3.Lamp2.TurnOn(carousel.Signaling);
                    s.StandItem3.Lamp3.TurnOn(carousel.Signaling);
                    s.StandItem3.Lamp4.TurnOn(carousel.Signaling);

                    s.StandItem4.Lamp1.TurnOn(carousel.Signaling);
                    s.StandItem4.Lamp2.TurnOn(carousel.Signaling);
                    s.StandItem4.Lamp3.TurnOn(carousel.Signaling);
                    s.StandItem4.Lamp4.TurnOn(carousel.Signaling);
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (var s in carousel.Dicts.Stands)
            {
                if (s.Name == "Stanowisko 1")
                {
                    s.StandItem1.Lamp1.TurnOff(carousel.Signaling);
                    s.StandItem1.Lamp2.TurnOff(carousel.Signaling);
                    s.StandItem1.Lamp3.TurnOff(carousel.Signaling);
                    s.StandItem1.Lamp4.TurnOff(carousel.Signaling);

                    s.StandItem2.Lamp1.TurnOff(carousel.Signaling);
                    s.StandItem2.Lamp2.TurnOff(carousel.Signaling);
                    s.StandItem2.Lamp3.TurnOff(carousel.Signaling);
                    s.StandItem2.Lamp4.TurnOff(carousel.Signaling);

                    s.StandItem3.Lamp1.TurnOff(carousel.Signaling);
                    s.StandItem3.Lamp2.TurnOff(carousel.Signaling);
                    s.StandItem3.Lamp3.TurnOff(carousel.Signaling);
                    s.StandItem3.Lamp4.TurnOff(carousel.Signaling);

                    s.StandItem4.Lamp1.TurnOff(carousel.Signaling);
                    s.StandItem4.Lamp2.TurnOff(carousel.Signaling);
                    s.StandItem4.Lamp3.TurnOff(carousel.Signaling);
                    s.StandItem4.Lamp4.TurnOff(carousel.Signaling);

                    if (s.StandItem1.Lamp1.blinkTimer != null)
                        s.StandItem1.Lamp1.blinkTimer.Stop();

                    if (s.StandItem1.Lamp2.blinkTimer != null)
                        s.StandItem1.Lamp2.blinkTimer.Stop();

                    if (s.StandItem1.Lamp3.blinkTimer != null)
                        s.StandItem1.Lamp3.blinkTimer.Stop();

                    if (s.StandItem1.Lamp4.blinkTimer != null)
                        s.StandItem1.Lamp4.blinkTimer.Stop();


                    if (s.StandItem2.Lamp1.blinkTimer != null)
                        s.StandItem2.Lamp1.blinkTimer.Stop();
                    if (s.StandItem2.Lamp2.blinkTimer != null)
                        s.StandItem2.Lamp2.blinkTimer.Stop();
                    if (s.StandItem2.Lamp3.blinkTimer != null)
                        s.StandItem2.Lamp3.blinkTimer.Stop();
                    if (s.StandItem2.Lamp4.blinkTimer != null)
                        s.StandItem2.Lamp4.blinkTimer.Stop();

                    if (s.StandItem3.Lamp1.blinkTimer != null)
                        s.StandItem3.Lamp1.blinkTimer.Stop();
                    if (s.StandItem3.Lamp2.blinkTimer != null)
                        s.StandItem3.Lamp2.blinkTimer.Stop();
                    if (s.StandItem3.Lamp3.blinkTimer != null)
                        s.StandItem3.Lamp3.blinkTimer.Stop();
                    if (s.StandItem3.Lamp4.blinkTimer != null)
                        s.StandItem3.Lamp4.blinkTimer.Stop();

                    if (s.StandItem4.Lamp1.blinkTimer != null)
                        s.StandItem4.Lamp1.blinkTimer.Stop();
                    if (s.StandItem4.Lamp2.blinkTimer != null)
                        s.StandItem4.Lamp2.blinkTimer.Stop();
                    if (s.StandItem4.Lamp3.blinkTimer != null)
                        s.StandItem4.Lamp3.blinkTimer.Stop();
                    if (s.StandItem4.Lamp4.blinkTimer != null)
                        s.StandItem4.Lamp4.blinkTimer.Stop();

                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            carousel.StatReport.TactsCount = 0;
            MAxTactTime = 0;
        }
    }
}
