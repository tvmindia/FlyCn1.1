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
.btnDivCommon {
    background-color: #008B8B;
    color: white;
    display: block;
    height: 40px;
    line-height: 40px;
    text-decoration: none;
    width: 100px;
    text-align: center;
}

    </style>
       <script>

        function showHide()
        {
          
          
          
            //document.getElementById("Validate").style.display = "";
            document.getElementById("Upload").style.display = "none";
            document.getElementById("Validate").style.display = "";
            document.getElementById("GenerateTemplate").style.display = "none";
            //document.getElementById("Upload").style.visibility = "false";

        }
        function showHideMain() {



            //document.getElementById("Validate").style.display = "";
            var firstdiv = document.getElementById("Upload");
            firstdiv.style.display = "";
            document.getElementById("GenerateTemplate").style.display = "none";
            document.getElementById("Validate").style.display = "none";
            //document.getElementById("Upload").style.visibility = "false";

           

        }
        function Upload() {



            //document.getElementById("Validate").style.display = "";
            document.getElementById("Upload").style.display = "none";
            document.getElementById("Validate").style.display = "none";
            document.getElementById("GenerateTemplate").style.display = "none";
            document.getElementById("DivValidate").style.display = "";
            //document.getElementById("Upload").style.visibility = "false";

           

        }
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       
      <div id="content">
             <div class="contentTopBar"></div>
    <div id="Heading" runat="server" >
          <ul class="list-inline" id="horizonaltab"  runat="server" style="width:100%;" >
             </ul>
    </div>
              <table style="margin-left:30px;">
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
                  </table>
    <div id="body" runat="server" class="container table-responsive" style="width: 100%; height:100%; margin-left:50px;" >
         
     
        <div id="GenerateTemplate">

        <table>
           
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
<%--                    <asp:Button ID="btnNext" runat="server" Text="Next>>"  Height="35px" Width="100px"   CssClass="buttonNext"  OnClientClick="NextClick()" OnClick="btnNext_Click" />--%>

           <div style="margin-left:500px;">

          
                                      <a href="#" class="buttonNext" onclick="return showHideMain();" >
  <div id="btnMainDiv" class="nav btnDivCommon">
   Next>>
  </div>
</a>
     </div>                        
        </div>

        </div>

           <div id="Upload"  style="display:none" >

       
             <div class="col-md-12 Span-One" >
                    <div class="col-md-6" >
                        <table>
            <tr>
                <td>
                      <asp:Label ID="Label1" runat="server" CssClass="moduleHeading"></asp:Label>
                </td>
            </tr>
          
            <tr style="height:30px;">
                <td>
                  
            <asp:Label ID="Label2" Text="Generate Template>>Upload>>Validate>>Import" runat="server" CssClass="caption" style="font:bold; margin-left:50px;"></asp:Label>

                 
                </td>
            </tr>
            <tr style="height:30px;">
                <td>
&nbsp
                </td>
            </tr>
           <tr style="height:30px;">
               
                <td>

            <asp:FileUpload ID="DataImportFileUpload" runat="server"  CssClass="fileUploadbutton"/>     
                       
                </td>
               <td>
                   <asp:Button ID="btnUpload" runat="server" Text="Upload" />
               </td>
               
            </tr>
            <tr style="height:30px;">
                <td>

                </td>
            </tr>
          </table>
                        
                        </div>
              
              
                     <div class="col-md-6" style="width:50%;">
                        
                         <table class="table table-bordered" style="width:40%;">
            <tr>
                <td>

                </td>
                <td>

                </td>
            </tr>
             <tr>
                <td>

                </td>
                <td>

                </td>
            </tr>
                             <tr>
                <td>

                </td>
                <td>

                </td>
            </tr>
                             <tr>
                <td>

                </td>
                <td>

                </td>
            </tr>

                             <tr>
                <td>

                </td>
                <td>

                </td>
            </tr>
        </table>
                         <table style="margin-left:100px;">
                            <tr>
                                <td>
                                      <a href="#" class="buttonNext" onclick="return showHide();">
  <div id="btnDiv" class="nav btnDivCommon">
   Next>>
  </div>
</a>
                                </td>
                            </tr>
                         </table>
                        </div>
                       <%--     <asp:Button ID="btnNext" runat="server" Text="Next>>"  Height="35px" Width="100px"   CssClass="buttonNext" OnClientClick="NextClick()"   />--%>
               
                 </div>
             </div>
        <div  style="display:none" id="Validate">
