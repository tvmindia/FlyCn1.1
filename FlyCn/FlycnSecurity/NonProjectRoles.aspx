<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="NonProjectRoles.aspx.cs" Inherits="FlyCn.FlycnSecurity.NonProjectRoles" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../Scripts/jquery.1.9.1.min.js"></script>

 <title>Non Project Roles</title>

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

         .myclass
      {
          width: 100px;
      }

          #tabs li a {
            color: white;
            display: block;
            text-decoration: none;
            font-size:small;
            font-weight:lighter;
        }

    </style>

    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
</asp:ScriptManager>  

    <script>

      

        function OnClientButtonClickingDetail(sender, args) {
            debugger;
            var btn = args.get_item();

            if (btn.get_value() == 'Save') {

                args.set_cancel(!validate());
            }

            if (btn.get_value() == 'Update') {

                args.set_cancel(!validate());
            }
        }

        function validate() {
          
            debugger;

            var RoleName = document.getElementById('<%=txtRoleName.ClientID %>').value;
        
            var AccessType = document.getElementById('<%=txtAccessType.ClientID %>').value;
            

            var ddlRoleType = document.getElementById("<%=ddlRoleType.ClientID%>");
            var ddlRoleTypeText = ddlRoleType.options[ddlRoleType.selectedIndex].text;
            
            var ddlLevel = document.getElementById("<%=ddlLevel.ClientID%>");
            var ddlLevelText = ddlLevel.options[ddlLevel.selectedIndex].text;

            if (RoleName == "" || AccessType == "" || ddlRoleTypeText == "--Select--" || ddlLevelText == "--Select--") {
             

                displayMessage(messageType.Error, messages.MandatoryFieldsGeneral);
                return false;
            }
            else {
                return true;
            }
        }

        function OnClientButtonClicking(sender, args) {
           
            var btn = args.get_item();
            if (btn.get_value() == 'Save') {
                args.set_cancel(!validate());
            }
        }
        function validate() {
           
            var RoleName = document.getElementById('<%=txtCreateRoleName.ClientID %>').value;
            RoleName = trimString(RoleName);
            var Description = document.getElementById('<%=txtDescription.ClientID %>').value;
            Description = trimString(Description);
            var ProjNo = document.getElementById('<%=ddlProjectNo.ClientID %>').value;
            ProjNo = trimString(ProjNo);
            if (RoleName == "" || Description == "" || ProjNo == "--select Project No--") {
                displayMessage(messageType.Error, messages.MandatoryFieldsGeneral);
               
                return false;
            }
            else {
                return true;
            }

        }

    </script>

        
        <div class="container" style="width: 100%">

        <div class="col-md-12">

                <ul id="tabs">
                    <li><a href="#" onclick="MyTab1(this);" id="tabs1">Non-Project Roles</a></li>
                    <li><a href="#" onclick="MyTab2(this);" id="tabs2">Project Roles</a></li>
                </ul>
   
     <div id="content">
                    <div id="tab1">
                         <div role="tabpanel" class="tab-pane active" id="home">
                            <div class="table-responsive">
   <uc1:ToolBar runat="server" ID="ToolBar"/>

    <div class="col-md-5"  >
        <div style="margin-left:-8px;">
            <asp:Label ID="Label1" runat="server" Text="Manage Existing Roles" CssClass="PageHeading"></asp:Label>
            </div>
        <br />
         <div class="contentTopBar" style="min-width:600px" ></div>
         <div  style="width:600px;" >
         
              <telerik:RadGrid ID="dtgNonProjectRoles" runat="server" AllowPaging="true" AllowSorting="true"  PageSize="7"
                        OnNeedDataSource="dtgNonProjectRoles_NeedDataSource" OnItemCommand="dtgNonProjectRoles_ItemCommand"
                        Skin="Silk" CssClass="outerMultiPage"
                        OnPreRender="dtgNonProjectRoles_PreRender" Width="100%">
                  
                  <HeaderStyle  HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <AlternatingItemStyle HorizontalAlign="Left" />
             

                        <MasterTableView AutoGenerateColumns="false" DataKeyNames="RoleID" >
                            
                            <Columns>
                                <telerik:GridButtonColumn CommandName="EditData" ItemStyle-Width="2px" ButtonType="ImageButton" ImageUrl="~/Images/Icons/Pencil-01.png" Text="Edit" UniqueName="EditData">
                                </telerik:GridButtonColumn>
                                <telerik:GridButtonColumn CommandName="Delete" ButtonType="ImageButton" ItemStyle-Width="2px"  ImageUrl="~/Images/Cancel.png" Text="Delete" UniqueName="Delete" ConfirmDialogType="RadWindow" ConfirmText="Are you sure">
                                </telerik:GridButtonColumn>

                                <telerik:GridBoundColumn HeaderText="ID" DataField="RoleID" UniqueName="RoleID" ></telerik:GridBoundColumn> 
                                 <telerik:GridBoundColumn HeaderText="Name" DataField="RoleName" UniqueName="RoleName" ></telerik:GridBoundColumn> 
                                 <telerik:GridBoundColumn HeaderText="Type" DataField="RoleType" UniqueName="RoleType" ></telerik:GridBoundColumn> 
                                 <telerik:GridBoundColumn HeaderText="Scope" DataField="RoleScope" UniqueName="RoleScope"  ></telerik:GridBoundColumn> 
                                 <telerik:GridBoundColumn  HeaderText="Scope Value" DataField="ScopeValue" UniqueName="ScopeValue" >  </telerik:GridBoundColumn> 
                                 <telerik:GridBoundColumn HeaderText="Group1" DataField="ProjectGroup1" UniqueName="ProjectGroup1"></telerik:GridBoundColumn> 
                                 <telerik:GridBoundColumn HeaderText="Group2" DataField="ProjectGroup2" UniqueName="ProjectGroup2"></telerik:GridBoundColumn> 
                                 <telerik:GridBoundColumn HeaderText="Group3" DataField="ProjectGroup3" UniqueName="ProjectGroup3"></telerik:GridBoundColumn> 
                                 <telerik:GridBoundColumn HeaderText="Access Type" DataField="AccessType" UniqueName="AccessType" ></telerik:GridBoundColumn> 
                                 <%--<telerik:GridBoundColumn HeaderText="Created By" DataField="Created_By" UniqueName="Created_By" ></telerik:GridBoundColumn>--%> 
                                 <%--<telerik:GridBoundColumn HeaderText="Created Date" DataField="Created_Date" UniqueName="Created_Date"  DataType="System.DateTime"  DataFormatString="{0:M/d/yyyy}" ></telerik:GridBoundColumn>--%> 

                            </Columns>
                        </MasterTableView>

                    </telerik:RadGrid>

             </div>
          
  </div>
       
      <div class="col-md-2">&nbsp;</div>
            <div class="col-md-1"  style="border-left: 1px solid #cfc7c0;height:400px;top:15px;">&nbsp;</div>

    <div class="col-md-4">
        <div style="margin-left:-80px;">
   <asp:Label ID="Label2" runat="server" Text="Create New Role" CssClass="PageHeading"></asp:Label>
            </div>
        <br />
