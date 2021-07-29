using ASS.devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ASS
{
    public class StandType
    {
        public string Name { get; set; }

        public StandItemType StandItem1 { get; set; }
        public StandItemType StandItem2 { get; set; }
        public StandItemType StandItem3 { get; set; }
        public StandItemType StandItem4 { get; set; }
        
        public StandType()
        {
            StandItem1 = new StandItemType();
            StandItem2 = new StandItemType();
            StandItem3 = new StandItemType();
            StandItem4 = new StandItemType();

        }

        public bool Lamp1isOn { get; set; }
        public LampType Lamp1()
        {
            return StandItem1.Lamp1;
        }

    }
}
