﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="ActivityLibrary.aspx.cs" Inherits="FlyCn.Activities.ActivityLibrary" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <script type="text/javascript">
            function onClientTabSelected(sender,args) {
                var tab = args.get_tab();
                if (tab.get_value() == '2') {
                    //new clicked 
                     
                    try{
                        <%=ToolBar.ClientID %>_SetAddVisible(false);
                        <%=ToolBar.ClientID %>_SetSaveVisible(true);
                        <%=ToolBar.ClientID %>_SetUpdateVisible(false);
                        <%=ToolBar.ClientID %>_SetDeleteVisible(false);
                    } catch (x) { alert(x.message);}

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
                if (btn.get_value() == 'Delete') {

                    args.set_cancel(!confirm('Do you want to delete ?'));
                }
              

            }

        </script>
 <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>
    <div style="width: 100%; text-align: center" class="baseStyles">

         <div class="inputMainContainer" >
         
         <div class="innerDiv">
             <table style="width:100%">
                 <tr>
                     <td style="text-align:left">

                          <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" Width="300px" OnClientTabSelected="onClientTabSelected" CausesValidation="false" Skin="Silk" SelectedIndex="0">
            <Tabs>
                <telerik:RadTab Text="View" PageViewID="rpList" Value="1" Width="150px" runat="server" ImageUrl="~/Images/Icons/ListIcon.png"  ></telerik:RadTab>
                 <telerik:RadTab Text="New" PageViewID="rpAddEdit" Value="2" Width="150px" runat="server" ImageUrl="~/Images/Icons/NewIcon.png"  ></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>

                     </td>
                     <td style="text-align:right;">
                         <table style="margin:0 auto;">
                             <tr>
                                  <td class="InputCaption">Module</td>
                
                <td></td>
                <td>
                    <telerik:RadComboBox ID="rcmbModules" runat="server" AutoPostBack="true" CssClass="Initialcombo" Skin="Silk" ></telerik:RadComboBox>
                </td>
                             </tr>
                         </table>
                     </td>

                 </tr>

             </table>
       
        <telerik:RadMultiPage ID="RadMultiPage1" runat="server" Width="100%" SelectedIndex="0" CssClass="outerMultiPage">
            <telerik:RadPageView ID="rpList" runat="server">
                <table style="width:100%">
                    <tr>
                        <td colspan="3"></td>

                    </tr>
                    <tr>
                        <td style="width:1%"></td>
                         <td>
                             
                <telerik:RadGrid ID="rgActList" runat="server" OnNeedDataSource="rgActList_NeedDataSource" Skin="Silk" OnItemCommand="rgActList_ItemCommand">
                      <MasterTableView DataKeyNames="ModuleID,ModuleActID"   AutoGenerateColumns="False" HeaderStyle-HorizontalAlign="Center">
                         
                          <PagerStyle Mode="NumericPages" />
                <Columns>
                     <telerik:GridButtonColumn CommandName="EditData" ButtonType="ImageButton" ImageUrl="~/Images/Icons/Pencil-01.png" 
                            
                          Text="Edit" UniqueName="EditData" ></telerik:GridButtonColumn>

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
                  
                   <uc1:ToolBar runat="server" ID="ToolBar" />

                  <asp:Label ID="msg" runat="server" Text=""></asp:Label>

              </telerik:RadPageView>
        </telerik:RadMultiPage>
             </div>
    </div>
        </div>
</asp:Content>
