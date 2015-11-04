<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="ReviseDocument.aspx.cs" Inherits="FlyCn.Approvels.ReviseDocument" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="../Scripts/jquery-1.11.3.min.js"></script>


    <script src="../Content/themes/FlyCnBlue/js/bootstrap.min.js"></script> 
<script src="../Content/themes/FlyCnBlue/js/bootstrap-datepicker.js"></script> 
<script>
    $(function () {
        $("#datepicker").datepicker({
            autoclose: true,
            todayHighlight: true
        }).datepicker('update', new Date());;
    });

</script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   


 <div class="col-md-12 Span-One">

    <div class="col-md-6">
       <div class="form-group required">
         <asp:Label ID="lblRemarks" CssClass="control-label col-md-5" runat="server" Text="Remarks"></asp:Label>
          <div class="col-md-7">
     <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" TextMode="MultiLine" Width="170px"></asp:TextBox>

          </div>
          </div>
        </div>

     <div class="col-md-6">
       <div class="form-group required">
         <asp:Label ID="lblRevisedDate" CssClass="control-label col-md-5" runat="server" Text="Revised Date"></asp:Label>
          <div class="col-md-7">
 <div id="datepicker" class="input-group date" data-date-format="mm-dd-yyyy">
              <input class="form-control" type="text"  />
              <span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span> </div>

          </div>
          </div>
        </div>
     </div>

</asp:Content>
