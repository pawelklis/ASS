using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASS;
using SimpleTCP;

namespace ASS_WEB
{
    public partial class plates : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }

        void Bind()
        {
            Dicts dicts = Dicts.GetData();
            dg1.DataSource = dicts.Plates;
            dg1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Dicts dicts = Dicts.GetData();
            dicts.Plates.Clear();
            
            dicts.Save();

            SendSave();

            Bind();

        }

        void SendSave()
        {
            try
            {
                string message = "refreshDicts";
                SimpleTcpClient client;
                client = new SimpleTcpClient();
                client.StringEncoder = Encoding.UTF8;
                //client.DataReceived += Client_DataReceived;
                client = new SimpleTcpClient().Connect("127.0.0.1", Convert.ToInt32("4444"));

                TimeSpan ts = new TimeSpan(0, 0, 5);
                string response = client.WriteLineAndGetReply(message, ts).MessageString;

            }
            catch (Exception ex)
            {

            }
        }

        protected void dg1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridViewRow gvr = (GridViewRow)((Button)e.CommandSource).NamingContainer;

                int i = gvr.RowIndex;
                string nazwa = ((TextBox)dg1.Rows[i].FindControl("txp")).Text;

                int index = (int)e.CommandArgument;

                Dicts dicts = Dicts.GetData();

                dicts.Plates[index].PlateID = nazwa;

                dicts.Save();
                SendSave();




            }
            catch (Exception)
            {

                
            }
        }
    }
}