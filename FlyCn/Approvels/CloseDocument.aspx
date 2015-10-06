<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="CloseDocument.aspx.cs" Inherits="FlyCn.Approvels.CloseDocument" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <asp:HiddenField ID="hdfRevisionId" runat="server" />
    <asp:Label ID="lblrevisionid" runat="server" Text="" ForeColor="SteelBlue"></asp:Label>

 <%-- <asp:TextBox ID="txtrevisionid" runat="server" ForeColor="Tan"></asp:TextBox>--%>

     <div class="col-lg-12 Span-One">
    <div class="col-lg-6">
     
        <div class="form-group">
    <asp:Label ID="lblLevel1" runat="server" class="control-label col-md-3" ForeColor="#669900"></asp:Label>
    <div class="col-md-9">
            <div class="control-group">
              <select id="selecttools" name="Level1"  
           >
        <option value=""></option>
        <option value="1">Manu</option>
        <option value="2">Amal</option>
        <option value="3">Jomon</option>
    </select>
            </div>
          </div>
        </div>
      
    </div>
    <div class="col-lg-6"> </div>
  </div>
    
    <div class="col-lg-12 Span-One">
    <div class="col-lg-6">
     
        <div class="form-group">
     <asp:Label ID="lblLevel2" runat="server" class="control-label col-md-3" ForeColor="#669900"></asp:Label>
    <div class="col-md-9">
            <div class="control-group">
              <select id="select-tools2" name="Level2">
        <option value=""></option>
        <option value="S1">Suvaneeth</option>
        <option value="J1">javd</option>
        <option value="J2">jissar</option>
    </select>
            </div>
          </div>
        </div>
      
    </div>
    <div class="col-lg-6"> 
                

        </div>
  </div>

    <div class="col-lg-12 Span-One">
    <div class="col-lg-6">
     
        <div class="form-group">
     <asp:Label ID="lblLevel3" runat="server" class="control-label col-md-3" ForeColor="#669900"></asp:Label>
    <div class="col-md-9">
            <div class="control-group">
              <select id="select-tools3" name="Level3">
        <option value=""></option>
        <option value="A1">Albert</option>
        <option value="A11">Amrutha</option>
        <option value="G2">Gopika</option>
    </select>
            </div>
          </div>
        </div>
      
    </div>
    <div class="col-lg-6"> 
                

        </div>
  </div>

    

    <div>
 &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp 
        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp  <asp:Button ID="btnCloseDocument" runat="server" Text="CloseDocument" BackColor="#009999" ForeColor="#000099" Width="263px" Height="36px" OnClick="btnCloseDocument_Click" />

    </div>
                
    <script src="../Content/themes/FlyCnBlue/js/selectize.js"></script> 
<script src="../Content/themes/FlyCnBlue/js/index.js"></script> 
<script>
  
				var $select = $('#selecttools').selectize({
					maxItems: null,
					
					create: false
				});
				

				// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

				var control = $select[0].selectize;

				$('#button-clear').on('click', function() {
					control.clear();
				});

				$('#button-clearoptions').on('click', function() {
					control.clearOptions();
				});

				$('#button-addoption').on('click', function() {
					control.addOption({
						id: 4,
						title: 'Something New',
						url: 'http://google.com'
					});
				});

				$('#button-additem').on('click', function() {
					control.addItem(2);
				});

				$('#button-setvalue').on('click', function() {
					control.setValue([2, 3]);
				});
				
				
				
				</script> 
<script>

    var $select = $('#select-tools2').selectize({
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

        var $select = $('#select-tools3').selectize({
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
