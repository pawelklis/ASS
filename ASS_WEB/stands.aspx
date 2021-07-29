<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="stands.aspx.cs" Inherits="ASS_WEB.stands" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="StyleSheet1.css" rel="stylesheet" />

    <style>
        table{
            font-size:10px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div>

        

            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <h1>Stanowiska</h1>
                    <asp:Button ID="btnSave" CssClass="btnSuccess" runat="server" Text="Zapisz" OnClick="btnSave_Click" />

                    <div style="width: 100%; height: 80vh; overflow: auto;">

                        <asp:GridView ID="dg1" runat="server" CssClass="dg" AutoGenerateColumns="false" OnRowDataBound="dg1_RowDataBound" OnRowCommand="dg1_RowCommand">
                            <Columns>

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="Label1" runat="server" Text="Nazwa"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txName" Width="170" CssClass="dgcell" runat="server" Text='<%# Eval("name") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="Label2" runat="server" Text="Kierunek 1"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddl1Direction" CssClass="ddl" runat="server" Style="width: 100%;"></asp:DropDownList>
                                        <asp:Label Style="visibility: hidden; font-size: 1px;" ID="l1direction" runat="server" Text='<%# Eval("s1direction") %>'></asp:Label>

                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="s1pol1" runat="server" Text="Lampa 1"></asp:Label>
                                                    <asp:Button ID="Button1x" runat="server" Text="ON" CommandArgument="111" />
                                                    <asp:Button ID="Button2x" runat="server" Text="Off" CommandArgument="110" />

                                                    

                                                </td>

                                            </tr>
                                            <tr>
                                                <td>

                                                    <table style="visibility:hidden;" class="controltable">

                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s1pol3" runat="server" Text="Tryb migotania"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s1pol4" runat="server" Text="Interwał [ms]"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s1pol5" runat="server" Text="Długość [ms]"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="cks1l1" runat="server" Text="" ToolTip='<%# Eval("s1l1lampblinking") %>' />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs1l1intervel" Width="80" TextMode="Number" min="0" runat="server" Text='<%# Eval("s1l1blinkinterval") %>'></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs1l1lenght" Width="80" TextMode="Number" min="0" runat="server" Text='<%# Eval("s1l1blinklenght") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table class="controltable">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s1pol6" runat="server" Text="Liczba taktów"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s1pol7" runat="server" Text="Włączenia"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s1pol8" runat="server" Text="Wyłączenia"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s1pol9" runat="server" Text=""></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs1l1tactson" Width="80" TextMode="Number" min="0" runat="server" Text='<%# Eval("s1l1tactson") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs1l1tactsoff" Width="80" TextMode="Number" min="0" runat="server" Text='<%# Eval("s1l1tactsoff") %>'>></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table class="controltable">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s1pol10" runat="server" Text="Prefix"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s1pol11" runat="server" Text="Sygnał"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s1pol12" runat="server" Text="Sufix"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txs1l1prefixOn" Width="80" runat="server" Text='<%# Eval("s1l1signalonprefix") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs1l1signalOn" Width="80" runat="server" Text='<%# Eval("s1l1signaloncontent") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs1l1sufixOn" Width="80" runat="server" Text='<%# Eval("s1l1signalonsufix") %>'>></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s1pol13" runat="server" Text="Prefix"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s1pol14" runat="server" Text="Sygnał"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s1pol15" runat="server" Text="Sufix"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txs1l1prefixOff" Width="80" runat="server" Text='<%# Eval("s1l1signaloffprefix") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs1l1signalOff" Width="80" runat="server" Text='<%# Eval("s1l1signaloffcontent") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs1l1sufixOff" Width="80" runat="server" Text='<%# Eval("s1l1signaloffsufix") %>'>></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="s1pol2" runat="server" Text="Lampa 2"></asp:Label>
                                                    <asp:Button ID="Button3" runat="server" Text="ON" CommandArgument="121"/>
                                                    <asp:Button ID="Button4" runat="server" Text="Off" CommandArgument="120" />
                                                    <asp:CheckBox ID="c1" runat="server" Text="Taktowanie" ToolTip='<%# Eval("s1Lamp2TurnOnByTacts") %>'/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table style="visibility:hidden;"  class="controltable">

                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s1pol16" runat="server" Text="Tryb migotania"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s1pol17" runat="server" Text="Interwał [ms]"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s1pol18" runat="server" Text="Długość [ms]"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="cks1l2" runat="server" Text="" ToolTip='<%# Eval("s1l2lampblinking") %>' />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs1l2intervel" Width="80" TextMode="Number" min="0" runat="server" Text='<%# Eval("s1l2blinkinterval") %>'></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs1l2lenght" Width="80" TextMode="Number" min="0" runat="server" Text='<%# Eval("s1l2blinklenght") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table class="controltable">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s1pol19" runat="server" Text="Liczba taktów"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s1pol20" runat="server" Text="Włączenia"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s1pol21" runat="server" Text="Wyłączenia"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s1pol22" runat="server" Text=""></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs1l2tactson" Width="80" TextMode="Number" min="0" runat="server" Text='<%# Eval("s1l2tactson") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs1l2tactsoff" Width="80" TextMode="Number" min="0" runat="server" Text='<%# Eval("s1l2tactsoff") %>'>></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table class="controltable">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s1pol23" runat="server" Text="Prefix"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s1pol24" runat="server" Text="Sygnał"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s1pol25" runat="server" Text="Sufix"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txs1l2prefixOn" Width="80" runat="server" Text='<%# Eval("s1l2signalonprefix") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs1l2signalOn" Width="80" runat="server" Text='<%# Eval("s1l2signaloncontent") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs1l2sufixOn" Width="80" runat="server" Text='<%# Eval("s1l2signalonsufix") %>'>></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s1pol26" runat="server" Text="Prefix"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s1pol27" runat="server" Text="Sygnał"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s1pol28" runat="server" Text="Sufix"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txs1l2prefixOff" Width="80" runat="server" Text='<%# Eval("s1l2signaloffprefix") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs1l2signalOff" Width="80" runat="server" Text='<%# Eval("s1l2signaloffcontent") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs1l2sufixOff" Width="80" runat="server" Text='<%# Eval("s1l2signaloffsufix") %>'>></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>

                                                </td>
                                            </tr>

                                        </table>



                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="Label22" runat="server" Text="Kierunek 2"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddl2Direction" CssClass="ddl"  runat="server" Style="width: 100%;"></asp:DropDownList>
                                        <asp:Label Style="visibility: hidden; font-size: 1px;" ID="l2direction" runat="server" Text='<%# Eval("s2direction") %>'></asp:Label>

                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="s2pol1" runat="server" Text="Lampa 1"></asp:Label>
                                                    <asp:Button ID="Button1xx" runat="server" Text="ON" CommandArgument="211" />
                                                    <asp:Button ID="Button2xxx" runat="server" Text="Off" CommandArgument="210" />
                                                    
                                                </td>

                                            </tr>
                                            <tr>
                                                <td>

                                                    <table style="visibility:hidden;"  class="controltable">

                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s2pol3" runat="server" Text="Tryb migotania"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s2pol4" runat="server" Text="Interwał [ms]"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s2pol5" runat="server" Text="Długość [ms]"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="cks2l1" runat="server" Text="" ToolTip='<%# Eval("s2l1lampblinking") %>' />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs2l1intervel" Width="80" TextMode="Number" min="0" runat="server" Text='<%# Eval("s2l1blinkinterval") %>'></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs2l1lenght" Width="80" TextMode="Number" min="0" runat="server" Text='<%# Eval("s2l1blinklenght") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table class="controltable">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s2pol6" runat="server" Text="Liczba taktów"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s2pol7" runat="server" Text="Włączenia"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s2pol8" runat="server" Text="Wyłączenia"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s2pol9" runat="server" Text=""></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs2l1tactson" Width="80" TextMode="Number" min="0" runat="server" Text='<%# Eval("s2l1tactson") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs2l1tactsoff" Width="80" TextMode="Number" min="0" runat="server" Text='<%# Eval("s2l1tactsoff") %>'>></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table class="controltable">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s2pol10" runat="server" Text="Prefix"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s2pol11" runat="server" Text="Sygnał"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s2pol12" runat="server" Text="Sufix"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txs2l1prefixOn" Width="80" runat="server" Text='<%# Eval("s2l1signalonprefix") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs2l1signalOn" Width="80" runat="server" Text='<%# Eval("s2l1signaloncontent") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs2l1sufixOn" Width="80" runat="server" Text='<%# Eval("s2l1signalonsufix") %>'>></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s2pol13" runat="server" Text="Prefix"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s2pol14" runat="server" Text="Sygnał"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s2pol15" runat="server" Text="Sufix"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txs2l1prefixOff" Width="80" runat="server" Text='<%# Eval("s2l1signaloffprefix") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs2l1signalOff" Width="80" runat="server" Text='<%# Eval("s2l1signaloffcontent") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs2l1sufixOff" Width="80" runat="server" Text='<%# Eval("s2l1signaloffsufix") %>'>></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="s2pol2" runat="server" Text="Lampa 2"></asp:Label>
                                                    <asp:Button ID="Button5" runat="server" Text="ON" CommandArgument="221" />
                                                    <asp:Button ID="Button6" runat="server" Text="Off" CommandArgument="220" />
                                                    <asp:CheckBox ID="c2" runat="server" Text="Taktowanie" ToolTip='<%# Eval("s2Lamp2TurnOnByTacts") %>'/>
                                                    
                                                </td>
                                                </tr>
                                            <tr>
                                                <td>
                                                    <table style="visibility:hidden;"  class="controltable">

                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s2pol16" runat="server" Text="Tryb migotania"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s2pol17" runat="server" Text="Interwał [ms]"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s2pol18" runat="server" Text="Długość [ms]"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="cks2l2" runat="server" Text="" ToolTip='<%# Eval("s2l2lampblinking") %>' />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs2l2intervel" Width="80" TextMode="Number" min="0" runat="server" Text='<%# Eval("s2l2blinkinterval") %>'></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs2l2lenght" Width="80" TextMode="Number" min="0" runat="server" Text='<%# Eval("s2l2blinklenght") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table class="controltable">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s2pol19" runat="server" Text="Liczba taktów"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s2pol20" runat="server" Text="Włączenia"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s2pol21" runat="server" Text="Wyłączenia"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s2pol22" runat="server" Text=""></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs2l2tactson" Width="80" TextMode="Number" min="0" runat="server" Text='<%# Eval("s2l2tactson") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs2l2tactsoff" Width="80" TextMode="Number" min="0" runat="server" Text='<%# Eval("s2l2tactsoff") %>'>></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table class="controltable">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s2pol23" runat="server" Text="Prefix"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s2pol24" runat="server" Text="Sygnał"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s2pol25" runat="server" Text="Sufix"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txs2l2prefixOn" Width="80" runat="server" Text='<%# Eval("s2l2signalonprefix") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs2l2signalOn" Width="80" runat="server" Text='<%# Eval("s2l2signaloncontent") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs2l2sufixOn" Width="80" runat="server" Text='<%# Eval("s2l2signalonsufix") %>'>></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s2pol26" runat="server" Text="Prefix"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s2pol27" runat="server" Text="Sygnał"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s2pol28" runat="server" Text="Sufix"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txs2l2prefixOff" Width="80" runat="server" Text='<%# Eval("s2l2signaloffprefix") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs2l2signalOff" Width="80" runat="server" Text='<%# Eval("s2l2signaloffcontent") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs2l2sufixOff" Width="80" runat="server" Text='<%# Eval("s2l2signaloffsufix") %>'>></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>

                                                </td>
                                            </tr>

                                        </table>

                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="Label222" runat="server" Text="Kierunek 3"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddl3Direction" CssClass="ddl"  runat="server" Style="width: 100%;"></asp:DropDownList>
                                        <asp:Label Style="visibility: hidden; font-size: 1px;" ID="l3direction" runat="server" Text='<%# Eval("s3direction") %>'></asp:Label>

                                              <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="s3pol1" runat="server" Text="Lampa 1"></asp:Label>
                                                    <asp:Button ID="Button1r" runat="server" Text="ON" CommandArgument="311" />
                                                    <asp:Button ID="Button2r" runat="server" Text="Off" CommandArgument="310" />
                                                    
                                                </td>
   
                                            </tr>
                                            <tr>
                                                <td>

                                                    <table  style="visibility:hidden;"  class="controltable">

                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s3pol3" runat="server" Text="Tryb migotania"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s3pol4" runat="server" Text="Interwał [ms]"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s3pol5" runat="server" Text="Długość [ms]"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="cks3l1" runat="server" Text="" ToolTip='<%# Eval("s3l1lampblinking") %>' />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs3l1intervel" Width="80" TextMode="Number" min="0" runat="server" Text='<%# Eval("s3l1blinkinterval") %>'></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs3l1lenght" Width="80" TextMode="Number" min="0" runat="server" Text='<%# Eval("s3l1blinklenght") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table class="controltable">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s3pol6" runat="server" Text="Liczba taktów"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s3pol7" runat="server" Text="Włączenia"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s3pol8" runat="server" Text="Wyłączenia"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s3pol9" runat="server" Text=""></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs3l1tactson" Width="80" TextMode="Number" min="0" runat="server" Text='<%# Eval("s3l1tactson") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs3l1tactsoff" Width="80" TextMode="Number" min="0" runat="server" Text='<%# Eval("s3l1tactsoff") %>'>></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table class="controltable">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s3pol10" runat="server" Text="Prefix"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s3pol11" runat="server" Text="Sygnał"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s3pol12" runat="server" Text="Sufix"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txs3l1prefixOn" Width="80" runat="server" Text='<%# Eval("s3l1signalonprefix") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs3l1signalOn" Width="80" runat="server" Text='<%# Eval("s3l1signaloncontent") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs3l1sufixOn" Width="80" runat="server" Text='<%# Eval("s3l1signalonsufix") %>'>></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s3pol13" runat="server" Text="Prefix"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s3pol14" runat="server" Text="Sygnał"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s3pol15" runat="server" Text="Sufix"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txs3l1prefixOff" Width="80" runat="server" Text='<%# Eval("s3l1signaloffprefix") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs3l1signalOff" Width="80" runat="server" Text='<%# Eval("s3l1signaloffcontent") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs3l1sufixOff" Width="80" runat="server" Text='<%# Eval("s3l1signaloffsufix") %>'>></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                             </tr>
                                                  <tr>
                                             <td>
                                                    <asp:Label ID="s3pol2" runat="server" Text="Lampa 2"></asp:Label>
                                                    <asp:Button ID="Button7" runat="server" Text="ON" CommandArgument="321" />
                                                    <asp:Button ID="Button8" runat="server" Text="Off" CommandArgument="320" />
                                                 <asp:CheckBox ID="c3" runat="server" Text="Taktowanie" ToolTip='<%# Eval("s3Lamp2TurnOnByTacts") %>'/>
                                                </td>
                                                      </tr>
                                                  <tr>
                                                <td>
                                                    <table  style="visibility:hidden;" class="controltable">

                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s3pol16" runat="server" Text="Tryb migotania"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s3pol17" runat="server" Text="Interwał [ms]"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s3pol18" runat="server" Text="Długość [ms]"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="cks3l2" runat="server" Text="" ToolTip='<%# Eval("s3l2lampblinking") %>' />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs3l2intervel" Width="80" TextMode="Number" min="0" runat="server" Text='<%# Eval("s3l2blinkinterval") %>'></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs3l2lenght" Width="80" TextMode="Number" min="0" runat="server" Text='<%# Eval("s3l2blinklenght") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table class="controltable">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s3pol19" runat="server" Text="Liczba taktów"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s3pol20" runat="server" Text="Włączenia"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s3pol21" runat="server" Text="Wyłączenia"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s3pol22" runat="server" Text=""></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs3l2tactson" Width="80" TextMode="Number" min="0" runat="server" Text='<%# Eval("s3l2tactson") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs3l2tactsoff" Width="80" TextMode="Number" min="0" runat="server" Text='<%# Eval("s3l2tactsoff") %>'>></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table class="controltable">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s3pol23" runat="server" Text="Prefix"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s3pol24" runat="server" Text="Sygnał"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s3pol25" runat="server" Text="Sufix"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txs3l2prefixOn" Width="80" runat="server" Text='<%# Eval("s3l2signalonprefix") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs3l2signalOn" Width="80" runat="server" Text='<%# Eval("s3l2signaloncontent") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs3l2sufixOn" Width="80" runat="server" Text='<%# Eval("s3l2signalonsufix") %>'>></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s3pol26" runat="server" Text="Prefix"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s3pol27" runat="server" Text="Sygnał"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s3pol28" runat="server" Text="Sufix"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txs3l2prefixOff" Width="80" runat="server" Text='<%# Eval("s3l2signaloffprefix") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs3l2signalOff" Width="80" runat="server" Text='<%# Eval("s3l2signaloffcontent") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs3l2sufixOff" Width="80" runat="server" Text='<%# Eval("s3l2signaloffsufix") %>'>></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>

                                                </td>
                                            </tr>

                                        </table>

                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="Label2222" runat="server" Text="Kierunek 4"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddl4Direction" CssClass="ddl"  runat="server" Style="width: 100%;"></asp:DropDownList>
                                        <asp:Label Style="visibility: hidden; font-size: 1px;" ID="l4direction" runat="server" Text='<%# Eval("s4direction") %>'></asp:Label>

                                         <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="s4pol1" runat="server" Text="Lampa 1"></asp:Label>
                                                    <asp:Button ID="Button1b" runat="server" Text="ON" CommandArgument="411" />
                                                    <asp:Button ID="Button2b" runat="server" Text="Off" CommandArgument="410" />
                                                </td>
                                
                                            </tr>
                                            <tr>
                                                <td>

                                                    <table style="visibility:hidden;"  class="controltable">

                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s4pol3" runat="server" Text="Tryb migotania"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s4pol4" runat="server" Text="Interwał [ms]"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s4pol5" runat="server" Text="Długość [ms]"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="cks4l1" runat="server" Text="" ToolTip='<%# Eval("s4l1lampblinking") %>' />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs4l1intervel" Width="80" TextMode="Number" min="0" runat="server" Text='<%# Eval("s4l1blinkinterval") %>'></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs4l1lenght" Width="80" TextMode="Number" min="0" runat="server" Text='<%# Eval("s4l1blinklenght") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table class="controltable">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s4pol6" runat="server" Text="Liczba taktów"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s4pol7" runat="server" Text="Włączenia"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s4pol8" runat="server" Text="Wyłączenia"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s4pol9" runat="server" Text=""></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs4l1tactson" Width="80" TextMode="Number" min="0" runat="server" Text='<%# Eval("s4l1tactson") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs4l1tactsoff" Width="80" TextMode="Number" min="0" runat="server" Text='<%# Eval("s4l1tactsoff") %>'>></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table class="controltable">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s4pol10" runat="server" Text="Prefix"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s4pol11" runat="server" Text="Sygnał"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s4pol12" runat="server" Text="Sufix"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txs4l1prefixOn" Width="80" runat="server" Text='<%# Eval("s4l1signalonprefix") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs4l1signalOn" Width="80" runat="server" Text='<%# Eval("s4l1signaloncontent") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs4l1sufixOn" Width="80" runat="server" Text='<%# Eval("s4l1signalonsufix") %>'>></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s4pol13" runat="server" Text="Prefix"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s4pol14" runat="server" Text="Sygnał"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s4pol15" runat="server" Text="Sufix"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txs4l1prefixOff" Width="80" runat="server" Text='<%# Eval("s4l1signaloffprefix") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs4l1signalOff" Width="80" runat="server" Text='<%# Eval("s4l1signaloffcontent") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs4l1sufixOff" Width="80" runat="server" Text='<%# Eval("s4l1signaloffsufix") %>'>></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                               </tr>
                                                  <tr>  
                                                      <td>
                                                    <asp:Label ID="s4pol2" runat="server" Text="Lampa 2"></asp:Label>
                                                    <asp:Button ID="Button9" runat="server" Text="ON"  CommandArgument="421" />
                                                    <asp:Button ID="Button10" runat="server" Text="Off" CommandArgument="420" />
                                                    <asp:CheckBox ID="c4" runat="server" Text="Taktowanie" ToolTip='<%# Eval("s4Lamp2TurnOnByTacts") %>'/>
                                                </td>
                                                      </tr>
                                                  <tr>
                                                <td>
                                                    <table  style="visibility:hidden;" class="controltable">

                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s4pol16" runat="server" Text="Tryb migotania"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s4pol17" runat="server" Text="Interwał [ms]"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s4pol18" runat="server" Text="Długość [ms]"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="cks4l2" runat="server" Text="" ToolTip='<%# Eval("s4l2lampblinking") %>' />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs4l2intervel" Width="80" TextMode="Number" min="0" runat="server" Text='<%# Eval("s4l2blinkinterval") %>'></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs4l2lenght" Width="80" TextMode="Number" min="0" runat="server" Text='<%# Eval("s4l2blinklenght") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table class="controltable">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s4pol19" runat="server" Text="Liczba taktów"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s4pol20" runat="server" Text="Włączenia"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s4pol21" runat="server" Text="Wyłączenia"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s4pol22" runat="server" Text=""></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs4l2tactson" Width="80" TextMode="Number" min="0" runat="server" Text='<%# Eval("s4l2tactson") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs4l2tactsoff" Width="80" TextMode="Number" min="0" runat="server" Text='<%# Eval("s4l2tactsoff") %>'>></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table class="controltable">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s4pol23" runat="server" Text="Prefix"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s4pol24" runat="server" Text="Sygnał"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s4pol25" runat="server" Text="Sufix"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txs4l2prefixOn" Width="80" runat="server" Text='<%# Eval("s4l2signalonprefix") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs4l2signalOn" Width="80" runat="server" Text='<%# Eval("s4l2signaloncontent") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs4l2sufixOn" Width="80" runat="server" Text='<%# Eval("s4l2signalonsufix") %>'>></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="s4pol26" runat="server" Text="Prefix"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s4pol27" runat="server" Text="Sygnał"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="s4pol28" runat="server" Text="Sufix"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txs4l2prefixOff" Width="80" runat="server" Text='<%# Eval("s4l2signaloffprefix") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs4l2signalOff" Width="80" runat="server" Text='<%# Eval("s4l2signaloffcontent") %>'>></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txs4l2sufixOff" Width="80" runat="server" Text='<%# Eval("s4l2signaloffsufix") %>'>></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    
                                                </td>
                                            </tr>

                                        </table>

                                    </ItemTemplate>
                                </asp:TemplateField>

                           

                            </Columns>
                        </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </form>

</body>
</html>
