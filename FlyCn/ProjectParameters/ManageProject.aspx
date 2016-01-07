 <%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="ManageProject.aspx.cs" Inherits="FlyCn.ProjectParameters.ManageProject" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../Scripts/jquery-1.8.2.min.js">
    </script>
    <script src="../Scripts/jquery-ui-1.8.24.js"></script>
    <link href="../Content/themes/base/jquery-ui.css" rel="stylesheet" />
      <script src="../Scripts/ToolBar.js"></script>
    <script src="../Scripts/Messages.js"></script>
    <script type="text/javascript">
        //$("[id*=btnModalPopup]").live("click", function () {
        function PopUp() {

        }
    </script>
    
    <style type="text/css">
        .ui-dialog-title {
            padding-left: 5em;
            color: green;
           width:500px;
           text-align:center;
         height:1px;
        }

        .ui-dialog-titlebar {
            background: #ffffff;
            border: none;
        }

        .ui-dialog .ui-dialog-titlebar-close {
            right: 0;
        }

        .ui-dialog {
            box-shadow: 0px 2px 7px #ffffff;
            -moz-box-shadow: 0px 2px 7px #ffffff;
            -webkit-box-shadow: 0px 2px 7px #ffffff;
            border-radius: 15px;
            -moz-border-radius: 15px;
            -webkit-border-radius: 15px;
            background: #FFFFFF;
            z-index: 5;
            /*background:transparent;*/
            /*background: rgba(34,34,34,0.75);*/
            background: rgb(255, 255, 255);
            border: 1px solid #fff;
        }

        .headings {
            font-family: 'segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            font-size: 15px;
            font-style: normal;
            color: #009933;
        }
        .content {
            border: 1px solid #FFFFFF;
            width: 50%;
            padding: 5px;
            margin: 0px 0 0 5px;
        }
        td.myclass {
            text-align: left;
            width: 10px;
        }

        td.size {
            text-align: left;
            width: 5px;
        }
    </style>

    <script type="text/javascript">

        function validate() {
            //try{

            debugger;
            var ProjectNo = document.getElementById("<%=txtProjNo.ClientID %>").value;
            var ProjectName = document.getElementById("<%=txtProjName.ClientID %>").value;
            var ProjectLocation = document.getElementById("<%=txtLocation.ClientID %>").value;
            var ProjectManager = document.getElementById("<%=txtManager.ClientID %>").value;

            if (ProjectNo == "" || ProjectName == "" || ProjectLocation == "" || ProjectManager == "") {

                <%--  document.getElementById("<%=lblerror.ClientID %>").innerHTML = "Please Fill all the Mandatory fields";--%>
                displayMessage(messageType.Error, messages.MandatoryFieldsGeneral);

                return false;

            }
            else {
                document.getElementById("<%=lblerror.ClientID %>").innerHTML = "";
                return true;
            }

        }
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            //------------------------For Security-----------------------------------------------//
            debugger;
            //var security = document.getElementById("hdnSecurityMaster").value;
            //DisableButtons();
            //Page Postback
            <%-- if (document.getElementById('<%=hdnAccessMode.ClientID%>').value == "EditData")
            {
                EnableButtonsForEdit();
            }
            else
                if (document.getElementById('<%=hdnAccessMode.ClientID%>').value == "ViewDetailColumn")
                {
                    DisableButtons();
                }--%>

            //----------------------------------------------------------------------------------//
            id = document.getElementById('IDAccordion');

            OpenDetailAccordion(id);
            parent.showTreeNode();

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


        function OpenDetailAccordion(id) {
            if (id != undefined)//accordion called from accordion click functionjs
            {
                var accordion = $(id);
                var accordionContent = accordion.next('.accordion-content');
                var accordionToggleIcon = accordion.children('.toggle-icon');

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
            }
        }

        function OnClientTabSelecting(sender, eventArgs) {
            var tab = eventArgs.get_tab();
            if (tab.get_value() == '2') {

                eventArgs.set_cancel(true);
                OpenNewProjectWizard();
            }

        }

        function OpenNewProjectWizard() {
            try {
                $("#modal_dialog").dialog({

                    title: "Project Wizard",
                    width: 800,
                    height: 400,
                    buttons: {}, modal: true



                });
                //$(".ui-dialog-titlebar").hide();
                //  $("#modal_dialog").dialog('widget').find(".ui-dialog-titlebar-close").show();
                return false;
            }
            catch (X) {
                alert(X.message);
            }
        }
        function onClientTabSelected(sender, args) {
            var tab = args.get_tab();

            if (tab.get_value() == '2') {


                try {
                    <%=ToolBar.ClientID %>_SetAddVisible(false);
                          <%=ToolBar.ClientID %>_SetSaveVisible(true);
                          <%=ToolBar.ClientID %>_SetUpdateVisible(false);
                          <%=ToolBar.ClientID %>_SetDeleteVisible(false);

                      }
                      catch (x) { alert(x.message); }



                  }

                  if (tab.get_value() == "1") {

                      var tabStrip = $find("<%= RadTabStrip1.ClientID %>");
                      var tab = tabStrip.findTabByValue("1");
                      tab.select();
                      var tab1 = tabStrip.findTabByValue("2");
                      tab1.set_text("New");
                      tab1.set_imageUrl('../Images/Icons/NewIcon.png');

                  }


              }

    </script>

    <script>

        function OnClientButtonClicking(sender, args) {

            var btn = args.get_item();
            if (btn.get_value() == 'Delete') {

                args.set_cancel(!confirm('Do you want to delete ?'));
            }
            if (btn.get_value() == 'Update') {

                args.set_cancel(!validate());
            }


        }
    </script>



     <asp:Label ID="lblTitle" runat="server" Text="Manage Project" CssClass="PageHeading"></asp:Label>
   
   
    
      <div class="container" style="width: 100%">
   

            <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" Width="300px" OnClientTabSelecting="OnClientTabSelecting" OnClientTabSelected="onClientTabSelected"
                CausesValidation="false" SelectedIndex="0" Skin="FlyCnRed_Rad" EnableEmbeddedSkins="false">

                <Tabs>
                    <telerik:RadTab Text="View" PageViewID="rpList" Value="1" Width="150px" runat="server" ImageUrl="~/Images/Icons/ListIcon.png" Selected="True"></telerik:RadTab>
                    <telerik:RadTab Text="New" PageViewID="EditData" Value="2" Width="150px" runat="server" ImageUrl="~/Images/Icons/NewIcon.png"></telerik:RadTab>

                </Tabs>
            </telerik:RadTabStrip>
           <div id="content">
                <%-- For Security ViewDetailColumn--%>
            <div class="contentTopBar"></div>


            <telerik:RadMultiPage ID="RadMultiPage1" runat="server" Width="100%" SelectedIndex="0" CssClass="outerMultiPage">

                <telerik:RadPageView ID="rpList" runat="server">

                    <div id="divList" style="width: 100%">
                        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
                        </asp:ScriptManager>

                        <telerik:RadGrid ID="dtgManageProjectGrid" runat="server" CellSpacing="0" 
                             AllowPaging="true" GridLines="None" OnItemCommand="dtgManageProjectGrid_ItemCommand" OnNeedDataSource="dtgManageProjectGrid_NeedDataSource1" OnPreRender="dtgManageProjectGrid_PreRender"
                             PageSize="10" Skin="Silk" Width="100%">
                            <MasterTableView AutoGenerateColumns="False" DataKeyNames="ProjectNo">
                                <Columns>
                                     
                                    <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="EditData" ImageUrl="~/Images/Icons/Pencil-01.png" Text="Edit" UniqueName="EditData"></telerik:GridButtonColumn>
                                    <telerik:GridBoundColumn DataField="ProjectNo" HeaderText="Project No" UniqueName="ProjectNo"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ProjectName" HeaderText="Project Name" UniqueName="ProjectName"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ProjectLocation" HeaderText="Location" UniqueName="ProjectLocation"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Active" HeaderText="Active" UniqueName="Active"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CompName" HeaderText="Company Name" UniqueName="CompName"></telerik:GridBoundColumn>
                                   
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </div>
                </telerik:RadPageView>

                <telerik:RadPageView ID="EditData" runat="server">
                    <asp:Label ID="lblerror" runat="server" Text="" ForeColor="Red"></asp:Label>

                    <uc1:ToolBar runat="server" ID="ToolBar" />

                     <%-- Tracking Details--%>
                                               <div class="accordion-container"> <a href="#" class="accordion-toggle" id="IDAccordion"> 
                              <span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a> </div>

  <div class="accordion-content"> 
                                      <div class="col-md-12 Span-One">
                                    <div class="col-md-6">
                                      <div class="form-group">
                   <asp:Label ID="lblProjectNo" runat="server" Text="ProjectNo"  class="control-label col-md-5" for="email3"></asp:Label>
                                         <div class="col-md-7">
                                                <asp:TextBox ID="txtProjNo" runat="server"></asp:TextBox>
                                            </div>
                                          </div>
                                        </div>
                                           <div class="col-md-6">
                                      <div class="form-group">
                                         <asp:Label ID="lblProjectName" runat="server" Text="Project Name"  class="control-label col-md-5" for="email3"></asp:Label>
                                              <div class="col-md-7">
                                                <asp:TextBox ID="txtProjName" runat="server"></asp:TextBox>
                                               </div>
                                          </div>
                                               </div>
                                                 <div class="col-md-6">
                                      <div class="form-group">
                                            <asp:Label ID="lblProjectLocation" runat="server" Text="Project Location"  class="control-label col-md-5" for="email3"></asp:Label>
                                                <div class="col-md-7">
                                                <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox>
                                               </div>
                                          </div>
                                                     </div>
                                                         <div class="col-md-6">
                                      <div class="form-group">
                                                       <asp:Label ID="lblProjectManager" runat="server" Text="Project Manager"  class="control-label col-md-5" for="email3"></asp:Label>
                                                   <div class="col-md-7">
                                                <asp:TextBox ID="txtManager" runat="server"></asp:TextBox>
                                                       </div>
                                               </div>
                                                             </div>
                                           <div class="col-md-6">
                                      <div class="form-group">
                                          <asp:Label ID="lblBaseProject" runat="server" Text="Base Project"  class="control-label col-md-5" for="email3"></asp:Label>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtBaseProject" runat="server"></asp:TextBox>
                                            </div>
                                          </div>
                                               </div>
                                          <div class="col-md-6">
                                      <div class="form-group">
                                          <asp:Label ID="lblActive" runat="server" Text="Active"  class="control-label col-md-5" for="email3"></asp:Label>
                                            <div class="col-md-7">

                                          
                                                <asp:CheckBox ID="CheckboxActive" runat="server" AutoPostBack="false" />
                                </div>
                                          </div>
                                              </div>
                                        </div>
                                 </div>
                                      </div>

                <%--  Company Details--%>
                       <div class="accordion-container"> <a href="#" class="accordion-toggle" >Company Details
                              <span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>
                              
                             <div class="accordion-content"> 
                                      <div class="col-md-12 Span-One">
                                    <div class="col-md-6">
                                      <div class="form-group">
                   <asp:Label ID="lblCompanyName" runat="server" Text="Company Name"  class="control-label col-md-5" for="email3"></asp:Label>
                                         <div class="col-md-7">
                                                <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
                                          </div></div>
                                        </div>
                                            <div class="col-md-6">
                                      <div class="form-group">
                   <asp:Label ID="lblAddress1" runat="server" Text="Address1"  class="control-label col-md-5" for="email3"></asp:Label>
                                         <div class="col-md-7">
                                           
                                                <asp:TextBox ID="txtAddress1" runat="server"></asp:TextBox>
                                           </div>
                                          </div>
                                                </div>
                                           <div class="col-md-6">
                                      <div class="form-group">
                   <asp:Label ID="lblAddress2" runat="server" Text="Address2 "  class="control-label col-md-5" for="email3"></asp:Label>
                                         <div class="col-md-7">
                                         
                                                <asp:TextBox ID="txtAddress2" runat="server"></asp:TextBox>
                                           
                                          </div>
                                          </div></div>
                                            <div class="col-md-6">
                                      <div class="form-group">
                   <asp:Label ID="lblTelephone" runat="server" Text="Telephone"  class="control-label col-md-5" for="email3"></asp:Label>
                                         <div class="col-md-7">
                                         
                                            
                                                <asp:TextBox ID="txtTelephone" runat="server"></asp:TextBox>
                                         </div>
                                          </div>
                                                </div>
                                              <div class="col-md-6">
                                      <div class="form-group">
                   <asp:Label ID="lblFax" runat="server" Text="Fax"  class="control-label col-md-5" for="email3"></asp:Label>
                                         <div class="col-md-7">
                                                <asp:TextBox ID="txtFax" runat="server"></asp:TextBox>
                                          </div>
                                          </div>
                                                  </div>
                                               <div class="col-md-6">
                                      <div class="form-group">
                   <asp:Label ID="lblEmail" runat="server" Text="Email"  class="control-label col-md-5" for="email3"></asp:Label>
                                         <div class="col-md-7">
                                                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                        </div>
                                          </div>
                                                   </div>
                                           <div class="col-md-6">
                                      <div class="form-group">
                   <asp:Label ID="lblWebsite" runat="server" Text="Website"  class="control-label col-md-5" for="email3"></asp:Label>
                                         <div class="col-md-7">
                                          
                                                <asp:TextBox ID="txtWebsite" runat="server"></asp:TextBox>
                                          </div>
                                          </div>
                                               </div>
                                              <div class="col-md-6">
                                      <div class="form-group">
                                                <asp:Label ID="lblComapnyLogo" runat="server" Text="Company Logo"></asp:Label>
                                             <div class="col-md-7">
                                                <asp:FileUpload ID="fuLogo" runat="server" Height="22px" Width="175px" />
                                                <asp:ImageButton ID="imbCompany" runat="server" Height="20px" Width="20px" />
                                                <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
                                </div>
                                          </div>
                                                  </div>
                               </div>
                                 </div>
                           </div>
             <%--       Client Details--%>
                     <div class="accordion-container"> <a href="#" class="accordion-toggle" >Client Details
                              <span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>
                              
                             <div class="accordion-content"> 
                                      <div class="col-md-12 Span-One">
                                    <div class="col-md-6">
                                      <div class="form-group">
                   <asp:Label ID="lblClientName" runat="server" Text="Client Name "  class="control-label col-md-5" for="email3"></asp:Label>
                                         <div class="col-md-7">
                    
                                        
                                        
                                                <asp:TextBox ID="txtClientName" runat="server"></asp:TextBox>
                                          </div>
                                          </div>
                                        </div>
                                             <div class="col-md-6">
                                      <div class="form-group">
                   <asp:Label ID="lblContractDetails" runat="server" Text="Contract Details "  class="control-label col-md-5" for="email3"></asp:Label>
                                         <div class="col-md-7">
                    
                                      
                                                <asp:TextBox ID="txtContractDetails" runat="server"></asp:TextBox>
                                      
                                     </div>
                                          </div>
                                                 </div>
                                             <div class="col-md-6">
                                      <div class="form-group">
                   <asp:Label ID="lblTelephone1" runat="server" Text="Telephone"  class="control-label col-md-5" for="email3"></asp:Label>
                                         <div class="col-md-7">
                                            
                                                <asp:TextBox ID="txtClientTelephone" runat="server"></asp:TextBox>
                                       </div>
                                          </div></div>
                                             <div class="col-md-6">
                                      <div class="form-group">
                   <asp:Label ID="lblClientFax" runat="server" Text="Client Fax"  class="control-label col-md-5" for="email3"></asp:Label>
                                         <div class="col-md-7">
                                                <asp:TextBox ID="txtClientFax" runat="server"></asp:TextBox>
                                         </div>
                                          </div>
                                                 </div>
                                               <div class="col-md-6">
                                      <div class="form-group">
                   <asp:Label ID="lblClientEmail" runat="server" Text="Client Email"  class="control-label col-md-5" for="email3"></asp:Label>
                                         <div class="col-md-7">
                                         
                                                <asp:TextBox ID="txtClientEmail" runat="server"></asp:TextBox>
                                            </div>
                                          </div>
                                                   </div>
                                             <div class="col-md-6">
                                      <div class="form-group">
                   <asp:Label ID="lblClientWebsite" runat="server" Text="Website"  class="control-label col-md-5" for="email3"></asp:Label>
                                         <div class="col-md-7">
                                           
                                                <asp:TextBox ID="txtClientWebsite" runat="server"></asp:TextBox>
                                          </div>
                                          </div>
                                                 </div>
                                             <div class="col-md-6">
                                      <div class="form-group">
                                                <asp:Label ID="lblClientLogo" runat="server" Text="Client Logo"></asp:Label>
                                         <div class="col-md-7">
                                                
                                         
                                                <asp:FileUpload ID="fuClientLogo" runat="server" Height="22px" Width="175px" />
                                                <asp:ImageButton ID="imbClientLogo" runat="server" Height="20px" Width="20px" />
                                                <asp:Label ID="lblmsg1" runat="server" Text=""></asp:Label>
                                    </div>
                                          </div>
                                                 </div>
                                          </div></div>
                                </div>