<%--Role name--%>
   <div class="col-md-12 Span-One" style="margin-left:-95px;">
                   


                        <div class="form-group required">


                            <asp:Label ID="lblRoleName" CssClass="control-label col-md-5"  runat="server" Text="RoleName"></asp:Label>

                            <div class="col-md-7">
                                  <asp:TextBox ID="txtRoleName" CssClass="form-control" runat="server"></asp:TextBox>
                                
                                <span id="span3" runat="server" style="color: red; font-size: 15px; font-weight: 500; font-family: Trebuchet MS;"></span>

                            </div>
                        </div>
                        <%-- </form>--%>
               
                    
                </div>

<%--Role type--%>

   <div class="col-md-12 Span-One" style="margin-left:-95px;">
                   

                        <div class="form-group required">


                            <asp:Label ID="lblRoleType" CssClass="control-label col-md-5"  runat="server" Text="RoleType">  </asp:Label>

                            <div class="col-md-7">
                                    <asp:DropDownList ID="ddlRoleType" runat="server" CssClass="selectbox" AutoPostBack="true" OnSelectedIndexChanged="ddlRoleType_SelectedIndexChanged"></asp:DropDownList>
                                
                                <span id="span1" runat="server" style="color: red; font-size: 15px; font-weight: 500; font-family: Trebuchet MS;"></span>

                            </div>
                        </div>
                        <%-- </form>--%>
               
                    
                </div>


