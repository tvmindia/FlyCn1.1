<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="EnggViewData.aspx.cs" Inherits="FlyCn.EngineeredDataList.EnggViewData" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script src="../Scripts/jquery-1.11.3.min.js"></script>
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


        function onClientTabSelected(sender, args) {
            debugger;
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

        </script>


      <div class="container">
          <asp:Label ID="lblTableName" runat="server" Text=""></asp:Label>
        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" Width="300px" OnClientTabSelected="onClientTabSelected"
            CausesValidation="false" SelectedIndex="0" Skin="FlyCnRed_Rad" EnableEmbeddedSkins="false">

            <Tabs>
                <telerik:RadTab Text="View" PageViewID="rpList" Value="1" Width="150px" runat="server" ImageUrl="~/Images/Icons/ListIcon.png" Selected="True" TabIndex="0"></telerik:RadTab>
                <telerik:RadTab Text="New" PageViewID="rpAddEdit" Value="2" Width="150px" runat="server" ImageUrl="~/Images/Icons/NewIcon.png" TabIndex="1" ></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>

             <div id="content">
              
            <div class="contentTopBar"></div>

                 <table>
                <tr>
                    <td>&nbsp
                    </td>
                    <td>
                         <uc1:ToolBar runat="server" ID="ToolBar" />

                         <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" CssClass="outerMultiPage">
                            <telerik:RadPageView ID="rpList" runat="server">

                                <div id="divList">
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
                             <telerik:RadPageView ID="rpAddEdit" runat="server">
                                   
                                          <div id="placeholder" runat="server" style="text-align: left"></div>
                                     </telerik:RadPageView>
                            
                               
                                </telerik:RadMultiPage>
                        













                        </td>
                    </tr>
                     </table>
                </div>
          </div>
</asp:Content>
