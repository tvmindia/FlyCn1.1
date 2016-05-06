<%-- Registration  --%>

<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="BOQHeader.aspx.cs" Inherits="FlyCn.BOQ.BOQHeader" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>
<%--<%@ Register Src="~/UserControls/GridviewFilter.ascx" TagPrefix="uc1" TagName="GridviewFilter" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%-- Registration--%>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Input</title>
     <%--<script src="../Content/themes/FlyCnBlue/js/jquery.min.js"></script>--%>
     <script src="../Scripts/jquery-1.8.2.js"></script>
     <script src="../Scripts/jquery-1.8.2.min.js"></script>
     <script src="../Scripts/jquery-ui-1.8.24.js"></script>
     <script src="../Scripts/jquery-ui-1.8.24.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
         html {width:100%; height:100%; overflow:auto; }
    </style>
       <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePartialRendering="true" EnablePageMethods="true"  >
       
    </asp:ScriptManager>
     <script>
         $(document).ready(function () {
             GetWebCount();
            
         });
          
         function GetWebCount() {
             var RevID = document.getElementById("hiddenFieldRevisionID").value;
             PageMethods.GetAttachmentCount(RevID, OnSuccess, onError);
             function OnSuccess(response, userContext, methodName) {
                 <%=ToolBar.ClientID %>_InvokeCountWebMethod(response);
             }
             function onError(response, userContext, methodName) {
                
             }
         }
</script>
 

    <script src="../Scripts/ToolBar.js"></script>
    <script src="../Scripts/Messages.js"></script>
     
     
   <%--  <uc1:GridviewFilter runat="server" ID="GridviewFilter" tableName="vBOQDocumentHeader" />--%>
         <%--<asp:UpdatePanel ID="upGrid" runat="server" UpdateMode="Always" >
                <ContentTemplate>   --%>     
   
    <div class="container" style="width: 100%">
     
        <!-----FORM SECTION---->
        <!-----SECTION TABLE---->
        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" Width="200px" OnClientTabSelected="onClientTabSelected" OnClientTabSelecting="OnClientTabSelecting"
            CausesValidation="false" SelectedIndex="0" Skin="FlyCnRed_Rad" EnableEmbeddedSkins="false"  >

            <Tabs>
                <telerik:RadTab Text="View" PageViewID="rpList" Value="1" Width="100px" Height="25px" runat="server" ImageUrl="~/Images/Icons/ListIcon.png" Selected="True"></telerik:RadTab>
                <telerik:RadTab Text="New" PageViewID="rpAddEdit" Value="2" Width="100px"  Height="25px" runat="server" ImageUrl="~/Images/Icons/NewIcon.png"></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <div id="content">


            <div class="contentTopBar"></div>

           
            <table style="width: 100%">
                <tr>
                     
                    <td>

                        <telerik:RadMultiPage ID="RadMultiPage1" runat="server" Width="100%" SelectedIndex="0" CssClass="outerMultiPage">
                            <telerik:RadPageView ID="rpList" runat="server">

                                <div id="divList" style="width: 100%;text-align:center">
                                  <%--  <asp:Label ID="lblresultReturned" runat="server" Text="Label"></asp:Label>--%>

                            
                              
                                    <telerik:RadGrid ID="dtgBOQGrid" runat="server" CellSpacing="0" GridLines="None" OnNeedDataSource="dtgBOQGrid_NeedDataSource" AllowPaging="true" AllowAutomaticDeletes="false" AllowAutomaticUpdates="false" OnItemCommand="dtgBOQGrid_ItemCommand"
                                        PageSize="10" Width="99%"  >
                                        <HeaderStyle  HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <AlternatingItemStyle HorizontalAlign="Left" />
                                        <ClientSettings>
                                            <Selecting AllowRowSelect="true" EnableDragToSelectRows="false" />
                                       
                                        </ClientSettings>
                                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="DocumentID,ProjectNo,RevisionID" AllowSorting="true">
                                            <Columns>
                                                <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="ChkChild" runat="server" onclick="HeaderUncheck(this);" AutoPostBack="False" />
                                                    </ItemTemplate>
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="Chkheader" runat="server" onclick="Check(this);" AutoPostBack="False" />
                                                    </HeaderTemplate>
                                                </telerik:GridTemplateColumn>

                                                <telerik:GridButtonColumn CommandName="EditDoc" ButtonType="ImageButton" ImageUrl="~/Images/Icons/Pencil-01.png" Text="Edit" UniqueName="EditData">
                                                </telerik:GridButtonColumn>
                                                 <telerik:GridButtonColumn CommandName="ViewDetailColumn" Text="ViewDetails" UniqueName="ViewDetailColumn"  ButtonType="ImageButton" Display="false" ImageUrl="~/Images/Document Next-WF.png"  ></telerik:GridButtonColumn>
                                                <telerik:GridBoundColumn HeaderText="Project No" DataField="ProjectNo" UniqueName="ProjectNo" Display="false"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="DocumentID" DataField="DocumentID" UniqueName="DocumentID" Display="false"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="RevisionID" DataField="RevisionID" UniqueName="RevisionID" Display="false"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Document No" DataField="DocumentNo" UniqueName="DocumentNo"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Title" DataField="DocumentTitle" UniqueName="DocumentTitle"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Client Doc No" DataField="ClientDocNo" UniqueName="ClientDocNo"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Revision No" DataField="RevisionNo" UniqueName="RevisionNo"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Document Date" DataField="DocumentDate" UniqueName="DocumentDate" DataType="System.DateTime" DataFormatString="{0:dd/MMM/yyyy}"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Document Owner" DataField="DocumentOwner" UniqueName="DocumentOwner"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Created Date" DataField="CreatedDate" UniqueName="CreatedDate" DataType="System.DateTime" DataFormatString="{0:dd/MMM/yyyy}"></telerik:GridBoundColumn>
                                                 <telerik:GridBoundColumn HeaderText="Revision Date" DataField="RevisionDate" UniqueName="RevisionDate" DataType="System.DateTime" DataFormatString="{0:dd/MMM/yyyy}"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Document Status" DataField="DocumentStatus" UniqueName="DocumentStatus"></telerik:GridBoundColumn>
                                            </Columns>
                                        </MasterTableView>

                                    </telerik:RadGrid>

                        
     <%--                                            <Triggers>
    <asp:AsyncPostBackTrigger ControlID="dtgBOQGrid" EventName="ItemCommand" />
