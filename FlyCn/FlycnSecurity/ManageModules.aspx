<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="ManageModules.aspx.cs" Inherits="FlyCn.FlycnSecurity.ManageModules" %>

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
            height: 25px;
            font: 400 12px/18px 'Open Sans', sans-serif;
            color: #000;
            font-weight: normal;
            border: 1px solid #ccc;
            margin: 5px 0 0 0;
            padding: 5px;
        }
    </style>
    <asp:ScriptManager ID="scriptmanager1" runat="server"></asp:ScriptManager>

     <div class="importWizardContainer" style="height:500px;">
          <div class="col-md-12">
        <uc1:ToolBar runat="server" ID="ToolBar" /> 
        </div>
         <div style="float:left; width:53%;">
             <div style="margin-left:10px;">
            <asp:Label ID="lblManageModules" runat="server" Text="Manage Modules" CssClass="PageHeading"></asp:Label>
                  </div> 
             <br />
         <div class="col-md-12">
              <div class="col-md-4">
                  <asp:Label ID="lblProject" runat="server" Text="Select Project"></asp:Label>
                  </div>
             <div class="col-md-8">
                 <asp:DropDownList ID="ddlProjects" runat="server" Width="150px" CssClass="selectbox" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlProjects_SelectedIndexChanged">
                       <asp:ListItem Text="--select project--"></asp:ListItem>
                 </asp:DropDownList>
                  </div>
             </div>
             </div>

           <div style="float:right; width:47%; ">
                   <div class="col-md-12"  style="border-left: 1px solid #cfc7c0;min-height:400px">
                     <div style="width: 450px; height: 400px; margin-left:65px;">
                <br />
                      
                 <div class="contentTopBar" style="width:450px;"></div>
                <telerik:RadGrid ID="dtgManageModules" runat="server" AllowPaging="true" OnNeedDataSource="dtgManageModules_NeedDataSource" Width="100%" Skin="Silk" CssClass="outerMultiPage" AllowSorting="true"  PageSize="7" OnItemCreated="dtgManageModules_ItemCreated">
                    <HeaderStyle  HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <AlternatingItemStyle HorizontalAlign="Left" />
                    <MasterTableView AutoGenerateColumns="false" ShowHeadersWhenNoRecords="true" ShowHeader="true" DataKeyNames="ModuleID" NoMasterRecordsText="No modules have been added.">
                        <Columns>
                            <telerik:GridBoundColumn HeaderText="ModuleID" DataField="ModuleID" Display="false"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Module" DataField="ModuleDesc" Display="true"></telerik:GridBoundColumn>
                            <telerik:GridCheckBoxColumn HeaderText="Select" DataType="System.Boolean" UniqueName="Modulescheck"></telerik:GridCheckBoxColumn>
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
             var project = document.getElementById('<%=ddlProjects.ClientID %>').value;
             project = trimString(project);
  
             if (project != "--select project--") {
                 return true;
             }
             else {
                 displayMessage(messageType.Error, messages.UserNameNeeded);
                 return false;
             }
         }
         </script>
</asp:Content>