<%--Role scope--%>

   <div class="col-md-12 Span-One" style="margin-left:-95px;">
                   

                        <div class="form-group required">


                            <asp:Label ID="lblRoleScope" CssClass="control-label col-md-5"  runat="server" Text="Role Scope">

          </asp:Label>

                            <div class="col-md-7">
                                     <asp:DropDownList ID="ddlLevel" CssClass="selectbox" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlLevel_SelectedIndexChanged"></asp:DropDownList>
                                
                                <span id="span2" runat="server" style="color: red; font-size: 15px; font-weight: 500; font-family: Trebuchet MS;"></span>

                            </div>
                        </div>
                        <%-- </form>--%>
               
                    
                </div>


 <%--Scope value--%>  

        <div class="col-md-12 Span-One" style="margin-left:-95px;">
                   

                        <div class="form-group">


                        <asp:Label ID="lblScopeValue" CssClass="control-label col-md-5"   runat="server" Text="Scope Value">

          </asp:Label>

                            <div class="col-md-7">
                                    <asp:ListBox ID="lstRoleScope" CssClass="selectbox" runat="server" SelectionMode="Multiple" OnSelectedIndexChanged="lstRoleScope_SelectedIndexChanged"></asp:ListBox>
                                
                               

                            </div>
                        </div>
                        <%-- </form>--%>
               
                    
                </div>


<%--Project group1--%>



        <div class="col-md-12 Span-One" style="margin-left:-95px;">
                   
            


                        <div class="form-group">


                       <asp:Label ID="lblProjectGroup1" CssClass="control-label col-md-5"  runat="server" Text="ProjectGroup1">

          </asp:Label>

                            <div class="col-md-7">
                                  <asp:DropDownList ID="ddlProjectGroup1" CssClass="selectbox" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProjectGroup1_SelectedIndexChanged" ></asp:DropDownList>
                                
                               

                            </div>
                        </div>
                        <%-- </form>--%>
               
                    
                </div>


<%--Project group2--%>



        <div class="col-md-12 Span-One" style="margin-left:-95px;">
                   

                        <div class="form-group">


                          <asp:Label ID="lblProjectGroup2" CssClass="control-label col-md-5"  runat="server" Text="ProjectGroup2">

          </asp:Label>

                            <div class="col-md-7">
                                  <asp:TextBox ID="txtProjectGroup2" CssClass="form-control" runat="server"></asp:TextBox>
                                
                              

                            </div>
                        </div>
                        <%-- </form>--%>
               
                    
                </div>



<%--Project group3--%>

<div class="col-md-12 Span-One" style="margin-left:-95px;">
                   

                        <div class="form-group">


                           <asp:Label ID="lblProjectGroup3" CssClass="control-label col-md-5"  runat="server" Text="ProjectGroup3">

         </asp:Label>

                            <div class="col-md-7">
                                  <asp:TextBox ID="txtProjectGroup3" CssClass="form-control" runat="server"></asp:TextBox>
                                
                                

                            </div>
                        </div>
                        <%-- </form>--%>
               
                    
                </div>



