<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="EnggViewData.aspx.cs" Inherits="FlyCn.EngineeredDataList.EnggViewData" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
      function OnClientButtonClicking(sender, args) {
        var btn = args.get_item();
        if (btn.get_value() == 'Save') {
           
            args.set_cancel(!validate());
           
            
        }
        if (btn.get_value() == 'Update') {
            parent.RevisionHistroyDeleteNode();

            args.set_cancel(!validate());
        }

        if (btn.get_value() == 'Edit') {

           
        }

      }
        </script>


      <div class="container" style="width: 100%">
          <asp:Label ID="lblTableName" runat="server" Text=""></asp:Label>
        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" Width="300px" OnClientTabSelected="onClientTabSelected" OnClientTabSelecting="OnClientTabSelecting"
            CausesValidation="false" SelectedIndex="0" Skin="FlyCnRed_Rad" EnableEmbeddedSkins="false">

            <Tabs>
                <telerik:RadTab Text="View" PageViewID="rpList" Value="1" Width="150px" runat="server" ImageUrl="~/Images/Icons/ListIcon.png" Selected="True"></telerik:RadTab>
                <telerik:RadTab Text="New" PageViewID="rpAddEdit" Value="2" Width="150px" runat="server" ImageUrl="~/Images/Icons/NewIcon.png"></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>

            <div id="content">
              
            <div class="contentTopBar"></div>

                 <table style="width:100%">
                <tr>
                    <td>&nbsp
                    </td>
                    <td>
                         <uc1:ToolBar runat="server" ID="ToolBar" />

                         <telerik:RadMultiPage ID="RadMultiPage1" runat="server" Width="100%" SelectedIndex="0" CssClass="outerMultiPage">
                            <telerik:RadPageView ID="rpList" runat="server">

                                <div id="divList" style="width: 100%">
                                    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
                                    </asp:ScriptManager>
                                       <telerik:RadGrid ID="dtgEnggDataList" runat="server"  OnItemCommand="dtgEnggDataList_ItemCommand"   OnPreRender="dtgEnggDataList_PreRender"   OnNeedDataSource="dtgEnggDataList_NeedDataSource"  
                                Skin="Silk" CssClass="myclass" >
                                <MasterTableView DataKeyNames="" CssClass="myclass">

                                    <Columns>
                                        <telerik:GridButtonColumn CommandName="EditData" Text="Edit" UniqueName="EditData" ButtonType="ImageButton" ImageUrl="~/Images/Icons/Pencil-01.png">
                                        </telerik:GridButtonColumn>
                                        <telerik:GridButtonColumn CommandName="Delete" ButtonType="ImageButton" Text="Delete" UniqueName="Delete" ConfirmDialogType="RadWindow" ConfirmText="Are you sure">
                                        </telerik:GridButtonColumn>

                                    </Columns>
                                </MasterTableView>

                            </telerik:RadGrid>

                                    </div>
                                </telerik:RadPageView>
                                </telerik:RadMultiPage>
                        













                        </td>
                    </tr>
                     </table>
                </div>
          </div>
</asp:Content>
