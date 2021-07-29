using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASS;

namespace ASS_WEB
{
    public partial class statistics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = StatisticsType.GetShiftsListAsync().Result;
                ddlShifts.Items.Clear();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListItem item = new ListItem();
                    item.Value = dt.Rows[i]["id"].ToString();
                    item.Text = dt.Rows[i]["shiftstart"].ToString() + " - " + dt.Rows[i]["shiftend"].ToString();
                    ddlShifts.Items.Add(item);
                }


            }
        }

        protected void imgDownload_Click(object sender, ImageClickEventArgs e)
        {
            DataTable dt = StatisticsType.GetParcelsAsync(int.Parse(ddlShifts.SelectedValue.ToString())).Result;


            byte[] Content = System.Text.Encoding.GetEncoding(1252).GetBytes(ToCSV(dt));
            Response.ContentType = "text/csv";
            Response.AddHeader("content-disposition", "attachment; filename=" + "Run_parcels_" + ddlShifts.SelectedValue.ToString() + ".csv");
            Response.BufferOutput = true;
            Response.ContentEncoding = Encoding.GetEncoding(1252);
            Response.OutputStream.Write(Content, 0, Content.Length);
            Response.End();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = StatisticsType.GetParcelsAsync(int.Parse(ddlShifts.SelectedValue.ToString())).Result;
            dg1.DataSource = dt;
            dg1.DataBind();


            DataTable at = StatisticsType.GetStandStatsAsync(int.Parse(ddlShifts.SelectedValue.ToString())).Result;
            dg2.DataSource = at;
            dg2.DataBind();

        }



        string ToCSV(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder line = new StringBuilder();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                line.Append(dt.Columns[i]);
                if (i < dt.Columns.Count - 1)
                {
                    line.Append(";");
                }
            }
            sb.AppendLine(line.ToString());
            line = new StringBuilder();

            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(';'))
                        {
                            value = String.Format("\"{0}\"", value);
                           line.Append(value);
                        }
                        else
                        {
                            line.Append(dr[i].ToString());
                        }
                    }
                    if (i < dt.Columns.Count - 1)
                    {
                        line.Append(";");
                    }
                }
                sb.AppendLine(line.ToString());
                line = new StringBuilder();
            }


            string a = sb.ToString();

            return sb.ToString();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            DataTable dt = StatisticsType.GetStandStatsAsync(int.Parse(ddlShifts.SelectedValue.ToString())).Result;


            byte[] Content = System.Text.Encoding.GetEncoding(1252).GetBytes(ToCSV(dt));
            Response.ContentType = "text/csv";
            Response.AddHeader("content-disposition", "attachment; filename=" + "Run_stands_" + ddlShifts.SelectedValue.ToString() + ".csv");
            Response.BufferOutput = true;
            Response.ContentEncoding = Encoding.GetEncoding(1252);
            Response.OutputStream.Write(Content, 0, Content.Length);
            Response.End();
        }
    }
}