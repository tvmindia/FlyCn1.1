<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ToolBar.ascx.cs" Inherits="FlyCn.UserControls.ToolBar" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<script type="text/javascript">

</script>

<style type="text/css">
       
div.RadToolBar_Metro .rtbOuter {
    border: none !important;
    background-color: Transparent !important;
}
div.RadToolBar_Metro .rtbMiddle
{
    border: none !important;
     background-color: Transparent !important;
}

.template
 {
    background-color: Transparent !important;
 }
    </style>


<div style="text-align:right;vertical-align:top;margin:30px">
<telerik:RadToolBar ID="CommonToolBar" runat="server" Font-Size="X-Small" Skin="Metro" BorderStyle="None" BorderWidth="0" CssClass="template" >
    <Items>
        <telerik:RadToolBarButton runat="server" Text="Add" Value="Add" PostBack="false"  ImagePosition="Left"  
            ImageUrl="~/Images/Icons/addToolbarIcon.png" DisabledImageUrl="~/Images/Icons/addToolbarIconDisabled.png" >
           
        </telerik:RadToolBarButton>
        <telerik:RadToolBarButton Value="addSaveSeperator" IsSeparator="true" runat="server"   > </telerik:RadToolBarButton>
         <telerik:RadToolBarButton runat="server" Text="Save" Value="Save" PostBack="false"  ImagePosition="Left"  
            ImageUrl="~/Images/Icons/saveToolbarIcon.png" DisabledImageUrl="~/Images/Icons/saveToolbarIconDisabled.png" >
           
        </telerik:RadToolBarButton>
         <telerik:RadToolBarButton Value="SaveUpdateSeperator" IsSeparator="true" runat="server"  > </telerik:RadToolBarButton>
         <telerik:RadToolBarButton runat="server" Text="Update" Value="Update" PostBack="false"  ImagePosition="Left"   
            ImageUrl="~/Images/Icons/saveToolbarIcon.png" DisabledImageUrl="~/Images/Icons/saveToolbarIconDisabled.png" >
           
        </telerik:RadToolBarButton>
         <telerik:RadToolBarButton Value="UpdateDeleteSeperator" IsSeparator="true" runat="server"  > </telerik:RadToolBarButton>
         <telerik:RadToolBarButton runat="server" Text="Delete" Value="Delete" PostBack="false"  ImagePosition="Left"   
            ImageUrl="~/Images/Icons/deleteToolbarIcon.png" DisabledImageUrl="~/Images/Icons/deleteToolbarIconDisabled.png" >
           
        </telerik:RadToolBarButton>
    </Items>
</telerik:RadToolBar>
    </div>
