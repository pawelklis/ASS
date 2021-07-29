using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS
{
    public class tactLogType
    {
        public int id { get; set; }
        public int TactNumber { get; set; }
        public int Time { get; set; }
        public string PlateID { get; set; }
        public DateTime RunDate { get; set; }
        public int roundNumber { get; set; }
        public int ParcelsOnbuffer { get; set; }
        public int ParcelsOnLine { get; set; }

        public int StartSensorReads { get; set; }
        public int StoptSensorReads { get; set; }
        public int TactSensorReads { get; set; }
        public int LenghtSensorReads { get; set; }
        public int SignalingReads { get; set; }
        public int Scanner1SensorReads { get; set; }
        public int PlateSensorReads { get; set; }
        public int Stand1_Reads { get; set; }
        public int Stand2_Reads { get; set; }
        public int Stand3_Reads { get; set; }
        public int Stand4_Reads { get; set; }
        public int Stand5_Reads { get; set; }
        public int Stand6_Reads { get; set; }
        public int Stand7_Reads { get; set; }
        public int Stand8_Reads { get; set; }
        public int Stand9_Reads { get; set; }
        public int Stand10_Reads { get; set; }
        public int Stand11_Reads { get; set; }
        public int Stand12_Reads { get; set; }
        public int Stand13_Reads { get; set; }
        public int SignalingWrites { get; set; }
        public DataTable dt { get; set; }

        public int TCPRead { get; set; }
        public int TCPWrite { get; set; }
        public int MysqlCommand { get; set; }

        public int TimeStamp { get; set; }

        public tactLogType(int TactNumber, string time, string plateID,int roundnumber,int parcelsbuffer,int parcelsline,
         int StartSensorReads ,
         int StoptSensorReads ,
         int TactSensorReads ,
         int LenghtSensorReads ,
         int SignalingReads ,
         int Scanner1SensorReads ,
         int PlateSensorReads ,
         int Stand1_Reads ,
         int Stand2_Reads ,
         int Stand3_Reads ,
         int Stand4_Reads ,
         int Stand5_Reads ,
         int Stand6_Reads ,
         int Stand7_Reads ,
         int Stand8_Reads ,
         int Stand9_Reads ,
         int Stand10_Reads ,
         int Stand11_Reads ,
         int Stand12_Reads ,
         int Stand13_Reads     ,
         int signalingwrites, int tcpread,int tcpwrite,int mysqlcommand, DataTable tb, int timestamp
            )
        {
            int test = 0;
       

            this.TactNumber = TactNumber ;
            //this.Time = int.Parse(time.Split(',')[0]);

            int.TryParse(time.Split(',')[0], out test);
            this.Time = test;

            this.TimeStamp = timestamp;

            this.PlateID = plateID;
            this.RunDate = DateTime.Now;
            this.roundNumber = roundnumber;
            this.ParcelsOnbuffer = parcelsbuffer;
            this.ParcelsOnLine = parcelsline;
            this.StartSensorReads = StartSensorReads;
            this.StoptSensorReads = StoptSensorReads;
            this.TactSensorReads = TactSensorReads;
            this.LenghtSensorReads = LenghtSensorReads;
            this.SignalingReads = SignalingReads;
            this.Scanner1SensorReads = Scanner1SensorReads;
            this.PlateSensorReads = PlateSensorReads;
            this.Stand1_Reads = Stand1_Reads;
            this.Stand2_Reads = Stand2_Reads;
            this.Stand3_Reads = Stand3_Reads;
            this.Stand4_Reads = Stand4_Reads;
            this.Stand5_Reads = Stand5_Reads;
            this.Stand6_Reads = Stand6_Reads;
            this.Stand7_Reads = Stand7_Reads;
            this.Stand8_Reads = Stand8_Reads;
            this.Stand9_Reads = Stand9_Reads;
            this.Stand10_Reads = Stand10_Reads;
            this.Stand11_Reads = Stand11_Reads;
            this.Stand12_Reads = Stand12_Reads;
            this.Stand13_Reads = Stand13_Reads;
            this.SignalingWrites = signalingwrites;
            this.TCPRead = tcpread;
            this.TCPWrite = tcpwrite;
            this.MysqlCommand = mysqlcommand;
            this.dt = tb;
        }

        public static  string ToJson(List<tactLogType> l)
        {
            string js = JsonConvert.SerializeObject(l);
            return js;
        }

        public static void SaveAsync(List<tactLogType> l)
        {
            Task.Run(() => Save(l));
        }
        private static void Save(List<tactLogType> l)
        {
            if (l != null)
            {
                if (l.Count > 0)
                {
                    mySQLcore m = mySQLcore.DB_Main();                   

                    string delid = m.GetString("SELECT id FROM tactlogs order by id desc limit 49,50;");
                    m.ExecuteNonQuery("delete from tactlogs where id < " + delid + ";");

                    TactLogDBType o = new TactLogDBType();
                    o.js = ToJson(l);
                    o.roundnumber = l[0].roundNumber;
                    m.Insert("tactlogs", "id", o);
                }
            }
        }

    }


    public class TactLogDBType
    {
        public int id { get; set; }
        public string js { get; set; }
        public int roundnumber { get; set; }



        public static List<tactLogType> GetData(int id)
        {
            mySQLcore m = mySQLcore.DB_Main();

            string js = m.GetString("select js from tactlogs where id = '" + id + "';");
            List<tactLogType> l = JsonConvert.DeserializeObject<List<tactLogType>>(js);
            return l;

        }
    }
}
