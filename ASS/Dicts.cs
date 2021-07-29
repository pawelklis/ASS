using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ASS
{
     public class Dicts
    {

        public bool TurnOffLampByTimer { get; set; }

        public List<StandType> Stands { get; set; }
        public List<DirectionType> Directions { get; set; }



        public bool StartSensorIsON { get; set; }
        public bool StopSensorIsON { get; set; }
        public bool TactSensorIsON { get; set; }
        public bool Scanner1IsON { get; set; }
        public bool SignalingIsON { get; set; }
        public bool LenghtSensorIsON { get; set; }
        public bool rfidTactSensorIsON { get; set; }

        public bool rfidTactSensorTacting { get; set; }
        
        public bool rfidReader_IsON1 { get; set; }
        public bool rfidReader_IsON2 { get; set; }
        public bool rfidReader_IsON3 { get; set; }
        public bool rfidReader_IsON4 { get; set; }
        public bool rfidReader_IsON5 { get; set; }
        public bool rfidReader_IsON6 { get; set; }
        public bool rfidReader_IsON7 { get; set; }
        public bool rfidReader_IsON8 { get; set; }
        public bool rfidReader_IsON9 { get; set; }
        public bool rfidReader_IsON10 { get; set; }
        public bool rfidReader_IsON11 { get; set; }
        public bool rfidReader_IsON12 { get; set; }
        public bool rfidReader_IsON13 { get; set; }


        public string StartSensorPort { get; set; }
        public string StopSensorPort { get; set; }
        public string TactSensorPort { get; set; }
        public string Scanner1Port { get; set; }
        public string SignalingPort { get; set; }
        public string LenghtSensorPort { get; set; }
        public string rfidTactSensorPort { get; set; }
        

        public int StartSensorSpeed { get; set; }
        public int StopSensorSpeed { get; set; }
        public int TactSensorSpeed { get; set; }
        public int Scanner1Speed { get; set; }
        public int SignalingSpeed { get; set; }
        public int LenghtSensorSpeed { get; set; }
        public int rfidTactSensorSpeed { get; set; }

        public int StartSensorDelay { get; set; }
        public int StopSensorDelay { get; set; }
        public int TactSensorDelay { get; set; }
        public int Scanner1Delay { get; set; }
        public int SignalingDelay { get; set; }
        public int LenghtSensorDelay { get; set; }
        public int rfidTactSensorDelay { get; set; }

        public string StartSensorName { get; set; }
        public string StopSensorName { get; set; }
        public string TactSensorName { get; set; }
        public string Scanner1Name { get; set; }
        public string SignalingName { get; set; }
        public string LenghtSensorName { get; set; }
        public string rfidTactSensorName { get; set; }


        public string rfidReader_Port1 { get; set; }
        public int rfidReader_Speed1 { get; set; }
        public int rfidReader_Delay1 { get; set; }
        public string rfidReader_Name1 { get; set; }

        public string rfidReader_Port2 { get; set; }
        public int rfidReader_Speed2 { get; set; }
        public int rfidReader_Delay2 { get; set; }
        public string rfidReader_Name2 { get; set; }

        public string rfidReader_Port3 { get; set; }
        public int rfidReader_Speed3 { get; set; }
        public int rfidReader_Delay3 { get; set; }
        public string rfidReader_Name3 { get; set; }

        public string rfidReader_Port4 { get; set; }
        public int rfidReader_Speed4 { get; set; }
        public int rfidReader_Delay4 { get; set; }
        public string rfidReader_Name4 { get; set; }

        public string rfidReader_Port5 { get; set; }
        public int rfidReader_Speed5 { get; set; }
        public int rfidReader_Delay5 { get; set; }
        public string rfidReader_Name5 { get; set; }

        public string rfidReader_Port6 { get; set; }
        public int rfidReader_Speed6 { get; set; }
        public int rfidReader_Delay6 { get; set; }
        public string rfidReader_Name6 { get; set; }

        public string rfidReader_Port7 { get; set; }
        public int rfidReader_Speed7 { get; set; }
        public int rfidReader_Delay7 { get; set; }
        public string rfidReader_Name7 { get; set; }

        public string rfidReader_Port8 { get; set; }
        public int rfidReader_Speed8 { get; set; }
        public int rfidReader_Delay8 { get; set; }
        public string rfidReader_Name8 { get; set; }

        public string rfidReader_Port9 { get; set; }
        public int rfidReader_Speed9 { get; set; }
        public int rfidReader_Delay9 { get; set; }
        public string rfidReader_Name9 { get; set; }

        public string rfidReader_Port10 { get; set; }
        public int rfidReader_Speed10 { get; set; }
        public int rfidReader_Delay10 { get; set; }
        public string rfidReader_Name10 { get; set; }
        
        public string rfidReader_Port11 { get; set; }
        public int rfidReader_Speed11 { get; set; }
        public int rfidReader_Delay11 { get; set; }
        public string rfidReader_Name11 { get; set; }

        public string rfidReader_Port12 { get; set; }
        public int rfidReader_Speed12 { get; set; }
        public int rfidReader_Delay12 { get; set; }
        public string rfidReader_Name12 { get; set; }

        public string rfidReader_Port13 { get; set; }
        public int rfidReader_Speed13 { get; set; }
        public int rfidReader_Delay13 { get; set; }
        public string rfidReader_Name13 { get; set; }



        public int WorkdetectionIntervalMS { get; set; }
        public int AllTactsCount { get; set; }
        public bool CorrectDisposedMarkers { get; set; }
        public int ParcelLenghtFactor { get; set; }
        public int BetweenMarkresSpaceCM { get; set; }
        public int StopCorrection { get; set; }
        public bool AutoWorkdetectioninterval { get; set; }

        public int StopSensorTactsCount { get; set; }
        public int ReportStatusInterval { get; set; }

        public string CamAdress1 { get; set; }
        public string CamAdress2 { get; set; }
        public bool blackCam1 { get; set; }
        public bool blackCam2 { get; set; }
        public int cam1zoom { get; set; }
        public int cam2zoom { get; set; }
        public int CurrentTact { get; set; }
        public int RoundNumber { get; set; }
        public List<PlateType> Plates { get; set; }

        public int plateIendtityLenght { get; set; }

        public bool TactSensorSimulatePlates { get; set; }


        public Dicts()
        {
            Stands = new List<StandType>();
            Directions = new List<DirectionType>();
        }

    


        public static DirectionType RejectDirection()
        {
            DirectionType o = new DirectionType();
            o.Name = "Odrzuty";

            DirectionItemType oi = new DirectionItemType();
            oi.PnaFrom = "999999";
            oi.PnaTo = "999999";
            oi.WSR = "ODRZUT";

            o.DirectionsPNAList.Add(oi);

            return o;
        }


    

        private void Clone(Dicts o)
        {
            PropertyInfo[] thisProps = this.GetType().GetProperties();
            PropertyInfo[] oProps = o.GetType().GetProperties();


            foreach(var pthis in thisProps)
            {
                foreach(var oprop in oProps)
                {
                    if (pthis.Name == oprop.Name)
                    {
                        pthis.SetValue(this, oprop.GetValue(o));
                    }
                }
            }

        }

   
        void runSave()
        {
            Task st = new Task(new Action(() => Save()));
            st.RunSynchronously();
        }

        public async void Save()
        {
            string path = CarouselType.Path + @"\" + StatusReportType.FileName;
            try
            {
                string js = JsonConvert.SerializeObject(this);
                mySQLcore m = mySQLcore.DB_Main();
                m.ExecuteNonQuery("delete  from dicts");
                m.ExecuteNonQuery(" insert into dicts(id,content) values (0,'" + js + "');");
            }
            catch (Exception ex)
            {


            }

        }



        public StandItemType GetStandItem(string destinationName)
        {
            StandItemType o = new StandItemType();
            
            foreach(var s in Stands)
            {
                if (s.StandItem1.Direction.Name.ToLower() == destinationName.ToLower())
                    o = s.StandItem1;
                if (s.StandItem1.Direction.Name.ToLower() == destinationName.ToLower())
                    o = s.StandItem2;
                if (s.StandItem1.Direction.Name.ToLower() == destinationName.ToLower())
                    o = s.StandItem3;
                if (s.StandItem1.Direction.Name.ToLower() == destinationName.ToLower())
                    o = s.StandItem4;
            }
            
            return o;
        }

        public static Dicts GetData()
        {
            
            Dicts o = new Dicts();

            DataTable dt = new DataTable();
            mySQLcore m = mySQLcore.DB_Main();

            //mySQLcore.KillSleepConnections(m, 100);

            dt = m.FillDatatable("select * from dicts limit 1");

            if (dt?.Rows.Count > 0)
            {
                string js = dt?.Rows[0]["content"].ToString();
                o = JsonConvert.DeserializeObject<Dicts>(js);
            }

            return o;
        }


    }
}
