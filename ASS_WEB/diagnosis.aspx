<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="diagnosis.aspx.cs" Inherits="ASS_WEB.diagnosis" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList><asp:Button ID="Button1" runat="server" Text="Wczytaj dane" OnClick="Button1_Click" />
            <br />
            <style>
                .fntSmall{
                    font-size:smaller;
                }
                table th{
                    position:sticky;
                    top:0px;
                    background-color:black;
                    word-wrap:anywhere;
                }
                .empt{
                    color: transparent;
border-color: black;
                }
            </style>
            <div style="overflow:auto;">
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                <br />
                <asp:CheckBox ID="CheckBox1" CssClass="fntSmall" runat="server" Checked="false" Text="Tact time" />
                <asp:CheckBox ID="CheckBox2" CssClass="fntSmall"  runat="server" Checked="false" Text="ParcelsOnBuffer" />
                <asp:CheckBox ID="CheckBox3" CssClass="fntSmall"  runat="server" Checked="false" Text="ParcelsOnLine" />
                <asp:CheckBox ID="CheckBox4" CssClass="fntSmall"  runat="server" Checked="false" Text="StartSensorReads" />
                <asp:CheckBox ID="CheckBox5" CssClass="fntSmall"  runat="server" Checked="false" Text="StoptSensorReads" />
                <asp:CheckBox ID="CheckBox6" CssClass="fntSmall"  runat="server" Checked="false" Text="TactSensorReads" />
                <asp:CheckBox ID="CheckBox7" CssClass="fntSmall"  runat="server" Checked="false" Text="LenghtSensorReads" />
                <asp:CheckBox ID="CheckBox8" CssClass="fntSmall"  runat="server" Checked="false" Text="SignalingReads" />
                <asp:CheckBox ID="CheckBox9" CssClass="fntSmall"  runat="server" Checked="false" Text="Scanner1SensorReads" />
                <asp:CheckBox ID="CheckBox10" CssClass="fntSmall"  runat="server" Checked="false" Text="PlateSensorReads" />
                <br />
                <asp:CheckBox ID="CheckBox11" CssClass="fntSmall"  runat="server" Checked="false" Text="Stand1_Reads" />
                <asp:CheckBox ID="CheckBox12" CssClass="fntSmall"  runat="server" Checked="false" Text="Stand2_Reads" />
                <asp:CheckBox ID="CheckBox13" CssClass="fntSmall"  runat="server" Checked="false" Text="Stand3_Reads" />
                <asp:CheckBox ID="CheckBox14" CssClass="fntSmall"  runat="server" Checked="false" Text="Stand4_Reads" />
                <asp:CheckBox ID="CheckBox15" CssClass="fntSmall"  runat="server" Checked="false" Text="Stand5_Reads" />
                <asp:CheckBox ID="CheckBox16" CssClass="fntSmall"  runat="server" Checked="false" Text="Stand6_Reads" />
                <asp:CheckBox ID="CheckBox17" CssClass="fntSmall"  runat="server" Checked="false" Text="Stand7_Reads" />
                <asp:CheckBox ID="CheckBox18" CssClass="fntSmall"  runat="server" Checked="false" Text="Stand8_Reads" />
                <asp:CheckBox ID="CheckBox19" CssClass="fntSmall"  runat="server" Checked="false" Text="Stand9_Reads" />
                <asp:CheckBox ID="CheckBox20" CssClass="fntSmall"  runat="server" Checked="false" Text="Stand10_Reads" />
                <asp:CheckBox ID="CheckBox21" CssClass="fntSmall"  runat="server" Checked="false" Text="Stand11_Reads" />
                <asp:CheckBox ID="CheckBox22" CssClass="fntSmall"  runat="server" Checked="false" Text="Stand12_Reads" />
                <asp:CheckBox ID="CheckBox23" CssClass="fntSmall"  runat="server" Checked="false" Text="Stand13_Reads" />
                <asp:CheckBox ID="CheckBox24" CssClass="fntSmall"  runat="server" Checked="false" Text="SignalingWrites" />
                <asp:CheckBox ID="CheckBox25" CssClass="fntSmall"  runat="server" Checked="false" Text="TCPRead" />
                <asp:CheckBox ID="CheckBox26" CssClass="fntSmall"  runat="server" Checked="false" Text="TCPWrite" />
                <asp:CheckBox ID="CheckBox27" CssClass="fntSmall"  runat="server" Checked="false" Text="MysqlCommand" />

            <asp:Chart ID="chart1" runat="server" Width="3600" Height="600">
                <Series>
                    <asp:Series Name="Series1"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            </div>

       <div style="width:100%;height:600px;overflow:auto;">
            <asp:GridView ID="dg1" Font-Size="Smaller" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
       </div>



        </div>
    </form>
</body>
</html>
