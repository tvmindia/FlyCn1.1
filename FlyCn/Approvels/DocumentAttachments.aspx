<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="DocumentAttachments.aspx.cs" Inherits="FlyCn.Approvels.DocumentAttachments" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UserControls/Uc_FlyCnFileUpload.ascx" TagPrefix="uc1" TagName="Uc_FlyCnFileUpload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
     <table>
            <tr>
                <td> <uc1:uc_flycnfileupload runat="server" ID="IdUc_FlyCnFileUpload" /></td>
           
                <td><asp:Button ID="btnsubmit" runat="server" Text="Upload" OnClick="btnsubmit_Click" /></td>
            </tr>
    <tr><td>
         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Height="111px" Width="293px" DataKeyNames="ImageID">
             <Columns>

                 <asp:BoundField DataField="ImageID" HeaderText="ImageID"
                     Visible="False" />
                 <asp:BoundField DataField="FileName" HeaderText="File Name" />
                 <asp:BoundField DataField="FileType" HeaderText="File Type" />
                 <asp:BoundField DataField="FileSize" HeaderText="File Size" />
                 
                 <asp:ButtonField CommandName="Select" ButtonType="Image" ImageUrl="~/Images/Download-02-WF.png"/>
                 
             </Columns>
         </asp:GridView>
        </td></tr>
          </table>
    <asp:HiddenField ID="popuprefreshRequired" runat="server"  ClientIDMode="Static"/>
    <asp:HiddenField ID="hdfRevisionID" runat="server" ClientIDMode="Static"/>
</asp:Content>
