<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="start.aspx.cs" Inherits="ASS_WEB.start" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="StyleSheet1.css" rel="stylesheet" />
          <style>
        .modalload {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 0;
            left:0px;
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
            -moz-opacity: 0.8;
            transition: all 2s;
        }

        .center {
            z-index: 1000;
            margin: 300px auto;
            padding: 10px;
            width: 130px;
            background-color: White;
            border-radius: 10px;
            filter: alpha(opacity=100);
            opacity: 1;
            -moz-opacity: 1;
        }

            .center img {
                height: 128px;
                width: 128px;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div style="background-color: #e2dede; width: 100%; height: 100vh;">


            <div style="height: 99vh; width: 1280px; position: fixed; top: 0px; left: calc(50% - 640px); background-color: white;">

                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                   <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="modalload">
                <div class="center">
                    <img alt="" src="loader.gif" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

                <div style="position: absolute; bottom: -10px; width: calc(100% - 200px); height: 40px; background-color: #a7a7a7; z-index: -1;"></div>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>

                        <div class="content">
                            <iframe id="ifr" runat="server" style="width: 100%; height: 99vh; border-style: none;"></iframe>





                        </div>
                        <div class="menu">
                            <div style="text-align:center;">
                            <asp:Label ID="lt" runat="server" Text="Automatic Sorting System" style="font-size:28px;color:white;"></asp:Label>
                            <asp:Label ID="lv" runat="server" Text="" style="font-size:10px;color:white;"></asp:Label>
                            </div>
                            <br />
                            <br />

                            <asp:Button ID="BtnMain" runat="server" CssClass="btn fnt" Text="Praca" OnClick="BtnMain_Click" />
                            <asp:Button ID="btnSettings" runat="server" CssClass="btn fnt" Text="Ustawienia" OnClick="btnSettings_Click" />
                            <asp:Button ID="btnDiagnosis" runat="server" CssClass="btn fnt" Text="Diagnostyka" OnClick="btnDiagnosis_Click" />
                            <asp:Button ID="btnstats" runat="server" CssClass="btn fnt" Text="Statystyki" OnClick="btnstats_Click" />
                        </div>



                        <%--    <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick"></asp:Timer>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>



                <asp:Label ID="lbTime" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="lbTactsCount" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="lbLastTact" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="lbSuposedTact" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="lbtacttime" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="lbworkdetect" runat="server" Text=""></asp:Label>

                <asp:GridView ID="dg1" runat="server"></asp:GridView>


            </div>

        </div>
    </form>
</body>
</html>
