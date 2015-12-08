<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="EnggDataListLandingPage.aspx.cs" Inherits="FlyCn.EngineeredDataList.EnggDataListLandingPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>
    <script>
        $(function () {
            // setup ul.tabs to work as tabs for each div directly under div.panes
            $("ul.tabs").tabs("div.panes > div");
        });

    </script>
   <style>
       .tabs {
    text-align:left;
    width:100%;
}
         
.tab {
   
    /*display:inline-block;*/
}

.tab2 {
   border-bottom-color:#ccc; /* same as .content background */
   margin-bottom:-2px; /* .content border width */
   border-radius:20px 10px 0 0; /* tweak to preference */
   border:5px;
}
#li {
     border-bottom-color:#ccc; /* same as .content background */
   margin-bottom:-2px; /* .content border width */
   border-radius:20px 10px 0 0;
}
   </style>
  <%-- <style>
        ul.result li div#a{ color: red; }
        ul.result li div#b{ color: green; }
        ul.result li div#c{ color: blue; }
    </style>  --%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div id="content">
             <div class="contentTopBar"></div>
          <div id="containerTab"   runat="server" style="width:100%;">

           <ul class="list-inline" id="horizonaltab"  runat="server" style="width:100%">
 
 <%-- <li ><a href="#"><img src="../Images/Icons/Civil16.png" /></a></li>
  <li ><a href="#"><img src="../Images/Icons/Civil48.png" /></a></li>
  <li><a href="#"><img src="../Images/Icons/Civil48.png" /></a></li>--%>
</ul>
     <%-- <a  href="EnggDatalistBaseTable.aspx"  > <div class="tab tab1">Tab 1</div></a>
      <a  href="EnggDatalistBaseTable.aspx"  > <div class="tab tab2">Tab 1</div></a>
            <a  href="EnggDatalistBaseTable.aspx"  > <div class="tab tab2">Tab 1q</div></a>
               <a  href="EnggDatalistBaseTable.aspx"  >   <div class="tab tab2">Tab 1</div></a>
                <a  href="EnggDatalistBaseTable.aspx"  >  <div class="tab tab2">Tab 1</div></a>
                <a  href="EnggDatalistBaseTable.aspx"  >  <div class="tab tab2">Tab 1</div></a>--%>
</div>
   <div id="body" runat="server" class="container table-responsive" style="width: 100%; height:100%; margin-left:50px;" >
    <%--<div style="width:100%">
  <div style="width:543px;">
    First pane. <a href="#third">open third tab</a>
  </div>
  <div>
    Second pane. You can open other tabs with normal
    <a href="#first">anchor links</a>
  </div>
  <div>
    Third tab content
  </div>
</div>--%>


       
       <%--<div  >
              <ul class="result">
        <li><div id="a">This is red</div></li>
        <li><div id="b">This is green</div></li>
        <li><div id="c">This is blue</div></li>
    </ul>
       </div>--%>
   </div>
          </div>
</asp:Content>
