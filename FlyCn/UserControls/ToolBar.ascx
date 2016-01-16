<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ToolBar.ascx.cs" Inherits="FlyCn.UserControls.ToolBar" EnableViewState="true" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style type="text/css">
     #noti_Container {
            position: fixed;
            width: 70px;
            height: 70px;
        }

        .noti_bubble {
            position: fixed; 
            top: 8%;
            left: 97%;
            padding: 1px 2px 1px 2px;
            background-color: blue; 
            color: white;
            font-weight: bold;
            font-size: 0.88em;
            border-radius: 30px;
            box-shadow: 1px 1px 1px gray;
        }
</style>
 <%--<asp:ScriptManager ID="ScriptManager2" runat="server" EnablePartialRendering="true" EnablePageMethods="true"  >
       
    </asp:ScriptManager>--%>

<script type="text/javascript">
    function <%=ClientID%>_InvokeCountWebMethod(count) {
        document.getElementById("<%= lblPopUpNumber.ClientID %>").innerHTML = count;
    }

     function <%=ClientID%>_hideNotification()
    {
        debugger;
        var notific = document.getElementById("noti_Container");
        notific.style.visibility = false;
    }

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

    function <%=ClientID%>_SetEditVisible(s) {

        <%= ClientID%>_SetVisibleButton('Edit', s);

    }

    function <%=ClientID%>_SetApproveVisible(s) {

        <%= ClientID%>_SetVisibleButton('Approve', s);

    }

    function <%=ClientID%>_SetDeclineVisible(s) {

        <%= ClientID%>_SetVisibleButton('Decline', s);

    }

    function <%=ClientID%>_SetRejectVisible(s) {

        <%= ClientID%>_SetVisibleButton('Reject', s);

    }

    function <%=ClientID%>_SetAttachVisible(s) {

        <%= ClientID%>_SetVisibleButton('Attach', s);
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
            var sep = btnItems.getItem(7);
            if (value) {
                btn.set_visible(true);
                sep.set_visible(true);
            }
            else {
                btn.set_visible(false);
                sep.set_visible(false);

            }

        }

        if (id == 'Edit') {
            var btn = btnItems.getItem(8);
             var sep = btnItems.getItem(9);
            if (value) {
                btn.set_visible(true);
                sep.set_visible(true);
            }
            else {
                btn.set_visible(false);
                sep.set_visible(false);

            }

        }

        if (id == 'Approve') {
            var btn = btnItems.getItem(10);
            var sep = btnItems.getItem(11);
            if (value) {
                btn.set_visible(true);
                sep.set_visible(true);
            }
            else {
                btn.set_visible(false);
                sep.set_visible(false);

            }

        }

        if (id == 'Decline') {
            var btn = btnItems.getItem(12);
            var sep = btnItems.getItem(13);
            if (value) {
                btn.set_visible(true);
                sep.set_visible(true);
            }
            else {
                btn.set_visible(false);
                sep.set_visible(false);

            }

        }

        if (id == 'Reject') {
            var btn = btnItems.getItem(14);
            var sep = btnItems.getItem(15);
            if (value) {
                btn.set_visible(true);
                sep.set_visible(true);
            }
            else {
                btn.set_visible(false);
                sep.set_visible(false);

            }

        }

        if (id == 'Attach') {
            var btn = btnItems.getItem(16);
           
           // var sep = btnItems.getItem(17);
            if (value) {
                btn.set_visible(true);
                sep.set_visible(true);
            }
            else {
                btn.set_visible(false);
             //   sep.set_visible(false);

            }

        }


    }


</script>
<div id="noti_Container">

            <div class="noti_bubble"><asp:Label ID="lblPopUpNumber" runat="server" /></div>
</div>

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
              <telerik:RadToolBarButton Value="UpdateEditSeperator" IsSeparator="true" runat="server"  style="display:none"  > </telerik:RadToolBarButton>
         <telerik:RadToolBarButton runat="server" Text="" Value="Edit"    ImagePosition="Left"   ToolTip="Edit"   style="display:none"
            ImageUrl="~/Images/Icons/editToolBarIcon.png" DisabledImageUrl="~/Images/Icons/editToolBarIconDisabled.png" >
           
        </telerik:RadToolBarButton>

          <telerik:RadToolBarButton Value="EditApproveSeperator" IsSeparator="true" runat="server"  style="display:none"  > </telerik:RadToolBarButton>
         <telerik:RadToolBarButton runat="server" Text="" Value="Approve"    ImagePosition="Left"   ToolTip="Approve"   style="display:none"
            ImageUrl="~/Images/Icons/approveToolbarIcon.png" DisabledImageUrl="~/Images/Icons/addToolbarIconDisabled.png" >
           
        </telerik:RadToolBarButton>

          <telerik:RadToolBarButton Value="ApproveDeclineSeperator" IsSeparator="true" runat="server"   style="display:none" > </telerik:RadToolBarButton>
         <telerik:RadToolBarButton runat="server" Text="" Value="Decline"    ImagePosition="Left"   ToolTip="Decline"   style="display:none"
            ImageUrl="~/Images/Icons/declineToolbarIcon.png" DisabledImageUrl="~/Images/Icons/declineToolbarIconDisabled.png" >
           
        </telerik:RadToolBarButton>

          <telerik:RadToolBarButton Value="DeclineRejectSeperator" IsSeparator="true" runat="server"   style="display:none" > </telerik:RadToolBarButton>
         <telerik:RadToolBarButton runat="server" Text="" Value="Reject"    ImagePosition="Left"   ToolTip="Reject"   style="display:none"
            ImageUrl="~/Images/Icons/rejectToolbarIcon.png" DisabledImageUrl="~/Images/Icons/rejectToolbarIconDisabled.png" >
             </telerik:RadToolBarButton>

               <telerik:RadToolBarButton Value="RejectAttachSeperator" IsSeparator="true" runat="server"   style="display:none" > </telerik:RadToolBarButton>
         <telerik:RadToolBarButton runat="server" Text="" Value="Attach"    ImagePosition="Left"   ToolTip="Attach"   style="display:none"
            ImageUrl="~/Images/Icons/attachToolbarIcon.png" DisabledImageUrl="~/Images/Icons/attachToolbarIconDisabled.png" >
             
           </telerik:RadToolBarButton>
        
        

    </Items>
</telerik:RadToolBar>
    <asp:HiddenField ID="DeleteCancel" runat="server" />
    </div>
