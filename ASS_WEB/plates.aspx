<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="plates.aspx.cs" Inherits="ASS_WEB.plates" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="StyleSheet1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <h1>Lista tac maszyny</h1>

        <asp:Button ID="Button1" CssClass="btndelete" runat="server" Text="Wyczyść wszystko" OnClick="Button1_Click" />
        <div>
            <asp:GridView ID="dg1" AutoGenerateColumns="false" style="width:100%" CssClass="dg"  runat="server" OnRowCommand="dg1_RowCommand">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label1" runat="server" Text="Index"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("Index")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                                        <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label3" runat="server" Text="Tag tacy"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:textbox ID="txp" runat="server" Text='<%# Eval("PlateID")%>'></asp:textbox>
                        </ItemTemplate>
                    </asp:TemplateField>

                                        <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label5" runat="server" Text="Liczba odczytów"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("ReadCount")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                                        <asp:TemplateField>
                        <HeaderTemplate>

                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Button ID="Button2" CssClass="btnSuccess" style="height:30px;padding:1px;" runat="server" Text="Zapisz" CommandArgument='<%# Eval("Index")%>' CommandName="sv" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
