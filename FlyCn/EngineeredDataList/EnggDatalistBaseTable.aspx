<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="EnggDatalistBaseTable.aspx.cs" Inherits="FlyCn.EngineeredDataList.EnggDatalistBaseTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
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
 .menu{width: 300px; height: 25; font-size: 18px;}
  .menu li{list-style: none; float: left; margin-right: 4px; padding: 5px;}
  .menu li:hover, .menu li.active {
        background-color: #f90;
    }
 /*.line {
  padding-right: 20px;
  border-right: 1px solid #cfc7c0;
}*/
 /*.line:after {
   
    border-right: 1px solid #cfc7c0;
}*/
 .cat {
     color:red;
    
}
 /*/*departments 
 {
   
 }

ul.departments { list-style-type: none; }*/

ul.departments li a
 { 
    color:green;
     }

ul.departments li a:hover { color:brown}
ul.departments li a::selection { color:blue}

 .selected {
    background-color: blue;
}
 a
 {
color:brown;
 }
 
#nav {  

}  

#nav li { 

    
}  

#nav li a {  
    color: #39aea8;  
   
 }  



ul, li {  
margin: 0; padding: 0;  
}  

ul#nav li a:link,ul#nav li a:visited {
color:green;
text-decoration:solid;
}

ul#nav li a:hover,ul#nav li a:active {
color:  #f4ba51 ;
text-decoration:solid;
}
    </style>

       <script>
          
           
           function UploadNextClick()
           {
               document.getElementById("Upload").style.display = "none";
               document.getElementById("DivValidate").style.display = "";
               document.getElementById("GenerateTemplate").style.display = "none";
               document.getElementById("Import").style.display = "none";
           }
           function GenerateTemplateNextClick()
           {
               var firstdiv = document.getElementById("Upload");
               firstdiv.style.display = "";
               document.getElementById("GenerateTemplate").style.display = "none";
               document.getElementById("DivValidate").style.display = "none";
               document.getElementById("Import").style.display = "none";
           }
         

           function Import()
           {
               document.getElementById("Upload").style.display = "none";
               document.getElementById("DivValidate").style.display = "none";
               document.getElementById("GenerateTemplate").style.display = "none";
               document.getElementById("Import").style.display = "";
           }

           function GenerateTemplateDivShow() {
               document.getElementById("Upload").style.display = "none";
               document.getElementById("Import").style.display = "none";
               document.getElementById("GenerateTemplate").style.display = "";
               document.getElementById("DivValidate").style.display = "none";
            
           }
           
           //function codeAddress() {
           //    alert('ok');
           //    parent.OnEnggDataListTreeBinding();
           //}
           //window.onload = codeAddress;
       </script>
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
       
     
    <div id="Heading" runat="server" style="width: 90%; text-align: center;margin:20px">
          <ul class="list-inline" id="horizonaltab"  runat="server" style="width:100%;" >
                <li style="width: 10px;"></li>
              
             </ul>
    </div>
              <table style="margin-left:30px;">
            <tr>
                <td>
                  <asp:Label ID="lblModule" runat="server"  CssClass="PageHeading"></asp:Label>
                </td>
            </tr>
            <tr style="height:30px;">
                <td>
&nbsp
                </td>
            </tr>
                  <tr>
                      <td>

                      </td>
                      <td style="width:100%">
                        <div id="nav"  >
                           <ul  class="list-inline" id="NavItem"  runat="server" style="width:100%;" >
                               <li>

                               </li>
              <li ><a href="#" onclick= 'GenerateTemplateDivShow();'>
                  Generate Template>>
                  </a>
              </li>
                                <li ><a href="#" onclick= 'GenerateTemplateNextClick();'>
                                    Upload>>
                                    </a>
                                    </li>
                               <li >
                                   <a href="#" onclick= 'UploadNextClick();'>
                                   Validate>>
                                       </a>
                               </li>
                               <li >
                                   <a href="#" onclick= 'Import();'>
                                 Import
                                       </a>
                               </li>
                               </ul>
                            </div>
                      </td>
                  </tr>
                  </table>
    <div id="body" runat="server" class="container table-responsive" style="width: 100%; height:100%; margin-left:50px;" >
         
     
        <div id="GenerateTemplate">
             <div class="col-md-12 Span-One" >
        <table>
           
            
            <tr style="height:30px;">
                <td>
                  
           

                 
                </td>
            </tr>
            <tr style="height:30px;">
                <td>
            <asp:Button ID="btnExcelIimport" runat="server" Text="Get Excel Import"  CssClass="buttonExcelImport" OnClick="btnExcelIimport_Click"/>
                    
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
                           <div style="overflow-y:scroll; height:190px;">
                           <asp:UpdatePanel ID="dtgUploadGridUpdatepanel" runat="server" UpdateMode="Conditional">
                   <ContentTemplate>
                  <telerik:RadGrid ID="dtgUploadGrid" runat="server"  AllowSorting="true"   Width="30%"
                        OnNeedDataSource="dtgUploadGrid_NeedDataSource" AllowMultiRowSelection="True" 
                        Skin="Silk" CssClass="outerMultiPage"  OnPreRender="dtgUploadGrid_PreRender"  OnItemCommand="dtgUploadGrid_ItemCommand"
                      OnItemDataBound="dtgUploadGrid_ItemDataBound"  >
                       

                        <MasterTableView DataKeyNames="">

                            <Columns>
                       <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" Display="true">
            <ItemTemplate>
                <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="ToggleRowSelection"
                    AutoPostBack="True" Checked="true" />
            </ItemTemplate>
            <HeaderTemplate>
                <asp:CheckBox ID="headerChkbox" runat="server" OnCheckedChanged="ToggleSelectedState" Checked="true"
                    AutoPostBack="True" />
            </HeaderTemplate>
        </telerik:GridTemplateColumn>

                            </Columns>
                        </MasterTableView>
                    
                    </telerik:RadGrid>
                       </ContentTemplate>
                               </asp:UpdatePanel>
                            </div>
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
                      <asp:Label ID="lblValidationErrorRows" runat="server" Text="Validation error rows"></asp:Label>
                         
                       <telerik:RadGrid ID="dtgvalidationErros" runat="server"  AllowSorting="true"   Width="50%"
                        OnNeedDataSource="dtgvalidationErros_NeedDataSource" AllowMultiRowSelection="True" 
                        Skin="Silk" CssClass="outerMultiPage"  > 
                   
                       

                        <MasterTableView DataKeyNames="">

                            <Columns>
                       

                            </Columns>
                        </MasterTableView>
                    
                    </telerik:RadGrid>
                         
                        </div>
                   <%-- <hr />--%>
              
                     <div class="col-md-6" style="border-left:1px solid #cfc7c0;" >
                        
                         <table class="" style="width:40%;">
            <tr>
                <td>
                          <asp:Label ID="lblVupldFile" runat="server" Text="Uploaded file"></asp:Label>


                </td>
                <td>
                    :
                </td>
            
                <td>
                      <asp:Label ID="lblVupldFilename" runat="server" Text="aasasas.xlsx"></asp:Label>


                </td>
            </tr>
             <tr>
                <td>
                      <asp:Label ID="lblVtotlrows" runat="server" Text="Total rows"></asp:Label>


                </td>
                     <td>
