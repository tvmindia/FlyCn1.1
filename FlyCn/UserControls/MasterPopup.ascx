<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MasterPopup.ascx.cs" Inherits="FlyCn.UserControls.MasterPopup" %>
<script>
   
    //Function to hide div when click outside the GO button

 $("body").click
(
function (e) {

    if (e.target.className !== "clsGoButton")
    {
        $("#" + '<%=divCloseAndIframe.ClientID%>').hide();
        
    }
   }
);


    //Program flow:function called on button click which gets the x y coordinates and then sets to div position(working code),this function is called on clientclick
    var idOfDivOpened = 0;
    var isDivOpened = 0;
    var countOfDivOpened = 0;
   
    function <%= ClientID%>_ChangeDivposition(subEvent)
    {
        
       var mainEvent = subEvent ? subEvent : window.event;

        var screenX = mainEvent.screenX;
        var xDifference = screenX - mainEvent.clientX;
        var x = screenX - xDifference;

        var screenY = mainEvent.screenY;
        var yDifference = screenY - mainEvent.clientY;
        var y = screenY - yDifference;

      
        var d = document.getElementById('<%=divCloseAndIframe.ClientID%>');
        d.style.position = "absolute";

        document.getElementById('<%=btnGo.ClientID%>').style.top = d.style.top;
        document.getElementById('<%=btnGo.ClientID%>').style.left = d.style.left;

        //d.style.left = x + 'px';
        //d.style.top = y + 'px';

    
        if (isDivOpened == 0)
        {
            $("#" + '<%=divCloseAndIframe.ClientID%>').show();

            idOfDivOpened = $("#" + '<%=divCloseAndIframe.ClientID%>');

            isDivOpened = 1;
            countOfDivOpened++;
            
        }

        else if (isDivOpened == 1)
        {
            for(i=countOfDivOpened;i>0;i--)
            {
                idOfDivOpened.hide();
                
            }
            $("#" + '<%=divCloseAndIframe.ClientID%>').show();
            idOfDivOpened = $("#" + '<%=divCloseAndIframe.ClientID%>');
            countOfDivOpened++;
        }

        return false;
    }

 
    //function to populate textbox and is called from child form (gridview.aspx)
    function SetTextBox(SelectedName, textboxID, divID,iframeDiv)
    {
        var id;
        id = document.getElementById(textboxID);
        id.value = SelectedName;
        document.getElementById(divID).style.display = 'none';
 
 }

    //Function to populate hidden field and is called from child form (gridview.aspx)
    function setHiddenfield(Code)
    {
      //debugger;
        document.getElementById('<%=hdnCode.ClientID%>').value = Code;
        selectedRowCode = Code;
       
        //alert(bankCode);

       
     }

    //function to hide div when click on close button
    function HideDivOnCloseButtonClick() {

        document.getElementById('<%=divCloseAndIframe.ClientID%>').style.display = 'none';

    }


</script>

  <table>
        
      
      <tr>
         
          <td>
              <asp:TextBox ID="txtName" runat="server" CssClass="textcssSample" ></asp:TextBox>
              </td>
               
        <td>  <asp:Button ID="btnGo" runat="server" Text=".."  class="clsGoButton"   />
      
          </td>

           </tr>
      </table>
 <asp:HiddenField ID="hdnCode" runat="server" />

<div id="divCloseAndIframe" style="display:none;position:fixed;width:305px;z-index:5;background-color:#8AC007; background:rgba(255,255,255,3);border-style: solid;
    border-width: 1px;background-color: #d7e5fa; box-shadow: 3px 3px 1px #888888; border-radius: 15px;" runat="server" >
   <table>
       <tr>
       <td style="width:90%;"><asp:Label ID="lblDivName" runat="server" Text="" ></asp:Label></td>
           <td style="width:10%;text-align:right;">
         <%-- <asp:Label ID="lblDivName" runat="server" Text="Label" Font-Bold="True" ></asp:Label>--%>
     <span onclick="HideDivOnCloseButtonClick" >X&nbsp;&nbsp;</span>
              
           </td>
       </tr>
       
       <tr>
           <td colspan="2">
                <div id="iframeDiv"  style="border:none; border:0;" runat="server">
 
     <iframe src="../UserControls/MasterPopupGridview.aspx?textboxid=<%=txtName.ClientID%>&divID=<%=divCloseAndIframe.ClientID%>&tableName=<%=tableName%>&textField=<%=textField%>&valueField=<%=valueField%>&iframeDiv=<%=iframeDiv.ClientID%>&codeHeader=<%=codeHeader%>&nameHeader=<%=nameHeader%>" style="border:0px;width:300px"></iframe> </div>
           </td>
       </tr>
   </table> 

</div>

