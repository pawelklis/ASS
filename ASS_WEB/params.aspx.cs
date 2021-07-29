using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASS;
using SimpleTCP;

namespace ASS_WEB
{
    public partial class _params : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }

        void Bind()
        {
            Dicts dicts = Dicts.GetData();

            if (dicts.WorkdetectionIntervalMS < 0)
                dicts.WorkdetectionIntervalMS = 100;

            numwork.Text = dicts.WorkdetectionIntervalMS.ToString();
            numalltacts.Text = dicts.AllTactsCount.ToString();
            ckturnofftimer.Checked = dicts.TurnOffLampByTimer;
            checkBox1.Checked = dicts.CorrectDisposedMarkers;
            numparcelfactor.Text = dicts.ParcelLenghtFactor.ToString();
            numtactlenghtcm.Text = dicts.BetweenMarkresSpaceCM.ToString();
            numstopcorection.Text = dicts.StopCorrection.ToString();
            txCamAdres.Text = dicts.CamAdress1;
            ckautowork.Checked = dicts.AutoWorkdetectioninterval;
            txCamadres2.Text = dicts.CamAdress2;
            numSTOPTacts.Text = dicts.StopSensorTactsCount.ToString();
            ckblack1.Checked = dicts.blackCam1;
            ckBlack2.Checked = dicts.blackCam2;
            numzum1.Text = dicts.cam1zoom.ToString();
            numzum2.Text = dicts.cam2zoom.ToString();

            ddlstart.SelectedValue = dicts.StartSensorPort;
            ddlstop.SelectedValue = dicts.StopSensorPort;
            ddltact.SelectedValue = dicts.TactSensorPort;
            ddllenght.SelectedValue = dicts.LenghtSensorPort;
            ddlsignaling.SelectedValue = dicts.SignalingPort;
            ddlscanner1.SelectedValue = dicts.Scanner1Port;
            ddlrfidtactport.SelectedValue = dicts.rfidTactSensorPort;

            txstartspeed.Text = dicts.StartSensorSpeed.ToString();
            txstopspeed.Text = dicts.StopSensorSpeed.ToString();
            txtactspeed.Text = dicts.TactSensorSpeed.ToString();
            txlenghtspeed.Text = dicts.LenghtSensorSpeed.ToString();
            txsignalspeed.Text = dicts.SignalingSpeed.ToString();
            txscanner1speed.Text = dicts.Scanner1Speed.ToString();
            txrfidtactspeed.Text = dicts.rfidTactSensorSpeed.ToString();

            txstartdelay.Text = dicts.StartSensorDelay.ToString();
            txstopdelay.Text = dicts.StopSensorDelay.ToString();
            txtactdelay.Text = dicts.TactSensorDelay.ToString();
            txlenghtdelay.Text = dicts.LenghtSensorDelay.ToString();
            txsignalingdelay.Text = dicts.SignalingDelay.ToString();
            txscanner1delay.Text = dicts.Scanner1Delay.ToString();
            txrfidtactdelay.Text = dicts.rfidTactSensorDelay.ToString();


            ddltractionPort1.SelectedValue = dicts.rfidReader_Port1;
            ddltractionPort2.SelectedValue = dicts.rfidReader_Port2;
            ddltractionPort3.SelectedValue = dicts.rfidReader_Port3;
            ddltractionPort4.SelectedValue = dicts.rfidReader_Port4;
            ddltractionPort5.SelectedValue = dicts.rfidReader_Port5;
            ddltractionPort6.SelectedValue = dicts.rfidReader_Port6;
            ddltractionPort7.SelectedValue = dicts.rfidReader_Port7;
            ddltractionPort8.SelectedValue = dicts.rfidReader_Port8;
            ddltractionPort9.SelectedValue = dicts.rfidReader_Port9;
            ddltractionPort10.SelectedValue = dicts.rfidReader_Port10;
            ddltractionPort11.SelectedValue = dicts.rfidReader_Port11;
            ddltractionPort12.SelectedValue = dicts.rfidReader_Port12;
            ddltractionPort13.SelectedValue = dicts.rfidReader_Port13;

            txTractionSpeed1.Text = dicts.rfidReader_Speed1.ToString();
            txTractionSpeed2.Text = dicts.rfidReader_Speed2.ToString();
            txTractionSpeed3.Text = dicts.rfidReader_Speed3.ToString();
            txTractionSpeed4.Text = dicts.rfidReader_Speed4.ToString();
            txTractionSpeed5.Text = dicts.rfidReader_Speed5.ToString();
            txTractionSpeed6.Text = dicts.rfidReader_Speed6.ToString();
            txTractionSpeed7.Text = dicts.rfidReader_Speed7.ToString();
            txTractionSpeed8.Text = dicts.rfidReader_Speed8.ToString();
            txTractionSpeed9.Text = dicts.rfidReader_Speed9.ToString();
            txTractionSpeed10.Text = dicts.rfidReader_Speed10.ToString();
            txTractionSpeed11.Text = dicts.rfidReader_Speed11.ToString();
            txTractionSpeed12.Text = dicts.rfidReader_Speed12.ToString();
            txTractionSpeed13.Text = dicts.rfidReader_Speed13.ToString();

            txTractionDelay1.Text = dicts.rfidReader_Delay1.ToString();
            txTractionDelay2.Text = dicts.rfidReader_Delay2.ToString();
            txTractionDelay3.Text = dicts.rfidReader_Delay3.ToString();
            txTractionDelay4.Text = dicts.rfidReader_Delay4.ToString();
            txTractionDelay5.Text = dicts.rfidReader_Delay5.ToString();
            txTractionDelay6.Text = dicts.rfidReader_Delay6.ToString();
            txTractionDelay7.Text = dicts.rfidReader_Delay7.ToString();
            txTractionDelay8.Text = dicts.rfidReader_Delay8.ToString();
            txTractionDelay9.Text = dicts.rfidReader_Delay9.ToString();
            txTractionDelay10.Text = dicts.rfidReader_Delay10.ToString();
            txTractionDelay11.Text = dicts.rfidReader_Delay11.ToString();
            txTractionDelay12.Text = dicts.rfidReader_Delay12.ToString();
            txTractionDelay13.Text = dicts.rfidReader_Delay13.ToString();


            CheckBox2.Checked = dicts.StartSensorIsON;
            CheckBox3.Checked = dicts.StopSensorIsON;
            CheckBox4.Checked = dicts.TactSensorIsON;
            CheckBox5.Checked = dicts.LenghtSensorIsON;
            CheckBox6.Checked = dicts.SignalingIsON;
            CheckBox7.Checked = dicts.Scanner1IsON;
            CheckBox8.Checked = dicts.rfidTactSensorIsON;

            CheckBox10.Checked = dicts.rfidReader_IsON1;
            CheckBox11.Checked = dicts.rfidReader_IsON2;
            CheckBox12.Checked = dicts.rfidReader_IsON3;
            CheckBox13.Checked = dicts.rfidReader_IsON4;
            CheckBox14.Checked = dicts.rfidReader_IsON5;
            CheckBox15.Checked = dicts.rfidReader_IsON6;
            CheckBox16.Checked = dicts.rfidReader_IsON7;
            CheckBox17.Checked = dicts.rfidReader_IsON8;
            CheckBox18.Checked = dicts.rfidReader_IsON9;
            CheckBox19.Checked = dicts.rfidReader_IsON10;
            CheckBox20.Checked = dicts.rfidReader_IsON11;
            CheckBox21.Checked = dicts.rfidReader_IsON12;
            CheckBox22.Checked = dicts.rfidReader_IsON13;

            txplateidlenght.Text = dicts.plateIendtityLenght.ToString();


            CheckBox23.Checked = dicts.rfidTactSensorTacting;
            CheckBox24.Checked = dicts.TactSensorSimulatePlates;
        }

        void Save()
        {
            Dicts dicts = Dicts.GetData();

            dicts.WorkdetectionIntervalMS = int.Parse(numwork.Text);
            dicts.AllTactsCount = int.Parse(numalltacts.Text);
            dicts.TurnOffLampByTimer = ckturnofftimer.Checked;
            dicts.CorrectDisposedMarkers = checkBox1.Checked;
            dicts.ParcelLenghtFactor = int.Parse(numparcelfactor.Text);
            dicts.BetweenMarkresSpaceCM = int.Parse(numtactlenghtcm.Text);
            dicts.StopCorrection = int.Parse(numstopcorection.Text);
            dicts.CamAdress1 = txCamAdres.Text;
            dicts.AutoWorkdetectioninterval = ckautowork.Checked;
            dicts.CamAdress2 = txCamadres2.Text;
            dicts.StopSensorTactsCount = int.Parse(numSTOPTacts.Text);
            dicts.blackCam1 = ckblack1.Checked;
            dicts.blackCam2 = ckBlack2.Checked;
            dicts.cam1zoom = int.Parse(numzum1.Text);
            dicts.cam2zoom = int.Parse(numzum2.Text);

            dicts.plateIendtityLenght = int.Parse(txplateidlenght.Text);
         

            dicts.StartSensorPort = ddlstart.SelectedValue;
            dicts.StopSensorPort = ddlstop.SelectedValue;
            dicts.TactSensorPort = ddltact.SelectedValue;
            dicts.LenghtSensorPort = ddllenght.SelectedValue;
            dicts.SignalingPort = ddlsignaling.SelectedValue;
            dicts.Scanner1Port = ddlscanner1.SelectedValue;
            dicts.rfidTactSensorPort = ddlrfidtactport.SelectedValue;

            dicts.StartSensorSpeed = int.Parse(txstartspeed.Text);
            dicts.StopSensorSpeed = int.Parse(txstopspeed.Text);
            dicts.TactSensorSpeed = int.Parse(txtactspeed.Text);
            dicts.LenghtSensorSpeed = int.Parse(txlenghtspeed.Text);
            dicts.SignalingSpeed = int.Parse(txsignalspeed.Text);
            dicts.Scanner1Speed = int.Parse(txscanner1speed.Text);
            dicts.rfidTactSensorSpeed = int.Parse(txrfidtactspeed.Text);

            dicts.StartSensorDelay = int.Parse(txstartdelay.Text);
            dicts.StopSensorDelay = int.Parse(txstopdelay.Text);
            dicts.TactSensorDelay = int.Parse(txtactdelay.Text);
            dicts.LenghtSensorDelay = int.Parse(txlenghtdelay.Text);
            dicts.SignalingDelay = int.Parse(txsignalingdelay.Text);
            dicts.Scanner1Delay = int.Parse(txscanner1delay.Text);
            dicts.rfidTactSensorDelay = int.Parse(txrfidtactdelay.Text);

            dicts.rfidReader_Port1 = ddltractionPort1.SelectedValue;
            dicts.rfidReader_Port2 = ddltractionPort2.SelectedValue;
            dicts.rfidReader_Port3 = ddltractionPort3.SelectedValue;
            dicts.rfidReader_Port4 = ddltractionPort4.SelectedValue;
            dicts.rfidReader_Port5 = ddltractionPort5.SelectedValue;
            dicts.rfidReader_Port6 = ddltractionPort6.SelectedValue;
            dicts.rfidReader_Port7 = ddltractionPort7.SelectedValue;
            dicts.rfidReader_Port8 = ddltractionPort8.SelectedValue;
            dicts.rfidReader_Port9 = ddltractionPort9.SelectedValue;
            dicts.rfidReader_Port10 = ddltractionPort10.SelectedValue;
            dicts.rfidReader_Port11 = ddltractionPort11.SelectedValue;
            dicts.rfidReader_Port12 = ddltractionPort12.SelectedValue;
            dicts.rfidReader_Port13 = ddltractionPort13.SelectedValue;

            dicts.rfidReader_Speed1 = int.Parse(txTractionSpeed1.Text);
            dicts.rfidReader_Speed2 = int.Parse(txTractionSpeed2.Text);
            dicts.rfidReader_Speed3 = int.Parse(txTractionSpeed3.Text);
            dicts.rfidReader_Speed4 = int.Parse(txTractionSpeed4.Text);
            dicts.rfidReader_Speed5 = int.Parse(txTractionSpeed5.Text);
            dicts.rfidReader_Speed6 = int.Parse(txTractionSpeed6.Text);
            dicts.rfidReader_Speed7 = int.Parse(txTractionSpeed7.Text);
            dicts.rfidReader_Speed8 = int.Parse(txTractionSpeed8.Text);
            dicts.rfidReader_Speed9 = int.Parse(txTractionSpeed9.Text);
            dicts.rfidReader_Speed10 = int.Parse(txTractionSpeed10.Text);
            dicts.rfidReader_Speed11 = int.Parse(txTractionSpeed11.Text);
            dicts.rfidReader_Speed12 = int.Parse(txTractionSpeed12.Text);
            dicts.rfidReader_Speed13 = int.Parse(txTractionSpeed13.Text);
            dicts.rfidReader_Delay1 = int.Parse(txTractionDelay1.Text);
            dicts.rfidReader_Delay2 = int.Parse(txTractionDelay2.Text);
            dicts.rfidReader_Delay3 = int.Parse(txTractionDelay3.Text);
            dicts.rfidReader_Delay4 = int.Parse(txTractionDelay4.Text);
            dicts.rfidReader_Delay5 = int.Parse(txTractionDelay5.Text);
            dicts.rfidReader_Delay6 = int.Parse(txTractionDelay6.Text);
            dicts.rfidReader_Delay7 = int.Parse(txTractionDelay7.Text);
            dicts.rfidReader_Delay8 = int.Parse(txTractionDelay8.Text);
            dicts.rfidReader_Delay9 = int.Parse(txTractionDelay9.Text);
            dicts.rfidReader_Delay10 = int.Parse(txTractionDelay10.Text);
            dicts.rfidReader_Delay11 = int.Parse(txTractionDelay11.Text);
            dicts.rfidReader_Delay12 = int.Parse(txTractionDelay12.Text);
            dicts.rfidReader_Delay13 = int.Parse(txTractionDelay13.Text);

            dicts.StartSensorIsON = CheckBox2.Checked;
            dicts.StopSensorIsON = CheckBox3.Checked;
            dicts.TactSensorIsON = CheckBox4.Checked;
            dicts.LenghtSensorIsON = CheckBox5.Checked;
            dicts.SignalingIsON = CheckBox6.Checked;
            dicts.Scanner1IsON = CheckBox7.Checked;
            dicts.rfidTactSensorIsON = CheckBox8.Checked;

            dicts.rfidReader_IsON1 = CheckBox10.Checked;
            dicts.rfidReader_IsON2 = CheckBox11.Checked;
            dicts.rfidReader_IsON3 = CheckBox12.Checked;
            dicts.rfidReader_IsON4 = CheckBox13.Checked;
            dicts.rfidReader_IsON5 = CheckBox14.Checked;
            dicts.rfidReader_IsON6 = CheckBox15.Checked;
            dicts.rfidReader_IsON7 = CheckBox16.Checked;
            dicts.rfidReader_IsON8 = CheckBox17.Checked;
            dicts.rfidReader_IsON9 = CheckBox18.Checked;
            dicts.rfidReader_IsON10 = CheckBox19.Checked;
            dicts.rfidReader_IsON11 = CheckBox20.Checked;
            dicts.rfidReader_IsON12 = CheckBox21.Checked;
            dicts.rfidReader_IsON13 = CheckBox22.Checked;

            dicts.rfidTactSensorTacting = CheckBox23.Checked;

            dicts.TactSensorSimulatePlates = CheckBox24.Checked;


            dicts.Save();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            SendToserverAndGetResponse("refreshDicts");
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
                return response;
            }
            catch (Exception ex)
            {

            }
            return "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SendToserverAndGetResponse("LightTestOn");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SendToserverAndGetResponse("LightTestOff");
        }
    }
}