<div class="col-md-12 Span-One" >
                    <div class="col-md-6">
                        <table>
            <tr>
                <td>
                      <asp:Label ID="Label3" runat="server" CssClass="moduleHeading"></asp:Label>
                </td>
            </tr>
          
            <tr style="height:30px;">
                <td>
                  
            <asp:Label ID="Label4" Text="Generate Template>>Upload>>Validate>>Import" runat="server" CssClass="caption" style="font:bold; margin-left:50px;"></asp:Label>

                 
                </td>
            </tr>
            <tr style="height:30px;">
                <td>

                            <asp:Label ID="lbltableHeading" runat="server" Text="Validation error rows"></asp:Label>
                </td>
            </tr>
           <tr style="height:30px;">
               
                <td>

      <table class="table-bordered" >
          <tr>
              <td>
                  
              </td>
              <td>

                  </td>
          </tr>
                <tr>
              <td>
                  
              </td>
              <td>

                  </td>
          </tr>
                <tr>
              <td>
                  
              </td>
              <td>

                  </td>
          </tr>
                <tr>
              <td>
                  
              </td>
              <td>

                  </td>
          </tr>
      </table>
                       
                </td>
               <td>
                   <asp:Button ID="Button1" runat="server" Text="Upload" />
               </td>
               
            </tr>
            <tr style="height:30px;">
                <td>

                </td>
            </tr>
          </table>
                        
                        </div>
                   <%-- <hr />--%>
              
                     <div class="col-md-6" >
                        
                         <table class="table table-bordered" style="width:40%;">
            <tr>
                <td>

                </td>
                <td>

                </td>
            </tr>
             <tr>
                <td>

                </td>
                <td>

                </td>
            </tr>
                             <tr>
                <td>

                </td>
                <td>

                </td>
            </tr>
                             <tr>
                <td>

                </td>
                <td>

                </td>
            </tr>

                             <tr>
                <td>

                </td>
                <td>

                </td>
            </tr>
        </table>

                         <table>
                            <tr>
                                <td>
                                      <a href="#" class="buttonNext btnDivCommon" onclick="return Upload();">
  <div id="btnDivUpload" class="nav btnDivCommon">
   Next>>
  </div>
</a>
                                </td>
                            </tr>
                         </table>
                        </div>
                          <%--  <asp:Button ID="Button2" runat="server" Text="Next>>"  Height="35px" Width="100px"   CssClass="buttonNext"   />--%>
      
                 </div>
        </div>

          <div  style="display:none" id="DivValidate">
<div class="col-md-12 Span-One" >
                    <div class="col-md-6" >
                        
                         <table class="table table-bordered" style="width:90%;">
            <tr>
                <td>

                </td>
                <td>

                </td>
            </tr>
             <tr>
                <td>

                </td>
                <td>

                </td>
            </tr>
                             <tr>
                <td>

                </td>
                <td>

                </td>
            </tr>
                             <tr>
                <td>

                </td>
                <td>

                </td>
            </tr>

                             <tr>
                <td>

                </td>
                <td>

                </td>
            </tr>
        </table>

                         
                        </div>
                   <%-- <hr />--%>
              
                     <div class="col-md-6" >
                        
                         <table class="" style="width:50%;">
            <tr>
                <td>
Uploaded file 

                </td>
                <td>
: aasasas.xlsx

                </td>
            </tr>
             <tr>
                <td>
Total rows

                </td>
                <td>
: 100

                </td>
            </tr>
                             <tr>
                <td>
Existing

                </td>
                <td>
: 25

                </td>
            </tr>
                             <tr>
                <td>
New

                </td>
                <td>
: 75

                </td>
            </tr>

                             <tr>
                <td>
Errors

                </td>
                <td>
: 1

                </td>
            </tr>
        </table>

                         <table>
                            <tr>
                                <td>
                                      <a href="#" class="buttonNext btnDivCommon" >
  <div id="btnDivValidate" class="nav btnDivCommon">
  Import
  </div>
</a>
                                </td>
                            </tr>
                         </table>
                        </div>
                          <%--  <asp:Button ID="Button2" runat="server" Text="Next>>"  Height="35px" Width="100px"   CssClass="buttonNext"   />--%>
      
                 </div>
        </div>
         <%--   <iframe id="IframeDataImport" style="width:1000px; height:700px; display:block;" runat="server" >
                </iframe>--%>
        </div>
       
</asp:Content>
