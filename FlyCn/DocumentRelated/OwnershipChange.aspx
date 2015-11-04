<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="OwnershipChange.aspx.cs" Inherits="FlyCn.DocumentRelated.OwnershipChange" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
   <div id="bodyDiv">
        <div class="contentTopBar"></div>
  
 
           <div class="col-md-12 Span-One">
                <div class="col-md-6">
                
                    <asp:Label ID="lblRemarks" CssClass="control-label col-md-5" runat="server" Text="Remarks"></asp:Label>
                    <asp:TextBox ID="txtRemarks" runat="server" CssClass="control-label col-md-7" Multiline="true" ></asp:TextBox>
                    </div>
               </div>
       <div class="col-md-6">
           <asp:Button ID="btnAcquire" runat="server" Text="Acquire"  OnClick="btnAcquire_Click"/>
       </div>
   </div>
      


</asp:Content>
