using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASS_WEB
{
    public partial class start : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ifr.Src = "~/dasch.aspx";

                System.Reflection.Assembly executingAssembly = System.Reflection.Assembly.GetExecutingAssembly();
                var fieVersionInfo = FileVersionInfo.GetVersionInfo(executingAssembly.Location);
                var version = fieVersionInfo.FileVersion;

                lv.Text = "v." + version;
            }
        }


        protected void btnSettings_Click(object sender, EventArgs e)
        {
            ifr.Src = "~/settings.aspx";
        }

        protected void BtnMain_Click(object sender, EventArgs e)
        {
            ifr.Src = "~/dasch.aspx";
        }

        protected void btnDiagnosis_Click(object sender, EventArgs e)
        {
            ifr.Src = "~/diagnosis.aspx";
        }

        protected void btnstats_Click(object sender, EventArgs e)
        {
            ifr.Src = "~/statistics.aspx";
        }
    }
}