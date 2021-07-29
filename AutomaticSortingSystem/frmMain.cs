using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ASS;
using Gecko;

namespace AutomaticSortingSystem
{
    public partial class frmMain : Form
    {
        CarouselType carousel;

        private bool machine_status;
        private bool start_sensorstatus;
        private bool stop_sensorstatus;
        private bool tact_sensorstatus;
        private bool signaling_sensorstatus;
        private bool scanner_sensorstatus;
        private bool lenght_sensorstatus;
        private bool rfidtactsensor_status;

        private bool stand1_status;
        private bool stand2_status;
        private bool stand3_status;
        private bool stand4_status;
        private bool stand5_status;
        private bool stand6_status;
        private bool stand7_status;
        private bool stand8_status;
        private bool stand9_status;
        private bool stand10_status;
        private bool stand11_status;
        private bool stand12_status;
        private bool stand13_status;

        private int dgscrollindex;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            DateTime tn = DateTime.Now;
            lbTime.Invoke(new Action(() => lbTime.Text = tn.Year + "-" + tn.Month + "-" + tn.Day + " " + tn.Hour + ":" + tn.Minute));
            var version = Application.ProductVersion;

            label2.Text = "v." + version;


            Container.Left = ((this.Width  / 2) - (Container.Width / 2)) -200;

            carousel = new CarouselType();
            carousel = CarouselType.Load();
            carousel.TurnOn();

            carousel.CarouselTacted += CarouselTacted;
            carousel.CarouselTimer += CarouselTimer;

            BindStands();

            Task.Run(() => UpdateData());

            pnweb.Parent = this;


        }
        private void frmMain_ResizeEnd(object sender, EventArgs e)
        {
            Container.Left = ((this.Width / 2) - (Container.Width / 2)) - 200;
        }

        void CarouselTimer(object sender,EventArgs e)
        {
            Task.Run(() => UpdateData());
        }
        void CarouselTacted(object sender, EventArgs e)
        {
            //Task.Run(() => UpdateData());
        }


