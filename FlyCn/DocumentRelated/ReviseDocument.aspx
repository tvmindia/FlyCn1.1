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
   <div>
<div class="col-md-12 Span-One">

    <div class="col-md-6">
       <div class="form-group required">
         <asp:Label ID="lblDocumentNo" CssClass="control-label col-md-5" runat="server" Text="Document No"></asp:Label>
          <div class="col-md-7">
     <asp:TextBox ID="txtDocumentNo" runat="server" CssClass="form-control"  Width="170px"></asp:TextBox>

          </div>
          </div>
        </div>

     <div class="col-md-6">
       <div class="form-group required">
         <asp:Label ID="lblDocumentType" CssClass="control-label col-md-5" runat="server" Text="Document type"></asp:Label>
          <div class="col-md-7">
     <asp:TextBox ID="txtDocumentType" runat="server" CssClass="form-control"  Width="170px"></asp:TextBox>

          </div>
          </div>
        </div>
     </div>

       <div class="col-md-12 Span-One">

    <div class="col-md-6">
       <div class="form-group required">
         <asp:Label ID="lblRevisionNo" CssClass="control-label col-md-5" runat="server" Text="Revision No"></asp:Label>
          <div class="col-md-7">
     <asp:TextBox ID="txtRevisionNo" runat="server" CssClass="form-control"  Width="170px"></asp:TextBox>

          </div>
          </div>
        </div>
           </div>

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
              <input   id="txtdatepicker" class="form-control"  type="text" runat="server" />
              <span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span> </div>

          </div>
          </div>
        </div>
     </div>
</div>
    <div>
<asp:Button ID="ReviseDocumentButton" runat="server" Text="Button" OnClick="ReviseDocumentButton_Click" style="width: 56px" />
    </div>
    
</asp:Content>
