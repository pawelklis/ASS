using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS
{
    public class DirectionType
    {
        public string Name { get; set; }


        public List<DirectionItemType> DirectionsPNAList { get; set; }

        public DirectionType()
        {
            this.DirectionsPNAList = new List<DirectionItemType>();
        }



        public bool isInRange(string PNA)
        {
            if (PNA == null)
                PNA = "99999";
            PNA = PNA.Replace("-", "");
            foreach (var sd in DirectionsPNAList)
            {
                if (int.Parse(PNA) >= int.Parse(sd.PnaFrom) && int.Parse(PNA) <= int.Parse(sd.PnaTo))
                {
                    return true;
                }
            }

            return false;
        }

    }
}
