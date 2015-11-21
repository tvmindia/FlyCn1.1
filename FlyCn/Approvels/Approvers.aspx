<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="Approvers.aspx.cs" Inherits="FlyCn.Approvels.Approvers" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">





     <div id="bodyDiv">
       <!--Telerik Radlistbox-->
       <telerik:RadGrid ID="dtgApprovers" runat="server" CellSpacing="0" GridLines="None" ItemStyle-HorizontalAlign="Center" AlternatingItemStyle-HorizontalAlign="Center"  AllowPaging="true" AllowAutomaticDeletes="false" AllowAutomaticUpdates="false"  PageSize="10" Width="500px" OnNeedDataSource="dtgApprovers_NeedDataSource">
         <HeaderStyle  HorizontalAlign="Center" />
         <ItemStyle HorizontalAlign="Left" />
         <AlternatingItemStyle HorizontalAlign="Left"/>
         <ClientSettings>
          <Selecting AllowRowSelect="true" EnableDragToSelectRows="false"/>
         </ClientSettings>
        <MasterTableView AutoGenerateColumns="False">
        <Columns>
         <telerik:GridBoundColumn HeaderText="ApprovalID" DataField="ApprovalID" UniqueName="ApprovalID" Display="false"></telerik:GridBoundColumn>
         <telerik:GridBoundColumn HeaderText="RevisionID" DataField="RevisionID" UniqueName="RevisionID" Display="false"></telerik:GridBoundColumn>
         <telerik:GridBoundColumn HeaderText="Level" DataField="VerifierLevel" ItemStyle-Width="50px" UniqueName="VerifierLevel"></telerik:GridBoundColumn>
	     <telerik:GridBoundColumn HeaderText="VerifierEmail" DataField="VerifierEmail" ItemStyle-Width="50px" UniqueName="VerifierEmail"></telerik:GridBoundColumn>
		 <telerik:GridBoundColumn HeaderText="StatusDescription" DataField="StatusDescription" ItemStyle-Width="50px" UniqueName="StatusDescription"></telerik:GridBoundColumn>
        </Columns>
        </MasterTableView>
      </telerik:RadGrid>
     </div>

















</asp:Content>
