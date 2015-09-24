<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="Personal.aspx.cs" Inherits="FlyCn.Personal" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="phdPersonalHead" ContentPlaceHolderID="head" runat="server">




    <script type="text/javascript">
        function ClearTextBox() {
            $('textarea').empty();

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
        function validate() {
            var Code = document.getElementById('<%=txtCode.ClientID %>').value;
            var Name = document.getElementById('<%=txtName.ClientID %>').value;
            var Nationality = document.getElementById('<%=txtNationality.ClientID %>').value;
            var Company = document.getElementById('<%=RadComboCompany.ClientID %>').value;
            if (Code == "" || Name == "" || Nationality == "" || Company == "") {

                displayMessage(messageType.Error, messages.MandatoryFieldsGeneral);

                return false;

            }

            else {

                return true;
            }
        }
    </script>

    <script type="text/javascript">
        function onClientTabSelected(sender, args) {
            
            var tab = args.get_tab();
            if (tab.get_value() == '2') {

                try {

                    ClearTextBox();
                    EnableButtonsForNew();
                    document.getElementById("<%=ContentIframe.ClientID %>").style.display = "none";
                    document.getElementById("<%=lblQualificationframe.ClientID %>").style.display = "";


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
            if (btn.get_value() == 'Save') {

                args.set_cancel(!validate());
            }
            if (btn.get_value() == 'Update') {

                args.set_cancel(!validate());
            }

        }
    </script>

  

    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Input</title>
    <!-----bootstrap css--->

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css" />
    <link href='https://fonts.googleapis.com/css?family=Roboto:400,300,300italic,400italic,700,700italic,900' rel='stylesheet' type='text/css' />
    <link href="Content/themes/FlyCnBlue/css/datepicker.css" rel="stylesheet" type="text/css" />
    <!-----bootstrap css--->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
    <link href="../Content/themes/FlyCnBlue/css/stylesheet.css" rel="stylesheet" />

    <link href="../Content/themes/FlyCnBlue/css/selectize.css" rel="stylesheet" type="text/css" />
    <link href="../Content/themes/FlyCnBlue/css/accodin.css" rel="stylesheet" type="text/css" />
    <!-----main css--->
    <link href="../Content/themes/FlyCnBlue/css/style.css" rel="stylesheet" type="text/css" />
    <!-----main css--->

</asp:Content>

<asp:Content ID="phdPersonalContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">

    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" Width="300px" OnClientTabSelected="onClientTabSelected"
        CausesValidation="false" SelectedIndex="0" Skin="Silk">
        <Tabs>
            <telerik:RadTab Text="View" PageViewID="rpList" Value="1" Width="150px" runat="server" ImageUrl="~/Images/Icons/ListIcon.png" Selected="True"></telerik:RadTab>
            <telerik:RadTab Text="New" PageViewID="rpAddEdit" Value="2" Width="150px" runat="server" ImageUrl="~/Images/Icons/NewIcon.png"></telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>


  
        <telerik:RadMultiPage ID="RadMultiPage1" runat="server" Width="100%" SelectedIndex="0" CssClass="outerMultiPage">
            <telerik:RadPageView ID="rpList" runat="server">
                <div id="divList">


                    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
                    </asp:ScriptManager>

                    <telerik:RadGrid ID="dtgPersonnelGrid" runat="server" AllowPaging="true" AllowSorting="true"  PageSize="7"
                        OnNeedDataSource="dtgPersonnelGrid_NeedDataSource" OnItemCommand="dtgPersonnelGrid_ItemCommand"
                        Skin="Silk" CssClass="outerMultiPage"
                        OnPreRender="dtgPersonnelGrid_PreRender">
                        <MasterTableView DataKeyNames="Code">

                            <Columns>
                                <telerik:GridButtonColumn CommandName="EditData" ButtonType="ImageButton" ImageUrl="~/Images/Icons/Pencil-01.png" Text="Edit" UniqueName="EditData">
                                </telerik:GridButtonColumn>
                                <telerik:GridButtonColumn CommandName="Delete" ButtonType="ImageButton" Text="Delete" UniqueName="Delete" ConfirmDialogType="RadWindow" ConfirmText="Are you sure">
                                </telerik:GridButtonColumn>

                            </Columns>
                        </MasterTableView>

                    </telerik:RadGrid>


                </div>

            </telerik:RadPageView>

            <telerik:RadPageView ID="rpAddEdit" runat="server">
                <%--  <asp:Label ID="lblerror" runat="server" Text="" ForeColor="Red"></asp:Label>--%>
                <uc1:ToolBar runat="server" ID="ToolBar" />
                <%--   <div class="accordion-container"> <a href="#" class="accordion-toggle">Lorem Ipsum is simply <span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>
          <div class="accordion-content">
                --%>


                <div class="col-lg-12 Span-One">
                    <div class="col-lg-6">

                        <div class="form-group">

                            <asp:Label ID="lblCode" CssClass="control-label col-lg-3" runat="server" Text="Code"></asp:Label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="txtCode" CssClass="form-control" runat="server"></asp:TextBox>
                                <span id="span2" runat="server" style="color: red; font-size: 15px; font-weight: 500; font-family: Trebuchet MS;">*</span>
                                <asp:RequiredFieldValidator ID="rfv" runat="server" ErrorMessage="Enter code."
                                    Display="Dynamic" SetFocusOnError="true"
                                    ForeColor="Red"
                                    ValidationGroup="Group"
                                    ControlToValidate="txtCode">
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <%-- </form>--%>
                    </div>
                    <div class="col-lg-6">
                        <%--    <form class="form-horizontal" role="form">--%>
                        <div class="form-group">


                            <asp:Label ID="lblStartDate" CssClass="control-label col-lg-3" runat="server" Text="Start Date"></asp:Label>

                            <div class="col-lg-9">


                                <telerik:RadDatePicker ID="RadStartDate" runat="server"
                                    Width="170px" TabIndex="2" AutoPostBack="false">
                                    <DateInput DateFormat="dd/MMM/yyyy" DisplayDateFormat="dd/MMM/yyyy" InvalidStyleDuration="100"
                                        runat="server">
                                    </DateInput>
                                    <Calendar runat="server">
                                    </Calendar>
                                </telerik:RadDatePicker>
                            </div>
                        </div>
                        <%-- </form>--%>
                    </div>
                </div>



                <div class="col-lg-12 Span-One">
                    <div class="col-lg-6">

                        <div class="form-group">


                            <asp:Label ID="lblName" CssClass="control-label col-lg-3" runat="server" Text="Name"></asp:Label>
                            <div class="col-lg-9">

                                <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
                                <span id="span1" runat="server" style="color: red; font-size: 15px; font-weight: 500; font-family: Trebuchet MS;">*</span>


                            </div>
                        </div>
                        <%-- </form>--%>
                    </div>
                    <div class="col-lg-6">
                        <%--    <form class="form-horizontal" role="form">--%>
                        <div class="form-group">

                            <asp:Label ID="lblEndDate" CssClass="control-label col-lg-3" runat="server" Text="End Date"></asp:Label>



                            <div class="col-lg-9">

                                <telerik:RadDatePicker ID="RadEndDate" runat="server"
                                    Width="170px" TabIndex="2" AutoPostBack="false" MinDate="<%# DateTime.Now.Date %>">
                                    <DateInput DateFormat="dd/MMM/yyyy" DisplayDateFormat="dd/MMM/yyyy" InvalidStyleDuration="100"
                                        runat="server">
                                    </DateInput>
                                    <Calendar runat="server">
                                    </Calendar>
                                </telerik:RadDatePicker>
                            </div>
                        </div>
                        <%-- </form>--%>
                    </div>
                </div>


                <div class="col-lg-12 Span-One">
                    <div class="col-lg-6">

                        <div class="form-group">


                            <asp:Label ID="lblNationality" CssClass="control-label col-lg-3" runat="server" Text="Nationality"></asp:Label>

                            <div class="col-lg-9">

                                <asp:TextBox ID="txtNationality" CssClass="form-control" runat="server"></asp:TextBox>
                                <span id="span3" runat="server" style="color: red; font-size: 15px; font-weight: 500; font-family: Trebuchet MS;">*</span>

                            </div>
                        </div>
                        <%-- </form>--%>
                    </div>
                    <div class="col-lg-6">
                        <%--    <form class="form-horizontal" role="form">--%>
                        <div class="form-group">

                            <asp:Label ID="lblPassportNo" CssClass="control-label col-lg-3" runat="server" Text="Passport No"></asp:Label>



                            <div class="col-lg-9">

                                <asp:TextBox ID="txtPassportNo" CssClass="form-control" runat="server"></asp:TextBox>

                            </div>
                        </div>
                        <%-- </form>--%>
                    </div>
                </div>
                <div class="col-lg-12 Span-One">
                    <div class="col-lg-6">
                        <%--    <form class="form-horizontal" role="form">--%>
                        <div class="form-group">
                            <asp:Label ID="lblRemarks" CssClass="control-label col-lg-3" runat="server" Text="Remarks"></asp:Label>





                            <div class="col-lg-9">
                                <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" TextMode="MultiLine" Width="170px"></asp:TextBox>


                            </div>
                        </div>
                        <%-- </form>--%>
                    </div>
                </div>
                <%-- 
              </div>
                    </div>  --%>
             <div class="col-lg-12">

      <div class="content white">
                          <div class="accordion-container"> <a href="#" class="accordion-toggle">Company Details  
                              <span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>
                              
                             <div class="accordion-content"> 
                      

                                <div class="col-lg-12 Span-One ">
                                    <div class="col-lg-6 ">

                                        <div class="form-group">

                                            <asp:Label ID="lblCompany" CssClass="control-label col-lg-3" runat="server" Text="Company"></asp:Label>



                                            <div class="col-lg-9">

                                                <telerik:RadComboBox ID="RadComboCompany" runat="server" Width="170px"
                                                    EmptyMessage="Select a Company" EnableLoadOnDemand="True" ShowMoreResultsBox="true"
                                                    EnableVirtualScrolling="true" OnItemsRequested="RadComboCompany_ItemsRequested">
                                                </telerik:RadComboBox>
                                                <span id="span4" runat="server" style="color: red; font-size: 15px; font-weight: 500; font-family: Trebuchet MS;">*</span>

                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>
                                    <div class="col-lg-6">
                                        <%--    <form class="form-horizontal" role="form">--%>
                                        <div class="form-group">

                                            <asp:Label ID="lblGenericPosition" CssClass="control-label col-lg-3" runat="server" Text="Generic Position"></asp:Label>




                                            <div class="col-lg-9">

                                                <asp:TextBox ID="txtGenericPosition" CssClass="form-control" runat="server"></asp:TextBox>

                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>
                                </div>



                                <div class="col-lg-12 Span-One">
                                    <div class="col-lg-6">

                                        <div class="form-group">

                                            <asp:Label ID="lblIsSubcontract" CssClass="control-label col-lg-3" runat="server" Text="Is Subcontract"></asp:Label>



                                            <div class="col-lg-9">

                                                <telerik:RadComboBox
                                                    ID="RadcomboSubcontract"
                                                    runat="server" Width="170px">
                                                    <Items>
                                                        <telerik:RadComboBoxItem runat="server" Text="Yes" Value="1" />
                                                        <telerik:RadComboBoxItem runat="server" Text="No" Value="0" />
                                                    </Items>
                                                </telerik:RadComboBox>

                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>
                                    <div class="col-lg-6">
                                        <%--    <form class="form-horizontal" role="form">--%>
                                        <div class="form-group">

                                            <asp:Label ID="lblContractPosition" CssClass="control-label col-lg-3" runat="server" Text="Contract Position"></asp:Label>




                                            <div class="col-lg-9">

                                                <asp:TextBox ID="txtContractPosition" CssClass="form-control" runat="server"></asp:TextBox>

                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>
                                </div>



                                <div class="col-lg-12 Span-One">
                                    <div class="col-lg-6">

                                        <div class="form-group">

                                            <asp:Label ID="lblEmpNo" CssClass="control-label col-lg-3" runat="server" Text="Emp No"></asp:Label>


                                            <div class="col-lg-9">

                                                <asp:TextBox ID="txtEmpNo" CssClass="form-control" runat="server"></asp:TextBox>

                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>
                                    <div class="col-lg-6">
                                        <%--    <form class="form-horizontal" role="form">--%>
                                        <div class="form-group">

                                            <asp:Label ID="lblHierarchyPosition" CssClass="control-label col-lg-3" runat="server" Text="Hierarchy Position"></asp:Label>




                                            <div class="col-lg-9">

                                                <asp:TextBox ID="txtHierarchyPosition" CssClass="form-control" runat="server"></asp:TextBox>

                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>
                                </div>



                                <div class="col-lg-12 Span-One">
                                    <div class="col-lg-6">

                                        <div class="form-group">

                                            <asp:Label ID="lblWorkHours" CssClass="control-label col-lg-3" runat="server" Text="Work Hours"></asp:Label>



                                            <div class="col-lg-9">

                                                <asp:TextBox ID="txtWorkHours" CssClass="form-control" runat="server"></asp:TextBox>
                                                <asp:RegularExpressionValidator
                                                    ID="RegularExpressionValidator6"
                                                    runat="server"
                                                    ControlToValidate="txtWorkHours"
                                                    ValidationExpression="([0-9])[0-9]*[.]?[0-9]*"
                                                    ErrorMessage="Invalid Entry" ForeColor="Red"></asp:RegularExpressionValidator>

                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>
                                    <div class="col-lg-6">
                                        <%--    <form class="form-horizontal" role="form">--%>
                                        <div class="form-group">

                                            <asp:Label ID="lblCategory" runat="server" CssClass="control-label col-lg-3" Text="Category"></asp:Label>




                                            <div class="col-lg-9">

                                                <asp:TextBox ID="txtCategory" CssClass="form-control" runat="server"></asp:TextBox>


                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>
                                </div>

                                <div class="col-lg-12 Span-One">
                                    <div class="col-lg-6">

                                        <div class="form-group">
                                            <asp:Label ID="lblOTEligible" CssClass="control-label col-lg-3" runat="server" Text="OT Eligible"></asp:Label>
                                            <div class="col-lg-9">

                                                <telerik:RadComboBox
                                                    ID="RadComboOTEligible"
                                                    runat="server" Width="170px">
                                                    <Items>
                                                        <telerik:RadComboBoxItem runat="server" Text="Yes" Value="1" />
                                                        <telerik:RadComboBoxItem runat="server" Text="No" Value="0" />
                                                    </Items>
                                                </telerik:RadComboBox>

                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>
                                    <div class="col-lg-6">
                                        <%--    <form class="form-horizontal" role="form">--%>
                                        <div class="form-group">

                                            <asp:Label ID="lblDescipline" CssClass="control-label col-lg-3" runat="server" Text="Descipline"></asp:Label>

                                            <div class="col-lg-9">

                                                <asp:TextBox ID="txtDescipline" CssClass="form-control" runat="server"></asp:TextBox>


                                            </div>
                                        </div>
                                        <%-- </form>--%>
                                    </div>
                                </div>
                            </div>
                        </div>

                       <div class="accordion-container"> <a href="#" class="accordion-toggle">Qualification
                              <span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>
                              
                             <div class="accordion-content"> 
                                <%--    <div id="framediv" runat="server" style="overflow: hidden;">--%>

                                <iframe id="ContentIframe"
                                    name="PQualification" style="height: 300px; width: 100%; display: none; overflow: hidden;"
                                    runat="server"></iframe>
                                                             <asp:Label ID="lblQualificationframe" runat="server" Text="First Insert Personnel Information and Click Save Button " ForeColor="Tomato"></asp:Label>

                                <%-- </div>--%>
                            </div>
                        </div>
                    </div>

              
                
                 </div>
                <hr />



            </telerik:RadPageView>
            <%--<%--  onload="javascript: setSize();" ,onload="autoResize('ContentIframe');"--%>
        </telerik:RadMultiPage>
   
        </div>

   <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $('.accordion-toggle').on('click', function (event) {
            event.preventDefault();
            // create accordion variables
            var accordion = $(this);
            var accordionContent = accordion.next('.accordion-content');
            var accordionToggleIcon = $(this).children('.toggle-icon');

            // toggle accordion link open class
            accordion.toggleClass("open");
            // toggle accordion content
            accordionContent.slideToggle(250);

            // change plus/minus icon
            if (accordion.hasClass("open")) {
                accordionToggleIcon.html("<i class='fa fa-minus-circle'></i>");
            } else {
                accordionToggleIcon.html("<i class='fa fa-plus-circle'></i>");
            }
        });
    });
</script>
   
    <script src="../Content/themes/FlyCnBlue/js/selectize.js"></script>
    <script src="../Content/themes/FlyCnBlue/js/index.js"></script>
    

    <!-----bootstrap js--->

    <script src="../Content/themes/FlyCnBlue/js/bootstrap.min.js"></script>
    <script src="../Content/themes/FlyCnBlue/js/bootstrap-datepicker.js"></script>
   
</asp:Content>

