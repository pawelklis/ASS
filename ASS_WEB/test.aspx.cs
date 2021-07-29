using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASS;

namespace ASS_WEB
{
    public partial class test : System.Web.UI.Page
    {
        int MAxTactTime { get; set; }
        int tik { get; set; }
        private bool NeedMaxReset { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                tik = 4990;
                MAxTactTime = 0;
                //Timer1.Interval = 1000;
                //Timer1.Enabled = true;
            }
        }

        //protected void Timer1_Tick(object sender, EventArgs e)
        //{
        //    StatusReportType StatReport = StatusReportType.GetData();
        //    lbTactsCount.Text = StatReport.TactsCount.ToString();

        //    Dicts dicts = Dicts.GetData();


        //    if (NeedMaxReset == true)
        //    {
        //        MAxTactTime = 0;
        //        NeedMaxReset = false;
        //    }

        //    //if (carousel.Isworking == true)
        //    //{
        //    //    labelIsWorking.Text = "PRACA";
        //    //    labelIsWorking.ForeColor = Color.DarkGreen;
        //    //}
        //    //else
        //    //{
        //    //    labelIsWorking.Text = "STOP";
        //    //    labelIsWorking.ForeColor = Color.Red;
        //    //    NeedMaxReset = true;
        //    //}

        //    if (tik > 5000)
        //    {
        //        MAxTactTime = 0;
        //        tik = 0;
        //    }

        //    if (MAxTactTime < StatReport.TactTime.TotalMilliseconds)
        //        MAxTactTime = (int)StatReport.TactTime.TotalMilliseconds;


        //    lbTime.Text = DateTime.Now.ToString();



        //    lbLastTact.Text = StatReport.LastTactTime.ToString();
        //    lbSuposedTact.Text = StatReport.SuppposedTactTime.ToString();
        //    lbtacttime.Text = StatReport.TactTime.ToString() + "\n " + StatReport.TactTime.TotalMilliseconds.ToString() + " [ms] \n max:" + MAxTactTime + " [ms] " + "\n Takty:" + StatReport.TactsCount;
        //    //lbworkdetect.Text = Dicts.WorkdetectionIntervalMS.ToString() + "[ms]";

        //    dg1.DataSource = StatReport.StandsStats;
        //    dg1.DataBind();

        //    tik += 1;
        //}

        //protected void btnSettings_Click(object sender, EventArgs e)
        //{
        //    ifr.Src = "~/settings.aspx";
        //}
    }
}