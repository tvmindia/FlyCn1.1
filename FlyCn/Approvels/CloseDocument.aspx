<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="CloseDocument.aspx.cs" Inherits="FlyCn.Approvels.CloseDocument" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .Error {
            font-family: 'segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            vertical-align: central;
            text-align: right;
            color: red;
            padding-right: 2em;
        }

        .label {
            font-family: 'segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            color: white;
        }
      
    </style>

    <script src="../Scripts/jquery-1.11.3.min.js" type="text/javascript"></script>
    <script>
        function CloseDoc() {

            var DivVal = document.getElementById('<%=hdfDivLevels.ClientID %>').value;

            divlevels = DivVal.split(",");

            var currentlevel = "";
            for (var k = 0; k < divlevels.length; k++) {

                currentlevel = document.getElementById(divlevels[k]).value;

                if (currentlevel != "") {
                    return true;

                }
                else if (divlevels[k] == divlevels[divlevels.length - 1]) {
                    document.getElementById('<%=lblerrordisplay.ClientID %>').innerHTML = "Please Select Atleast One Varifier";

                    return false;
                }
        }
    }
    </script>


    <script>
        function getOptionsLevel1() {

            var hiddenvalue = document.getElementById('<%=hdfSelectBox1.ClientID %>').value;
           
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
           
            if (hiddenvalue != "") {


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

 
        <div style="width:705px; height: 340px; background-color: transparent; overflow-y: auto; scrollbar-base-color: rgba(36,85,99,.9); overflow-x:hidden;">
          <div class="container" style="width: 100%;">
              <div class="contentTopBar"></div>
           
                <div class="col-xs-12 Span-One">
                    <asp:Label ID="lblCaption" runat="server" Text="" CssClass="Verifiercaption" ClientIDMode="Static"></asp:Label>
                    <div class="col-xs-12 Span-One" id="divLevel1" runat="server" visible="false">



                        <asp:Label ID="lblLevel1" runat="server" class="control-label col-xs-2" ForeColor="#006666"></asp:Label>
                        <div class="col-xs-9">
                            <div class="control-group">

                                <select id="selecttools1" name="Level1">

                                    <option value="0"></option>

                                </select>
                            </div>
                        </div>
                        <div class="col-xs-1">

                            <asp:CheckBox ID="chkLevel1" runat="server" AutoPostBack="false" />



                        </div>
                    </div>




                    <div class="col-xs-12 Span-One" id="divLevel2" runat="server" visible="false">



                        <asp:Label ID="lblLevel2" runat="server" class="control-label col-xs-2" ForeColor="#006666"></asp:Label>
                        <div class="col-xs-9">
                            <div class="control-group">
                                <select id="selecttools2" name="Level2">
                                    <option value=""></option>

                                </select>
                            </div>
                        </div>
                        <div class="col-xs-1">

                            <asp:CheckBox ID="chkLevel2" runat="server" AutoPostBack="false" />

                        </div>
                    </div>



                    <div class="col-xs-12 Span-One" id="divLevel3" runat="server" visible="false">


                        <asp:Label ID="lblLevel3" runat="server" class="control-label col-xs-2" ForeColor="#006666"></asp:Label>
                        <div class="col-xs-9">
                            <div class="control-group">
                                <select id="selecttools3" name="Level3">
                                    <option value=""></option>

                                </select>
                            </div>
                        </div>
                        <div class="col-xs-1">

                            <asp:CheckBox ID="chkLevel3" runat="server" AutoPostBack="false" />


                        </div>
                    </div>





                    <div class="col-xs-12 Span-One" id="divLevel4" runat="server" visible="false">


                        <asp:Label ID="lblLevel4" runat="server" class="control-label col-xs-2" ForeColor="#006666"></asp:Label>
                        <div class="col-xs-9">
                            <div class="control-group">
                                <select id="selecttools4" name="Level4">
                                    <option value=""></option>

                                </select>
                            </div>
                        </div>
                        <div class="col-xs-1">

                            <asp:CheckBox ID="chkLevel4" runat="server" AutoPostBack="false" />


                        </div>
                    </div>






                    <div class="col-xs-12 Span-One" id="divLevel5" runat="server" visible="false">


                        <asp:Label ID="lblLevel5" runat="server" class="control-label col-xs-2" ForeColor="#006666"></asp:Label>
                        <div class="col-xs-9">
                            <div class="control-group">
                                <select id="selecttools5" name="Level5">
                                    <option value=""></option>

                                </select>
                            </div>
                        </div>
                        <div class="col-xs-1">

                            <asp:CheckBox ID="chkLevel5" runat="server" AutoPostBack="false" />


                        </div>
                    </div>






                    <div class="col-xs-12 Span-One" id="divLevel6" runat="server" visible="false">


                        <asp:Label ID="lblLevel6" runat="server" class="control-label col-xs-2" ForeColor="#006666"></asp:Label>
                        <div class="col-xs-9">
                            <div class="control-group">
                                <select id="selecttools6" name="Level6">
                                    <option value=""></option>

                                </select>
                            </div>
                        </div>
                        <div class="col-xs-1">

                            <asp:CheckBox ID="chkLevel6" runat="server" AutoPostBack="false" />


                        </div>
                    </div>




                    <div class="col-xs-12 Span-One" id="divLevel7" runat="server" visible="false">



                        <asp:Label ID="lblLevel7" runat="server" class="control-label col-xs-2" ForeColor="#006666"></asp:Label>
                        <div class="col-xs-9">
                            <div class="control-group">
                                <select id="selecttools7" name="Level7">
                                    <option value=""></option>

                                </select>
                            </div>
                        </div>
                        <div class="col-xs-1">

                            <asp:CheckBox ID="chkLevel7" runat="server" AutoPostBack="false" />


                        </div>
                    </div>



                    <div class="col-xs-12 Span-One" id="divLevel8" runat="server" visible="false">



                        <asp:Label ID="lblLevel8" runat="server" class="control-label col-xs-2" ForeColor="#006666"></asp:Label>
                        <div class="col-xs-9">
                            <div class="control-group">
                                <select id="selecttools8" name="Level8">
                                    <option value=""></option>

                                </select>
                            </div>
                        </div>
                        <div class="col-xs-1">

                            <asp:CheckBox ID="chkLevel8" runat="server" AutoPostBack="false" />


                        </div>
                    </div>



                    <div class="col-xs-12 Span-One" id="divLevel9" runat="server" visible="false">


                        <asp:Label ID="lblLevel9" runat="server" class="control-label col-xs-2" ForeColor="#006666"></asp:Label>
                        <div class="col-xs-9">
                            <div class="control-group">
                                <select id="selecttools9" name="Level9">
                                    <option value=""></option>

                                </select>
                            </div>
                        </div>
                        <div class="col-xs-1">

                            <asp:CheckBox ID="chkLevel9" runat="server" AutoPostBack="false" />


                        </div>
                    </div>



                    <div class="col-xs-12 Span-One" id="divLevel10" runat="server" visible="false">


                        <asp:Label ID="lblLevel10" runat="server" class="control-label col-xs-2" ForeColor="#006666"></asp:Label>
                        <div class="col-xs-9">
                            <div class="control-group">
                                <select id="selecttools10" name="Level10">
                                </select>
                            </div>
                        </div>
                        <div class="col-xs-1">

                            <asp:CheckBox ID="chkLevel10" runat="server" AutoPostBack="false" />


                        </div>
                    </div>



                </div>


            </div>

      <div id="Placeholder" runat="server">
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

                <asp:HiddenField ID="hdfDocType" runat="server" />
                <asp:HiddenField ID="hdfDocNo" runat="server" />
        </div>

    </div>
    <asp:Label ID="lblerrordisplay" runat="server" Text="" Font-Size="14px" CssClass="Error" Style="margin-left: 5px;"></asp:Label>
    <asp:HiddenField ID="popuprefreshRequired" runat="server" ClientIDMode="Static" />
    <table >

        <tr>

            <td class="popupButtonContainer">

                <asp:Button class="buttonroundCorner" ID="btnCloseDocument" runat="server" Text="Close Document"
                    Width="263px" Height="36px" OnClientClick="return CloseDoc();" OnClick="btnCloseDocument_Click" />
            </td>
        </tr>
    </table>

    <script src="../Content/themes/FlyCnBlue/js/selectize.js"></script>
    <script src="../Content/themes/FlyCnBlue/js/index.js"></script>
    <%--  call a method to fill 1st select box data and apply bootstrap style -- start--%>
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
    <%--  call a method to fill 1st select box data  and apply bootstrap style --end --%>

    <%--  call a method to fill 2nd select box data  and apply bootstrap style  -- start--%>
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
    <%--  call a method to fill 2nd select box data   and apply bootstrap style -- end--%>

    <%--  call a method to fill 3rd select box data   and apply bootstrap style-- start--%>
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
    <%--  call a method to fill 3rd select box data   and apply bootstrap style -- end--%>

    <%--  call a method to fill 4rd select box data   and apply bootstrap style -- start--%>

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
    <%--  call a method to fill 4rd select box data   and apply bootstrap style -- end--%>

    <%--  call a method to fill 5th select box data    and apply bootstrap style-- start--%>

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
    <%--  call a method to fill 5th select box data    and apply bootstrap style-- end--%>

    <%--  call a method to fill 6th select box data    and apply bootstrap style-- start--%>

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
    <%--  call a method to fill 6th select box data    and apply bootstrap style-- end--%>

    <%--  call a method to fill 7th select box data    and apply bootstrap style-- start--%>

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
    <%--  call a method to fill 7th select box data   and apply bootstrap style -- end--%>

    <%--  call a method to fill 8th select box data    and apply bootstrap style-- start--%>
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

    <%--  call a method to fill 8th select box data    and apply bootstrap style-- end--%>

    <%--  call a method to fill 9th select box data   and apply bootstrap style -- start--%>

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

    <%--  call a method to fill 9th select box data   and apply bootstrap style -- end--%>

    <%--  call a method to fill 10th select box data   and apply bootstrap style -- start--%>
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

    <%--  call a method to fill 10th select box data   and apply bootstrap style -- end--%>
</asp:Content>
