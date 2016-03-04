<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" EnableEventValidation="false"  CodeBehind="Users.aspx.cs" Inherits="FlyCn.FlycnSecurity.Users" %>
<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
    <script type="text/javascript">
        $(document).ready(function () {
         
           
                    
            var EmailValidlbl = document.getElementById('<%=lblEmaillValid.ClientID %>');
            EmailValidlbl.style.display = "none";
            var validatePassword = document.getElementById('<%=lblpassValidate.ClientID %>');
            validatePassword.style.display = "none";
            var LnameImage = document.getElementById('<%=imgWebLnames.ClientID %>');
            LnameImage.style.display = "none";
            var errLname = document.getElementById('<%=errorLnames.ClientID %>');
            errLname.style.display = "none";
        });
        
       
       
    </script>
    <asp:ScriptManager ID="scriptmanager2" runat="server" EnablePageMethods="true" EnablePartialRendering="true" ></asp:ScriptManager>   
  
     <div class="importWizardContainer" style="height:500px;">
           <div class="col-md-12">
        <uc1:ToolBar runat="server" ID="ToolBar" /> 
        </div>
     
      
          <div style="float:left; width:53%;">
               
                   <div class="col-md-12">
                         <div style="margin-left:-10px;">
                           <asp:Label ID="ManageExisting" runat="server" Text="Manage Existing Users" CssClass="PageHeading"></asp:Label>
                          </div>
                           
                       <br />
                      <%--  <div class="contentTopBar" style="width:500px;"></div>--%>
                         <div style="width:500px;">
                     <telerik:RadGrid ID="dtgManageExisting" runat="server" OnDeleteCommand="dtgManageExisting_DeleteCommand1" OnNeedDataSource="dtgManageExisting_NeedDataSource" OnItemCommand="dtgManageExisting_ItemCommand1" AllowPaging="true" Width="100%" Skin="Silk" CssClass="outerMultiPage" AllowSorting="true"  PageSize="7" >
                           <HeaderStyle  HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <AlternatingItemStyle HorizontalAlign="Left" />
                    <MasterTableView  AutoGenerateColumns="false" ShowHeadersWhenNoRecords="true" ShowHeader="true" NoMasterRecordsText="No login details have been added." DataKeyNames="UserName">
                         <Columns>
                               <telerik:GridButtonColumn CommandName="EditData" ButtonType="ImageButton" ImageUrl="~/Images/Icons/Pencil-01.png" Text="Edit" UniqueName="EditData">
                                </telerik:GridButtonColumn>
                                <telerik:GridButtonColumn CommandName="Delete" ButtonType="ImageButton" ImageUrl="~/Images/Cancel.png" Text="Delete" UniqueName="Delete">
                                </telerik:GridButtonColumn>

                              <telerik:GridBoundColumn HeaderText="Login Name" DataField="UserName" UniqueName="UserName" ></telerik:GridBoundColumn>
                              <telerik:GridBoundColumn HeaderText="Email" DataField="EmailId" UniqueName="EmailId"></telerik:GridBoundColumn>
                              <telerik:GridBoundColumn HeaderText="Theme" DataField="Theme" UniqueName="Theme"></telerik:GridBoundColumn>
                              <telerik:GridBoundColumn HeaderText="Active" DataField="Active" UniqueName="Active" ></telerik:GridBoundColumn>
                             <telerik:GridBoundColumn HeaderText="PassWord" DataField="PassWord" UniqueName="PassWord" Display="false" ></telerik:GridBoundColumn>
                              <telerik:GridBoundColumn HeaderText="CreatedBy" DataField="CreatedBy" UniqueName="CreatedBy" Display="false"></telerik:GridBoundColumn>
                              <telerik:GridBoundColumn HeaderText="CreatedDate" DataField="CreatedDate" UniqueName="CreatedDate" Display="false"></telerik:GridBoundColumn>
                              <telerik:GridBoundColumn HeaderText="DefaultProjectNo" DataField="DefaultProjectNo" UniqueName="DefaultProjectNo" Display="false"></telerik:GridBoundColumn>
                              <telerik:GridBoundColumn HeaderText="Updated_By" DataField="Updated_By" UniqueName="Updated_By" Display="false"></telerik:GridBoundColumn>
                              <telerik:GridBoundColumn HeaderText="Updated_Date" DataField="Updated_Date" UniqueName="Updated_Date" Display="false"></telerik:GridBoundColumn>
                             
                        </Columns>
                    </MasterTableView>

                </telerik:RadGrid>
                </div>
                     
               </div>
         </div>
         
          <div style="float:right; width:47%; ">
            <div class="col-md-12"  style="border-left: 1px solid #cfc7c0;min-height:400px">
                <div style="margin-left:10px;">
            <asp:Label ID="lblCreateNew" runat="server" Text="Create New" CssClass="PageHeading"></asp:Label>
                  </div> 
               
                <br />
                <div class="col-md-12 Span-One">
               <div class="form-group required">
                   
                       <asp:Label ID="lblLoginName" runat="server" CssClass="control-label col-md-6 "  Text="Login Name"></asp:Label>
                      
                    <div class="col-md-6">
                        <table>
                            <tr>
                                <td>
                        <asp:TextBox ID="txtLoginName" runat="server" CssClass="form-control" autocomplete="off" onchange="LoginNameCheck(this)"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvloginName" runat="server" ErrorMessage="Enter Login Name"
                                    Display="Dynamic" SetFocusOnError="true"
                                    ForeColor="Red"
                                    ValidationGroup="Group"
                                    ControlToValidate="txtLoginName">
                                </asp:RequiredFieldValidator></td>
                                <td>
                        <asp:Image  ID="imgWebLnames" runat="server" ToolTip="Login Name is Available" ImageUrl="~/Images/ProjectImages/Check.png" Width="17px" Height="17px"/></td>
                        <td>   <asp:Image ID="errorLnames" runat="server" ToolTip="Login Name is Unavailable" ImageUrl="~/Images/ProjectImages/newClose.png" Width="10px" Height="10px" /></td>
                           </tr> </table>
                        </div>
                   </div>
               </div>
                
                 <div class="col-md-12 Span-One">
                 <div class="form-group required">
                     
                   <asp:Label ID="lblPassword" runat="server" CssClass="control-label col-md-6 "  Text="Password"></asp:Label>
                         
                      <div class="col-md-6">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" autocomplete="off" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
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
                          <table>
                              <tr><td>
                       <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" autocomplete="off" CssClass="form-control" onchange="validatePasswords();"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ErrorMessage="Enter Confirm Password"
                                    Display="Dynamic" SetFocusOnError="true"
                                    ForeColor="Red"
                                    ValidationGroup="Group"
                                    ControlToValidate="txtConfirmPassword">
                                </asp:RequiredFieldValidator>
                          </td> 
                                  <td>
                                      <asp:Label ID="lblpassValidate" runat="server" Text="Password doesn't match" ForeColor="Red"></asp:Label>
                                  </td>
                              </tr>  </table>
                          </div>
                     </div>
                     </div>
                 <div class="col-md-12 Span-One">
                 <div class="form-group required">
                     
                   <asp:Label ID="lblEmail" runat="server" CssClass="control-label col-md-6 "  Text="Email"></asp:Label>
                          
                      <div class="col-md-6">
                          <table>
                              <tr><td>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" onchange="validateEmail(this);"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Enter Email"
                                    Display="Dynamic" SetFocusOnError="true"
                                    ForeColor="Red"
                                    ValidationGroup="Group"
                                    ControlToValidate="txtEmail">
                                </asp:RequiredFieldValidator>
                           </td>
                                  <td>
                                      <asp:Label ID="lblEmaillValid" runat="server" Text="Invalid Email" ForeColor="Red" ></asp:Label>
                                  </td>
                              </tr> </table>
                          </div>
                     </div>
                   </div>
                 <div class="col-md-12 Span-One">
                 <div class="form-group required">
                     
                        <asp:Label ID="lblActive" runat="server" CssClass="control-label col-md-6 "  Text="Active"></asp:Label>
                         
                      <div class="col-md-6" style="white-space:nowrap;overflow:hidden;">
                          <table>
                              <tr>
                                  <td> <asp:CheckBox ID="chkIsActive" runat="server" /></td>
                                  <td>&nbsp;IsActive</td>
                              </tr>
                          </table>
                         
                          
                          </div>
                   </div>
                     </div>
                <div class="col-md-12 Span-One">
                 <div class="form-group required">
                     
                        <asp:Label ID="lblTheme" runat="server" CssClass="control-label col-md-6 "  Text="Theme"></asp:Label>
                         
                      <div class="col-md-6">
                        <asp:DropDownList ID="ddlTheme" runat="server" Width="150px">
                            <asp:ListItem Text="--select theme--" Value="0"></asp:ListItem>
                            <asp:ListItem Text="FlyCnGreen" Value="FlyCnGreen"></asp:ListItem>
                            <asp:ListItem Text="FlyCnRed" Value="FlyCnRed"></asp:ListItem>
                        </asp:DropDownList>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Select Theme"
                                    Display="Dynamic" SetFocusOnError="true"
                                    ForeColor="Red"
                                    ValidationGroup="Group"
                                    ControlToValidate="ddlTheme">
                                </asp:RequiredFieldValidator>
                          </div>
                   </div>
                     </div>
                
         </div>
              </div>
              </div>
    <asp:HiddenField ID="hdnEditPostBack" runat="server" Value="0" />
    <script type="text/javascript">
        function OnClientButtonClicking(sender, args) {
            var btn = args.get_item();
            if (btn.get_value() == 'Save') {
                args.set_cancel(!validate());
            }
        }


        function OnClientButtonClickingDetail(sender, args) {

            var btn = args.get_item();

            if (btn.get_value() == 'Save') {

                args.set_cancel(!validate());
            }

            if (btn.get_value() == 'Update') {

                args.set_cancel(!validate());
            }
        }
        function validate()
        {
            var logName = document.getElementById('<%=txtLoginName.ClientID %>').value;
            logName = trimString(logName);
            var password = document.getElementById('<%=txtPassword.ClientID %>').value;
            password = trimString(password);
            var ConfirmPass = document.getElementById('<%=txtConfirmPassword.ClientID %>').value;
            ConfirmPass = trimString(ConfirmPass);
            var Email = document.getElementById('<%=txtEmail.ClientID %>').value;
            Email = trimString(Email);
           
            var Theme = document.getElementById('<%=ddlTheme.ClientID %>').value;
            Theme = trimString(Theme);
            if (logName != "" || password != "" || ConfirmPass != "" || Email != "" || Theme!="") {
                return true;
            }
            else
            {
                displayMessage(messageType.Error, messages.MandatoryFieldsGeneral);
                return false;
            }
            if(password==ConfirmPass)
            {
                return true;
            }
            else
            {
                displayMessage(messageType.Error, messages.PasswordDoesnotMatch);
                return false;
            }
            
        }

        function validatePasswords()
        {
            var password = document.getElementById('<%=txtPassword.ClientID %>').value;
            password = trimString(password);
            var ConfirmPass = document.getElementById('<%=txtConfirmPassword.ClientID %>').value;
            ConfirmPass = trimString(ConfirmPass);
            if (password == ConfirmPass) {
                var validatePassword = document.getElementById('<%=lblpassValidate.ClientID %>');
                validatePassword.style.display = "none";
                return true;
            }
            if(password==null&&ConfirmPass==null)
            {
                var validatePassword = document.getElementById('<%=lblpassValidate.ClientID %>');
                validatePassword.style.display = "none";
            }
            else {
                var validatePassword = document.getElementById('<%=lblpassValidate.ClientID %>');
                validatePassword.style.display = "block";
                return false;
            }
        }
        function LoginNameCheck(txtLoginName)
        {
            debugger;
            var name = document.getElementById('<%=txtLoginName.ClientID %>').value;
            PageMethods.ValidateLoginName(name, OnSuccess, onError);
            function OnSuccess(response, userContext, methodName) {
               
                var LnameImage = document.getElementById('<%=imgWebLnames.ClientID %>');
                var errLname = document.getElementById('<%=errorLnames.ClientID %>');
                if (response == false)
                {
                   
                    LnameImage.style.display = "block";
                    errLname.style.display = "none";
                   
                }
                if(response == true)
                {
                    errLname.style.display = "block";
                    errLname.style.color = "Red";
                    errLname.innerHTML="Name Alreay Exists"
                    LnameImage.style.display = "none";
                    
                }
            }
             function onError(response, userContext, methodName) {
               
               
            }
        }

        function validateEmail(emailField) {
            var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;

            if (reg.test(emailField.value) == false) {
                var EmailValidlbl = document.getElementById('<%=lblEmaillValid.ClientID %>');
                EmailValidlbl.style.display = "block";
                return false;
            }
            if (reg.test(emailField.value) == true) {
                var EmailValidlbl = document.getElementById('<%=lblEmaillValid.ClientID %>');
                EmailValidlbl.style.display = "none";
                return true;
            }
        }
   </script>
</asp:Content>
