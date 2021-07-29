using ASS.devices;
using ASS.ServiceReference2;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using SimpleTCP;
using System.Data;
using System.Reflection;

namespace ASS
{
    public class CarouselType
    {
        public static string Path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ASSCore\";
        public static string FileName = "ASS.json";

        public SimpleTcpServer data_server;
        Task DataServerTask;
        Timer DeviceTimer { get; set; }
        public StatusReportType StatReport { get; set; }
        public bool Isworking { get; set; }
        public StartSensorType StartSensor { get; set; }
        public StopSensorType StopSensor { get; set; }
        public TactSensorType TactSensor { get; set; }
        public LenghtSensorType LenghtSensor { get; set; }
        public ScannerType Scanner1 { get; set; }
        public SignalingType Signaling { get; set; }
        public RFIDTactSensorType RFIDTactSensor { get; set; }
        public CamScannerType CamScanner { get; set; }
        public CamScannerType CamScanner2 { get; set; }
        public RFIDReaderType rfidReader1 { get; set; }
        public RFIDReaderType rfidReader2 { get; set; }
        public RFIDReaderType rfidReader3 { get; set; }
        public RFIDReaderType rfidReader4 { get; set; }
        public RFIDReaderType rfidReader5 { get; set; }
        public RFIDReaderType rfidReader6 { get; set; }
        public RFIDReaderType rfidReader7 { get; set; }
        public RFIDReaderType rfidReader8 { get; set; }
        public RFIDReaderType rfidReader9 { get; set; }
        public RFIDReaderType rfidReader10 { get; set; }
        public RFIDReaderType rfidReader11 { get; set; }
        public RFIDReaderType rfidReader12 { get; set; }
        public RFIDReaderType rfidReader13 { get; set; }
        public bool isready { get; set; }
        public List<ParcelType> ParcelsBuffer { get; set; }
        public List<ParcelType> ParcelsOnRun { get; set; }
        private Timer TimerWorkDetection { get; set; }
        public Dicts Dicts { get; set; }
        private bool SetLenght { get; set; }
        private Timer TimerConnectDevices { get; set; }
        public ShiftType CurrentShift { get; set; }
        DateTime LastTick { get; set; }

        public int mysqlcommandCount { get; set; }

        private DataTable dtlogs { get; set; }

        List<tactLogType> tactslogs { get; set; }


        #region "Events"
        public EventHandler<SerialPortDevice.SerialPortEventArgs> OnStopSensorRead;
        public EventHandler<ParcelType.ParcelEventArgs> OnParcelError;
        public EventHandler<ParcelType.ParcelEventArgs> OnParcelDataOK;

        public EventHandler CarouselTacted;
        public EventHandler CarouselTimer;

        #endregion


     
        public CarouselType()
        {
            dtlogs = new DataTable();
            dtlogs.Columns.Add("method");
            dtlogs.Columns.Add("tactcount");
            dtlogs.Columns.Add("count", typeof(int));
            
            //AddLog(MethodBase.GetCurrentMethod().Name);

            Dicts = new Dicts();
            ParcelsBuffer = new List<ParcelType>();
            ParcelsOnRun = new List<ParcelType>();

            CurrentShift = new ShiftType();
            StatReport = new StatusReportType();

            mySQLcore.OnConnection += OnMysqlCommand;

            DeviceTimer = new Timer();
            DeviceTimer.Interval = 2000;
            DeviceTimer.Elapsed += DeviceTimerElapsed;
            DeviceTimer.Start();
        }
        void DeviceTimerElapsed(object sender, EventArgs e)
        {
            Task.Run(() => CheckDevices());
           if(Isworking==false)
                PrintAsync("", "", "", "", "", "");

            EventHandler ev = CarouselTimer;
            EventArgs ee = new EventArgs();
            ev?.Invoke(this, ee);
        }
        void OnMysqlCommand(object sender,EventArgs e)
        {
            mysqlcommandCount += 1;
        }


        #region "SaveLoad"
        private void CheckPath()
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            if (!Directory.Exists(Path))
                Directory.CreateDirectory(Path);
        }
        public static CarouselType Load()
        {

            if (File.Exists(Path + FileName))
            {
                string str = File.ReadAllText(Path + FileName, Encoding.GetEncoding(1250));

                //str = str.Replace("\"MissedParcelsCount\":[]", "\"MissedParcelsCount\":0");

                Dicts dicts = JsonConvert.DeserializeObject<Dicts>(str);

                //dicts.Save();

                CarouselType carousel = new CarouselType();
                carousel.Dicts = Dicts.GetData(); //dicts;

                //carousel.Dicts.Save();
                //carousel.Save();

                foreach (var s in dicts.Stands)
                {
                    if (s.StandItem1.Direction == null)
                        s.StandItem1.Direction = new DirectionType { Name = "" };

                    if (s.StandItem2.Direction == null)
                        s.StandItem2.Direction = new DirectionType { Name = "" };

                    if (s.StandItem3.Direction == null)
                        s.StandItem3.Direction = new DirectionType { Name = "" };

                    if (s.StandItem4.Direction == null)
                        s.StandItem4.Direction = new DirectionType { Name = "" };
                }


                return carousel;
            }
            else
            {
                CarouselType carousel = new CarouselType();
                return carousel;
            }

        }
        public void Save()
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            CheckPath();
            string str = JsonConvert.SerializeObject(this.Dicts);
            File.WriteAllText(Path + FileName, str, Encoding.GetEncoding(1250));

