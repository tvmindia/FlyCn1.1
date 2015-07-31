<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="ActivityLibrary.aspx.cs" Inherits="FlyCn.Activities.ActivityLibrary" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <script type="text/javascript">
            function onClientTabSelected(sender,args) {
                var tab = args.get_tab();

            }


        </script>
 <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>
    <div style="width: 100%; text-align: center" class="baseStyles">

         <div class="inputMainContainer" >
        <table style="width: 40%">
            <tr><td colspan="3">&nbsp;</td></tr>
            <tr>
                <td class="InputCaption">Module</td>
                
                <td></td>
                <td>
                    <telerik:RadComboBox ID="rcmbModules" runat="server" AutoPostBack="true" CssClass="Initialcombo" Skin="Silk" ></telerik:RadComboBox>
                </td>
            </tr>
              <tr><td colspan="3">&nbsp;</td></tr>
        </table>
         <div class="innerDiv">
        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" Width="400px" OnClientTabSelected="onClientTabSelected" CausesValidation="false" Skin="Silk" SelectedIndex="0">
            <Tabs>
                <telerik:RadTab Text="View" PageViewID="rpList" Value="1" Width="200px" runat="server"></telerik:RadTab>
                 <telerik:RadTab Text="New" PageViewID="rpAddEdit" Value="2" Width="200px" runat="server"></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage ID="RadMultiPage1" runat="server" Width="100%" SelectedIndex="0" CssClass="outerMultiPage">
            <telerik:RadPageView ID="rpList" runat="server">

                List grid

            </telerik:RadPageView>
              <telerik:RadPageView ID="rpAddEdit" runat="server">
                  
                   add /edit page



              </telerik:RadPageView>
        </telerik:RadMultiPage>
             </div>
    </div>
        </div>
</asp:Content>
