<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="RejectedDocument.aspx.cs" Inherits="FlyCn.Approvels.RejectedDocument" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" >
 <div class="col-md-12 Span-One">
                <div class="col-md-6">
                
                    <asp:Label ID="lblApprover" CssClass="control-label col-md-6" runat="server" Text="Approver"></asp:Label>
                       
                    <asp:Label ID="lblApproversName"  CssClass="control-label col-md-6" runat="server" Text=""></asp:Label>
                   

                   
                    
              
      </div> 
    <div class="col-md-6">
                

          
                   </div>
     </div>
        <div  class="col-md-12 Span-One">
               <div class="col-md-9">
                                    <asp:Label ID="lblDescription" CssClass="control-label col-md-5"  runat="server" Text="Document Will be closed for approvel"></asp:Label>
                   </div>
        </div>
    </div>
    <table>

            <tr>

                <td>
                  
            <asp:Button class="buttonroundCorner" ID="btnCloseDocument" runat="server" Text="Close Document" 
                  Width="263px" Height="36px"  OnClientClick="return CloseDoc();"  OnClick="btnCloseDocument_Click"   />
 </td>
                </tr>
       </table>
</asp:Content>
