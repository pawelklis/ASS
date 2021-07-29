using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASS;
using System.Data;
using System.Drawing;
using SimpleTCP;
using System.Text;

namespace ASS_WEB
{
    public partial class dasch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["machine"] = machine_status;
                ViewState["start_sensorstatus"] = start_sensorstatus;
                ViewState["stop_sensorstatus"] = stop_sensorstatus;
                ViewState["tact_sensorstatus"] = tact_sensorstatus;
                ViewState["signaling_sensorstatus"] = signaling_sensorstatus;
                ViewState["scanner_sensorstatus"] = scanner_sensorstatus;
                ViewState["lenght_sensorstatus"] = lenght_sensorstatus;
                SendToserverAndGetResponse("CheckDevices");
            }
        }

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



        protected void Button1_Click(object sender, EventArgs e)
        {
            runobject.Attributes.CssStyle.Add("class","animated");


            ClientScript.RegisterStartupScript(this.GetType(), "anm", "document.getElementById('runobject').style.visibility = 'hidden';", true);

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            runobject.Attributes.CssStyle.Clear();

            ClientScript.RegisterStartupScript(this.GetType(), "anm", "document.getElementById('runobject').style.visibility = 'visible';", true);
        }


        string SendToserverAndGetResponse(string message)
        {
            try
            {
                SimpleTcpClient client;
                client = new SimpleTcpClient();
                client.StringEncoder = Encoding.UTF8;
                //client.DataReceived += Client_DataReceived;
                client = new SimpleTcpClient().Connect("127.0.0.1", Convert.ToInt32("4444"));            
                TimeSpan ts = new TimeSpan(0, 0, 5);
                string response = client.WriteLineAndGetReply(message, ts).MessageString;
                client.Disconnect();
                return response;
            }
            catch (Exception ex)
            {

            }
            return "";
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            StatusReportType statusReport = StatusReportType.FromJson(SendToserverAndGetResponse("GetStatusReport"));

            if (statusReport != null)
            {

            
            labelWork.Text = "STOP";

            machine_status = bool.Parse(ViewState["machine"].ToString());
            start_sensorstatus = bool.Parse(ViewState["start_sensorstatus"].ToString());
            stop_sensorstatus = bool.Parse(ViewState["stop_sensorstatus"].ToString());
            tact_sensorstatus = bool.Parse(ViewState["tact_sensorstatus"].ToString());
            signaling_sensorstatus = bool.Parse(ViewState["signaling_sensorstatus"].ToString());
            scanner_sensorstatus = bool.Parse(ViewState["scanner_sensorstatus"].ToString());
            lenght_sensorstatus = bool.Parse(ViewState["lenght_sensorstatus"].ToString());

                dg1.DataSource = statusReport.parcelsOnRunTable;
                dg1.DataBind();

                labelcurrentplate.Text = statusReport.currentplate;
                labelnextplate.Text = statusReport.nextplate;

            if (statusReport.CarouselWorking == true)
            {
                labelWork.Text = "Praca";
                workimg.ImageUrl = "~/workon.gif";

                if (machine_status == false)
                {
                    loglist.Items.Insert(0, DateTime.Now + " " + "Start maszyny");
                    machine_status = true;
                }

            }
            else
            {
                workimg.ImageUrl = "~/workoff.gif";

                if (machine_status == true)
                {
                    loglist.Items.Insert(0, DateTime.Now + " " + "Stop maszyny");
                    machine_status = false;
                }

            }


            if (statusReport.StartSensorConnected == true)
            {
                startscanner.Attributes["class"] = "connected";


                if (start_sensorstatus == false)
                {
                    loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik startu połączony");
                    start_sensorstatus = true;
                }
            }
            else
            {
                startscanner.Attributes["class"] = "disconnected";


                if (start_sensorstatus == true)
                {
                    loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik startu rozłączony");
                    start_sensorstatus = false;
                }
            }

            


            if (statusReport.StopSensorConnected == true)
            {
                stopscanner.Attributes["class"] = "connected";


                if (stop_sensorstatus == false)
                {
                    loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stop połączony");
                    stop_sensorstatus = true;
                }
            }
            else
            {
                stopscanner.Attributes["class"] = "disconnected";


                if (stop_sensorstatus == true)
                {
                    loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stop rozłączony");
                    stop_sensorstatus = false;
                }
            }

            if (statusReport.tactSensorConnected == true)
            {
                tactscanner.Attributes["class"] = "connected";

                if (tact_sensorstatus == false)
                {
                    loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik taktu połączony");

                    tact_sensorstatus = true;
                }
            }
            else
            {
                tactscanner.Attributes["class"] = "disconnected";


                if (tact_sensorstatus == true)
                {
                    loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik taktu rozłączony");
                    tact_sensorstatus = false;
                }
            }

            if (statusReport.LenghttSensorConnected == true)
            {
                lenghtscanner.Attributes["class"] = "connected";

                if (lenght_sensorstatus == false)
                {
                    loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik długości połączony");

                    lenght_sensorstatus = true;
                }
            }
            else
            {
                lenghtscanner.Attributes["class"] = "disconnected";

                if (lenght_sensorstatus == true)
                {
                    loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik długości rozłączony");

                    lenght_sensorstatus = false;
                }
            }

            if (statusReport.SignalingConnected == true)
            {
                signaling.Attributes["class"] = "connected";

                if (signaling_sensorstatus == false)
                {
                    loglist.Items.Insert(0, DateTime.Now + " " + "Sterownik sygnalizacji połączony");

                    signaling_sensorstatus = true;
                }
            }
            else
            {
                signaling.Attributes["class"] = "disconnected";

                if (signaling_sensorstatus == true)
                {
                    loglist.Items.Insert(0, DateTime.Now + " " + "Sterownik sygnalizacji rozłączony");

                    signaling_sensorstatus = false;
                }
            }

            if (statusReport.Scanner1Connected == true)
            {
                scanner1.Attributes["class"] = "connected";

                if (scanner_sensorstatus == false)
                {
                    loglist.Items.Insert(0, DateTime.Now + " " + "Skaner nr 1 połączony");

                    scanner_sensorstatus = true;
                }
            }
            else
            {
                scanner1.Attributes["class"] = "disconnected";

                if (scanner_sensorstatus == true)
                {
                    loglist.Items.Insert(0, DateTime.Now + " " + "Skaner nr 1 rozłączony");

                    scanner_sensorstatus = false;
                }
            }

                if (statusReport.rfidTactSensorConnected == true)
                {
                    Div1.Attributes["class"] = "connected";

                    if (rfidtactsensor_status == false)
                    {
                        loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik tacek połączony");

                        rfidtactsensor_status = true;
                    }
                }
                else
                {
                    Div1.Attributes["class"] = "disconnected";

                    if (rfidtactsensor_status == true)
                    {
                        loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik tacek rozłączony");

                        rfidtactsensor_status = false;
                    }
                }





                if (statusReport.rfidReaderConnected_1 == true)
                {
                    Div2.Attributes["class"] = "connected";

                    if (stand1_status == false)
                    {
                        loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 1 połączony");

                        stand1_status = true;
                    }
                }
                else
                {
                    Div2.Attributes["class"] = "disconnected";

                    if (stand1_status == true)
                    {
                        loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 1 rozłączony");

                        stand1_status = false;
                    }
                }



                if (statusReport.rfidReaderConnected_2 == true)
                {
                    Div3.Attributes["class"] = "connected";

                    if (stand2_status == false)
                    {
                        loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 2 połączony");

                        stand2_status = true;
                    }
                }
                else
                {
                    Div3.Attributes["class"] = "disconnected";

                    if (stand2_status == true)
                    {
                        loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 2 rozłączony");

                        stand2_status = false;
                    }
                }


                if (statusReport.rfidReaderConnected_3 == true)
                {
                    Div4.Attributes["class"] = "connected";

                    if (stand3_status == false)
                    {
                        loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 3 połączony");

                        stand3_status = true;
                    }
                }
                else
                {
                    Div4.Attributes["class"] = "disconnected";

                    if (stand3_status == true)
                    {
                        loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 3 rozłączony");

                        stand3_status = false;
                    }
                }


                if (statusReport.rfidReaderConnected_4 == true)
                {
                    Div5.Attributes["class"] = "connected";

                    if (stand4_status == false)
                    {
                        loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 4 połączony");

                        stand4_status = true;
                    }
                }
                else
                {
                    Div5.Attributes["class"] = "disconnected";

                    if (stand4_status == true)
                    {
                        loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 4 rozłączony");

                        stand4_status = false;
                    }
                }


                if (statusReport.rfidReaderConnected_5 == true)
                {
                    Div6.Attributes["class"] = "connected";

                    if (stand5_status == false)
                    {
                        loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 5 połączony");

                        stand5_status = true;
                    }
                }
                else
                {
                    Div6.Attributes["class"] = "disconnected";

                    if (stand5_status == true)
                    {
                        loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 5 rozłączony");

                        stand5_status = false;
                    }
                }


                if (statusReport.rfidReaderConnected_6 == true)
                {
                    Div7.Attributes["class"] = "connected";

                    if (stand6_status == false)
                    {
                        loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 6 połączony");

                        stand6_status = true;
                    }
                }
                else
                {
                    Div7.Attributes["class"] = "disconnected";

                    if (stand6_status == true)
                    {
                        loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 6 rozłączony");

                        stand6_status = false;
                    }
                }




                if (statusReport.rfidReaderConnected_7 == true)
                {
                    Div8.Attributes["class"] = "connected";

                    if (stand7_status == false)
                    {
                        loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 7 połączony");

                        stand7_status = true;
                    }
                }
                else
                {
                    Div8.Attributes["class"] = "disconnected";

                    if (stand7_status == true)
                    {
                        loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 7 rozłączony");

                        stand7_status = false;
                    }
                }




                if (statusReport.rfidReaderConnected_8 == true)
                {
                    Div9.Attributes["class"] = "connected";

                    if (stand8_status == false)
                    {
                        loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 8 połączony");

                        stand8_status = true;
                    }
                }
                else
                {
                    Div9.Attributes["class"] = "disconnected";

                    if (stand8_status == true)
                    {
                        loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 8 rozłączony");

                        stand8_status = false;
                    }
                }




                if (statusReport.rfidReaderConnected_9 == true)
                {
                    Div10.Attributes["class"] = "connected";

                    if (stand9_status == false)
                    {
                        loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 9 połączony");

                        stand9_status = true;
                    }
                }
                else
                {
                    Div10.Attributes["class"] = "disconnected";

                    if (stand9_status == true)
                    {
                        loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 9 rozłączony");

                        stand9_status = false;
                    }
                }






                if (statusReport.rfidReaderConnected_10 == true)
                {
                    Div11.Attributes["class"] = "connected";

                    if (stand10_status == false)
                    {
                        loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 10 połączony");

                        stand10_status = true;
                    }
                }
                else
                {
                    Div11.Attributes["class"] = "disconnected";

                    if (stand10_status == true)
                    {
                        loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 10 rozłączony");

                        stand10_status = false;
                    }
                }




                if (statusReport.rfidReaderConnected_11 == true)
                {
                    Div12.Attributes["class"] = "connected";

                    if (stand11_status == false)
                    {
                        loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 11 połączony");

                        stand11_status = true;
                    }
                }
                else
                {
                    Div12.Attributes["class"] = "disconnected";

                    if (stand11_status == true)
                    {
                        loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 11 rozłączony");

                        stand11_status = false;
                    }
                }


                if (statusReport.rfidReaderConnected_12 == true)
                {
                    Div13.Attributes["class"] = "connected";

                    if (stand12_status == false)
                    {
                        loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 12 połączony");

                        stand12_status = true;
                    }
                }
                else
                {
                    Div13.Attributes["class"] = "disconnected";

                    if (stand12_status == true)
                    {
                        loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 12 rozłączony");

                        stand12_status = false;
                    }
                }



                if (statusReport.rfidReaderConnected_13 == true)
                {
                    Div90.Attributes["class"] = "connected";

                    if (stand13_status == false)
                    {
                        loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 13 połączony");

                        stand13_status = true;
                    }
                }
                else
                {
                    Div90.Attributes["class"] = "disconnected";

                    if (stand13_status == true)
                    {
                        loglist.Items.Insert(0, DateTime.Now + " " + "Czujnik stanowiska 13 rozłączony");

                        stand13_status = false;
                    }
                }

                ViewState["machine"] = machine_status;
            ViewState["start_sensorstatus"] = start_sensorstatus;
            ViewState["stop_sensorstatus"] = stop_sensorstatus;
            ViewState["tact_sensorstatus"] = tact_sensorstatus;
            ViewState["signaling_sensorstatus"] = signaling_sensorstatus;
            ViewState["scanner_sensorstatus"] = scanner_sensorstatus;
            ViewState["lenght_sensorstatus"] = lenght_sensorstatus;


            if (statusReport.currentshift == null)
            {
                statusReport.currentshift = new ShiftType();
            }
            else
            {
                if (statusReport.currentshift.IsOpen() == true)
                {
                    Button1.Text = "Stop Przebiegu";
                }
                else
                {
                    Button1.Text = "Start przebiegu";
                }
            }

                lboccupiedplatescount.Text = statusReport.occupiedplates.ToString() ;
                lboccupiedplatespercentage.Text = statusReport.occupiedplatespercentage.ToString() + "%";
            lbShift.Text = "Przebieg: " + statusReport.currentshift.ShiftStart;

            labelBuffer.Text = "Bufor: " + statusReport.ParcelInBuffer;
            LabelLine.Text = "Na linii: " + statusReport.ParcelsAtLine;

            DataTable dt = new DataTable();
            dt.Columns.Add("kierunek");
            dt.Columns.Add("sorted");
            dt.Columns.Add("mised");

            foreach (var s in statusReport.StandsStats)
            {

                dt.Rows.Add(s.Name, s.SortedParcels, s.MissedParcels);
            }

            this.chart1.Series.Clear();
            //this.chart1.DataBindCrossTable(dt.Rows, "kierunek", "mised", "sorted", "");

            chart1.Series.Add("Podzielone");
            chart1.Series[0].XValueMember = "kierunek";
            chart1.Series[0].YValueMembers = "sorted";
            chart1.Series[0].IsValueShownAsLabel = true;

            chart1.Series.Add("Przepuszczone");
            chart1.Series[1].XValueMember = "kierunek";
            chart1.Series[1].YValueMembers = "mised";
            chart1.Series[1].IsValueShownAsLabel = true;

            chart1.ChartAreas["ChartArea1"].AxisX.Title = "Kierunek";
            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            chart1.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Sans Serif", 10, FontStyle.Bold);
            chart1.ChartAreas["ChartArea1"].AxisY.Title = "Liczba przesyłek";
            chart1.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Sans Serif", 10, FontStyle.Bold);

            foreach (var s in this.chart1.Series)
            {
                s.ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.StackedColumn;
            }

            chart1.DataSource = dt;
            chart1.DataBind();
        }
    }

    protected void Button1_Click1(object sender, EventArgs e)
        {
            StatusReportType statusReport = StatusReportType.FromJson(SendToserverAndGetResponse("GetStatusReport"));
            if (statusReport != null)
            {
                if (statusReport.currentshift == null)
                {
                    statusReport.currentshift = new ShiftType();
                }
                if (statusReport.currentshift.IsOpen() == true)
                {
                    SendToserverAndGetResponse("StopRun");
                
                }
                else
                {

                    SendToserverAndGetResponse("StartRun");
                }
            }



        }

        protected void Timer2_Tick(object sender, EventArgs e)
        {
            SendToserverAndGetResponse("CheckDevices");
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            SendToserverAndGetResponse("CheckDevices");
        }
    }
}