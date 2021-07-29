<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dasch.aspx.cs" Inherits="ASS_WEB.dasch" Async="true" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="StyleSheet1.css" rel="stylesheet" />


    <style>
        .animated {
            top: 165px;
            left: 354px;
            width: 30px;
            height: 30px;
            background-color: wheat;
            animation-name: run;
            animation-duration: 5s;
            animation-play-state: running;
            animation-timing-function: linear;
            position: absolute;
            animation-iteration-count: infinite;
            border-radius: 50%;
            visibility: hidden;
        }

        @keyframes run {
            0% {
                top: 165px;
                left: 354px;
            }

            45% {
                top: 165px;
                left: 1200px;
            }

            50% {
                top: 95px;
                left: 1240px;
            }

            55% {
                top: 25px;
                left: 1200px;
            }

            70% {
                top: 25px;
                left: 95px;
            }

            80% {
                top: 95px;
                left: 35px;
            }

            90% {
                top: 165px;
                left: 95px;
            }

            100% {
                top: 165px;
                left: 354px;
            }
        }


        .connected {
            background-color: green;
        }

        .disconnected {
            background-color: red;
        }
        .off
        {
            background-color:black;
        }

        .tb {
            text-align: center;
        }

        .footer {
            position: fixed;
            bottom: 0px;
            width: 100%;
            height: 62px;
            background-color: #a7a7a7;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>

    




        <div style="width: 100%; height: 99vh; border-style: none;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>



                    <script>
                        function test() {
                            document.getElementById('runobject').style.visibility = 'hidden';
                        }
                    </script>



                    <table class="tb">
                        <tr>
                            <td>
                                <img src="masp.png" usemap="#image-map" />
                                <map name="image-map">
                                    <div title="Start sensor" id="startscanner" runat="server" class="disconnected" style="width: 30px; height: 30px; top: 145px; left: 314px; position: absolute;" coords="320,235,352,206"></div>
                                    <div title="Tact sensor" id="tactscanner" runat="server" class="disconnected" style="width: 30px; height: 30px; top: 116px; left: 314px; position: absolute;" coords="320,235,352,206"></div>
                                    <div title="Lenght sensor" id="lenghtscanner" runat="server" class="disconnected" style="width: 30px; height: 30px; top: 145px; left: 280px; position: absolute;" coords="320,235,352,206"></div>
                                    <div title="Scanner 1" id="scanner1" runat="server" class="disconnected" style="width: 30px; height: 60px; top: 116px; left: 200px; position: absolute;" coords="320,235,352,206"></div>
                                    <div title="Sygnalizacja" id="signaling" runat="server" class="disconnected" style="width: 820px; height: 30px; top: 74px; left: 90px; position: absolute;"></div>
                                    <div title="Stop sensor" id="stopscanner" runat="server" class="disconnected" style="width: 30px; height: 30px; top: 14px; left: 105px; position: absolute;" coords="320,235,352,206"></div>
                                
                                
                                    <div title="Plate sensor" id="Div1" runat="server" class="disconnected" style="width: 30px; height: 30px; top: 116px; left: 280px; position: absolute;" coords="320,235,352,206"></div>
                                    
                                    <div title="Stand1 sensor" id="Div2" runat="server" class="disconnected" style="width: 30px; height: 30px; top: 145px; left: 400px; position: absolute;" coords="320,235,352,206"></div>
                                    <div title="Stand2 sensor" id="Div3" runat="server" class="disconnected" style="width: 30px; height: 30px; top: 145px; left: 480px; position: absolute;" coords="320,235,352,206"></div>
                                    <div title="Stand3 sensor" id="Div4" runat="server" class="disconnected" style="width: 30px; height: 30px; top: 145px; left: 560px; position: absolute;" coords="320,235,352,206"></div>
                                    <div title="Stand4 sensor" id="Div5" runat="server" class="disconnected" style="width: 30px; height: 30px; top: 145px; left: 640px; position: absolute;" coords="320,235,352,206"></div>
                                    <div title="Stand5 sensor" id="Div6" runat="server" class="disconnected" style="width: 30px; height: 30px; top: 145px; left: 720px; position: absolute;" coords="320,235,352,206"></div>
                                    <div title="Stand6 sensor" id="Div7" runat="server" class="disconnected" style="width: 30px; height: 30px; top: 145px; left: 800px; position: absolute;" coords="320,235,352,206"></div>
                                    
                                    <div title="Stand7 sensor" id="Div8" runat="server" class="disconnected" style="width: 30px; height: 30px; top: 14px; left: 800px; position: absolute;" coords="320,235,352,206"></div>
                                    <div title="Stand8 sensor" id="Div9" runat="server" class="disconnected" style="width: 30px; height: 30px; top: 14px; left: 720px; position: absolute;" coords="320,235,352,206"></div>
                                    <div title="Stand9 sensor" id="Div10" runat="server" class="disconnected" style="width: 30px; height: 30px; top: 14px; left: 640px; position: absolute;" coords="320,235,352,206"></div>
                                    <div title="Stand10 sensor" id="Div11" runat="server" class="disconnected" style="width: 30px; height: 30px; top: 14px; left: 560px; position: absolute;" coords="320,235,352,206"></div>
                                    <div title="Stand11 sensor" id="Div12" runat="server" class="disconnected" style="width: 30px; height: 30px; top: 14px; left: 480px; position: absolute;" coords="320,235,352,206"></div>
                                    <div title="Stand12 sensor" id="Div13" runat="server" class="disconnected" style="width: 30px; height: 30px; top: 14px; left: 400px; position: absolute;" coords="320,235,352,206"></div>
                                    
                                    <div title="Stand13 sensor" id="Div90" runat="server" class="disconnected" style="width: 30px; height: 30px; top: 14px; left: 200px; position: absolute;" coords="320,235,352,206"></div>

                                
                                
                                
                                
                                
                                </map>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="Button1" runat="server" CssClass="btnSuccess" OnClick="Button1_Click1" Text="Start przebiegu" Visible="False" />
                                <asp:Button ID="Button2" runat="server" CssClass="btnSuccess" OnClick="Button2_Click1" Text="Sprawdź urządzenia" />
                            </td>
                        </tr>
                    </table>


                    <div style="width: 100%; height: 100px; position: fixed; bottom: 62px;">
                        <asp:ListBox ID="loglist" runat="server" Style="width: 100%; height: 99px;"></asp:ListBox>
                    </div>

                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>

                            <div>
                                <asp:Chart ID="chart1" runat="server" Width="1000px">
                                    <Series>
                                        <asp:Series Name="Series1" ChartType="StackedColumn"></asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>


                    <div>
                        <asp:GridView ID="dg1" runat="server"></asp:GridView>
                    </div>


                    <div class="footer">
                        <asp:Image ID="workimg" runat="server" ImageUrl="~/workoff.gif" Height="60px" Width="120px" />
                        <asp:Label ID="lbShift" runat="server" Text=""></asp:Label>
                        <asp:Label ID="labelWork" runat="server" Style="visibility: hidden;"></asp:Label>
                        <asp:Label ID="labelBuffer" runat="server" Style="visibility: visible;"></asp:Label>
                        <asp:Label ID="LabelLine" runat="server" Style="visibility: visible;"></asp:Label>
                        <asp:Label ID="labelcurrentplate" runat="server" Style="visibility: visible;"></asp:Label>
                        <asp:Label ID="labelnextplate" runat="server" Style="visibility: visible;"></asp:Label>
                        <asp:Label ID="lboccupiedplatescount" runat="server" Style="visibility: visible;"></asp:Label>
                        <asp:Label ID="lboccupiedplatespercentage" runat="server" Style="visibility: visible;"></asp:Label>
                    </div>




                    <div id="runobject" runat="server"></div>
                    <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="5000" Enabled="true"></asp:Timer>
                     <asp:Timer ID="Timer2" runat="server" OnTick="Timer2_Tick" Interval="10000" Enabled="true"></asp:Timer>
                </ContentTemplate>
            </asp:UpdatePanel>



        </div>
    </form>
</body>
</html>
