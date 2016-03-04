<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="ManageCategory.aspx.cs" Inherits="FlyCn.FlycnSecurity.ManageCategory" %>
<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <script src="../Scripts/jquery-1.8.2.js"></script>

 <asp:ScriptManager ID="scriptmanager1" runat="server"></asp:ScriptManager>
     <div class="importWizardContainer" style="height:500px;">
          <div class="col-md-12">
        <uc1:ToolBar runat="server" ID="ToolBar" /> 
        </div>
          <div style="float:left; width:53%;">
             <div style="margin-left:10px;">
            <asp:Label ID="lblManageCategory" runat="server" Text="Manage Category" CssClass="PageHeading"></asp:Label>
                  </div> 
             <br />
         <div class="col-md-12">
              <div class="col-md-4">
                  <asp:Label ID="lblProject" runat="server" Text="Select Project module"></asp:Label>
                  </div>
             <div class="col-md-8">
                 <asp:DropDownList ID="ddlProjects" runat="server" Width="150px" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlProjects_SelectedIndexChanged">
                       <asp:ListItem Text="--select module--"></asp:ListItem>
                 </asp:DropDownList>
                  </div>
             </div>
               <div style="width: 450px; height: 400px; margin-left:65px;margin-left:25px;">
                <br />
                      <br />
                 <div class="contentTopBar" style="width:450px;"></div>
                <telerik:RadGrid ID="dtgManageCategory" runat="server" AllowPaging="true" Width="100%" Skin="Silk" CssClass="outerMultiPage" AllowSorting="true"  PageSize="7" OnNeedDataSource="dtgManageCategory_NeedDataSource">
                    <HeaderStyle  HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <AlternatingItemStyle HorizontalAlign="Left" />
                    <MasterTableView AutoGenerateColumns="false" ShowHeadersWhenNoRecords="true" ShowHeader="true" DataKeyNames="Category" NoMasterRecordsText="No categories have been added.">
                        <Columns>
                            <telerik:GridBoundColumn HeaderText="CategoryID" DataField="Category" Display="false"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Category" DataField="CategoryDesc" Display="true"></telerik:GridBoundColumn>
                            <telerik:GridCheckBoxColumn HeaderText="Select" DataType="System.Boolean" UniqueName="Modulescheck"></telerik:GridCheckBoxColumn>
                        </Columns>
                    </MasterTableView>

                </telerik:RadGrid>
            </div>
               
             </div>
         <div style="float:right; width:47%; ">
                   <div class="col-md-12"  style="border-left: 1px solid #cfc7c0;min-height:400px">
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
  
             if (project != "--select module--") {
                 return true;
             }
             else {
                 displayMessage(messageType.Error, messages.UserNameNeeded);
                 return false;
             }
         }
         </script>
</asp:Content>
