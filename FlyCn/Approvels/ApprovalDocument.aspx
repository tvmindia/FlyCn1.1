﻿<%-- Registration  --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="ApprovalDocument.aspx.cs" Inherits="FlyCn.Approvels.ApprovalDocument" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%-- Registration  --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Input</title>
     <!-----bootstrap css--->
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
    <link href="../Content/themes/base/jquery-ui.css" rel="stylesheet" />
    <!-----main css--->
    <!----jquery here jquery 1.11.3.min.js in ifrme has been disabled inorder to work dialog popup here---->
     <script src="../Content/themes/FlyCnBlue/js/jquery.js"></script>
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
            color: white;
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
            background: #f2f2f2;
            z-index: 50;
            /*background:transparent;*/
            /*background: rgba(34,34,34,0.75);*/
            background: rgba(36,85,99,.9);
            border: 1px solid #fff;
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
        <div id="content">
            <div class="contentTopBar"></div>
            <table style="width: 100%">
                <tr>
                  <td>
                        <div id="divList" style="width: 100%;text-align:center">
                                    <telerik:RadGrid ID="dtgPendingApprovalGrid" runat="server" CellSpacing="0" GridLines="None" AllowPaging="true" AllowAutomaticDeletes="false" OnNeedDataSource="dtgPendingApprovalGrid_NeedDataSource" OnPreRender="dtgPendingApprovalGrid_PreRender" OnItemCommand="dtgPendingApprovalGrid_ItemCommand" AllowAutomaticUpdates="false"  PageSize="10" Width="100%">
                                        <HeaderStyle  HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <AlternatingItemStyle HorizontalAlign="Left" />
                                        <ClientSettings>
                                            <Selecting AllowRowSelect="true" EnableDragToSelectRows="false" />
                                        </ClientSettings>
                                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="ApprovalID,RevisionID,DocumentID,ProjectNo">
                                            <Columns>
                                               
                                                <telerik:GridBoundColumn HeaderText="ApprovalID" DataField="ApprovalID" UniqueName="ApprovalID" Display="false"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="RevisionID" DataField="RevisionID" UniqueName="RevisionID" Display="false"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="DocumentID" DataField="DocumentID" UniqueName="DocumentID" Display="false"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Project No" DataField="ProjectNo" UniqueName="ProjectNo" Display="false"></telerik:GridBoundColumn>
                                               
                                                <telerik:GridBoundColumn HeaderText="DocumentNo" DataField="DocumentNo" ItemStyle-Width="30%" UniqueName="DocumentNo"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Date" DataField="CreatedDate" ItemStyle-Width="30%" UniqueName="CreatedDate" DataType="System.DateTime" DataFormatString="{0:dd/MMM/yyyy}"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Sent By" DataField="CreatedBy" ItemStyle-Width="30%"  UniqueName="CreatedBy"></telerik:GridBoundColumn>

                                                 <telerik:GridButtonColumn HeaderText="Action" CommandName="Action" ButtonType="ImageButton" ItemStyle-Width="5%" ImageUrl="~/Images/Icons/arrow-right3232.png" Text="Action" UniqueName="Action">
                                                </telerik:GridButtonColumn>
                                                <telerik:GridButtonColumn HeaderText="Details" CommandName="Details" ButtonType="ImageButton" ItemStyle-Width="5%" ImageUrl="~/Images/Icons/mail3232.png" Text="Details" UniqueName="Details">
                                                </telerik:GridButtonColumn>
                                          
                                            </Columns>
                                        </MasterTableView>

                                    </telerik:RadGrid>
                                </div>
                             </td>
                            </tr>
            </table>
        </div>
        </div>
             <div id="modal_dialog" style="display: none; width: 1000px!important; height: 700px!important; overflow: hidden; overflow-x: hidden;">
                <iframe src="ApprovalScreen.aspx" style="width: 1300px; height: 700px;"></iframe>
             </div>

<script type="text/javascript">

       function OpenNewProjectWizard() {
            try {
                $("#modal_dialog").dialog({

                    title: "Approval Screen",
                    width: 780,
                    height: 700,
                    buttons: {}, modal: true

                });
               return false;
            }
            catch (X) {
                alert(X.message);
            }
       }  
</script>
                            
</asp:Content>


