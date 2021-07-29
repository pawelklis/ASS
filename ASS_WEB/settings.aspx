<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="settings.aspx.cs" Inherits="ASS_WEB.settings" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

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

      


        

            <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" CssClass="fullpage" style="height:99vh;" ActiveTabIndex="1">
                <ajaxToolkit:TabPanel runat="server" HeaderText="Kierunki sortownicze" ID="TabPanel1" style="height:95vh;">
                    <ContentTemplate>
                        <iframe id="ifr1" runat="server" class="fullpage"></iframe> 
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Stanowiska" style="height:95vh;">
                    <ContentTemplate>
                        <iframe id="ifr2" runat="server" class="fullpage"></iframe> 
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="Parametry" style="height:95vh;">
                    <ContentTemplate>
                        <iframe id="ifr3" runat="server" class="fullpage"></iframe> 
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel4" runat="server" HeaderText="Tace"  style="height:95vh;">
                    <ContentTemplate>
                        <iframe id="ifr4" runat="server" class="fullpage"></iframe> 
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>


        

        </div>
    </form>
</body>
</html>
