<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ToolBar.ascx.cs" Inherits="FlyCn.UserControls.ToolBar" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<script type="text/javascript">

</script>
<telerik:RadToolBar ID="CommonToolBar" runat="server" Width="100%">
    <Items>
        <telerik:RadToolBarButton runat="server" Text="Add" Value="Add" PostBack="false" Height="25px" Width="60px" ImageUrl="">

        </telerik:RadToolBarButton>

    </Items>
</telerik:RadToolBar>
