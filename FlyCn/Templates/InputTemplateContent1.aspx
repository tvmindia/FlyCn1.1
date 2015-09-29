<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="InputTemplateContent1.aspx.cs" Inherits="FlyCn.Templates.InputTemplateContent1" %>
<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Input</title>
    <!-----bootstrap css--->
    <link href="../Content/themes/FlyCnBlue/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../Content/themes/FlyCnBlue/css/roboto_google_api.css" rel="stylesheet" />

    <link href="Content/themes/FlyCnBlue/css/datepicker.css" rel="stylesheet" type="text/css" />
    <!-----bootstrap css--->
    <link href="../Content/themes/FlyCnBlue/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/themes/FlyCnBlue/css/stylesheet.css" rel="stylesheet" />

    <link href="../Content/themes/FlyCnBlue/css/selectize.css" rel="stylesheet" type="text/css" />
    <link href="../Content/themes/FlyCnBlue/css/accodin.css" rel="stylesheet" type="text/css" />
    <!-----main css--->
    <link href="../Content/themes/FlyCnBlue/css/style.css" rel="stylesheet" type="text/css" />
   
 

    <!-----main css--->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
           <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
</asp:ScriptManager>
     <div class="PageHeading">Construction Punch List</div>
    <div class="container inputMainContainer"  >
  <div class="col-md-12"   >
        <ul id="tabs">
      <li><a href="#" name="tab1">View</a></li>
      <li><a href="#" name="tab2">New</a></li>
             </ul>
    <div id="content"  >
      <div id="tab1"  >
          <div role="tabpanel" class="tab-pane active" id="home">
          <div class="table-responsive">
            <div class="contentTopBar"></div>
            
    
             <telerik:RadGrid ID="dtgManageProjectGrid" runat="server"  CellSpacing="0"
    GridLines="None" OnNeedDataSource="dtgManageProjectGrid_NeedDataSource" AllowPaging="true" OnItemCommand="dtgManageProjectGrid_ItemCommand"
    PageSize="10" Width="100%"   >
                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="ProjectNo,IDNo,EILType">
    <Columns>
         <telerik:GridButtonColumn CommandName="EditData" Text="Edit" UniqueName="EditData" ButtonType="ImageButton" ImageUrl="~/Images/Icons/Pencil-01.png"></telerik:GridButtonColumn>     
     <telerik:GridButtonColumn CommandName="DeleteColumn" Text="Delete" UniqueName="DeleteColumn" ButtonType="ImageButton" ImageUrl="~/Images/Cancel.png" ConfirmDialogType="RadWindow" ConfirmText="Are you sure, you want to delete this item ?">
      </telerik:GridButtonColumn>

     <telerik:GridBoundColumn HeaderText="Project No" DataField="ProjectNo" UniqueName="ProjectNo"></telerik:GridBoundColumn> 
     <telerik:GridBoundColumn HeaderText="ID No" DataField="IDNo" UniqueName="IDNo"></telerik:GridBoundColumn>
     <telerik:GridBoundColumn HeaderText="LinkIDNo" DataField="LinkIDNo" UniqueName="LinkIDNo"></telerik:GridBoundColumn> 
     <telerik:GridBoundColumn HeaderText="EILType" DataField="EILType" UniqueName="EILType"></telerik:GridBoundColumn> 
     <telerik:GridBoundColumn HeaderText="OpenBy" DataField="OpenBy" UniqueName="OpenBy"></telerik:GridBoundColumn> 
     <telerik:GridBoundColumn HeaderText="OpenDt" DataField="OpenDt" UniqueName="OpenDt" DataType="System.DateTime"  DataFormatString="{0:M/d/yyyy}"></telerik:GridBoundColumn> 
    
    </Columns>
  </MasterTableView>            
             </telerik:RadGrid>
               </div>
        </div>
      </div>
      <div id="tab2"  > 
        <div role="tabpanel" class="tab-pane active" id="Div1">
             
          <div class="table-responsive">
               <div class="contentTopBar"></div>
              <div  >
               <uc1:ToolBar runat="server" ID="ToolBar" /></div>
                <div class="col-md-12 Span-One">
                    <div class="col-md-6 ">
                        <div class="form-group ">
                        <label class="control-label col-md-3" for="email3">Module </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtModule" runat="server"></asp:TextBox>
                        </div>
                        </div>
                    </div>
                     <div class="col-md-6 ">
                        <div class="form-group">
                        <label class="control-label col-md-3" for="email3">Category </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-12 Span-One">
                    <div class="col-md-6 ">
                        <div class="form-group ">
                        <label class="control-label col-md-3" for="email3">Tag </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        </div>
                        </div>
                    </div>
                     <div class="col-md-6 ">
                        <div class="form-group">
                        <label class="control-label col-md-3" for="email3">Activity </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                        </div>
                        </div>
                    </div>
                </div>

              <div class="col-md-12">
                  <div class="content white">
                      <div class="accordion-container">
                          <a href="#" class="accordion-toggle">Lorem Ipsum is simply <span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>
                          <div class="accordion-content">
                                  <div class="col-md-6 ">
                        <div class="form-group ">
                        <label class="control-label col-md-3" for="email3">Module </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                        </div>
                        </div>
                    </div>
                     <div class="col-md-6 ">
                        <div class="form-group">
                        <label class="control-label col-md-3" for="email3">Category </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                        </div>
                        </div>
                    </div>
                                <div class="col-md-6 ">
                        <div class="form-group ">
                        <label class="control-label col-md-3" for="email3">Module </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                        </div>
                        </div>
                    </div>
                     <div class="col-md-6 ">
                        <div class="form-group">
                        <label class="control-label col-md-3" for="email3">Category </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                        </div>
                        </div>
                    </div>
                                <div class="col-md-6 ">
                        <div class="form-group ">
                        <label class="control-label col-md-3" for="email3">Module </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                        </div>
                        </div>
                    </div>
                     <div class="col-md-6 ">
                        <div class="form-group">
                        <label class="control-label col-md-3" for="email3">Category </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                        </div>
                        </div>
                    </div>
                                <div class="col-md-6 ">
                        <div class="form-group ">
                        <label class="control-label col-md-3" for="email3">Module </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                        </div>
                        </div>
                    </div>
                     <div class="col-md-6 ">
                        <div class="form-group">
                        <label class="control-label col-md-3" for="email3">Category </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                        </div>
                        </div>
                    </div>
                          </div>
                      </div>
                  
                      <div class="accordion-container">
                          <a href="#" class="accordion-toggle">Lorem Ipsum is simply <span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>
                          <div class="accordion-content">
                                  <div class="col-md-6 ">
                        <div class="form-group ">
                        <label class="control-label col-md-3" for="email3">Module </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                        </div>
                        </div>
                    </div>
                     <div class="col-md-6 ">
                        <div class="form-group">
                        <label class="control-label col-md-3" for="email3">Category </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
                        </div>
                        </div>
                    </div>
                                <div class="col-md-6 ">
                        <div class="form-group ">
                        <label class="control-label col-md-3" for="email3">Module </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
                        </div>
                        </div>
                    </div>
                     <div class="col-md-6 ">
                        <div class="form-group">
                        <label class="control-label col-md-3" for="email3">Category </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>
                        </div>
                        </div>
                    </div>
                                <div class="col-md-6 ">
                        <div class="form-group ">
                        <label class="control-label col-md-3" for="email3">Module </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="TextBox16" runat="server"></asp:TextBox>
                        </div>
                        </div>
                    </div>
                     <div class="col-md-6 ">
                        <div class="form-group">
                        <label class="control-label col-md-3" for="email3">Category </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="TextBox17" runat="server"></asp:TextBox>
                        </div>
                        </div>
                    </div>
                                <div class="col-md-6 ">
                        <div class="form-group ">
                        <label class="control-label col-md-3" for="email3">Module </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="TextBox18" runat="server"></asp:TextBox>
                        </div>
                        </div>
                    </div>
                     <div class="col-md-6 ">
                        <div class="form-group">
                        <label class="control-label col-md-3" for="email3">Category </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="TextBox19" runat="server"></asp:TextBox>
                        </div>
                        </div>
                    </div>
                          </div>
                      </div>
                  </div>
              </div>
          </div>
        </div>
      </div>
        </div>

  </div>

   
  </div>
    
 
 
   <script>
       $(document).ready(function () {
           $("#content").find("[id^='tab']").hide(); // Hide all content
           $("#tabs li:first").attr("id", "current"); // Activate the first tab
           $("#content #tab1").fadeIn(); // Show first tab's content

           $('#tabs a').click(function (e) {
               e.preventDefault();
               if ($(this).closest("li").attr("id") == "current") { //detection for current tab
                   return;
               }
               else {
                   $("#content").find("[id^='tab']").hide(); // Hide all content
                   $("#tabs li").attr("id", ""); //Reset id's
                   $(this).parent().attr("id", "current"); // Activate this
                   $('#' + $(this).attr('name')).fadeIn(); // Show content for the current tab
               }
           });
       });
</script> 
    <script type="text/javascript">
        $(document).ready(function () {
            $('.accordion-toggle').on('click', function (event) {
                event.preventDefault();
                // create accordion variables
                var accordion = $(this);
                var accordionContent = accordion.next('.accordion-content');
                var accordionToggleIcon = $(this).children('.toggle-icon');

                // toggle accordion link open class
                accordion.toggleClass("open");
                // toggle accordion content
                accordionContent.slideToggle(250);

                // change plus/minus icon
                if (accordion.hasClass("open")) {
                    accordionToggleIcon.html("<i class='fa fa-minus-circle'></i>");
                } else {
                    accordionToggleIcon.html("<i class='fa fa-plus-circle'></i>");
                }

            });
        });
</script>  
</asp:Content>
