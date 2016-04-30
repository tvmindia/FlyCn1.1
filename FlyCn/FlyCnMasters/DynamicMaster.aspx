<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="DynamicMaster.aspx.cs" Inherits="FlyCn.FlyCnMasters.DynamicMaster" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>

<asp:Content ID="phdDynamicMasterHead" ContentPlaceHolderID="head" runat="server">
      <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />   
</asp:Content>
<asp:Content ID="phdDynamicMasterContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../Scripts/jquery-1.11.3.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            parent.showTreeNode();
        });
        function ClearTextBox()
        {
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





        function OnClientTabSelecting(sender, eventArgs) {

            debugger;

            var tab = eventArgs.get_tab();

            var security = document.getElementById("hdnSecurityMaster").value;
            if (tab.get_text() == "New") {
                 <%=ToolBar.ClientID %>_SetEditVisible(false);
                <%=ToolBar.ClientID %>_SetAddVisible(false);
                <%=ToolBar.ClientID %>_SetSaveVisible(true);
                <%=ToolBar.ClientID %>_SetUpdateVisible(false);
                <%=ToolBar.ClientID %>_SetDeleteVisible(false);
            }

          <%--  PageSecurityCheck(security);
            if (PageSecurity.isWriteOnly) {
                if (tab.get_text() == "New") {

                    eventArgs.set_cancel(false);
                  
                }
                else
                    if (tab.get_text() == "Details") {
                        <%=ToolBar.ClientID %>_SetEditVisible(false);
                        <%=ToolBar.ClientID %>_SetAddVisible(false);
                        <%=ToolBar.ClientID %>_SetSaveVisible(false);
                        <%=ToolBar.ClientID %>_SetUpdateVisible(false);
                        <%=ToolBar.ClientID %>_SetDeleteVisible(false);
                    }
            }
            else
                if (PageSecurity.isReadOnly) {
                    if (tab.get_text() == "New") {
                       
                        AlertMsg(messages.EditModeNewClick);

                        eventArgs.set_cancel(true);
                    }
                    else
                        if (tab.get_text() == "Details") {
                            debugger;
                            <%=ToolBar.ClientID %>_SetEditVisible(false);
                            <%=ToolBar.ClientID %>_SetAddVisible(false);
                            <%=ToolBar.ClientID %>_SetSaveVisible(false);
                            <%=ToolBar.ClientID %>_SetUpdateVisible(false);
                            <%=ToolBar.ClientID %>_SetDeleteVisible(false);
                         
                        }

                }
                else if (PageSecurity.isEditOnly) {
                    if (tab.get_text() == "New") {
                       
                        AlertMsg(messages.EditModeNewClick);
                        eventArgs.set_cancel(true);
                    }
                    else
                        if (tab.get_text() == "Details") {
                            debugger;
                            <%=ToolBar.ClientID %>_SetEditVisible(false);
                            <%=ToolBar.ClientID %>_SetAddVisible(false);
                            <%=ToolBar.ClientID %>_SetSaveVisible(false);
                            <%=ToolBar.ClientID %>_SetUpdateVisible(false);
                            <%=ToolBar.ClientID %>_SetDeleteVisible(false);
                       
                        }
                }--%>



        }



        function onClientTabSelected(sender, args) {
            var tab = args.get_tab();
            if (tab.get_value() == '2') {//New tab selected

               <%-- try {

                    ClearTextBox();
                    EnableButtonsForNew();

                    var security = document.getElementById("hdnSecurityMaster").value;
                    PageSecurityCheck(security);

                    if ((PageSecurity.isWriteOnly)) {
                        debugger;
                        <%=ToolBar.ClientID %>_SetEditVisible(false);
                        <%=ToolBar.ClientID %>_SetAddVisible(false);
                        <%=ToolBar.ClientID %>_SetSaveVisible(true);
                        <%=ToolBar.ClientID %>_SetUpdateVisible(false);
                        <%=ToolBar.ClientID %>_SetDeleteVisible(false);
                      
                    }


                    if ((PageSecurity.isReadOnly)) {
                        debugger;
                        <%=ToolBar.ClientID %>_SetEditVisible(false);
                        <%=ToolBar.ClientID %>_SetAddVisible(false);
                        <%=ToolBar.ClientID %>_SetSaveVisible(false);
                        <%=ToolBar.ClientID %>_SetUpdateVisible(false);
                        <%=ToolBar.ClientID %>_SetDeleteVisible(false);
                     
                    }
                }
                catch (x)
                {
                    alert(x.message);
                }--%>

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
        <div class="container" style="width: 100%">

    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" Width="300px" OnClientTabSelected="onClientTabSelected"  OnClientTabSelecting="OnClientTabSelecting"  
        CausesValidation="False" SelectedIndex="1"  Skin="FlyCnRed_Rad" EnableEmbeddedSkins="false">
        <Tabs>
            <telerik:RadTab Text="View" PageViewID="rpList" Value="1" Width="150px" runat="server" ImageUrl="~/Images/Icons/ListIcon.png" Selected="True" TabIndex="0"></telerik:RadTab>
            <telerik:RadTab Text="New" PageViewID="rpAddEdit" Value="2" Width="150px" runat="server" ImageUrl="~/Images/Icons/NewIcon.png" TabIndex="1"></telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
              <div id="content">
            <div class="contentTopBar"></div>
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
                                        <telerik:GridButtonColumn CommandName="Delete" ButtonType="ImageButton" Text="Delete" UniqueName="Delete" ImageUrl="~/Images/Cancel.png"  ConfirmDialogType="RadWindow" ConfirmText="Are you sure">
                                        </telerik:GridButtonColumn>

                                          <telerik:GridButtonColumn CommandName="ViewDetailColumn" Text="ViewDetails" UniqueName="ViewDetailColumn"  ButtonType="ImageButton" Display="false" ImageUrl="~/Images/Document Next-WF.png"  ></telerik:GridButtonColumn>
                                    </Columns>
                                </MasterTableView>

                            </telerik:RadGrid>
                        </div>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="rpAddEdit" runat="server">
                         <div class="col-md-12" > <uc1:ToolBar runat="server" ID="ToolBar" /></div>
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
                  </div>
</div>

    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
