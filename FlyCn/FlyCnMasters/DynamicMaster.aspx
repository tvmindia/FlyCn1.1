<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="DynamicMaster.aspx.cs" Inherits="FlyCn.FlyCnMasters.DynamicMaster" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
    <style type="text/css">
  .RadWindow .rwDialogPopup
   {
    color:Blue !important;// customizing popup window
   }
  .RadWindow .rwWindowContent .rwPopupButton .rwInnerSpan
  {
     color:Red !important;// customizing the text in popup window
  }
</style>
    <script ></script>
    
      
     

    <script type="text/javascript">
        function onClientTabSelected(sender, args) {
            var tab = args.get_tab();       
            if (tab.get_value() == '2') {
            
                try {
                    $('textarea').empty();

                    $("input:text").val('');

                    <%=ToolBar.ClientID %>_SetAddVisible(false);
                    <%=ToolBar.ClientID %>_SetSaveVisible(true);
                    <%=ToolBar.ClientID %>_SetUpdateVisible(false);
                    <%=ToolBar.ClientID %>_SetDeleteVisible(false);
                }
                catch (x)
                {
                    alert(x.message);
                }

            }

            if (tab.get_value() == "1") {

                var tabStrip = $find("<%= RadTabStrip1.ClientID %>");
                var tab = tabStrip.findTabByValue("1");
                tab.select();
                var tab1 = tabStrip.findTabByValue("2");
                tab1.set_text("New");
                tab1.set_imageUrl('../Images/Icons/NewIcon.png');
            }

        }

        function OnClientButtonClicking(sender, args) {

            var btn = args.get_item();
            if (btn.get_value() == 'Delete') {

                args.set_cancel(!confirm('Do you want to delete ?'));
            }


        }

        


        </script>

  
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="inputMainContainer">
        <div  class="innerDiv">
            <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" Width="300px" OnClientTabSelected="onClientTabSelected"
             CausesValidation="False"   SelectedIndex="1" Skin="Silk" >
            <Tabs>
                <telerik:RadTab Text="View" PageViewID="rpList" Value="1" Width="150px" runat="server" ImageUrl="~/Images/Icons/ListIcon.png" Selected="True"  TabIndex="0"  ></telerik:RadTab>
                 <telerik:RadTab Text="New" PageViewID="rpAddEdit" Value="2" Width="150px" runat="server" ImageUrl="~/Images/Icons/NewIcon.png"  TabIndex="1"  ></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
            
                     <table style="width: 100%">
                         <tr>
                        
                             <td>
                 <telerik:RadMultiPage ID="RadMultiPage1" runat="server" Width="100%" SelectedIndex="0" CssClass="outerMultiPage">
                                    <telerik:RadPageView ID="rpList" runat="server"  >
                                        <div id="div2" >
         <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
</asp:ScriptManager>
             <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="0"
                 GridLines="None" OnNeedDataSource="RadGrid1_NeedDataSource1" AllowPaging="true" ItemStyle-HorizontalAlign="Left" AlternatingItemStyle-HorizontalAlign="Left"
                 PageSize="10" AllowAutomaticDeletes="True" OnItemCommand="RadGrid1_ItemCommand" 
                  OnPreRender="RadGrid1_PreRender" AllowMultiRowEdit="true"  DataKeyNames="Code"  CommandItemDisplay="Right" Skin="Silk">
<MasterTableView   >
     
    <Columns>
          <telerik:GridButtonColumn CommandName="EditData" Text="Edit" UniqueName="EditData"  ButtonType="ImageButton" ImageUrl="~/Images/Icons/Pencil-01.png" >
                    </telerik:GridButtonColumn>
         <telerik:GridButtonColumn CommandName="Delete"  ButtonType="ImageButton" Text="Delete" UniqueName="Delete" ConfirmDialogType="RadWindow" ConfirmText="Are you sure" >
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
                                     <asp:Label ID="lblmasterName" runat="server" CssClass="title"></asp:Label>
                                              <asp:HiddenField ID="HiddenField" runat="server" />
                                        <asp:HiddenField ID="HiddenField1" runat="server" />
                                    
        <br />

                                 
                                     <div id="div1" >
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
