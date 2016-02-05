<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="AssignRoles.aspx.cs" Inherits="FlyCn.FlycnSecurity.AssignRoles" %>

<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        #lblUser
        {
       
        
        }
    </style>
     <script src="../Scripts/jquery-1.8.2.js"></script>
     
    <script type="text/javascript">
        $(document).ready(function () {
            EnableButtonsForNew();
            <%=ToolBar.ClientID %>_hideNotification();

        });
        function EnableButtonsForNew() {

            <%=ToolBar.ClientID %>_SetAddVisible(false);
            <%=ToolBar.ClientID %>_SetSaveVisible(true);
            <%=ToolBar.ClientID %>_SetUpdateVisible(false);
            <%=ToolBar.ClientID %>_SetDeleteVisible(false);

        }

    </script> 

    <asp:ScriptManager ID="scriptmanager1" runat="server"></asp:ScriptManager>



 
    <div class="importWizardContainer" style="height:500px;">
           <div class="col-md-12">
        <uc1:ToolBar runat="server" ID="ToolBar" />
    </div>
        <div style="float: left; width: 53%;">
            <div class="contentTopBar" style="width:700px;"></div>
            <div class="col-md-12">
               
                    <asp:Label ID="lblCurrentRoles" runat="server" Text="Current Roles" CssClass="PageHeading"></asp:Label>
                </div>
                <div>
                 
                        <table>
                            <tr>
                                <td style="width:200px;">
                                    <br />
                    <asp:Label ID="lblUser" runat="server" Text="Select User:" CssClass="control-label col-xs-6"  ></asp:Label>
                       
                   </td><td>
                       <br />
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="150px" AppendDataBoundItems="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Text="--select user--"></asp:ListItem>
                    </asp:DropDownList>
                      </td> </tr>
                      </table>
                </div>

            <div style="width: 450px; height: 400px;">
                <br />
                <telerik:RadGrid ID="dtgCurrentRoles" runat="server" OnNeedDataSource="dtgCurrentRoles_NeedDataSource" AllowPaging="true" PageSize="10">

                    <MasterTableView AutoGenerateColumns="false" ShowHeadersWhenNoRecords="true" ShowHeader="true" DataKeyNames="RoleName,RoleID" NoMasterRecordsText="No Categories have been added.">
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
            <div class="contentTopBar" style="width:500px;"></div>
            <div class="col-md-12" style="border-left: 1px solid #cfc7c0; min-height: 400px">

                <asp:Label ID="lblAssignRoles" runat="server" Text="Assign Roles" CssClass="PageHeading"></asp:Label>

                <br />

               <table style="width: 95%">
                    <tr>
                        <td>
                            <br />
                            <asp:Label ID="lblSelectRole" runat="server" Text="Select Role Type:"></asp:Label></td>
                        <td>
                            <br />
                            <asp:RadioButton ID="RadioButton1" Text="" runat="server" GroupName="roles" /></td>
                        <td><br />Project Roles</td>
                        <td><br />
                            <asp:RadioButton ID="RadioButton2" runat="server" Text="" GroupName="roles" />

                        </td>
                        <td><br />Non-Project Roles</td>
                    </tr>
                   
                </table>
                
             
                <asp:Label ID="Label3" runat="server" Text="Select Project/Level"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="DropDownList2" runat="server" Width="150px" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                    <asp:ListItem Text="--select level--"></asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="DropDownList3" runat="server" Width="150px" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                    <asp:ListItem Text="--select--"></asp:ListItem>
                </asp:DropDownList>
               
                <div style="overflow-x:auto; width: 300px; height: 200px;position:center; position:fixed;left:65% ;top:30%;">
                    <br />
                 
                    <telerik:RadGrid ID="dtgAssignRoles" runat="server" OnNeedDataSource="dtgAssignRoles_NeedDataSource" OnItemCreated="dtgAssignRoles_ItemCreated">

                        <MasterTableView AutoGenerateColumns="false" ShowHeadersWhenNoRecords="true" DataKeyNames="RoleName" ShowHeader="true" NoMasterRecordsText="No Categories have been added.">
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
            debugger;
            EnableButtonsForNew();
            <%=ToolBar.ClientID %>_hideNotification();
            });
            function EnableButtonsForNew() {
                <%=ToolBar.ClientID %>_SetAddVisible(false);
                <%=ToolBar.ClientID %>_SetSaveVisible(true);
                <%=ToolBar.ClientID %>_SetUpdateVisible(false);
                <%=ToolBar.ClientID %>_SetDeleteVisible(false);
            }
        function OnClientButtonClicking(sender, args) {
            debugger;
            var btn = args.get_item();
            if (btn.get_value() == 'Save') {
                args.set_cancel(!validate());
            }
        }
        function validate() {
            return true;
        }
    </script>
</asp:Content>

