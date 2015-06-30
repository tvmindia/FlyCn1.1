<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Landing.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="FlyCn.Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainBody" runat="server">
 
     <style>
        #MainBody_div1 {
 
  z-index: 3;
  position:relative;
  
  left:30%;
}
 #MainBody_div2 {
 
 
 
  
}
    </style> 
   
 
<script>
    var flag = 0;
    var str = "hello()";
    $(document).ready(function () {
        $("#MainBody_div1").fadeIn();
    });
    function bindimage(id) {
        
        $('#iframesub1').fadeOut(500, function () { document.getElementById('iframesub1').setAttribute('src', 'SubMenu.aspx' + '?id=' + id); });
       
        document.getElementById('iframesub1').style.border = 0;
        $("#iframesub1").fadeIn(1000);
        
        if (flag == 0)
        {
            $("#MainBody_div1").animate({ left: "-=150" }, 800);
            flag = 1;

        }

   
    }
 
</script>
     <table style="width: 100%">
            <tr>
                <td style="width: 50%;">
                   
                        <div id="div1" runat="server" style="width:800px;height:500px;display:none" >
                        </div>
                   
                        
                    
                </td>
                <td style="">
                      <div id="div2" runat="server">
                          <iframe id="iframesub1" style="width:800px;height:500px;display:none;"  frameborder="0"  ></iframe>
                        
                        </div>
                </td>
                 
            </tr>
        </table>
</asp:Content>