            Dicts.Save();
        }

        #endregion

        #region "Carousel"
        void ClearPlates()
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            //Dicts.Plates = new List<PlateType>();
        }
        void StartDataServer()
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            data_server = new SimpleTcpServer();
            data_server.Delimiter = 0x13;
            data_server.StringEncoder = Encoding.UTF8;            
            data_server.DataReceived += Server_DataReceived;
            System.Net.IPAddress ip = System.Net.IPAddress.Parse("127.0.0.1");
            data_server.Start(ip, Convert.ToInt32("4444"));
        }

        public int TCPReadCount { get; set; }
        public int TCPWriteCount { get; set; }

        private void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            TCPReadCount += 1;
            
            string msg = e.MessageString.Replace("\u0013", "");
            Task.Run(() => TCPAfterRead(msg));
          
        }

        public double OccupiedPlatesCT()
        {
            int op = (from p in ParcelsOnRun
                      select p.OccupiedPlates).Sum();
            return op;
        }
        public double Occupiedplatespercent()
        {
            double opp = (double)OccupiedPlatesCT() / (double)Dicts.AllTactsCount;
            return Math.Round(opp * 100, 2); ;
        }

        public void SetStatusReport()
        {
            StatReport.Scanner1Connected = Scanner1.PortRS232.IsOpen();
            StatReport.StartSensorConnected = StartSensor.PortRS232.IsOpen();
            StatReport.StopSensorConnected = StopSensor.PortRS232.IsOpen();
            StatReport.tactSensorConnected = TactSensor.PortRS232.IsOpen();
            StatReport.LenghttSensorConnected = LenghtSensor.PortRS232.IsOpen();
            StatReport.SignalingConnected = Signaling.PortRS232.IsOpen();

            StatReport.rfidReaderConnected_1 = rfidReader1.PortRS232.IsOpen();
            StatReport.rfidReaderConnected_2 = rfidReader2.PortRS232.IsOpen();
            StatReport.rfidReaderConnected_3 = rfidReader3.PortRS232.IsOpen();
            StatReport.rfidReaderConnected_4 = rfidReader4.PortRS232.IsOpen();
            StatReport.rfidReaderConnected_5 = rfidReader5.PortRS232.IsOpen();
            StatReport.rfidReaderConnected_6 = rfidReader6.PortRS232.IsOpen();
            StatReport.rfidReaderConnected_7 = rfidReader7.PortRS232.IsOpen();
            StatReport.rfidReaderConnected_8 = rfidReader8.PortRS232.IsOpen();
            StatReport.rfidReaderConnected_9 = rfidReader9.PortRS232.IsOpen();
            StatReport.rfidReaderConnected_10 = rfidReader10.PortRS232.IsOpen();
            StatReport.rfidReaderConnected_11 = rfidReader11.PortRS232.IsOpen();
            StatReport.rfidReaderConnected_12 = rfidReader12.PortRS232.IsOpen();
            StatReport.rfidReaderConnected_13 = rfidReader13.PortRS232.IsOpen();


            StatReport.ParcelInBuffer = ParcelsBuffer.Count;
            StatReport.ParcelsAtLine = ParcelsOnRun.Count;



            StatReport.occupiedplates = (int)OccupiedPlatesCT();


            StatReport.occupiedplatespercentage = Occupiedplatespercent();


            StatReport.CarouselWorking = Isworking;
            StatReport.DevicesCanRun = isready;

            StatReport.currentplate = RFIDTactSensor.CurrentReadedPlateID;
            StatReport.nextplate = RFIDTactSensor.NextPlateID();

            StatReport.parcelsOnRunTable = ParcelsOnRunTable();

            StatReport.MachineStatusReady = false;



            StatReport.MachineStatusReady = isready;


            StatReport.currentshift = CurrentShift;
        }

        public void StartRun()
        {
                StartShift();
                StatReport.currentshift = CurrentShift;
                data_server.Broadcast(StatReport.toJson());
                TCPWriteCount += 1;
        }
        public void StopRun()
        {
            if (ParcelsBuffer.Count > 0)
                return;
            if (ParcelsOnRun.Count > 0)
                return;

                StopShift();
                StatReport.currentshift = CurrentShift;
                data_server.Broadcast(StatReport.toJson());
                TCPWriteCount += 1;
        }

        private void TCPAfterRead(string msg)
        {
            if (msg == "CheckDevices")
            {
                Task.Run(() => IsReady());
            }
            if (msg == "GetStatusReport")
            {

                SetStatusReport();
                data_server.Broadcast(StatReport.toJson());
                TCPWriteCount += 1;

            }
            if (msg == "StartRun")
            {
                StartRun();
            }
            if (msg == "StopRun")
            {
                StopRun();
            }
            if (msg == "refreshDicts")
            {
                int roundnumber = Dicts.RoundNumber;
                this.Dicts = Dicts.GetData();
                this.Dicts.RoundNumber = roundnumber;

                RFIDTactSensor.Tacting = Dicts.rfidTactSensorTacting;
                RFIDTactSensor.PortRS232.isOn = Dicts.rfidTactSensorIsON;
                RFIDTactSensor.plates = Dicts.Plates;

                StartSensor.PortRS232.isOn = Dicts.StartSensorIsON;
                StopSensor.PortRS232.isOn = Dicts.StopSensorIsON;
                TactSensor.PortRS232.isOn = Dicts.TactSensorIsON;
                LenghtSensor.PortRS232.isOn = Dicts.LenghtSensorIsON;
                Signaling.PortRS232.isOn = Dicts.SignalingIsON;
                Scanner1.PortRS232.isOn = Dicts.Scanner1IsON;
                rfidReader1.PortRS232.isOn = Dicts.rfidReader_IsON1;
                rfidReader2.PortRS232.isOn = Dicts.rfidReader_IsON2;
                rfidReader3.PortRS232.isOn = Dicts.rfidReader_IsON3;
                rfidReader4.PortRS232.isOn = Dicts.rfidReader_IsON4;
                rfidReader5.PortRS232.isOn = Dicts.rfidReader_IsON5;
                rfidReader6.PortRS232.isOn = Dicts.rfidReader_IsON6;
                rfidReader7.PortRS232.isOn = Dicts.rfidReader_IsON7;
                rfidReader8.PortRS232.isOn = Dicts.rfidReader_IsON8;
                rfidReader9.PortRS232.isOn = Dicts.rfidReader_IsON9;
                rfidReader10.PortRS232.isOn = Dicts.rfidReader_IsON10;
                rfidReader11.PortRS232.isOn = Dicts.rfidReader_IsON11;
                rfidReader12.PortRS232.isOn = Dicts.rfidReader_IsON12;
                rfidReader13.PortRS232.isOn = Dicts.rfidReader_IsON13;

                InitSteportStands();

                data_server.Broadcast(StatReport.toJson());
                TCPWriteCount += 1;
            }
            if (msg == "LightTestOn")
            {
                LightTestOn();
            }
            if (msg == "LightTestOff")
            {
                LightTestOff();
            }
            if (msg.StartsWith("ll"))
            {
                string standname = msg.Split('_')[1];
                string lampNr = msg.Split('_')[2];

                foreach (var s in Dicts.Stands)
                {
                    if (s.Name == standname)
                    {
                        if (lampNr == "111")
                            s.StandItem1.Lamp1.TurnOn(Signaling);
                        if (lampNr == "121")
                            s.StandItem1.Lamp2.TurnOn(Signaling);
                        if (lampNr == "211")
                            s.StandItem2.Lamp1.TurnOn(Signaling);
                        if (lampNr == "221")
                            s.StandItem2.Lamp2.TurnOn(Signaling);
                        if (lampNr == "311")
                            s.StandItem3.Lamp1.TurnOn(Signaling);
                        if (lampNr == "321")
                            s.StandItem3.Lamp2.TurnOn(Signaling);
                        if (lampNr == "411")
                            s.StandItem4.Lamp1.TurnOn(Signaling);
                        if (lampNr == "421")
                            s.StandItem4.Lamp2.TurnOn(Signaling);

                        if (lampNr == "110")
                            s.StandItem1.Lamp1.TurnOff(Signaling);
                        if (lampNr == "120")
                            s.StandItem1.Lamp2.TurnOff(Signaling);
                        if (lampNr == "210")
                            s.StandItem2.Lamp1.TurnOff(Signaling);
                        if (lampNr == "220")
                            s.StandItem2.Lamp2.TurnOff(Signaling);
                        if (lampNr == "310")
                            s.StandItem3.Lamp1.TurnOff(Signaling);
                        if (lampNr == "320")
                            s.StandItem3.Lamp2.TurnOff(Signaling);
                        if (lampNr == "410")
                            s.StandItem4.Lamp1.TurnOff(Signaling);
                        if (lampNr == "420")
                            s.StandItem4.Lamp2.TurnOff(Signaling);
                    }
                }

            }
        }

        public bool IsReady()
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            if (CheckDevices() == true)
            {               
                    isready = true;
                    return true;                
            }
            else
            {
            
            }

            isready = false;
            return false;
        }
        private void LightTestOn()
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            foreach (var s in Dicts.Stands)
            {
                s.StandItem1.Lamp1.TurnOn(Signaling);
                s.StandItem1.Lamp2.TurnOn(Signaling);
                s.StandItem2.Lamp1.TurnOn(Signaling);
                s.StandItem2.Lamp2.TurnOn(Signaling);
                s.StandItem3.Lamp1.TurnOn(Signaling);
                s.StandItem3.Lamp2.TurnOn(Signaling);
                s.StandItem4.Lamp1.TurnOn(Signaling);
                s.StandItem4.Lamp2.TurnOn(Signaling);
            }
        }
        private void LightTestOff()
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            foreach (var s in Dicts.Stands)
            {
                s.StandItem1.Lamp1.TurnOff(Signaling);
                s.StandItem1.Lamp2.TurnOff(Signaling);
                s.StandItem2.Lamp1.TurnOff(Signaling);
                s.StandItem2.Lamp2.TurnOff(Signaling);
                s.StandItem3.Lamp1.TurnOff(Signaling);
                s.StandItem3.Lamp2.TurnOff(Signaling);
                s.StandItem4.Lamp1.TurnOff(Signaling);
                s.StandItem4.Lamp2.TurnOff(Signaling);
            }
        }
        public void TurnOn()
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            ClearPlates();
            Dicts.CurrentTact = 0;

            DataServerTask = new Task(() => StartDataServer());
            DataServerTask.Start();

            tactslogs = new List<tactLogType>();

            StatReport = new StatusReportType();

            ParcelsBuffer = new List<ParcelType>();
            ParcelsOnRun = new List<ParcelType>();

            StartSensor = new StartSensorType();
            
            StartSensor.PortRS232.Connect(Dicts.StartSensorPort,Dicts.StartSensorIsON, Dicts.StartSensorSpeed, Dicts.StartSensorDelay, Dicts.StartSensorName);
            StartSensor.PortRS232.OnRead += StartSensorOnRead;


            StopSensor = new StopSensorType();
            StopSensor.PortRS232.Connect(Dicts.StopSensorPort,Dicts.StopSensorIsON, Dicts.StopSensorSpeed, Dicts.StopSensorDelay, Dicts.StopSensorName);
            StopSensor.PortRS232.OnRead += StopSensorOnRead;


            TactSensor = new TactSensorType();
            TactSensor.PortRS232.Connect(Dicts.TactSensorPort,Dicts.TactSensorIsON, Dicts.TactSensorSpeed, Dicts.TactSensorDelay, Dicts.TactSensorName);
            TactSensor.PortRS232.OnRead += TactSensorOnRead;

            Scanner1 = new ScannerType();
            Scanner1.PortRS232.Connect(Dicts.Scanner1Port,Dicts.Scanner1IsON, Dicts.Scanner1Speed, Dicts.Scanner1Delay, Dicts.Scanner1Name);
            Scanner1.PortRS232.OnRead += Scanner1SensorOnRead;

            Signaling = new SignalingType();
            Signaling.PortRS232.Connect(Dicts.SignalingPort,Dicts.SignalingIsON, Dicts.SignalingSpeed, Dicts.SignalingDelay, Dicts.SignalingName);
            Signaling.PortRS232.OnWrite += SignalingOnWrite;

            LenghtSensor = new LenghtSensorType();
            LenghtSensor.PortRS232.Connect(Dicts.LenghtSensorPort,Dicts.LenghtSensorIsON, Dicts.LenghtSensorSpeed, Dicts.LenghtSensorDelay, Dicts.LenghtSensorName);
            LenghtSensor.PortRS232.OnRead += LenghtensorOnRead;

            RFIDTactSensor = new RFIDTactSensorType(Dicts.Plates);
            RFIDTactSensor.Tacting = Dicts.rfidTactSensorTacting;
            RFIDTactSensor.PortRS232.Connect(Dicts.rfidTactSensorPort,Dicts.rfidTactSensorIsON, Dicts.rfidTactSensorSpeed, Dicts.rfidTactSensorDelay, Dicts.rfidTactSensorName);
            RFIDTactSensor.PortRS232.OnRead += rfidTactSensorOnRead;

            StatReport.StandsStats = new List<StatusReportType.StandStatItem>();

            rfidReader1 = new RFIDReaderType();
            rfidReader1.PortRS232.Connect(Dicts.rfidReader_Port1,Dicts.rfidReader_IsON1, Dicts.rfidReader_Speed1, Dicts.rfidReader_Delay1, Dicts.rfidReader_Name1);
            rfidReader1.PortRS232.OnRead += rfidReader1_OnRead;

            rfidReader2 = new RFIDReaderType();
            rfidReader2.PortRS232.Connect(Dicts.rfidReader_Port2, Dicts.rfidReader_IsON2, Dicts.rfidReader_Speed2, Dicts.rfidReader_Delay2, Dicts.rfidReader_Name2);
            rfidReader2.PortRS232.OnRead += rfidReader2_OnRead;

            rfidReader3 = new RFIDReaderType();
            rfidReader3.PortRS232.Connect(Dicts.rfidReader_Port3, Dicts.rfidReader_IsON3, Dicts.rfidReader_Speed3, Dicts.rfidReader_Delay3, Dicts.rfidReader_Name3);
            rfidReader3.PortRS232.OnRead += rfidReader3_OnRead;

            rfidReader4 = new RFIDReaderType();
            rfidReader4.PortRS232.Connect(Dicts.rfidReader_Port4, Dicts.rfidReader_IsON4, Dicts.rfidReader_Speed4, Dicts.rfidReader_Delay4, Dicts.rfidReader_Name4);
            rfidReader4.PortRS232.OnRead += rfidReader4_OnRead;

            rfidReader5 = new RFIDReaderType();
            rfidReader5.PortRS232.Connect(Dicts.rfidReader_Port5, Dicts.rfidReader_IsON5, Dicts.rfidReader_Speed5, Dicts.rfidReader_Delay5, Dicts.rfidReader_Name5);
            rfidReader5.PortRS232.OnRead += rfidReader5_OnRead;

            rfidReader6 = new RFIDReaderType();
            rfidReader6.PortRS232.Connect(Dicts.rfidReader_Port6, Dicts.rfidReader_IsON6, Dicts.rfidReader_Speed6, Dicts.rfidReader_Delay6, Dicts.rfidReader_Name6);
            rfidReader6.PortRS232.OnRead += rfidReader6_OnRead;

            rfidReader7 = new RFIDReaderType();
            rfidReader7.PortRS232.Connect(Dicts.rfidReader_Port7, Dicts.rfidReader_IsON7, Dicts.rfidReader_Speed7, Dicts.rfidReader_Delay7, Dicts.rfidReader_Name7);
            rfidReader7.PortRS232.OnRead += rfidReader7_OnRead;

            rfidReader8 = new RFIDReaderType();
            rfidReader8.PortRS232.Connect(Dicts.rfidReader_Port8, Dicts.rfidReader_IsON8, Dicts.rfidReader_Speed8, Dicts.rfidReader_Delay8, Dicts.rfidReader_Name8);
            rfidReader8.PortRS232.OnRead += rfidReader8_OnRead;

            rfidReader9 = new RFIDReaderType();
            rfidReader9.PortRS232.Connect(Dicts.rfidReader_Port9, Dicts.rfidReader_IsON9, Dicts.rfidReader_Speed9, Dicts.rfidReader_Delay9, Dicts.rfidReader_Name9);
            rfidReader9.PortRS232.OnRead += rfidReader9_OnRead;

            rfidReader10 = new RFIDReaderType();
            rfidReader10.PortRS232.Connect(Dicts.rfidReader_Port10, Dicts.rfidReader_IsON10, Dicts.rfidReader_Speed10, Dicts.rfidReader_Delay10, Dicts.rfidReader_Name10);
            rfidReader10.PortRS232.OnRead += rfidReader10_OnRead;

            rfidReader11 = new RFIDReaderType();
            rfidReader11.PortRS232.Connect(Dicts.rfidReader_Port11, Dicts.rfidReader_IsON11, Dicts.rfidReader_Speed11, Dicts.rfidReader_Delay11, Dicts.rfidReader_Name11);
            rfidReader11.PortRS232.OnRead += rfidReader11_OnRead;

            rfidReader12 = new RFIDReaderType();
            rfidReader12.PortRS232.Connect(Dicts.rfidReader_Port12, Dicts.rfidReader_IsON12, Dicts.rfidReader_Speed12, Dicts.rfidReader_Delay12, Dicts.rfidReader_Name12);
            rfidReader12.PortRS232.OnRead += rfidReader12_OnRead;

            rfidReader13 = new RFIDReaderType();
            rfidReader13.PortRS232.Connect(Dicts.rfidReader_Port13, Dicts.rfidReader_IsON13, Dicts.rfidReader_Speed13, Dicts.rfidReader_Delay13, Dicts.rfidReader_Name13);
            rfidReader13.PortRS232.OnRead += rfidReader13_OnRead;

            InitSteportStands();

            resetCounters();



      
                try
                {
                    string rn = mySQLcore.DB_Main().GetString("select roundnumber from tactlogs order by roundnumber desc limit 1;");
                    Dicts.RoundNumber = int.Parse(rn) + 1;
                }
                catch (Exception)
                {

                }
            

            IsReady();

            PrintAsync("", "", "", "", "", "");

            RoundStartTime = DateTime.Now;



            this.CurrentShift = ShiftType.GetLastShift();
        }
        void PrintAsync(string CurrentReadedPlate, string CurrentIndex, string platescount, string AllTactsCount, string StopSensorTactsCount, string WorkdetectionIntervalMS)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            Task.Run(() => print(CurrentReadedPlate, CurrentIndex, platescount, AllTactsCount, StopSensorTactsCount, WorkdetectionIntervalMS));      
        }
        void print(string CurrentReadedPlate, string CurrentIndex, string platescount, string AllTactsCount, string StopSensorTactsCount, string WorkdetectionIntervalMS)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            string line_1 = "";
            string line_2 = "";
            string line_3 = "";
            string line_4 = "";


            if (isready == true)
            {
                line_1 = "Status: Ready";
                if (Isworking)
                {
                    line_1 += " Belt Working";
                }
                else
                {
                    line_1 += " Belt Not Working";
                }
            }
            else
            {
                line_1 = "Status:Device Error";
                
            }


            line_2 = CurrentReadedPlate + " _ " + CurrentIndex + " _ " + platescount + " _ " + Dicts.CurrentTact + " _ " + Dicts.RoundNumber;
            line_3 = AllTactsCount + " " + StopSensorTactsCount + " " + WorkdetectionIntervalMS;
            line_4 = ParcelsBuffer.Count.ToString() + "  " + ParcelsOnRun.Count.ToString();

            //ConsoleTables.ConsoleTable tb = new ConsoleTables.ConsoleTable("numer", "pna", "plateID", "kierunek", "takt", "taktdocelowy", "lenght", "plates", "korekcja", "secondrun", "runtime");
            //DataTable dt = ParcelsOnRunTable();
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    tb.AddRow(dt.Rows[i].ItemArray);
            //}







            //try
            //{
            //Console.Clear();

            //    Console.WriteLine(line_1);
    
            //    Console.WriteLine(line_2);
     
            //    Console.WriteLine(line_3);
  
            //    Console.WriteLine(line_4);
            //}
            //catch (Exception)
            //{

         
            //}



      



            

            //tb.Write();
        }
        void InitSteportStands()
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            StatReport.StandsStats.Clear();
            foreach (var s in Dicts.Stands)
            {

                s.StandItem1.SortedParcels = 0;
                s.StandItem1.MissedParcelsCount = 0;

                s.StandItem2.SortedParcels = 0;
                s.StandItem2.MissedParcelsCount = 0;

                s.StandItem3.SortedParcels = 0;
                s.StandItem3.MissedParcelsCount = 0;

                s.StandItem4.SortedParcels = 0;
                s.StandItem4.MissedParcelsCount = 0;

                StatusReportType.StandStatItem item;

                item = new StatusReportType.StandStatItem();
                item.StandName = s.Name;
                item.Name = s.StandItem1.Direction.Name;
                item.MissedParcels = s.StandItem1.MissedParcelsCount;
                item.SortedParcels = s.StandItem1.SortedParcels;
                StatReport.StandsStats.Add(item);

                item = new StatusReportType.StandStatItem();
                item.StandName = s.Name;
                item.Name = s.StandItem2.Direction.Name;
                item.MissedParcels = s.StandItem2.MissedParcelsCount;
                item.SortedParcels = s.StandItem2.SortedParcels;
                StatReport.StandsStats.Add(item);

                item = new StatusReportType.StandStatItem();
                item.StandName = s.Name;
                item.Name = s.StandItem3.Direction.Name;
                item.MissedParcels = s.StandItem3.MissedParcelsCount;
                item.SortedParcels = s.StandItem3.SortedParcels;
                StatReport.StandsStats.Add(item);

                item = new StatusReportType.StandStatItem();
                item.StandName = s.Name;
                item.Name = s.StandItem4.Direction.Name;
                item.MissedParcels = s.StandItem4.MissedParcelsCount;
                item.SortedParcels = s.StandItem4.SortedParcels;
                StatReport.StandsStats.Add(item);

            }
        }
        public DataTable ParcelsOnRunTable()
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            DataTable dt = new DataTable();
            dt.Columns.Add("Przesyłka");
            dt.Columns.Add("PNA");
            dt.Columns.Add("Tacka");
            dt.Columns.Add("Kierunek");
            dt.Columns.Add("Takt");
            dt.Columns.Add("Takt doc.");
            dt.Columns.Add("Dł.");
            dt.Columns.Add("Zaj. tac");
            dt.Columns.Add("Korekcja");
            dt.Columns.Add("Recyrk");
            dt.Columns.Add("Czas");
            try
            {
                foreach (var p in this.ParcelsOnRun)
                {
                    dt.Rows.Add(p.Number, p.DestinationPNA, p.ParcelPlateID, p.Destination.Direction.Name, 
                        p.TactCount,p.Destination.Lamp1.TactsToTurnON.ToString() + ", " +  p.Destination.Lamp2.TactsToTurnON.ToString()  , p.Lenght, p.OccupiedPlates, p.correctCounts, p.SecondRunt, p.RunTime());
                }
            }
            catch (Exception)
            {
            }
            return dt;
        }
        private void resetCounters()
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            foreach (var s in Dicts.Stands)
            {

                s.StandItem1.SortedParcels = 0;
                s.StandItem1.MissedParcelsCount = 0;

                s.StandItem2.SortedParcels = 0;
                s.StandItem2.MissedParcelsCount = 0;

                s.StandItem3.SortedParcels = 0;
                s.StandItem3.MissedParcelsCount = 0;

                s.StandItem4.SortedParcels = 0;
                s.StandItem4.MissedParcelsCount = 0;
            }

            Dicts.Save();
        }
        public void TurnOff()
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            StartSensor.PortRS232.Disconnect();
            StopSensor.PortRS232.Disconnect();
            TactSensor.PortRS232.Disconnect();
            Scanner1.PortRS232.Disconnect();
            Signaling.PortRS232.Disconnect();
            LenghtSensor.PortRS232.Disconnect();
            RFIDTactSensor.PortRS232.Disconnect();



            StatReport.Scanner1Connected = false;
            StatReport.StartSensorConnected = false;
            StatReport.StopSensorConnected = false;
            StatReport.tactSensorConnected = false;
            StatReport.LenghttSensorConnected = false;
            StatReport.SignalingConnected = false;
            StatReport.rfidTactSensorConnected = false;
            StatReport.Save();



            DataServerTask.Dispose();
        }
        public void StartShift()
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            resetCounters();
            CurrentShift.StartShift();            
        }
        public void StopShift()
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            CurrentShift.EndShift(this.Dicts.Stands);          
            CurrentShift = new ShiftType();

            NeedDictsSave = false;
            Task.Run(() => Dicts.Save());

            resetCounters();
        }


        private string WhatsNotOn { get; set; }
        private bool CheckDevices()
        {
            WhatsNotOn = "";
            //AddLog(MethodBase.GetCurrentMethod().Name);
            bool st = true;

            if (Scanner1 == null)
                Scanner1 = new ScannerType();
            
            if (Scanner1.PortRS232.IsOpen() == false)
            {
                Scanner1.PortRS232.Connect(Dicts.Scanner1Port,Dicts.Scanner1IsON, Dicts.Scanner1Speed, Dicts.Scanner1Delay, Dicts.Scanner1Name, true);
                if (Dicts.Scanner1IsON == true)
                { st = false; WhatsNotOn += "S canner1"; }
            }

            if (StartSensor == null)
                StartSensor = new StartSensorType();
            if (StartSensor.PortRS232.IsOpen() == false)
            {
                StartSensor.PortRS232.Connect(Dicts.StartSensorPort,Dicts.StartSensorIsON, Dicts.StartSensorSpeed, Dicts.StartSensorDelay, Dicts.StartSensorName, true);
                if (Dicts.StartSensorIsON == true)
                { st = false; WhatsNotOn += " StartSensor"; }
            }

            if (StopSensor == null)
                StopSensor = new StopSensorType();
            if (StopSensor.PortRS232.IsOpen() == false)
            {
                StopSensor.PortRS232.Connect(Dicts.StopSensorPort,Dicts.StopSensorIsON, Dicts.StopSensorSpeed, Dicts.StopSensorDelay, Dicts.StopSensorName, true);
                if (Dicts.StopSensorIsON == true)
                { st = false; WhatsNotOn += " StopSensor"; }
            }

            if (TactSensor == null)
                TactSensor = new TactSensorType();
            if (TactSensor.PortRS232.IsOpen() == false)
            {
                TactSensor.PortRS232.Connect(Dicts.TactSensorPort,Dicts.TactSensorIsON, Dicts.TactSensorSpeed, Dicts.TactSensorDelay, Dicts.TactSensorName, true);
                if (Dicts.TactSensorIsON == true)
                    st = false;
            }

            if (LenghtSensor == null){
                LenghtSensor = new LenghtSensorType();
            }
            if (LenghtSensor.PortRS232.IsOpen() == false)
            {
                LenghtSensor.PortRS232.Connect(Dicts.LenghtSensorPort,Dicts.LenghtSensorIsON, Dicts.LenghtSensorSpeed, Dicts.LenghtSensorDelay, Dicts.LenghtSensorName, true);
                if (Dicts.LenghtSensorIsON == true)
                { st = false; WhatsNotOn += " LenghtSensor"; }
            }

            if (Signaling == null)
                Signaling = new SignalingType();
            if (Signaling.PortRS232.IsOpen() == false)
            {
                Signaling.PortRS232.Connect(Dicts.SignalingPort,Dicts.SignalingIsON, Dicts.SignalingSpeed, Dicts.SignalingDelay, Dicts.SignalingName, true);
                if (Dicts.SignalingIsON == true)
                { st = false; WhatsNotOn += " Signaling"; }
            }

            if (RFIDTactSensor == null)
                RFIDTactSensor = new RFIDTactSensorType(Dicts.Plates);
            rfidReader1.PortRS232.isOn = Dicts.rfidReader_IsON1;
            if (RFIDTactSensor.PortRS232.IsOpen() == false)
            {
                RFIDTactSensor.Tacting = Dicts.rfidTactSensorTacting;
                RFIDTactSensor.PortRS232.Connect(Dicts.rfidTactSensorPort,Dicts.rfidTactSensorIsON, Dicts.rfidTactSensorSpeed, Dicts.rfidTactSensorDelay, Dicts.rfidTactSensorName, true);
                if (Dicts.rfidTactSensorIsON == true )
                { st = false; WhatsNotOn += " PlateSensor"; }
            }

            if (rfidReader1 == null)
                rfidReader1 = new RFIDReaderType();
         

            if (rfidReader1.PortRS232.IsOpen() == false)
            {
                rfidReader1.PortRS232.Connect(Dicts.rfidReader_Port1, Dicts.rfidReader_IsON1, Dicts.rfidReader_Speed1, Dicts.rfidReader_Delay1, Dicts.rfidReader_Name1, true);
                if (Dicts.rfidReader_IsON1 == true)
                { st = false; WhatsNotOn += " StandReader_1"; }
            }

            if (rfidReader2 == null)
                rfidReader2 = new RFIDReaderType();
            if (rfidReader2.PortRS232.IsOpen() == false)
            {
                rfidReader2.PortRS232.Connect(Dicts.rfidReader_Port2, Dicts.rfidReader_IsON2, Dicts.rfidReader_Speed2, Dicts.rfidReader_Delay2, Dicts.rfidReader_Name2, true);
                if (Dicts.rfidReader_IsON2 == true)
                { st = false; WhatsNotOn += " StandReader_2"; }
            }
            if (rfidReader3 == null)
                rfidReader3 = new RFIDReaderType();
            if (rfidReader3.PortRS232.IsOpen() == false)
            {
                rfidReader3.PortRS232.Connect(Dicts.rfidReader_Port3, Dicts.rfidReader_IsON3, Dicts.rfidReader_Speed3, Dicts.rfidReader_Delay3, Dicts.rfidReader_Name3, true);
                if (Dicts.rfidReader_IsON3 == true)
                { st = false; WhatsNotOn += " StandReader_3"; }
            }
            if (rfidReader4 == null)
                rfidReader4 = new RFIDReaderType();
            if (rfidReader4.PortRS232.IsOpen() == false)
            {
                rfidReader4.PortRS232.Connect(Dicts.rfidReader_Port4, Dicts.rfidReader_IsON4, Dicts.rfidReader_Speed4, Dicts.rfidReader_Delay4, Dicts.rfidReader_Name4, true);
                if (Dicts.rfidReader_IsON4 == true)
                { st = false; WhatsNotOn += " StandReader_4"; }
            }
            if (rfidReader5 == null)
                rfidReader5 = new RFIDReaderType();
            if (rfidReader5.PortRS232.IsOpen() == false)
            {
                rfidReader5.PortRS232.Connect(Dicts.rfidReader_Port5, Dicts.rfidReader_IsON5, Dicts.rfidReader_Speed5, Dicts.rfidReader_Delay5, Dicts.rfidReader_Name5, true);
                if (Dicts.rfidReader_IsON5 == true)
                { st = false; WhatsNotOn += " StandReader_5"; }
            }
            if (rfidReader6 == null)
                rfidReader6 = new RFIDReaderType();
            if (rfidReader6.PortRS232.IsOpen() == false)
            {
                rfidReader6.PortRS232.Connect(Dicts.rfidReader_Port6, Dicts.rfidReader_IsON6, Dicts.rfidReader_Speed6, Dicts.rfidReader_Delay6, Dicts.rfidReader_Name6, true);
                if (Dicts.rfidReader_IsON6 == true)
                { st = false; WhatsNotOn += " StandReader_6"; }
            }
            if (rfidReader7 == null)
                rfidReader7 = new RFIDReaderType();
            if (rfidReader7.PortRS232.IsOpen() == false)
            {
                rfidReader7.PortRS232.Connect(Dicts.rfidReader_Port7, Dicts.rfidReader_IsON7, Dicts.rfidReader_Speed7, Dicts.rfidReader_Delay7, Dicts.rfidReader_Name7, true);
                if (Dicts.rfidReader_IsON7 == true)
                { st = false; WhatsNotOn += " StandReader_7"; }
            }
            if (rfidReader8 == null)
                rfidReader8 = new RFIDReaderType();
            if (rfidReader8.PortRS232.IsOpen() == false)
            {
                rfidReader8.PortRS232.Connect(Dicts.rfidReader_Port8, Dicts.rfidReader_IsON8, Dicts.rfidReader_Speed8, Dicts.rfidReader_Delay8, Dicts.rfidReader_Name8, true);
                if (Dicts.rfidReader_IsON8 == true)
                { st = false; WhatsNotOn += " StandReader_8"; }
            }
            if (rfidReader9 == null)
                rfidReader9 = new RFIDReaderType();
            if (rfidReader9.PortRS232.IsOpen() == false)
            {
                rfidReader9.PortRS232.Connect(Dicts.rfidReader_Port9, Dicts.rfidReader_IsON9, Dicts.rfidReader_Speed9, Dicts.rfidReader_Delay9, Dicts.rfidReader_Name9, true);
                if (Dicts.rfidReader_IsON9 == true)
                { st = false; WhatsNotOn += " StandReader_9"; }
            }
            if (rfidReader10 == null)
                rfidReader10 = new RFIDReaderType();
            if (rfidReader10.PortRS232.IsOpen() == false)
            {
                rfidReader10.PortRS232.Connect(Dicts.rfidReader_Port10, Dicts.rfidReader_IsON10, Dicts.rfidReader_Speed10, Dicts.rfidReader_Delay10, Dicts.rfidReader_Name10, true);
                if (Dicts.rfidReader_IsON10 == true)
                { st = false; WhatsNotOn += " StandReader_10"; }
            }
            if (rfidReader11 == null)
                rfidReader11 = new RFIDReaderType();
            if (rfidReader11.PortRS232.IsOpen() == false)
            {
                rfidReader11.PortRS232.Connect(Dicts.rfidReader_Port11, Dicts.rfidReader_IsON11, Dicts.rfidReader_Speed11, Dicts.rfidReader_Delay11, Dicts.rfidReader_Name11, true);
                if (Dicts.rfidReader_IsON11 == true)
                { st = false; WhatsNotOn += " StandReader_11"; }
            }
            if (rfidReader12 == null)
                rfidReader12 = new RFIDReaderType();
            if (rfidReader12.PortRS232.IsOpen() == false)
            {
                rfidReader12.PortRS232.Connect(Dicts.rfidReader_Port12, Dicts.rfidReader_IsON12, Dicts.rfidReader_Speed12, Dicts.rfidReader_Delay12, Dicts.rfidReader_Name12, true);
                if (Dicts.rfidReader_IsON12 == true)
                { st = false; WhatsNotOn += " StandReader_12"; }
            }
            if (rfidReader13 == null)
                rfidReader13 = new RFIDReaderType();
            if (rfidReader13.PortRS232.IsOpen() == false)
            {
                rfidReader13.PortRS232.Connect(Dicts.rfidReader_Port13, Dicts.rfidReader_IsON13, Dicts.rfidReader_Speed13, Dicts.rfidReader_Delay13, Dicts.rfidReader_Name13, true);
                if (Dicts.rfidReader_IsON13 == true)
                { st = false; WhatsNotOn += " StandReader_13"; }
            }

            isready = st;

            //try
            //{
            //    Console.SetCursorPosition(0, 6);
            //    Console.Write(new string(' ', 100));
            //    Console.SetCursorPosition(0, 6);
            //    Console.WriteLine(WhatsNotOn);
            //}
            //catch (Exception)
            //{
             
            //}


    

            if (st == false)
            {
                try
                {
                    if (TimerConnectDevices != null)
                        TimerConnectDevices.Stop();

                    TimerConnectDevices = new Timer();
                    TimerConnectDevices.Interval = 1000;
                    TimerConnectDevices.Elapsed += OnTimedEvent;
                    TimerConnectDevices.Start();
                }
                catch (Exception)
                {

                    
                }



                void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
                {
                    CheckDevices();
                }
            }
            else
            {
                if (TimerConnectDevices != null)
                    TimerConnectDevices.Stop();
            }

            return st;
        }
        private void WorkDetection_OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            if (DateTime.Now > StatReport.SuppposedTactTime)
            {
                Isworking = false;
            }
        }

        #endregion

        #region "cameras"
        public void TurnOnCammera()
        {
            CamScanner = new CamScannerType();
            CamScanner.CameraAdres = Dicts.CamAdress1;
            CamScanner.OnBarcodeReaded += CamScanner_OnRead;
            CamScanner.CaptureCamera(Dicts.CamAdress1, Dicts.cam1zoom, Dicts.blackCam1);
        }

        public void TurnOffCamera()
        {

            CamScanner.STOP();
            CamScanner = null;


        }

        public void TurnOnCamera2()
        {
            CamScanner2 = new CamScannerType();
            CamScanner2.CameraAdres = Dicts.CamAdress2;
            CamScanner2.OnBarcodeReaded += CamScanner2_OnRead;
            CamScanner2.CaptureCamera(Dicts.CamAdress2, Dicts.cam2zoom, Dicts.blackCam2);
        }

        public void TurnOffCamera2()
        {
            CamScanner2.STOP();
            CamScanner2 = null;
        }
        #endregion

        void CheckToOn(string plateid)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            foreach (var p in ParcelsOnRun)
            {
                if (p.ParcelPlateID == plateid)
                {
                    p.Destination.Lamp2.TurnOn(Signaling);
                    p.Lamp2_On();
                }
            }
        }

        #region "DevicesRead"
        void rfidReader1_OnRead(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            CheckToOn(e.message);
        }
        void rfidReader2_OnRead(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            CheckToOn(e.message);
        }
        void rfidReader3_OnRead(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            CheckToOn(e.message);
        }
        void rfidReader4_OnRead(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            CheckToOn(e.message);
        }
        void rfidReader5_OnRead(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            CheckToOn(e.message);
        }
        void rfidReader6_OnRead(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            CheckToOn(e.message);
        }
        void rfidReader7_OnRead(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            CheckToOn(e.message);
        }
        void rfidReader8_OnRead(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            CheckToOn(e.message);
        }
        void rfidReader9_OnRead(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            CheckToOn(e.message);
        }
        void rfidReader10_OnRead(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            CheckToOn(e.message);
        }
        void rfidReader11_OnRead(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            CheckToOn(e.message);
        }
        void rfidReader12_OnRead(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            CheckToOn(e.message);
        }
        void rfidReader13_OnRead(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            CheckToOn(e.message);
        }

        int AllSorted()
        {
            int a = 0;
            foreach (var s in Dicts.Stands)
            {
                a += s.StandItem1.SortedParcels;
                a += s.StandItem2.SortedParcels;
                a += s.StandItem3.SortedParcels;
                a += s.StandItem4.SortedParcels;

                s.StandItem1.AllSortedParcels = a;
                s.StandItem2.AllSortedParcels = a;
                s.StandItem3.AllSortedParcels = a;
                s.StandItem4.AllSortedParcels = a;
            }

          

            return a;
        }
        

      private DateTime RoundStartTime { get; set; }
      private TimeSpan LogTimeStamp { get; set; }
            
        void TactPing()
        {
            AllSorted();


            if (NeedDictsSave == true)
            {
                NeedDictsSave = false;
                Task.Run(() => Dicts.Save());
            }


            foreach (var s in Dicts.Stands)
            {
                if (s.StandItem1.Lamp1ONTacts > 0 || s.StandItem2.Lamp1ONTacts > 0 || s.StandItem3.Lamp1ONTacts > 0 || s.StandItem4.Lamp1ONTacts > 0)
                {
                    s.StandItem1.Lamp1ONTacts -= 1;
                    s.StandItem2.Lamp1ONTacts -= 1;
                    s.StandItem3.Lamp1ONTacts -= 1;
                    s.StandItem4.Lamp1ONTacts -= 1;

                    if (s.Lamp1isOn == false)
                    {
                        s.Lamp1isOn = true;
                        s.Lamp1().TurnOn(Signaling);
                    }
                    else
                    {
                        s.Lamp1isOn = false;
                        s.Lamp1().TurnOff(Signaling);
                    }
                }
                else
                {
                    if(s.Lamp1().LampisON==true)
                        s.Lamp1().TurnOff(Signaling);
                }

            }




            LogTimeStamp = DateTime.Now - RoundStartTime;

            //AddLog(MethodBase.GetCurrentMethod().Name);
            tactslogs.Add(new tactLogType(Dicts.CurrentTact, StatReport.TactTime.TotalMilliseconds.ToString(), RFIDTactSensor.CurrentReadedPlateID,Dicts.RoundNumber,ParcelsBuffer.Count,ParcelsOnRun.Count,
                StartSensor.PortRS232.ReadsCount,StopSensor.PortRS232.ReadsCount,TactSensor.PortRS232.ReadsCount,LenghtSensor.PortRS232.ReadsCount,Signaling.PortRS232.ReadsCount,
                Scanner1.PortRS232.ReadsCount,RFIDTactSensor.PortRS232.ReadsCount,rfidReader1.PortRS232.ReadsCount,rfidReader2.PortRS232.ReadsCount,rfidReader3.PortRS232.ReadsCount,
                rfidReader4.PortRS232.ReadsCount,rfidReader5.PortRS232.ReadsCount,rfidReader6.PortRS232.ReadsCount,rfidReader7.PortRS232.ReadsCount,rfidReader8.PortRS232.ReadsCount,
                rfidReader9.PortRS232.ReadsCount,rfidReader10.PortRS232.ReadsCount,rfidReader11.PortRS232.ReadsCount,rfidReader12.PortRS232.ReadsCount,rfidReader13.PortRS232.ReadsCount,Signaling.PortRS232.WriteCounts,TCPReadCount,TCPWriteCount,mysqlcommandCount,new DataTable(),(int)LogTimeStamp.TotalMilliseconds));

            if (Dicts.RoundNumber > int.MaxValue - 2)
                Dicts.RoundNumber = 0;

            Dicts.CurrentTact += 1;
            
                StartSensor.PortRS232.ReadsCount = 0;
                StopSensor.PortRS232.ReadsCount = 0;
                TactSensor.PortRS232.ReadsCount = 0;
                LenghtSensor.PortRS232.ReadsCount = 0;
                Signaling.PortRS232.ReadsCount = 0;
                Scanner1.PortRS232.ReadsCount = 0;
                RFIDTactSensor.PortRS232.ReadsCount = 0;
                rfidReader1.PortRS232.ReadsCount = 0;
                rfidReader2.PortRS232.ReadsCount = 0;
                rfidReader3.PortRS232.ReadsCount = 0;
                rfidReader4.PortRS232.ReadsCount = 0;
                rfidReader5.PortRS232.ReadsCount = 0;
                rfidReader6.PortRS232.ReadsCount = 0;
                rfidReader7.PortRS232.ReadsCount = 0;
                rfidReader8.PortRS232.ReadsCount = 0;
                rfidReader9.PortRS232.ReadsCount = 0;
                rfidReader10.PortRS232.ReadsCount = 0;
                rfidReader11.PortRS232.ReadsCount = 0;
                rfidReader12.PortRS232.ReadsCount = 0;
                rfidReader13.PortRS232.ReadsCount = 0;
                Signaling.PortRS232.WriteCounts = 0;

            TCPReadCount = 0;
            TCPWriteCount = 0;
            mysqlcommandCount = 0;


            if (tactslogs.Count > Dicts.AllTactsCount - 1)
            {
                tactslogs[0].dt = dtlogs;

                tactLogType.SaveAsync(tactslogs);
                tactslogs = new List<tactLogType>();
                Dicts.CurrentTact = 0;
                Dicts.RoundNumber += 1;

                RoundStartTime = DateTime.Now;

                dtlogs.Rows.Clear();
            }

            PrintAsync(RFIDTactSensor.CurrentReadedPlateID, RFIDTactSensor.CurrentIndex().ToString(), Dicts.Plates.Count.ToString(), Dicts.AllTactsCount.ToString(),
                Dicts.StopSensorTactsCount.ToString(), Dicts.WorkdetectionIntervalMS.ToString());

            Isworking = true;

            StatReport.TactsCount += 1;          

            if (Isworking == false || TimerWorkDetection == null)
            {
                TimerWorkDetection = new Timer();
                TimerWorkDetection.Elapsed += WorkDetection_OnTimedEvent;
                TimerWorkDetection.Interval = 100;
                TimerWorkDetection.Start();

                foreach (var p in ParcelsOnRun)
                {
                    for (int i = 0; i < Dicts.StopCorrection; i++)
                    {
                        p.AddTact();
                    }
                }
            }

            StatReport.TactTime = DateTime.Now - StatReport.LastTactTime;

            StatReport.LastTactTime = DateTime.Now;
            StatReport.SuppposedTactTime = StatReport.LastTactTime.AddMilliseconds(Dicts.WorkdetectionIntervalMS);

            if (Dicts.AutoWorkdetectioninterval == true)
                Dicts.WorkdetectionIntervalMS = (int)StatReport.TactTime.TotalMilliseconds + 100;

            try
            {
                foreach (var p in ParcelsOnRun)
                {
                    p.AddTact();
                    if (p.SecondRunt == true)
                    {
                        if (p.TactCount == Dicts.AllTactsCount - 2)
                        {
                            p.SecondRunt = false;

                            if (ParcelsBuffer.Exists(x => x.Number == p.Number) == false)
                            {
                                p.TactCount = 0;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {


            }



            try
            {
                foreach (var p in ParcelsOnRun)
                {
                  Task.Run(()=>  p.CheckTacts());
                }
            }
            catch (Exception ex)
            {


            }


            EventHandler ev = CarouselTacted;
            EventArgs e = new EventArgs();
            ev?.Invoke(this, e);

        }

        private bool NeedDictsSave { get; set; }
        void rfidTactSensorOnRead(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            // Console.Clear();]]]

            string ms = e.message.Replace("\u0002", "").Replace("\u0003", "");

            if (ms.Length == Dicts.plateIendtityLenght)
            {
                if(ms!= RFIDTactSensor.CurrentReadedPlateID)
                {               

                    if (Dicts.Plates == null)
                    {
                        Dicts.Plates = new List<PlateType>();
                    }

                    if (!Dicts.Plates.Exists(xx => xx.PlateID == ms))
                    {
                        PlateType p = new PlateType();
                        p.PlateID = ms;
                        p.Index = Dicts.Plates.Count + 1;

                        NeedDictsSave = true;

                        Dicts.Plates.Add(p);
                        if (RFIDTactSensor.plates == null)
                            RFIDTactSensor.plates = new List<PlateType>();

                        RFIDTactSensor.plates = Dicts.Plates;
                    }

                    if (ms != RFIDTactSensor.NextPlateID())
                    {
                        //błąd nie odczytalo tacki, która powinna teraz być
                        if (RFIDTactSensor.NextPlateID() != "")
                        {
                            //ominięcie wyjątku przy starcie programu,gdy nie ma określonej nastepnej tacki

                        }
                    }

                    RFIDTactSensor.CurrentReadedPlateID = ms;
                    RFIDTactSensor.currentPlate().ReadCount += 1;

                    //if (RFIDTactSensor.Tacting == true)
                        Dicts.CurrentTact = RFIDTactSensor.currentPlate().Index;

                    int x = RFIDTactSensor.CurrentReadedPlateID.Length;


                    if(RFIDTactSensor.Tacting==true)
                                        TactPing();
                }
            }



        }
        void TactSensorOnRead(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            if (e.message.Replace("\r", "").Replace("\n", "").ToLower().StartsWith("j"))
            {
                if (Dicts.TactSensorSimulatePlates == true)
                {
                    RFIDTactSensor.CurrentReadedPlateID = RFIDTactSensor.GetPlate(Dicts.CurrentTact).PlateID;
                }

                TactPing();
            }

        }
        void StartSensorOnRead(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            if (ParcelsBuffer.Count > 0)
            {
                ParcelType parcel = null;
                parcel = ParcelsBuffer[0];

                parcel.ParcelPlateID = RFIDTactSensor.CurrentReadedPlateID;
                RFIDTactSensor.CurrentReadedPlateID = "";

                parcel.BehindDestination = false;
                parcel.NextRound = false;
                //parcel.Lenght = len;
                parcel.StartRun();
                ParcelsOnRun.Add(parcel);
                parcel.AddToBase();
                parcel.StartRun();
                ParcelsBuffer.Remove(parcel);

                if (Dicts.CorrectDisposedMarkers == true)
                {
                    double disposedMarkers = (double)parcel.Lenght / (double)this.StatReport.TactTime.TotalMilliseconds;
                    //double disposedMarkers = 2;

                    for (int i = 0; i < disposedMarkers; i++)
                    {
                        parcel.AddTact();
                        parcel.correctCounts += 1;
                    }
                }

                SetLenght = true;
            }

        }
        void LenghtensorOnRead(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            int len = 100;
            string[] js = e.message.Split(char.Parse(" "));
            if (js.Length == 2)
            {
                len = int.Parse(js[1]) * Dicts.ParcelLenghtFactor;
            }

            if (SetLenght == true)
            {
                if (ParcelsOnRun.Count > 0)
                {
                    ParcelType parcel = ParcelsOnRun.Last();
                    parcel.Lenght = len;
                    parcel.OccupiedPlates = (int)Math.Ceiling((decimal)len / (decimal)Dicts.WorkdetectionIntervalMS);
                    SetLenght = false;
                }
        
            }
        }
        void StopSensorOnRead(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            try
            {
                foreach (var p in ParcelsOnRun)
                {
                    if (p.TactCount - p.correctCounts == Dicts.StopSensorTactsCount)
                    {
                        p.SecondRunt = true;
                        p.Destination.MissedParcelsCount += 1;
                    }
                }
                SerialPortDevice.SerialPortEventArgs args = new SerialPortDevice.SerialPortEventArgs();
                args.message = "STOP Sensor READED";
                EventHandler<SerialPortDevice.SerialPortEventArgs> handler = OnStopSensorRead;
                handler.Invoke(sender, args);
            }
            catch (Exception)
            {

             
            }

        }
        void Scanner1SensorOnRead(object sender, SerialPortDevice.SerialPortEventArgs e)
        {

            if (CurrentShift.IsOpen() == false)
                Task.Run(() => StartRun());

            //AddLog(MethodBase.GetCurrentMethod().Name);
            if (e.message.Length == 19)
                e.message = "0" + e.message;



            if (ParcelsBuffer.Exists(x => x.Number == e.message) == false)
            {
                ParcelType parcel = new ParcelType();
                parcel.Shift = CurrentShift;
                parcel.signaling = Signaling;
                parcel.ParcelError += ParcelError;
                parcel.ParcelDataOK += NewParcelDataOK;
                parcel.TactAdded += ParcelTactAdded;
                parcel.OnLampOn_1 += ParcelLampOn_1;
                parcel.OnLampOn_2 += ParcelLampOn_2;
                parcel.OnLampOff_1 += ParcelLampOff_1;
                parcel.OnLampOff_2 += ParcelLampOff_2;

                parcel.Number = e.message;

                parcel.SetAddressAsync(this.Dicts.Stands, this.Dicts.TurnOffLampByTimer);

                Console.WriteLine(e.message);

            }
        }

        void CamScanner_OnRead(object sender, CamScannerType.CamScannerEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            if (ParcelsBuffer.Exists(x => x.Number == e.Barcode) == false)
            {
                ParcelType parcel = new ParcelType();
                parcel.signaling = Signaling;

                parcel.ParcelError += ParcelError;
                parcel.ParcelDataOK += NewParcelDataOK;
                parcel.TactAdded += ParcelTactAdded;

                parcel.OnLampOn_1 += ParcelLampOn_1;
                parcel.OnLampOn_2 += ParcelLampOn_2;    

                parcel.OnLampOff_1 += ParcelLampOff_1;
                parcel.OnLampOff_2 += ParcelLampOff_2;
             

                parcel.Number = e.Barcode;

                parcel.SetAddress(this.Dicts.Stands, this.Dicts.TurnOffLampByTimer);
            }
        }
        void CamScanner2_OnRead(object sender, CamScannerType.CamScannerEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            if (ParcelsBuffer.Exists(x => x.Number == e.Barcode) == false)
            {
                ParcelType parcel = new ParcelType();
                parcel.signaling = Signaling;

                parcel.ParcelError += ParcelError;
                parcel.ParcelDataOK += NewParcelDataOK;
                parcel.TactAdded += ParcelTactAdded;

                parcel.OnLampOn_1 += ParcelLampOn_1;
                parcel.OnLampOn_2 += ParcelLampOn_2;
               

                parcel.OnLampOff_1 += ParcelLampOff_1;
                parcel.OnLampOff_2 += ParcelLampOff_2;
               

                parcel.Number = e.Barcode;

                parcel.SetAddress(Dicts.Stands, this.Dicts.TurnOffLampByTimer);
            }
        }


        void CamScanner2_Error(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
        }
        void rfidTactSensor_Error(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
        }
        void TactSensor_Error(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
        }
        void StartSensor_Error(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
        }
        void Lenghtensor_Error(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
        }
        void StopSensor_Error(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
        }
        void Scanner1Sensor_Error(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
        }
        void CamScanner_Error(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
        }

        void rfidReader1_Error(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
        }
        void rfidReader2_Error(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
        }
        void rfidReader3_Error(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
        }
        void rfidReader4_Error(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
        }
        void rfidReader5_Error(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
        }
        void rfidReader6_Error(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
        }
        void rfidReader7_Error(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
        }
        void rfidReader8_Error(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
        }
        void rfidReader9_Error(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
        }
        void rfidReader10_Error(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
        }
        void rfidReader11_Error(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
        }
        void rfidReader12_Error(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
        }
        void rfidReader13_Error(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
        }




        #endregion

        #region "DevicesWrite"
        void SignalingOnWrite(object sender, SerialPortDevice.SerialPortEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
        }

        #endregion


        #region "ParcelEvents"

        void ParcelError(object sender, ParcelType.ParcelEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            try
            {
                EventHandler<ParcelType.ParcelEventArgs> handler = OnParcelError;
                handler.Invoke(sender, e);
            }
            catch (Exception)
            {


            }

        }

        void NewParcelDataOK(object sender, ParcelType.ParcelEventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            ParcelsBuffer.Add(e.parcel);



            foreach (var ss in StatReport.StandsStats)
            {
                if (ss.Name == e.parcel.Destination.Direction.Name)
                {
                    ss.SortedParcels = e.parcel.Destination.SortedParcels;
                    ss.MissedParcels = e.parcel.Destination.MissedParcelsCount;
                }
            }

            try
            {
                EventHandler<ParcelType.ParcelEventArgs> handler = OnParcelDataOK;
                handler.Invoke(sender, e);
            }
            catch (Exception ex)
            {


            }

        }

        void ParcelTactAdded(object sender, ParcelType.ParcelEventArgs e)
        {

        }


        public void ParcelLampOn_1(object sender, EventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            ParcelType p = (ParcelType)sender;
        }
        public void ParcelLampOn_2(object sender, EventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            ParcelType p = (ParcelType)sender;

            foreach (var ss in StatReport.StandsStats)
            {
                if (ss.Name == p.Destination.Direction.Name)
                {
                    ss.SortedParcels = p.Destination.SortedParcels;
                    ss.MissedParcels = p.Destination.MissedParcelsCount;
                }
            }

        }
    

        public void ParcelLampOff_1(object sender, EventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            ParcelType p = (ParcelType)sender;
        }
        public void ParcelLampOff_2(object sender, EventArgs e)
        {
            //AddLog(MethodBase.GetCurrentMethod().Name);
            ParcelType p = (ParcelType)sender;

            Task.Run(() => p.UpdateTime());

            ParcelsOnRun.Remove(p);
        }
    



        #endregion

    }
}
