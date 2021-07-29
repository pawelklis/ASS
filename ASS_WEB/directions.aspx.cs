using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASS;
using SimpleTCP;

namespace ASS_WEB
{
    public partial class directions : System.Web.UI.Page
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

            DataTable dt = new DataTable();
            dt.Columns.Add("nazwa");
            dt.Columns.Add("pnaod");
            dt.Columns.Add("pnado");
            dt.Columns.Add("wsr");

            foreach (var d in dicts.Directions)
            {
                foreach (var i in d.DirectionsPNAList)
                {
                    dt.Rows.Add(d.Name, i.PnaFrom, i.PnaTo, i.WSR);
                }
            }

            dt.Rows.Add("", "", "", "");

            dg1.DataSource = dt;
            dg1.DataBind();
        }


        void Save()
        {
            Dicts dicts = Dicts.GetData();

            dicts.Directions.Clear();

            for (int i = 0; i < dg1.Rows.Count ; i++)
            {
                string nazwa = ((TextBox)dg1.Rows[i].FindControl("txName")).Text;
                string pnaOdd = ((TextBox)dg1.Rows[i].FindControl("txpnaod")).Text;
                string pnaDod = ((TextBox)dg1.Rows[i].FindControl("txpnado")).Text;
                string wsr = ((TextBox)dg1.Rows[i].FindControl("txwsr")).Text;

                if (!string.IsNullOrEmpty(nazwa))
                {
                    DirectionType kierunek = getKierunekFromKierunki(nazwa, dicts.Directions);

                    DirectionItemType item = new DirectionItemType();
                    item.PnaFrom = pnaOdd;
                    item.PnaTo = pnaDod;
                    item.WSR = wsr;

                    kierunek.DirectionsPNAList.Add(item);
                }



            }

            dicts.Save();
        }


        string SendToserverAndGetResponse(string message)
        {
            try
            {
                SimpleTcpClient client;
                client = new SimpleTcpClient();
                client.StringEncoder = Encoding.UTF8;
                //client.DataReceived += Client_DataReceived;
                client = new SimpleTcpClient().Connect("127.0.0.1", Convert.ToInt32("4444"));

                TimeSpan ts = new TimeSpan(0, 0, 5);
                string response = client.WriteLineAndGetReply(message, ts).MessageString;
                return response;
            }
            catch (Exception ex)
            {

            }
            return "";
        }

        DirectionType getKierunekFromKierunki(string nazwa, List<DirectionType> kierunki)
        {
            foreach (var k in kierunki)
            {
                if (k.Name == nazwa)
                {
                    return k;
                }
            }

            DirectionType kierunek = new DirectionType();
            kierunek.Name = nazwa;

            kierunki.Add(kierunek);
            return kierunek;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            Bind();
            SendToserverAndGetResponse("refreshDicts");
        }

        protected void dg1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                GridViewRow gvr = (GridViewRow)((Button)e.CommandSource).NamingContainer;

                int i = gvr.RowIndex;

                string nazwa = ((TextBox)dg1.Rows[i].FindControl("txName")).Text;
                string pnaOdd = ((TextBox)dg1.Rows[i].FindControl("txpnaod")).Text;
                string pnaDod = ((TextBox)dg1.Rows[i].FindControl("txpnado")).Text;
                string wsr = ((TextBox)dg1.Rows[i].FindControl("txwsr")).Text;

                Dicts dicts = Dicts.GetData();
                foreach (var d in dicts.Directions)
                {
                    foreach (var x in d.DirectionsPNAList)
                    {                        
                        if (d.Name == nazwa)
                        {
                            if (x.PnaFrom == pnaOdd)
                            {
                                if (x.PnaTo == pnaDod)
                                {
                                    if (x.WSR == wsr)
                                    {
                                        d.DirectionsPNAList.Remove(x);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("nazwa");
                dt.Columns.Add("pnaod");
                dt.Columns.Add("pnado");
                dt.Columns.Add("wsr");

                foreach (var d in dicts.Directions)
                {
                    foreach (var y in d.DirectionsPNAList)
                    {
                        dt.Rows.Add(d.Name, y.PnaFrom, y.PnaTo, y.WSR);
                    }
                }

                dt.Rows.Add("", "", "", "");

                dg1.DataSource = dt;
                dg1.DataBind();

                Save();
                Bind();

            }
        }
    }
}