        private void LauncherDialog_Download(object sender, Gecko.LauncherDialogEvent e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = e.Filename;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                nsILocalFile objTarget = Xpcom.CreateInstance<nsILocalFile>("@mozilla.org/file/local;1");

                using (nsAString tmp = new nsAString(saveFileDialog1.FileName))
                {
                    objTarget.InitWithPath(tmp);
                }
                e.HelperAppLauncher.SaveToDisk(objTarget, false);
            }
        }

        async void UpdateData()
        {
            try
            {
                DateTime tn = DateTime.Now;
                lbTime.Invoke(new Action(() => lbTime.Text = tn.Year + "-" + tn.Month + "-" + tn.Day + " " + tn.Hour + ":" + tn.Minute));

                dgscrollindex = dg1.FirstDisplayedScrollingRowIndex;


            await Task.Run(() => carousel.SetStatusReport());

            dg1.Invoke( new Action(()=>     dg1.DataSource = carousel.ParcelsOnRunTable()));

                if(dgscrollindex>0)
                    dg1.Invoke(new Action(() => dg1.FirstDisplayedScrollingRowIndex = dgscrollindex));

                dg1.Invoke(new Action(() => dg1.Columns[4].Width = 50));





            if (carousel.StatReport.CarouselWorking == true)
            {
                  
                    pictureBox2.Invoke(new Action(() => pictureBox2.Image = AutomaticSortingSystem.Properties.Resources.workOn));
            }
            else
            {
                  
                    pictureBox2.Invoke(new Action(() => pictureBox2.Image = AutomaticSortingSystem.Properties.Resources.workoff));
            }

            lbShift.Invoke(new Action(() => lbShift.Text = carousel.CurrentShift.ShiftStart.ToString()));
            labelbuffer.Invoke(new Action(() => labelbuffer.Text ="W buforze:" + carousel.ParcelsBuffer.Count.ToString()));
            labelline.Invoke(new Action(() => labelline.Text ="Na linii:" + carousel.ParcelsOnRun.Count.ToString()));
            labelcurrentplate.Invoke(new Action(() => labelcurrentplate.Text = carousel.RFIDTactSensor.CurrentReadedPlateID + "[" + carousel.RFIDTactSensor.currentPlate().Index + "]"));
            labelnextplate.Invoke(new Action(() => labelnextplate.Text = carousel.RFIDTactSensor.NextPlateID()));
            lboccupiedplatespercentage.Invoke(new Action(() =>lboccupiedplatespercentage.Text = "Zajętość maszyny:" + carousel.Occupiedplatespercent().ToString() + "%" )) ;
            labeloccupiedplatescount.Invoke(new Action(() => labeloccupiedplatescount.Text = "Zajętość maszyny:" + carousel.OccupiedPlatesCT().ToString() + "tac"));
            lbtact.Invoke(new Action(() => lbtact.Text = "Takt:" + carousel.Dicts.CurrentTact + ""));
            lbround.Invoke(new Action(() => lbround.Text = "Okrążenie:" + carousel.Dicts.RoundNumber + ""));
            lbclients.Invoke(new Action(() => lbclients.Text = "Podłączonych klientów:" + carousel.data_server.ConnectedClientsCount.ToString() + ""));

            foreach(var c in panel4.Controls)
                {
                    if (c.GetType() == typeof(usStandStat))
                    {
                        usStandStat u = (usStandStat)c;
                        u.RefreshData();
                    }
                }

                //await Task.Run(() => BindChart());
               // if(backgroundWorker1.IsBusy==false)
                   // backgroundWorker1.RunWorkerAsync();
        


            }
            catch (Exception ex)
            {
                                
            }


            StatusReportType statusReport = carousel.StatReport;


            if (statusReport.StartSensorConnected == true)
            {               

                bStartsensor.Invoke(new Action(() => bStartsensor.BackColor = Color.Green));

                if (start_sensorstatus == false)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik startu połączony")));
                    start_sensorstatus = true;
                }
            }
            else
            {
                bStartsensor.Invoke(new Action(() => bStartsensor.BackColor = Color.Red));


                if (start_sensorstatus == true)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik startu rozłączony")));
                    start_sensorstatus = false;
                }
            }




            if (statusReport.StopSensorConnected == true)
            {
                bStopsensor.Invoke(new Action(() => bStopsensor.BackColor = Color.Green));


                if (stop_sensorstatus == false)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stop połączony")));
                    stop_sensorstatus = true;
                }
            }
            else
            {
                bStopsensor.Invoke(new Action(() => bStopsensor.BackColor = Color.Red));


                if (stop_sensorstatus == true)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stop rozłączony")));
                    stop_sensorstatus = false;
                }
            }

            if (statusReport.tactSensorConnected == true)
            {
                bTactSensor.Invoke(new Action(() => bTactSensor.BackColor = Color.Green));

                if (tact_sensorstatus == false)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik taktu połączony")));

                    tact_sensorstatus = true;
                }
            }
            else
            {
                bTactSensor.Invoke(new Action(() => bTactSensor.BackColor = Color.Red));



                if (tact_sensorstatus == true)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik taktu rozłączony")));
                    tact_sensorstatus = false;
                }
            }

            if (statusReport.LenghttSensorConnected == true)
            {
                bLenghtsensor.Invoke(new Action(() => bLenghtsensor.BackColor = Color.Green));

                if (lenght_sensorstatus == false)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik długości połączony")));

                    lenght_sensorstatus = true;
                }
            }
            else
            {
                bLenghtsensor.Invoke(new Action(() => bLenghtsensor.BackColor = Color.Red));

                if (lenght_sensorstatus == true)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik długości rozłączony")));

                    lenght_sensorstatus = false;
                }
            }

            if (statusReport.SignalingConnected == true)
            {
                bSignaling.Invoke(new Action(() => bSignaling.BackColor = Color.Green));


                if (signaling_sensorstatus == false)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Sterownik sygnalizacji połączony")));

                    signaling_sensorstatus = true;
                }
            }
            else
            {
                bSignaling.Invoke(new Action(() => bSignaling.BackColor = Color.Red));


                if (signaling_sensorstatus == true)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Sterownik sygnalizacji rozłączony")));

                    signaling_sensorstatus = false;
                }
            }

            if (statusReport.Scanner1Connected == true)
            {
                bScanner1.Invoke(new Action(() => bScanner1.BackColor = Color.Green));

                if (scanner_sensorstatus == false)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Skaner nr 1 połączony")));

                    scanner_sensorstatus = true;
                }
            }
            else
            {
                bScanner1.Invoke(new Action(() => bScanner1.BackColor = Color.Red));

                if (scanner_sensorstatus == true)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Skaner nr 1 rozłączony")));

                    scanner_sensorstatus = false;
                }
            }

            if (statusReport.rfidTactSensorConnected == true)
            {
                bPlatesensor.Invoke(new Action(() => bPlatesensor.BackColor = Color.Green));

                if (rfidtactsensor_status == false)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik tacek połączony")));

                    rfidtactsensor_status = true;
                }
            }
            else
            {
                bPlatesensor.Invoke(new Action(() => bPlatesensor.BackColor = Color.Red));

                if (rfidtactsensor_status == true)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik tacek rozłączony")));

                    rfidtactsensor_status = false;
                }
            }





            if (statusReport.rfidReaderConnected_1 == true)
            {
                bStand1.Invoke(new Action(() => bStand1.BackColor = Color.Green));

                if (stand1_status == false)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 1 połączony")));

                    stand1_status = true;
                }
            }
            else
            {
                bStand1.Invoke(new Action(() => bStand1.BackColor = Color.Red));

                if (stand1_status == true)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 1 rozłączony")));

                    stand1_status = false;
                }
            }



            if (statusReport.rfidReaderConnected_2 == true)
            {
                bStand2.Invoke(new Action(() => bStand2.BackColor = Color.Green));

                if (stand2_status == false)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 2 połączony")));

                    stand2_status = true;
                }
            }
            else
            {
                bStand2.Invoke(new Action(() => bStand2.BackColor = Color.Red));

                if (stand2_status == true)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 2 rozłączony")));

                    stand2_status = false;
                }
            }


            if (statusReport.rfidReaderConnected_3 == true)
            {
                Bstand3.Invoke(new Action(() => Bstand3.BackColor = Color.Green));

                if (stand3_status == false)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 3 połączony")));

                    stand3_status = true;
                }
            }
            else
            {
                Bstand3.Invoke(new Action(() => Bstand3.BackColor = Color.Red));

                if (stand3_status == true)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 3 rozłączony")));

                    stand3_status = false;
                }
            }


            if (statusReport.rfidReaderConnected_4 == true)
            {
                bStand4.Invoke(new Action(() => bStand4.BackColor = Color.Green));

                if (stand4_status == false)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 4 połączony")));

                    stand4_status = true;
                }
            }
            else
            {
                bStand4.Invoke(new Action(() => bStand4.BackColor = Color.Red));

                if (stand4_status == true)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 4 rozłączony")));

                    stand4_status = false;
                }
            }


            if (statusReport.rfidReaderConnected_5 == true)
            {
                bStand5.Invoke(new Action(() => bStand5.BackColor = Color.Green));

                if (stand5_status == false)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 5 połączony")));

                    stand5_status = true;
                }
            }
            else
            {
                bStand5.Invoke(new Action(() => bStand5.BackColor = Color.Red));

                if (stand5_status == true)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 5 rozłączony")));

                    stand5_status = false;
                }
            }


            if (statusReport.rfidReaderConnected_6 == true)
            {
                bStand6.Invoke(new Action(() => bStand6.BackColor = Color.Green));

                if (stand6_status == false)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 6 połączony")));

                    stand6_status = true;
                }
            }
            else
            {
                bStand6.Invoke(new Action(() => bStand6.BackColor = Color.Red));

                if (stand6_status == true)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 6 rozłączony")));

                    stand6_status = false;
                }
            }




            if (statusReport.rfidReaderConnected_7 == true)
            {
                bStand7.Invoke(new Action(() => bStand7.BackColor = Color.Green));

                if (stand7_status == false)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 7 połączony")));

                    stand7_status = true;
                }
            }
            else
            {
                bStand7.Invoke(new Action(() => bStand7.BackColor = Color.Red));


                if (stand7_status == true)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 7 rozłączony")));

                    stand7_status = false;
                }
            }




            if (statusReport.rfidReaderConnected_8 == true)
            {
                bStand8.Invoke(new Action(() => bStand8.BackColor = Color.Green));

                if (stand8_status == false)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 8 połączony")));

                    stand8_status = true;
                }
            }
            else
            {
                bStand8.Invoke(new Action(() => bStand8.BackColor = Color.Red));


                if (stand8_status == true)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 8 rozłączony")));

                    stand8_status = false;
                }
            }




            if (statusReport.rfidReaderConnected_9 == true)
            {
                bStand9.Invoke(new Action(() => bStand9.BackColor = Color.Green));

                if (stand9_status == false)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 9 połączony")));

                    stand9_status = true;
                }
            }
            else
            {
                bStand9.Invoke(new Action(() => bStand9.BackColor = Color.Red));

                if (stand9_status == true)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 9 rozłączony")));

                    stand9_status = false;
                }
            }






            if (statusReport.rfidReaderConnected_10 == true)
            {
                bStand10.Invoke(new Action(() => bStand10.BackColor = Color.Green));


                if (stand10_status == false)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 10 połączony")));

                    stand10_status = true;
                }
            }
            else
            {
                bStand10.Invoke(new Action(() => bStand10.BackColor = Color.Red));


                if (stand10_status == true)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 10 rozłączony")));

                    stand10_status = false;
                }
            }




            if (statusReport.rfidReaderConnected_11 == true)
            {
                bStand11.Invoke(new Action(() => bStand11.BackColor = Color.Green));


                if (stand11_status == false)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 11 połączony")));

                    stand11_status = true;
                }
            }
            else
            {
                bStand11.Invoke(new Action(() => bStand11.BackColor = Color.Red));


                if (stand11_status == true)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 11 rozłączony")));

                    stand11_status = false;
                }
            }


            if (statusReport.rfidReaderConnected_12 == true)
            {
                bStand12.Invoke(new Action(() => bStand12.BackColor = Color.Green));


                if (stand12_status == false)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 12 połączony")));

                    stand12_status = true;
                }
            }
            else
            {
                bStand12.Invoke(new Action(() => bStand12.BackColor = Color.Red));


                if (stand12_status == true)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 12 rozłączony")));

                    stand12_status = false;
                }
            }



            if (statusReport.rfidReaderConnected_13 == true)
            {
                bStand13.Invoke(new Action(() => bStand13.BackColor = Color.Green));


                if (stand13_status == false)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 13 połączony")));

                    stand13_status = true;
                }
            }
            else
            {
                bStand13.Invoke(new Action(() => bStand13.BackColor = Color.Red));

                if (stand13_status == true)
                {
                    loglist.Invoke(new Action(() => loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 13 rozłączony")));

                    stand13_status = false;
                }
            }

            if (carousel.CurrentShift.IsOpen() == true)
            {
                button3.Invoke(new Action(() => button3.Text = "Stop przebiegu"));

                if (carousel.ParcelsBuffer.Count > 0)
                {
                    button3.Invoke(new Action(() => button3.Enabled = false));
                }
                else
                {
                    button3.Invoke(new Action(() => button3.Enabled = true));
                }

                if (carousel.ParcelsOnRun.Count > 0)
                {
                    button3.Invoke(new Action(() => button3.Enabled = false));
                }
                else
                {
                    button3.Invoke(new Action(() => button3.Enabled = true));
                }
            }
            else
            {
                button3.Invoke(new Action(() => button3.Text = "Start przebiegu"));
            }




        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnweb.Visible = false;
            geckoWebBrowser1.Navigate("http://localhost:76/");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //usSettings us = new usSettings();
            //us.carousel = carousel;
            //us.Dock = DockStyle.Fill;

            //Container.AutoScroll = true;
            //Container.Controls.Clear();
            //Container.Controls.Add(us);

            geckoWebBrowser1.Navigate("http://localhost:76/settings.aspx");

            pnweb.Dock = DockStyle.Fill;
            pnweb.Visible = true;
            pnweb.BringToFront();
        }

        private async void button5_Click(object sender, EventArgs e)
        {
           await carousel.Dicts.Stands[0].StandItem3.Lamp1.TurnOn(carousel.Signaling);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            try
            {

            }
            catch (Exception)
            {

              
            }



            //try
            //{
            //    DataTable dt = new DataTable();
            //    dt.Columns.Add("kierunek");
            //    dt.Columns.Add("sorted");
            //    dt.Columns.Add("mised");

            //    foreach (var s in carousel.StatReport.StandsStats)
            //    {
            //        dt.Rows.Add(s.Name, s.SortedParcels, s.MissedParcels);
            //    }

            //    chart1.Invoke(new Action(() => chart1.Series.Clear()));
            //    //this.chart1.DataBindCrossTable(dt.Rows, "kierunek", "mised", "sorted", "");

            //    chart1.Invoke(new Action(() => chart1.Series.Add("Podzielone")));
            //    chart1.Invoke(new Action(() => chart1.Series[0].XValueMember = "kierunek"));
            //    if (string.IsNullOrEmpty(chart1.Series[0].YValueMembers))
            //        chart1.Invoke(new Action(() => chart1.Series[0].YValueMembers = "sorted"));
            //    chart1.Invoke(new Action(() => chart1.Series[0].IsValueShownAsLabel = true));
            //    chart1.Invoke(new Action(() => chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column));

            //    chart1.Invoke(new Action(() => chart1.Series.Add("Przepuszczone")));
            //    chart1.Invoke(new Action(() => chart1.Series[1].XValueMember = "kierunek"));
            //    if (string.IsNullOrEmpty(chart1.Series[1].YValueMembers))
            //        chart1.Invoke(new Action(() => chart1.Series[1].YValueMembers = "mised"));
            //    chart1.Invoke(new Action(() => chart1.Series[1].IsValueShownAsLabel = true));
            //    chart1.Invoke(new Action(() => chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column));

            //    chart1.Invoke(new Action(() => chart1.ChartAreas["ChartArea1"].AxisX.Title = "Kierunek"));
            //    chart1.Invoke(new Action(() => chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1));
            //    chart1.Invoke(new Action(() => chart1.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Sans Serif", 10, FontStyle.Bold)));
            //    chart1.Invoke(new Action(() => chart1.ChartAreas["ChartArea1"].AxisY.Title = "Liczba przesyłek"));
            //    chart1.Invoke(new Action(() => chart1.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Sans Serif", 10, FontStyle.Bold)));

            //    chart1.Invoke(new Action(() => chart1.Legends.Add("Legenda")));
            //    chart1.Invoke(new Action(() => chart1.Legends[0].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom));

            //    chart1.Invoke(new Action(() => chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false));
            //    chart1.Invoke(new Action(() => chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false));


            //    chart1.Invoke(new Action(() => chart1.DataSource = dt));
            //    chart1.Invoke(new Action(() => chart1.DataBind()));
            //}
            //catch (Exception ex)
            //{


            //}
        }



        void BindStands()
        {
            int tp = 0;
            foreach(var s in carousel.Dicts.Stands)
            {
                usStandStat us;
                us = new usStandStat();
                us.stand = s;
                us.Top = tp;
                us.Left = 0;
                panel4.Controls.Add(us);
                tp += us.Height;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (carousel.CurrentShift.IsOpen() == true)
            {
                carousel.StopRun();
            }
            else
            {
                carousel.StartRun();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            geckoWebBrowser1.Navigate("http://localhost:76/diagnosis.aspx");

            pnweb.Dock = DockStyle.Fill;
            pnweb.Visible = true;
            pnweb.BringToFront();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            geckoWebBrowser1.Navigate("http://localhost:76/statistics.aspx");
            LauncherDialog.Download += LauncherDialog_Download;

            pnweb.Dock = DockStyle.Fill;
            pnweb.Visible = true;
            pnweb.BringToFront();
        }

    }
}
