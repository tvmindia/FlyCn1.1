<%-- Registration  --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="BOQDetails.aspx.cs" Inherits="FlyCn.BOQ.BOQDetails" %>
<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


<meta name="viewport" content="width=device-width, initial-scale=1" />
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Input</title>

<!-----bootstrap css--->
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css" />
<link href='https://fonts.googleapis.com/css?family=Roboto:400,300,300italic,400italic,700,700italic,900' rel='stylesheet' type='text/css' />
<link href="Content/themes/FlyCnBlue/css/datepicker.css" rel="stylesheet" type="text/css" />
<!-----bootstrap css--->
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css"/>
<link href="../Content/themes/FlyCnBlue/css/stylesheet.css" rel="stylesheet" />

<link href="../Content/themes/FlyCnBlue/css/selectize.css" rel="stylesheet" type="text/css" />
<link href="../Content/themes/FlyCnBlue/css/accodin.css" rel="stylesheet" type="text/css" />
<!-----main css--->
<link href="../Content/themes/FlyCnBlue/css/style.css" rel="stylesheet" type="text/css" />
<!-----main css--->
</asp:Content>
<%-- Registration--%>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

 <uc1:ToolBar runat="server" ID="ToolBarBOQDetails" />

  <!---SECTION ONE--->
 <div class="col-lg-12 Span-One">
    <div class="col-lg-6">
       <div class="form-group">
          <asp:Label ID="lblItemNo" CssClass="control-label col-lg-3" runat="server" Text="Item No"></asp:Label>
          <div class="col-lg-9">
            <asp:TextBox ID="txtItemNo"  runat="server" CssClass="form-control"></asp:TextBox>
          </div>
        </div>
       </div>
      <div class="col-lg-6">
       <div class="form-group">
         <asp:Label ID="lblItemDescription" CssClass="control-label col-lg-3" runat="server" Text="Item Description"></asp:Label>
          <div class="col-lg-9">
             <asp:TextBox ID="txtItemDescription" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
      </div>

     <div class="col-lg-6">
       <div class="form-group">
         <asp:Label ID="lblQuantity" CssClass="control-label col-lg-3" runat="server" Text="Quantity"></asp:Label>
          <div class="col-lg-9">
             <asp:TextBox ID="txtQuantity" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
      </div>

     <div class="col-lg-6">
       <div class="form-group">
         <asp:Label ID="lblUnit" CssClass="control-label col-lg-3" runat="server" Text="Unity"></asp:Label>
          <div class="col-lg-9">
             <asp:TextBox ID="txtUnit" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
      </div>

      <div class="col-lg-6">
       <div class="form-group">
         <asp:Label ID="lblNormalHours" CssClass="control-label col-lg-3" runat="server" Text="Normal Hours"></asp:Label>
          <div class="col-lg-9">
             <asp:TextBox ID="txtNormalHours" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
      </div>

       <div class="col-lg-6">
       <div class="form-group">
         <asp:Label ID="lblLabourRate" CssClass="control-label col-lg-3" runat="server" Text="Labour Rate"></asp:Label>
          <div class="col-lg-9">
             <asp:TextBox ID="txtLabourRate" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
      </div>

     <div class="col-lg-6">
       <div class="form-group">
         <asp:Label ID="lblLabourRateType" CssClass="control-label col-lg-3" runat="server" Text="Labour Rate Type"></asp:Label>
          <div class="col-lg-9">
             <asp:TextBox ID="txtLabourRateType" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
      </div>


      <div class="col-lg-6">
       <div class="form-group">
         <asp:Label ID="lblMaterialRate" CssClass="control-label col-lg-3" runat="server" Text="Material Rate"></asp:Label>
          <div class="col-lg-9">
             <asp:TextBox ID="txtMaterialRate" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
      </div>

     <div class="col-lg-6">
       <div class="form-group">
         <asp:Label ID="lblUDFRate1" CssClass="control-label col-lg-3" runat="server" Text="UDF Rate1"></asp:Label>
          <div class="col-lg-9">
             <asp:TextBox ID="txtUDFRate1" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
      </div>


      <div class="col-lg-6">
       <div class="form-group">
         <asp:Label ID="lblUDFRateType1" CssClass="control-label col-lg-3" runat="server" Text="UDF Rate Type1"></asp:Label>
          <div class="col-lg-9">
             <asp:TextBox ID="txtUDFRateType1" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
      </div>


       <div class="col-lg-6">
       <div class="form-group">
         <asp:Label ID="lblUDFRate2" CssClass="control-label col-lg-3" runat="server" Text="UDF Rate2"></asp:Label>
          <div class="col-lg-9">
             <asp:TextBox ID="txtUDFRate2" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
      </div>

     <div class="col-lg-6">
       <div class="form-group">
         <asp:Label ID="lblUDFRateType2" CssClass="control-label col-lg-3" runat="server" Text="UDF Rate Type2"></asp:Label>
          <div class="col-lg-9">
             <asp:TextBox ID="txtUDFRateType2" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
      </div>


      <div class="col-lg-6">
       <div class="form-group">
         <asp:Label ID="lblUDFRate3" CssClass="control-label col-lg-3" runat="server" Text="UDF Rate3"></asp:Label>
          <div class="col-lg-9">
             <asp:TextBox ID="txtUDFRate3" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
      </div>


      <div class="col-lg-6">
       <div class="form-group">
         <asp:Label ID="lblUDFRateType3" CssClass="control-label col-lg-3" runat="server" Text="UDF Rate Type3"></asp:Label>
          <div class="col-lg-9">
             <asp:TextBox ID="txtUDFRateType3" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
      </div>


      <div class="col-lg-6">
       <div class="form-group">
         <asp:Label ID="lblUDFRate4" CssClass="control-label col-lg-3" runat="server" Text="UDF Rate4"></asp:Label>
          <div class="col-lg-9">
             <asp:TextBox ID="txtUDFRate4" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
      </div>

      <div class="col-lg-6">
       <div class="form-group">
         <asp:Label ID="lblUDFRateType4" CssClass="control-label col-lg-3" runat="server" Text="UDF Rate Type4"></asp:Label>
          <div class="col-lg-9">
             <asp:TextBox ID="txtUDFRateType4" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
      </div>


       <div class="col-lg-6">
       <div class="form-group">
         <asp:Label ID="lblUDFRate5" CssClass="control-label col-lg-3" runat="server" Text="UDF Rate5"></asp:Label>
          <div class="col-lg-9">
             <asp:TextBox ID="txtUDFRate5" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
       </div>



      <div class="col-lg-6">
       <div class="form-group">
         <asp:Label ID="lblUDFRateType5" CssClass="control-label col-lg-3" runat="server" Text="UDF Rate Type5"></asp:Label>
          <div class="col-lg-9">
             <asp:TextBox ID="txtUDFRateType5" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
       </div>

     <div class="col-lg-6">
       <div class="form-group">
         <asp:Label ID="lblGroup1" CssClass="control-label col-lg-3" runat="server" Text="Group1"></asp:Label>
          <div class="col-lg-9">
             <asp:TextBox ID="txtGroup1" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
       </div>

      <div class="col-lg-6">
       <div class="form-group">
         <asp:Label ID="lblGroup2" CssClass="control-label col-lg-3" runat="server" Text="Group2"></asp:Label>
          <div class="col-lg-9">
             <asp:TextBox ID="txtGroup2" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
       </div>

      <div class="col-lg-6">
       <div class="form-group">
         <asp:Label ID="lblGroup3" CssClass="control-label col-lg-3" runat="server" Text="Group3"></asp:Label>
          <div class="col-lg-9">
             <asp:TextBox ID="txtGroup3" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
       </div>

       <div class="col-lg-6">
       <div class="form-group">
         <asp:Label ID="lblGroup4" CssClass="control-label col-lg-3" runat="server" Text="Group4"></asp:Label>
          <div class="col-lg-9">
             <asp:TextBox ID="txtGroup4" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
       </div>

      <div class="col-lg-6">
       <div class="form-group">
         <asp:Label ID="lblGroup5" CssClass="control-label col-lg-3" runat="server" Text="Group5"></asp:Label>
          <div class="col-lg-9">
             <asp:TextBox ID="txtGroup5" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          </div>
       </div>


</div>
    <!---SECTION ONE---> 






</asp:Content>




