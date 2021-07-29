using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS
{
    public class ShiftType
    {

        public int id { get; set; }
        public DateTime ShiftStart { get; set; }
        public DateTime ShiftEnd { get; set; }
        
        public static ShiftType GetLastShift()
        {
            ShiftType o = new ShiftType();
            mySQLcore m = mySQLcore.DB_Main();
            o = m.GetSingleObject<ShiftType>("select * from shiftstb order by id desc limit 1;");

            if (o.IsOpen() == true)
            {
                return o;
            }

            return new ShiftType();
        }

        public bool IsOpen()
        {
            if (ShiftStart == new DateTime(1, 1, 1, 0, 0, 0))
            {
                return false;
            }
            if (ShiftEnd == new DateTime(1, 1, 1, 0, 0, 0))
            {
                return true;
            }
            return false;
        }

        public void StartShift()
        {
            this.ShiftStart = DateTime.Now;
            SaveAsync();
        }
        public void EndShift( List<StandType> stands)
        {
            this.ShiftEnd = DateTime.Now;

            SaveStats( stands);

            SaveAsync();
        }
        private void SaveAsync()
        {
            Task.Run(() => Save());
        }
        private void Save()
        {
            mySQLcore m = mySQLcore.DB_Main();

            if (this.id == 0)
            {
                this.id =int.Parse( m.ExecuteScalar("insert into shiftstb (shiftstart) values ('" + this.ShiftStart + "');select last_insert_id();"));
            }
            else
            {
                m.Update("shiftstb", "id", this);
            }
           
        }



        private async Task SaveStats(  List<StandType> stands)
        {
            mySQLcore m = mySQLcore.DB_Main();
            DataTable dt = new DataTable();
            dt.Columns.Add("Stanowisko");
            dt.Columns.Add("Kierunek");
            dt.Columns.Add("Podzielone przesyłki");
            dt.Columns.Add("Pominięte przesyłki");
            dt.Columns.Add("Wszystkie przesyłki");
            dt.Columns.Add("Obciążenie");
            dt.Columns.Add("Efektywnosc");
            foreach(var s in stands)
            {
                double sorted = s.StandItem1.SortedParcels;
                double mised = s.StandItem1.MissedParcelsCount;
                double all = s.StandItem1.AllSortedParcels;
                double obciazenie = (sorted / all) * (double)100;
                double efektywnosc =(double)100 - ((mised / all) * (double)100);

                dt.Rows.Add(s.Name, s.StandItem1.Direction.Name, s.StandItem1.SortedParcels, s.StandItem1.MissedParcelsCount, s.StandItem1.AllSortedParcels,obciazenie,efektywnosc);

                 sorted = s.StandItem2.SortedParcels;
                 mised = s.StandItem2.MissedParcelsCount;
                 all = s.StandItem2.AllSortedParcels;
                 obciazenie = (sorted / all) * (double)100;
                 efektywnosc = (double)100 - ((mised / all) * (double)100);

                dt.Rows.Add(s.Name, s.StandItem2.Direction.Name, s.StandItem2.SortedParcels, s.StandItem2.MissedParcelsCount, s.StandItem2.AllSortedParcels, obciazenie, efektywnosc);

                sorted = s.StandItem3.SortedParcels;
                mised = s.StandItem3.MissedParcelsCount;
                all = s.StandItem3.AllSortedParcels;
                obciazenie = (sorted / all) * (double)100;
                efektywnosc = (double)100 - ((mised / all) * (double)100);

                dt.Rows.Add(s.Name, s.StandItem3.Direction.Name, s.StandItem3.SortedParcels, s.StandItem3.MissedParcelsCount, s.StandItem3.AllSortedParcels, obciazenie, efektywnosc);

                sorted = s.StandItem4.SortedParcels;
                mised = s.StandItem4.MissedParcelsCount;
                all = s.StandItem4.AllSortedParcels;
                obciazenie = (sorted / all) * (double)100;
                efektywnosc = (double)100 - ((mised / all) * (double)100);

                dt.Rows.Add(s.Name, s.StandItem4.Direction.Name, s.StandItem4.SortedParcels, s.StandItem4.MissedParcelsCount, s.StandItem4.AllSortedParcels, obciazenie, efektywnosc);
            }

            string js = JsonConvert.SerializeObject(dt);


            m.ExecuteNonQuery("insert into standstats (shiftid,js) VALUES ('" + this.id +"','" + js + "');");

        }

    }
}
