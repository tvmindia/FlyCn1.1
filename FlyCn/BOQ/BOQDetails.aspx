<%-- Registration  --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="BOQDetails.aspx.cs" Inherits="FlyCn.BOQ.BOQDetails" %>
<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


<meta name="viewport" content="width=device-width, initial-scale=1" />
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Input</title>

 <!-----bootstrap css--->
    <link href="../Content/themes/FlyCnBlue/css/roboto_google_api.css" rel="stylesheet" />
    <link href="Content/themes/FlyCnBlue/css/datepicker.css" rel="stylesheet" type="text/css" />
    <!-----bootstrap css--->
    <link href="../Content/themes/FlyCnBlue/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/themes/FlyCnBlue/css/stylesheet.css" rel="stylesheet" />

    <link href="../Content/themes/FlyCnBlue/css/selectize.css" rel="stylesheet" type="text/css" />
    <link href="../Content/themes/FlyCnBlue/css/accodin.css" rel="stylesheet" type="text/css" />
    <!-----main css--->
    <link href="../Content/themes/FlyCnBlue/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Content/themes/FlyCnRed_Rad/TabStrip.FlyCnRed_Rad.css" rel="stylesheet" />
     <script src="../Content/themes/FlyCnBlue/js/jquery.min.js"></script>

    <!-----main css--->
