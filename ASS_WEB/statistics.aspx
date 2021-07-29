<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="statistics.aspx.cs" Inherits="ASS_WEB.statistics" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" />

    <style>
        .btndownload{
            background-color:white;
            transition:all 1s;
            border-radius:50%;
            border-style:solid;
            border-width:1px;
        }
        .btndownload:hover{
            background-color:silver;
            transition:all 1s;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Statystyki</h2>

            <div style="height:100px;">
                <asp:Label ID="lb1" runat="server" Text="Przebieg: "></asp:Label>
                <asp:DropDownList ID="ddlShifts" runat="server"></asp:DropDownList>
                <asp:Button ID="Button1" CssClass="btnSuccess" runat="server" Text="Wczytaj dane" OnClick="Button1_Click" />
                
                <div style="float:right;text-align:center;">
                    <asp:ImageButton ID="imgDownload" runat="server"  CssClass="btndownload" OnClick="imgDownload_Click" ImageUrl="~/appbar.office.excel.png" />
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="Przesyłki" style="width:100%;text-align:center;font-size:small;"></asp:Label>
                </div>

               <div style="float:right;text-align:center;">
                    <asp:ImageButton ID="ImageButton1" runat="server"  CssClass="btndownload" OnClick="ImageButton1_Click" ImageUrl="~/appbar.office.excel.png" />
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Stanowiska" style="width:100%;text-align:center;font-size:small;"></asp:Label>
                </div>

            </div>

            <div style="overflow:auto;max-height:500px;margin:10px;">
                <h4>Statystki stanowiskowe</h4>
                                <asp:GridView ID="dg2" AutoGenerateColumns="false" style="width:100%;" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
   
                                    <Columns>
                                        <asp:BoundField DataField="Stanowisko" HeaderText="Stanowisko"  />
                                        <asp:BoundField DataField="Kierunek" HeaderText="Kierunek" />
                                        <asp:BoundField DataField="Podzielone przesyłki" HeaderText="Podzielone przesyłki" />
                                        <asp:BoundField DataField="Pominięte przesyłki"  HeaderText="Pominięte przesyłki"/>
                                        <asp:BoundField DataField="Wszystkie przesyłki" HeaderText="Wszystkie przesyłki" />
                                        <asp:BoundField DataField="Obciążenie" HeaderText="Obciążenie [%]" />
                                        <asp:BoundField DataField="Efektywnosc" HeaderText="Efektywność [%]" />
                                    </Columns>
   
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

            <div style="overflow:auto;max-height:500px;margin:10px;">
                 <h4>Wysortowane przesyłki</h4>
                <asp:GridView ID="dg1" AutoGenerateColumns="False" style="width:100%;" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:BoundField DataField="Numer przesylki" HeaderText="Numer przesyłki" />
                        <asp:BoundField DataField="Kierunek" HeaderText="Kierunek" />
                        <asp:BoundField DataField="Czas przebiegu" HeaderText="Czas przebiegu" />
                        <asp:BoundField DataField="Rodzaj przesyłki" HeaderText="Rodzaj przesyłki" />
                        <asp:BoundField DataField="Data nadania" HeaderText="Data nadania" />
                        <asp:BoundField DataField="UP przeznaczenia" HeaderText="UP przeznaczenia" />
                        <asp:BoundField DataField="UP przeznaczenia PNA" HeaderText="UP przeznaczenia PNA" />
                        <asp:BoundField DataField="UP Nadania" HeaderText="UP nadania" />
                        <asp:BoundField DataField="UP nadania PNA" HeaderText="UP nadania PNA" />
                        <asp:BoundField DataField="tm" HeaderText="Czas" />
                    </Columns>
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
