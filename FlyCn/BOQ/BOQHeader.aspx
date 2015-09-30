<%-- Registration  --%>

<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="BOQHeader.aspx.cs" Inherits="FlyCn.BOQ.BOQHeader" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- Registration--%>

    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Input</title>

    <!-----bootstrap css--->
    <link href="../Content/themes/FlyCnBlue/css/roboto_google_api.css" rel="stylesheet" />
    <link href="Content/themes/FlyCnBlue/css/datepicker.css" rel="stylesheet" type="text/css" />
    <!-----bootstrap css--->
    <link href="../Content/themes/FlyCnBlue/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/themes/FlyCnBlue/css/stylesheet.css" rel="stylesheet" />

    <link href="../Content/themes/FlyCnBlue/css/selectize.css" rel="stylesheet" type="text/css" />
    <link href="../Content/themes/FlyCnBlue/css/accodin.css" rel="stylesheet" type="text/css" />
    <!-----main css--->
    <link href="../Content/themes/FlyCnBlue/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Content/themes/FlyCnRed_Rad/TabStrip.FlyCnRed_Rad.css" rel="stylesheet" />
     <script src="../Content/themes/FlyCnBlue/js/jquery.min.js"></script>

    <!-----main css--->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>

    <div class="container" style="width: 100%">



        <!-----FORM SECTION---->
        <!-----SECTION TABLE---->

        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" Width="300px" OnClientTabSelected="onClientTabSelected"
            CausesValidation="false" SelectedIndex="0" Skin="FlyCnRed_Rad" EnableEmbeddedSkins="false">

            <Tabs>
                <telerik:RadTab Text="View" PageViewID="rpList" Value="1" Width="150px" runat="server" ImageUrl="~/Images/Icons/ListIcon.png" Selected="True"></telerik:RadTab>
                <telerik:RadTab Text="New" PageViewID="rpAddEdit" Value="2" Width="150px" runat="server" ImageUrl="~/Images/Icons/NewIcon.png"></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <div id="content">
            <div class="contentTopBar"></div>
            <table style="width: 100%">
                <tr>
                     
                    <td>

                        <telerik:RadMultiPage ID="RadMultiPage1" runat="server" Width="100%" SelectedIndex="0" CssClass="outerMultiPage">
                            <telerik:RadPageView ID="rpList" runat="server">

                                <div id="divList" style="width: 100%;text-align:center">





                                    <telerik:RadGrid ID="dtgBOQGrid" runat="server" CellSpacing="0" GridLines="None" OnNeedDataSource="dtgBOQGrid_NeedDataSource" AllowPaging="true" AllowAutomaticDeletes="false" AllowAutomaticUpdates="false" OnItemCommand="dtgBOQGrid_ItemCommand"
                                        PageSize="10" Width="99%"  >
                                        <HeaderStyle  HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <AlternatingItemStyle HorizontalAlign="Left" />
                                        <ClientSettings>
                                            <Selecting AllowRowSelect="true" EnableDragToSelectRows="false" />
                                           
                                        </ClientSettings>

                                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="DocumentID,ProjectNo">

                                            <Columns>

                                                <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="ChkChild" runat="server" onclick="HeaderUncheck(this);" AutoPostBack="False" />
                                                    </ItemTemplate>
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="Chkheader" runat="server" onclick="Check(this);" AutoPostBack="False" />
                                                    </HeaderTemplate>
                                                </telerik:GridTemplateColumn>

                                                <telerik:GridButtonColumn CommandName="EditDoc" ButtonType="ImageButton" ImageUrl="~/Images/Icons/Pencil-01.png" Text="Edit" UniqueName="EditData">
                                                </telerik:GridButtonColumn>

                                                <telerik:GridBoundColumn HeaderText="Project No" DataField="ProjectNo" UniqueName="ProjectNo" Display="false"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="DocumentID" DataField="DocumentID" UniqueName="DocumentID"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Document No" DataField="DocumentNo" UniqueName="DocumentNo"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Title" DataField="DocumentTitle" UniqueName="DocumentTitle"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Client Doc No" DataField="ClientDocNo" UniqueName="ClientDocNo"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Revision No" DataField="RevisionNo" UniqueName="RevisionNo"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Document Date" DataField="DocumentDate" UniqueName="DocumentDate" DataType="System.DateTime" DataFormatString="{0:dd/MMM/yyyy}"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Document Owner" DataField="DocumentOwner" UniqueName="DocumentOwner"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Created Date" DataField="CreatedDate" UniqueName="CreatedDate" DataType="System.DateTime" DataFormatString="{0:dd/MMM/yyyy}"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Document Status" DataField="DocumentStatus" UniqueName="DocumentStatus"></telerik:GridBoundColumn>


                                            </Columns>
                                        </MasterTableView>

                                    </telerik:RadGrid>


                                </div>
                            </telerik:RadPageView>

                            <telerik:RadPageView ID="rpAddEdit" runat="server">
                                <uc1:ToolBar runat="server" ID="ToolBar" />


                                <!-----SECTION TABLE---->
                                <!---SECTION ONE--->
                                <div class="col-md-12 Span-One">
                                    <div class="col-md-6">

                                        <div class="form-group">

                                            <asp:Label ID="lblDocumentno" CssClass="control-label col-md-3" runat="server" Text="Document No"></asp:Label>
                                            <div class="col-md-9">

                                                <asp:TextBox ID="txtDocumentno" Enabled="false" runat="server" CssClass="form-control" BackColor="Gray"></asp:TextBox>
                                                <asp:HiddenField ID="hiddenFiedldProjectno" runat="server" />
                                                <asp:HiddenField ID="hiddenFieldDocumentID" runat="server" />
                                                <asp:HiddenField ID="hiddenFieldRevisionID" runat="server" ClientIDMode="Static" />

                                            </div>
                                        </div>

                                    </div>
                                    <div class="col-md-6">

                                        <div class="form-group">


                                            <asp:Label ID="lblClientdocumentnot" CssClass="control-label col-md-3" runat="server" Text="Client Document No*"></asp:Label>
                                            <div class="col-md-9">

                                                <asp:TextBox ID="txtClientdocumentno" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                                <!---SECTION ONE--->

                                <!---SECTION TWO--->
                                <div class="col-md-12 Span-One">
                                    <div class="col-md-6">

                                        <div class="form-group">

                                            <asp:Label ID="lblRevisionno" CssClass="control-label col-md-3" runat="server" Text="Revision No*"></asp:Label>
                                            <div class="col-md-9">

                                                <asp:TextBox ID="txtRevisionno" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                    </div>


                                    <div class="col-md-6">

                                        <div class="form-group">

                                            <asp:Label ID="lblDocumentdate" CssClass="control-label col-md-3" runat="server" Text="Document Date*"></asp:Label>
                                            <div class="col-md-9">
                                                <telerik:RadDatePicker ID="RadDocumentDate" runat="server"></telerik:RadDatePicker>
                                                <%-- <asp:TextBox ID="txtDocumentdate" CssClass="form-control" runat="server"></asp:TextBox>--%>
                                            </div>
                                        </div>

                                    </div>



                                    <div class="col-md-6">

                                        <div class="form-group">

                                            <asp:Label ID="lblDocumenttitle" CssClass="control-label col-md-3" runat="server" Text="Document Title*"></asp:Label>
                                            <div class="col-md-9">

                                                <asp:TextBox ID="txtDocumenttitle" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="col-md-6">

                                        <div class="form-group">


                                            <asp:Label ID="lblRemarks" CssClass="control-label col-md-3" runat="server" Text="Remarks*"></asp:Label>
                                            <div class="col-md-9">

                                                <asp:TextBox ID="txtRemarks" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                    </div>

                                 



                                </div>

                                   <div class="col-md-12">
                                        
                                        <div class="content white">
                                            <div class="accordion-container">
                                                <a href="#" class="accordion-toggle">Details<span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>
                                                <div class="accordion-content">

                                                    <iframe id="ContentIframe" name="BOQDetails" style="height: 500px; width: 100%; overflow: hidden;" runat="server"></iframe>
                                                     
                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                <!---SECTION TWO--->

                            </telerik:RadPageView>

                        </telerik:RadMultiPage>
                    </td>
                </tr>
            </table>
        </div>

        <!-----FORM SECTION---->
    </div>

    <!--<JavaScrict>-->
    <script type="text/javascript">
        function validate() {
            var Clientdocumentno = document.getElementById('<%=txtClientdocumentno.ClientID %>').value;
        var Revisionno = document.getElementById('<%=txtRevisionno.ClientID %>').value;
        var DocumentDate = document.getElementById('<%=RadDocumentDate.ClientID %>').value;
        var Documenttitle = document.getElementById('<%=txtDocumenttitle.ClientID %>').value;
        var Remarks = document.getElementById('<%=txtRemarks.ClientID%>').value;
        if (Clientdocumentno == "" || Revisionno == "" || DocumentDate == "" || Documenttitle == "" || Remarks == "") {

            displayMessage(messageType.Error, messages.MandatoryFieldsGeneral);

            return false;

        }

        else {

            return true;
        }
    }

    function HeaderUncheck(obj) {
        var IsChecked = obj.checked;
        if (!IsChecked) {
            var chkBox = $('input[id$="Chkheader"]');
            chkBox[0].checked = false;
        }

    }
    function Check(obj) {

        var IsChecked = obj.checked;
        var grid = $find("<%=dtgBOQGrid.ClientID %>");
        var MasterTable = grid.get_masterTableView();
        var Rows = MasterTable.get_dataItems();
        if (IsChecked == true) {
            for (var i = 0; i < Rows.length; i++) {
                MasterTable.get_dataItems()[i].findElement("ChkChild").checked = true;
            }
        }

        if (IsChecked == false) {
            for (var i = 0; i < Rows.length; i++) {
                MasterTable.get_dataItems()[i].findElement("ChkChild").checked = false;
            }
        }
    }



    function onClientTabSelected(sender, args) {

        var tab = args.get_tab();
        if (tab.get_value() == '2') {
            //new clicked 
            /*   $('input[type=text]').each(function () {
                   $(this).val('');
               });*/


            document.getElementById('<%=txtDocumentno.ClientID %>').value = "-------System Code-------";



            try {
                <%=ToolBar.ClientID %>_SetAddVisible(false);
                <%=ToolBar.ClientID %>_SetSaveVisible(true);
                <%=ToolBar.ClientID %>_SetUpdateVisible(false);
                <%=ToolBar.ClientID %>_SetDeleteVisible(false);

            }
            catch (x) { alert(x.message); }



        }

        if (tab.get_value() == "1") {

            var tabStrip = $find("<%= RadTabStrip1.ClientID %>");
            var tab = tabStrip.findTabByValue("1");
            tab.select();
            var tab1 = tabStrip.findTabByValue("2");
            tab1.set_text("New");
        }

    }

    function OnClientButtonClicking(sender, args) {
        var btn = args.get_item();
        if (btn.get_value() == 'Save') {

            args.set_cancel(!validate());
        }
        if (btn.get_value() == 'Update') {

            args.set_cancel(!validate());
        }



    }



    </script>
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
    <!--<JavaScrict ends here>-->

</asp:Content>































