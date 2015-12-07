<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="EnggDatalistBaseTable.aspx.cs" Inherits="FlyCn.EngineeredDataList.EnggDatalistBaseTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

.button {
 
 /*Step 2: Basic Button Styles*/
 display: block;
 height: 100px;
 width: 300px;
 background: #34696f;
 border: 2px solid rgba(33, 68, 72, 0.59);
 color:white;
 /*Step 3: Text Styles*/
 
 text-align: center;
 font: bold 3.2em/100px "Helvetica Neue", Arial, Helvetica, Geneva, sans-serif;
}
 .moduleHeading
 {
     font-size:15px;
     font-family:'Segoe UI';
 }
 .caption
 
 {
     font-size:15px;
     margin-left:40px;
 }
 .buttonNext
 {
     margin-left:300px;
 }
/*Step 3: Link Styling*/
a.button {
 text-decoration: none;
}
.buttonExcelImport
{
    margin-left:90px;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div id="content">
             <div class="contentTopBar"></div>
    <div id="body" runat="server" class="container table-responsive" style="width: 100%; height:100%; margin-left:50px;" >
         
         <ul class="list-inline" id="horizonaltab"  runat="server" style="width:100%">
             </ul>
        <div>

        <table>
            <tr>
                <td>
                      <asp:Label ID="lblModule" runat="server" CssClass="moduleHeading"></asp:Label>
                </td>
            </tr>
            <tr style="height:30px;">
                <td>
&nbsp
                </td>
            </tr>
            <tr>
                <td>
                  
            <asp:Label ID="lblCaption" Text="Generate Template>>Upload>>Validate>>Import" runat="server" CssClass="caption" style="font:bold;"></asp:Label>

                 
                </td>
            </tr>
            <tr  style="height:30px;">

            </tr>
            <tr style="height:30px;">
                <td>
            <asp:Button ID="btnExcelIimport" runat="server" Text="Get Excel Import"  CssClass="buttonExcelImport"/>
                    
                </td>
            </tr>
            <tr style="height:30px;">
                <td>

                </td>
            </tr>
        </table>  
      
            


           
            <ul style="list-style-type:disc">
  <li>Please save the excel</li>
  <li>fill the data and make it ready for upload</li>
  <li>click Next Button to get upload option</li>
</ul>
                    <asp:Button ID="btnNext" runat="server" Text="Next>>"  Height="35px" Width="100px"   CssClass="buttonNext" />

        </div>
        </div>
        </div>
</asp:Content>
