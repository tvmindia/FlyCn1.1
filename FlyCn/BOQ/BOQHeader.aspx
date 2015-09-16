<%-- Registration  --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="BOQHeader.aspx.cs" Inherits="FlyCn.BOQ.BOQHeader" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik"%>
<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%-- Registration--%>

<meta name="viewport" content="width=device-width, initial-scale=1" />
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Input</title>

<!-----bootstrap css--->
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css" />
<link href='https://fonts.googleapis.com/css?family=Roboto:400,300,300italic,400italic,700,700italic,900' rel='stylesheet' type='text/css' />
<link href="Content/themes/FlyCnBlue/css/datepicker.css" rel="stylesheet" type="text/css" />
<!-----bootstrap css--->
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
<link href="../Content/themes/FlyCnBlue/css/stylesheet.css" rel="stylesheet" />

<link href="../Content/themes/FlyCnBlue/css/selectize.css" rel="stylesheet" type="text/css" />
<link href="../Content/themes/FlyCnBlue/css/accodin.css" rel="stylesheet" type="text/css" />
<!-----main css--->
<link href="../Content/themes/FlyCnBlue/css/style.css" rel="stylesheet" type="text/css" />
<!-----main css--->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
           <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePartialRendering="true">
</asp:ScriptManager>

<div class="container">
  

 
<!-----FORM SECTION----> 
<!-----SECTION TABLE---->
   
        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" Width="300px" OnClientTabSelected="onClientTabSelected"
             CausesValidation="false"   SelectedIndex="0" Skin="Silk">
            
            <Tabs>
                 <telerik:RadTab Text="View" PageViewID="rpList" Value="1" Width="150px" runat="server" ImageUrl="~/Images/Icons/ListIcon.png" Selected="True" ></telerik:RadTab>
                 <telerik:RadTab Text="New" PageViewID="rpAddEdit" Value="2" Width="150px" runat="server" ImageUrl="~/Images/Icons/NewIcon.png"  ></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>

        <table style="width:100%">
    <tr>
        <td>
            &nbsp
        </td>
        <td>

        <telerik:RadMultiPage ID="RadMultiPage1" runat="server" Width="100%" SelectedIndex="0" CssClass="outerMultiPage">
            <telerik:RadPageView ID="rpList" runat="server">
               
          <div id="divList" style="width:100%">

      
                     
    
<telerik:RadGrid ID="RadGrid1" runat="server"  CellSpacing="0" GridLines="None" AllowPaging="true" OnNeedDataSource="RadGrid1_NeedDataSource" PageSize="10" Width="984px" Skin="Silk" >
<MasterTableView AutoGenerateColumns="False" DataKeyNames="ProjectNo,IDNo,EILType">
    <Columns>
     <telerik:GridBoundColumn HeaderText="Project No" DataField="ProjectNo" UniqueName="ProjectNo"></telerik:GridBoundColumn> 
     <telerik:GridBoundColumn HeaderText="ID No" DataField="IDNo" UniqueName="IDNo"></telerik:GridBoundColumn>
     <telerik:GridBoundColumn HeaderText="LinkIDNo" DataField="LinkIDNo" UniqueName="LinkIDNo"></telerik:GridBoundColumn> 
     <telerik:GridBoundColumn HeaderText="EILType" DataField="EILType" UniqueName="EILType"></telerik:GridBoundColumn> 
     <telerik:GridBoundColumn HeaderText="OpenBy" DataField="OpenBy" UniqueName="OpenBy"></telerik:GridBoundColumn> 
     <telerik:GridBoundColumn HeaderText="OpenDt" DataField="OpenDt" UniqueName="OpenDt" DataType="System.DateTime"  DataFormatString="{0:M/d/yyyy}"></telerik:GridBoundColumn> 
     <telerik:GridButtonColumn CommandName="EditData" Text="Edit" UniqueName="EditData" ButtonType="ImageButton" ImageUrl="~/Images/Icons/Pencil-01.png"></telerik:GridButtonColumn>     
     <telerik:GridButtonColumn CommandName="DeleteColumn" Text="Delete" UniqueName="DeleteColumn" ButtonType="ImageButton" ImageUrl="~/Images/Cancel.png" ConfirmDialogType="RadWindow" ConfirmText="Are you sure, you want to delete this item ?">
      </telerik:GridButtonColumn>
     </Columns>
 </MasterTableView>            
 </telerik:RadGrid>
     