:
                </td>
                <td>
                      <asp:Label ID="lblVtotltowcount" runat="server" Text="100"></asp:Label>



                </td>
            </tr>
                             <tr>
                <td>
                      <asp:Label ID="lblVexisting" runat="server" Text="Existing"></asp:Label>



                </td>
                                 <td>
:
                </td>
                <td>
                      <asp:Label ID="lblVexistingCount" runat="server" Text="25"></asp:Label>

                     

                </td>
            </tr>
                             <tr>
                <td>
                      <asp:Label ID="lblVNew" runat="server" Text="New"></asp:Label>



                </td>
                                 <td>
:
                </td>
                <td>
                      <asp:Label ID="lblVNewCount" runat="server" Text="75"></asp:Label>



                </td>
            </tr>

                             <tr>
                <td>
                      <asp:Label ID="lblVErrors" runat="server" Text="Errors"></asp:Label>



                </td>
                                 <td>
:
                </td>
                <td>
                      <asp:Label ID="lblVErrorsCount" runat="server" Text=" 1"></asp:Label>


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
                    <a href="../ExcelImport/ImportStatusList.aspx" target="_self" class="a">Import Status</a>
                   <%-- <asp:LinkButton ID="LbtnImportStatus" runat="server"  ForeColor="#006699"><a href="../ExcelImport/ImportStatusList.aspx" target="_self">Import Status</a></asp:LinkButton>--%>
                </td>
            </tr>
        </table>

                         
                        </div>
                   <%-- <hr />--%>
              
                     <div class="col-md-6" style="border-left:1px solid #cfc7c0;" >
                        
                         <table class="" style="width:50%;">
            <tr>
                <td>
                          <asp:Label ID="lblIupldFile" runat="server" Text="Uploaded file"></asp:Label>



                </td>
                 <td>
                    :
                </td>
                <td>
                          <asp:Label ID="lblIupldFileName" runat="server" Text="aasasas.xlsx"></asp:Label>



                </td>
            </tr>
             <tr>
                <td>
                          <asp:Label ID="lblITotlrows" runat="server" Text="Total rows"></asp:Label>



                </td>
                  <td>
                    :
                </td>
                <td>
                          <asp:Label ID="lblITotlrowsCount" runat="server" Text="100"></asp:Label>



                </td>
            </tr>
                             <tr>
                <td>
                          <asp:Label ID="lblIExisting" runat="server" Text="Existing"></asp:Label>
                    


                </td>
                                  <td>
                    :
                </td>
                <td>
                          <asp:Label ID="lblIExistingCount" runat="server" Text=" 25"></asp:Label>



                </td>
            </tr>
                             <tr>
                <td>
                          <asp:Label ID="lblINew" runat="server" Text="New"></asp:Label>



                </td>
                                  <td>
                    :
                </td>
                <td>
                          <asp:Label ID="lblINewCount" runat="server" Text="75"></asp:Label>



                </td>
            </tr>

                             <tr>
                <td>
<asp:LinkButton ID="lbtnErrors" runat="server" ForeColor="#006699">Errors</asp:LinkButton>
                </td>
                                  <td>
                    :
                </td>
                <td>
                          <asp:Label ID="lblIerrorCount" runat="server" Text="1"></asp:Label>

 
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
       
       
</asp:Content>
