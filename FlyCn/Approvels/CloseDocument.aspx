<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="CloseDocument.aspx.cs" Inherits="FlyCn.Approvels.CloseDocument" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .caption {
            font-family: 'segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            vertical-align: middle;
        }
    </style>
    <script>

        function getOptions() {
            var hiddenvalue = document.getElementById('<%=hdfSelectBox1.ClientID %>').value;
           var selectList = document.getElementById("selecttools");
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
           return arry;
       }


       function getOptionsLevel2() {
           var hiddenvalue = document.getElementById('<%=hdfSelectBox2.ClientID %>').value;
           var selectList = document.getElementById("select-tools2");
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
           return arry;
       }

       function getOptionsLevel3() {
           var hiddenvalue = document.getElementById('<%=hdfSelectBox3.ClientID %>').value;
           var selectList = document.getElementById("select-tools3");
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
           return arry;
       }
    </script>
    <div class="container" style="width: 100%">
        <asp:HiddenField ID="hdfSelectBox1" runat="server" />
        <asp:HiddenField ID="hdfSelectBox2" runat="server" />
        <asp:HiddenField ID="hdfSelectBox3" runat="server" />
        <asp:Label ID="lblrevisionid" runat="server" Text="" ForeColor="#008B8B" Font-Size="18px" CssClass="caption"></asp:Label>
      

        <div class="col-md-12 Span-One">
            <div class="col-md-6">

                <div class="form-group">
                    <asp:Label ID="lblLevel1" runat="server" class="control-label col-md-3" ForeColor="#669900"></asp:Label>
                    <div class="col-md-9">
                        <div class="control-group">
                            <select id="selecttools" name="Level1">

                                <option value=""></option>
                                <%-- <option value="1">Manu</option>
        <option value="2">Amal</option>
        <option value="3">Jomon</option>--%>
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

        <div class="col-md-12 Span-One">
            <div class="col-md-6">

                <div class="form-group">
                    <asp:Label ID="lblLevel2" runat="server" class="control-label col-md-3" ForeColor="#669900"></asp:Label>
                    <div class="col-md-9">
                        <div class="control-group">
                            <select id="select-tools2" name="Level2">
                                <option value=""></option>
                                <%--  <option value="S1">Suvaneeth</option>
        <option value="J1">javd</option>
        <option value="J2">jissar</option>--%>
                            </select>
                        </div>
                    </div>
                </div>

            </div>
            <div class="col-md-6">
                <%--    <form class="form-horizontal" role="form">--%>
                <div class="form-group">



                    <div class="col-md-9">

                        <asp:CheckBox ID="chkLevel2" runat="server" AutoPostBack="false" />

                    </div>
                </div>
                <%-- </form>--%>
            </div>
        </div>

        <div class="col-md-12 Span-One">
            <div class="col-md-6">

                <div class="form-group">
                    <asp:Label ID="lblLevel3" runat="server" class="control-label col-md-3" ForeColor="#669900"></asp:Label>
                    <div class="col-md-9">
                        <div class="control-group">
                            <select id="select-tools3" name="Level3">
                                <option value=""></option>
                                <%--  <option value="A1">Albert</option>
        <option value="A11">Amrutha</option>
        <option value="G2">Gopika</option>--%>
                            </select>
                        </div>
                    </div>
                </div>

            </div>
            <div class="col-md-6">
                <%--    <form class="form-horizontal" role="form">--%>
                <div class="form-group">


                    <div class="col-md-9">

                        <asp:CheckBox ID="chkLevel3" runat="server" AutoPostBack="false" />


                    </div>
                </div>
                <%-- </form>--%>
            </div>
        </div>

        <div class="col-md-12 Span-One">
            <div class="col-md-6">

                <div class="form-group">
                    <asp:Label ID="Level4" runat="server" class="control-label col-md-3" ForeColor="#669900"></asp:Label>
                    <div class="col-md-9">
                        <div class="control-group">
                            <select id="select-tools4" name="Level3">
                                <option value=""></option>
                                <%--  <option value="A1">Albert</option>
        <option value="A11">Amrutha</option>
        <option value="G2">Gopika</option>--%>
                            </select>
                        </div>
                    </div>
                </div>

            </div>
            <div class="col-md-6">
                <%--    <form class="form-horizontal" role="form">--%>
                <div class="form-group">


                    <div class="col-md-9">

                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="false" />


                    </div>
                </div>
                <%-- </form>--%>
            </div>
        </div>

        <div class="col-md-12 Span-One">
            <div class="col-md-6">

                <div class="form-group">
                    <asp:Label ID="Level5" runat="server" class="control-label col-md-3" ForeColor="#669900"></asp:Label>
                    <div class="col-md-9">
                        <div class="control-group">
                            <select id="select-tools5" name="Level3">
                                <option value=""></option>
                                <%--  <option value="A1">Albert</option>
        <option value="A11">Amrutha</option>
        <option value="G2">Gopika</option>--%>
                            </select>
                        </div>
                    </div>
                </div>

            </div>
            <div class="col-md-6">
                <%--    <form class="form-horizontal" role="form">--%>
                <div class="form-group">


                    <div class="col-md-9">

                        <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="false" />


                    </div>
                </div>
                <%-- </form>--%>
            </div>
        </div>

        <div class="col-md-12 Span-One">
            <div class="col-md-6">

                <div class="form-group">
                    <asp:Label ID="Level6" runat="server" class="control-label col-md-3" ForeColor="#669900"></asp:Label>
                    <div class="col-md-9">
                        <div class="control-group">
                            <select id="select-tools6" name="Level3">
                                <option value=""></option>
                                <%--  <option value="A1">Albert</option>
        <option value="A11">Amrutha</option>
        <option value="G2">Gopika</option>--%>
                            </select>
                        </div>
                    </div>
                </div>

            </div>
            <div class="col-md-6">
                <%--    <form class="form-horizontal" role="form">--%>
                <div class="form-group">


                    <div class="col-md-9">

                        <asp:CheckBox ID="CheckBox3" runat="server" AutoPostBack="false" />


                    </div>
                </div>
                <%-- </form>--%>
            </div>
        </div>

        <div class="col-md-12 Span-One">
            <div class="col-md-6">

                <div class="form-group">
                    <asp:Label ID="Level7" runat="server" class="control-label col-md-3" ForeColor="#669900"></asp:Label>
                    <div class="col-md-9">
                        <div class="control-group">
                            <select id="select-tools7" name="Level3">
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

                        <asp:CheckBox ID="CheckBox4" runat="server" AutoPostBack="false" />


                    </div>
                </div>
                <%-- </form>--%>
            </div>
        </div>

        <div>
            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp 
        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp 
            <asp:Button ID="btnCloseDocument" runat="server" Text="CloseDocument" BackColor="#009999" ForeColor="#000099" Width="263px" Height="36px" OnClick="btnCloseDocument_Click" />

        </div>

    </div>
    <script src="../Content/themes/FlyCnBlue/js/selectize.js"></script>
    <script src="../Content/themes/FlyCnBlue/js/index.js"></script>
    <script>




        var $select = $('#selecttools').selectize({

            maxItems: null,
            valueField: 'id',
            labelField: 'title',
            searchField: 'title',
            options: getOptions(),
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

        var $select = $('#select-tools2').selectize({
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

        var $select = $('#select-tools3').selectize({
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

        var $select = $('#select-tools4').selectize({
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

        var $select = $('#select-tools5').selectize({
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

        var $select = $('#select-tools6').selectize({
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

        var $select = $('#select-tools7').selectize({
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
</asp:Content>
