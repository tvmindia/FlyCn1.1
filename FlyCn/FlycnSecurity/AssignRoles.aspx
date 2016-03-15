<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="AssignRoles.aspx.cs" Inherits="FlyCn.FlycnSecurity.AssignRoles" %>

<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script src="../Scripts/jquery-1.8.2.js"></script>
     
    <style>
          .selectbox {
            width: 69%;
            background-color: #FFF;
            height:25px;
            font: 400 12px/18px 'Open Sans', sans-serif;
            color: #000;
            font-weight: normal;
            border: 1px solid #ccc;
            margin: 5px 0 0 0;
            padding: 5px;
    </style>

    <asp:ScriptManager ID="scriptmanager1" runat="server"></asp:ScriptManager>

 
    <div class="importWizardContainer" style="height:500px;">
           <div class="col-md-12">
        <uc1:ToolBar runat="server" ID="ToolBar" />
    </div>
        <div style="float: left; width: 53%;">
          
                <div style="margin-left:-8px;">
                 
                        <table>
                            <tr>
                                <td style="width:200px;">
                                    <br />
                    <asp:Label ID="lblUser" runat="server" Text="Select User:" CssClass="control-label col-xs-6"  ></asp:Label>
                       
                   </td><td>
                       <br />
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="150px" CssClass="selectbox" AppendDataBoundItems="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Text="--select user--"></asp:ListItem>
                    </asp:DropDownList>
                      </td> </tr>
                      </table>
                </div>
             <br />
            <div class="col-md-12" style="left:-2%;">
               
                    <asp:Label ID="lblCurrentRoles" runat="server" Text="Current Roles"></asp:Label>
                  <asp:Label ID="lblCurrentRoleDescription" runat="server" Text="" ></asp:Label>
                </div>
            <br />
            <div style="width: 450px; height: 400px;">
                <br />
                 <%--<div class="contentTopBar" style="width:450px;"></div>--%>
                <telerik:RadGrid ID="dtgCurrentRoles" runat="server" OnNeedDataSource="dtgCurrentRoles_NeedDataSource" AllowPaging="true" Width="100%" Skin="Silk" CssClass="outerMultiPage" AllowSorting="true"  PageSize="7">
                    <HeaderStyle  HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <AlternatingItemStyle HorizontalAlign="Left" />
                    <MasterTableView AutoGenerateColumns="false" ShowHeadersWhenNoRecords="true" ShowHeader="true" DataKeyNames="RoleName,RoleID" NoMasterRecordsText="No users have been added.">
                        <Columns>
                            <telerik:GridBoundColumn HeaderText="Role ID" DataField="RoleID" Display="true"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Role Type" DataField="RoleType" Display="true"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Role Name" DataField="RoleName" Display="true"></telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>

                </telerik:RadGrid>
            </div>

        </div>
        <div style="float: right; width: 47%;">
          
            <div class="col-md-12" style="border-left: 1px solid #cfc7c0; min-height: 400px;left:1%;" >
                <div style="margin-left:75px;">
                <asp:Label ID="lblAssignRoles" runat="server" Text="Assign Roles" CssClass="PageHeading"></asp:Label>
                    <br />
                      <br />
                    </div>
                     <div style="margin-left:90px;">
                <asp:Label ID="lblAssignRoleName" runat="server" Text="" ></asp:Label>
                    </div>
                
              
                <br />
                <div style="margin-left:90px;">
                <asp:Label ID="Label3" runat="server" Text="Select Level"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="DropDownList2" runat="server" Width="150px" CssClass="selectbox" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                    <asp:ListItem Text="--select level--"></asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="DropDownList3" runat="server" Width="150px" CssClass="selectbox" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                    <asp:ListItem Text="--select--"></asp:ListItem>
                </asp:DropDownList>
               </div>
                <div style="overflow-x:auto;overflow-x:hidden; width: 300px; height: 200px;position:center; position:fixed;left:68.5% ;top:30%;">
                    <br />
                  <%--<div class="contentTopBar" style="width:420px;"></div>--%>
                    <telerik:RadGrid ID="dtgAssignRoles" runat="server" OnNeedDataSource="dtgAssignRoles_NeedDataSource" AllowPaging="true" Width="100%" Skin="Silk" CssClass="outerMultiPage" AllowSorting="true"  OnItemCreated="dtgAssignRoles_ItemCreated">
                        <HeaderStyle  HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <AlternatingItemStyle HorizontalAlign="Left" />
                        <MasterTableView AutoGenerateColumns="false" ShowHeadersWhenNoRecords="true" DataKeyNames="RoleName" ShowHeader="true" NoMasterRecordsText="No roles have been added.">
                            <Columns>
                                <telerik:GridBoundColumn HeaderText="Role" DataField="RoleName"></telerik:GridBoundColumn>
                                <telerik:GridCheckBoxColumn HeaderText="Select" DataType="System.Boolean" UniqueName="Assignrolescheck"></telerik:GridCheckBoxColumn>
                            </Columns>
                        </MasterTableView>

                    </telerik:RadGrid>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        
        $(document).ready(function () {
            EnableButtonsForNew();
            });
            function EnableButtonsForNew() {
                <%=ToolBar.ClientID %>_SetAddVisible(false);
                <%=ToolBar.ClientID %>_SetSaveVisible(true);
                <%=ToolBar.ClientID %>_SetUpdateVisible(false);
                <%=ToolBar.ClientID %>_SetDeleteVisible(false);
            }
        function OnClientButtonClicking(sender, args) {
            var btn = args.get_item();
            if (btn.get_value() == 'Save') {
                args.set_cancel(!validate());
            }
        }
        function validate() {
            var ddlUser = document.getElementById('<%=DropDownList1.ClientID %>').value;
            ddlUser = trimString(ddlUser);
            var ddlLevel1 = document.getElementById('<%=DropDownList2.ClientID %>').value;
            ddlLevel1 = trimString(ddlLevel1);
            var ddlLevel2 = document.getElementById('<%=DropDownList3.ClientID %>').value;
            ddlLevel2 = trimString(ddlLevel2);
            if (ddlUser != "--select user--") {
                return true;
            }
            else {
                displayMessage(messageType.Error,messages.UserNameNeeded);
                return false;
            }
            if (ddlLevel1 == "--select level--" || ddlLevel2 == "--select--")
            {
                displayMessage(messageType.Error, messages.SelectLevel);
                return false;
            }
            else
            {
                return true;
            }
        }
    </script>
</asp:Content>

