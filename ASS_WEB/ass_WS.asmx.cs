using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ASS;

namespace ASS_WEB
{
    /// <summary>
    /// Summary description for ass_WS
    /// </summary>
    [WebService(Namespace = "http://localhost.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ass_WS : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public void SaveWS(string js)
        {
            mySQLcore m = mySQLcore.DB_Main();
            //mySQLcore.KillSleepConnections(m, 100);
            m.InsertOnDuplicateUpdate("1", js);
        }

    }
}
