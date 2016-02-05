<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="AssignUserRoles.aspx.cs" Inherits="FlyCn.FlycnSecurity.AssignUserRoles" %>
<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <script src="../Scripts/jquery-1.8.2.js"></script>
     
    <script type="text/javascript">
        $(document).ready(function () {
            EnableButtonsForNew();
            <%=ToolBar.ClientID %>_hideNotification();

        });
        function EnableButtonsForNew() {
           
            <%=ToolBar.ClientID %>_SetAddVisible(false);
            <%=ToolBar.ClientID %>_SetSaveVisible(true);
            <%=ToolBar.ClientID %>_SetUpdateVisible(false);
            <%=ToolBar.ClientID %>_SetDeleteVisible(false);

        }

    </script> 
    <asp:ScriptManager ID="scriptmanager2" runat="server" EnablePageMethods="true"></asp:ScriptManager>
        <div class="container" style="width: 100%">
            <uc1:ToolBar runat="server" ID="ToolBar" />
    </div>
</asp:Content>
