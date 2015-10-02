<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="UserMaster.aspx.cs" Inherits="FlyCn.FlyCnMasters.UserMaster" %>
<asp:Content ID="phdUserMasterHead" ContentPlaceHolderID="head" runat="server">
    
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
       <!-----bootstrap css--->
   <%-- <link href="../Content/themes/FlyCnBlue/css/roboto_google_api.css" rel="stylesheet" />
    <link href="Content/themes/FlyCnBlue/css/datepicker.css" rel="stylesheet" type="text/css" />
    <!-----bootstrap css--->
    <link href="../Content/themes/FlyCnBlue/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/themes/FlyCnBlue/css/stylesheet.css" rel="stylesheet" />

    <link href="../Content/themes/FlyCnBlue/css/selectize.css" rel="stylesheet" type="text/css" />
    <link href="../Content/themes/FlyCnBlue/css/accodin.css" rel="stylesheet" type="text/css" />
    <!-----main css--->
    <link href="../Content/themes/FlyCnBlue/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Content/themes/FlyCnRed_Rad/TabStrip.FlyCnRed_Rad.css" rel="stylesheet" />--%>
    <!-----main css--->
  

</asp:Content>
<asp:Content ID="phdUserMasterContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <script type="text/javascript">
             function ClearTextBox() {
                 $('textarea').empty();
                 $('PassWord').empty();
                 $("input:text").val('');
             }
             function EnableButtonsForNew() {
                 <%=ToolBar.ClientID %>_SetAddVisible(false);
            <%=ToolBar.ClientID %>_SetSaveVisible(true);
            <%=ToolBar.ClientID %>_SetUpdateVisible(false);
            <%=ToolBar.ClientID %>_SetDeleteVisible(false);
        }
        function SelectTabList() {
            var tabStrip = $find("<%= RadTabStrip1.ClientID %>");
            var tab = tabStrip.findTabByValue("1");
            tab.select();
        }

        function SetTabNewTextAndIcon() {
            var tabStrip = $find("<%= RadTabStrip1.ClientID %>");
            var tab1 = tabStrip.findTabByValue("2");
            tab1.set_text("New");
            tab1.set_imageUrl('../Images/Icons/NewIcon.png');
        }
           </script>

     <script type="text/javascript">
         function onClientTabSelected(sender, args) {

             var tab = args.get_tab();
             if (tab.get_value() == '2') {

                 try {

                     ClearTextBox();
                     EnableButtonsForNew();



                 }
                 catch (x) {
                     alert(x.message);
                 }

             }

             if (tab.get_value() == "1") {//List tab selected

                 SelectTabList();
                 SetTabNewTextAndIcon();

             }
         }

    </script>

    <script>

        function OnClientButtonClicking(sender, args) {

            var btn = args.get_item();
            if (btn.get_value() == 'Delete') {

                args.set_cancel(!confirm('Do you want to delete ?'));
            }
        }
            </script>
      <div class="container"  style="width: 100%">
          
                    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
                    </asp:ScriptManager>
    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" Width="300px" OnClientTabSelected="onClientTabSelected"
        CausesValidation="false" SelectedIndex="0" Skin="FlyCnRed_Rad" EnableEmbeddedSkins="false">
        <Tabs>
            <telerik:RadTab Text="View" PageViewID="rpList" Value="1" Width="150px" runat="server" ImageUrl="~/Images/Icons/ListIcon.png" Selected="True"></telerik:RadTab>
            <telerik:RadTab Text="New" PageViewID="rpAddEdit" Value="2" Width="150px" runat="server" ImageUrl="~/Images/Icons/NewIcon.png"></telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
           <div id="content">
            <div class="contentTopBar"></div>

               <telerik:RadMultiPage ID="RadMultiPage1" runat="server" Width="100%" SelectedIndex="0" CssClass="outerMultiPage">
            <telerik:RadPageView ID="rpList" runat="server">
                <div id="divList">


                   

                    <telerik:RadGrid ID="dtgUserMaster" runat="server" AllowPaging="true" AllowSorting="true"  PageSize="7"
                        OnNeedDataSource="dtgUserMaster_NeedDataSource" 
                        Skin="Silk" CssClass="outerMultiPage"  OnPreRender="dtgUserMaster_PreRender"  OnItemCommand="dtgUserMaster_ItemCommand"
                        >
                        <MasterTableView DataKeyNames="UserName,PassWord">

                            <Columns>
                            
                                  <telerik:GridButtonColumn CommandName="Delete" ButtonType="ImageButton" ImageUrl="~/Images/Cancel.png" Text="Delete" UniqueName="Delete" ConfirmText="Do you want to delete ?">
                                </telerik:GridButtonColumn>


                            </Columns>
                        </MasterTableView>

                    </telerik:RadGrid>


                </div>

            </telerik:RadPageView>
                   
            <telerik:RadPageView ID="rpAddEdit" runat="server">
                <%--  <asp:Label ID="lblerror" runat="server" Text="" ForeColor="Red"></asp:Label>--%>
                <uc1:ToolBar runat="server" ID="ToolBar" />
                 <div class="col-md-12 Span-One">
                    <div class="col-md-6">
                        <div class="form-group">
                <asp:Label ID="lblUserName" runat="server" Text="UserName" CssClass="control-label col-md-3"></asp:Label>
                              
                              <div class="col-md-9">
                                  <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" ></asp:TextBox>
                                    
                                   <span id="span2" 
                                         style="color: red; font-size: 15px;
 font-weight: 500; font-family: Trebuchet MS;">*</span>
                                   <asp:RequiredFieldValidator id="usernameReq"
              runat="server"
              ControlToValidate="txtUserName"
              ErrorMessage="Username is required!"
              SetFocusOnError="True" ForeColor="#CC0000" />
                </div>
                            </div>
                        </div>
                                 <div class="col-md-6">
                        <%--    <form class="form-horizontal" role="form">--%>
                        <div class="form-group">


                                          <asp:Label ID="lblPassWord" runat="server" Text="PassWord" CssClass="control-label col-md-3"></asp:Label>

                            <div class="col-md-9">


                         <asp:TextBox ID="txtPassWord" runat="server" CssClass="form-control" TextMode="Password" ></asp:TextBox>
                                     <span id="span1" runat="server" style="color: red; font-size: 15px; font-weight: 500; font-family: Trebuchet MS;">*</span>
                                  <asp:RequiredFieldValidator id="passwordReq"
              runat="server"
              ControlToValidate="txtPassWord"
              ErrorMessage="Password is required!"
              SetFocusOnError="True" Display="Dynamic" ForeColor="#CC0000" />

                            </div>
                        </div>
                        <%-- </form>--%>
                    </div>
                     </div>

                <div class="col-md-12 Span-One">
                    <div class="col-md-6">

                        <div class="form-group">
                <asp:Label ID="lblConfirmPassWord" runat="server" Text="Confirm PassWord" CssClass="control-label col-md-3"></asp:Label>
                              <div class="col-md-9">
                                  <asp:TextBox ID="txtConfirmPassWord" runat="server" CssClass="form-control" TextMode="Password" ></asp:TextBox>
                                     <span id="span3" 
                                         style="color: red; font-size: 15px;
 font-weight: 500; font-family: Trebuchet MS;">*</span>
                                   <asp:RequiredFieldValidator id="confirmPasswordReq"
              runat="server" 
              ControlToValidate="txtConfirmPassWord"
              ErrorMessage="Password confirmation is required!"
              SetFocusOnError="True" 
              Display="Dynamic" ForeColor="#CC0000" />
          <asp:CompareValidator id="comparePasswords" 
              runat="server"
              ControlToCompare="txtPassWord"
              ControlToValidate="txtConfirmPassWord"
              ErrorMessage="Your passwords do not match up!"
              Display="Dynamic" ForeColor="#CC0000" />
        
                </div>
                            </div>
                        </div>
                                 <div class="col-md-6">
                        <%--    <form class="form-horizontal" role="form">--%>
                        <div class="form-group">


                                          <asp:Label ID="lblEmailId" runat="server" Text="Email Id" CssClass="control-label col-md-3"></asp:Label>

                            <div class="col-md-9">


                         <asp:TextBox ID="txtEmailId" runat="server" CssClass="form-control" TextMode="Email"  ></asp:TextBox>
                                     <span id="span4" runat="server" style="color: red; font-size: 15px; font-weight: 500; font-family: Trebuchet MS;">*</span>
                                <asp:RequiredFieldValidator id="EmailReq"
              runat="server"
              ControlToValidate="txtEmailId"
              ErrorMessage="Email Id is required!"
              SetFocusOnError="True" Display="Dynamic" ForeColor="#CC0000" />

                                <asp:RegularExpressionValidator
        id="regEmail"
        ControlToValidate="txtEmailId"
        Text="(Invalid email)"
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
        Runat="server" ForeColor="#CC0000" />    
    
                            </div>
                        </div>
                        <%-- </form>--%>
                    </div>
                     </div>
                                  </telerik:RadPageView>
                </telerik:RadMultiPage>
         
               </div>
</div>
    
</asp:Content>
