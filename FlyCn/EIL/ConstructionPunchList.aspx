﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="ConstructionPunchList.aspx.cs" Inherits="FlyCn.EIL.ConstructionPunchList" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UserControls/Uc_FlyCnFileUpload.ascx" TagPrefix="uc1" TagName="Uc_FlyCnFileUpload" %>
<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>

<asp:Content ID="phdConstructionPunchListHead" ContentPlaceHolderID="head" runat="server">
    
     <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    
  <%-- <script src="../Scripts/jquery-1.11.3.min.js"></script>--%>
     <%-- <script src="../Scripts/jquery-1.12.0.min.js"></script>--%>
      <script src="../Scripts/jquery.1.9.1.min.js"></script>
    <script src="../Scripts/jquery-ui.min10.2.js"></script>
    
    <%--<script src="../Scripts/jquery-1.8.3.min.js"></script>--%>
   <%--  <script src="../Scripts/jquery-ui.js"></script> --%>
    <script src="../Scripts/ToolBar.js"></script>
    <script src="../Scripts/Messages.js"></script>
    <script src="../Content/themes/FlyCnBlue/js/selectize.js"></script>
    <script src="../Content/themes/FlyCnBlue/js/index.js"></script>    
    <script src="../Content/themes/FlyCnBlue/js/bootstrap.min.js"></script>
    <script src="../Content/themes/FlyCnBlue/js/bootstrap-datepicker.js"></script>
   <link href="../Scripts/jquery-ui.css" rel="stylesheet" />
    <style type="text/css">
        .selectbox {
            width: 69%;
            height: 25px;
            background-color: #FFF;
            font: 400 12px/18px 'Open Sans', sans-serif;
            color: #000;
            font-weight: normal;
            border: 1px solid #ccc;
            margin: 5px 0 0 0;
            padding: 5px;
        }
        .ui-autocomplete {
background: fixed;
font-size:small;
font-family:Cambria, Cochin, Georgia, Times, Times New Roman, serif;
background-color: ghostwhite;
 box-shadow:1px 1px 1px 1px #f3e6d8;
 overflow-y:auto;
 max-height:270px;
}
      
        .textbox {
            width: 48%;
            height: 10px;   
            background-color: #FFF;
            font: 400 12px/18px 'Open Sans', sans-serif;
            color: #000;
            font-weight: normal;
            border: 1px solid #ccc;
            margin: 5px 0 0 0;
            padding: 5px;
        }

        .rediobutton {
            width: 30px;
            height: 18px;
            background-color: #FFF;
            font: 400 12px/18px 'Open Sans', sans-serif;
            color: #000;
            font-weight: normal;
            border: 1px solid #ccc;
            margin: 5px 0 0 0;
            padding: 5px;
        }

        .content {
            border: 1px solid #BDBDBD;
            width: 91%;
            padding: 5px;
            margin: 0px 0 0 5px;
        }

        .textarea {
            margin-top: 250%;
            left: 0%;
            width: 150px;
        }

        .hdnField {
            display: none;
        }

        .tabletd {
            width: 280px;
        }

        .tabletbody {
            width: 400px;
        }
    </style>
   
    <title>Input</title>
  <%--  <!-----bootstrap css--->
    <link href="../Content/themes/FlyCnBlue/css/roboto_google_api.css" rel="stylesheet" />
    <link href="Content/themes/FlyCnBlue/css/datepicker.css" rel="stylesheet" type="text/css" />
    <!-----bootstrap css--->
    <link href="../Content/themes/FlyCnBlue/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/themes/FlyCnBlue/css/stylesheet.css" rel="stylesheet" />

    <link href="../Content/themes/FlyCnBlue/css/selectize.css" rel="stylesheet" type="text/css" />
    <link href="../Content/themes/FlyCnBlue/css/accodin.css" rel="stylesheet" type="text/css" />
    <!-----main css--->
    <link href="../Content/themes/FlyCnBlue/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Content/themes/FlyCnRed_Rad/TabStrip.FlyCnRed_Rad.css" rel="stylesheet" />
    <!-----main css--->--%>
</asp:Content>

