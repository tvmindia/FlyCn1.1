<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="ImportErrorDetails.aspx.cs" Inherits="FlyCn.ExcelImport.ImportErrorDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik"%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style>
        #tabs li a {
	
	color:#000000;
	

	display:block;

	
	text-decoration:none;
	
	
	
}
    </style>
    
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
</asp:ScriptManager>
     <div class="PageHeading">Error Details</div>
    <div class="container inputMainContainer"  >
  <div class="col-md-12"   >
        <ul id="tabs">
      <li><a href="#" name="tab1">Error Details</a></li>
             </ul>
    <div id="content"  >
           <div id="tab1"  >
             <telerik:radgrid ID="RadGrid1_ErrorDetails" runat="server" Width="100%" >
              <HeaderStyle  HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <AlternatingItemStyle HorizontalAlign="Left" />
                                        <ClientSettings>
                                            <Selecting AllowRowSelect="true" EnableDragToSelectRows="false" />
                                       
                                        </ClientSettings>
                                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="Status_Id">
                                            <Columns>                             
                                                 <telerik:GridBoundColumn HeaderText="Row NO" DataField="Excel_RowNO" UniqueName="Excel_RowNO" ItemStyle-Width="25%" ></telerik:GridBoundColumn>
                                                 <telerik:GridBoundColumn HeaderText="Key Field" DataField="Key_Field" UniqueName="Key_Field" ItemStyle-Width="25%" ></telerik:GridBoundColumn>
                                                 <telerik:GridBoundColumn HeaderText="Error Description" DataField="Error_Description" UniqueName="Error_Description" ItemStyle-Width="50%"></telerik:GridBoundColumn>       
                                            </Columns>
                                        </MasterTableView>
        </telerik:radgrid>
               </div>
               </div>
        </div>
      </div>
</asp:Content>
