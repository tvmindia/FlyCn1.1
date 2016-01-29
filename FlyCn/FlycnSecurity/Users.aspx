<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="FlyCn.FlycnSecurity.Users" %>
<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
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
    <asp:ScriptManager ID="scriptmanager2" runat="server"></asp:ScriptManager>

          <div id="Heading" runat="server" style="width: 90%; text-align: center; margin: 20px">
        <ul class="list-inline" id="horizonaltab" runat="server" style="width: 100%;">
            <li style="width: 10px;"></li>
                
        </ul>
    </div>
    
    
    <div class="col-md-12">
        <uc1:ToolBar runat="server" ID="ToolBar" /> 
        </div>
     <div class="importWizardContainer" style="height:500px;">
        
          <div style="float:left; width:53%;">
                
                   <div class="col-md-12">
                         
                           <asp:Label ID="ManageExisting" runat="server" Text="Manage Existing" CssClass="PageHeading"></asp:Label>
                           <br />
                       <br />
                         <div style="width:550px;">
                     <telerik:RadGrid ID="dtgManageExisting" runat="server" OnNeedDataSource="dtgManageExisting_NeedDataSource">

                    <MasterTableView  AutoGenerateColumns="false" ShowHeadersWhenNoRecords="true" ShowHeader="true" NoMasterRecordsText="No Categories have been added.">
                         <Columns>
                              <telerik:GridBoundColumn HeaderText="Login Name" Display="true"></telerik:GridBoundColumn>
                              <telerik:GridBoundColumn HeaderText="Full Name" Display="true"></telerik:GridBoundColumn>
                              <telerik:GridBoundColumn HeaderText="Email" Display="true"></telerik:GridBoundColumn>
                              <telerik:GridBoundColumn HeaderText="Active" Display="true"></telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>

                </telerik:RadGrid>
                </div>
                     
               </div>
         </div>
          <div style="float:right; width:47%; ">
            <div class="col-md-12"  style="border-left: 1px solid #cfc7c0;min-height:400px">
               
            <asp:Label ID="lblCreateNew" runat="server" Text="Create New" CssClass="PageHeading"></asp:Label>
                   
                <br />
                <br />
                <div class="col-md-12 Span-One">
               <div class="form-group required">
                   
                       <asp:Label ID="lblLoginName" runat="server" CssClass="control-label col-md-6 "  Text="Login Name"></asp:Label>
                      
                    <div class="col-md-6">
                        <asp:TextBox ID="txtLoginName" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvloginName" runat="server" ErrorMessage="Enter Login Name"
                                    Display="Dynamic" SetFocusOnError="true"
                                    ForeColor="Red"
                                    ValidationGroup="Group"
                                    ControlToValidate="txtLoginName">
                                </asp:RequiredFieldValidator>
                        </div>
                   </div>
               </div>
                 <div class="col-md-12 Span-One">
                 <div class="form-group required">
                     
                    <asp:Label ID="lblFullName" runat="server" CssClass="control-label col-md-6 "  Text="Full Name"></asp:Label>
                        
                      <div class="col-md-6">
                       <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="rfvFullName" runat="server" ErrorMessage="Enter Full Name"
                                    Display="Dynamic" SetFocusOnError="true"
                                    ForeColor="Red"
                                    ValidationGroup="Group"
                                    ControlToValidate="txtFullName">
                                </asp:RequiredFieldValidator>
                          </div>
                     </div>
                     </div>
                 <div class="col-md-12 Span-One">
                 <div class="form-group required">
                     
                   <asp:Label ID="lblPassword" runat="server" CssClass="control-label col-md-6 "  Text="Password"></asp:Label>
                         
                      <div class="col-md-6">
                        <asp:TextBox Id-="txtPassword" runat="server" CssClass="form-control"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Enter Password"
                                    Display="Dynamic" SetFocusOnError="true"
                                    ForeColor="Red"
                                    ValidationGroup="Group"
                                    ControlToValidate="txtPassword">
                                </asp:RequiredFieldValidator>
                          </div>
                     </div>
                     </div>
                 <div class="col-md-12 Span-One">
                 <div class="form-group required">
                      
                  <asp:Label ID="lblConfirmPassword" runat="server" CssClass="control-label col-md-6 "  Text="Confirm Password"></asp:Label>
                        
                      <div class="col-md-6">
                       <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ErrorMessage="Enter Confirm Password"
                                    Display="Dynamic" SetFocusOnError="true"
                                    ForeColor="Red"
                                    ValidationGroup="Group"
                                    ControlToValidate="txtConfirmPassword">
                                </asp:RequiredFieldValidator>
                          </div>
                     </div>
                     </div>
                 <div class="col-md-12 Span-One">
                 <div class="form-group required">
                     
                   <asp:Label ID="lblEmail" runat="server" CssClass="control-label col-md-6 "  Text="Email"></asp:Label>
                          
                      <div class="col-md-6">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Enter Email"
                                    Display="Dynamic" SetFocusOnError="true"
                                    ForeColor="Red"
                                    ValidationGroup="Group"
                                    ControlToValidate="txtEmail">
                                </asp:RequiredFieldValidator>
                          </div>
                     </div>
                   </div>
                 <div class="col-md-12 Span-One">
                 <div class="form-group required">
                     
                        <asp:Label ID="lblActive" runat="server" CssClass="control-label col-md-6 "  Text="Active"></asp:Label>
                         
                      <div class="col-md-6">
                        <asp:TextBox ID="txtActive" runat="server" CssClass="form-control"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="rfvActive" runat="server" ErrorMessage="Enter Active"
                                    Display="Dynamic" SetFocusOnError="true"
                                    ForeColor="Red"
                                    ValidationGroup="Group"
                                    ControlToValidate="txtActive">
                                </asp:RequiredFieldValidator>
                          </div>
                   </div>
                     </div>
                
         </div>
              </div>
              </div>
</asp:Content>
