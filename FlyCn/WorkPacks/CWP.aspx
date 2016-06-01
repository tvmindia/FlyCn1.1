<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="CWP.aspx.cs" Inherits="FlyCn.WorkPacks.CWP" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <%-- Registration--%>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <script src="../Scripts/jquery-1.8.2.js"></script>
     <script src="../Scripts/jquery-1.8.2.min.js"></script>
     <script src="../Scripts/jquery-ui-1.8.24.js"></script>
     <script src="../Scripts/jquery-ui-1.8.24.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script src="../Scripts/ToolBar.js"></script>
    <script src="../Scripts/Messages.js"></script>
      <link href="../Content/themes/base/jquery-ui.css" rel="stylesheet" />
     <style type="text/css">
        .ui-dialog-title {
            padding-left: 15em;
            color: #333300;
        }

        .ui-widget {
    font-family: Verdana,Arial,sans-serif/*{ffDefault}*/;
    font-size: 1.4em/*{fsDefault};;; */;
}
        .ui-dialog-titlebar {
            background: transparent;
            border: none;
            /*height: 1.1em;*/
        }
         .RadGrid_Default {
             border:none;
         }
        .ui-dialog .ui-dialog-titlebar-close {
            right: 0;
        }

        .ui-dialog {
            /*overflow:auto;
      overflow-x:hidden;*/
            background: top;
            background-color: white;
            border: 1px solid #fff;
            margin-top: 20px;
            margin-bottom: 30px;
            -moz-border-radius: 12px;
            -webkit-border-radius: 12px;
            border-radius: 12px;
            -moz-box-shadow: 4px 4px 14px #000;
            -webkit-box-shadow: 4px 4px 14px #000;
            box-shadow: 4px 4px 14px #000;
            border-top: #A6CAB8 3px solid;
        }

        .headings {
            font-family: 'segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            font-size: 15px;
            font-style: normal;
            color: #009933;
        }

        
    </style>
     <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePartialRendering="true" EnablePageMethods="true"  >
       
    </asp:ScriptManager>
    <div>
    <asp:Label ID="lblTitle" runat="server" Text="Construction Work Packs" CssClass="PageHeading"></asp:Label></div>
    <div class="container" style="width: 100%">
         <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" Width="200px" OnClientTabSelected="onClientTabSelected" OnClientTabSelecting="OnClientTabSelecting"
            CausesValidation="false" SelectedIndex="0" Skin="FlyCnRed_Rad" EnableEmbeddedSkins="false"  >

            <Tabs>
                <telerik:RadTab Text="View" PageViewID="rpList" Value="1" Width="100px" Height="25px" runat="server" ImageUrl="~/Images/Icons/ListIcon.png" Selected="True"></telerik:RadTab>
                <telerik:RadTab Text="New" PageViewID="rpAddEdit" Value="2" Width="100px"  Height="25px" runat="server" ImageUrl="~/Images/Icons/NewIcon.png"></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
         <div id="content" style="height:600px;overflow-y:hidden;">


            <div class="contentTopBar"></div>
              <table style="width: 100%">
                   <tr>
                       <td>
                              <telerik:RadMultiPage ID="RadMultiPage1" runat="server" Width="100%" SelectedIndex="0" CssClass="outerMultiPage">

                                     <telerik:RadPageView ID="rpList" runat="server">
                                         <div id="divList" style="width: 100%;text-align:center">

                                             <telerik:RadGrid runat="server" ID="dtgCWPHeaderGrid" CellSpacing="0" GridLines="None" AlwaysVisible="true" AllowPaging="true" AllowAutomaticDeletes="false" AllowSorting="true" AllowAutomaticUpdates="false" PageSize="10" Width="100%" OnNeedDataSource="dtgCWPHeaderGrid_NeedDataSource" OnItemCommand="dtgCWPHeaderGrid_ItemCommand">
                                                   <HeaderStyle  HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <AlternatingItemStyle HorizontalAlign="Left" />
                                        <ClientSettings>
                                            <Selecting AllowRowSelect="true" EnableDragToSelectRows="false" />                 
                                        </ClientSettings>
                                          <MasterTableView AutoGenerateColumns="false" DataKeyNames="DocumentID,RevisionID" ShowHeadersWhenNoRecords="true" ShowHeader="true" NoMasterRecordsText="No Items have been added." InsertItemPageIndexAction="ShowItemOnFirstPage" InsertItemDisplay="Top">
                                               <Columns>
                                                    <telerik:GridButtonColumn CommandName="EditDoc" ButtonType="ImageButton" ImageUrl="~/Images/Icons/Pencil-01.png" Text="Edit" UniqueName="EditData">
                                                </telerik:GridButtonColumn>
                                                     <telerik:GridBoundColumn HeaderText="Project No" DataField="ProjectNo" UniqueName="ProjectNo" Display="false"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="DocumentID" DataField="DocumentID" UniqueName="DocumentID" Display="false"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="RevisionID" DataField="RevisionID" UniqueName="RevisionID" Display="false"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Document No" DataField="DocumentNo" UniqueName="DocumentNo"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Title" DataField="DocumentTitle" UniqueName="DocumentTitle"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Client Doc No" DataField="ClientDocNo" UniqueName="ClientDocNo"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Revision No" DataField="RevisionNo" UniqueName="RevisionNo"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Document Date" DataField="DocumentDate" UniqueName="DocumentDate" DataType="System.DateTime" DataFormatString="{0:dd/MMM/yyyy}"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Planner" DataField="Planner" UniqueName="Planner" ></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Document Owner" DataField="DocumentOwner" UniqueName="DocumentOwner"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Created Date" DataField="CreatedDate" UniqueName="CreatedDate" DataType="System.DateTime" DataFormatString="{0:dd/MMM/yyyy}"></telerik:GridBoundColumn>
                                                 <telerik:GridBoundColumn HeaderText="Revision Date" DataField="RevisionDate" UniqueName="RevisionDate" DataType="System.DateTime" DataFormatString="{0:dd/MMM/yyyy}"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Document Status" DataField="DocumentStatus" UniqueName="DocumentStatus"></telerik:GridBoundColumn>
                                                   </Columns>
                                              </MasterTableView>
                                             </telerik:RadGrid>
                                             </div>
                                         </telerik:RadPageView>
                                   <telerik:RadPageView ID="rpAddEdit" runat="server">
                                          <uc1:ToolBar runat="server" ID="ToolBar" OnClientButtonClicking="SetIframeSrc(CWP_Detail)" />
                                        <div class="col-md-12 Span-One">
                                              <div class="col-md-6">

                                        <div class="form-group">
                                            <asp:Label ID="lblDocumentNo" CssClass="control-label col-md-5" runat="server" Text="Document No"></asp:Label>   
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtDocumentNo" Enabled="false" CssClass="form-control AutoGenTextbox" ClientIDMode="Static" runat="server"></asp:TextBox>
                                              
                                            </div>
                                        </div>
                                    </div>
                                              <div class="col-md-6">

                                        <div class="form-group">
                                            <asp:Label ID="lblDocumentOwner" CssClass="control-label col-md-5" runat="server" Text="Document Owner"></asp:Label>   
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtDocumentOwner" Enabled="false" CssClass="form-control AutoGenTextbox" ClientIDMode="Static" runat="server"></asp:TextBox>
                                              
                                            </div>
                                        </div>
                                    </div>
                                              <div class="col-md-6">

                                        <div class="form-group required">
                                            <asp:Label ID="lblClientDocumentNo" CssClass="control-label col-md-5" runat="server" Text="Client Document No"></asp:Label>   
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtClientDocumentNo" Enabled="true" CssClass="form-control AutoGenTextbox" ClientIDMode="Static" runat="server"></asp:TextBox>
                                              
                                            </div>
                                        </div>
                                    </div>
                                              <div class="col-md-6">

                                        <div class="form-group required">
                                            <asp:Label ID="lblRevisionNo" CssClass="control-label col-md-5" runat="server" Text="Revision No"></asp:Label>   
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtRevisionNo" Enabled="true" CssClass="form-control AutoGenTextbox" ClientIDMode="Static" runat="server"></asp:TextBox>
                                              
                                            </div>
                                        </div>
                                    </div>
                                                                                      <div class="col-md-6">

                                        <div class="form-group required">
                                            <asp:Label ID="lblDocumentTitle" CssClass="control-label col-md-5" runat="server" Text="Document Title"></asp:Label>   
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtDocumentTitle" Enabled="true" CssClass="form-control AutoGenTextbox" ClientIDMode="Static" runat="server"></asp:TextBox>
                                              
                                            </div>
                                        </div>
                                    </div>
                                            
                                                                                      <div class="col-md-6">

                                        <div class="form-group required">
                                            <asp:Label ID="lblDocumetDate" CssClass="control-label col-md-5" runat="server" Text="Documet Date"></asp:Label>   
                                            <div class="col-md-7">
                                               <!----------->                                               
                                           <div id="datepicker" class="input-group date " data-date-format="dd-M-yyyy">
                                           <input   id="txtdatepicker" class="form-control"  type="text" runat="server" readonly="readonly"/>
                                           <span class="input-group-addon dateicon"  ><i class="glyphicon glyphicon-calendar"></i></span> </div>
                                            <!----------->
                                              
                                            </div>
                                        </div>
                                    </div>
                                                                                                                                      <div class="col-md-6">

                                        <div class="form-group required">
                                            <asp:Label ID="lblPlanner" CssClass="control-label col-md-5" runat="server" Text="Planner"></asp:Label>   
                                            <div class="col-md-7">
                                               <%-- <asp:TextBox ID="txtPlanner" Enabled="true" CssClass="form-control AutoGenTextbox" ClientIDMode="Static" runat="server"></asp:TextBox>--%>
                                                 <telerik:RadComboBox RenderMode="Lightweight" ID="radPlanner" EnableAutomaticLoadOnDemand="true" ItemsPerRequest="10" ShowMoreResultsBox="true" EnableVirtualScrolling="true" runat="server" Width="180" Height="200px" EmptyMessage="Select Planner" >
                                                    <WebServiceSettings Method="GetAllNames" Path="CWP.aspx"></WebServiceSettings>
                                                         </telerik:RadComboBox>
                                              
                                            </div>
                                        </div>
                                    </div>                                                                          <div class="col-md-6">

                                        <div class="form-group required">
                                            <asp:Label ID="lblRemarks" CssClass="control-label col-md-5" runat="server" Text="Remarks"></asp:Label>   
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtRemarks" TextMode="MultiLine" Enabled="true" CssClass="form-control AutoGenTextbox" ClientIDMode="Static" runat="server"></asp:TextBox>
                                              
                                            </div>
                                        </div>
                                    </div> 
                                             <div class="col-md-6">&nbsp;</div>
                                            <div class="col-md-6">
                                             <asp:Label ID="lblDocumentStatus" CssClass="DocStatusLabel" runat="server" ClientIDMode="Static"></asp:Label>
                                         </div>
                                            </div>

                                        <div class="col-md-12">
                                     <div class="col-md-6">&nbsp;</div>
                                     <div class="col-md-6">&nbsp;</div>
                                      <div class="col-md-6"></div>
                                       <div id="modal_dialog" style="display: none; overflow-x:hidden;overflow-y:hidden;">
                                      <iframe id="ContentApprovers" runat="server" style="width: 1000px; height: 600px;"></iframe>
                                      </div>
                                       <div class="content white">
                                       <div class="accordion-container">
                                         <a href="#" class="accordion-toggle" id="IDAccordion">Details<span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>
                                         <div class="accordion-content">
                                                <div id="rpCWPDetailList" style="width: 100%;text-align:center">
                                            <telerik:RadGrid ID="dtgCWPDetailGrid" runat="server" CellSpacing="0" GridLines="None" AlwaysVisible="true"  AllowPaging="true" AllowAutomaticDeletes="false" AllowAutomaticUpdates="false" AllowSorting="true" PageSize="10" Width="99%" OnNeedDataSource="dtgCWPDetailGrid_NeedDataSource" OnDeleteCommand="dtgCWPDetailGrid_DeleteCommand">
                                                <HeaderStyle  HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left"/>
                                        <AlternatingItemStyle HorizontalAlign="Left" />
                                        <ClientSettings>
                                            <Selecting AllowRowSelect="true" EnableDragToSelectRows="false" />                                           
                                        </ClientSettings>
                                                <MasterTableView AutoGenerateColumns="False" DataKeyNames="ItemID" ShowHeadersWhenNoRecords="true" ShowHeader="true" NoMasterRecordsText="No Items have been added." InsertItemPageIndexAction="ShowItemOnFirstPage" InsertItemDisplay="Top">
                                                    <Columns>
                                                        <telerik:GridButtonColumn CommandName="Delete" ButtonType="ImageButton" ImageUrl="~/Images/Cancel.png" Text="Delete" UniqueName="Delete">
                                </telerik:GridButtonColumn>
                                                         <telerik:GridBoundColumn HeaderText="ItemID" DataField="ItemID" UniqueName="ItemID" Display="false"></telerik:GridBoundColumn>
                                                         <telerik:GridBoundColumn HeaderText="RevisionID" DataField="RevisionID" UniqueName="RevisionID" Display="false"></telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn HeaderText="ProjectNo" DataField="ProjectNo" UniqueName="ProjectNo" Display="false"></telerik:GridBoundColumn>
                                                          <telerik:GridBoundColumn HeaderText="Item No" DataField="ItemNo" UniqueName="ItemNo" Display="true"></telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn HeaderText="Module ID" DataField="ModuleID" UniqueName="ModuleID" Display="true"></telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn HeaderText="Category" DataField="Category" UniqueName="Category" Display="true"></telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn HeaderText="KeyField" DataField="KeyField" UniqueName="KeyField" Display="true"></telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn HeaderText="KeyValue" DataField="KeyValue" UniqueName="KeyValue" Display="true"></telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn HeaderText="CreatedBy" DataField="CreatedBy" UniqueName="CreatedBy" Display="false"></telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn HeaderText="CreatedDate" DataField="CreatedDate" UniqueName="CreatedDate" Display="false"></telerik:GridBoundColumn>
                                                        </Columns>
                                                    </MasterTableView>
                                            </telerik:RadGrid>
                                            </div>
                                         <iframe id="ContentIframe" name="CWPDetails" style="height: 500px; width: 100%; overflow: hidden;" runat="server">
                                         </iframe>   
                                         </div>
                                       </div>
                                      </div>
                                            </div>
                                       </telerik:RadPageView>
                                  </telerik:RadMultiPage>
                       </td>
                   </tr>
                  </table>
             </div>
        </div>
     <div id="AddNewCWPDetail" style="display: none;width:800px; height: 500px; overflow-x: hidden;overflow-y:hidden "> 
         
        <iframe id="IframeContent" src="CWP_Detail.aspx" style="width:800px; height: 500px;overflow-y:hidden;" runat="server">           
        </iframe>         

    </div>

    <asp:HiddenField ID="hdfProjectNo" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hiddenFieldDocumentID" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hiddenFieldRevisionID" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hiddenFieldDocumentType" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hiddenDocumentOwner" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hiddenUsername" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hiddenRevisionNumber" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdfStatusValue" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hiddenDocumentNo" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="HiddenRevisionIdCollection" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hiddendocumentDate" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdfTabStatus" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdfLevelDescription" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hiddenStatusValue" runat="server" ClientIDMode="Static" />

    <script type="text/javascript">
        
        function ClearCWPHeaderTexBox() {

            document.getElementById('<%=txtDocumentNo.ClientID %>').value = "------System Generated Code------";
            document.getElementById('<%=txtDocumentOwner.ClientID%>').value = "-------Document Owner-------";
            document.getElementById('<%=txtClientDocumentNo.ClientID %>').value = "";
            document.getElementById('<%=txtRevisionNo.ClientID %>').value = "";
            $('#datepicker').datepicker('update', '');
            document.getElementById('<%=txtDocumentTitle.ClientID %>').value = "";
            document.getElementById('<%=txtRemarks.ClientID %>').value = "";
            var radCombo = $telerik.findComboBox("<%= radPlanner.ClientID %>");
            radCombo.clearSelection();
            radCombo.enable();
        }

        function DisableCWPHeaderTextBox() {

            var v1 = document.getElementById('<%=txtdatepicker.ClientID %>');
            v1.setAttribute("readonly", "readonly");
            v1 = document.getElementById('<%=txtClientDocumentNo.ClientID %>');
            v1.setAttribute("readonly", "readonly");
            v1 = document.getElementById('<%=txtRevisionNo.ClientID %>');
            v1.setAttribute("readonly", "readonly");
            v1 = document.getElementById('<%=txtDocumentTitle.ClientID %>');
            v1.setAttribute("readonly", "readonly");
            v1 = document.getElementById('<%=radPlanner.ClientID %>');
            v1.setAttribute("readonly", "readonly");
            v1 = document.getElementById('<%=txtRemarks.ClientID %>');
            v1.setAttribute("readonly", "readonly");
            // $('#datepicker').datepicker({ enableOnReadonly: false });
            // $(document).off('.datepicker.data-api');
            // $('#datepicker').datepicker('hide');
            //$('#datepicker').datepicker("remove");
            $(".input-group date").attr('readonly', 'readonly')
            v1 = document.getElementById('<%=ContentIframe.ClientID %>');
            v1.style["display"] = "block";
        }
        function EnableCWPHeaderTextBox() {

            //Enable header textboxess
            var e = document.getElementById('<%=txtClientDocumentNo.ClientID %>');
            e.removeAttribute("readonly", 0);
            e = document.getElementById('<%=txtRevisionNo.ClientID %>');
            e.removeAttribute("readonly", 0);
            e = document.getElementById('<%=txtdatepicker.ClientID %>');
            e.removeAttribute("readonly", 0);
            e = document.getElementById('<%=txtDocumentTitle.ClientID %>');
            e.removeAttribute("readonly", 0);
            e = document.getElementById('<%=txtRemarks.ClientID %>');
            e.removeAttribute("readonly", 0);
            e = document.getElementById('<%=radPlanner.ClientID %>');
            e.removeAttribute("readonly", 0);
            //Enable header textboxess

        }
        function AddNewCWPDetailWindow(HyperlinkID) {
            debugger;
            if (HyperlinkID == "CWP_Detail") {
                var AllRegistrationIframe = document.getElementById('<%=IframeContent.ClientID %>');
                AllRegistrationIframe.src = "../WorkPacks/CWP_Detail.aspx";
            }
            var frame = document.getElementById('IframeContent');
            try {
                $("#AddNewCWPDetail").dialog({
                    title: "New CWP Detail",
                    width: 800,
                    height: 500,
                    resizable: false,
                    buttons: {}, modal: true
                    
                });
                return false
            }
            catch (X) {
                alert(X.message);
            }
           
        }
        function OnClientButtonClicking(sender, args) {
          
            var btn = args.get_item();
            if (btn.get_value() == 'Save') {

                args.set_cancel(!validate());
            }
            if (btn.get_value() == 'Add') {
                AddNewCWPDetailWindow("CWP_Detail");
                args.set_cancel(true);
            }
            if (btn.get_value() == 'Update') {

                args.set_cancel(!validateUpdate());
            }
        }

        function OnClientTabSelecting(sender, eventArgs) {
           
            var tab = eventArgs.get_tab();
            if (tab.get_text() == "New") {
                document.getElementById('<%=lblDocumentStatus.ClientID %>').innerHTML = "";
                    //parent.collapsenode();
                    eventArgs.set_cancel(false);
                }
                else
                    if (tab.get_text() == "Details") {
                        <%=ToolBar.ClientID %>_SetEditVisible(false);
                        <%=ToolBar.ClientID %>_SetAddVisible(false);
                        <%=ToolBar.ClientID %>_SetSaveVisible(false);
                        <%=ToolBar.ClientID %>_SetUpdateVisible(false);
                        <%=ToolBar.ClientID %>_SetDeleteVisible(false);
                    }                   
        }
        function clearGrid()
        {
            var view = $find("<%=  dtgCWPDetailGrid.ClientID %>").get_masterTableView();
            view.set_dataSource([]);
            view.dataBind();
        }
        function onClientTabSelected(sender, args) {
           
            var tab = args.get_tab();

            if (tab.get_value() == '2') {
                ClearCWPHeaderTexBox();
                EnableCWPHeaderTextBox();
                parent.collapsenode();
                clearGrid();
                hideMe();
               
                try {                                     
                        <%=ToolBar.ClientID %>_SetEditVisible(false);
                        <%=ToolBar.ClientID %>_SetAddVisible(false);
                        <%=ToolBar.ClientID %>_SetSaveVisible(true);
                        <%=ToolBar.ClientID %>_SetUpdateVisible(false);
                        <%=ToolBar.ClientID %>_SetDeleteVisible(false);
                      
                    }
              catch (x) {
                    alert(x.message);
                }
                
               
            }
            if (tab.get_value() == "1") {
                parent.collapsenode();
                parent.HideTreeNode();
                var tabStrip = $find("<%= RadTabStrip1.ClientID %>");
                var tab = tabStrip.findTabByValue("1");
                tab.select();
                var tab1 = tabStrip.findTabByValue("2");
                tab1.set_text("New");
                tab1.set_imageUrl('../Images/Icons/NewIcon.png');
                parent.RevisionHistroyDeleteNode();
            }

        }
       
        $(document).ready(function () {
            $('.accordion-toggle').on('click', function (event) {

                event.preventDefault();
                OpenDetailAccordion(this);
            });

            //parent.collapsenode();
        });

        function validate()
        {
        
            var docTitle = document.getElementById('<%=txtDocumentTitle.ClientID %>').value;
            var planner = $telerik.findComboBox("<%= radPlanner.ClientID %>").get_text();
            var docDate = document.getElementById('<%=txtdatepicker.ClientID %>').value;
            var remarks = document.getElementById('<%=txtRemarks.ClientID %>').value;
            var revNo = document.getElementById('<%=txtRevisionNo.ClientID %>').value;
            var clientDocNo = document.getElementById('<%=txtClientDocumentNo.ClientID %>').value;
            if (docTitle == "" || planner == "Select Planner" || docDate == "" || remarks == ""||revNo==""||clientDocNo=="") {
                displayMessage(messageType.Error, messages.MandatoryFieldsGeneral);
                return false;
            }
            else {
                return true;
            }
            }
        function validateUpdate()
        {
            return true;
        }
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
            if (id == undefined)//accordion called from code behind scrpt register after CWPHeaderSave
            {
                id = document.getElementById('IDAccordion');
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
    </script>
    <script>
        $(function () {


            $("#datepicker").datepicker({
                autoclose: true,
                clearBtn: true,
                todayHighlight: true,
                pickTime: false,
                format: 'dd-mm-yyyy'
            }).datepicker('update');
            // }).datepicker('update', new Date());;
        });

</script>
</asp:Content>
