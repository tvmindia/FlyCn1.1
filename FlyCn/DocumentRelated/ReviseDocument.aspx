<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="ReviseDocument.aspx.cs" Inherits="FlyCn.Approvels.ReviseDocument" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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
 <div id="datepicker" class="input-group date " data-date-format="dd-M-yyyy">
                                           <input   id="txtdatepicker" class="form-control"  type="text" runat="server" />
                                           <span class="input-group-addon dateicon"  ><i class="glyphicon glyphicon-calendar"></i></span> </div>

          </div>
          </div>
        </div>
     </div>

</asp:Content>