</asp:Content>
<%-- Registration--%>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

  <div class="container" style="width: 100%">
        <!-----FORM SECTION---->
        <!-----SECTION TABLE---->

        <telerik:RadTabStrip ID="RadTabStripBOQDetail" runat="server" MultiPageID="RadMultiPageBOQDetail" Width="300px" OnClientTabSelected="onClientTabSelectedBOQDetail"
            CausesValidation="false" SelectedIndex="0" Skin="FlyCnRed_Rad" EnableEmbeddedSkins="false">

            <Tabs>
                <telerik:RadTab Text="View" PageViewID="rpBOQDetailList" Value="1" Width="150px" runat="server" ImageUrl="~/Images/Icons/ListIcon.png" Selected="True"></telerik:RadTab>
                <telerik:RadTab Text="New" PageViewID="rpBOQDetailAddEdit" Value="2" Width="150px" runat="server" ImageUrl="~/Images/Icons/NewIcon.png"></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <div id="content">
            <div class="contentTopBar"></div>
            <table style="width: 100%">
                <tr>
                     
                    <td>

                        <telerik:RadMultiPage ID="RadMultiPageBOQDetail" runat="server" Width="100%" SelectedIndex="0" CssClass="outerMultiPage">
                            <!--Radpage view begins here-->
                            <telerik:RadPageView ID="rpList" runat="server">

                                <div id="rpBOQDetailList" style="width: 100%;text-align:center">

                                       <telerik:RadGrid ID="dtgBOQDetailGrid" runat="server" CellSpacing="0" GridLines="None" OnNeedDataSource="dtgBOQDetailGrid_NeedDataSource" AllowPaging="true" AllowAutomaticDeletes="false" AllowAutomaticUpdates="false" OnItemCommand="dtgBOQDetailGrid_ItemCommand"
                                        PageSize="10" Width="99%"  >
                                        <HeaderStyle  HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <AlternatingItemStyle HorizontalAlign="Left" />
                                        <ClientSettings>
                                            <Selecting AllowRowSelect="true" EnableDragToSelectRows="false" />
                                           
                                        </ClientSettings>

                                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="ItemID,RevisionID,ProjectNo">

                                            <Columns>

                                                <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="ChkChild" runat="server" onclick="HeaderUncheck(this);" AutoPostBack="False" />
                                                    </ItemTemplate>
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="Chkheader" runat="server" onclick="Check(this);" AutoPostBack="False" />
                                                    </HeaderTemplate>
                                                </telerik:GridTemplateColumn>

                                                <telerik:GridButtonColumn CommandName="EditDoc" ButtonType="ImageButton" ImageUrl="~/Images/Icons/Pencil-01.png" Text="Edit" UniqueName="EditData">
                                                </telerik:GridButtonColumn>
                                                <telerik:GridButtonColumn CommandName="DeleteDoc" Text="Delete" UniqueName="DeleteColumn" ButtonType="ImageButton" ImageUrl="~/Images/Cancel.png" ConfirmDialogType="RadWindow" ConfirmText="Are you sure, you want to delete this item ?">
                                                </telerik:GridButtonColumn>

                                                <telerik:GridBoundColumn HeaderText="RevisionID" DataField="RevisionID" UniqueName="RevisionID" Display="false"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Item ID" DataField="ItemID" UniqueName="ItemID" Display="false"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Project No" DataField="ProjectNo" UniqueName="ProjectNo" Display="false"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Item No" DataField="ItemNo" UniqueName="ItemNo"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Description" DataField="ItemDescription" UniqueName="ItemDescription"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Quantity" DataField="Quantity" UniqueName="Quantity"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Unit" DataField="Unit" UniqueName="Unit"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Normal Hours" DataField="NormHours" UniqueName="NormHours"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Labour Rate" DataField="LabourRate" UniqueName="LabourRate"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="RateType" DataField="LabourRateType" UniqueName="LabourRateType"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Material Rate" DataField="MaterialRate" UniqueName="MaterialRate"></telerik:GridBoundColumn>
                                               


                                            </Columns>
                                        </MasterTableView>

                                    </telerik:RadGrid>


                                </div>
                            </telerik:RadPageView>
                             <!--Radpage view Ends here-->

                              <!----RadPage view edit begins here---->
  <!----EDIT SECTION--->
 <telerik:RadPageView ID="rpBOQDetailAddEdit" runat="server">
 <uc1:ToolBar runat="server" ID="ToolBarBOQDetail" />

 <!---SECTION ONE--->
 <div class="col-md-12 Span-One">

   

      <div class="col-md-6">
       <div class="form-group">
         <asp:Label ID="lblItemDescription" CssClass="control-label col-md-3" runat="server" Text="Item Description*"></asp:Label>
          <div class="col-md-9">
             <asp:TextBox ID="txtItemDescription" CssClass="form-control" runat="server"></asp:TextBox>
               <asp:HiddenField ID="hdfRevisionId" runat="server" />
              <asp:HiddenField ID="hdfItemId" runat="server" />
          </div>
          </div>
         </div>

     <div class="col-md-6">
       <div class="form-group">
         <asp:Label ID="lblQuantity" CssClass="control-label col-md-3" runat="server" Text="Quantity*"></asp:Label>
          <div class="col-md-9">
             <asp:TextBox ID="txtQuantity" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
        </div>

     <div class="col-md-6">
       <div class="form-group">
         <asp:Label ID="lblUnit" CssClass="control-label col-md-3" runat="server" Text="Unit*"></asp:Label>
          <div class="col-md-9">
             <asp:TextBox ID="txtUnit" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
        </div>

      <div class="col-md-6">
       <div class="form-group">
         <asp:Label ID="lblNormalHours" CssClass="control-label col-md-3" runat="server" Text="Normal Hours"></asp:Label>
          <div class="col-md-9">
             <asp:TextBox ID="txtNormalHours" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
         </div>

       <div class="col-md-6">
       <div class="form-group">
         <asp:Label ID="lblLabourRate" CssClass="control-label col-md-3" runat="server" Text="Labour Rate"></asp:Label>
          <div class="col-md-9">
             <asp:TextBox ID="txtLabourRate" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
         </div>

     <div class="col-md-6">
       <div class="form-group">
         <asp:Label ID="lblLabourRateType" CssClass="control-label col-md-3" runat="server" Text="Labour Rate Type"></asp:Label>
          <div class="col-md-9">
             <asp:TextBox ID="txtLabourRateType" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
         </div>


      <div class="col-md-6">
       <div class="form-group">
         <asp:Label ID="lblMaterialRate" CssClass="control-label col-md-3" runat="server" Text="Material Rate"></asp:Label>
          <div class="col-md-9">
             <asp:TextBox ID="txtMaterialRate" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
         </div>

     <div class="col-md-6">
       <div class="form-group">
         <asp:Label ID="lblUDFRate1" CssClass="control-label col-md-3" runat="server" Text="UDF Rate1"></asp:Label>
          <div class="col-md-9">
             <asp:TextBox ID="txtUDFRate1" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
         </div>


      <div class="col-md-6">
       <div class="form-group">
         <asp:Label ID="lblUDFRateType1" CssClass="control-label col-md-3" runat="server" Text="UDF Rate Type1"></asp:Label>
          <div class="col-md-9">
             <asp:TextBox ID="txtUDFRateType1" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
         </div>


       <div class="col-md-6">
       <div class="form-group">
         <asp:Label ID="lblUDFRate2" CssClass="control-label col-md-3" runat="server" Text="UDF Rate2"></asp:Label>
          <div class="col-md-9">
             <asp:TextBox ID="txtUDFRate2" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
         </div>

     <div class="col-md-6">
       <div class="form-group">
         <asp:Label ID="lblUDFRateType2" CssClass="control-label col-md-3" runat="server" Text="UDF Rate Type2"></asp:Label>
          <div class="col-md-9">
             <asp:TextBox ID="txtUDFRateType2" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
          </div>


      <div class="col-md-6">
       <div class="form-group">
         <asp:Label ID="lblUDFRate3" CssClass="control-label col-md-3" runat="server" Text="UDF Rate3"></asp:Label>
          <div class="col-md-9">
             <asp:TextBox ID="txtUDFRate3" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
         </div>


      <div class="col-md-6">
       <div class="form-group">
         <asp:Label ID="lblUDFRateType3" CssClass="control-label col-md-3" runat="server" Text="UDF Rate Type3"></asp:Label>
          <div class="col-md-9">
             <asp:TextBox ID="txtUDFRateType3" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
         </div>


      <div class="col-md-6">
       <div class="form-group">
         <asp:Label ID="lblUDFRate4" CssClass="control-label col-md-3" runat="server" Text="UDF Rate4"></asp:Label>
          <div class="col-md-9">
             <asp:TextBox ID="txtUDFRate4" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
         </div>

      <div class="col-md-6">
       <div class="form-group">
         <asp:Label ID="lblUDFRateType4" CssClass="control-label col-md-3" runat="server" Text="UDF Rate Type4"></asp:Label>
          <div class="col-md-9">
             <asp:TextBox ID="txtUDFRateType4" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
         </div>


       <div class="col-md-6">
       <div class="form-group">
         <asp:Label ID="lblUDFRate5" CssClass="control-label col-md-3" runat="server" Text="UDF Rate5"></asp:Label>
          <div class="col-md-9">
             <asp:TextBox ID="txtUDFRate5" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
         </div>



      <div class="col-md-6">
       <div class="form-group">
         <asp:Label ID="lblUDFRateType5" CssClass="control-label col-md-3" runat="server" Text="UDF Rate Type5"></asp:Label>
          <div class="col-md-9">
             <asp:TextBox ID="txtUDFRateType5" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
         </div>

     <div class="col-md-6">
       <div class="form-group">
         <asp:Label ID="lbmdroup1" CssClass="control-label col-md-3" runat="server" Text="Group1"></asp:Label>
          <div class="col-md-9">
             <asp:TextBox ID="txtGroup1" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
         </div>

      <div class="col-md-6">
       <div class="form-group">
         <asp:Label ID="lbmdroup2" CssClass="control-label col-md-3" runat="server" Text="Group2"></asp:Label>
          <div class="col-md-9">
             <asp:TextBox ID="txtGroup2" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
         </div>

      <div class="col-md-6">
       <div class="form-group">
         <asp:Label ID="lbmdroup3" CssClass="control-label col-md-3" runat="server" Text="Group3"></asp:Label>
          <div class="col-md-9">
             <asp:TextBox ID="txtGroup3" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
        </div>

       <div class="col-md-6">
       <div class="form-group">
         <asp:Label ID="lbmdroup4" CssClass="control-label col-md-3" runat="server" Text="Group4"></asp:Label>
          <div class="col-md-9">
             <asp:TextBox ID="txtGroup4" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
       </div>

      <div class="col-md-6">
       <div class="form-group">
         <asp:Label ID="lbmdroup5" CssClass="control-label col-md-3" runat="server" Text="Group5"></asp:Label>
          <div class="col-md-9">
             <asp:TextBox ID="txtGroup5" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
       </div>


 </div> <!---col-md-12 Span-One Ends here-->
 <!---SECTION ONE---> 

     <!--Radpage view rpAddEdit ends here-->
       </telerik:RadPageView>
          <!--RadMultiPage ends here-->
        </telerik:RadMultiPage>
        </td>
        </tr>
       </table>
   </div>
