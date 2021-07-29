using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASS_WEB
{
    public partial class settings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ifr1.Src = "~/directions.aspx";
                ifr2.Src = "~/stands.aspx";
                ifr3.Src = "~/params.aspx";
                ifr4.Src = "~/plates.aspx";
            }
        }
    }
}