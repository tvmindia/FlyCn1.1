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
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
        <div id="containerTab" runat="server" style="width: 90%; text-align: center;margin:20px">

            <ul class="list-inline" id="horizonaltab" runat="server" style="width: 100%">

                <li style="width: 10px;"></li>


            </ul>

        </div>
        <div id="body" runat="server" class="container table-responsive" style="width: 100%; height: 100%;">
        </div>
     
</asp:Content>
