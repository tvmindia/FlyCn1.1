﻿
<%-- Registration  --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="ApprovalDocument.aspx.cs" Inherits="FlyCn.Approvels.ApprovalDocument" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>
<%-- Registration  --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Input</title>
 <%--    <!-----bootstrap css--->
    <link href="../Content/themes/FlyCnBlue/css/roboto_google_api.css" rel="stylesheet" />
    <link href="Content/themes/FlyCnBlue/css/datepicker.css" rel="stylesheet" type="text/css" />
    <!-----bootstrap css--->
   
    <link href="../Content/themes/FlyCnBlue/css/stylesheet.css" rel="stylesheet" />
    <link href="../Content/themes/FlyCnBlue/css/selectize.css" rel="stylesheet" type="text/css" />
    <link href="../Content/themes/FlyCnBlue/css/accodin.css" rel="stylesheet" type="text/css" />
    <!-----main css--->
    <link href="../Content/themes/FlyCnBlue/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Content/themes/FlyCnRed_Rad/TabStrip.FlyCnRed_Rad.css" rel="stylesheet" />
    <link href="../Content/themes/base/jquery-ui.css" rel="stylesheet" />--%>
    <!-----main css--->
    <!----jquery here jquery 1.11.3.min.js in ifrme has been disabled inorder to work dialog popup here---->
   <%--  <script src="../Content/themes/FlyCnBlue/js/jquery.js"></script>--%>
     <script src="../Scripts/jquery-1.8.2.js"></script>
     <script src="../Scripts/jquery-1.8.2.min.js"></script>
     <script src="../Scripts/jquery-ui-1.8.24.js"></script>
     <script src="../Scripts/jquery-ui-1.8.24.min.js"></script>
    
    <!----jquery---->
     
  </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .ui-dialog-title {
            padding-left: 15em;
            color:maroon;
            font-size:large;
        }

        .ui-dialog-titlebar {
            background: transparent;
            border: none;
        }

        .ui-dialog .ui-dialog-titlebar-close {
            right: 0;
        }

        .ui-dialog {
            box-shadow: 0px 2px 7px #292929;
            -moz-box-shadow: 0px 2px 7px #292929;
            -webkit-box-shadow: 0px 2px 7px #292929;
            border-radius: 15px;
            -moz-border-radius: 15px;
            -webkit-border-radius: 15px;
            background:white;
            z-index: 50;
            /*background:transparent;*/
            /*background: rgba(34,34,34,0.75);*/
            background:white;
            border: 1px solid #fff;
            color:maroon;
        }

        .headings {
            font-family: 'segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            font-size: 15px;
            font-style: normal;
            color: #009933;
        }

        td.myclass {
            text-align: left;
            width: 100px;
        }

        td.size {
            text-align: left;
            width: 200px;
        }

        
        
    </style>
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"> 
    </asp:ScriptManager>

    <div class="container" style="width: 100%">
        <!-----FORM SECTION---->
        <!-----SECTION TABLE---->
          <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" Width="300px" OnClientTabSelected="onClientTabSelected" OnClientTabSelecting="OnClientTabSelecting" CausesValidation="false" SelectedIndex="0" Skin="FlyCnRed_Rad" EnableEmbeddedSkins="false">

            <Tabs>
                <telerik:RadTab Text="Pending" PageViewID="rpList" Value="1" Width="150px" runat="server" ImageUrl="~/Images/Icons/ListIcon.png" Selected="True"></telerik:RadTab>
                <telerik:RadTab Text="Approval" PageViewID="rpApproval" Value="2" Width="150px" runat="server" ImageUrl="~/Images/Icons/NewIcon.png"></telerik:RadTab>
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
                                    <telerik:RadGrid ID="dtgPendingApprovalGrid" runat="server" CellSpacing="0" GridLines="None" AllowPaging="true" AllowAutomaticDeletes="false" OnNeedDataSource="dtgPendingApprovalGrid_NeedDataSource" OnPreRender="dtgPendingApprovalGrid_PreRender" OnItemCommand="dtgPendingApprovalGrid_ItemCommand" OnItemDataBound="dtgPendingApprovalGrid_ItemDataBound" AllowAutomaticUpdates="false"  PageSize="10" Width="100%">
                                        <HeaderStyle  HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <AlternatingItemStyle HorizontalAlign="Left" />
                                        <ClientSettings>
                                            <Selecting AllowRowSelect="true" EnableDragToSelectRows="false" />
                                        </ClientSettings>
                                        <MasterTableView AutoGenerateColumns="False" AllowSorting="true" DataKeyNames="ApprovalID,RevisionID,DocumentID,ProjectNo,DocumentNo,CreatedDate,DocCreatedBy,DocumentType,DocCreatedDate,DocCreatedBy,DocumentOwner,DocumentDate,VerifierLevel,RevisionNo,DocumentTitle">
                                            <Columns>
                                               
                                                <telerik:GridBoundColumn HeaderText="ApprovalID" DataField="ApprovalID" UniqueName="ApprovalID" Display="false"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="RevisionID" DataField="RevisionID" UniqueName="RevisionID" Display="false"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="DocumentID" DataField="DocumentID" UniqueName="DocumentID" Display="false"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Project No" DataField="ProjectNo" UniqueName="ProjectNo" Display="false"></telerik:GridBoundColumn>
                                               
                                                <telerik:GridBoundColumn HeaderText="DocumentNo" DataField="DocumentNo" ItemStyle-Width="15%" UniqueName="DocumentNo"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Revision No" DataField="RevisionNo" ItemStyle-Width="15%" UniqueName="RevisionNo"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Document Type" DataField="DocumentType" ItemStyle-Width="10%" UniqueName="DocumentType"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Document Title" DataField="DocumentTitle" ItemStyle-Width="20%" UniqueName="DocumentTitle"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Closed Date" DataField="CreatedDate" ItemStyle-Width="15%" UniqueName="CreatedDate" DataType="System.DateTime" DataFormatString="{0:dd/MMM/yyyy}"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Level" DataField="VerifierLevel" ItemStyle-Width="10%" UniqueName="VerifierLevel"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Closed By" DataField="CreatedBy" ItemStyle-Width="15%"  UniqueName="CreatedBy"></telerik:GridBoundColumn>
                                                
                                                 <telerik:GridButtonColumn HeaderText="Action" CommandName="Action" ButtonType="ImageButton" ItemStyle-Width="5%" ImageUrl="~/Images/Icons/arrow-right3232.png" Text="Action" UniqueName="Action">
                                                </telerik:GridButtonColumn>
                                                                                         
                                            </Columns>
                                        </MasterTableView>

                                    </telerik:RadGrid>
                            
                        </div>
                        </telerik:RadPageView>

                       <!---End of radpageview list--->

                           <!--Approval page--->
                            <telerik:RadPageView ID="rpApproval" runat="server">
                                 <uc1:ToolBar runat="server" ID="ToolBarApprovalDoc" />

                                <div class="col-md-12 Span-One">

                                     <div class="col-md-6">
                                         <div class="col-md-12 infoBox">
                                            <div class="col-md-12 infoBoxTitle">Document Details</div>
                                               <div class="col-md-12">&nbsp;</div>
                                         <div class="col-md-5">
                                             <asp:Label ID="lblProjectnumber" runat="server" Text="Project No"></asp:Label>
                                         </div>
                                         <div class="col-md-7">
                                               <div class="form-group">
                                                   <asp:Label ID="lblProjectno" runat="server" Text="" Font-Bold="true"></asp:Label>
                                               </div>
                                         </div>


                                         <div class="col-md-5">
                                          <asp:Label ID="lblDocNo" runat="server" Text="Document No"></asp:Label>
                                         </div>
                                         <div class="col-md-7">
                                         <div class="form-group">
                                          <asp:Label ID="lblDocumentNo" runat="server" Text="" Font-Bold="true"></asp:Label>
                                             <asp:HiddenField ID="hiddenFiedldProjectno" runat="server" ClientIDMode="Static"/>
                                             <asp:HiddenField ID="hiddenFieldDocumentID" runat="server" ClientIDMode="Static"/>
                                             <asp:HiddenField ID="hiddenFieldRevisionID" runat="server" ClientIDMode="Static"/>
                                             <asp:HiddenField ID="hiddenFieldApprovalID" runat="server" ClientIDMode="Static" />
                                             <asp:HiddenField ID="hiddenFieldDocumentType" runat="server" ClientIDMode="Static"/>
                                             <asp:HiddenField ID="hiddenFieldDocumentNo" runat="server" ClientIDMode="Static" />
                                             <asp:HiddenField ID="hiddenFieldDocOwner" runat="server" ClientIDMode="Static" />
                                             <asp:HiddenField ID="hiddenFieldRevisionNo" runat="server" ClientIDMode="Static" />
                                             <asp:HiddenField ID="hiddenFieldStatus" runat="server" ClientIDMode="Static" />
                                             <asp:HiddenField ID="hiddenFieldClientDocNo" runat="server" ClientIDMode="Static" />
                                           </div>
                                         </div>
                                         <div class="col-md-5">
                                               <asp:Label ID="lblRevisionNumber" runat="server" Text="Revision No"></asp:Label>
                                         </div>
                                         <div class="col-md-7">
                                            <div class="form-group">
                                                 <asp:Label ID="lblRevisionNo" runat="server" Text="" Font-Bold="true"></asp:Label>
                                            </div>
                                         </div>
                                          <div class="col-md-5">
                                             <asp:Label ID="lblDocumentOwner" runat="server" Text="Document Owner"></asp:Label>
                                         </div>
                                         <div class="col-md-7">
                                             <div class="form-group">
                                                 <asp:Label ID="lblDocOwner" runat="server" Text="" Font-Bold="true"></asp:Label>
                                             </div>
                                         </div>
                                         <div class="col-md-5">
                                             <asp:Label ID="lblDocTitle" runat="server" Text="Document Title"></asp:Label>
                                         </div>
                                         <div class="col-md-7">
                                               <div class="form-group">
                                                   <asp:Label ID="lblDocumentTitle" runat="server" Text="" Font-Bold="true"></asp:Label>
                                               </div>
                                         </div>
                                             <div class="col-md-5">
                                             <asp:Label ID="lblDocType" runat="server" Text="Document Type"></asp:Label>
                                         </div>
                                         <div class="col-md-7">
                                             <div class="form-group">
                                                 <asp:Label ID="lblDocumentType" runat="server" Text="" Font-Bold="true"></asp:Label>
                                             </div>
                                         </div>
                                          <div class="col-md-5">
                                             <asp:Label ID="lblCreDate" runat="server" Text="Created Date"></asp:Label>
                                            </div>
                                            <div class="col-md-7">
                                             <div class="form-group">
                                                 <asp:Label ID="lblCreatedDate" runat="server" Text='<%# Bind("Date", "{0:D}")%>' Font-Bold="true"></asp:Label>
                                             </div>
                                            </div>

                                         <div class="col-md-5">
                                             <asp:Label ID="lblDocDate" runat="server" Text="Document Date"></asp:Label>
                                         </div>
                                         <div class="col-md-7">
                                             <div class="form-group">
                                                 <asp:Label ID="lblDocumentDate" runat="server" Text='<%# Bind("Date", "{0:D}")%>' Font-Bold="true"></asp:Label>
                                             </div>
                                         </div>
                                         <div class="col-md-5">
                                            <asp:Label ID="lblcreated" runat="server" Text="Created By"></asp:Label>
                                        </div>                   
                                         <div class="col-md-7">

                                        <div class="form-group">
                                          <asp:Label ID="lblCreatedBy" runat="server" Text='<%# Bind("Date", "{0:D}")%>' Font-Bold="true"></asp:Label>
                                        </div>
                                          </div>
                                           <div class="col-md-5">
                                           <asp:Label ID="lblCloseddat" runat="server" Text="Closed Date"></asp:Label>
                                           </div>                   
                                           <div class="col-md-7">

                                           <div class="form-group">
                                           <asp:Label ID="lblClosedDate" runat="server" Text='<%# Bind("Date", "{0:D}")%>' Font-Bold="true"></asp:Label>
                                           </div>
                                          </div>
                                     

                                      <div class="col-md-12">
                                         <asp:LinkButton ID="lnkbtnDetail" runat="server" CssClass="DocStatusLabel" OnClick="lnkbtnDetail_Click">Detail</asp:LinkButton>
                                      </div>
                                         <div id="modal_dialog" style="display: none; width: 1200px!important; height: 700px!important;overflow-x:scroll;overflow-y:scroll;">
                                      <iframe id="ContentDocDetails" runat="server" style="width: 1000px; height: 600px;"></iframe>
                                      </div>
                                      </div>
                                  </div>
                                 
                                   <div class="col-md-6">
                                         <div class="col-md-12 infoBox">
                                            <div class="col-md-12 infoBoxTitle"> Approval Details</div>
                                               <div class="col-md-12">&nbsp;</div>
                                        <div class="col-md-12">
                                         <asp:Label ID="lblRemarks" runat="server" Text="Approver Remarks"></asp:Label>
                                        </div>
                                    <div class="col-md-12">
                                    <div class="form-group">
                                     <asp:TextBox ID="txtRemarks" CssClass="form-control" runat="server" TextMode="MultiLine" MaxLength="250"></asp:TextBox>
                                     <asp:Label ID="lblValidationMsg" runat="server" Text=""></asp:Label>
                                     </div>

                                    </div>
                                  
                                    <div class="col-md-12">
                                        <!--Telerik Radlistbox-->
                                        <telerik:RadGrid ID="dtgApprovers" runat="server" CellSpacing="0" GridLines="None" ItemStyle-HorizontalAlign="Center" AlternatingItemStyle-HorizontalAlign="Center"  AllowPaging="true" AllowAutomaticDeletes="false" AllowAutomaticUpdates="false"  PageSize="10" Width="500px" OnNeedDataSource="dtgApprovers_NeedDataSource">
                                        <HeaderStyle  HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <AlternatingItemStyle HorizontalAlign="Left"/>
                                        <ClientSettings>
                                        <Selecting AllowRowSelect="true" EnableDragToSelectRows="false"/>
                                        </ClientSettings>
                                        <MasterTableView AutoGenerateColumns="False">
                                             <Columns>
                                                <telerik:GridBoundColumn HeaderText="ApprovalID" DataField="ApprovalID" UniqueName="ApprovalID" Display="false"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="RevisionID" DataField="RevisionID" UniqueName="RevisionID" Display="false"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Level" DataField="VerifierLevel" ItemStyle-Width="50px" UniqueName="VerifierLevel"></telerik:GridBoundColumn>
												<telerik:GridBoundColumn HeaderText="VerifierEmail" DataField="VerifierEmail" ItemStyle-Width="50px" UniqueName="VerifierEmail"></telerik:GridBoundColumn>
												<telerik:GridBoundColumn HeaderText="StatusDescription" DataField="StatusDescription" ItemStyle-Width="50px" UniqueName="StatusDescription"></telerik:GridBoundColumn>
                                             </Columns>
                                        </MasterTableView>
                                        </telerik:RadGrid>
                                    </div>
                                </div>
                                </div>
                                        
                                    
                                             
                               </div><!--End of col-md-12 span one-->
                           </telerik:RadPageView>
                           <!--End of radApproval page--->
                          </telerik:RadMultiPage>
                    
                  </td>
              </tr>
           </table>
          
             </div><!--end of div contentTopBar--->
        
    </div><!--end of div contentTopBar--->
        
    

