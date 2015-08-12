<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ToolBar.ascx.cs" Inherits="FlyCn.UserControls.ToolBar" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<script type="text/javascript">
    function confirmation(control) {
        try{
            var tool = $find(control.id);
            var items = tool.get_items();
            var btn = items.getItem(6);
            var cID = control.id.replace("CommonToolBar", "DeleteCancel");
            if (btn.get_enabled()) {
                var result = confirm("Do you want to delete ?");
                if (result) {
                    document.getElementById(cID).value = "";
                    return true

                }
                else {

                    document.getElementById(cID).value = "DeleteCancel";
                    return false
                }
            }}
        catch (x) {
            alert("toolbar error : " + x.message);

        }
    }
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
    <asp:HiddenField ID="DeleteCancel" runat="server" />
    </div>
