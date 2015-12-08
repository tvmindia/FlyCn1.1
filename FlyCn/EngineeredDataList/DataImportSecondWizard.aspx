<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="DataImportSecondWizard.aspx.cs" Inherits="FlyCn.EngineeredDataList.DataImportSecondWizard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        
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
 .fileUploadbutton
 
 {
     font-size:15px;
     margin-left:40px;
 }
 .buttonNext
 {
     margin-left:900px;
     text-align:center;
     padding-left:1000px;
 }
/*Step 3: Link Styling*/
a.button {
 text-decoration: none;
}
.buttonExcelImport
{
    margin-left:90px;
}
.verticalLine {
    border-left: thick solid #ff0000;
}
hr.vertical
{
   width: 0px;
   height: 100%; /* or height in PX */
} 
hr {
  transform: rotate(90deg);
}
vr {
    display: block;
    width:10px;
    background-color:#000;
    position:absolute;
    top:0;
    bottom:0;
    left:150px;
}

#btnDiv {
    background-color: black;
    color: white;
    display: block;
    height: 40px;
    line-height: 40px;
    text-decoration: none;
    width: 100px;
    text-align: center;
}
#btnDiv2 {
    background-color: black;
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
          
          
          
            //document.getElementById("2ndDiv").style.display = "";
            var firstdiv =  document.getElementById("1stDiv");
            firstdiv.style.display = "none";
            //document.getElementById("1stDiv").style.visibility = "false";

            alert(3);
            
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width:100%;" class="table-responsive">
       
       
        
    </div>
   
   
      
</asp:Content>
