<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Landing.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="FlyCn.Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainBody" runat="server">
 
     <style>
        #MainBody_div1 {
 
  z-index: 0;
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
    function bindimage(id, heading, color) {
        debugger;
        document.getElementById('SubHeadSpan').innerHTML = '&nbsp;'
        document.getElementById('SubHeadSpan').setAttribute('class', color);

        $('#iframesub1').fadeOut(500, function () { document.getElementById('iframesub1').setAttribute('src', 'SubMenu.aspx' + '?id=' + id); });
       
        document.getElementById('iframesub1').style.border = 0;
        document.getElementById('SubHeadSpan').innerHTML = heading;
        $("#iframesub1").fadeIn(1000, function () { });
        
        if (flag == 0)
        {
            $("#MainBody_div1").animate({ left: "-=150" }, 800);
            flag = 1;

        }

       
   
    }


    //function bindimageLink(url) {
        
    //    window.location = url;
    //}
 
    function getSubTilePermission(url, id, spanID)
    {
       

    


        PageMethods.GetPermissionOfSubTiles(id, onSucess, onError);
        
        function onSucess(SubTilePermissionDenied) {
           
         
            if (SubTilePermissionDenied == true) {
               
                //SubTileDenied = true;
                debugger;
                var frame = document.getElementById('iframesub1');
                frame.contentWindow.setAccessmsg(spanID);               
              
                //alert(document.getElementById('spanID'));
            }
            else
            {
                window.location = url;
            }
            
        }
        function onError(SubTilePermission) {
            alert('Something wrong while getting sub tile permission');

        }
    }



  

</script>
    
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
     
     <table style="width: 100%">
         <tr><td></td><td>&nbsp;</td></tr>
          <tr><td></td><td > 
             <div class="subMenuHead"><span id="SubHeadSpan">&nbsp;</span></div> </td></tr>
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
