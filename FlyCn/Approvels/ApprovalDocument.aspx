<%-- Registration  --%>
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
     <script src="../Content/themes/FlyCnBlue/js/jquery.min.js"></script>
    <!-----main css--->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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

                                
                            
</asp:Content>


