<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="ManageCategory.aspx.cs" Inherits="FlyCn.FlycnSecurity.ManageCategory" %>
<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <script src="../Scripts/jquery-1.8.2.js"></script>
    <script src="../Scripts/Messages.js"></script>
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
        }
    </style>
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
              <div class="col-md-3">
                  <asp:Label ID="lblProject" runat="server" Text="Select Project"></asp:Label>
                  </div>
             <div class="col-md-3">
                 <asp:DropDownList ID="ddlProjects" runat="server" Width="150px" CssClass="selectbox" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlProjects_SelectedIndexChanged">
                       <asp:ListItem Text="--select project--"></asp:ListItem>
                 </asp:DropDownList>
                  <asp:RequiredFieldValidator ID="frvProjects" runat="server" ErrorMessage="*"
                                    Display="Dynamic" SetFocusOnError="true"
                                    ForeColor="Red"
                                    ValidationGroup="Group"
                                    ControlToValidate="ddlProjects">
                                </asp:RequiredFieldValidator>
                  </div>
             <div class="col-md-6">
                
                  </div>
             </div>
              <br />
              <br />
               <div class="col-md-12">
                    <div class="col-md-3">
                  <asp:Label ID="lblModule" runat="server" Text="Select module"></asp:Label>
                  </div>
                     <div class="col-md-3">
                          <asp:DropDownList ID="ddlModule" runat="server" Width="150px" CssClass="selectbox" AppendDataBoundItems="false" AutoPostBack="true" OnSelectedIndexChanged="ddlModule_SelectedIndexChanged">
                       <asp:ListItem Text="--select module--" Selected="True"></asp:ListItem>
                 </asp:DropDownList>
                          <asp:RequiredFieldValidator ID="rfvModule" runat="server" ErrorMessage="*"
                                    Display="Dynamic" SetFocusOnError="true"
                                    ForeColor="Red"
                                    ValidationGroup="Group"
                                    ControlToValidate="ddlModule">
                                </asp:RequiredFieldValidator>
                         </div>
                    <div class="col-md-6">
                
                  </div>
                   </div>
              
               <div style="width: 470px; height: 400px; margin-left:5%;">
                <br />
                      <br />
                   <br />
                 <div class="contentTopBar" style="width:470px;"></div>
                <telerik:RadGrid ID="dtgManageCategory" runat="server" AllowPaging="true" Width="100%" Skin="Silk" CssClass="outerMultiPage" AllowSorting="true"  PageSize="7" OnNeedDataSource="dtgManageCategory_NeedDataSource" OnItemCreated="dtgManageCategory_ItemCreated" OnPreRender="dtgManageCategory_PreRender">
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
                       <div style="margin-left:23%;">
            <asp:Label ID="lblCreateNew" runat="server" Text="Create New" CssClass="PageHeading"></asp:Label>
                  </div> 
               
                <br />
                        <div class="col-md-12 Span-One" style="margin-left:20%;">
               <div class="form-group required">
                     
                   <asp:Label ID="lblCategory" runat="server" Text="Category" CssClass="control-label col-md-6 "></asp:Label>
                   
                           <div class="col-md-5">
                        <asp:TextBox ID="txtCategory" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                   </div>
                            </div>

                        <div class="col-md-12 Span-One" style="margin-left:20%;">
               <div class="form-group required">
                   <asp:Label ID="lblCategoryDesc" runat="server" Text="Category Desc" CssClass="control-label col-md-6 "></asp:Label>
                    <div class="col-md-5">
                        <asp:TextBox ID="txtCategoryDesc" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                   </div>
                            </div>

                        <div class="col-md-12 Span-One" style="margin-left:20%;">
               <div class="form-group required">
                   <asp:Label ID="lblCategoryHelp" runat="server" Text="Category Help" CssClass="control-label col-md-6 "></asp:Label>
                    <div class="col-md-5">
                        <asp:TextBox ID="txtCategoryHelp" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                   </div>
                            </div>

                        <div class="col-md-12 Span-One" style="margin-left:20%;">
               <div class="form-group required">
                   <asp:Label ID="lblDisplayOrder" runat="server" Text="Display Order" CssClass="control-label col-md-6 "></asp:Label>
                    <div class="col-md-5">
                        <asp:TextBox ID="txtDisplayOrder" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                   </div>
                            </div>

                        <div class="col-md-12 Span-One" style="margin-left:20%;">
               <div class="form-group required">
                   <asp:Label ID="lblCategoryType" runat="server" Text="Category Type" CssClass="control-label col-md-6 "></asp:Label>
                    <div class="col-md-5">
                        <asp:TextBox ID="txtCategoryType" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                   </div>
                            </div>

                        <div class="col-md-12 Span-One" style="margin-left:20%;">
               <div class="form-group required">
                   <asp:Label ID="lblKeyField" runat="server" Text="KeyField" CssClass="control-label col-md-6 "></asp:Label>
                    <div class="col-md-5">
                        <asp:TextBox ID="txtKeyField" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                   </div>
                            </div>

                        <div class="col-md-12 Span-One" style="margin-left:20%;">
               <div class="form-group required">
                   <asp:Label ID="lblKeyFieldGrpBy" runat="server" Text="KeyField GroupBy" CssClass="control-label col-md-6 "></asp:Label>
                    <div class="col-md-6">
                         <table>
                              <tr>
                                  <td> <asp:CheckBox ID="chkIsActive" runat="server" /></td>
                                  <td>&nbsp;IsActive</td>
                              </tr>
                          </table>
                        </div>
                   </div>
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
                <%=ToolBar.ClientID %>_SetDeleteVisible(true);
            }

         function OnClientButtonClicking(sender, args) {
             var btn = args.get_item();
             if (btn.get_value() == 'Save') {
                 args.set_cancel(!validate());
                
             }
             if (btn.get_value() == 'Delete') {

                 args.set_cancel(!validateDelete());
             }
         }
      
   function validate() {
       var regexp = /^[a-zA-Z]+$/;
       var r = /^-?\d\d*$/;
       var project = document.getElementById('<%=ddlProjects.ClientID %>').value;
       var module = document.getElementById('<%=ddlModule.ClientID %>').value;
       var category = document.getElementById('<%=txtCategory.ClientID %>');
       var categoryDesc = document.getElementById('<%=txtCategoryDesc.ClientID %>');
       var categoryHelp = document.getElementById('<%=txtCategoryHelp.ClientID %>');
       var categoryType = document.getElementById('<%=txtCategoryType.ClientID %>');
       var keyField = document.getElementById('<%=txtKeyField.ClientID %>');
       var displayOrder = document.getElementById('<%=txtDisplayOrder.ClientID %>');
       if ((category.value.match(regexp)) && (categoryDesc.value.match(regexp)) && (categoryHelp.value.match(regexp)) && (categoryType.value.match(regexp)) && (keyField.value.match(regexp)) && (displayOrder.value.match(r)) && (project != "--select project--") && (module != "--select module--")) {
           return true;
       } else {
           if ((project == "--select project--") && (module == "--select module--")) {
               displayMessage(messageType.Error, messages.DropdownSelect);
           }
           else {
               displayMessage(messageType.Error, messages.IncorrectFormat);
           }
           return false;
       }
      
         }

          function validateDelete()
          {
              var project = document.getElementById('<%=ddlProjects.ClientID %>').value;
              project = trimString(project);
              var module = document.getElementById('<%=ddlModule.ClientID %>').value;
              module = trimString(module);
              if (project != "--select project--" || module != "--select module--")
              {
                   return true;
              }
          else {
                 displayMessage(messageType.Error, messages.MandatoryFieldsGeneral);
          return false;
          }
          
          }
         </script>
</asp:Content>
