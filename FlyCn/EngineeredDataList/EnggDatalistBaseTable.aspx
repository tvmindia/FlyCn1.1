<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="EnggDatalistBaseTable.aspx.cs" Inherits="FlyCn.EngineeredDataList.EnggDatalistBaseTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
    <style type="text/css">
        .buttonTable {
            margin-left: 70%;
            margin-top: 60%;
        }

        .moduleHeading {
            font-size: 14px;
            font-family: 'Segoe UI';
        }

        .caption {
            font-size: 14px;
            margin-left: 40px;
        }

        .menu {
            width: 300px;
            height: 25;
            font-size: 18px;
        }

            .menu li {
                list-style: none;
                float: left;
                margin-right: 4px;
                padding: 5px;
            }

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
            color: red;
        }
        /*/*departments 
 {
   
 }

ul.departments { list-style-type: none; }*/

        ul.departments li a {
            color: green;
        }

            ul.departments li a:hover {
                color: brown;
            }


            ul.departments li a::selection {
                color: blue;
            }

        .selected {
            background-color: blue;
        }

        a {
            color: brown;
        }

        #nav {
        }

            #nav li {
            }

                #nav li a {
                    color: #39aea8;
                }



        ul, li {
            margin: 0;
            padding: 0;
        }

            ul#nav li a:link, ul#nav li a:visited {
                color: green;
                text-decoration: solid;
            }

            ul#nav li a:hover, ul#nav li a:active {
                color: #f4ba51;
                text-decoration: solid;
            }
    </style>
    <script src="../Scripts/UserJs/UserValidations.js"></script>
    <script>


        function UploadNextClick() {
            document.getElementById("Upload").style.display = "none";
            document.getElementById("DivValidate").style.display = "";
            document.getElementById("GenerateTemplate").style.display = "none";
            document.getElementById("Import").style.display = "none";
        }
        function GenerateTemplateNextClick() {
            var firstdiv = document.getElementById("Upload");
            firstdiv.style.display = "";
            document.getElementById("GenerateTemplate").style.display = "none";
            document.getElementById("DivValidate").style.display = "none";
            document.getElementById("Import").style.display = "none";
        }


        function Import() {
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
    <script>
          
           function validateExcel() {

            var fileUpload = document.getElementById('<%=DataImportFileUpload.ClientID%>');
            var Extension = fileUpload.value.substring(fileUpload.value.lastIndexOf('.') + 1).toLowerCase();
            var flag=validateExcelExtension(Extension)
            if (flag!=false) {
                return true;
            }
            else {
                var lblmsg = document.getElementById('<%=lblMsg.ClientID%>');
                lblmsg.innerHTML = "Kindly Upload file types of xlsx or xls";
                //var upload = document.getElementById('Gridandbutton');
                //upload.style.display = "none";
                DisableGridandButton();
                return false;
            }
           }
        function DisableGridandButton()
        {
           // dtgUploadGrid.get_element().disabled = "disabled";
            var disdtg = $find("<%=dtgUploadGrid.ClientID%>");
            //disdtg.disabled = "disabled";
            DisableGrid(disdtg);
            document.getElementById('<%= btnValidate.ClientID %>').disabled = true;

        }

        //function EnableGridandButton()
        //{
        //   // document.getElementById("btnValidate").disabled = true;
        //    alert("js");
        //   // var upload = document.getElementById('Gridandbutton');
        //   // upload.style.display = "";
        // }
    </script>


    <div id="Heading" runat="server" style="width: 90%; text-align: center; margin: 20px">
        <ul class="list-inline" id="horizonaltab" runat="server" style="width: 100%;">
            <li style="width: 10px;"></li>
                
        </ul>
    </div>
    <table style="width:100%">
        <tr>
            <td style="width:30%">
                <asp:Label ID="lblModule" runat="server" CssClass="PageHeading"></asp:Label>
           </td>
            <td style="text-align:right;vertical-align:bottom">

                  <div id="nav" class="NavButton">
                    <ul class="list-inline" id="NavItem" runat="server" style="width: 100%;">
                        <li></li>
                        <li><a href="#" onclick='GenerateTemplateDivShow();'>Generate Template &nbsp;&nbsp; <img src="../Images/Icons/RightArrow16.png" />
                        </a>
                        </li>
                        <li><a href="#" onclick='GenerateTemplateNextClick();'>Upload &nbsp;&nbsp; <img src="../Images/Icons/RightArrow16.png" />
                        </a>
                        </li>
                        <li>
                            <a href="#" onclick='UploadNextClick();'>Validate &nbsp;&nbsp; <img src="../Images/Icons/RightArrow16.png" />
                            </a>
                        </li>
                        <li>
                            <a href="#" onclick='Import();'>Import
                            </a>
                        </li>
                    </ul>
                </div>
            </td>
            <td style="width:10%"></td>
        </tr>
     
         
    </table>

    <div class="importWizardContainer">
    <div id="body" runat="server" class="container table-responsive" style="width: 96%; height: 100%; margin-left: 5px;">


        <div id="GenerateTemplate" >
            <div class="col-md-12 Span-One">
                 <asp:Button class="Flatbutton" style="width:300px" ID="btnExcelIimport" runat="server" Text="Download Excel Template"  OnClick="btnExcelIimport_Click"  />
                    




                <ul class="importWizardList">
                    <li>Please save the excel</li>
                    <li>fill the data and make it ready for upload</li>
                    <li>click Next Button to get upload option</li>
                </ul>
                <%--                    <asp:Button ID="btnNext" runat="server" Text="Next>>"  Height="35px" Width="100px"   CssClass="buttonNext"  OnClientClick="NextClick()" OnClick="btnNext_Click" />--%>
            </div>

            <table class="buttonTable">
                <tr>
                    <td>
                        <div class="Flatbutton" style="width:150px">
                             <a href="#" class="buttonNext" onclick="return GenerateTemplateNextClick();">
                            <div id="btnMainDiv" class="nav" style="color:white">
                                Next &nbsp;<img src="../Images/Icons/RightArrow16.png" />
                            </div>
                        </a>
                        </div>
                       
                    </td>
                </tr>
            </table>
        </div>


   

    <div id="Upload" style="display: none; margin-left: 2px;">


        <div class="col-md-12 Span-One" style="vertical-align:middle">
            <div class="col-md-4" style="text-align:left;margin-top:5%">

                 <div class="col-md-10">
               
                    <asp:FileUpload ID="DataImportFileUpload" runat="server" class="FlatbuttonUpload" width="300px" /> </div>
                  <div class="col-md-2">
                    <asp:Button ID="btnUpload" runat="server" Text="Upload" class="Flatbutton" OnClientClick="return validateExcel()" OnClick="btn_upload_Click" Style="width: 80px" /> 
                 </div>
                 <div>
                   <asp:Label ID="lblMsg" runat="server" Text="" Font-Bold="true"></asp:Label>
                 </div>

            </div>
            <div class="col-md-1">&nbsp;</div>
            <div class="col-md-1"  style="border-left: 1px solid #cfc7c0;min-height:250px">&nbsp;</div>


         
            <div class="col-md-5" id="Gridandbutton">
                <%--<div >--%>
                <asp:Label ID="lblUploadGridHeading" runat="server" Text="Choose Fields" CssClass="subtitle"></asp:Label>
              <div style="height: 220px;" class="chooseFieldsBox">
                <div  style="overflow-y: scroll; height: 200px;">
                    <asp:UpdatePanel ID="dtgUploadGridUpdatepanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <telerik:RadGrid ID="dtgUploadGrid" runat="server" AllowSorting="true" 
                                OnNeedDataSource="dtgUploadGrid_NeedDataSource" AllowMultiRowSelection="True"
                                Skin="Silk" CssClass="outerMultiPage" OnPreRender="dtgUploadGrid_PreRender" OnItemCommand="dtgUploadGrid_ItemCommand"
                                OnItemDataBound="dtgUploadGrid_ItemDataBound">
                                <MasterTableView DataKeyNames="">
                                    <Columns>
                                        <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" Display="true">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="ToggleRowSelection" AutoPostBack="false" Checked="true"/>
                                            </ItemTemplate>
                                         </telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView>

                            </telerik:RadGrid>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                        </div>
                    
             </div>
               <%-- <table class="buttonTable">
                <tr>
                    <td>--%>
                        <div class="Flatbutton" style="width:150px">
                               <asp:Button ID="btnValidate" runat="server" class="buttonValidateAndImport" OnClick="BtnNext_Click" OnClientClick="return UploadNextClick();" Text="Validate"></asp:Button>
                               <img src="../Images/Icons/RightArrow16.png" />
                          
                       
                        </div>
                        
                  <%--  </td>
                </tr>
            </table>--%>
             
                
            <%--</div>--%>
           </div>
            
            <%--     <asp:Button ID="btnNext" runat="server" Text="Next>>"  Height="35px" Width="100px"   CssClass="buttonNext" OnClientClick="NextClick()"   />--%>
          
           
            </div>

         
        <%--<table class="buttonTable">
            <tr>
                <td>
                    <a href="#" class="buttonNext" onclick="return UploadNextClick();">
                        <div id="btnDiv" class="nav btnDivCommon">
                            Next>>
                        </div>
                    </a>
                </td>
            </tr>
        </table>--%>
    </div>

     
    <div style="display: none; margin-left: 50px;" id="DivValidate">
        <div class="col-md-12 Span-One">


            <div class="col-md-5">
                <asp:Label ID="lblValidationErrorRows" runat="server" Text="Validation error rows" CssClass="subtitle"></asp:Label>
                 <div style="height: 220px;" class="chooseFieldsBox">
                <div  style="overflow-y: scroll; height: 200px;">
                     <telerik:RadGrid ID="dtgvalidationErros" runat="server"   AllowSorting="true" Width="100%"
                       OnNeedDataSource="dtgvalidationErros_NeedDataSource"
                      OnPreRender="dtgvalidationErros_PreRender" AllowMultiRowSelection="True" Skin="Silk" CssClass="outerMultiPage">

                    <MasterTableView DataKeyNames="Status_ID" AutoGenerateColumns="false" ShowHeadersWhenNoRecords="false" NoDetailRecordsText="No Errors">
                         <Columns>
                              <telerik:GridBoundColumn HeaderText="Row NO" DataField="Excel_RowNO" UniqueName="Excel_RowNO" ItemStyle-Width="20%"></telerik:GridBoundColumn>
                              <telerik:GridBoundColumn HeaderText="Key Field" DataField="Key_Field" UniqueName="Key_Field" ItemStyle-Width="30%"></telerik:GridBoundColumn>
                              <telerik:GridBoundColumn HeaderText="Description" DataField="Error_Description" UniqueName="Error_Description" ItemStyle-Width="50%"></telerik:GridBoundColumn>
                              <telerik:GridBoundColumn HeaderText="Serial No" DataField="Sl_No" UniqueName="Sl_No" Display="false"></telerik:GridBoundColumn>
                              <telerik:GridBoundColumn HeaderText="StatusID" DataField="Status_ID" UniqueName="Status_ID" Display="false"></telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>

                </telerik:RadGrid>
                </div>
                </div>

            </div>
            <div class="col-md-1">&nbsp;</div>
               <div class="col-md-1"  style="border-left: 1px solid #cfc7c0;min-height:250px">&nbsp;</div>
            

            <div class="col-md-5" >
                <div class="col-md-12 infoBoxTitle">Details </div>
                <div class="col-md-12 infoBox"> 
                    <br />   
                <div class="col-md-7">
                    <asp:Label ID="lblVupldFile" runat="server" Text="Uploaded file"></asp:Label>
                </div>

                <div class="col-md-5">
                    <asp:Label ID="lblVupldFilename" runat="server" Text=""></asp:Label>
                </div>

                <div class="col-md-7"><asp:Label ID="lblVtotlrows" runat="server" Text="Total rows"></asp:Label>
                </div>
                <div class="col-md-5"> <asp:Label ID="lblVtotltowcount" runat="server" Text=""></asp:Label>
                </div>

                <div class="col-md-7">  <asp:Label ID="lblVexisting" runat="server" Text="Existing"></asp:Label>
                </div>
                <div class="col-md-5"> <asp:Label ID="lblVexistingCount" runat="server" Text=""></asp:Label>
                </div>

                <div class="col-md-7">    <asp:Label ID="lblVNew" runat="server" Text="New"></asp:Label>
                </div>
                <div class="col-md-5"> <asp:Label ID="lblVNewCount" runat="server" Text=""></asp:Label>
                </div>

                <div class="col-md-7"> <asp:Label ID="lblVErrors" runat="server" Text="Errors"></asp:Label>
                </div>
                <div class="col-md-5"> <asp:Label ID="lblVErrorsCount" runat="server" Text=""></asp:Label>
                </div>
                       <br />   <br />
                    </div>
                            

                 


            </div>


            <%--  <asp:Button ID="Button2" runat="server" Text="Next>>"  Height="35px" Width="100px"   CssClass="buttonNext"   />--%>
        </div>
         <table class="buttonTable">
                <tr>
                    <td>
          
                        <div class="Flatbutton" style="width:150px">
                         <asp:Button ID="btnImport" runat="server" style="background-color:#B00000;border:none" OnClick="btnImport_Click" OnClientClick="return Import();" Text="Import"></asp:Button>
                         <img src="../Images/Icons/RightArrow16.png" />
                        </div>
                      
                    </td>
              </tr>
        </table>
                       
                  

        <%--
              <table class="buttonTable">
                <tr>
                    <td>
                        <div class="Flatbutton" style="width:150px">
                             <a href="#" class="buttonNext" onclick="return Import();">
                            <div id="Div3" class="nav" style="color:white">
                                 Done
                            </div>
                        </a>
                        </div>
                       
                    </td>
                </tr>
            </table>
         
            
            
            
            
            <table class="buttonTable">
            <tr>
                <td>
                    <a href="#" class="buttonNext btnDivCommon" onclick="return Import();">
                        <div id="btnDivValidate" class="nav btnDivCommon">
                            Import
                        </div>
                    </a>
                </td>
            </tr>
        </table>--%>
    </div>


    <div style="display: none; margin-left: 5px;" id="Import">
        <div class="col-md-12 Span-One">
            <div class="col-md-5" style="padding-top:50px">

                  <div class="col-md-12">
                      <asp:Label ID="Label1" runat="server" Text="Thread Started ...." CssClass="subtitle"></asp:Label></div>
                  <div class="col-md-12">&nbsp;</div>  <div class="col-md-12">&nbsp; </div>
                <div class="col-md-12 subtitle" style="text-decoration:underline;color:darkblue">

                     <a href="../ExcelImport/ImportStatusList.aspx" target="_self" class="a">Click to see Import Status</a>
                </div>
                           
                           
                        

            </div>
          
             <div class="col-md-1">&nbsp;</div>
               <div class="col-md-1"  style="border-left: 1px solid #cfc7c0;min-height:250px">&nbsp;</div>
            <div class="col-md-5"  >

              <%-- <iframe id="ContentIframe" name="BOQDetails" style="height: 200px; width: 100%; overflow: hidden;" runat="server"></iframe>--%>
  
            </div>


            <%--  <asp:Button ID="Button2" runat="server" Text="Next>>"  Height="35px" Width="100px"   CssClass="buttonNext"   />--%>
        </div>


         <table class="buttonTable">
                <tr>
                    <td>
                        <div class="Flatbutton" style="width:150px">
                             <a href="#" class="buttonNext" onclick="return Import();">
                            <div id="Div3" class="nav" style="color:white">
                                 Done
                            </div>
                        </a>
                        </div>
                       
                    </td>
                </tr>
            </table>


        <%--<table class="buttonTable">
            <tr>
                <td>
                    <a href="#" class="buttonNext btnDivCommon">
                        <div id="btnImport" class="nav btnDivCommon">
                            Done
                        </div>
                    </a>
                </td>
            </tr>
        </table>--%>
    </div>

         </div>
    </div>
       <asp:HiddenField ID="hdfTableName" runat="server" />
       <asp:HiddenField ID="hdfFileName" runat="server"/>
       <asp:HiddenField ID="hdfFileLocation" runat="server"/>
       <asp:HiddenField ID="hdfstatusID" runat="server"/>
       <asp:HiddenField ID="hdfremovedField" runat="server"/>
       <asp:HiddenField ID="hdfErrorRow" runat="server" />
</asp:Content>
