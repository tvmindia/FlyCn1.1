<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="DocumentAttachments.aspx.cs" Inherits="FlyCn.Approvels.DocumentAttachments" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UserControls/Uc_FlyCnFileUpload.ascx" TagPrefix="uc1" TagName="Uc_FlyCnFileUpload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <style>
       #table1
       {
          margin-left:15%;

       }
        .tblList
       {
          margin-left:15%;
        
       }

         .Grid, .Grid th 
{
    border:1px solid #DCDCDC;
     text-align:center;
  
}
.Grid td
{
    border:1px solid #DCDCDC;
   
}


   </style>
   
 <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
    <div class="contentTopBar">&nbsp;</div>
   <table id="table1">
       <tr>
          <td>   <uc1:uc_flycnfileupload runat="server" ID="IdUc_FlyCnFileUpload" /></td>
           <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
             <td>  <asp:Button ID="btnsubmit" runat="server" Text="Upload" OnClick="btnsubmit_Click" /></td>
           </tr>
           </table>
    <br />
         <table id="table2" class="tblList">
    <tr><td>
         <asp:GridView ID="GridView1"  CssClass="Grid"    runat="server" CellPadding="5" CellSpacing="10" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Height="111px" Width="400px" DataKeyNames="ImageID" OnRowCreated="GridView1_RowCreated" OnRowDeleting="GridView1_RowDeleting" OnRowDataBound="GridView1_RowDataBound">
             <Columns>

                 <asp:BoundField DataField="ImageID" HeaderText="ImageID"
                     Visible="False" />
                 <asp:BoundField DataField="FileName" HeaderText="File Name" />
                 <asp:BoundField DataField="FileType" HeaderText="File Type" />
                 <asp:BoundField DataField="FileSize" HeaderText="File Size" />
                 
                 <asp:ButtonField CommandName="Select" ButtonType="Image" ImageUrl="~/Images/Download-202-WF.png" ControlStyle-Height="15px"/>

                  <asp:ButtonField CommandName="Delete" ButtonType="Image" ImageUrl="~/Images/Cancel.png" ControlStyle-Height="15px"/>
                 
             </Columns>
         </asp:GridView>
        </td></tr>
          </table>
    <asp:HiddenField ID="popuprefreshRequired" runat="server"  ClientIDMode="Static"/>
    <asp:HiddenField ID="hdfRevisionID" runat="server" ClientIDMode="Static"/>
    <asp:HiddenField ID="hdfItemID" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hiddenStatusValue" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hiddenAttachmentCount" runat="server" ClientIDMode="Static" />
   
    
    
</asp:Content>
