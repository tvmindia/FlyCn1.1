<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="CloseDocument.aspx.cs" Inherits="FlyCn.Approvels.CloseDocument" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .caption {
            font-family: 'segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            vertical-align: middle;
        }
         .Error {
            font-family: 'segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            vertical-align:central;
             text-align:right;
             color:red;
             padding-right:2em;
        }
    </style>
  
  <%--  <script src="../Scripts/jquery-1.11.3.min.js" type="text/javascript"></script>--%>
    <script>
        function CloseDoc()
        {
            
            var DivVal = document.getElementById('<%=hdfDivLevels.ClientID %>').value;
           
            s= DivVal.split(",");
                               
            var a = "";
            for (var k = 0; k < s.length; k++) {

                a = document.getElementById(s[k]).value;
            
                if (a != "") {
                    return true;

                }
                else if(s[k] == s[s.length - 1])     
                {
                    document.getElementById('<%=lblerrordisplay.ClientID %>').innerHTML = "Please Select Atleast One Varifier";
                    //break;
                   //alert("Please Select Atleast One Varifier");
                   return false;
                }
            }
        }
    </script>
   
    
    <script>
        function getOptionsLevel1() {

            var hiddenvalue = document.getElementById('<%=hdfSelectBox1.ClientID %>').value;
            debugger;
            if (hiddenvalue != "") {



                var selectList = document.getElementById("selecttools1");
                var arr = hiddenvalue.split('||');
                var arry = [];

                for (i = 0; i < arr.length; i++) {
                    var aTemp = arr[i].split("=");

                    if (aTemp.length == 2) {
                        //var option;
                        var options;
                        arry.push({ id: aTemp[0], title: aTemp[1] });
                    }
                }

            }
            return arry;
        }
    </script>

    <script>
        function getOptionsLevel2() {
           
            var hiddenvalue = document.getElementById('<%=hdfSelectBox2.ClientID %>').value;
            debugger;
            if (hiddenvalue != "")
            {

            
            //var id = document.getElementById('selecttools2').style.visibility= true;
            var selectList = document.getElementById("selecttools2");
            var arr = hiddenvalue.split('||');
            var arry = [];

            for (i = 0; i < arr.length; i++) {
                var aTemp = arr[i].split("=");

                if (aTemp.length == 2) {
                    //var option;
                    var options;
                    arry.push({ id: aTemp[0], title: aTemp[1] });
                }
            }
          
            }
            return arry;
        }
    </script>
    
  
   

    <script>
        function getOptionsLevel3() {

            var hiddenvalue = document.getElementById('<%=hdfSelectBox3.ClientID %>').value;
            debugger;
            if (hiddenvalue != "") {


               
                var selectList = document.getElementById("selecttools3");
                var arr = hiddenvalue.split('||');
                var arry = [];

                for (i = 0; i < arr.length; i++) {
                    var aTemp = arr[i].split("=");

                    if (aTemp.length == 2) {
                        //var option;
                        var options;
                        arry.push({ id: aTemp[0], title: aTemp[1] });
                    }
                }

            }
            return arry;
        }
    </script>

    <script>
        function getOptionsLevel4() {

            var hiddenvalue = document.getElementById('<%=hdfSelectBox4.ClientID %>').value;
            debugger;
            if (hiddenvalue != "") {


           
                var selectList = document.getElementById("selecttools4");
                var arr = hiddenvalue.split('||');
                var arry = [];

                for (i = 0; i < arr.length; i++) {
                    var aTemp = arr[i].split("=");

                    if (aTemp.length == 2) {
                        //var option;
                        var options;
                        arry.push({ id: aTemp[0], title: aTemp[1] });
                    }
                }

            }
            return arry;
        }
    </script>

    <script>
        function getOptionsLevel5() {

            var hiddenvalue = document.getElementById('<%=hdfSelectBox5.ClientID %>').value;
            debugger;
            if (hiddenvalue != "") {


                
                var selectList = document.getElementById("selecttools5");
                var arr = hiddenvalue.split('||');
                var arry = [];

                for (i = 0; i < arr.length; i++) {
                    var aTemp = arr[i].split("=");

                    if (aTemp.length == 2) {
                        //var option;
                        var options;
                        arry.push({ id: aTemp[0], title: aTemp[1] });
                    }
                }

            }
            return arry;
        }
    </script>

    <script>
        function getOptionsLevel6() {

            var hiddenvalue = document.getElementById('<%=hdfSelectBox6.ClientID %>').value;
            debugger;
            if (hiddenvalue != "") {


                
                var selectList = document.getElementById("selecttools6");
                var arr = hiddenvalue.split('||');
                var arry = [];

                for (i = 0; i < arr.length; i++) {
                    var aTemp = arr[i].split("=");

                    if (aTemp.length == 2) {
                        //var option;
                        var options;
                        arry.push({ id: aTemp[0], title: aTemp[1] });
                    }
                }

            }
            return arry;
        }
    </script>

    <script>
        function getOptionsLevel7() {

            var hiddenvalue = document.getElementById('<%=hdfSelectBox7.ClientID %>').value;
            debugger;
            if (hiddenvalue != "") {


                
                var selectList = document.getElementById("selecttools7");
                var arr = hiddenvalue.split('||');
                var arry = [];

                for (i = 0; i < arr.length; i++) {
                    var aTemp = arr[i].split("=");

                    if (aTemp.length == 2) {
                        //var option;
                        var options;
                        arry.push({ id: aTemp[0], title: aTemp[1] });
                    }
                }

            }
            return arry;
        }
    </script>

    <script>
        function getOptionsLevel8() {

            var hiddenvalue = document.getElementById('<%=hdfSelectBox8.ClientID %>').value;
            debugger;
            if (hiddenvalue != "") {


                
                var selectList = document.getElementById("selecttools8");
                var arr = hiddenvalue.split('||');
                var arry = [];

                for (i = 0; i < arr.length; i++) {
                    var aTemp = arr[i].split("=");

                    if (aTemp.length == 2) {
                        //var option;
                        var options;
                        arry.push({ id: aTemp[0], title: aTemp[1] });
                    }
                }

            }
            return arry;
        }
    </script>

    <script>
        function getOptionsLevel9() {

            var hiddenvalue = document.getElementById('<%=hdfSelectBox9.ClientID %>').value;
            debugger;
            if (hiddenvalue != "") {


                
                var selectList = document.getElementById("selecttools9");
                var arr = hiddenvalue.split('||');
                var arry = [];

                for (i = 0; i < arr.length; i++) {
                    var aTemp = arr[i].split("=");

                    if (aTemp.length == 2) {
                        //var option;
                        var options;
                        arry.push({ id: aTemp[0], title: aTemp[1] });
                    }
                }

            }
            return arry;
        }
    </script>

    <script>
        function getOptionsLevel10() {

            var hiddenvalue = document.getElementById('<%=hdfSelectBox10.ClientID %>').value;
            debugger;
            if (hiddenvalue != "") {


                
                var selectList = document.getElementById("selecttools10");
                var arr = hiddenvalue.split('||');
                var arry = [];

                for (i = 0; i < arr.length; i++) {
                    var aTemp = arr[i].split("=");

                    if (aTemp.length == 2) {
                        //var option;
                        var options;
                        arry.push({ id: aTemp[0], title: aTemp[1] });
                    }
                }

            }
            return arry;
        }
    </script>
 
    <div class="container" style="width: 100%">
        <div  id="Placeholder" runat="server">
            <asp:HiddenField ID="hdfSelectBox1" runat="server" />
            <asp:HiddenField ID="hdfSelectBox2" runat="server" />
            <asp:HiddenField ID="hdfSelectBox3" runat="server" />
            <asp:HiddenField ID="hdfSelectBox4" runat="server" />
            <asp:HiddenField ID="hdfSelectBox5" runat="server" />
            <asp:HiddenField ID="hdfSelectBox6" runat="server" />
            <asp:HiddenField ID="hdfSelectBox7" runat="server" />
            <asp:HiddenField ID="hdfSelectBox8" runat="server" />
            <asp:HiddenField ID="hdfSelectBox9" runat="server" />
            <asp:HiddenField ID="hdfSelectBox10" runat="server" />
               <asp:HiddenField ID="hdfDivLevels" runat="server" />
        <asp:Label ID="lblrevisionid" runat="server" Text="" ForeColor="#008B8B" Font-Size="18px" CssClass="caption" ClientIDMode="Static"></asp:Label>
      
             <asp:Label ID="lblerrordisplay" runat="server" Text=""  Font-Size="14px" CssClass="Error"  ></asp:Label>
        <div class="col-md-12 Span-One" id="divLevel1"  runat="server" visible="false">
            <div class="col-md-6">

                <div class="form-group">
                    <asp:Label ID="lblLevel1" runat="server" class="control-label col-md-3" ForeColor="#669900"></asp:Label>
                    <div class="col-md-9">
                        <div class="control-group"> 
                            <select id="selecttools1"   name="Level1"  >

                                <option value="0" ></option>
                      
                            </select>
                        </div>
                    </div>
                </div>

            </div>
            <div class="col-md-6">
                <%--    <form class="form-horizontal" role="form">--%>
                <div class="form-group">


                    <div class="col-md-9">

                        <asp:CheckBox ID="chkLevel1" runat="server" AutoPostBack="false" />


                    </div>
                </div>
                <%-- </form>--%>
            </div>
        </div>

        <div class="col-md-12 Span-One" id="divLevel2" runat="server" visible="false">
            <div class="col-md-6">

                <div class="form-group" >
                    <asp:Label ID="lblLevel2" runat="server" class="control-label col-md-3" ForeColor="#669900"></asp:Label>
                    <div class="col-md-9">
                        <div class="control-group">
                            <select id="selecttools2" name="Level2">
                                <option value=""></option>
                       
                            </select>
                        </div>
                    </div>
                </div>

            </div>
            <div class="col-md-6">
                <%--    <form class="form-horizontal" role="form">--%>
                <div class="form-group">



                    <div class="col-md-9">

                        <asp:CheckBox ID="chkLevel2" runat="server" AutoPostBack="false"  />

                    </div>
                </div>
                <%-- </form>--%>
            </div>
        </div>

        <div class="col-md-12 Span-One" id="divLevel3" runat="server" visible="false">
            <div class="col-md-6">
                <div class="form-group">
                    <asp:Label ID="lblLevel3" runat="server" class="control-label col-md-3" ForeColor="#669900"></asp:Label>
                    <div class="col-md-9">
                        <div class="control-group">
                            <select id="selecttools3" name="Level3" >
                                <option value=""></option>
                              
                            </select>
                        </div>
                    </div>
                </div>

            </div>
            <div class="col-md-6">
                <%--    <form class="form-horizontal" role="form">--%>
                <div class="form-group">


                    <div class="col-md-9">

                        <asp:CheckBox ID="chkLevel3" runat="server" AutoPostBack="false"   />


                    </div>
                </div>
                <%-- </form>--%>
            </div>
        </div>

        <div class="col-md-12 Span-One" id="divLevel4" runat="server" visible="false">
            <div class="col-md-6">

                <div class="form-group">
                    <asp:Label ID="lblLevel4" runat="server" class="control-label col-md-3" ForeColor="#669900"></asp:Label>
                    <div class="col-md-9">
                        <div class="control-group">
                            <select id="selecttools4" name="Level4" >
                                <option value="" ></option>
                         
                            </select>
                        </div>
                    </div>
                </div>

            </div>
            <div class="col-md-6">
                <%--    <form class="form-horizontal" role="form">--%>
                <div class="form-group">


                    <div class="col-md-9">

                        <asp:CheckBox ID="chkLevel4" runat="server" AutoPostBack="false"  />


                    </div>
                </div>
                <%-- </form>--%>
            </div>
        </div>

        <div class="col-md-12 Span-One" id="divLevel5" runat="server" visible="false">
            <div class="col-md-6">

                <div class="form-group">
                    <asp:Label ID="lblLevel5" runat="server" class="control-label col-md-3" ForeColor="#669900"></asp:Label>
                    <div class="col-md-9">
                        <div class="control-group">
                            <select id="selecttools5" name="Level5">
                                <option value=""></option>
                              
                            </select>
                        </div>
                    </div>
                </div>

            </div>
            <div class="col-md-6">
                <%--    <form class="form-horizontal" role="form">--%>
                <div class="form-group">


                    <div class="col-md-9">

                        <asp:CheckBox ID="chkLevel5" runat="server" AutoPostBack="false"   />


                    </div>
                </div>
                <%-- </form>--%>
            </div>
        </div>

        <div class="col-md-12 Span-One" id="divLevel6" runat="server" visible="false">
            <div class="col-md-6">

                <div class="form-group">
                    <asp:Label ID="lblLevel6" runat="server" class="control-label col-md-3" ForeColor="#669900"></asp:Label>
                    <div class="col-md-9">
                        <div class="control-group">
                            <select id="selecttools6" name="Level3" > 
                                <option value=""></option>
                              
                            </select>
                        </div>
                    </div>
                </div>

            </div>
            <div class="col-md-6">
              
                <div class="form-group">


                    <div class="col-md-9">

                        <asp:CheckBox ID="chkLevel6" runat="server" AutoPostBack="false"   />


                    </div>
                </div>
                <%-- </form>--%>
            </div>
        </div>

        <div class="col-md-12 Span-One" id="divLevel7" runat="server" visible="false">
            <div class="col-md-6">

                <div class="form-group">
                    <asp:Label ID="lblLevel7" runat="server" class="control-label col-md-3" ForeColor="#669900"></asp:Label>
                    <div class="col-md-9">
                        <div class="control-group">
                            <select id="selecttools7" name="Level3">
                                <option value=""></option>

                            </select>
                        </div>
                    </div>
                </div>

            </div>
            <div class="col-md-6">
               
                <div class="form-group">


                    <div class="col-md-9">

                        <asp:CheckBox ID="chkLevel7" runat="server" AutoPostBack="false" />


                    </div>
                </div>
                <%-- </form>--%>
            </div>
        </div>

        <div class="col-md-12 Span-One" id="divLevel8" runat="server" visible="false">
            <div class="col-md-6">

                <div class="form-group">
                    <asp:Label ID="lblLevel8" runat="server" class="control-label col-md-3" ForeColor="#669900"></asp:Label>
                    <div class="col-md-9">
                        <div class="control-group">
                            <select id="selecttools8" name="Level3" >
                                <option value=""></option>

                            </select>
                        </div>
                    </div>
                </div>

            </div>
            <div class="col-md-6">
             
                <div class="form-group">


                    <div class="col-md-9">

                        <asp:CheckBox ID="chkLevel8" runat="server" AutoPostBack="false"  />


                    </div>
                </div>
                <%-- </form>--%>
            </div>
        </div>

        <div class="col-md-12 Span-One" id="divLevel9" runat="server" visible="false">
            <div class="col-md-6">

                <div class="form-group">
                    <asp:Label ID="lblLevel9" runat="server" class="control-label col-md-3" ForeColor="#669900"></asp:Label>
                    <div class="col-md-9">
                        <div class="control-group">
                            <select id="selecttools9" name="Level3" >
                                <option value=""></option>

                            </select>
                        </div>
                    </div>
                </div>

            </div>
            <div class="col-md-6">
                <%--    <form class="form-horizontal" role="form">--%>
                <div class="form-group">


                    <div class="col-md-9">

                        <asp:CheckBox ID="chkLevel9" runat="server" AutoPostBack="false"  />


                    </div>
                </div>
                <%-- </form>--%>
            </div>
        </div>

        <div class="col-md-12 Span-One" id="divLevel10" runat="server" visible="false">
            <div class="col-md-6">

                <div class="form-group">
                    <asp:Label ID="lblLevel10" runat="server" class="control-label col-md-3" ForeColor="#669900"></asp:Label>
                    <div class="col-md-9">
                        <div class="control-group">
                            <select id="selecttools10" name="Level10" >
                              

                            </select>
                        </div>
                    </div>
                </div>

            </div>
            <div class="col-md-6">
              
                <div class="form-group">


                    <div class="col-md-9">

                        <asp:CheckBox ID="chkLevel10" runat="server" AutoPostBack="false"  />


                    </div>
                </div>
                <%-- </form>--%>
            </div>
        </div>

        <div>
            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp 
        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp 
            <asp:Button ID="btnCloseDocument" runat="server" Text="CloseDocument" BackColor="#009999"
                 ForeColor="#000099" Width="263px" Height="36px"  OnClientClick="return CloseDoc();"  OnClick="btnCloseDocument_Click"  />

        </div>

    </div>
        </div>

    <script src="../Content/themes/FlyCnBlue/js/selectize.js"></script>
    <script src="../Content/themes/FlyCnBlue/js/index.js"></script>

    <script>

        var $select = $('#selecttools1').selectize({

            maxItems: null,
            valueField: 'id',
            labelField: 'title',
            searchField: 'title',
            options: getOptionsLevel1(),
            create: false
        });


        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        var control = $select[0].selectize;

        $('#button-clear').on('click', function () {
            control.clear();
        });

        $('#button-clearoptions').on('click', function () {
            control.clearOptions();
        });

        $('#button-addoption').on('click', function () {
            control.addOption({
                id: 4,
                title: 'Something New',
                url: 'http://google.com'
            });
        });

        $('#button-additem').on('click', function () {
            control.addItem(2);
        });

        $('#button-setvalue').on('click', function () {
            control.setValue([2, 3]);
        });



    </script>

     <script>

         var $select = $('#selecttools2').selectize({
             maxItems: null,
             valueField: 'id',
             labelField: 'title',
             searchField: 'title',
             options: getOptionsLevel2(),
             create: false
         });



         // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

         var control = $select[0].selectize;

         $('#button-clear').on('click', function () {
             control.clear();
         });

         $('#button-clearoptions').on('click', function () {
             control.clearOptions();
         });

         $('#button-addoption').on('click', function () {
             control.addOption({
                 id: 4,
                 title: 'Something New',
                 url: 'http://google.com'
             });
         });

         $('#button-additem').on('click', function () {
             control.addItem(2);
         });

         $('#button-setvalue').on('click', function () {
             control.setValue([2, 3]);
         });



     </script>

    <script>

        var $select = $('#selecttools3').selectize({
            maxItems: null,
            valueField: 'id',
            labelField: 'title',
            searchField: 'title',
            options: getOptionsLevel3(),
            create: false
        });



        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        var control = $select[0].selectize;

        $('#button-clear').on('click', function () {
            control.clear();
        });

        $('#button-clearoptions').on('click', function () {
            control.clearOptions();
        });

        $('#button-addoption').on('click', function () {
            control.addOption({
                id: 4,
                title: 'Something New',
                url: 'http://google.com'
            });
        });

        $('#button-additem').on('click', function () {
            control.addItem(2);
        });

        $('#button-setvalue').on('click', function () {
            control.setValue([2, 3]);
        });



    </script>

    <script>

        var $select = $('#selecttools4').selectize({
            maxItems: null,
            valueField: 'id',
            labelField: 'title',
            searchField: 'title',
            options: getOptionsLevel4(),
            create: false
        });



        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        var control = $select[0].selectize;

        $('#button-clear').on('click', function () {
            control.clear();
        });

        $('#button-clearoptions').on('click', function () {
            control.clearOptions();
        });

        $('#button-addoption').on('click', function () {
            control.addOption({
                id: 4,
                title: 'Something New',
                url: 'http://google.com'
            });
        });

        $('#button-additem').on('click', function () {
            control.addItem(2);
        });

        $('#button-setvalue').on('click', function () {
            control.setValue([2, 3]);
        });



    </script>

    <script>

        var $select = $('#selecttools5').selectize({
            maxItems: null,
            valueField: 'id',
            labelField: 'title',
            searchField: 'title',
            options: getOptionsLevel5(),
            create: false
        });



        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        var control = $select[0].selectize;

        $('#button-clear').on('click', function () {
            control.clear();
        });

        $('#button-clearoptions').on('click', function () {
            control.clearOptions();
        });

        $('#button-addoption').on('click', function () {
            control.addOption({
                id: 4,
                title: 'Something New',
                url: 'http://google.com'
            });
        });

        $('#button-additem').on('click', function () {
            control.addItem(2);
        });

        $('#button-setvalue').on('click', function () {
            control.setValue([2, 3]);
        });



    </script>

    <script>

        var $select = $('#selecttools6').selectize({
            maxItems: null,
            valueField: 'id',
            labelField: 'title',
            searchField: 'title',
            options: getOptionsLevel6(),
            create: false
        });



        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        var control = $select[0].selectize;

        $('#button-clear').on('click', function () {
            control.clear();
        });

        $('#button-clearoptions').on('click', function () {
            control.clearOptions();
        });

        $('#button-addoption').on('click', function () {
            control.addOption({
                id: 4,
                title: 'Something New',
                url: 'http://google.com'
            });
        });

        $('#button-additem').on('click', function () {
            control.addItem(2);
        });

        $('#button-setvalue').on('click', function () {
            control.setValue([2, 3]);
        });



    </script>

    <script>

        var $select = $('#selecttools7').selectize({
            maxItems: null,
            valueField: 'id',
            labelField: 'title',
            searchField: 'title',
            options: getOptionsLevel7(),
            create: false
        });



        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        var control = $select[0].selectize;

        $('#button-clear').on('click', function () {
            control.clear();
        });

        $('#button-clearoptions').on('click', function () {
            control.clearOptions();
        });

        $('#button-addoption').on('click', function () {
            control.addOption({
                id: 4,
                title: 'Something New',
                url: 'http://google.com'
            });
        });

        $('#button-additem').on('click', function () {
            control.addItem(2);
        });

        $('#button-setvalue').on('click', function () {
            control.setValue([2, 3]);
        });



    </script>

    <script>

        var $select = $('#selecttools8').selectize({
            maxItems: null,
            valueField: 'id',
            labelField: 'title',
            searchField: 'title',
            options: getOptionsLevel8(),
            create: false
        });



        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        var control = $select[0].selectize;

        $('#button-clear').on('click', function () {
            control.clear();
        });

        $('#button-clearoptions').on('click', function () {
            control.clearOptions();
        });

        $('#button-addoption').on('click', function () {
            control.addOption({
                id: 4,
                title: 'Something New',
                url: 'http://google.com'
            });
        });

        $('#button-additem').on('click', function () {
            control.addItem(2);
        });

        $('#button-setvalue').on('click', function () {
            control.setValue([2, 3]);
        });



    </script>

    <script>

        var $select = $('#selecttools9').selectize({
            maxItems: null,
            valueField: 'id',
            labelField: 'title',
            searchField: 'title',
            options: getOptionsLevel9(),
            create: false
        });



        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        var control = $select[0].selectize;

        $('#button-clear').on('click', function () {
            control.clear();
        });

        $('#button-clearoptions').on('click', function () {
            control.clearOptions();
        });

        $('#button-addoption').on('click', function () {
            control.addOption({
                id: 4,
                title: 'Something New',
                url: 'http://google.com'
            });
        });

        $('#button-additem').on('click', function () {
            control.addItem(2);
        });

        $('#button-setvalue').on('click', function () {
            control.setValue([2, 3]);
        });



    </script>

    <script>
        var $select = $('#selecttools10').selectize({

            maxItems: null,
            valueField: 'id',
            labelField: 'title',
            searchField: 'title',
            options: getOptionsLevel10(),
            create: false
        });


        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        var control = $select[0].selectize;

        $('#button-clear').on('click', function () {
            control.clear();
        });

        $('#button-clearoptions').on('click', function () {
            control.clearOptions();
        });

        $('#button-addoption').on('click', function () {
            control.addOption({
                id: 4,
                title: 'Something New',
                url: 'http://google.com'
            });
        });

        $('#button-additem').on('click', function () {
            control.addItem(2);
        });

        $('#button-setvalue').on('click', function () {
            control.setValue([2, 3]);
        });



    </script>


    
</asp:Content>
