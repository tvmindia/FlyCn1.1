﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="ActivityLibrary.aspx.cs" Inherits="FlyCn.Activities.ActivityLibrary" %>

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
                    <telerik:RadComboBox ID="rcmbModules" runat="server" AutoPostBack="true" CssClass="Initialcombo"   ></telerik:RadComboBox>
                </td>
            </tr>
              <tr><td colspan="3">&nbsp;</td></tr>
        </table>
         <div class="innerDiv">
        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" Width="300px" OnClientTabSelected="onClientTabSelected" CausesValidation="false"   SelectedIndex="0">
            <Tabs>
                <telerik:RadTab Text="View" PageViewID="rpList" Value="1" Width="150px" runat="server" ImageUrl="~/Images/Icons/ListIcon.png"  ></telerik:RadTab>
                 <telerik:RadTab Text="New" PageViewID="rpAddEdit" Value="2" Width="150px" runat="server" ImageUrl="~/Images/Icons/NewIcon.png"  ></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage ID="RadMultiPage1" runat="server" Width="100%" SelectedIndex="0" CssClass="outerMultiPage">
            <telerik:RadPageView ID="rpList" runat="server">
                <table style="width:100%">
                    <tr>
                        <td colspan="3"></td>

                    </tr>
                    <tr>
                        <td style="width:1%"></td>
                         <td>
                             
                <telerik:RadGrid ID="rgActList" runat="server" OnNeedDataSource="rgActList_NeedDataSource"  >
                      <MasterTableView DataKeyNames="ModuleID,ModuleActID"   AutoGenerateColumns="False" HeaderStyle-HorizontalAlign="Center">
                         
                          <PagerStyle Mode="NumericPages" />
                <Columns>
                    <telerik:GridBoundColumn DataField="ModuleID" HeaderText="ModuleID" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ModuleActID" HeaderText="Act ID"  >
                    </telerik:GridBoundColumn>
                     
                    <telerik:GridBoundColumn DataField="FullDesc" HeaderText="FullDesc"  >
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ShortDesc" HeaderText="ShortDesc">
                    </telerik:GridBoundColumn>
                </Columns>

                      </MasterTableView>

                </telerik:RadGrid>
                         </td>
                         <td style="width:1%"></td>
                    </tr>
                    <tr>
                        <td colspan="3"></td>

                    </tr>
                </table>
              
            </telerik:RadPageView>
              <telerik:RadPageView ID="rpAddEdit" runat="server">
                  
                   add /edit page



              </telerik:RadPageView>
        </telerik:RadMultiPage>
             </div>
    </div>
        </div>
</asp:Content>
