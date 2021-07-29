using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;
using System.Timers;

namespace ASS
{
    public class StatusReportType
    {
        public static string FileName = "report.json";
  

        public int TactsCount { get; set; }
        public DateTime LastTactTime { get; set; }   
        public DateTime SuppposedTactTime { get; set; }   
        public TimeSpan TactTime { get; set; }

        public DataTable parcelsOnRunTable { get; set; }

        public int ParcelInBuffer { get; set; }
        public int ParcelsAtLine { get; set; }

        public bool DevicesCanRun { get; set; }
        public bool MachineStatusReady { get; set; }

        public bool StartSensorConnected { get; set; }
        public bool StopSensorConnected { get; set; }
        public bool tactSensorConnected { get; set; }
        public bool LenghttSensorConnected { get; set; }
        public bool SignalingConnected { get; set; }
        public bool Scanner1Connected { get; set; }
        public bool rfidTactSensorConnected { get; set; }

        public bool rfidReaderConnected_1 { get; set; }
        public bool rfidReaderConnected_2 { get; set; }
        public bool rfidReaderConnected_3 { get; set; }
        public bool rfidReaderConnected_4 { get; set; }
        public bool rfidReaderConnected_5 { get; set; }
        public bool rfidReaderConnected_6 { get; set; }
        public bool rfidReaderConnected_7 { get; set; }
        public bool rfidReaderConnected_8 { get; set; }
        public bool rfidReaderConnected_9 { get; set; }
        public bool rfidReaderConnected_10 { get; set; }
        public bool rfidReaderConnected_11 { get; set; }
        public bool rfidReaderConnected_12 { get; set; }
        public bool rfidReaderConnected_13 { get; set; }


        public int occupiedplates { get; set; }
        public double occupiedplatespercentage { get; set; }

        public string currentplate { get; set; }
        public string nextplate { get; set; }

        public ShiftType currentshift { get; set; }
        public bool CarouselWorking { get; set; }

        public List<StandStatItem> StandsStats { get; set; }

        public StatusReportType()
        {
            StandsStats = new List<StandStatItem>();
            currentshift = new ShiftType();
        }





        void runSave()
        {
            Task st = new Task(new Action(()=>Save()));
            st.RunSynchronously();
        }

        public async void Save()
        {
            string path = CarouselType.Path + @"\" + StatusReportType.FileName;
            try
            {    
                string js = JsonConvert.SerializeObject(this);
                mySQLcore m = mySQLcore.DB_Main();
                //mySQLcore.KillSleepConnections(m, 100);
                m.InsertOnDuplicateUpdate("1", js);
            }
            catch (Exception ex)
            {

               
            }

        }

        public static StatusReportType GetData()
        {
            string path = CarouselType.Path + @"\" + StatusReportType.FileName;
            StatusReportType o = new StatusReportType();

            DataTable dt = new DataTable();
            mySQLcore m = mySQLcore.DB_Main();

            //mySQLcore.KillSleepConnections(m, 100);

            dt = m.FillDatatable("select * from stat where id=0");
            if (dt != null)
            {
            if (dt.Rows.Count > 0)
            {
                string js = dt.Rows[0]["val"].ToString();
                o = JsonConvert.DeserializeObject<StatusReportType>(js);
            }
            }

                   
            return o;
        }


        public string toJson()
        {
            string js = JsonConvert.SerializeObject(this);
            return js;
        }

        public static StatusReportType FromJson(string js)
        {
            StatusReportType o = JsonConvert.DeserializeObject<StatusReportType>(js);
            return o;
        }

        public class StandStatItem
        {
            public string StandName { get; set; }
            public string Name { get; set; }
            public int SortedParcels { get; set; }
            public int MissedParcels { get; set; }

        }
    }
}
