<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="CWP.aspx.cs" Inherits="FlyCn.WorkPacks.ConstructionWorkPacks" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <%-- Registration--%>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <script src="../Scripts/jquery-1.8.2.js"></script>
     <script src="../Scripts/jquery-1.8.2.min.js"></script>
     <script src="../Scripts/jquery-ui-1.8.24.js"></script>
     <script src="../Scripts/jquery-ui-1.8.24.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script src="../Scripts/ToolBar.js"></script>
    <script src="../Scripts/Messages.js"></script>
     
     <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePartialRendering="true" EnablePageMethods="true"  >
       
    </asp:ScriptManager>
    <div>
    <asp:Label ID="lblTitle" runat="server" Text="Construction Work Packs" CssClass="PageHeading"></asp:Label></div>
    <div class="container" style="width: 100%">
         <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" Width="200px" OnClientTabSelected="onClientTabSelected" OnClientTabSelecting="OnClientTabSelecting"
            CausesValidation="false" SelectedIndex="0" Skin="FlyCnRed_Rad" EnableEmbeddedSkins="false"  >

            <Tabs>
                <telerik:RadTab Text="View" PageViewID="rpList" Value="1" Width="100px" Height="25px" runat="server" ImageUrl="~/Images/Icons/ListIcon.png" Selected="True"></telerik:RadTab>
                <telerik:RadTab Text="New" PageViewID="rpAddEdit" Value="2" Width="100px"  Height="25px" runat="server" ImageUrl="~/Images/Icons/NewIcon.png"></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
         <div id="content" style="height:600px;overflow-y:hidden;">


            <div class="contentTopBar"></div>
              <table style="width: 100%">
                   <tr>
                       <td>
                              <telerik:RadMultiPage ID="RadMultiPage1" runat="server" Width="100%" SelectedIndex="0" CssClass="outerMultiPage">

                                     <telerik:RadPageView ID="rpList" runat="server">
                                         <div id="divList" style="width: 100%;text-align:center">

                                             <telerik:RadGrid runat="server" ID="dtgCWPHeaderGrid" CellSpacing="0" GridLines="None" AllowPaging="true" AllowAutomaticDeletes="false" AllowAutomaticUpdates="false" PageSize="10" Width="99%" OnNeedDataSource="dtgCWPHeaderGrid_NeedDataSource">
                                                   <HeaderStyle  HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <AlternatingItemStyle HorizontalAlign="Left" />
                                        <ClientSettings>
                                            <Selecting AllowRowSelect="true" EnableDragToSelectRows="false" />                 
                                        </ClientSettings>
                                          <MasterTableView AutoGenerateColumns="False" DataKeyNames="" ShowHeadersWhenNoRecords="true" ShowHeader="true" NoMasterRecordsText="No Items have been added." InsertItemPageIndexAction="ShowItemOnFirstPage" InsertItemDisplay="Top">
                                               <Columns>
                                                   </Columns>
                                              </MasterTableView>
                                             </telerik:RadGrid>
                                             </div>
                                         </telerik:RadPageView>
                                   <telerik:RadPageView ID="rpAddEdit" runat="server">
                                          <uc1:ToolBar runat="server" ID="ToolBar" />
                                        <div class="col-md-12 Span-One">
                                              <div class="col-md-6">

                                        <div class="form-group">
                                            <asp:Label ID="lbl1" CssClass="control-label col-md-5" runat="server" Text="Label1"></asp:Label>   
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtlbl1" Enabled="true" CssClass="form-control AutoGenTextbox" ClientIDMode="Static" runat="server"></asp:TextBox>
                                              
                                            </div>
                                        </div>
                                    </div>
                                              <div class="col-md-6">

                                        <div class="form-group">
                                            <asp:Label ID="lbl2" CssClass="control-label col-md-5" runat="server" Text="Label2"></asp:Label>   
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txt2" Enabled="true" CssClass="form-control AutoGenTextbox" ClientIDMode="Static" runat="server"></asp:TextBox>
                                              
                                            </div>
                                        </div>
                                    </div>
                                              <div class="col-md-6">

                                        <div class="form-group">
                                            <asp:Label ID="lbl3" CssClass="control-label col-md-5" runat="server" Text="Label3"></asp:Label>   
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txt3" Enabled="true" CssClass="form-control AutoGenTextbox" ClientIDMode="Static" runat="server"></asp:TextBox>
                                              
                                            </div>
                                        </div>
                                    </div>
                                              <div class="col-md-6">

                                        <div class="form-group">
                                            <asp:Label ID="lbl4" CssClass="control-label col-md-5" runat="server" Text="Label4"></asp:Label>   
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txt4" Enabled="true" CssClass="form-control AutoGenTextbox" ClientIDMode="Static" runat="server"></asp:TextBox>
                                              
                                            </div>
                                        </div>
                                    </div>
                                                                                      <div class="col-md-6">

                                        <div class="form-group">
                                            <asp:Label ID="lbl5" CssClass="control-label col-md-5" runat="server" Text="Label5"></asp:Label>   
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txt5" Enabled="true" CssClass="form-control AutoGenTextbox" ClientIDMode="Static" runat="server"></asp:TextBox>
                                              
                                            </div>
                                        </div>
                                    </div>
                                            
                                                                                      <div class="col-md-6">

                                        <div class="form-group">
                                            <asp:Label ID="lbl6" CssClass="control-label col-md-5" runat="server" Text="Label6"></asp:Label>   
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txt6" Enabled="true" CssClass="form-control AutoGenTextbox" ClientIDMode="Static" runat="server"></asp:TextBox>
                                              
                                            </div>
                                        </div>
                                    </div>
                                            </div>

                                        <div class="col-md-12">
                                     <div class="col-md-6">&nbsp;</div>
                                     <div class="col-md-6">&nbsp;</div>
                                      <div class="col-md-6"></div>
                                       <div id="modal_dialog" style="display: none; width: 1200px!important; height: 700px!important;overflow-x:hidden;overflow-y:hidden;">
                                      <iframe id="ContentApprovers" runat="server" style="width: 1000px; height: 600px;"></iframe>
                                      </div>
                                       <div class="content white">
                                       <div class="accordion-container">
                                         <a href="#" class="accordion-toggle" id="IDAccordion">Details<span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>
                                         <div class="accordion-content">
                                                <div id="rpCWPDetailList" style="width: 100%;text-align:center">
                                            <telerik:RadGrid ID="dtgCWPDetailGrid" runat="server" CellSpacing="0" GridLines="None"  AllowPaging="true" AllowAutomaticDeletes="false" AllowAutomaticUpdates="false" PageSize="10" Width="99%" OnNeedDataSource="dtgCWPDetailGrid_NeedDataSource">
                                                <HeaderStyle  HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left"/>
                                        <AlternatingItemStyle HorizontalAlign="Left" />
                                        <ClientSettings>
                                            <Selecting AllowRowSelect="true" EnableDragToSelectRows="false" />                                           
                                        </ClientSettings>
                                                <MasterTableView AutoGenerateColumns="False" DataKeyNames="" ShowHeadersWhenNoRecords="true" ShowHeader="true" NoMasterRecordsText="No Items have been added." InsertItemPageIndexAction="ShowItemOnFirstPage" InsertItemDisplay="Top">
                                                    <Columns>
                                                        </Columns>
                                                    </MasterTableView>
                                            </telerik:RadGrid>
                                            </div>
                                         <iframe id="ContentIframe" name="CWPDetails" style="height: 500px; width: 100%; overflow: hidden;" runat="server">
                                         </iframe>   
                                         </div>
                                       </div>
                                      </div>
                                            </div>
                                       </telerik:RadPageView>
                                  </telerik:RadMultiPage>
                       </td>
                   </tr>
                  </table>
             </div>
        </div>
    <script type="text/javascript">
        function OnClientTabSelecting(sender, eventArgs) {

            var tab = eventArgs.get_tab();
                if (tab.get_text() == "New") {
                    parent.collapsenode();
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
           
        function onClientTabSelected(sender, args) {

            var tab = args.get_tab();

            if (tab.get_value() == '2') {

                parent.collapsenode();
                hideMe();
               
                try {
                  
                    
                        <%=ToolBar.ClientID %>_SetEditVisible(false);
                        <%=ToolBar.ClientID %>_SetAddVisible(false);
                        <%=ToolBar.ClientID %>_SetSaveVisible(true);
                        <%=ToolBar.ClientID %>_SetUpdateVisible(false);
                        <%=ToolBar.ClientID %>_SetDeleteVisible(false);
                      
                    }


                   
             
                catch (x) {
                    alert(x.message);
                }
                
               
            }
            if (tab.get_value() == "1") {
                //parent.collapsenode();
                //parent.HideTreeNode();
                var tabStrip = $find("<%= RadTabStrip1.ClientID %>");
                var tab = tabStrip.findTabByValue("1");
                tab.select();
                var tab1 = tabStrip.findTabByValue("2");
                tab1.set_text("New");
                tab1.set_imageUrl('../Images/Icons/NewIcon.png');
               
            }

        }
        $(document).ready(function () {
            $('.accordion-toggle').on('click', function (event) {

                event.preventDefault();
                OpenDetailAccordion(this);
            });

            parent.collapsenode();
        });


        function OpenDetailAccordion(id) {

            if (id != undefined)//accordion called from accordion click functionjs
            {
                var accordion = $(id);
                var accordionContent = accordion.next('.accordion-content');
                var accordionToggleIcon = accordion.children('.toggle-icon');

                // toggle accordion link open class
                accordion.toggleClass("open");
                // toggle accordion content
                accordionContent.slideToggle(250);

                // change plus/minus icon
                if (accordion.hasClass("open")) {
                    accordionToggleIcon.html("<i class='fa fa-minus-circle'></i>");
                } else {
                    accordionToggleIcon.html("<i class='fa fa-plus-circle'></i>");
                }
            }
            if (id == undefined)//accordion called from code behind scrpt register after CWPHeaderSave
            {
                id = document.getElementById('IDAccordion');
                var accordion = $(id);
                var accordionContent = accordion.next('.accordion-content');
                var accordionToggleIcon = accordion.children('.toggle-icon');

                // toggle accordion link open class
                accordion.toggleClass("open");
                // toggle accordion content
                accordionContent.slideToggle(250);

                // change plus/minus icon
                if (accordion.hasClass("open")) {
                    accordionToggleIcon.html("<i class='fa fa-minus-circle'></i>");
                } else {
                    accordionToggleIcon.html("<i class='fa fa-plus-circle'></i>");
                }
            }
        }
    </script>
</asp:Content>