</div>
</telerik:RadPageView>
          
    <telerik:RadPageView ID="rpAddEdit" runat="server">
        <uc1:ToolBar runat="server" ID="ToolBar" />

           
       <!-----SECTION TABLE---->
  <!---SECTION ONE--->
  <div class="col-lg-12 Span-One">
    <div class="col-lg-6">
      <form class="form-horizontal" role="form">
        <div class="form-group">
        
            <asp:Label ID="lblDocumentno" CssClass="control-label col-lg-3" runat="server" Text="Document No"></asp:Label>
          <div class="col-lg-9">
            
            <asp:TextBox ID="txtDocumentno" Enabled="false" runat="server" CssClass="form-control" BackColor="Gray"></asp:TextBox>
          </div>
        </div>
      </form>
    </div>
    <div class="col-lg-6">
      <form class="form-horizontal" role="form">
        <div class="form-group">
       
          
            <asp:Label ID="lblClientdocumentnot" CssClass="control-label col-lg-3" runat="server" Text="Client Document No"></asp:Label>
          <div class="col-lg-9">
           
              <asp:TextBox ID="txtClientdocumentno" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
        </div>
      </form>
    </div>
  </div>
  <!---SECTION ONE---> 

  <!---SECTION TWO--->
  <div class="col-lg-12 Span-One">
    <div class="col-lg-6">
      <form class="form-horizontal" role="form">
        <div class="form-group">
         
            <asp:Label ID="lblRevisionno" CssClass="control-label col-lg-3" runat="server" Text="Revision No"></asp:Label>
          <div class="col-lg-9">
         
              <asp:TextBox ID="txtRevisionno" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
        </div>
      </form>
    </div>


    <div class="col-lg-6">
      <form class="form-horizontal" role="form">
        <div class="form-group">
          
            <asp:Label ID="lblDocumentdate" CssClass="control-label col-lg-3" runat="server" Text="Document Date"></asp:Label>
          <div class="col-lg-9">
          
              <asp:TextBox ID="txtDocumentdate" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
        </div>
      </form>
    </div>



    <div class="col-lg-6">
      <form class="form-horizontal" role="form">
        <div class="form-group">
         
            <asp:Label ID="lblDocumenttitle" CssClass="control-label col-lg-3" runat="server" Text="Document Title"></asp:Label>
          <div class="col-lg-9">
           
              <asp:TextBox ID="txtDocumenttitle" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
        </div>
      </form>
    </div>

    <div class="col-lg-6">
      <form class="form-horizontal" role="form">
        <div class="form-group">
         
           
            <asp:Label ID="lblRemarks" CssClass="control-label col-lg-3" runat="server" Text="Remarks"></asp:Label>
          <div class="col-lg-9">
         
              <asp:TextBox ID="txtRemarks" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
        </div>
      </form>
    </div>
   
</div>
<!---SECTION TWO---> 

</telerik:RadPageView>  
 
</telerik:RadMultiPage>
</td>
</tr>
</table>
   
 <!-----FORM SECTION----> 
</div>

<!--<JavaScrict>-->
<script type="text/javascript">
        function onClientTabSelected(sender, args) {
           
            var tab = args.get_tab();
            if (tab.get_text() == "View") {

                var tabStrip = $find("<%= RadTabStrip1.ClientID %>");
                  var tab = tabStrip.findTabByText("View");
                  tab.select();
                  var tab1 = tabStrip.findTabByText("Edit");
                  tab1.set_text("New");
                  $('input[type=text]').each(function () {
                      $(this).val('');
                  });

                  $('textarea').empty();


              }

              $('input[type=text]').each(function () {
                  $(this).val('');
              });

              $('textarea').empty();
          }

    function onClientTabSelected(sender, args) {

              var tab = args.get_tab();
              if (tab.get_value() == '2') {
                  //new clicked 
                  $('input[type=text]').each(function () {
                      $(this).val('');
                  });


                  document.getElementById('<%=txtDocumentno.ClientID %>').value = "-------System Code-------";
                      $('textarea').empty();

                      debugger;
                      try {
                          <%=ToolBar.ClientID %>_SetAddVisible(false);
                          <%=ToolBar.ClientID %>_SetSaveVisible(true);
                          <%=ToolBar.ClientID %>_SetUpdateVisible(false);
                          <%=ToolBar.ClientID %>_SetDeleteVisible(false);

                      } catch (x) { alert(x.message); }



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

<!--<JavaScrict ends here>-->

</asp:Content>






























   
