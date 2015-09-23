<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ToolBar.ascx.cs" Inherits="FlyCn.UserControls.ToolBar" EnableViewState="true" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<script type="text/javascript">
    function confirmation(control) {
        try{
            var tool = $find(control);
            var items = tool.get_items();
            var btn = items.getItem(6);
            var cID = "<%= DeleteCancel.ClientID %>";
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


    function <%=ClientID%>_SetAddVisible(s) {

        <%= ClientID%>_SetVisibleButton('Add', s);

    }

    function <%=ClientID%>_SetSaveVisible(s) {

        <%= ClientID%>_SetVisibleButton('Save', s);

    }

    function <%=ClientID%>_SetUpdateVisible(s) {

        <%= ClientID%>_SetVisibleButton('Update', s);

    }

    function <%=ClientID%>_SetDeleteVisible(s) {

        <%= ClientID%>_SetVisibleButton('Delete', s);

    }



    function <%= ClientID%>_SetVisibleButton(id, value) {
        //debugger;
        var toolBar = $find("<%= CommonToolBar.ClientID %>");
        var btnItems = toolBar.get_items();
        if (id == 'Add') {
            var btn = btnItems.getItem(0);
            var sep = btnItems.getItem(1);
            if (value) {             
                btn.set_visible(true);
                sep.set_visible(true);
            }
            else {
                btn.set_visible(false);
                sep.set_visible(false);

            }

        }


        if (id == 'Save') {
            var btn = btnItems.getItem(2);
            var sep = btnItems.getItem(3);
            if (value) {
                btn.set_visible(true);
                sep.set_visible(true);
            }
            else {
                btn.set_visible(false);
                sep.set_visible(false);

            }

        }

        if (id == 'Update') {
            var btn = btnItems.getItem(4);
            var sep = btnItems.getItem(5);
            if (value) {
                btn.set_visible(true);
                sep.set_visible(true);
            }
            else {
                btn.set_visible(false);
                sep.set_visible(false);

            }

        }

        if (id == 'Delete') {
            var btn = btnItems.getItem(6);
           // var sep = btnItems.getItem[5];
            if (value) {
                btn.set_visible(true);
               // sep.set_visible(true);
            }
            else {
                btn.set_visible(false);
                //sep.set_visible(false);

            }

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


<div class="ToolBarContainer">
<telerik:RadToolBar   ID="CommonToolBar" runat="server" Font-Size="X-Small" Skin="Metro" BorderStyle="None" BorderWidth="0" CssClass="template" OnButtonClick="CommonToolBar_ButtonClick"  >
   <CollapseAnimation Type="OutQuint" Duration="200" />
     <Items>
        <telerik:RadToolBarButton runat="server" Text="" Value="Add"    ImagePosition="Left"  ToolTip="Add"
            ImageUrl="~/Images/Icons/addToolbarIcon.png" DisabledImageUrl="~/Images/Icons/addToolbarIconDisabled.png" >
           
        </telerik:RadToolBarButton>
        <telerik:RadToolBarButton Value="addSaveSeperator" IsSeparator="true" runat="server"   > </telerik:RadToolBarButton>
         <telerik:RadToolBarButton runat="server" Text="" Value="Save"   ImagePosition="Left"  ToolTip="Save"
            ImageUrl="~/Images/Icons/saveToolbarIcon.png" DisabledImageUrl="~/Images/Icons/saveToolbarIconDisabled.png" >
           
        </telerik:RadToolBarButton>
         <telerik:RadToolBarButton Value="SaveUpdateSeperator" IsSeparator="true" runat="server"  > </telerik:RadToolBarButton>
         <telerik:RadToolBarButton runat="server" Text="" Value="Update"    ImagePosition="Left"  ToolTip="Update" 
            ImageUrl="~/Images/Icons/saveToolbarIcon.png" DisabledImageUrl="~/Images/Icons/saveToolbarIconDisabled.png" >
           
        </telerik:RadToolBarButton>
         <telerik:RadToolBarButton Value="UpdateDeleteSeperator" IsSeparator="true" runat="server"  > </telerik:RadToolBarButton>
         <telerik:RadToolBarButton runat="server" Text="" Value="Delete"    ImagePosition="Left"   ToolTip="Delete"
            ImageUrl="~/Images/Icons/deleteToolbarIcon.png" DisabledImageUrl="~/Images/Icons/deleteToolbarIconDisabled.png" >
           
        </telerik:RadToolBarButton>
    </Items>
</telerik:RadToolBar>
    <asp:HiddenField ID="DeleteCancel" runat="server" />
    </div>
