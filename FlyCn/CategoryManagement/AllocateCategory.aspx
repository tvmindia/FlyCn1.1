<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="AllocateCategory.aspx.cs" Inherits="FlyCn.CategoryManagement.AllocateCategory" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../Content/themes/base/jquery-ui.css" rel="stylesheet" />
     <link href="../Content/themes/FlyCnRider/Splitter.FlyCnRider.css" rel="stylesheet" />
    <link href="../Content/themes/base/jquery-ui.css" rel="stylesheet" />
    <script src="../Scripts/jquery.1.9.1.min.js"></script>
    <script src="../Scripts/ToolBar.js"></script>
    <script src="../Scripts/Messages.js"></script>
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      
    <script src="../Scripts/jquery-1.11.3.min.js"></script>
     <script src="../Content/themes/FlyCnBlue/js/selectize.js"></script>
    <script src="../Content/themes/FlyCnBlue/js/index.js"></script>
    
  
    <!-----bootstrap js--->
     
    <script src="../Content/themes/FlyCnBlue/js/bootstrap.min.js"></script>
    <script src="../Content/themes/FlyCnBlue/js/bootstrap-datepicker.js"></script>
          
    <style>
        html, body {
  overflow-y:hidden;
  height:100%;
}
     #tabs li a {
            color: white;
            display: block;
            text-decoration: none;
            font-size: small;
            font-weight: lighter;
        }  
/*#menu ul li.selected {
    background: #910000;
    color:#FFFFFF;
}*/

