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
    text-align:right;
}
.tab {
    padding:.5em 3em;   
    display:inline-block;
}
.tab2 {
   border-bottom-color:#ccc; /* same as .content background */
   margin-bottom:-2px; /* .content border width */
   border-radius:20px 10px 0 0; /* tweak to preference */
}
   </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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

       <div class="tabs" id="containerTab">
    <div class="tab tab1">Tab 1</div>
    <div class="tab tab2">Tab 1</div>
            <a  href="EnggDatalistBaseTable.aspx"  > <div class="tab tab2">Tab 1q</div></a>
               <div class="tab tab2">Tab 1</div>
               <div class="tab tab2">Tab 1</div>
               <div class="tab tab2">Tab 1</div>
</div>
   </div>

</asp:Content>