</Triggers>--%>
                     
                                </div>
                            </telerik:RadPageView>
                             <!-----SECTION TABLE---->
                             <!---SECTION ONE--->
                                
                            <telerik:RadPageView ID="rpAddEdit" runat="server">

                                
                                <uc1:ToolBar runat="server" ID="ToolBar" />

                                <div class="col-md-12 Span-One">
                                  
                                    <div class="col-md-6">

                                        <div class="form-group">

                                            <asp:Label ID="lblDocumentno" CssClass="control-label col-md-5" runat="server" Text="Document No"></asp:Label>
                                            <div class="col-md-7">

                                                <asp:TextBox ID="txtDocumentno" Enabled="false" runat="server" CssClass="form-control AutoGenTextbox"  ClientIDMode="Static"></asp:TextBox>
                                                <asp:HiddenField ID="hiddenFiedldProjectno" runat="server" ClientIDMode="Static"/>
                                                <asp:HiddenField ID="hiddenFieldDocumentID" runat="server" ClientIDMode="Static"/>
                                                <asp:HiddenField ID="hiddenFieldRevisionID" runat="server" ClientIDMode="Static"/>
                                                <asp:HiddenField ID="hdfEditStatus" runat="server" ClientIDMode="Static" />
                                                <asp:HiddenField ID="hiddenFieldDocumentType" runat="server" ClientIDMode="Static" />
                                                <asp:HiddenField ID="hiddenDocumentOwner" runat="server" ClientIDMode="Static" />
                                                <asp:HiddenField ID="hiddenUsername" runat="server" ClientIDMode="Static" />
                                                <asp:HiddenField ID="hiddenRevisionNumber" runat="server" ClientIDMode="Static" />
                                                <asp:HiddenField ID="hiddenStatusValue" runat="server" ClientIDMode="Static" />
                                                <asp:HiddenField ID="hiddenDocumentNo" runat="server" ClientIDMode="Static" />
                                                <asp:HiddenField ID="HiddenRevisionIdCollection" runat="server" ClientIDMode="Static" />
                                                <asp:HiddenField ID="hiddendocumentDate" runat="server" ClientIDMode="Static" />
                                                <asp:HiddenField ID="HiddenTabStatus" runat="server" ClientIDMode="Static" />
                                           
                                                 </div>
                                        </div>

                                    </div>

                                    <div class="col-md-6">

                                        <div class="form-group">
                                            <asp:Label ID="lblDocOwner" CssClass="control-label col-md-5" runat="server" Text="Document Owner"></asp:Label>   
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtDocOwner" Enabled="false" CssClass="form-control AutoGenTextbox" ClientIDMode="Static" runat="server"></asp:TextBox>
                                              
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-6">

                                        <div class="form-group">
                                            <asp:Label ID="lblClientdocumentnot" CssClass="control-label col-md-5" runat="server" Text="Client Document No"></asp:Label>   
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtClientdocumentno" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                                              
                                            </div>
                                        </div>
                                    </div>
                                
                                <!---SECTION ONE--->

                                <!---SECTION TWO--->
                               
                                    <div class="col-md-6">
                                     <div class="form-group required">
                                        <asp:Label ID="lblRevisionno" CssClass="control-label col-md-5" runat="server" Text="Revision No"></asp:Label> 
                                           <div class="col-md-7">
                                               <asp:TextBox ID="txtRevisionno" CssClass="form-control" runat="server" MaxLength="10"></asp:TextBox>
                                           </div>
                                         
                                        </div>
                                     </div>
                                  

                                    <div class="col-md-6">

                                        <div class="form-group required">

                                          <asp:Label ID="lblDocumentdate" CssClass="control-label col-md-5" runat="server" Text="Document Date"></asp:Label> 
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

                                            <asp:Label ID="lblDocumenttitle" CssClass="control-label col-md-5" runat="server" Text="Document Title"></asp:Label> 
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtDocumenttitle" CssClass="form-control" runat="server" MaxLength="250"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-6">

                                        <div class="form-group required">


                                            <asp:Label ID="lblRemarks" CssClass="control-label col-md-5" runat="server" Text="Remarks"></asp:Label> 
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtRemarks" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                    </div>
                                   
                                    
                                </div>
                              
                                <div class="col-md-12">
                                     <div class="col-md-6">&nbsp;</div>
                                     <div class="col-md-6">&nbsp;</div>
                                      <div class="col-md-6"></div>
                                      <div class="col-md-6">
                                       
                                         <div class="col-md-7">
                                             <asp:Label ID="lblDocumentStatus" CssClass="DocStatusLabel" runat="server"    ClientIDMode="Static"></asp:Label>
                                         </div>
                                         
                                         
                                       <div id="modal_dialog" style="display: none; width: 1200px!important; height: 700px!important;overflow-x:hidden;overflow-y:hidden;">
                                      <iframe id="ContentApprovers" runat="server" style="width: 1000px; height: 600px;"></iframe>
                                      </div>
                                    </div>
                                     <div class="content white">
                                       <div class="accordion-container">
                                         <a href="#" class="accordion-toggle" id="IDAccordion">Details<span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>
                                         <div class="accordion-content">
                                         <iframe id="ContentIframe" name="BOQDetails" style="height: 500px; width: 100%; overflow: hidden;" runat="server"></iframe>
                                         </div>
                                       </div>
                                      </div>
                                    </div>
                                <!---SECTION TWO--->

                            </telerik:RadPageView>

                        </telerik:RadMultiPage>
                         
                    </td>
                </tr>
            </table>

 
              
        
        </div>
        </div>
  <%--</ContentTemplate>
                                </asp:UpdatePanel>--%>
      
        <!-----FORM SECTION---->
    

    <!--<JavaScrict>-->
    <script type="text/javascript">

        function AttachFunction()
        {
            parent.AttachmentlinkClick('BOQHeader')
        }

        function validate()
        {
            var Clientdocumentno = document.getElementById('<%=txtClientdocumentno.ClientID %>').value;
          
            var Revisionno = document.getElementById('<%=txtRevisionno.ClientID %>').value;
            Revisionno = trimString(Revisionno);
            var DocumentDate = document.getElementById('<%=txtdatepicker.ClientID %>').value;
            DocumentDate = trimString(DocumentDate);
            var Documenttitle = document.getElementById('<%=txtDocumenttitle.ClientID %>').value;
            Documenttitle = trimString(Documenttitle);
            var Remarks = document.getElementById('<%=txtRemarks.ClientID%>').value;
            Remarks = trimString(Remarks);
            if (Revisionno == "" || DocumentDate == "" || Documenttitle == "" || Remarks == "") {

            displayMessage(messageType.Error, messages.MandatoryFieldsGeneral);
            return false;
        }
        else {
            return true;
        }
    }

    function HeaderUncheck(obj) {
        var IsChecked = obj.checked;
        if (!IsChecked) {
            var chkBox = $('input[id$="Chkheader"]');
            chkBox[0].checked = false;
        }

    }
    function Check(obj) {

        var IsChecked = obj.checked;
        var grid = $find("<%=dtgBOQGrid.ClientID %>");
        var MasterTable = grid.get_masterTableView();
        var Rows = MasterTable.get_dataItems();
        if (IsChecked == true) {
            for (var i = 0; i < Rows.length; i++) {
                MasterTable.get_dataItems()[i].findElement("ChkChild").checked = true;
            }
        }

        if (IsChecked == false) {
            for (var i = 0; i < Rows.length; i++) {
                MasterTable.get_dataItems()[i].findElement("ChkChild").checked = false;
            }
        }
    }

        function OnClientTabSelecting(sender, eventArgs) {

            debugger;

            var tab = eventArgs.get_tab();
            
            var security = document.getElementById("hdnSecurityMaster").value;
            var user = document.getElementById('<%=hiddenUsername.ClientID%>');
            var owner = document.getElementById('<%=hiddenDocumentOwner.ClientID%>');
          
            PageSecurityCheck(security);
            if (PageSecurity.isWriteOnly) {
                if (tab.get_text() == "New") {

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
            else
                if (PageSecurity.isReadOnly) {
                    if (tab.get_text() == "New") {
                        
                        AlertMsg(messages.EditModeNewClick);

                        eventArgs.set_cancel(true);
                    }
                    else 
                        if (tab.get_text() == "Details")
                        {
                             <%=ToolBar.ClientID %>_SetEditVisible(false);
                            <%=ToolBar.ClientID %>_SetAddVisible(false);
                            <%=ToolBar.ClientID %>_SetSaveVisible(false);
                            <%=ToolBar.ClientID %>_SetUpdateVisible(false);
                            <%=ToolBar.ClientID %>_SetDeleteVisible(false);
                              <%=ToolBar.ClientID %>_SetAttachVisible(false);
                        }
                   
                }
                else if (PageSecurity.isEditOnly) {
                    if (tab.get_text() == "New") {
                      
                        AlertMsg(messages.EditModeNewClick);
                        eventArgs.set_cancel(true);
                    }
                    else 
                        if (tab.get_text() == "Details") {
                            <%=ToolBar.ClientID %>_SetEditVisible(false);
                            <%=ToolBar.ClientID %>_SetAddVisible(false);
                            <%=ToolBar.ClientID %>_SetSaveVisible(false);
                            <%=ToolBar.ClientID %>_SetUpdateVisible(false);
                            <%=ToolBar.ClientID %>_SetDeleteVisible(false);
                              <%=ToolBar.ClientID %>_SetAttachVisible(false);
                        }
                }



        }
       <%-- function hideNofificationCount()
        {
            debugger;
            <%=ToolBar.ClientID %>_hideNotification();
}--%>
        
        function onClientTabSelected(sender, args) {
           
        var tab = args.get_tab();

        if (tab.get_value() == '2')
        {
            
             parent.HideTreeNode();
            
            //var txtCont = Page.Master.Master.FindControl("rtvLeftMenu").ClientID ;
            //alert(txtCont);
            <%--document.getElementById('<%=hdnPostbackOnItemCommand.ClientID %>').value = "1";--%>
            hideMe();
           <%-- var hiddenPostBack = document.getElementById('<%=GridviewFilter.FindControl("hdnPostbackOnItemCommand").ClientID %>');
            var hiddenPostBackValue = hiddenPostBack.value();
            hiddenPostBackValue = "View";--%>

          //Clear Text boxes When New tab clicks
            ClearBOQHeaderTexBox();
         //Clear Text boxes When New tab clicks
          try {
          var security = document.getElementById("hdnSecurityMaster").value;
          PageSecurityCheck(security);
        
            if ((PageSecurity.isWriteOnly)) {

                <%=ToolBar.ClientID %>_SetEditVisible(false);
                <%=ToolBar.ClientID %>_SetAddVisible(false);
                <%=ToolBar.ClientID %>_SetSaveVisible(true);
                <%=ToolBar.ClientID %>_SetUpdateVisible(false);
                <%=ToolBar.ClientID %>_SetDeleteVisible(false);
                <%=ToolBar.ClientID %>_SetAttachVisible(false);
}
          
       
            if((PageSecurity.isReadOnly))
            {
             
                <%=ToolBar.ClientID %>_SetEditVisible(false);
                <%=ToolBar.ClientID %>_SetAddVisible(false);
                <%=ToolBar.ClientID %>_SetSaveVisible(false);
                <%=ToolBar.ClientID %>_SetUpdateVisible(false);
                <%=ToolBar.ClientID %>_SetDeleteVisible(false);
                <%=ToolBar.ClientID %>_SetAttachVisible(false);
            }
              }
            catch (x)
            {
                alert(x.message);
            }
            //here only one textbox is checked for readonly true
            if (document.getElementById('<%=txtClientdocumentno.ClientID %>').readOnly == true)
            {
                //here the readonly text box will be set to false inorder to enter new Boqheader
                EnableBOQHeaderTextBox();//remove readonly property from the text boxes
                v1 = document.getElementById('<%=ContentIframe.ClientID %>');
                v1.style["display"] = "none";//disabling iframe
               
            }
            if ($('#hdfEditStatus').val() == "GridEdit")//here gridedit value is set upon the grid edit event code behind code
            {//this checking determines update is from gridedit so when user clicks on new tab the child iframe should clear
                
                v1 = document.getElementById('<%=ContentIframe.ClientID %>');
                v1.style["display"] = "none";//disabling iframe
             
            }
         }
            if (tab.get_value() == "1")

            {
                parent.collapsenode();
                parent.HideTreeNode();
                document.getElementById('<%=HiddenTabStatus.ClientID %>').value="1";             
                var tabStrip = $find("<%= RadTabStrip1.ClientID %>");
                var tab = tabStrip.findTabByValue("1");
                tab.select();
                var tab1 = tabStrip.findTabByValue("2");
                tab1.set_text("New");
                tab1.set_imageUrl('../Images/Icons/NewIcon.png');            
                parent.RevisionHistroyDeleteNode();               
            }

         }
        function ClearBOQHeaderTexBox()
        {
           
            document.getElementById('<%=txtDocumentno.ClientID %>').value = "------System Generated Code------";
            document.getElementById('<%=txtDocOwner.ClientID%>').value = "-------Document Owner-------";
            document.getElementById('<%=txtClientdocumentno.ClientID %>').value = "";
            document.getElementById('<%=txtRevisionno.ClientID %>').value = "";
            $('#datepicker').datepicker('update', '');
            document.getElementById('<%=txtDocumenttitle.ClientID %>').value = "";
            document.getElementById('<%=txtRemarks.ClientID %>').value = "";
            document.getElementById('<%=lblDocumentStatus.ClientID%>').innerHTML = "";
        }
      
        
        function OnClientButtonClicking(sender, args) {
        var btn = args.get_item();
        if (btn.get_value() == 'Save') {
           
            args.set_cancel(!validate());
           
            
        }
        if (btn.get_value() == 'Update') {
            try {

            parent.RevisionHistroyDeleteNode();

            args.set_cancel(!validate());
            } catch (X) { alert(x)}
            
        }

        if (btn.get_value() == 'Edit') {

           
        }

        if (btn.get_value() == 'Attach') {
            AttachFunction();
            args.set_cancel(true);


        }

    }



    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.accordion-toggle').on('click', function (event) {

                event.preventDefault();          
                OpenDetailAccordion(this);
            });

         

        });


        function OpenDetailAccordion(id)
        {
            
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
            if(id==undefined)//accordion called from code behind scrpt register after BoqHeaderSave
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
        function DisableBOQHeaderTextBox()
        {
       
            var v1 = document.getElementById('<%=txtdatepicker.ClientID %>');
            //v1.setAttribute("readonly", "readonly");
            v1 = document.getElementById('<%=txtClientdocumentno.ClientID %>');
            v1.setAttribute("readonly", "readonly");
            v1 = document.getElementById('<%=txtRevisionno.ClientID %>');
            v1.setAttribute("readonly", "readonly");
            v1 = document.getElementById('<%=txtDocumenttitle.ClientID %>');
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
        function EnableBOQHeaderTextBox()
        {
           
            //Enable header textboxess
            var e = document.getElementById('<%=txtClientdocumentno.ClientID %>');
            e.removeAttribute("readonly", 0);
            e = document.getElementById('<%=txtRevisionno.ClientID %>');
            e.removeAttribute("readonly", 0);
            e = document.getElementById('<%=txtdatepicker.ClientID %>');
            e.removeAttribute("readonly", 0);
            e = document.getElementById('<%=txtDocumenttitle.ClientID %>');
            e.removeAttribute("readonly", 0);
            e = document.getElementById('<%=txtRemarks.ClientID %>');
            e.removeAttribute("readonly", 0);
            //Enable header textboxess

        }

       
     


    </script>
    <!--<JavaScrict ends here>-->

        <!-----bootstrap js---> 

<script>
    $(function () {
      

        $("#datepicker").datepicker({
            autoclose: true,
            clearBtn:true,
            todayHighlight: true,
            pickTime: false,
            format: 'dd-mm-yyyy'
        }).datepicker('update');
       // }).datepicker('update', new Date());;
    });

</script> 


<!-----bootstrap js--->

</asp:Content>































