<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="SubMenu.aspx.cs" Inherits="FlyCn.SubMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function setAccessmsg(spanID) {

            var deniedSpan = document.getElementById(spanID);

            var s = spanID;
            
            deniedSpan.style.color = "red";
            deniedSpan.innerHTML = spanID;


        }
    </script>

      <table style="width: 100%;position:fixed;top:0">
            <tr>
                <td style="width: 100%;">
                   
                        <div id="div2" runat="server" >
                        </div>
                                           
                    
                </td>
                
                 
            </tr>
       
         
        </table>
</asp:Content>
