<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Uc_FlyCnFileUpload.ascx.cs" Inherits="Proj1.WebUserControl1" %>
<script  type="text/javascript">
    $(document).ready(function () {
        
         $(".divimagebtn").hover(function () {
             $(document).mousemove(function (event) {
                 document.getElementById("<%=idImageFullsize.ClientID%>").style.display = "";
          
              $("<%=idImageFullsize.ClientID%>").css({ "position": "absolute", "left": event.clientX, "top": event.clientY }).show();
           });
      });
});

function testmouseover()
{
    //alert("hello");
    //document.getElementById("<%=idImageFullsize.ClientID%>").style.display="";
    //$("#idImageFullsize").css({ "position": "absolute", "left": event.clientX, "top": event.clientY }).show();

    
   // $("#Image1").mousemove(function (event) {
     //       $("#idImageFullsize").css({ "position": "absolute", "left": event.clientX, "top": event.clientY }).show();
      //  });
   


}

    function testmouseout()
    {
        
        //document.getElementById("<%=idImageFullsize.ClientID%>").style.display ="none";
       // $(document).unbind("mousemove");
       // $("#idImageFullsize").hide();
    }

 
</script>

<div class="DivFileUpload">
    <table style="width:auto" border="1">
        <tr>
            <td colspan="2">
                <asp:FileUpload ID="FileUpload1" runat="server"/></td>
         
        </tr>
      

    </table>

</div>

    <asp:Image ID="idImageFullsize" runat="server" Height="99px" style="display:none" Width="333px" />


    <asp:Label ID="lblmsg" runat="server"></asp:Label>
   


