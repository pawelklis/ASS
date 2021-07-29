using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS.devices
{

    public class RFIDTactSensorType:SensorType
    {

        public RFIDTactSensorType(List<PlateType> platesList)
        {
            this.plates = platesList;            
        }

        public bool Tacting { get; set; }
        public List<PlateType> plates { get; set; }

        public string CurrentReadedPlateID { get; set; }

        public PlateType GetPlate(int index)
        {
            if (index < plates.Count)
                return plates[index];

            return new PlateType();
        }

        public PlateType currentPlate()
        {
            foreach(var p in plates)
            {
                if (p.PlateID == CurrentReadedPlateID)
                    return p;
            }
            return new PlateType();
        }

        public string NextPlateID()
        {
            string np = "";

            if (plates == null)
                return "";

            int currentIndex = CurrentIndex();
            if (currentIndex+1 == plates.Count-1)
                currentIndex = 0;

            if (currentIndex + 1 == plates.Count)
            {
                np = "";
            }
            else
            {
                if (plates.Count > 0)
                {
                    np = plates[currentIndex + 1].PlateID;
                }
                else
                {
                    np = "";
                }
            }
            return np;
        }


        public int CurrentIndex()
        {

            if (plates == null)
                return 0;

            int i = 0;
            foreach(var p in plates)
            {
                if (p.PlateID == CurrentReadedPlateID)
                {
                    return i;
                }
                i += 1;
            }
            return 0;
        }


    }
}
