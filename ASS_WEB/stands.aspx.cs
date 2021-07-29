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
    public partial class stands : System.Web.UI.Page
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

            Session["dicts"] = dicts;

            DataTable dt = new DataTable();
            dt.Columns.Add("s1Lamp2TurnOnByTacts");
            dt.Columns.Add("s2Lamp2TurnOnByTacts");
            dt.Columns.Add("s3Lamp2TurnOnByTacts");
            dt.Columns.Add("s4Lamp2TurnOnByTacts");
            dt.Columns.Add("name");
            dt.Columns.Add("s1direction");
            dt.Columns.Add("s2direction");
            dt.Columns.Add("s3direction");
            dt.Columns.Add("s4direction");



            dt.Columns.Add("s1l1lampblinking");
            dt.Columns.Add("s1l1blinkinterval");
            dt.Columns.Add("s1l1blinklenght");
            dt.Columns.Add("s1l1tactson");
            dt.Columns.Add("s1l1tactsoff");
            dt.Columns.Add("s1l1signalonprefix");
            dt.Columns.Add("s1l1signaloncontent");
            dt.Columns.Add("s1l1signalonsufix");
            dt.Columns.Add("s1l1signaloffprefix");
            dt.Columns.Add("s1l1signaloffcontent");
            dt.Columns.Add("s1l1signaloffsufix");

            dt.Columns.Add("s1l2lampblinking");
            dt.Columns.Add("s1l2blinkinterval");
            dt.Columns.Add("s1l2blinklenght");
            dt.Columns.Add("s1l2tactson");
            dt.Columns.Add("s1l2tactsoff");
            dt.Columns.Add("s1l2signalonprefix");
            dt.Columns.Add("s1l2signaloncontent");
            dt.Columns.Add("s1l2signalonsufix");
            dt.Columns.Add("s1l2signaloffprefix");
            dt.Columns.Add("s1l2signaloffcontent");
            dt.Columns.Add("s1l2signaloffsufix");

            dt.Columns.Add("s2l1lampblinking");
            dt.Columns.Add("s2l1blinkinterval");
            dt.Columns.Add("s2l1blinklenght");
            dt.Columns.Add("s2l1tactson");
            dt.Columns.Add("s2l1tactsoff");
            dt.Columns.Add("s2l1signalonprefix");
            dt.Columns.Add("s2l1signaloncontent");
            dt.Columns.Add("s2l1signalonsufix");
            dt.Columns.Add("s2l1signaloffprefix");
            dt.Columns.Add("s2l1signaloffcontent");
            dt.Columns.Add("s2l1signaloffsufix");

            dt.Columns.Add("s2l2lampblinking");
            dt.Columns.Add("s2l2blinkinterval");
            dt.Columns.Add("s2l2blinklenght");
            dt.Columns.Add("s2l2tactson");
            dt.Columns.Add("s2l2tactsoff");
            dt.Columns.Add("s2l2signalonprefix");
            dt.Columns.Add("s2l2signaloncontent");
            dt.Columns.Add("s2l2signalonsufix");
            dt.Columns.Add("s2l2signaloffprefix");
            dt.Columns.Add("s2l2signaloffcontent");
            dt.Columns.Add("s2l2signaloffsufix");

            dt.Columns.Add("s3l1lampblinking");
            dt.Columns.Add("s3l1blinkinterval");
            dt.Columns.Add("s3l1blinklenght");
            dt.Columns.Add("s3l1tactson");
            dt.Columns.Add("s3l1tactsoff");
            dt.Columns.Add("s3l1signalonprefix");
            dt.Columns.Add("s3l1signaloncontent");
            dt.Columns.Add("s3l1signalonsufix");
            dt.Columns.Add("s3l1signaloffprefix");
            dt.Columns.Add("s3l1signaloffcontent");
            dt.Columns.Add("s3l1signaloffsufix");

            dt.Columns.Add("s3l2lampblinking");
            dt.Columns.Add("s3l2blinkinterval");
            dt.Columns.Add("s3l2blinklenght");
            dt.Columns.Add("s3l2tactson");
            dt.Columns.Add("s3l2tactsoff");
            dt.Columns.Add("s3l2signalonprefix");
            dt.Columns.Add("s3l2signaloncontent");
            dt.Columns.Add("s3l2signalonsufix");
            dt.Columns.Add("s3l2signaloffprefix");
            dt.Columns.Add("s3l2signaloffcontent");
            dt.Columns.Add("s3l2signaloffsufix");

            dt.Columns.Add("s4l1lampblinking");
            dt.Columns.Add("s4l1blinkinterval");
            dt.Columns.Add("s4l1blinklenght");
            dt.Columns.Add("s4l1tactson");
            dt.Columns.Add("s4l1tactsoff");
            dt.Columns.Add("s4l1signalonprefix");
            dt.Columns.Add("s4l1signaloncontent");
            dt.Columns.Add("s4l1signalonsufix");
            dt.Columns.Add("s4l1signaloffprefix");
            dt.Columns.Add("s4l1signaloffcontent");
            dt.Columns.Add("s4l1signaloffsufix");

            dt.Columns.Add("s4l2lampblinking");
            dt.Columns.Add("s4l2blinkinterval");
            dt.Columns.Add("s4l2blinklenght");
            dt.Columns.Add("s4l2tactson");
            dt.Columns.Add("s4l2tactsoff");
            dt.Columns.Add("s4l2signalonprefix");
            dt.Columns.Add("s4l2signaloncontent");
            dt.Columns.Add("s4l2signalonsufix");
            dt.Columns.Add("s4l2signaloffprefix");
            dt.Columns.Add("s4l2signaloffcontent");
            dt.Columns.Add("s4l2signaloffsufix");


            foreach (var stand in dicts.Stands)
            {

                if (stand.Name.ToLower() != "odrzut")
                {
                    dt.Rows.Add(stand.StandItem1.Lamp2ByTacts,stand.StandItem2.Lamp2ByTacts,stand.StandItem3.Lamp2ByTacts,stand.StandItem4.Lamp2ByTacts, stand.Name, stand.StandItem1.Direction.Name, stand.StandItem2.Direction.Name, stand.StandItem3.Direction.Name, stand.StandItem4.Direction.Name,
                        stand.StandItem1.Lamp1.LampBlinking,
                        stand.StandItem1.Lamp1.LampBlinkingInterval,
                        stand.StandItem1.Lamp1.LampBlinkingLenght,
                        stand.StandItem1.Lamp1.TactsToTurnON,
                        stand.StandItem1.Lamp1.TactsToTurnOff,
                        stand.StandItem1.Lamp1.TurnOnSignal.Prefix, stand.StandItem1.Lamp1.TurnOnSignal.Content, stand.StandItem1.Lamp1.TurnOnSignal.Sufix,
                        stand.StandItem1.Lamp1.TurnOffSignal.Prefix, stand.StandItem1.Lamp1.TurnOffSignal.Content, stand.StandItem1.Lamp1.TurnOffSignal.Sufix,
                                        stand.StandItem1.Lamp2.LampBlinking,
                        stand.StandItem1.Lamp2.LampBlinkingInterval,
                        stand.StandItem1.Lamp2.LampBlinkingLenght,
                        stand.StandItem1.Lamp2.TactsToTurnON,
                        stand.StandItem1.Lamp2.TactsToTurnOff,
                        stand.StandItem1.Lamp2.TurnOnSignal.Prefix, stand.StandItem1.Lamp2.TurnOnSignal.Content, stand.StandItem1.Lamp2.TurnOnSignal.Sufix,
                        stand.StandItem1.Lamp2.TurnOffSignal.Prefix, stand.StandItem1.Lamp2.TurnOffSignal.Content, stand.StandItem1.Lamp2.TurnOffSignal.Sufix,
                                          stand.StandItem2.Lamp1.LampBlinking,
                        stand.StandItem2.Lamp1.LampBlinkingInterval,
                        stand.StandItem2.Lamp1.LampBlinkingLenght,
                        stand.StandItem2.Lamp1.TactsToTurnON,
                        stand.StandItem2.Lamp1.TactsToTurnOff,
                        stand.StandItem2.Lamp1.TurnOnSignal.Prefix, stand.StandItem2.Lamp1.TurnOnSignal.Content, stand.StandItem2.Lamp1.TurnOnSignal.Sufix,
                        stand.StandItem2.Lamp1.TurnOffSignal.Prefix, stand.StandItem2.Lamp1.TurnOffSignal.Content, stand.StandItem2.Lamp1.TurnOffSignal.Sufix,
                                        stand.StandItem2.Lamp2.LampBlinking,
                        stand.StandItem2.Lamp2.LampBlinkingInterval,
                        stand.StandItem2.Lamp2.LampBlinkingLenght,
                        stand.StandItem2.Lamp2.TactsToTurnON,
                        stand.StandItem2.Lamp2.TactsToTurnOff,
                        stand.StandItem2.Lamp2.TurnOnSignal.Prefix, stand.StandItem2.Lamp2.TurnOnSignal.Content, stand.StandItem2.Lamp2.TurnOnSignal.Sufix,
                        stand.StandItem2.Lamp2.TurnOffSignal.Prefix, stand.StandItem2.Lamp2.TurnOffSignal.Content, stand.StandItem2.Lamp2.TurnOffSignal.Sufix,
                                          stand.StandItem3.Lamp1.LampBlinking,
                        stand.StandItem3.Lamp1.LampBlinkingInterval,
                        stand.StandItem3.Lamp1.LampBlinkingLenght,
                        stand.StandItem3.Lamp1.TactsToTurnON,
                        stand.StandItem3.Lamp1.TactsToTurnOff,
                        stand.StandItem3.Lamp1.TurnOnSignal.Prefix, stand.StandItem3.Lamp1.TurnOnSignal.Content, stand.StandItem3.Lamp1.TurnOnSignal.Sufix,
                        stand.StandItem3.Lamp1.TurnOffSignal.Prefix, stand.StandItem3.Lamp1.TurnOffSignal.Content, stand.StandItem3.Lamp1.TurnOffSignal.Sufix,
                                        stand.StandItem3.Lamp2.LampBlinking,
                        stand.StandItem3.Lamp2.LampBlinkingInterval,
                        stand.StandItem3.Lamp2.LampBlinkingLenght,
                        stand.StandItem3.Lamp2.TactsToTurnON,
                        stand.StandItem3.Lamp2.TactsToTurnOff,
                        stand.StandItem3.Lamp2.TurnOnSignal.Prefix, stand.StandItem3.Lamp2.TurnOnSignal.Content, stand.StandItem3.Lamp2.TurnOnSignal.Sufix,
                        stand.StandItem3.Lamp2.TurnOffSignal.Prefix, stand.StandItem3.Lamp2.TurnOffSignal.Content, stand.StandItem3.Lamp2.TurnOffSignal.Sufix,
                                          stand.StandItem4.Lamp1.LampBlinking,
                        stand.StandItem4.Lamp1.LampBlinkingInterval,
                        stand.StandItem4.Lamp1.LampBlinkingLenght,
                        stand.StandItem4.Lamp1.TactsToTurnON,
                        stand.StandItem4.Lamp1.TactsToTurnOff,
                        stand.StandItem4.Lamp1.TurnOnSignal.Prefix, stand.StandItem4.Lamp1.TurnOnSignal.Content, stand.StandItem4.Lamp1.TurnOnSignal.Sufix,
                        stand.StandItem4.Lamp1.TurnOffSignal.Prefix, stand.StandItem4.Lamp1.TurnOffSignal.Content, stand.StandItem4.Lamp1.TurnOffSignal.Sufix,
                                        stand.StandItem4.Lamp2.LampBlinking,
                        stand.StandItem4.Lamp2.LampBlinkingInterval,
                        stand.StandItem4.Lamp2.LampBlinkingLenght,
                        stand.StandItem4.Lamp2.TactsToTurnON,
                        stand.StandItem4.Lamp2.TactsToTurnOff,
                        stand.StandItem4.Lamp2.TurnOnSignal.Prefix, stand.StandItem4.Lamp2.TurnOnSignal.Content, stand.StandItem4.Lamp2.TurnOnSignal.Sufix,
                        stand.StandItem4.Lamp2.TurnOffSignal.Prefix, stand.StandItem4.Lamp2.TurnOffSignal.Content, stand.StandItem4.Lamp2.TurnOffSignal.Sufix
                        );
                }
            }
            dg1.DataSource = dt;
            dg1.DataBind();


        }
        protected void dg1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gvr = (GridViewRow)((Button)e.CommandSource).NamingContainer;

            int i = gvr.RowIndex;

            string standname = ((TextBox)dg1.Rows[i].FindControl("txName")).Text;

            SendToserverAndGetResponse("ll"+ "_" + standname + "_" + e.CommandArgument.ToString());
            


        }
        void Save()
        {

            Dicts dicts = Dicts.GetData();


            foreach (GridViewRow row in dg1.Rows)
            {
                DropDownList ddl1 = (DropDownList)row.FindControl("ddl1Direction");
                DropDownList ddl2 = (DropDownList)row.FindControl("ddl2Direction");
                DropDownList ddl3 = (DropDownList)row.FindControl("ddl3Direction");
                DropDownList ddl4 = (DropDownList)row.FindControl("ddl4Direction");
                string name = ((TextBox)row.FindControl("txName")).Text;

                foreach(var s in dicts.Stands)
                {
                    if (s.Name == name)
                    {
                        string s1direction = ddl1.SelectedValue;
                        string s2direction = ddl2.SelectedValue;
                        string s3direction = ddl3.SelectedValue;
                        string s4direction = ddl4.SelectedValue;

                        foreach (var kier in dicts.Directions)
                        {
                            if (kier.Name == s1direction)
                            {
                                s.StandItem1.Direction = kier;                                
                            }
                            if (kier.Name == s2direction)
                            {
                                s.StandItem2.Direction = kier;                               
                            }
                            if (kier.Name == s3direction)
                            {
                                s.StandItem3.Direction = kier;
                            }
                            if (kier.Name == s4direction)
                            {
                                s.StandItem4.Direction = kier;
                            }
                        }

                        if (string.IsNullOrEmpty(s1direction))
                            s.StandItem1.Direction = new DirectionType();

                        if (string.IsNullOrEmpty(s2direction))
                            s.StandItem2.Direction = new DirectionType();

                        if (string.IsNullOrEmpty(s3direction))
                            s.StandItem3.Direction = new DirectionType();

                        if (string.IsNullOrEmpty(s4direction))
                            s.StandItem4.Direction = new DirectionType();


                        s.StandItem1.Lamp1.LampBlinking = ((CheckBox)row.FindControl("cks1l1")).Checked;
                        s.StandItem1.Lamp1.LampBlinkingInterval = int.Parse(((TextBox)row.FindControl("txs1l1intervel")).Text);
                        s.StandItem1.Lamp1.LampBlinkingLenght = int.Parse(((TextBox)row.FindControl("txs1l1lenght")).Text);
                        s.StandItem1.Lamp1.TactsToTurnON = int.Parse(((TextBox)row.FindControl("txs1l1tactson")).Text);
                        s.StandItem1.Lamp1.TactsToTurnOff = int.Parse(((TextBox)row.FindControl("txs1l1tactsoff")).Text);
                        s.StandItem1.Lamp1.TurnOnSignal.Prefix = ((TextBox)row.FindControl("txs1l1prefixOn")).Text;
                        s.StandItem1.Lamp1.TurnOnSignal.Content = ((TextBox)row.FindControl("txs1l1signalOn")).Text;
                        s.StandItem1.Lamp1.TurnOnSignal.Sufix = ((TextBox)row.FindControl("txs1l1sufixOn")).Text;
                        s.StandItem1.Lamp1.TurnOffSignal.Prefix = ((TextBox)row.FindControl("txs1l1prefixOff")).Text;
                        s.StandItem1.Lamp1.TurnOffSignal.Content = ((TextBox)row.FindControl("txs1l1signalOff")).Text;
                        s.StandItem1.Lamp1.TurnOffSignal.Sufix = ((TextBox)row.FindControl("txs1l1sufixOff")).Text;

                        s.StandItem1.Lamp2ByTacts= ((CheckBox)row.FindControl("c1")).Checked;
                        s.StandItem1.Lamp2.LampBlinking = ((CheckBox)row.FindControl("cks1l2")).Checked;
                        s.StandItem1.Lamp2.LampBlinkingInterval = int.Parse(((TextBox)row.FindControl("txs1l2intervel")).Text);
                        s.StandItem1.Lamp2.LampBlinkingLenght = int.Parse(((TextBox)row.FindControl("txs1l2lenght")).Text);
                        s.StandItem1.Lamp2.TactsToTurnON = int.Parse(((TextBox)row.FindControl("txs1l2tactson")).Text);
                        s.StandItem1.Lamp2.TactsToTurnOff = int.Parse(((TextBox)row.FindControl("txs1l2tactsoff")).Text);
                        s.StandItem1.Lamp2.TurnOnSignal.Prefix = ((TextBox)row.FindControl("txs1l2prefixOn")).Text;
                        s.StandItem1.Lamp2.TurnOnSignal.Content = ((TextBox)row.FindControl("txs1l2signalOn")).Text;
                        s.StandItem1.Lamp2.TurnOnSignal.Sufix = ((TextBox)row.FindControl("txs1l2sufixOn")).Text;
                        s.StandItem1.Lamp2.TurnOffSignal.Prefix = ((TextBox)row.FindControl("txs1l2prefixOff")).Text;
                        s.StandItem1.Lamp2.TurnOffSignal.Content = ((TextBox)row.FindControl("txs1l2signalOff")).Text;
                        s.StandItem1.Lamp2.TurnOffSignal.Sufix = ((TextBox)row.FindControl("txs1l2sufixOff")).Text;

                        s.StandItem2.Lamp2ByTacts = ((CheckBox)row.FindControl("c2")).Checked;
                        s.StandItem2.Lamp1.LampBlinking = ((CheckBox)row.FindControl("cks2l1")).Checked;
                        s.StandItem2.Lamp1.LampBlinkingInterval = int.Parse(((TextBox)row.FindControl("txs2l1intervel")).Text);
                        s.StandItem2.Lamp1.LampBlinkingLenght = int.Parse(((TextBox)row.FindControl("txs2l1lenght")).Text);
                        s.StandItem2.Lamp1.TactsToTurnON = int.Parse(((TextBox)row.FindControl("txs2l1tactson")).Text);
                        s.StandItem2.Lamp1.TactsToTurnOff = int.Parse(((TextBox)row.FindControl("txs2l1tactsoff")).Text);
                        s.StandItem2.Lamp1.TurnOnSignal.Prefix = ((TextBox)row.FindControl("txs2l1prefixOn")).Text;
                        s.StandItem2.Lamp1.TurnOnSignal.Content = ((TextBox)row.FindControl("txs2l1signalOn")).Text;
                        s.StandItem2.Lamp1.TurnOnSignal.Sufix = ((TextBox)row.FindControl("txs2l1sufixOn")).Text;
                        s.StandItem2.Lamp1.TurnOffSignal.Prefix = ((TextBox)row.FindControl("txs2l1prefixOff")).Text;
                        s.StandItem2.Lamp1.TurnOffSignal.Content = ((TextBox)row.FindControl("txs2l1signalOff")).Text;
                        s.StandItem2.Lamp1.TurnOffSignal.Sufix = ((TextBox)row.FindControl("txs2l1sufixOff")).Text;

                        s.StandItem2.Lamp2.LampBlinking = ((CheckBox)row.FindControl("cks2l2")).Checked;
                        s.StandItem2.Lamp2.LampBlinkingInterval = int.Parse(((TextBox)row.FindControl("txs2l2intervel")).Text);
                        s.StandItem2.Lamp2.LampBlinkingLenght = int.Parse(((TextBox)row.FindControl("txs2l2lenght")).Text);
                        s.StandItem2.Lamp2.TactsToTurnON = int.Parse(((TextBox)row.FindControl("txs2l2tactson")).Text);
                        s.StandItem2.Lamp2.TactsToTurnOff = int.Parse(((TextBox)row.FindControl("txs2l2tactsoff")).Text);
                        s.StandItem2.Lamp2.TurnOnSignal.Prefix = ((TextBox)row.FindControl("txs2l2prefixOn")).Text;
                        s.StandItem2.Lamp2.TurnOnSignal.Content = ((TextBox)row.FindControl("txs2l2signalOn")).Text;
                        s.StandItem2.Lamp2.TurnOnSignal.Sufix = ((TextBox)row.FindControl("txs2l2sufixOn")).Text;
                        s.StandItem2.Lamp2.TurnOffSignal.Prefix = ((TextBox)row.FindControl("txs2l2prefixOff")).Text;
                        s.StandItem2.Lamp2.TurnOffSignal.Content = ((TextBox)row.FindControl("txs2l2signalOff")).Text;
                        s.StandItem2.Lamp2.TurnOffSignal.Sufix = ((TextBox)row.FindControl("txs2l2sufixOff")).Text;

                        s.StandItem3.Lamp2ByTacts = ((CheckBox)row.FindControl("c3")).Checked;
                        s.StandItem3.Lamp1.LampBlinking = ((CheckBox)row.FindControl("cks3l1")).Checked;
                        s.StandItem3.Lamp1.LampBlinkingInterval = int.Parse(((TextBox)row.FindControl("txs3l1intervel")).Text);
                        s.StandItem3.Lamp1.LampBlinkingLenght = int.Parse(((TextBox)row.FindControl("txs3l1lenght")).Text);
                        s.StandItem3.Lamp1.TactsToTurnON = int.Parse(((TextBox)row.FindControl("txs3l1tactson")).Text);
                        s.StandItem3.Lamp1.TactsToTurnOff = int.Parse(((TextBox)row.FindControl("txs3l1tactsoff")).Text);
                        s.StandItem3.Lamp1.TurnOnSignal.Prefix = ((TextBox)row.FindControl("txs3l1prefixOn")).Text;
                        s.StandItem3.Lamp1.TurnOnSignal.Content = ((TextBox)row.FindControl("txs3l1signalOn")).Text;
                        s.StandItem3.Lamp1.TurnOnSignal.Sufix = ((TextBox)row.FindControl("txs3l1sufixOn")).Text;
                        s.StandItem3.Lamp1.TurnOffSignal.Prefix = ((TextBox)row.FindControl("txs3l1prefixOff")).Text;
                        s.StandItem3.Lamp1.TurnOffSignal.Content = ((TextBox)row.FindControl("txs3l1signalOff")).Text;
                        s.StandItem3.Lamp1.TurnOffSignal.Sufix = ((TextBox)row.FindControl("txs3l1sufixOff")).Text;

                        s.StandItem3.Lamp2.LampBlinking = ((CheckBox)row.FindControl("cks3l2")).Checked;
                        s.StandItem3.Lamp2.LampBlinkingInterval = int.Parse(((TextBox)row.FindControl("txs3l2intervel")).Text);
                        s.StandItem3.Lamp2.LampBlinkingLenght = int.Parse(((TextBox)row.FindControl("txs3l2lenght")).Text);
                        s.StandItem3.Lamp2.TactsToTurnON = int.Parse(((TextBox)row.FindControl("txs3l2tactson")).Text);
                        s.StandItem3.Lamp2.TactsToTurnOff = int.Parse(((TextBox)row.FindControl("txs3l2tactsoff")).Text);
                        s.StandItem3.Lamp2.TurnOnSignal.Prefix = ((TextBox)row.FindControl("txs3l2prefixOn")).Text;
                        s.StandItem3.Lamp2.TurnOnSignal.Content = ((TextBox)row.FindControl("txs3l2signalOn")).Text;
                        s.StandItem3.Lamp2.TurnOnSignal.Sufix = ((TextBox)row.FindControl("txs3l2sufixOn")).Text;
                        s.StandItem3.Lamp2.TurnOffSignal.Prefix = ((TextBox)row.FindControl("txs3l2prefixOff")).Text;
                        s.StandItem3.Lamp2.TurnOffSignal.Content = ((TextBox)row.FindControl("txs3l2signalOff")).Text;
                        s.StandItem3.Lamp2.TurnOffSignal.Sufix = ((TextBox)row.FindControl("txs3l2sufixOff")).Text;

                        s.StandItem4.Lamp2ByTacts = ((CheckBox)row.FindControl("c4")).Checked;
                        s.StandItem4.Lamp1.LampBlinking = ((CheckBox)row.FindControl("cks4l1")).Checked;
                        s.StandItem4.Lamp1.LampBlinkingInterval = int.Parse(((TextBox)row.FindControl("txs4l1intervel")).Text);
                        s.StandItem4.Lamp1.LampBlinkingLenght = int.Parse(((TextBox)row.FindControl("txs4l1lenght")).Text);
                        s.StandItem4.Lamp1.TactsToTurnON = int.Parse(((TextBox)row.FindControl("txs4l1tactson")).Text);
                        s.StandItem4.Lamp1.TactsToTurnOff = int.Parse(((TextBox)row.FindControl("txs4l1tactsoff")).Text);
                        s.StandItem4.Lamp1.TurnOnSignal.Prefix = ((TextBox)row.FindControl("txs4l1prefixOn")).Text;
                        s.StandItem4.Lamp1.TurnOnSignal.Content = ((TextBox)row.FindControl("txs4l1signalOn")).Text;
                        s.StandItem4.Lamp1.TurnOnSignal.Sufix = ((TextBox)row.FindControl("txs4l1sufixOn")).Text;
                        s.StandItem4.Lamp1.TurnOffSignal.Prefix = ((TextBox)row.FindControl("txs4l1prefixOff")).Text;
                        s.StandItem4.Lamp1.TurnOffSignal.Content = ((TextBox)row.FindControl("txs4l1signalOff")).Text;
                        s.StandItem4.Lamp1.TurnOffSignal.Sufix = ((TextBox)row.FindControl("txs4l1sufixOff")).Text;

                        s.StandItem4.Lamp2.LampBlinking = ((CheckBox)row.FindControl("cks4l2")).Checked;
                        s.StandItem4.Lamp2.LampBlinkingInterval = int.Parse(((TextBox)row.FindControl("txs4l2intervel")).Text);
                        s.StandItem4.Lamp2.LampBlinkingLenght = int.Parse(((TextBox)row.FindControl("txs4l2lenght")).Text);
                        s.StandItem4.Lamp2.TactsToTurnON = int.Parse(((TextBox)row.FindControl("txs4l2tactson")).Text);
                        s.StandItem4.Lamp2.TactsToTurnOff = int.Parse(((TextBox)row.FindControl("txs4l2tactsoff")).Text);
                        s.StandItem4.Lamp2.TurnOnSignal.Prefix = ((TextBox)row.FindControl("txs4l2prefixOn")).Text;
                        s.StandItem4.Lamp2.TurnOnSignal.Content = ((TextBox)row.FindControl("txs4l2signalOn")).Text;
                        s.StandItem4.Lamp2.TurnOnSignal.Sufix = ((TextBox)row.FindControl("txs4l2sufixOn")).Text;
                        s.StandItem4.Lamp2.TurnOffSignal.Prefix = ((TextBox)row.FindControl("txs4l2prefixOff")).Text;
                        s.StandItem4.Lamp2.TurnOffSignal.Content = ((TextBox)row.FindControl("txs4l2signalOff")).Text;
                        s.StandItem4.Lamp2.TurnOffSignal.Sufix = ((TextBox)row.FindControl("txs4l2sufixOff")).Text;





                    }
                }

                


            }

            dicts.Save();
            Session["dicts"] = dicts;
            Bind();

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            SendToserverAndGetResponse("refreshDicts");
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
                string response = client.WriteLineAndGetReply(message, ts)?.MessageString;
                return response;
            }
            catch (Exception ex)
            {

            }
            return "";
        }

        protected void dg1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Dicts dicts = (Dicts)Session["dicts"];

                DropDownList ddl1 = (DropDownList)e.Row.FindControl("ddl1Direction");
                DropDownList ddl2 = (DropDownList)e.Row.FindControl("ddl2Direction");
                DropDownList ddl3 = (DropDownList)e.Row.FindControl("ddl3Direction");
                DropDownList ddl4 = (DropDownList)e.Row.FindControl("ddl4Direction");




                ddl1.Items.Insert(0, "");
                ddl2.Items.Insert(0, "");
                ddl3.Items.Insert(0, "");
                ddl4.Items.Insert(0, "");
                foreach (var dd in dicts.Directions)
                {


                    ddl1.Items.Add(dd.Name);
                    ddl2.Items.Add(dd.Name);
                    ddl3.Items.Add(dd.Name);
                    ddl4.Items.Add(dd.Name);

                }


                ddl1.SelectedValue = "";
                ddl2.SelectedValue = "";
                ddl3.SelectedValue = "";
                ddl4.SelectedValue = "";

                string d1 = ((Label)e.Row.FindControl("l1direction")).Text;
                ddl1.SelectedValue = d1;

                string d2 = ((Label)e.Row.FindControl("l2direction")).Text;
                ddl2.SelectedValue = d2;

                string d3 = ((Label)e.Row.FindControl("l3direction")).Text;
                ddl3.SelectedValue = d3;

                string d4 = ((Label)e.Row.FindControl("l4direction")).Text;
                ddl4.SelectedValue = d4;

                CheckBox c1 = (CheckBox)e.Row.FindControl("c1");
                if (c1.ToolTip.ToLower() == "true")
                {
                    c1.Checked = true;
                }
                else
                {
                    c1.Checked = false;
                }
                CheckBox c2 = (CheckBox)e.Row.FindControl("c2");
                if (c2.ToolTip.ToLower() == "true")
                {
                    c2.Checked = true;
                }
                else
                {
                    c2.Checked = false;
                }
                CheckBox c3 = (CheckBox)e.Row.FindControl("c3");
                if (c3.ToolTip.ToLower() == "true")
                {
                    c3.Checked = true;
                }
                else
                {
                    c3.Checked = false;
                }
                CheckBox c4 = (CheckBox)e.Row.FindControl("c4");
                if (c4.ToolTip.ToLower() == "true")
                {
                    c4.Checked = true;
                }
                else
                {
                    c4.Checked = false;
                }

                CheckBox ck11 = (CheckBox)e.Row.FindControl("cks1l1");
                CheckBox ck12 = (CheckBox)e.Row.FindControl("cks1l2");

                CheckBox ck21 = (CheckBox)e.Row.FindControl("cks2l1");
                CheckBox ck22 = (CheckBox)e.Row.FindControl("cks2l2");

                CheckBox ck31 = (CheckBox)e.Row.FindControl("cks3l1");
                CheckBox ck32 = (CheckBox)e.Row.FindControl("cks3l2");

                CheckBox ck41 = (CheckBox)e.Row.FindControl("cks4l1");
                CheckBox ck42 = (CheckBox)e.Row.FindControl("cks4l2");

                if (ck11.ToolTip.ToLower() == "true")
                {
                    ck11.Checked = true;
                }
                else
                {
                    ck11.Checked = false;
                }
                if (ck12.ToolTip.ToLower() == "true")
                {
                    ck12.Checked = true;
                }
                else
                {
                    ck12.Checked = false;
                }


                if (ck21.ToolTip.ToLower() == "true")
                {
                    ck21.Checked = true;
                }
                else
                {
                    ck21.Checked = false;
                }
                if (ck22.ToolTip.ToLower() == "true")
                {
                    ck22.Checked = true;
                }
                else
                {
                    ck22.Checked = false;
                }


                if (ck31.ToolTip.ToLower() == "true")
                {
                    ck31.Checked = true;
                }
                else
                {
                    ck31.Checked = false;
                }
                if (ck32.ToolTip.ToLower() == "true")
                {
                    ck32.Checked = true;
                }
                else
                {
                    ck32.Checked = false;
                }


                if (ck41.ToolTip.ToLower() == "true")
                {
                    ck41.Checked = true;
                }
                else
                {
                    ck41.Checked = false;
                }
                if (ck42.ToolTip.ToLower() == "true")
                {
                    ck42.Checked = true;
                }
                else
                {
                    ck42.Checked = false;
                }


            }



        }
    }
}