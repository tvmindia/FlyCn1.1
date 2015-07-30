<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="ActivityLibrary.aspx.cs" Inherits="FlyCn.Activities.ActivityLibrary" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%; text-align: center" class="baseStyles">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <script type="text/javascript">
            function onClientTabSelected(sender,args) {
                var tab = args.get_tab();

            }


        </script>
 <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>
        <table style="width: 50%">
            <tr>
                <td class="InputCaption">Module</td>
                
                <td></td>
                <td>
                    <telerik:RadComboBox ID="rcmbModules" runat="server" AutoPostBack="true" CssClass="combo" ></telerik:RadComboBox>
                </td>
            </tr>
        </table>
        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" Width="100%" OnClientTabSelected="onClientTabSelected" CausesValidation="false">
            <Tabs>
                <telerik:RadTab Text="View" PageViewID="rpList" Value="1" Width="100px" runat="server"></telerik:RadTab>
                 <telerik:RadTab Text="New" PageViewID="rpAddEdit" Value="2" Width="100px" runat="server"></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage ID="RadMultiPage1" runat="server" Width="100%" SelectedIndex="0" >
            <telerik:RadPageView ID="rpList" runat="server">

                List grid

            </telerik:RadPageView>
              <telerik:RadPageView ID="rpAddEdit" runat="server">
                  
                   add /edit page



              </telerik:RadPageView>
        </telerik:RadMultiPage>

    </div>
</asp:Content>
