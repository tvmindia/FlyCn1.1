<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="EnggViewData.aspx.cs" Inherits="FlyCn.EngineeredDataList.EnggViewData" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" /> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <script src="../Scripts/jquery-1.11.3.min.js"></script>
    <script>

        function OnClientButtonClicking(sender, args) {
            var btn = args.get_item();
         //debugger;
       //if (btn.get_value() == 'Save') {
           
       //    args.set_cancel(!Validate());
           
            
       //}
        //if (btn.get_value() == 'Update') {
        //    parent.RevisionHistroyDeleteNode();

        //    args.set_cancel(true);
        //}

        //if (btn.get_value() == 'Edit') {

           
        //}

        }



     
   function ClearTextBox()
   {
       $('textarea').empty();

       $("input:text").val('');
   }
   function EnableButtonsForNew() {
       debugger;
          <%=ToolBar.ClientID %>_SetAddVisible(false);
          <%=ToolBar.ClientID %>_SetSaveVisible(true);
          <%=ToolBar.ClientID %>_SetUpdateVisible(false);
          <%=ToolBar.ClientID %>_SetDeleteVisible(false);
          <%=ToolBar.ClientID %>_SetEditVisible(false);

      }

        function SelectTabList() {
            debugger;
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
              debugger;
              <%=ToolBar.ClientID %>_SetAddVisible(false);
              <%=ToolBar.ClientID %>_SetSaveVisible(false);
              <%=ToolBar.ClientID %>_SetUpdateVisible(false);
              <%=ToolBar.ClientID %>_SetDeleteVisible(false);
              <%=ToolBar.ClientID %>_SetEditVisible(false);
              SelectTabList();
              SetTabNewTextAndIcon();

          }

      }

        function Validate() {
            displayMessage(messageType.Error, messages.MandatoryFieldsGeneral);
            return false;
        }
        </script>


      <div class="container" style="width:100%">
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

                 <table style="width:100%">
                <tr>
                    <td>&nbsp
                    </td>
                    <td>
                         <uc1:ToolBar runat="server" ID="ToolBar" />

                         <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" CssClass="outerMultiPage">
                            <telerik:RadPageView ID="rpList" runat="server">

                                <div id="divList" style="width:100%">
                                    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
                                    </asp:ScriptManager>
                                       
                                    <telerik:RadGrid ID="dtgEnggDataList" runat="server"  OnItemCommand="dtgEnggDataList_ItemCommand"   OnPreRender="dtgEnggDataList_PreRender"   OnNeedDataSource="dtgEnggDataList_NeedDataSource"  
                                Skin="Silk" width="100%">
                                <MasterTableView DataKeyNames="" CssClass="myclass">

                                    <Columns>
                                        <telerik:GridButtonColumn CommandName="EditData" Text="Edit" UniqueName="EditData" ButtonType="ImageButton" ImageUrl="~/Images/Icons/Pencil-01.png">
                                        </telerik:GridButtonColumn> 
                                       

                                    </Columns>
                                </MasterTableView>
 
                            </telerik:RadGrid>
                                
                                    </div>
                                    </telerik:RadPageView>   
                             <telerik:RadPageView ID="rpAddEdit" runat="server">
                                   
                                          <div id="placeholder" runat="server" style="text-align: left" class="col-md-12 Span-One"></div>
                                     </telerik:RadPageView>
                            
                               
                                </telerik:RadMultiPage>

                        </td>
                    
                    </tr>
                     </table>
                </div>
          </div>
    <asp:HiddenField ID="HiddenField" runat="server" />
      <asp:HiddenField ID="HiddenField1" runat="server" />
</asp:Content>
