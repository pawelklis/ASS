<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="directions.aspx.cs" Inherits="ASS_WEB.directions" Async="true" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="StyleSheet1.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div>

        
     

            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>

            <h1>Słownik kierunków</h1>
            <asp:Button ID="btnSave" CssClass="btnSuccess" runat="server" Text="Zapisz" OnClick="btnSave_Click" />

            <div style="width:100%;height:80vh;overflow:auto;">

            <asp:GridView ID="dg1" runat="server" CssClass="dg" AutoGenerateColumns="false" OnRowCommand="dg1_RowCommand">
                <Columns>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label1" runat="server" Text="Nazwa"></asp:Label></HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txName" CssClass="dgcell" runat="server" Text='<%# Eval("nazwa") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>

                                        <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label12" runat="server" Text="Zakres PNA od"></asp:Label></HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txpnaod" CssClass="dgcell"  runat="server" Text='<%# Eval("pnaod") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>

                                        <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label13" runat="server" Text="Zakres PNA do"></asp:Label></HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txpnado" CssClass="dgcell"  runat="server" Text='<%# Eval("pnado") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>

                                        <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label14" runat="server" Text="Skrót WSR"></asp:Label></HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txwsr" CssClass="dgcell"  runat="server" Text='<%# Eval("wsr") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>

                                        <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label15" runat="server" Text=""></asp:Label></HeaderTemplate>
                        <ItemTemplate>
                            <asp:Button ID="btndel" runat="server" CssClass="btndelete" Text="Usuń" CommandName="del" CommandArgument='<%# Eval("nazwa") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>


                </ContentTemplate></asp:UpdatePanel>
            </div>
        </div>
    </form>
</body>
</html>
