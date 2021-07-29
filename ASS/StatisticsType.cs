using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ASS
{
    public class StatisticsType
    {

        public static async Task<DataTable> GetStandStatsAsync(int shiftid)
        {
            DataTable dt = Task.Run(() => GetStandStats(shiftid)).Result;
            return dt;
        }
        private static DataTable GetStandStats(int shiftid)
        {
            mySQLcore m = mySQLcore.DB_Main();
            DataTable at = m.FillDatatable("select * from standstats where shiftid=" + shiftid + ";");

            if (at == null)
                at = new DataTable();
            DataTable dt;
            if (at.Rows.Count == 0)
            {
                at = new DataTable();
                at.Columns.Add("js");

                DataTable empt = new DataTable();
                empt.Columns.Add("Empty");
                empt.Rows.Add("Brak danych");


                dt = empt;
            }
            else
            {

                dt = JsonConvert.DeserializeObject<DataTable>(at.Rows[0]["js"].ToString());
            }



            return dt;
        }


        public static async Task<DataTable> GetShiftsListAsync()
        {
            DataTable dt = Task.Run(()=>GetShiftsList()).Result;
            return dt;            
        }
            private static DataTable GetShiftsList()
            {
                mySQLcore m = mySQLcore.DB_Main();
                DataTable dt = m.FillDatatable("select id,shiftstart,shiftend from shiftstb where shiftend is not null order by id desc;");
                return dt;
            }




        public static async Task<DataTable> GetParcelsAsync(int shiftid)
        {
            DataTable dt =  Task.Run(() => GetParcels(shiftid)).Result;
            return dt;
        }
            private static DataTable GetParcels(int shiftid)
            {
                mySQLcore m = mySQLcore.DB_Main();
                DataTable dt = m.FillDatatable("" +
                " select " +
                " id," +
                " shiftid," +
                "`number` as 'Numer przesylki'," +
                " dest as 'Kierunek'," +
                "`time` as 'Czas przebiegu'," +
                " tm," +
                " content->> '$.rodzPrzes' as 'Rodzaj przesyłki'," +
                " content->> '$.zdarzenia' as 'Zdarzenia'," +
                " content->> '$.dataNadania' as 'Data nadania'," +
                " content->> '$.urzadPrzezn.nazwa' as 'UP przeznaczenia'," +
                " content->> '$.urzadPrzezn.daneSzczegolowe.pna' as 'UP przeznaczenia PNA'," +
                " content->> '$.urzadNadania.nazwa' as 'UP Nadania'," +
                " content->> '$.urzadNadania.daneSzczegolowe.pna' as 'UP nadania PNA'" +
                " from parcels where shiftid = " + shiftid + "; ");
       
                return dt;
            }



    }
}
