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
    
    <div class="container" style="width: 100%">
        <div  id="Placeholder" runat="server">
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
                            <select id="selecttools1" name="Level1" runat="server"  visible="false">

                                <option value="0"></option>
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

                        <asp:CheckBox ID="chkLevel1" runat="server" AutoPostBack="false"  Visible="false" />


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
                            <select id="selecttools2" name="Level2" runat="server" visible="false">
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

                        <asp:CheckBox ID="chkLevel2" runat="server" AutoPostBack="false" Visible="false" />

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
                            <select id="selecttools3" name="Level3" runat="server" visible="false">
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

                        <asp:CheckBox ID="chkLevel3" runat="server" AutoPostBack="false"  Visible="false" />


                    </div>
                </div>
                <%-- </form>--%>
            </div>
        </div>

        <div class="col-md-12 Span-One">
            <div class="col-md-6">

                <div class="form-group">
                    <asp:Label ID="lblLevel4" runat="server" class="control-label col-md-3" ForeColor="#669900"></asp:Label>
                    <div class="col-md-9">
                        <div class="control-group">
                            <select id="selecttools4" name="Level4" visible="false" runat="server">
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

                        <asp:CheckBox ID="chkLevel4" runat="server" AutoPostBack="false"  Visible="false" />


                    </div>
                </div>
                <%-- </form>--%>
            </div>
        </div>

        <div class="col-md-12 Span-One">
            <div class="col-md-6">

                <div class="form-group">
                    <asp:Label ID="lblLevel5" runat="server" class="control-label col-md-3" ForeColor="#669900"></asp:Label>
                    <div class="col-md-9">
                        <div class="control-group">
                            <select id="selecttools5" name="Level5" visible="false" runat="server">
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

                        <asp:CheckBox ID="chkLevel5" runat="server" AutoPostBack="false"  Visible="false" />


                    </div>
                </div>
                <%-- </form>--%>
            </div>
        </div>

        <div class="col-md-12 Span-One">
            <div class="col-md-6">

                <div class="form-group">
                    <asp:Label ID="lblLevel6" runat="server" class="control-label col-md-3" ForeColor="#669900"></asp:Label>
                    <div class="col-md-9">
                        <div class="control-group">
                            <select id="selecttools6" name="Level3" runat="server" visible="false"> 
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

                        <asp:CheckBox ID="chkLevel6" runat="server" AutoPostBack="false"  Visible="false" />


                    </div>
                </div>
                <%-- </form>--%>
            </div>
        </div>

        <div class="col-md-12 Span-One">
            <div class="col-md-6">

                <div class="form-group">
                    <asp:Label ID="lblLevel7" runat="server" class="control-label col-md-3" ForeColor="#669900"></asp:Label>
                    <div class="col-md-9">
                        <div class="control-group">
                            <select id="selecttools7" name="Level3" runat="server" visible="false">
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

                        <asp:CheckBox ID="chkLevel7" runat="server" AutoPostBack="false"  Visible="false" />


                    </div>
                </div>
                <%-- </form>--%>
            </div>
        </div>

        <div class="col-md-12 Span-One">
            <div class="col-md-6">

                <div class="form-group">
                    <asp:Label ID="lblLevel8" runat="server" class="control-label col-md-3" ForeColor="#669900"></asp:Label>
                    <div class="col-md-9">
                        <div class="control-group">
                            <select id="selecttools8" name="Level3" visible="false"  runat="server">
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

                        <asp:CheckBox ID="chkLevel8" runat="server" AutoPostBack="false"  Visible="false" />


                    </div>
                </div>
                <%-- </form>--%>
            </div>
        </div>

        <div class="col-md-12 Span-One">
            <div class="col-md-6">

                <div class="form-group">
                    <asp:Label ID="lblLevel9" runat="server" class="control-label col-md-3" ForeColor="#669900"></asp:Label>
                    <div class="col-md-9">
                        <div class="control-group">
                            <select id="selecttools9" name="Level3" visible="false" runat="server">
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

                        <asp:CheckBox ID="chkLevel9" runat="server" AutoPostBack="false"  Visible="false" />


                    </div>
                </div>
                <%-- </form>--%>
            </div>
        </div>

            <div class="col-md-12 Span-One">
            <div class="col-md-6">

                <div class="form-group">
                    <asp:Label ID="lblLevel10" runat="server" class="control-label col-md-3" ForeColor="#669900"></asp:Label>
                    <div class="col-md-9">
                        <div class="control-group">
                            <select id="selecttools10" name="Level10" visible="false" runat="server">
                              

                            </select>
                        </div>
                    </div>
                </div>

            </div>
            <div class="col-md-6">
                <%--    <form class="form-horizontal" role="form">--%>
                <div class="form-group">


                    <div class="col-md-9">

                        <asp:CheckBox ID="chkLevel10" runat="server" AutoPostBack="false"  Visible="false" />


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
        </div>
    <script src="../Content/themes/FlyCnBlue/js/selectize.js"></script>
    <script src="../Content/themes/FlyCnBlue/js/index.js"></script>
    <script>




        var $select = $('#selecttools1').selectize({

            maxItems: null,
          
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