<asp:Content ID="phdConstructionPunchListMaster" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     
    <script type="text/javascript">
       
        function ClearTextBox() {
            $('textarea').empty();

            $("input:text").val('');
        }
        //---------For Security-------------//

        function EnableButtonsForNew() {


            AddMode("<%= ToolBar.ClientID %>");
        }

        function EnableButtonsForEdit() {

            EditMode("<%= ToolBar.ClientID %>");

            }

            function DisableButtons() {

                DisableAll("<%= ToolBar.ClientID %>");

        }
        function DeleteButtonEnable() {

            if (PageSecurity.isDelete)
                EnableButtonsWithDelete("<%= ToolBar.ClientID %>");

      }

      //---------------------------------------------------------//



      function SelectTabList() {
          var tabStrip = $find("<%= RadTabStrip1.ClientID %>");
                    var tab = tabStrip.findTabByValue("1");
                    tab.select();
                }

                function SetTabNewTextAndIcon() {
                    var tabStrip = $find("<%= RadTabStrip1.ClientID %>");
                    var tab1 = tabStrip.findTabByValue("2");
                    tab1.set_text("New");
                    tab1.set_imageUrl('../Images/Icons/NewIcon.png');
                }


            </script>
    <script type="text/javascript">

        //-----------------For  Security-------------------------//
        function SecurityTabSelecting(eventArgs) {
            var security = document.getElementById("hdnSecurityMaster").value;
            var tab = eventArgs.get_tab();
            PageSecurityCheck(security);
            if (PageSecurity.isWriteOnly) {

                if (tab.get_text() == "New") {
                    EnableButtonsForNew();

                    eventArgs.set_cancel(false);
                }

            }
            else
                if (PageSecurity.isEditOnly) {
                    EnableButtonsForEdit();
                    if (tab.get_text() == "New") {
                        AlertMsg(messages.EditModeNewClick);


                        eventArgs.set_cancel(true);
                    }

                }
                else
                    if (PageSecurity.isAddOnly) {

                        if (tab.get_text() == "New")

                            eventArgs.set_cancel(false);
                        EnableButtonsForNew();
                    }
                    else if (PageSecurity.isReadOnly) {

                        if (tab.get_text() == "New") {
                            AlertMsg(messages.EditModeNewClick);


                            eventArgs.set_cancel(true);
                        }

                    }

        }


        function OnCommand(sender, args) {
            var value = args.get_commandName();
            if (value == "EditData") {
                EnableButtonsForEdit();
            }
            else
                if (value == "ViewDetailColumn") {
                    DisableAll();
                }
        }
        //-----------------------------------------------------------//
        function OnClientTabSelecting(sender, eventArgs) {
            SecurityTabSelecting(eventArgs);

        }


        


        function onClientTabSelected(sender, args) {
            var tab = args.get_tab();

            if (tab.get_value() == '2') {

                try {


                    ClearTexBox();

                    if (tab.get_text() == "New") {
                        <%=ToolBar.ClientID %>_SetAddVisible(false);
                        <%=ToolBar.ClientID %>_SetSaveVisible(true);
                        <%=ToolBar.ClientID %>_SetUpdateVisible(false);
                        <%=ToolBar.ClientID %>_SetDeleteVisible(false);
                        <%=ToolBar.ClientID %>_SetAttachVisible(false);
                        var IdNo = document.getElementById("<%=txtIDno.ClientID %>").value;
                        var moduleId = document.getElementById('<%=ddlModule.ClientID %>').selectedIndex;
                        var category = document.getElementById('<%=ddlCategory.ClientID %>').selectedIndex;
                        var activity = document.getElementById('<%=ddlActivity.ClientID %>').selectedIndex;
                        var tag = $telerik.findComboBox("<%= radTagNo.ClientID %>");
                       
                        IdNo.EditMode = true;
                        moduleId.EditMode = true;
                        category.EditMode = true;
                        activity.EditMode = true;
                        tag.EditMode = true;
                    }
                    if (document.getElementById("<%= grdFileUpload.ClientID %>") != null)
                        document.getElementById("<%= grdFileUpload.ClientID %>").style.display = "none";
                }
                catch (x) {

                }

            }


            if (tab.get_value() == "1") {

                SelectTabList();
                SetTabNewTextAndIcon();

            }

        }
        function OnClientButtonClicking(sender, args) {

            var btn = args.get_item();
            if (btn.get_value() == 'Delete') {

                args.set_cancel(!confirm(messages.DeleteAlertGeneral));
            }
            if (btn.get_value() == 'Update') {

                args.set_cancel(!validateEdit());

            }
            if (btn.get_value() == 'Save') {

                args.set_cancel(!validateSave());
            }
            if (btn.get_value() == 'Add') {

                args.set_cancel(!validateAdd());
            }

        }

        function validateAdd()
        {
            return true;
        }
        function ClearTexBox() {
            document.getElementById('<%=txtIDno.ClientID %>').value = "";          
            var LnameImage = document.getElementById('<%=imgWebLnames.ClientID %>');
            LnameImage.style.display = "none";
            var errLname = document.getElementById('<%=errorLnames.ClientID %>');
            errLname.style.display = "none";
            document.getElementById('<%=ddlModule.ClientID %>').selectedIndex = "0";          
            document.getElementById('<%=ddlCategory.ClientID %>').selectedIndex = "0";            
            document.getElementById('<%=ddlActivity.ClientID %>').selectedIndex = "0";
            document.getElementById('<%=ddlOpenBy.ClientID %>').selectedIndex = "0";
            document.getElementById('<%=ddlEnteredBy.ClientID %>').selectedIndex = "0";
            document.getElementById('<%=ddlPlant.ClientID %>').selectedIndex = "0";
            document.getElementById('<%=ddlArea.ClientID %>').selectedIndex = "0";
            document.getElementById('<%=ddlLocation.ClientID %>').selectedIndex = "0";
            document.getElementById('<%=ddlUnit.ClientID %>').selectedIndex = "0";
            document.getElementById('<%=ddlSystem.ClientID %>').selectedIndex = "0";
            document.getElementById('<%=ddlControlSystem.ClientID %>').selectedIndex = "0";
            document.getElementById('<%=ddlSubsystem.ClientID %>').selectedIndex = "0";
            document.getElementById('<%=ddlRequestedBy.ClientID %>').selectedIndex = "0";
            document.getElementById('<%=ddlInspector.ClientID %>').selectedIndex = "0";
            document.getElementById('<%=ddlActionBy.ClientID %>').selectedIndex = "0";
            document.getElementById('<%=ddlDiscipline.ClientID %>').selectedIndex = "0";
            document.getElementById('<%=ddlFailCategory.ClientID %>').selectedIndex = "0";
            document.getElementById('<%=ddlCategoryList.ClientID %>').selectedIndex = "0";
            document.getElementById('<%=ddlResponsiblePerson.ClientID %>').selectedIndex = "0";
            document.getElementById('<%=ddlOrganization.ClientID %>').selectedIndex = "0";
            document.getElementById('<%=ddlSignedBy.ClientID %>').selectedIndex = "0";
           
                  $('input[type=text]').each(function () {
                      $(this).val('');
                  });
              }


    </script>
    <script type="text/javascript">

        function validateSave() {
            var IdNo = document.getElementById("<%=txtIDno.ClientID %>").value;
            var moduleId = document.getElementById('<%=ddlModule.ClientID %>').selectedIndex;
            var category = document.getElementById('<%=ddlCategory.ClientID %>').selectedIndex;
            var activity = document.getElementById('<%=ddlActivity.ClientID %>').selectedIndex;
            var tag = $telerik.findComboBox("<%= radTagNo.ClientID %>").get_text();

            if (moduleId != "0")
            {
               
                if (category == "0" || activity == "0" || tag == "Search for TagNo...")
                {
                    displayMessage(messageType.Error, messages.TrackingDetails);
                    return false;
                }
                else if (IdNo == "") {
                    document.getElementById("<%=lblerror.ClientID %>").innerHTML = "";

                    displayMessage(messageType.Error, messages.MandatoryFieldsGeneral);
                    return false;

                }
                else {
                    document.getElementById("<%=lblerror.ClientID %>").innerHTML = "";
                    return true;

                }
               
            }
            else if (IdNo == "") {
                document.getElementById("<%=lblerror.ClientID %>").innerHTML = "";

                displayMessage(messageType.Error, messages.MandatoryFieldsGeneral);
                return false;

            }
            else {
                document.getElementById("<%=lblerror.ClientID %>").innerHTML = "";
              
                if (moduleId == "0" && IdNo != "") {
                    var myHidden = document.getElementById('<%= hdfValidateSave.ClientID %>');
                    myHidden.value = "1";
                  
                }
                else {
                  
                    myHidden.value = "2";
                }
                return true;
            }     
        }
        
        function validateEdit()
        {
            var IdNo = document.getElementById("<%=txtIDno.ClientID %>").value;
            if (IdNo == "") {
                document.getElementById("<%=lblerror.ClientID %>").innerHTML = "";

                displayMessage(messageType.Error, messages.MandatoryFieldsGeneral);
                return false;

            }
            else {
                document.getElementById("<%=lblerror.ClientID %>").innerHTML = "";
                return true;

            }
        }
    </script>
    <script type="text/javascript">

    

        $(document).ready(function () {
            debugger;
            var LnameImage = document.getElementById('<%=imgWebLnames.ClientID %>');
            LnameImage.style.display = "none";
            var errLname = document.getElementById('<%=errorLnames.ClientID %>');
            errLname.style.display = "none";
  
            //------------------------For Security-----------------------------------------------//
           
            //var security = document.getElementById("hdnSecurityMaster").value;

            //Page Postback
           <%-- if (document.getElementById('<%=hdnAccessMode.ClientID%>').value == "EditData")
            {
                EnableButtonsForEdit();
            }
            else
                if (document.getElementById('<%=hdnAccessMode.ClientID%>').value == "ViewDetailColumn")
                {
                    DisableButtons();
                }--%>

            //----------------------------------------------------------------------------------//
            id = document.getElementById('IDAccordion');

            OpenDetailAccordion(id);
            parent.showTreeNode();

            $('.accordion-toggle').on('click', function (event) {

                event.preventDefault();
                // create accordion variables
                var accordion = $(this);
                var accordionContent = accordion.next('.accordion-content');
                var accordionToggleIcon = $(this).children('.toggle-icon');

                // toggle accordion link open class
                accordion.toggleClass("open");
                // toggle accordion content
                accordionContent.slideToggle(250);

                // change plus/minus icon
                if (accordion.hasClass("open")) {
                    accordionToggleIcon.html("<i class='fa fa-minus-circle'></i>");
                } else {
                    accordionToggleIcon.html("<i class='fa fa-plus-circle'></i>");
                }

            });

        });


        function OpenDetailAccordion(id) {
            if (id != undefined)//accordion called from accordion click functionjs
            {

                var accordion = $(id);
                var accordionContent = accordion.next('.accordion-content');
                var accordionToggleIcon = accordion.children('.toggle-icon');

                // toggle accordion link open class
                accordion.toggleClass("open");
                // toggle accordion content
                accordionContent.slideToggle(250);

                // change plus/minus icon
                if (accordion.hasClass("open")) {
                    accordionToggleIcon.html("<i class='fa fa-minus-circle'></i>");
                } else {
                    accordionToggleIcon.html("<i class='fa fa-plus-circle'></i>");
                }
            }
        }
        
        function checkIdNo(txtIDno)
        {
            var ID = document.getElementById('<%=txtIDno.ClientID %>').value;
            var mode = document.getElementById('<%=hdnMode.ClientID %>').value;
            PageMethods.ValidateIdNo(ID, mode, OnSuccess, onError);
           
            function OnSuccess(response, userContext, methodName) {
                var LnameImage = document.getElementById('<%=imgWebLnames.ClientID %>');
                var errLname = document.getElementById('<%=errorLnames.ClientID %>');
                if (response == false)
                {
                   
                    LnameImage.style.display = "block";
                    errLname.style.display = "none";
                   
                }
                if(response == true)
                {
                    errLname.style.display = "block";
                    errLname.style.color = "Red";
                    errLname.innerHTML="Name Alreay Exists"
                    LnameImage.style.display = "none";
                    
                }
            }
            function onError(response, userContext, methodName) {
               
               
            }
        }
       
            </script>


    <asp:Label ID="lblTitle" runat="server" Text="" CssClass="PageHeading"></asp:Label>
   
    <div class="container" style="width: 100%">
       
   
        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" Width="300px" OnClientTabSelected="onClientTabSelected" OnClientTabSelecting="OnClientTabSelecting"
            CausesValidation="false" SelectedIndex="0" Skin="FlyCnRed_Rad" EnableEmbeddedSkins="false">

            <Tabs>
                <telerik:RadTab Text="View" PageViewID="rpList" Value="1" Width="150px" runat="server" ImageUrl="~/Images/Icons/ListIcon.png" Selected="True"></telerik:RadTab>
                <telerik:RadTab Text="New" PageViewID="rpAddEdit" Value="2" Width="150px" runat="server" ImageUrl="~/Images/Icons/NewIcon.png"></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <div id="content">
                <%-- For Security ViewDetailColumn--%>
            <div class="contentTopBar"></div>
            <table style="width:100%">
                <tr>
                    <td>
                        <telerik:RadMultiPage ID="RadMultiPage1" runat="server" Width="100%" SelectedIndex="0" CssClass="outerMultiPage">
                            <telerik:RadPageView ID="rpList" runat="server"> 

                                <div id="divList" style="width: 100%">
                                    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" EnablePageMethods="true">
                                    </asp:ScriptManager>

                                    

                                    <telerik:RadGrid ID="dtgManageProjectGrid" runat="server" CellSpacing="0"
                                        GridLines="None" OnNeedDataSource="dtgManageProjectGrid_NeedDataSource1" AllowPaging="true" OnPageIndexChanged="dtgManageProjectGrid_PageIndexChanged"  AlwaysVisible="true" OnSelectedIndexChanged="dtgManageProjectGrid_SelectedIndexChanged" OnItemCommand="dtgManageProjectGrid_ItemCommand"
                                        PageSize="10" Width="100%" Skin="Silk">
                                         <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>
                                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="ProjectNo,IDNo,EILType" InsertItemPageIndexAction="ShowItemOnFirstPage" InsertItemDisplay="Top" >
                                            <Columns>
                                                <telerik:GridButtonColumn CommandName="EditData" ItemStyle-Width="10px" Text="Edit" UniqueName="EditData" ButtonType="ImageButton" ImageUrl="~/Images/Icons/Pencil-01.png"></telerik:GridButtonColumn>
                                                <telerik:GridButtonColumn CommandName="DeleteColumn" Text="Delete" UniqueName="DeleteColumn" ButtonType="ImageButton" ImageUrl="~/Images/Cancel.png" ConfirmDialogType="RadWindow" ConfirmText="Are you sure, you want to delete this item ?">  </telerik:GridButtonColumn>
                                                <telerik:GridButtonColumn CommandName="ViewDetailColumn" Text="ViewDetails" UniqueName="ViewDetailColumn"  ButtonType="ImageButton" Display="false" ImageUrl="~/Images/Document Next-WF.png"  ></telerik:GridButtonColumn>
                  
                                                <telerik:GridBoundColumn HeaderText="Project No" DataField="ProjectNo" UniqueName="ProjectNo"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="ID No" DataField="IDNo" UniqueName="IDNo"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="LinkIDNo" DataField="LinkIDNo" UniqueName="LinkIDNo"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="EILType" DataField="EILType" UniqueName="EILType"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="CreatedBy" DataField="CreatedBy" UniqueName="CreatedBy"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="CreatedDt" DataField="CreatedDt" UniqueName="CreatedDt" DataType="System.DateTime" DataFormatString="{0:dd/MMM/yyyy}"></telerik:GridBoundColumn>

                                            </Columns>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                      <asp:Label ID="lblTypeNeed" runat="server" Text="" Visible="false"></asp:Label>
                                </div>
                            </telerik:RadPageView>

                            <telerik:RadPageView ID="rpAddEdit" runat="server">
                                <asp:Label ID="lblerror" runat="server" Text="" ForeColor="Red"></asp:Label>

                                <uc1:ToolBar runat="server" ID="ToolBar" />
                           

                             <%-- Tracking Details--%>
                                               <div class="accordion-container"> <a href="#" class="accordion-toggle" id="IDAccordion">Tracking Details  
                              <span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>
                              
                             <div class="accordion-content" > 
                                      <div class="col-md-12 Span-One">
                                    <div class="col-md-6">
                                      <div class="form-group">
                    
                            <asp:Label ID="lblModule" runat="server" Text="Module"  class="control-label col-md-5" for="email3"></asp:Label>
                     
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlModule" runat="server" CssClass="selectbox" AppendDataBoundItems="false" AutoPostBack="true" OnSelectedIndexChanged="ddlModule_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>

                                    <div class="col-md-6">

                                        <div class="form-group">

                                             <asp:Label ID="lblCate" runat="server" Text="Category"  class="control-label col-md-5" for="email3"></asp:Label>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="selectbox" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AppendDataBoundItems="false" AutoPostBack="true"></asp:DropDownList>

                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>

                           
                                    <div class="col-md-6">

                                        <div class="form-group">
                                              <br />
                                            <asp:Label ID="lblTag" runat="server" Text="Tag"  class="control-label col-md-5" for="email3"></asp:Label>
                                             
                                             <div class="col-md-7">                                           
                                                    <telerik:RadComboBox RenderMode="Lightweight" ID="radTagNo" EnableAutomaticLoadOnDemand="true" ItemsPerRequest="10" ShowMoreResultsBox="true" EnableVirtualScrolling="true" runat="server" Width="180" Height="200px" EmptyMessage="Search for TagNo..." >
                                                    <WebServiceSettings Method="GetAllTagNo" Path="ConstructionPunchList.aspx"></WebServiceSettings>
                                                         </telerik:RadComboBox>
                                                 
                                            </div>
                                       <%--   <input id="txtLoading" type="text" value="Loading"/>--%>
                                        </div>
                                        <%-- </form>--%>
                                    </div>
                                          <br />
                                          <br />
                                          
                                       
                                    <div class="col-md-6">

                                        <div class="form-group">
                                           
 <asp:Label ID="lblActivity" runat="server" Text="Activity"  class="control-label col-md-5" for="email3"></asp:Label>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlActivity" runat="server" CssClass="selectbox"  AppendDataBoundItems="false" AutoPostBack="true"></asp:DropDownList>

                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>
                                </div>
                                </div></div>
                                                              
                                 <%-- General Details--%>
                                   <div class="accordion-container"> <a href="#" class="accordion-toggle" id="IDAccordion">General Details
                              <span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>
                              
                             <div class="accordion-content">
                                <div class="col-md-12 Span-One">
                                    <div class="col-md-6">

                                         <div class="form-group required">
                              
                                              <asp:Label ID="lblIdno" runat="server" Text="ID No"  class="control-label col-md-5" for="email3"></asp:Label>
                                            <div class="col-md-7">
                                                <table>
                                                    <tr>
                                                        <td>
                                                <asp:TextBox ID="txtIDno" CssClass="form-control" runat="server" onchange="checkIdNo(this)"></asp:TextBox></td>
                                                <td> <asp:Image  ID="imgWebLnames" runat="server" ToolTip="ID is Available" ImageUrl="~/Images/ProjectImages/Check.png" Width="17px" Height="17px"/></td>
                                               <td>  <asp:Image ID="errorLnames" runat="server" ToolTip="ID is Unavailable" ImageUrl="~/Images/ProjectImages/newClose.png" Width="10px" Height="10px" /></td>
                                          </tr> </table>
                                                     </div>
                                        </div>
                                        <%-- </form>--%>
                                   </div>

                                    <div class="col-md-6">

                                        <div class="form-group">

                                               <asp:Label ID="lblOpenBy" runat="server" Text="Open By"  class="control-label col-md-5" for="email3"></asp:Label>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlOpenBy" runat="server" CssClass="selectbox">
                                                </asp:DropDownList>
                                                <asp:Label ID="lblIDNum" runat="server" Text="" Visible="false"></asp:Label>
                                                 <asp:Label ID="lblEliTypeNum" runat="server" Text="" Visible="false"></asp:Label>
                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>



                                    <div class="col-md-6">

                                        <div class="form-group">

                                                <asp:Label ID="lblEnteredDate" runat="server" Text="Entered Date"  class="control-label col-md-5" for="email3"></asp:Label>
                                            <div class="col-md-7">

                                                <telerik:RadDatePicker ID="RadEnteredDate" runat="server"
                                                    Width="200px" TabIndex="2" AutoPostBack="false" MinDate="<%# DateTime.Now.Date %>">
                                                    <DateInput DateFormat="dd/MMM/yyyy" DisplayDateFormat="dd/MMM/yyyy" InvalidStyleDuration="100"
                                                        runat="server">
                                                    </DateInput>
                                                    <Calendar runat="server">
                                                    </Calendar>
                                                </telerik:RadDatePicker>

                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>

                                    <div class="col-md-6">

                                        <div class="form-group">

                                             <asp:Label ID="lblEnteredBy" runat="server" Text="Entered By"  class="control-label col-md-5" for="email3"></asp:Label>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlEnteredBy" runat="server" CssClass="selectbox">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>
                          



                                    <div class="col-md-6">

                                        <div class="form-group">

                                 <asp:Label ID="lblOpenDate" runat="server" Text="Open Date"  class="control-label col-md-5" for="email3"></asp:Label>
                                            <div class="col-md-7">

                                                <telerik:RadDatePicker ID="RadOpenDate" runat="server"
                                                    Width="200px" TabIndex="2" AutoPostBack="false">
                                                   <DateInput DateFormat="dd/MMM/yyyy" DisplayDateFormat="dd/MMM/yyyy" InvalidStyleDuration="100"
                                                        runat="server">
                                                    </DateInput>


                                                </telerik:RadDatePicker>
                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>


                                </div>

                                 </div>
                                    
         </div>
                                  <%-- Location Details--%>
                                             <div class="accordion-container"> <a href="#" class="accordion-toggle" >  Location Details 
                              <span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>
                              
                             <div class="accordion-content"> 
                                           <div class="col-md-12 Span-One">
                                    <div class="col-md-6">

                                        <div class="form-group">
                           <asp:Label ID="lblPlant" runat="server" Text="Plant"  class="control-label col-md-5" for="email3"></asp:Label>
                                            <div class="col-md-7">

                                                <asp:DropDownList ID="ddlPlant" runat="server" CssClass="selectbox">
                                                </asp:DropDownList>

                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>

                                    <div class="col-md-6">

                                        <div class="form-group">

                                            <asp:Label ID="lblArea" runat="server" Text="Area"  class="control-label col-md-5" for="email3"></asp:Label>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlArea" runat="server" CssClass="selectbox">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>


                          
                                    <div class="col-md-6">

                                        <div class="form-group">

                                       <asp:Label ID="lblLocation" runat="server" Text="Location"  class="control-label col-md-5" for="email3"></asp:Label>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlLocation" runat="server" CssClass="selectbox">
                                                </asp:DropDownList>

                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>

                                    <div class="col-md-6">

                                        <div class="form-group">

                                <asp:Label ID="lblUnit" runat="server" Text="Unit"  class="control-label col-md-5" for="email3"></asp:Label>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlUnit" runat="server" CssClass="selectbox">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>
                                </div>
                                </div>
                                                               </div>
                                        <%--System--%>   
                                             <div class="accordion-container"> <a href="#" class="accordion-toggle"> System 
                              <span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>
                              
                             <div class="accordion-content">  
                                  <div class="col-md-12 Span-One">
                                    <div class="col-md-6">

                                        <div class="form-group">
    <asp:Label ID="lblSystem" runat="server" Text="System"  class="control-label col-md-5" for="email3"></asp:Label>
                                            <div class="col-md-7">

                                              <%--  <asp:TextBox ID="txtSystem" CssClass="form-control" runat="server"></asp:TextBox>--%>
                                                <asp:DropDownList ID="ddlSystem" runat="server" CssClass="selectbox"></asp:DropDownList>

                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>

                                    <div class="col-md-6">

                                        <div class="form-group">

    <asp:Label ID="lblControlSystem" runat="server" Text="Control System"  class="control-label col-md-5" for="email3"></asp:Label>
                                            <div class="col-md-7">


                                                <%--<asp:TextBox ID="txtControlSystem" CssClass="form-control" runat="server"></asp:TextBox>--%>
                                                <asp:DropDownList ID="ddlControlSystem" runat="server" CssClass="selectbox"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    
                                    </div>
                            

                               
                                    <div class="col-md-6">

                                        <div class="form-group">

    <asp:Label ID="lblSubSystem" runat="server" Text="Sub System"  class="control-label col-md-5" for="email3"></asp:Label>
                                            <div class="col-md-7">

                                                <%--<asp:TextBox ID="txtSubsystem" CssClass="form-control" runat="server"></asp:TextBox>--%>
                                                <asp:DropDownList ID="ddlSubsystem" runat="server" CssClass="selectbox"></asp:DropDownList>

                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>
   
                                </div>
                                </div></div>
                                  <%--Item Details--%>  
                                <div class="accordion-container"> <a href="#" class="accordion-toggle">Item Details   
                              <span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>
                              
                             <div class="accordion-content"> 
                                              
                                 <div class="col-md-12 Span-One">
                                    <div class="col-md-6">

                                        <div class="form-group">
    <asp:Label ID="lblRequestedBy" runat="server" Text="Requested By"  class="control-label col-md-5" for="email3"></asp:Label>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlRequestedBy" runat="server" CssClass="selectbox">
                                                </asp:DropDownList>

                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>

                                    <div class="col-md-6">

                                        <div class="form-group">

    <asp:Label ID="lblInspector" runat="server" Text="Inspector"  class="control-label col-md-5" for="email3"></asp:Label>
                                            <div class="col-md-7">

                                                <asp:DropDownList ID="ddlInspector" runat="server" CssClass="selectbox">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>
                            

                                    <div class="col-md-6">

                                        <div class="form-group">


    <asp:Label ID="lblActionBy" runat="server" Text="Action By"  class="control-label col-md-5" for="email3"></asp:Label>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlActionBy" runat="server" CssClass="selectbox">
                                                </asp:DropDownList>

                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>

                                    <div class="col-md-6">

                                        <div class="form-group">
    <asp:Label ID="lblDiscipline" runat="server" Text="Discipline"  class="control-label col-md-5" for="email3"></asp:Label>
                                            <div class="col-md-7">

                                                <asp:DropDownList ID="ddlDiscipline" runat="server" CssClass="selectbox">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>
                                
                                    <div class="col-md-6">

                                        <div class="form-group">


     <asp:Label ID="lblFailCategory" runat="server" Text="Fail Category"  class="control-label col-md-5" for="email3"></asp:Label>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlFailCategory" runat="server" CssClass="selectbox">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>

                                    <div class="col-md-6">

                                        <div class="form-group">

    <asp:Label ID="lblCategory" runat="server" Text="Category"  class="control-label col-md-5" for="email3"></asp:Label>
                                            <div class="col-md-7">

                                                <asp:DropDownList ID="ddlCategoryList" runat="server" CssClass="selectbox">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>
                             

                               
                                    <div class="col-md-6">

                                        <div class="form-group">

    <asp:Label ID="lblRFIno" runat="server" Text="RFI No"  class="control-label col-md-5" for="email3"></asp:Label>
                                            <div class="col-md-7">

                                                <asp:TextBox ID="txtRFINo" CssClass="form-control" runat="server"></asp:TextBox>

                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>

                                    <div class="col-md-6">

                                        <div class="form-group">

    <asp:Label ID="lblRFIDate" runat="server" Text="RFI Date"  class="control-label col-md-5" for="email3"></asp:Label>
                                            <div class="col-md-7">
                                                <telerik:RadDatePicker ID="RadRFIDate" runat="server"
                                                    Width="200px" TabIndex="2" AutoPostBack="false">
                                                    <DateInput DateFormat="dd/MMM/yyyy" InvalidStyleDuration="100" LabelCssClass="radLabelCss_Office2007"
                                                        runat="server">
                                                    </DateInput>


                                                </telerik:RadDatePicker>
                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>
                              

                                    <div class="col-md-6">

                                        <div class="form-group">
    <asp:Label ID="lblCoveredByProject" runat="server" Text="Covered By Project"  class="control-label col-md-5" for="email3"></asp:Label>
                                            <div class="col-md-1">

                                                <asp:RadioButton ID="rdbCoveredByYes"  runat="server" GroupName="Coveredbyproject" ToolTip="1" Text="Yes"/></div>
                                              <div class="col-md-6">
                <asp:RadioButton ID="rdbCoveredByNo" runat="server"  GroupName="Coveredbyproject" ToolTip="0" Text="No"/></div>
                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    

                                    <div class="col-md-6">

                                        <div class="form-group">

    <asp:Label ID="lblItemDescription" runat="server" Text="Item Description"  class="control-label col-md-5" for="email3"></asp:Label>
                                            <div class="col-md-7">

                                                <asp:TextBox ID="txtItemDescription" CssClass="form-control" runat="server"></asp:TextBox>

                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>
                                </div>
                                </div>
          </div>
                                  <%--Change Request Details--%>
                                <div class="accordion-container"> <a href="#" class="accordion-toggle"> Change Request Details  
                              <span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>
                              
                             <div class="accordion-content"> 
                                           
                                  <div class="col-md-12 Span-One">
                                    <div class="col-md-6">

                                        <div class="form-group">
    <asp:Label ID="Label1" runat="server" Text="Reference"  class="control-label col-md-5" for="email3"></asp:Label>
                                            <div class="col-md-7">

                                                <asp:TextBox ID="txtReference" CssClass="form-control" runat="server"></asp:TextBox>

                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>

                                    <div class="col-md-6">

                                        <div class="form-group">
    <asp:Label ID="Label2" runat="server" Text="Change Request"  class="control-label col-md-5" for="email3"></asp:Label>
                                            <div class="col-md-7">
                                                
                                                 <div class="col-md-1">

                                                <asp:RadioButton ID="rdbChangeRequestyes" runat="server" Text="Yes" GroupName="ChangeRequest" ToolTip="1"/></div>
                                              <div class="col-md-6">
                <asp:RadioButton ID="rdbchangerequestno" runat="server" Text="No" GroupName="ChangeRequest" ToolTip="0"/></div>
                                            </div>
                                              
                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>
                                </div>
                                 </div>
                                <%--Drawing Details--%>
                                            <div class="accordion-container"> <a href="#" class="accordion-toggle">Drawing Details   
                              <span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>
                              
                             <div class="accordion-content"> 
                                        <div class="col-md-12 Span-One">
                                    <div class="col-md-6">

                                        <div class="form-group"> 
    <asp:Label ID="Label3" runat="server" Text="Drawing"  class="control-label col-md-5" for="email3"></asp:Label>
                                            <div class="col-md-7">

                                                <asp:TextBox ID="txtDrawing" CssClass="form-control" runat="server"></asp:TextBox>

                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>

                                    <div class="col-md-6">

                                        <div class="form-group">
    <asp:Label ID="Label4" runat="server" Text="Sheet"  class="control-label col-md-5" for="email3"></asp:Label>
                                            <div class="col-md-7">

                                                <asp:TextBox ID="txtSheet" CssClass="form-control" runat="server"></asp:TextBox>

                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>
                              
                                    <div class="col-md-6">

                                        <div class="form-group">

    <asp:Label ID="Label5" runat="server" Text="Revision"  class="control-label col-md-5" for="email3"></asp:Label>
                                            <div class="col-md-7">

                                                <asp:TextBox ID="txtRevision" CssClass="form-control" runat="server"></asp:TextBox>

                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>

                                    <div class="col-md-6">

                                        <div class="form-group">
      <asp:Label ID="Label6" runat="server" Text="Reference Date"  class="control-label col-md-5" for="email3"></asp:Label>
                                            <div class="col-md-7">
                                                <telerik:RadDatePicker ID="RadReferenceDate" runat="server"
                                                    Width="200px" TabIndex="2" AutoPostBack="false">
                                                    <DateInput DateFormat="dd/MMM/yyyy" InvalidStyleDuration="100" LabelCssClass="radLabelCss_Office2007"
                                                        runat="server">
                                                    </DateInput>


                                                </telerik:RadDatePicker>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                </div></div>
                                  <%--Query Details--%>
                                   <div class="accordion-container"> <a href="#" class="accordion-toggle">Query Details  
                                            
                              <span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>
                              
                             <div class="accordion-content"> 
                               
                                  <div class="col-md-12 Span-One">
                                    <div class="col-md-6">

                                        <div class="form-group">
    <asp:Label ID="Label7" runat="server" Text="Query"  class="control-label col-md-5" for="email3"></asp:Label>
                                            <div class="col-md-7">

                                                <asp:TextBox ID="txtQuery" CssClass="form-control" runat="server"></asp:TextBox>

                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>

                                    <div class="col-md-6">

                                        <div class="form-group">

    <asp:Label ID="Label8" runat="server" Text="Query Status"  class="control-label col-md-5" for="email3"></asp:Label>
                                            <div class="col-md-7">

                                                <asp:TextBox ID="txtQueryStatus" CssClass="form-control" runat="server"></asp:TextBox>

                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>
                               
                                    <div class="col-md-6">

                                        <div class="form-group">


    <asp:Label ID="Label9" runat="server" Text="Query Revision"  class="control-label col-md-5" for="email3"></asp:Label>
                                            <div class="col-md-7">

                                                <asp:TextBox ID="txtQueryRevision" CssClass="form-control" runat="server"></asp:TextBox>

                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>


                                </div>
                                </div></div>
                                 <%--Completion Details--%>
                                 <div class="accordion-container"> <a href="#" class="accordion-toggle">Completion Details 
                                            
                              <span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>
                              
                             <div class="accordion-content"> 
                                <div class="col-md-12 Span-One">
                                    <div class="col-md-6">

                                        <div class="form-group">
    <asp:Label ID="Label10" runat="server" Text="Responsible Person"  class="control-label col-md-5" for="email3"></asp:Label>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlResponsiblePerson" runat="server" CssClass="selectbox">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>

                                    <div class="col-md-6">

                                        <div class="form-group">

                <asp:Label ID="Label11" runat="server" Text="Organization"  class="control-label col-md-5" for="email3"></asp:Label>
                                            <div class="col-md-7">

                                                <asp:DropDownList ID="ddlOrganization" runat="server" CssClass="selectbox">
                                                </asp:DropDownList>

                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>
                               
                                    <div class="col-md-6">

                                        <div class="form-group">

    <asp:Label ID="Label12" runat="server" Text="Signed By"  class="control-label col-md-5" for="email3"></asp:Label>
                                            <div class="col-md-7">

                                                <asp:DropDownList ID="ddlSignedBy" runat="server" CssClass="selectbox">
                                                </asp:DropDownList>

                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>

                                    <div class="col-md-6">

                                        <div class="form-group">

          <asp:Label ID="Label13" runat="server" Text="Completion Date"  class="control-label col-md-5" for="email3"></asp:Label>
                                            <div class="col-md-7">


                                                <telerik:RadDatePicker ID="RadCompletionDate" runat="server" Culture="Portuguese (Brazil)"
                                                    Width="200px" TabIndex="2" AutoPostBack="false">
                                                    <DateInput DateFormat="dd/MM/yyyy" InvalidStyleDuration="100" LabelCssClass="radLabelCss_Office2007"
                                                        runat="server">
                                                    </DateInput>

                                                    <Calendar runat="server">
                                                    </Calendar>
                                                </telerik:RadDatePicker>
                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>
                             

                                    <div class="col-md-6">

                                        <div class="form-group">

                                                <asp:Label ID="Label14" runat="server" Text="Scheduled Completion Date"  class="control-label col-md-5" for="email3"></asp:Label>
                                    
                                            <div class="col-md-7">

                                                <telerik:RadDatePicker ID="RadScheduleCompletionDate" runat="server" Culture="Portuguese (Brazil)"
                                                    Width="200px" TabIndex="2" AutoPostBack="false">
                                                    <DateInput DateFormat="dd/MM/yyyy" InvalidStyleDuration="100" LabelCssClass="radLabelCss_Office2007"
                                                        runat="server">
                                                    </DateInput>

                                                    <Calendar runat="server">
                                                    </Calendar>
                                                </telerik:RadDatePicker>
                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>

                                    <div class="col-md-6">

                                        <div class="form-group">
                                              <asp:Label ID="Label15" runat="server" Text="Completion Remarks"  class="control-label col-md-5" for="email3"></asp:Label>
                                     
                                            <div class="col-md-7">

                                                <asp:TextBox ID="txtCompletionRemarks" runat="server" TextMode="MultiLine" Height="60px" Width="200px"></asp:TextBox>


                                            </div>
                                        </div>
                                        <%-- </form>--%>

                                 </div></div></div></div>
                                  <div class="accordion-container"> <a href="#" class="accordion-toggle">Attachments 
                                            
                              <span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>
                              
                             <div class="accordion-content"> 
                            <div class="col-md-3"></div>
                                 <div class="col-md-6">
                                   <table id="table1">
       <tr>
          <td>   <uc1:uc_flycnfileupload runat="server" ID="IdUc_FlyCnFileUpload" /></td>
           <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
             <td>  <asp:Button ID="btnsubmit" runat="server" Text="Upload" Enabled="false" OnClick="btnsubmit_Click" /></td>
           </tr>
       <tr>
          
           <td>
           <asp:Label ID="Label16" runat="server" Text="" ForeColor="Red"></asp:Label>
               </td>
       </tr>
           </table>
    <br />
         <table id="table2">
    <tr><td>
         <asp:GridView ID="GridView1" CssClass="Grid" runat="server" CellPadding="5" CellSpacing="10" AutoGenerateColumns="False" Height="111px" Width="400px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataKeyNames="AttachmentID" OnRowDeleting="GridView1_RowDeleting">
             <Columns>
                 <asp:BoundField DataField="AttachmentID" HeaderText="ID" Visible="false" />
                 <asp:BoundField DataField="AttachmentName" HeaderText="File Name" />
                 <asp:BoundField DataField="FileType" HeaderText="File Type" />
                 <asp:BoundField DataField="FileSize" HeaderText="File Size" />
                 
                 <asp:ButtonField CommandName="Select" ButtonType="Image" ImageUrl="~/Images/Download-202-WF.png" ControlStyle-Height="15px"/>

                  <asp:ButtonField CommandName="Delete" ButtonType="Image" ImageUrl="~/Images/Cancel.png" ControlStyle-Height="15px"/>
                 
             </Columns>
         </asp:GridView>
        </td></tr>
          </table>
                         </div>
                                 <div class="col-md-3">
                             </div>
                                      </div></div>
                                        <%-- </form>--%>
                           <table style="width: 100%;">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                   

                                  
                                </table>
                                <table style="width: 100%;">
                                    <tr>
                                        <td class="tabletd">
                                            <asp:GridView ID="grdFileUpload" DataKeyNames="FileName" runat="server" AutoGenerateColumns="false" style="width:80%" OnRowCommand="grdFileUpload_RowCommand" OnRowDeleting="grdFileUpload_RowDeleting" OnRowDataBound="grdFileUpload_RowDataBound" GridLines="None">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            Serial No.
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSRNO" runat="server"
                                                                Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="hdnField" runat="server" Value='<%# Bind("SlNo") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="hdnType" runat="server" Value='<%# Bind("EILType") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="FileName" DataField="FileName" />

                                                    <%--<ItemTemplate>--%>
                                                    <%--<asp:ImageButton ID="imageButtonDelete" ImageUrl="~/Images/Trash can - 04.png" 
