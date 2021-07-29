using ASS.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS
{
    public static class TrackingInterface
    {
        public static ASS.ServiceReference1.Przesylka SprawdzPrzesylke(string nr)
        {
            SledzeniePortTypeClient service = new SledzeniePortTypeClient();
            service.ClientCredentials.UserName.UserName = "sledzeniepp";
            service.ClientCredentials.UserName.Password = "PPSA";
            ASS.ServiceReference1.Przesylka p;
            try
            {
                p   = service.sprawdzPrzesylkePl(nr);
            }
            catch (Exception)
            {

                return null;
            }

  
            return p;
        }

        public static List<ASS.ServiceReference1.Przesylka> SprawdzPrzesylki(string[] nr)
        {
            SledzeniePortTypeClient service = new SledzeniePortTypeClient();
            service.ClientCredentials.UserName.UserName = "sledzeniepp";
            service.ClientCredentials.UserName.Password = "PPSA";

            List<ASS.ServiceReference1.Przesylka> lp = new List<ASS.ServiceReference1.Przesylka>();
            List<string> nrl = new List<string>();
            int max = service.maksymalnaLiczbaPrzesylek();

            foreach (var sn in nr)
            {
                if (nrl.Count < max)
                    nrl.Add(sn);
                if (nrl.Count > max - 1)
                {
                    var ok = service.sprawdzPrzesylki(nrl.ToArray());
                    foreach (var p in ok.przesylki)
                        lp.Add(p);
                    nrl.Clear();
                }
            }

            return lp;
        }
    }
}
