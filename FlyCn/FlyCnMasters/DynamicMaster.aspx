<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="DynamicMaster.aspx.cs" Inherits="FlyCn.FlyCnMasters.DynamicMaster" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>

<asp:Content ID="phdDynamicMasterHead" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .RadWindow .rwDialogPopup {
            color: Blue !important;
            /*customizing popup window;*/
        }

        .RadWindow .rwWindowContent .rwPopupButton .rwInnerSpan {
            color: Red !important;
            /* customizing the text in popup window;*/
        }
    </style>
    <script></script>




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


        function onClientTabSelected(sender, args) {
            var tab = args.get_tab();
            if (tab.get_value() == '2') {//New tab selected

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

        function OnClientButtonClicking(sender, args) {

            var btn = args.get_item();
            if (btn.get_value() == 'Delete') {

                args.set_cancel(!confirm('Do you want to delete ?'));
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
<asp:Content ID="phdDynamicMasterContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" Width="300px" OnClientTabSelected="onClientTabSelected"
        CausesValidation="False" SelectedIndex="1" Skin="Silk">
        <Tabs>
            <telerik:RadTab Text="View" PageViewID="rpList" Value="1" Width="150px" runat="server" ImageUrl="~/Images/Icons/ListIcon.png" Selected="True" TabIndex="0"></telerik:RadTab>
            <telerik:RadTab Text="New" PageViewID="rpAddEdit" Value="2" Width="150px" runat="server" ImageUrl="~/Images/Icons/NewIcon.png" TabIndex="1"></telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>

    <table style="width: 100%">
        <tr>

            <td>
                <telerik:RadMultiPage ID="RadMultiPage1" runat="server" Width="100%" SelectedIndex="0" CssClass="outerMultiPage">
                    <telerik:RadPageView ID="rpList" runat="server">
                        <div id="div2">
                            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
                            </asp:ScriptManager>
                            <telerik:RadGrid ID="dtgDynamicMasterGrid" runat="server" CellSpacing="0"
                                GridLines="None" OnNeedDataSource="dtgDynamicMasterGrid_NeedDataSource1" AllowPaging="true" ItemStyle-HorizontalAlign="Left" AlternatingItemStyle-HorizontalAlign="Left"
                                PageSize="7" AllowAutomaticDeletes="True" OnItemCommand="dtgDynamicMasterGrid_ItemCommand" Width="984px"
                                OnPreRender="dtgDynamicMasterGrid_PreRender" AllowMultiRowEdit="true" DataKeyNames="Code" CommandItemDisplay="Right" Skin="Silk">
                                <MasterTableView>

                                    <Columns>
                                        <telerik:GridButtonColumn CommandName="EditData" ItemStyle-Width="10px" Text="Edit" UniqueName="EditData" ButtonType="ImageButton" ImageUrl="~/Images/Icons/Pencil-01.png">
                                        </telerik:GridButtonColumn>
                                        <telerik:GridButtonColumn CommandName="Delete" ButtonType="ImageButton" Text="Delete" UniqueName="Delete" ConfirmDialogType="RadWindow" ConfirmText="Are you sure">
                                        </telerik:GridButtonColumn>

                                    </Columns>
                                </MasterTableView>

                            </telerik:RadGrid>
                        </div>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="rpAddEdit" runat="server">
                        <uc1:ToolBar runat="server" ID="ToolBar" />
                        <div>


                            <div>
                            </div>
                            <asp:Label ID="lblmasterName" runat="server" CssClass="PageHeading"></asp:Label>
                            <asp:HiddenField ID="HiddenField" runat="server" />
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                        <asp:HiddenField ID="HiddenUniqueIdentifier" runat="server" />
                            <br />
                            <br />

                            <div id="div1">
                                <div id="placeholder" runat="server" style="text-align: left"></div>
                                <br />
                                <br />

                            </div>


                        </div>

                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>


    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
