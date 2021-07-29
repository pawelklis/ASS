using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using ASS;

namespace ASS_WEB
{
    public partial class diagnosis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindDDL();
            }

        }


        void BindDDL()
        {
            DataTable dt = new DataTable();
            mySQLcore m = mySQLcore.DB_Main();
            dt = m.FillDatatable("select distinct id, roundnumber from tactlogs order by id desc;");
            DropDownList1.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem item = new ListItem();
                item.Text = dt.Rows[i][1].ToString();
                item.Value =dt.Rows[i][0].ToString();
                DropDownList1.Items.Add(item);
            }

            try
            {
                DropDownList1.SelectedValue = Session["selddl"].ToString();
            }
            catch (Exception)
            {

       
            }

        }

        void BindChart()
        {


            List<tactLogType> l = TactLogDBType.GetData(int.Parse(DropDownList1.SelectedValue.ToString()));



            this.chart1.Series.Clear();

            Session["selddl"] = DropDownList1.SelectedValue;
     
            chart1.Titles.Add("Okrążenie numer: " + DropDownList1.SelectedValue.ToString());

            if (CheckBox1.Checked)
            {
                chart1.Series.Add("TactTime");
                chart1.Series["TactTime"].XValueMember = "TactNumber";
                chart1.Series["TactTime"].YValueMembers = "Time";
                chart1.Series["TactTime"].IsValueShownAsLabel = false;

                chart1.Series["TactTime"].YAxisType = AxisType.Secondary;
                chart1.Series["TactTime"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
            }
            if (CheckBox2.Checked)
            {
                chart1.Series.Add("ParcelsOnBuffer");
                chart1.Series["ParcelsOnBuffer"].XValueMember = "TactNumber";
                chart1.Series["ParcelsOnBuffer"].YValueMembers = "ParcelsOnbuffer";
                chart1.Series["ParcelsOnBuffer"].IsValueShownAsLabel = false;
                chart1.Series["ParcelsOnBuffer"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
            }
            if (CheckBox3.Checked)
            {
                chart1.Series.Add("ParcelsOnLine");
                chart1.Series["ParcelsOnLine"].XValueMember = "TactNumber";
                chart1.Series["ParcelsOnLine"].YValueMembers = "ParcelsOnLine";
                chart1.Series["ParcelsOnLine"].IsValueShownAsLabel = false;
                chart1.Series["ParcelsOnLine"].YAxisType = AxisType.Secondary;
                chart1.Series["ParcelsOnLine"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
            }
            if (CheckBox4.Checked)
            {
                chart1.Series.Add("StartSensorReads");
                chart1.Series["StartSensorReads"].XValueMember = "TactNumber";
                chart1.Series["StartSensorReads"].YValueMembers = "StartSensorReads";
                chart1.Series["StartSensorReads"].IsValueShownAsLabel = false;
                chart1.Series["StartSensorReads"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
            }
            if (CheckBox5.Checked)
            {
                chart1.Series.Add("StoptSensorReads");
                chart1.Series["StoptSensorReads"].XValueMember = "TactNumber";
                chart1.Series["StoptSensorReads"].YValueMembers = "StoptSensorReads";
                chart1.Series["StoptSensorReads"].IsValueShownAsLabel = false;
                chart1.Series["StoptSensorReads"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
            }
            if (CheckBox6.Checked)
            {
                chart1.Series.Add("TactSensorReads");
                chart1.Series["TactSensorReads"].XValueMember = "TactNumber";
                chart1.Series["TactSensorReads"].YValueMembers = "TactSensorReads";
                chart1.Series["TactSensorReads"].IsValueShownAsLabel = false;
                chart1.Series["TactSensorReads"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
            }
            if (CheckBox7.Checked)
            {
                chart1.Series.Add("LenghtSensorReads");
                chart1.Series["LenghtSensorReads"].XValueMember = "TactNumber";
                chart1.Series["LenghtSensorReads"].YValueMembers = "LenghtSensorReads";
                chart1.Series["LenghtSensorReads"].IsValueShownAsLabel = false;
                chart1.Series["LenghtSensorReads"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
            }
            if (CheckBox8.Checked)
            {
                chart1.Series.Add("SignalingReads");
                chart1.Series["SignalingReads"].XValueMember = "TactNumber";
                chart1.Series["SignalingReads"].YValueMembers = "SignalingReads";
                chart1.Series["SignalingReads"].IsValueShownAsLabel = false;
                chart1.Series["SignalingReads"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
            }
            if (CheckBox9.Checked)
            {
                chart1.Series.Add("Scanner1SensorReads");
                chart1.Series["Scanner1SensorReads"].XValueMember = "TactNumber";
                chart1.Series["Scanner1SensorReads"].YValueMembers = "Scanner1SensorReads";
                chart1.Series["Scanner1SensorReads"].IsValueShownAsLabel = false;
                chart1.Series["Scanner1SensorReads"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
            }
            if (CheckBox10.Checked)
            {
                chart1.Series.Add("PlateSensorReads");
                chart1.Series["PlateSensorReads"].XValueMember = "TactNumber";
                chart1.Series["PlateSensorReads"].YValueMembers = "PlateSensorReads";
                chart1.Series["PlateSensorReads"].IsValueShownAsLabel = false;
                chart1.Series["PlateSensorReads"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
            }
            if (CheckBox11.Checked)
            {
                chart1.Series.Add("Stand1_Reads");
                chart1.Series["Stand1_Reads"].XValueMember = "TactNumber";
                chart1.Series["Stand1_Reads"].YValueMembers = "Stand1_Reads";
                chart1.Series["Stand1_Reads"].IsValueShownAsLabel = false;
                chart1.Series["Stand1_Reads"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
            }
            if (CheckBox12.Checked)
            {
                chart1.Series.Add("Stand2_Reads");
                chart1.Series["Stand2_Reads"].XValueMember = "TactNumber";
                chart1.Series["Stand2_Reads"].YValueMembers = "Stand2_Reads";
                chart1.Series["Stand2_Reads"].IsValueShownAsLabel = false;
                chart1.Series["Stand2_Reads"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
            }
            if (CheckBox13.Checked)
            {
                chart1.Series.Add("Stand3_Reads");
                chart1.Series["Stand3_Reads"].XValueMember = "TactNumber";
                chart1.Series["Stand3_Reads"].YValueMembers = "Stand3_Reads";
                chart1.Series["Stand3_Reads"].IsValueShownAsLabel = false;
                chart1.Series["Stand3_Reads"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
            }
            if (CheckBox14.Checked)
            {
                chart1.Series.Add("Stand4_Reads");
                chart1.Series["Stand4_Reads"].XValueMember = "TactNumber";
                chart1.Series["Stand4_Reads"].YValueMembers = "Stand4_Reads";
                chart1.Series["Stand4_Reads"].IsValueShownAsLabel = false;
                chart1.Series["Stand4_Reads"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
            }
            if (CheckBox15.Checked)
            {
                chart1.Series.Add("Stand5_Reads");
                chart1.Series["Stand5_Reads"].XValueMember = "TactNumber";
                chart1.Series["Stand5_Reads"].YValueMembers = "Stand5_Reads";
                chart1.Series["Stand5_Reads"].IsValueShownAsLabel = false;
                chart1.Series["Stand5_Reads"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
            }
            if (CheckBox16.Checked)
            {
                chart1.Series.Add("Stand6_Reads");
                chart1.Series["Stand6_Reads"].XValueMember = "TactNumber";
                chart1.Series["Stand6_Reads"].YValueMembers = "Stand6_Reads";
                chart1.Series["Stand6_Reads"].IsValueShownAsLabel = false;
                chart1.Series["Stand6_Reads"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
            }
            if (CheckBox17.Checked)
            {
                chart1.Series.Add("Stand7_Reads");
                chart1.Series["Stand7_Reads"].XValueMember = "TactNumber";
                chart1.Series["Stand7_Reads"].YValueMembers = "Stand7_Reads";
                chart1.Series["Stand7_Reads"].IsValueShownAsLabel = false;
                chart1.Series["Stand7_Reads"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
            }
            if (CheckBox18.Checked)
            {
                chart1.Series.Add("Stand8_Reads");
                chart1.Series["Stand8_Reads"].XValueMember = "TactNumber";
                chart1.Series["Stand8_Reads"].YValueMembers = "Stand8_Reads";
                chart1.Series["Stand8_Reads"].IsValueShownAsLabel = false;
                chart1.Series["Stand8_Reads"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
            }
            if (CheckBox19.Checked)
            {
                chart1.Series.Add("Stand9_Reads");
                chart1.Series["Stand9_Reads"].XValueMember = "TactNumber";
                chart1.Series["Stand9_Reads"].YValueMembers = "Stand9_Reads";
                chart1.Series["Stand9_Reads"].IsValueShownAsLabel = false;
                chart1.Series["Stand9_Reads"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
            }
            if (CheckBox20.Checked)
            {
                chart1.Series.Add("Stand10_Reads");
                chart1.Series["Stand10_Reads"].XValueMember = "TactNumber";
                chart1.Series["Stand10_Reads"].YValueMembers = "Stand10_Reads";
                chart1.Series["Stand10_Reads"].IsValueShownAsLabel = false;
                chart1.Series["Stand10_Reads"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
            }
            if (CheckBox21.Checked)
            {
                chart1.Series.Add("Stand11_Reads");
                chart1.Series["Stand11_Reads"].XValueMember = "TactNumber";
                chart1.Series["Stand11_Reads"].YValueMembers = "Stand11_Reads";
                chart1.Series["Stand11_Reads"].IsValueShownAsLabel = false;
                chart1.Series["Stand11_Reads"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
            }
            if (CheckBox22.Checked)
            {
                chart1.Series.Add("Stand12_Reads");
                chart1.Series["Stand12_Reads"].XValueMember = "TactNumber";
                chart1.Series["Stand12_Reads"].YValueMembers = "Stand12_Reads";
                chart1.Series["Stand12_Reads"].IsValueShownAsLabel = false;
                chart1.Series["Stand12_Reads"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
            }
            if (CheckBox23.Checked)
            {
                chart1.Series.Add("Stand13_Reads");
                chart1.Series["Stand13_Reads"].XValueMember = "TactNumber";
                chart1.Series["Stand13_Reads"].YValueMembers = "Stand13_Reads";
                chart1.Series["Stand13_Reads"].IsValueShownAsLabel = false;
                chart1.Series["Stand13_Reads"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
            }
            if (CheckBox24.Checked)
            {
                chart1.Series.Add("SignalingWrites");
                chart1.Series["SignalingWrites"].XValueMember = "TactNumber";
                chart1.Series["SignalingWrites"].YValueMembers = "SignalingWrites";
                chart1.Series["SignalingWrites"].IsValueShownAsLabel = false;
                chart1.Series["SignalingWrites"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
            }

            if (CheckBox25.Checked)
            {
                chart1.Series.Add("TCPRead");
                chart1.Series["TCPRead"].XValueMember = "TactNumber";
                chart1.Series["TCPRead"].YValueMembers = "TCPRead";
                chart1.Series["TCPRead"].IsValueShownAsLabel = false;
                chart1.Series["TCPRead"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
            }

            if (CheckBox26.Checked)
            {
                chart1.Series.Add("TCPWrite");
                chart1.Series["TCPWrite"].XValueMember = "TactNumber";
                chart1.Series["TCPWrite"].YValueMembers = "TCPWrite";
                chart1.Series["TCPWrite"].IsValueShownAsLabel = false;
                chart1.Series["TCPWrite"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
            }

            if (CheckBox27.Checked)
            {
                chart1.Series.Add("MysqlCommand");
                chart1.Series["MysqlCommand"].XValueMember = "TactNumber";
                chart1.Series["MysqlCommand"].YValueMembers = "MysqlCommand";
                chart1.Series["MysqlCommand"].IsValueShownAsLabel = false;
                chart1.Series["MysqlCommand"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
            }

            chart1.ChartAreas["ChartArea1"].AxisX.Title = "";
            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            chart1.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Sans Serif", 10, FontStyle.Bold);
            chart1.ChartAreas["ChartArea1"].AxisY.Title = "";
            chart1.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Sans Serif", 10, FontStyle.Bold);
            //chart1.ChartAreas["ChartArea1"].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep30;
            

            foreach (var s  in chart1.Series)
            {
                s.ToolTip=s.Name + " " + "Tact=#VALX, Value=#VALY";
            }

            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            chart1.ChartAreas["ChartArea1"].AxisY2.Enabled = AxisEnabled.True;
            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas["ChartArea1"].AxisY2.MajorGrid.Enabled = false;

            chart1.Legends.Add(new System.Web.UI.DataVisualization.Charting.Legend());
            chart1.Legends[0].Docking = Docking.Bottom;


            chart1.DataSource = l;
            chart1.DataBind();


            dg1.DataSource = l;
            dg1.DataBind();



            double roundms = l.Last().TimeStamp;
            double r1 = (roundms / 1000);
            double rm = r1 / 60;
            Label1.Text = "Czas okrążenia: " + rm;


            int av = (int)Math.Ceiling(roundms / 385);

            foreach(GridViewRow row in dg1.Rows)
            {
                foreach(TableCell cel in row.Cells)
                {
                    if (cel.Text == "0")
                    {
                        cel.Attributes["class"] = "empt";
                    }
                }

                TableCell cts = row.Cells[row.Cells.Count - 1];

                if(row.RowIndex+1< dg1.Rows.Count)
                {
                    TableCell nt = dg1.Rows[row.RowIndex + 1].Cells[row.Cells.Count - 1];

                    int v = int.Parse(nt.Text) - int.Parse(cts.Text);

                    int rv = v - av;

                    if (v > av)
                    {
                        cts.ForeColor = Color.Red;
                        cts.Text += "(+" + rv + "ms)";
                    }
                    else
                    {
                        cts.ForeColor = Color.DarkGreen;
                        cts.Text += "(" + rv + "ms)";
                    }
                }


            }






            BindDDL();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BindChart();
        }
    }
}