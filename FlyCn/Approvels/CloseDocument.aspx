<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="CloseDocument.aspx.cs" Inherits="FlyCn.Approvels.CloseDocument" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <asp:HiddenField ID="hdfRevisionId" runat="server" />
    <asp:Label ID="lblrevisionid" runat="server" Text="" ForeColor="SteelBlue"></asp:Label>

 <%-- <asp:TextBox ID="txtrevisionid" runat="server" ForeColor="Tan"></asp:TextBox>--%>
</asp:Content>
