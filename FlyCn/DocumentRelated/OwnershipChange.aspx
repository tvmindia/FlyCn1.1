<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="OwnershipChange.aspx.cs" Inherits="FlyCn.DocumentRelated.OwnershipChange" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
   <div id="bodyDiv">
        <div class="contentTopBar"></div>
  
 
           <div class="col-md-12 Span-One">
                <div class="col-md-6">
                
                    <asp:Label ID="lblRemarks" CssClass="control-label col-md-5" runat="server" Text="Remarks" Style="font:bold"></asp:Label>
                    <asp:TextBox ID="txtRemarks" runat="server" CssClass="control-label col-md-7"  TextMode="MultiLine" Height="50px" MaxLength="200" ></asp:TextBox>
                    </div>
               </div>
       <br />


        <div class="col-md-12 Span-One" style="height:50px;">
             
                    <asp:Label ID="lblDescription" CssClass="control-label col-md-12" runat="server" Text="The Ownership of this document will be changed to your name.And only you will be have the permission to access this document." Style="font-size:10px;"></asp:Label>

                  
            </div>
       <br />
        <br />
    
       <div class="popupButtonContainer">
           <br />
           <br />
          

             <asp:Button class="buttonroundCorner" ID="btnAcquire" runat="server" Text="Acquire" 
                  Width="220px" Height="34px"    OnClick="btnAcquire_Click"   />
       </div>
            </div>

    <asp:HiddenField ID="popuprefreshRequired" runat="server"  ClientIDMode="Static"/>
      


</asp:Content>