</div>



<!--<JavaScrict>-->

 <script type="text/javascript">
    
     $(document).ready(function () {
         
        
        
     });
     function onClientTabSelectedBOQDetail(sender, args)
     {
         var tab = args.get_tab();
         if (tab.get_value() == '2') {
             //Clear Text boxes When New tab clicks
             //new clicked 
             $('input[type=text]').each(function () {
                 $(this).val('');
             });
             //Clear Text boxes When New tab clicks
             try {
                 <%=ToolBarBOQDetail.ClientID %>_SetAddVisible(false);
                 <%=ToolBarBOQDetail.ClientID %>_SetSaveVisible(true);
                 <%=ToolBarBOQDetail.ClientID %>_SetUpdateVisible(false);
                 <%=ToolBarBOQDetail.ClientID %>_SetDeleteVisible(false);
             }
             catch (x) {
                 alert(x.message);
             }
         }

     }
     function OnClientButtonClickingDetail(sender, args)
     {
        debugger;
        var btn = args.get_item();
        if (btn.get_value() == 'Save')
        {
            alert("save clicked");
     //     args.set_cancel(!validate());
        }
        if (btn.get_value() == 'Update') 
        {
            alert("update clicked");
       //     args.set_cancel(!validate());
        }

        if (btn.get_value() == "Delete") 
        {
            alert("Delete clicked");
        }
                
     }

</script>
 
<!--<JavaScrict Ends here>-->


</asp:Content>




