<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="RejectedDocument.aspx.cs" Inherits="FlyCn.Approvels.RejectedDocument" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="width: 100%;">
  
                <div class="contentTopBar"></div>

        <div style="height:40px;">

        </div>
         <asp:Label ID="lblCaption" runat="server" Text="Approvers"  CssClass="Verifiercaption" ClientIDMode="Static"></asp:Label>

        <div  class="col-md-12 Span-One" style="height:20px;">
                
                                    <asp:Label ID="lblDescription" CssClass="control-label col-md-5"  runat="server" Text="Document Will be closed for approvel to the approvers below " style="font-family:'segoe UI', Tahoma, Geneva, Verdana, sans-serif; font:bold; font-size:15px;"></asp:Label>
                
                  
 </div>
 <div class="col-md-12 Span-One" >
                    <div class="col-md-6" id="label1Id" runat="server"  >

                        <div class="col-md-9" >

                            <asp:Label ID="lblName" CssClass="control-label col-md-3" runat="server" Text="" ></asp:Label>
                                </div>
                            <div class="col-md-3" id="label2Id" runat="server">

                                 <asp:Label ID="lblEmail" CssClass="control-label col-md-3" runat="server" Text=""></asp:Label>
                               

                            </div>
                    
                        </div>
    
     </div>
          
        

         </div>
      <asp:HiddenField ID="popuprefreshRequired" runat="server"  ClientIDMode="Static"/>
    <div>

    </div>
    <div style="height:30px;">

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
