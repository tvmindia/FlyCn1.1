<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="PunchListSummary.aspx.cs" Inherits="FlyCn.EIL.PunchListSummary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script type="text/javascript" src="https://www.google.com/jsapi"></script> 

 &nbsp;&nbsp; <asp:Label ID="lblTitle" runat="server" Text="PunchList Summary" CssClass="PageHeading"></asp:Label>
     <div class="importWizardContainer" style="height:600px;">
          <asp:Literal ID="ltScripts" runat="server"></asp:Literal>  
         <asp:Button ID="printPunchList" runat="server" OnClick="printPunchList_Click" Text="Download"/>
    <div id="columnchart_material" style="width: 600px; height: 500px;"></div>
         </div>
  
</asp:Content>
