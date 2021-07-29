using ASS.devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS
{
    public class StandItemType
    {
        public DirectionType Direction { get; set; }

        public int MissedParcelsCount { get; set; }
        public int SortedParcels { get; set; }
        public int AllSortedParcels { get; set; }

        public int Lamp1ONTacts { get; set; }

        public LampType Lamp1 { get; set; }
        public LampType Lamp2 { get; set; }
        public LampType Lamp3 { get; set; }
        public LampType Lamp4 { get; set; }

        public bool Lamp2ByTacts { get; set; }
        public StandItemType()
        {                        
            Lamp1 = new LampType();
            Lamp2 = new LampType();
            Lamp3 = new LampType();
            Lamp4 = new LampType();

          

        }


        async void rfidTactSensorOnRead(object sender, SerialPortDevice.SerialPortEventArgs e)
        {

        }
    }
}
