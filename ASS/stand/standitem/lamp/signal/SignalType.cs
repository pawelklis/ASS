using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS
{
    public class SignalType
    {
        public string Prefix { get; set; }
        public string Content { get; set; }
        public string Sufix { get; set; }


        public string FullSignal()
        {
            if (Content == null)
                Content = "";

            string s = "";
            if (Content.Contains(","))
            {
                List<string> ci = Content.Split(char.Parse(",")).ToList();

                foreach(var ss in ci)
                {
                    s=s + Prefix + "," + ss + "," + Sufix + ",";
                }

                s = s.Substring(0, s.Length - 1);
            }
            else
            {
                s = Prefix + "," + Content + "," + Sufix;
            }


            
            return s;
        }

        public SignalType()
        {
            Prefix = "27";
            Content = "0";
            Sufix = "10,13";
        }

    }
}