<script type="text/javascript">


    function OnClientTabSelecting(sender, eventArgs)
   {
       
        var tab = eventArgs.get_tab();
        if (tab.get_text() == "Approval")
        {
            alert("Please choose one of the actions below! ");
            eventArgs.set_cancel(true);
        }
        if (tab.get_text() == "Pending")
        {
          
            eventArgs.set_cancel(false);
        }
      
      }

       function OpenNewProjectWizard() {
    var docno=document.getElementById('<%=lblDocumentNo.ClientID %>').innerHTML;
            try {
                $("#modal_dialog").dialog({

                    title: "Document Details" +"-"+ docno,
                    width: 1000,
                    height: 400,
                    buttons: {}, modal: true

                });
               return false;
            }
            catch (X) {
                alert(X.message);
            }
       }
     

       function onClientTabSelected(sender, args) {
       
           var tab = args.get_tab();
           if (tab.get_value() == '2')
           {

             
           }
           if (tab.get_value() == "1") {
              
               var tabStrip = $find("<%= RadTabStrip1.ClientID %>");
               var tab = tabStrip.findTabByValue("1");
               tab.select();
           }

       }
  
    function ToolBarVisibility()
    {
        <%=ToolBarApprovalDoc.ClientID %>_SetApproveVisible(true);
        <%=ToolBarApprovalDoc.ClientID %>_SetDeclineVisible(true);
        <%=ToolBarApprovalDoc.ClientID %>_SetRejectVisible(true);
    }
    function validateText() {
       
        var Remarks = document.getElementById('<%=txtRemarks.ClientID %>').value;
        if (Remarks == "") {
            document.getElementById('<%= lblValidationMsg.ClientID %>').innerHTML = 'Please Fill the Remarks...!';
            return false;
        }
        else {
            return true;
        }

    }
    function OnClientButtonClickingApproval(sender, args)
    {
        
        var btn = args.get_item();
       
        if (btn.get_value() == 'Approve')//remarks is not mandatory for approve button
        {
        
            args.set_cancel(false);
         
        }
        if (btn.get_value() == 'Decline')//remarks is mandatory for Decline button
        {
            
            var valbool = validateText();
            args.set_cancel(!valbool);
        }

        if (btn.get_value() == 'Reject')//remarks is mandatory for Reject button
        {
            var valbool = validateText();
            args.set_cancel(!valbool);
        }
    }

</script>
                            
</asp:Content>