<%--Access type--%>

        <div class="col-md-12 Span-One" style="margin-left:-95px;">
                   

                        <div class="form-group required">


                            <asp:Label ID="lblAccessType" CssClass="control-label col-md-5"  runat="server" Text="Access Type">

          </asp:Label>

                            <div class="col-md-7">
                                  <asp:TextBox ID="txtAccessType" CssClass="form-control" runat="server"></asp:TextBox>
                                
                                <span id="span8" runat="server" style="color: red; font-size: 15px; font-weight: 500; font-family: Trebuchet MS;"></span>

                            </div>
                        </div>
                        <%-- </form>--%>
               
                    
                </div>
        </div>
                                </div>

   </div>

  </div>
       

            <div id="tab2">
                
                <div role="tabpanel" class="tab-pane active" id="Div1">
                    <div class="table-responsive" style="overflow-x:hidden;">
                       
        <uc1:ToolBar runat="server" ID="ToolBar1" /> 
       
                

                         <div style="float:left; width:53%;">
                           
                               <asp:Label ID="lblManageExistingRoles" runat="server" Text="Manage Existing Roles" CssClass="PageHeading"></asp:Label>
                             <br />
                           <div class="col-md-12 Span-One">
                                <div class="col-md-6"></div>
                               <div class="col-md-3" style="margin-left:-52%;">
                             <asp:Label ID="lblProjectNo" runat="server" Text="Project No"></asp:Label>
                                    </div>
                               <div class="col-md-3" style="margin-left:-15%;">
                                   <asp:DropDownList ID="ddlProjectNo" runat="server" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlProjectNo_SelectedIndexChanged">
                                       <asp:ListItem Text="--select Project No--"></asp:ListItem>
                                   </asp:DropDownList>
                                   </div>
                             </div>
                               <div class="col-md-4">
                         
                         
                         
                       <br />
                                    <div class="contentTopBar" style="width:450px;"></div>
                         <div style="width:450px;">
                              <telerik:RadGrid ID="dtgManageExistingRoles" runat="server" AllowPaging="true" Width="100%" Skin="Silk" CssClass="outerMultiPage" AllowSorting="true"  PageSize="7" OnNeedDataSource="dtgManageExistingRoles_NeedDataSource">
                                     <HeaderStyle  HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <AlternatingItemStyle HorizontalAlign="Left" />
                    <MasterTableView  AutoGenerateColumns="false" ShowHeadersWhenNoRecords="true" ShowHeader="true" NoMasterRecordsText="No roles have been added.">
                         <Columns>
                              <telerik:GridBoundColumn HeaderText="Role ID" DataField="RoleID" UniqueName="RoleID" ></telerik:GridBoundColumn> 
                              <telerik:GridBoundColumn HeaderText="Role Name" DataField="RoleName" UniqueName="RoleName"></telerik:GridBoundColumn>
                           <telerik:GridBoundColumn HeaderText="Description" DataField="Description" UniqueName="Description"></telerik:GridBoundColumn>
                             <%--<telerik:GridBoundColumn HeaderText="Access Type" DataField="AccessType" UniqueName="AccessType" ></telerik:GridBoundColumn> --%>
                        </Columns>
                    </MasterTableView>

                </telerik:RadGrid>
                             </div>
                                   </div>
                             </div>
                      
                        <div style="float:right; width:47%; ">

                            <br />
            <div class="col-md-12"  style="border-left: 1px solid #cfc7c0;height:400px;top:35%;margin-left:0px;">
                <div style="margin-left:55px;">

                               <asp:Label ID="lblCreateNewRole" runat="server" Text="Create New Role" CssClass="PageHeading"></asp:Label>
                    </div>

                             <div class="col-md-12 Span-One" style="margin-left:5%;">
                                 <div class="form-group required">
                                <div class="col-md-6">
                             <asp:Label ID="lblCreateRoleName" runat="server" Text="Role Name" CssClass="control-label col-md-6 "></asp:Label>
                                    </div>
                               <div class="col-md-6">
                                  <asp:TextBox ID="txtCreateRoleName" runat="server" CssClass="form-control"></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="rfvRoleName" runat="server" ErrorMessage="Enter RoleName"
                                    Display="Dynamic" SetFocusOnError="true"
                                    ForeColor="Red"
                                    ValidationGroup="Group"
                                    ControlToValidate="txtCreateRoleName">
                                </asp:RequiredFieldValidator>
                                   </div>
                                     </div>
                             </div>

                             <div class="col-md-12 Span-One" style="margin-left:5%;">
                                 <div class="form-group required">
                                <div class="col-md-6">
                             <asp:Label ID="lblDescription" runat="server" Text="Description" CssClass="control-label col-md-6 "></asp:Label>
                                    </div>
                               <div class="col-md-6">
                                   <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control"></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ErrorMessage="Enter Description"
                                    Display="Dynamic" SetFocusOnError="true"
                                    ForeColor="Red"
                                    ValidationGroup="Group"
                                    ControlToValidate="txtDescription">
                                </asp:RequiredFieldValidator>
                                   </div>
                                     </div>
                             </div>

                            </div>
                    </div>
                </div>
            </div>
            
            </div>
            </div>
   </div>
            </div>
    <asp:HiddenField ID="hdnEditPostBack" runat="server" Value="0" />
     <asp:HiddenField ID="selected_tab" runat="server" />
 <script>
    
   
     $(document).ready(function () {
         var myHidden = document.getElementById('<%= selected_tab.ClientID %>');
             document.getElementById("tab1").style.display = "block";
             document.getElementById("tab2").style.display = "none";
             if(myHidden.value==2)
             {
                 document.getElementById("tab2").style.display = "block";
                 document.getElementById("tab1").style.display = "none";
             }
         
     });
     function MyTab1(id)
     {
         var myHidden = document.getElementById('<%= selected_tab.ClientID %>');
         myHidden.value = 1;
         funtab2 = document.getElementById("tab2");
         funtab2.style.display = "none";
         document.getElementById("tab1").style.display = "block";
     }
     function MyTab2(id) {
         var myHidden = document.getElementById('<%= selected_tab.ClientID %>');
         myHidden.value = 2;
         funtab1 = document.getElementById("tab1");
        
         funtab1.style.display = "none";
         document.getElementById("tab2").style.display = "block";
        
     }
    </script>
</asp:Content>


 
