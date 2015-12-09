<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="EnggDatalistBaseTable.aspx.cs" Inherits="FlyCn.EngineeredDataList.EnggDatalistBaseTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

.buttonTable
{
margin-left:70%;
margin-top:60%;
}
 .moduleHeading
 {
     font-size:14px;
     font-family:'Segoe UI';
 }
 .caption
 
 {
     font-size:14px;
     margin-left:40px;
 }

 /*.line {
  padding-right: 20px;
  border-right: 1px solid #cfc7c0;
}*/
 .line:after {
   
    border-right: 1px solid #cfc7c0;
}


    </style>
       <script>

           function UploadNextClick()
           {
               document.getElementById("Upload").style.display = "none";
               document.getElementById("DivValidate").style.display = "";
               document.getElementById("GenerateTemplate").style.display = "none";
           }
           function GenerateTemplateNextClick()
           {
               var firstdiv = document.getElementById("Upload");
               firstdiv.style.display = "";
               document.getElementById("GenerateTemplate").style.display = "none";
               document.getElementById("Validate").style.display = "none";
           }
           function Upload()
           {
               document.getElementById("Upload").style.display = "none";
               document.getElementById("Validate").style.display = "none";
               document.getElementById("GenerateTemplate").style.display = "none";
               document.getElementById("DivValidate").style.display = "";
        
           }

           function Import()
           {
               document.getElementById("Upload").style.display = "none";
               document.getElementById("DivValidate").style.display = "none";
               document.getElementById("GenerateTemplate").style.display = "none";
               document.getElementById("Import").style.display = "";
           }
        
       </script>
    <script type="text/javascript">
        $(function () {

            $('#Heading ul li a').each(function () {
               
                    $(this).addClass('active');
               
            });
        });

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
             <div class="col-md-12 Span-One" >
        <table>
           
            <tr style="height:30px;">
                <td>
 <asp:Label ID="lblCaption" Text="Generate Template>>Upload>>Validate>>Import" runat="server"  CssClass="caption" style="font:bold;"></asp:Label>
                </td>
            </tr>
            <tr style="height:30px;">
                <td>
                  
           

                 
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
                 </div>
        
             <table class="buttonTable">
                            <tr>
                                <td>
          
                                      <a href="#" class="buttonNext" onclick="return GenerateTemplateNextClick();" >
  <div id="btnMainDiv" class="nav btnDivCommon">
   Next>>
  </div>
</a>
                                    </td>
                                </tr>
                                    </table>
     </div>                        
        

        </div>

           <div id="Upload"  style="display:none;margin-left:50px;" >

       
             <div class="col-md-12 Span-One" >
                    <div class="col-md-6"  >
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
              
               
                     <div class="col-md-6" style="width:50%; border-left:1px solid #cfc7c0;">
                        
                 <asp:Label ID="lblUploadGridHeading" runat="server" Text="Choose Fields"></asp:Label>
                         <table class="table table-bordered" style="width:35%;">
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

                        
                       <%--     <asp:Button ID="btnNext" runat="server" Text="Next>>"  Height="35px" Width="100px"   CssClass="buttonNext" OnClientClick="NextClick()"   />--%>
               
                 </div>

               <table class="buttonTable">
                            <tr>
                                <td>
                                      <a href="#" class="buttonNext" onclick="return UploadNextClick();">
  <div id="btnDiv" class="nav btnDivCommon">
   Next>>
  </div>
</a>
                                </td>
                            </tr>
                         </table>
             </div>

        

          <div  style="display:none;margin-left:50px;" id="DivValidate">
<div class="col-md-12 Span-One" >
                    <div class="col-md-6" >
                         <asp:Label ID="Label3" runat="server" CssClass="moduleHeading"></asp:Label>
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
              
                     <div class="col-md-6" style="border-left:1px solid #cfc7c0;" >
                        
                         <table class="" style="width:30%;">
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

                       
                        </div>

      
                          <%--  <asp:Button ID="Button2" runat="server" Text="Next>>"  Height="35px" Width="100px"   CssClass="buttonNext"   />--%>
      
                 </div>

              <table class="buttonTable">
                            <tr>
                                <td>
                                      <a href="#" class="buttonNext btnDivCommon"  onclick="return Import();" >
  <div id="btnDivValidate" class="nav btnDivCommon">
  Import
  </div>
</a>
                                </td>
                            </tr>
                         </table>
        </div>
      

          <div  style="display:none;margin-left:50px;" id="Import">
<div class="col-md-12 Span-One" >
                    <div class="col-md-6" >
                        
                         <table class="" style="width:90%;">
            <tr>
                <td>
                     Generate Template >>Upload>>Validate >>Import
                </td>
               

            </tr>
             <tr style="height:20px;">
                
                <td>

                </td>
            </tr>
                             <tr>
                <td>
Data import started …../Data import success				

                </td>
                
            </tr>
                             <tr style="height:20px;">
                                 
                
                <td>

                </td>
            </tr>

                             <tr>
                
                <td>
                    <asp:LinkButton ID="LbtnImportStatus" runat="server"  ForeColor="#006699">Import Status</asp:LinkButton>
                </td>
            </tr>
        </table>

                         
                        </div>
                   <%-- <hr />--%>
              
                     <div class="col-md-6" style="border-left:1px solid #cfc7c0;" >
                        
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
<asp:LinkButton ID="lbtnErrors" runat="server" ForeColor="#006699">Errors</asp:LinkButton>
                </td>
                <td>
: 1

                </td>
            </tr>
        </table>

                       
                        </div>

      
                          <%--  <asp:Button ID="Button2" runat="server" Text="Next>>"  Height="35px" Width="100px"   CssClass="buttonNext"   />--%>
      
                 </div>

              <table class="buttonTable">
                            <tr>
                                <td>
                                      <a href="#" class="buttonNext btnDivCommon" >
  <div id="btnImport" class="nav btnDivCommon">
  Done
  </div>
</a>
                                </td>
                            </tr>
                         </table>
        </div>
        </div>
       
</asp:Content>