Text="Delete" CommandName="Delete" runat="server" />--%>
                                                    <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/Cancel.png" CommandName="Delete" Text="Delete" Visible="True" />
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imageButtonDownload" ImageUrl="~/Images/Download-02-WF.png" Text="Download" Visible="True" runat="server" OnClick="imageButtonDownload_Click" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                              
                                <table style="width: 100%;">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>

                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>

                                        <%-- <td>
             <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Width="46px" ValidationGroup="dummy"/>
              &nbsp;<asp:Button  ID="btnUpdate" runat="server" Text="Update"  Onclick="btnUpdate_Click"/>
&nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" Height="27px" Width="49px" OnClick="btnCancel_Click" />
            </td>--%>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>



                            </telerik:RadPageView>


                        </telerik:RadMultiPage>
                    </td>
                </tr>
            </table>
            
        </div>
        
 </div>

     <asp:HiddenField ID="hdnAccessMode" runat="server" />
    <asp:HiddenField ID="hdnMode" runat="server" ClientIDMode="Static"/>
    <asp:HiddenField ID="hdnIdNo" runat="server" ClientIDMode="Static" />
       <asp:HiddenField ID="hdnSecurity" runat="server" />
    <asp:HiddenField ID="hdnTagNo" runat="server" />
    <asp:HiddenField ID="hdfValidateSave" runat="server" />
 
</asp:Content>