<%--  Admin Details--%>
                                     <div class="accordion-container"> <a href="#" class="accordion-toggle" >Admin Details
                              <span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>
                              
                             <div class="accordion-content"> 
                                      <div class="col-md-12 Span-One">
                                    <div class="col-md-6">
                                      <div class="form-group">
                   <asp:Label ID="lblImplementationEngineer" runat="server" Text=" Implementation Engineer"  class="control-label col-md-5" for="email3"></asp:Label>
                                         <div class="col-md-7">
                                     
                                                <asp:TextBox ID="txtImplementation" runat="server"></asp:TextBox>
                                          
                                           </div>
                                          </div>
                                        </div>
                                             <div class="col-md-6">
                                      <div class="form-group">
                   <asp:Label ID="lblProjectAdmin" runat="server" Text="Project Admin "  class="control-label col-md-5" for="email3"></asp:Label>
                                         <div class="col-md-7">
                                         
                                                <asp:TextBox ID="txtProjectAdmin" runat="server"></asp:TextBox>
                                     </div>
                                          </div>
                                                 </div>
                                                <div class="col-md-6">
                                      <div class="form-group">
                   <asp:Label ID="lblPunchListFromCompany" runat="server" Text="Punch List From Company"  class="control-label col-md-5" for="email3"></asp:Label>
                                         <div class="col-md-7">
                                          
                                                <asp:TextBox ID="txtPunchList" runat="server"></asp:TextBox>
                                           </div>
                                          </div>
                                                    </div>
  <div class="col-md-6">
                                      <div class="form-group">
                   <asp:Label ID="lblPunchListFromPerson" runat="server" Text="Punch List From Person"  class="control-label col-md-5" for="email3"></asp:Label>
                                         <div class="col-md-7">
                                        
                                                <asp:TextBox ID="txtPunchListPerson" runat="server"></asp:TextBox>
                                         </div></div></div>
                                           <div class="col-md-6">
                                      <div class="form-group">
                   <asp:Label ID="lblPunchListToCompany" runat="server" Text="Punch List To Company"  class="control-label col-md-5" for="email3"></asp:Label>
                                         <div class="col-md-7">
                                          
                                                <asp:TextBox ID="txtPunchListToCompany" runat="server"></asp:TextBox>
                                            </div></div></div>
                                                 <div class="col-md-6">
                                      <div class="form-group">
                   <asp:Label ID="lblPunchListTOPerson" runat="server" Text="Punch List TO Person"  class="control-label col-md-5" for="email3"></asp:Label>
                                         <div class="col-md-7">
                                          
                                                <asp:TextBox ID="txtPunchListToPerson" runat="server"></asp:TextBox>
                                   
                             </div></div></div>
                                </div>
                                 </div></div>
                    <%--Caption For Project Fields--%>
                          <div class="accordion-container"> <a href="#" class="accordion-toggle" >Caption For Project Fields
                              <span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>
                              
                             <div class="accordion-content"> 
                                      <div class="col-md-12 Span-One">
                                    <div class="col-md-6">
                                      <div class="form-group">
                   <asp:Label ID="lblPlant" runat="server" Text="Plant"  class="control-label col-md-5" for="email3"></asp:Label>
                                         <div class="col-md-7">
                                    
                                                <asp:TextBox ID="txtPlant" runat="server"></asp:TextBox>
                                          </div></div></div>
                                           <div class="col-md-6">
                                      <div class="form-group">
                   <asp:Label ID="lblArea" runat="server" Text="Area"  class="control-label col-md-5" for="email3"></asp:Label>
                                         <div class="col-md-7">
                                                <asp:TextBox ID="txtArea" runat="server"></asp:TextBox>
                                           </div></div></div>
                                              <div class="col-md-6">
                                      <div class="form-group">
                   <asp:Label ID="lblLocation" runat="server" Text="Location"  class="control-label col-md-5" for="email3"></asp:Label>
                                         <div class="col-md-7">
                                         
                                                <asp:TextBox ID="txtCaptionLocation" runat="server"></asp:TextBox>
                                           </div>
                                          </div>
                                                  </div>
                                          <div class="col-md-6">                                              
                                      <div class="form-group">
                   <asp:Label ID="lblSystem" runat="server" Text="System"  class="control-label col-md-5" for="email3"></asp:Label>
                                         <div class="col-md-7">
                                
                                                <asp:TextBox ID="txtSystem" runat="server"></asp:TextBox>
                                         </div></div></div>
                                                <div class="col-md-6">                                              
                                      <div class="form-group">
                   <asp:Label ID="SubSystem" runat="server" Text="SubSystem"  class="control-label col-md-5" for="email3"></asp:Label>
                                                      <div class="col-md-7">
                                                <asp:TextBox ID="txtsubsystem" runat="server"></asp:TextBox>
                                       </div></div></div>
                                             <div class="col-md-6">                                              
                                      <div class="form-group">
                   <asp:Label ID="blbMiscManpowerTracking" runat="server" Text="Misc Manpower Tracking"  class="control-label col-md-5" for="email3"></asp:Label>
                                                      <div class="col-md-7">
                                  
                                                <asp:TextBox ID="txtManPower" runat="server"></asp:TextBox>
                               </div>
                                             </div>
                                                    </div>
                                             </div>
                                    </div>
                                </div>
                  <%--  Man Hours Related Captions --%>
                      <div class="accordion-container"> <a href="#" class="accordion-toggle" >Man Hours Related Captions 
                              <span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>
                              
                             <div class="accordion-content"> 
                                      <div class="col-md-12 Span-One">
                                    <div class="col-md-6">
                                      <div class="form-group">
                   <asp:Label ID="lblOtherCost1" runat="server" Text="Other Cost1"  class="control-label col-md-5" for="email3"></asp:Label>
                                         <div class="col-md-7">
                                   
                                    
                                                <asp:TextBox ID="txtOtherCost1" runat="server"></asp:TextBox>
                                          </div></div></div>
                                             <div class="col-md-6">
                                      <div class="form-group">
                   <asp:Label ID="lblOtherCost2" runat="server" Text="Other Cost2 "  class="control-label col-md-5" for="email3"></asp:Label>
                                         <div class="col-md-7">
                                 
                                                <asp:TextBox ID="txtOtherCost2" runat="server"></asp:TextBox>
                       </div></div></div>
                                             <div class="col-md-6">
                                      <div class="form-group">
                   <asp:Label ID="lblOtherCost3" runat="server" Text="Other Cost3"  class="control-label col-md-5" for="email3"></asp:Label>
                                         <div class="col-md-7">
                                 
                                                <asp:TextBox ID="txtOtherCost3" runat="server"></asp:TextBox>
                                           </div></div></div>

                                         
                                      <div class="col-md-6">
                                      <div class="form-group">
                   <asp:Label ID="lblPaymentCurrency" runat="server" Text="Payment Currency"  class="control-label col-md-5" for="email3"></asp:Label>
                                         <div class="col-md-7">
                                           
                                                <asp:TextBox ID="txtPaymentCurrency" runat="server"></asp:TextBox>
                                          </div></div></div>
                                            <div class="col-md-6">
                                      <div class="form-group">
                   <asp:Label ID="lblLunchBreakMinutes" runat="server" Text="Lunch Break Minutes"  class="control-label col-md-5" for="email3"></asp:Label>
                                         <div class="col-md-7">
                                          
                                                <asp:TextBox ID="txtLunchBreakMinutes" runat="server"></asp:TextBox>
                                         </div>
                                          </div>
                                                </div>
                                          </div>
                                 </div>
                                </div>
                   <%-- Hierarchy Captions --%>
                                     <div class="accordion-container"> <a href="#" class="accordion-toggle" >Hierarchy Captions 
                              <span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>
                              
                             <div class="accordion-content"> 
                                      <div class="col-md-12 Span-One">
                                    <div class="col-md-6">
                                      <div class="form-group">
                   <asp:Label ID="lblLevel1" runat="server" Text="Level 1"  class="control-label col-md-5" for="email3"></asp:Label>
                                         <div class="col-md-7">
                                       
                                         
                                                <asp:TextBox ID="txtLevel1" runat="server"></asp:TextBox>
                                          </div></div></div>
                                           <div class="col-md-6">
                                      <div class="form-group">
                   <asp:Label ID="Label2" runat="server" Text="Level 2"  class="control-label col-md-5" for="email3"></asp:Label>
                                         <div class="col-md-7">
                                                <asp:TextBox ID="txtLevel2" runat="server"></asp:TextBox>
                                       </div>
                                          </div></div>
                                                <div class="col-md-6">
                                      <div class="form-group">
                   <asp:Label ID="Label3" runat="server" Text="Level 3"  class="control-label col-md-5" for="email3"></asp:Label>
                                         <div class="col-md-7">
                                                <asp:TextBox ID="txtLevel3" runat="server"></asp:TextBox>
                                         </div></div>
                                </div>
                                          </div></div></div>
                 <%--   Client Related Captions--%>
                                      <div class="accordion-container"> <a href="#" class="accordion-toggle" >Client Related Captions
                              <span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>
                              
                             <div class="accordion-content"> 
                                      <div class="col-md-12 Span-One">
                                    <div class="col-md-6">
                                      <div class="form-group">
                   <asp:Label ID="lblClient1" runat="server" Text="Client 1 "  class="control-label col-md-5" for="email3"></asp:Label>
                                         <div class="col-md-7">
                                    
                                           
                                                <asp:TextBox ID="txtClient1" runat="server"></asp:TextBox>
                      </div></div></div>
                                         <div class="col-md-6">
                                      <div class="form-group">
                   <asp:Label ID="lblClient2" runat="server" Text="Client 2"  class="control-label col-md-5" for="email3"></asp:Label>
                                         <div class="col-md-7">
                                                <asp:TextBox ID="txtClient2" runat="server"></asp:TextBox>
                                     </div></div></div>
                                           <div class="col-md-6">
                                      <div class="form-group">
                   <asp:Label ID="lblThirdParty" runat="server" Text="Third Party"  class="control-label col-md-5" for="email3"></asp:Label>
                                         <div class="col-md-7">
                                            
                                                <asp:TextBox ID="txtThirdParty" runat="server"></asp:TextBox>
                   
                                          </div>
                                          </div>
                                </div>
                                          </div>
                                        </div>
                                          </div>


                </telerik:RadPageView>

            </telerik:RadMultiPage>
            <div id="modal_dialog" style="display: none; width: 1000px!important; height: 1000px!important; overflow: hidden; overflow-x: hidden;">

                <iframe src="AddNewProject.aspx" style="width: 1000px; height: 500px;"></iframe>

            </div>
    
        </div>
     
    </div>
    
 </asp:Content>