/*#menu li {
    display: block;
    float: left;
    background: black;
}
#menu a {
    display: block;
    float: left;
    margin-right: 17px;
    padding: 5px 8px;
    text-decoration: none;
    font: 20px Georgia, "Times New Roman", Times, serif;
    color: #FFFFFF;
}*/
    </style>
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager><div style="margin-left:3%;">
    <asp:Label ID="lblTitle" runat="server" Text="Category Management" CssClass="PageHeading"></asp:Label></div>
     <div class="container" style="width: 100%;height:500px;">
           <div id="content" style="max-height:600px;overflow-x:auto;overflow-y:auto;">
          <div class="col-md-12" id="menu" style="min-height:500px;max-height:600px;">
               <ul id="tabs" class="navigation">
                    <li class='active'><a href="#" onclick="MyTab1(this);" id="tabs1" runat="server">Allocate Tags</a></li>
                    <li><a href="#" onclick="MyTab2(this);" id="tabs2" runat="server">Available Tags</a></li>
                </ul>
           
                  <div id="tab1">
         
                 
        <uc1:ToolBar runat="server" ID="ToolBar"/> 
                      <div>
                           <telerik:RadGrid ID="dtgAllocateTags" runat="server"  GridLines="None" CellSpacing="0"  AlwaysVisible="true" AllowPaging="true" Width="100%" CssClass="outerMultiPage" AllowSorting="true"  PageSize="6" OnNeedDataSource="dtgAllocateTags_NeedDataSource" OnPreRender="dtgAllocateTags_PreRender" OnItemCommand="dtgAllocateTags_ItemCommand" OnItemDataBound="dtgAllocateTags_ItemDataBound" >
                                     <HeaderStyle  HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <AlternatingItemStyle HorizontalAlign="Left" />
                                    <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>
                    <MasterTableView  AutoGenerateColumns="true" ShowHeadersWhenNoRecords="true" ShowHeader="true" NoMasterRecordsText="No Activities have been added." InsertItemPageIndexAction="ShowItemOnFirstPage" InsertItemDisplay="Top" DataKeyNames="">
                         <Columns>
                               <telerik:GridCheckBoxColumn HeaderText="SELECT" DataType="System.Boolean" UniqueName="Allocatecheck"></telerik:GridCheckBoxColumn>
                               <telerik:GridBoundColumn HeaderText="KeyField" DataField="KeyField" UniqueName="KeyField" Display="false"></telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>

                </telerik:RadGrid>
                          </div>
                      </div>

                       <div id="tab2">
         
                 
        <uc1:ToolBar runat="server" ID="ToolBar1" /> 
                      <div>
                           <telerik:RadGrid ID="dtgAvailableTags" runat="server" GridLines="None" CellSpacing="0"  AlwaysVisible="true" AllowPaging="true" Width="100%" CssClass="outerMultiPage" AllowSorting="true"  PageSize="6" OnNeedDataSource="dtgAvailableTags_NeedDataSource" OnPreRender="dtgAvailableTags_PreRender" OnItemCommand="dtgAvailableTags_ItemCommand" OnItemDataBound="dtgAvailableTags_ItemDataBound">
                                     <HeaderStyle  HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <AlternatingItemStyle HorizontalAlign="Left" />
                                    <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>
                    <MasterTableView  AutoGenerateColumns="True" ShowHeadersWhenNoRecords="true" ShowHeader="true" NoMasterRecordsText="No Activities have been added." InsertItemPageIndexAction="ShowItemOnFirstPage" InsertItemDisplay="Top" DataKeyNames="">
                         <Columns>
                             
                        <telerik:GridCheckBoxColumn HeaderText="SELECT" DataType="System.Boolean" UniqueName="Modulescheck"></telerik:GridCheckBoxColumn>
                              
                              </Columns>
                    </MasterTableView>

                </telerik:RadGrid>
                          </div>
                      </div>
                  </div>
              </div>
        
         </div>
    <asp:HiddenField id="hdfFieldName" runat="server"/>
    <asp:HiddenField ID="hdfAllocatedDataKey" runat="server" />
    <asp:HiddenField ID="hdfkeyField" runat="server" />
     <asp:HiddenField ID="selected_tab" runat="server" />
      <script>
    
   
          $(document).ready(function () {
              var myHidden = document.getElementById('<%= selected_tab.ClientID %>');
              document.getElementById("tab1").style.display = "block";
              document.getElementById("tab2").style.display = "none";
              document.getElementById("tab1").selected = true;
              
              if (myHidden.value == 2) {
                  document.getElementById("tab2").style.display = "block";
                  document.getElementById("tab1").style.display = "none";
              }
              parent.showTreeNode();
              $('#menu ul li a').click(function (ev) {
                  $('#menu ul li').removeClass('selected');
                  $(ev.currentTarget).parent('li').addClass('selected');
              });
          });
          function MyTab1(Id) {
              var myHidden = document.getElementById('<%= selected_tab.ClientID %>');
              myHidden.value = 1;
              funtab2 = document.getElementById("tab2");
              funtab2.style.display = "none";
              document.getElementById("tab1").style.display = "block";
          }
          function MyTab2(Id) {
              var myHidden = document.getElementById('<%= selected_tab.ClientID %>');
              myHidden.value = 2;
              funtab1 = document.getElementById("tab1");
              funtab1.style.display = "none";
              document.getElementById("tab2").style.display = "block";
          }
          function OnClientButtonClicking(sender, args) {
              var btn = args.get_item();
              if (btn.get_value() == 'Allocate') {
                  args.set_cancel(!validateDesc());
              }
          }
          function validateDesc()
          {
              var flag="";
              var grid = $find("<%=dtgAvailableTags.ClientID %>");
              var masterTableView = grid.get_masterTableView();
              if (masterTableView != null) {
                  var gridItems = masterTableView.get_dataItems();
                  var i;
                  for (i = 0; i < gridItems.length; ++i) {
                      var gridItem = gridItems[i];
                      var cell = gridItem.get_cell("Modulescheck");
                      var controlsArray = cell.getElementsByTagName('input');
                      if (controlsArray.length > 0) {
                          var rdo = controlsArray[0];
                          if (rdo.checked == true) {
                              flag = "1";
                              return true;
                              
                          }
                         
                         
                      }
                     
                  }
              }
              if (flag != "1") {
                 displayMessage(messageType.Error, messages.checkboxNotChecked);
                 return false;
              }
          }

          function OnClientButtonClickingDetail(sender, args) {
              var btn = args.get_item();
              if (btn.get_value() == 'DeAllocate') {
                  args.set_cancel(!validatesDeAllocate());
              }
          }
          function validates()
          {
              return true;
          }
          function validatesDeAllocate()
          {
              var flag = "";
              var grid = $find("<%=dtgAllocateTags.ClientID %>");
              var masterTableView = grid.get_masterTableView();
              if (masterTableView != null) {
                  var gridItems = masterTableView.get_dataItems();
                  var i;
                  for (i = 0; i < gridItems.length; ++i) {
                      var gridItem = gridItems[i];
                      var cell = gridItem.get_cell("Allocatecheck");
                      var controlsArray = cell.getElementsByTagName('input');
                      if (controlsArray.length > 0) {
                          var rdo = controlsArray[0];
                          if (rdo.checked == true) {
                              flag = "1";
                              return true;

                          }


                      }

                  }
              }
              if (flag != "1") {
                  displayMessage(messageType.Error, messages.checkboxNotChecked);
                  return false;
              }
          }
          </script>

</asp:Content>
