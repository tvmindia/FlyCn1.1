<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="ManageProject.aspx.cs" Inherits="FlyCn.ProjectParameters.ManageProject" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik"%>
<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <script src="../Scripts/jquery-1.8.2.min.js"></script>
    <script src="../Scripts/jquery-ui-1.8.24.js"></script>
    <link href="../Content/themes/base/jquery-ui.css" rel="stylesheet" />
<script type="text/javascript">
    //$("[id*=btnModalPopup]").live("click", function () {
    function PopUp()
    {
       
    }
</script>
    <style type="text/css">
        .ui-dialog-title {
 padding-left:15em;
 color:white;
}

.ui-dialog-titlebar {
    background:transparent;
    border:none;
    
}

.ui-dialog .ui-dialog-titlebar-close {
    right:0;
}
.ui-dialog{
box-shadow: 0px 2px 7px #292929;
-moz-box-shadow: 0px 2px 7px #292929;
		-webkit-box-shadow: 0px 2px 7px #292929;
		border-radius:15px;
		-moz-border-radius:15px;
		-webkit-border-radius:15px;
		background: #f2f2f2;
		z-index:50;
       /*background:transparent;*/
        /*background: rgba(34,34,34,0.75);*/
 
   
  background: rgba(36,85,99,.9); 
       
       	border:1px solid #fff;


}
.headings
{
   font-family:'segoe UI' , Tahoma, Geneva, Verdana, sans-serif;  
   font-size:15px;
   font-style:normal;
   color:#009933;
}
  td.myclass
{
  text-align:left;
 
  width:100px;
 
}
   td.size
{
  text-align:left;
 
  width:200px;
 
}
   

    </style>
    <script  type="text/javascript">
     
        function validate() {
            //try{

            debugger;
            var ProjectNo = document.getElementById("<%=txtProjNo.ClientID %>").value;
            var ProjectName = document.getElementById("<%=txtProjName.ClientID %>").value;
            var ProjectLocation = document.getElementById("<%=txtLocation.ClientID %>").value;
            var ProjectManager = document.getElementById("<%=txtManager.ClientID %>").value; 

            if (ProjectNo == "" || ProjectName == "" || ProjectLocation == "" || ProjectManager == "") {

                document.getElementById("<%=lblerror.ClientID %>").innerHTML = "Please Fill all the Mandatory fields";
                return false;

            }
            else {
                document.getElementById("<%=lblerror.ClientID %>").innerHTML = "";
                return true;
            }

        }
</script>
   
      <script type="text/javascript">
 
function OnClientTabSelecting(sender, eventArgs)
{
   var tab = eventArgs.get_tab();
                  if (tab.get_value() == '2') {
                  
    eventArgs.set_cancel(true);
     OpenNewProjectWizard();
}

}   

function OpenNewProjectWizard()
{
try {
                    $("#modal_dialog").dialog({
                    
                        title: "Project Wizard",
                        width: 780,
                       height:700,
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
    
    

       <p>
        Manage Project</p>
     
     <hr />

        <div class="inputMainContainer">
        <div class="innerDiv">
        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" Width="300px" OnClientTabSelecting="OnClientTabSelecting" OnClientTabSelected="onClientTabSelected"
             CausesValidation="false"   SelectedIndex="0" Skin="Silk" >
            
            <Tabs>
                <telerik:RadTab Text="View" PageViewID="rpList" Value="1" Width="150px" runat="server" ImageUrl="~/Images/Icons/ListIcon.png" Selected="True" ></telerik:RadTab>
                 <telerik:RadTab Text="New" PageViewID="EditData" Value="2" Width="150px" runat="server" ImageUrl="~/Images/Icons/NewIcon.png"  ></telerik:RadTab>
           
                 </Tabs>
        </telerik:RadTabStrip>
       
 
  <telerik:RadMultiPage ID="RadMultiPage1" runat="server" Width="100%" SelectedIndex="0" CssClass="outerMultiPage">
       
            <telerik:RadPageView ID="rpList" runat="server">
               
                <div id="divList" style="width:100%">
                    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
                    </asp:ScriptManager>

                    <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" CellSpacing="0" GridLines="None" OnItemCommand="RadGrid1_ItemCommand" OnNeedDataSource="RadGrid1_NeedDataSource1" OnPreRender="RadGrid1_PreRender" PageSize="10" Skin="Silk" Width="984px"><mastertableview autogeneratecolumns="False" datakeynames="ProjectNo"><Columns><telerik:GridBoundColumn DataField="ProjectNo" HeaderText="Project No" UniqueName="ProjectNo"></telerik:GridBoundColumn><telerik:GridBoundColumn DataField="ProjectName" HeaderText="Project Name" UniqueName="ProjectName"></telerik:GridBoundColumn><telerik:GridBoundColumn DataField="ProjectLocation" HeaderText="Location" UniqueName="ProjectLocation"></telerik:GridBoundColumn><telerik:GridBoundColumn DataField="Active" HeaderText="Active" UniqueName="Active"></telerik:GridBoundColumn><telerik:GridBoundColumn DataField="CompName" HeaderText="Company Name" UniqueName="CompName"></telerik:GridBoundColumn><telerik:GridButtonColumn ButtonType="ImageButton" CommandName="EditData" ImageUrl="~/Images/Icons/Pencil-01.png" Text="Edit" UniqueName="EditData"></telerik:GridButtonColumn>
                    </Columns>
                    </mastertableview>
                    </telerik:RadGrid>
                </div>
                    </telerik:RadPageView>
          
       <telerik:RadPageView ID="EditData" runat="server">
           <asp:Label ID="lblerror" runat="server" Text="" ForeColor="Red"></asp:Label>
           
         <uc1:ToolBar runat="server" ID="ToolBar" />

           <table>
               <tr>
                   <td >&nbsp&nbsp</td><td>
                       <div>
                       <table>
               <tr>
                   <td class="size">Project No </td>
                   <td class="size">
                       <asp:TextBox ID="txtProjNo" runat="server"></asp:TextBox>
                         <span id="span2" runat="server" style="color: red; font-size: 15px; font-weight: 500;
font-family: Trebuchet MS;">*</span>
                   </td>
               </tr>
               <tr>
                   <td>Project Name </td>
                   <td>
                       <asp:TextBox ID="txtProjName" runat="server"></asp:TextBox>
                         <span id="span1" runat="server" style="color: red; font-size: 15px; font-weight: 500;
font-family: Trebuchet MS;">*</span>
                   </td>
                   <td  class="myclass">&nbsp;&nbsp;</td>
                   <td class="size">Project Location </td>
                   <td class="size">
                       <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox>
                         <span id="span3" runat="server" style="color: red; font-size: 15px; font-weight: 500;
font-family: Trebuchet MS;">*</span>
                   </td>
               </tr>
               <tr>
                   <td>Project Manager </td>
                   <td>
                       <asp:TextBox ID="txtManager" runat="server"></asp:TextBox>
                         <span id="span4" runat="server" style="color: red; font-size: 15px; font-weight: 500;
font-family: Trebuchet MS;">*</span>
                   </td>
                <td>&nbsp;&nbsp;</td>
                   <td>Base Project </td>
                   <td>
                       <asp:TextBox ID="txtBaseProject" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td  >Active </td>
                   <td>
                       <asp:CheckBox ID="CheckboxActive" runat="server" AutoPostBack="true" />
                   </td>
               </tr>
                           
                           </table>
</div>
 <br />    
                <hr />  
                       <br />     
                    <div>   <table>
               <tr>
                   <td class="headings">Company Details </td>
               </tr>
               <tr>
                   <td class="size">Company Name </td>
                   <td class="size">
                       <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
                   </td>
                 <td class="myclass">&nbsp;&nbsp;</td>
                   <td class="size">Address1 </td>
                   <td class="size">
                       <asp:TextBox ID="txtAddress1" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>Address2 </td>
                   <td>
                       <asp:TextBox ID="txtAddress2" runat="server"></asp:TextBox>
                   </td>
                <td>&nbsp;&nbsp;</td>
                   <td>Telephone </td>
                   <td>
                       <asp:TextBox ID="txtTelephone" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>Fax </td>
                   <td>
                       <asp:TextBox ID="txtFax" runat="server"></asp:TextBox>
                   </td>
              <td>&nbsp;&nbsp;</td>
                   <td>Email </td>
                   <td>
                       <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>Website </td>
                   <td>
                       <asp:TextBox ID="txtWebsite" runat="server"></asp:TextBox>
                   </td>
              <td>&nbsp;&nbsp;</td>
                   <td>
                       <asp:Label ID="lblComapnyLogo" runat="server" Text="Company Logo"></asp:Label>
                   </td>
                   <td>
                       <asp:FileUpload ID="fuLogo" runat="server" Height="22px" Width="175px" />
                       <asp:ImageButton ID="imbCompany" runat="server" Height="20px" Width="20px" />
                       <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
                   </td>
                   <td>&nbsp;</td>
               </tr>
                               </table>
                        </div>
                        <br />    
                       <hr />
                       <br />
                     <div>  <table>
               <tr>
                   <td class="headings">Client Details </td>
               </tr>
               <tr>
                   <td class="size">Client Name </td>
                   <td class="size">
                       <asp:TextBox ID="txtClientName" runat="server"></asp:TextBox>
                   </td>
              <td class="myclass">&nbsp;&nbsp;</td>
                   <td class="size">Contract Details </td>
                   <td class="size">
                       <asp:TextBox ID="txtContractDetails" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>Telephone </td>
                   <td>
                       <asp:TextBox ID="txtClientTelephone" runat="server"></asp:TextBox>
                   </td>
             <td>&nbsp;&nbsp;</td>
                   <td>Fax </td>
                   <td>
                       <asp:TextBox ID="txtClientFax" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>Email </td>
                   <td>
                       <asp:TextBox ID="txtClientEmail" runat="server"></asp:TextBox>
                   </td>
               <td>&nbsp;&nbsp;</td>
                   <td>Website </td>
                   <td>
                       <asp:TextBox ID="txtClientWebsite" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>
                       <asp:Label ID="lblClientLogo" runat="server" Text="Client Logo"></asp:Label>
                   </td>
                   <td>
                       <asp:FileUpload ID="fuClientLogo" runat="server" Height="22px" Width="175px" />
                       <asp:ImageButton ID="imbClientLogo" runat="server" Height="20px" Width="20px" />
                        <asp:Label ID="lblmsg1" runat="server" Text=""></asp:Label>
                   </td>
               </tr>
                         </table>
                     </div> 
                        <br />    
                       <hr />
                       <br />
                    <div>   <table>   
               <tr>
                   <td class="headings">Admin Details </td>
               </tr>
               <tr>
                   <td class="size">Implementation Engineer </td>
                   <td class="size">
                       <asp:TextBox ID="txtImplementation" runat="server"></asp:TextBox>
                   </td>
              <td class="myclass">&nbsp;&nbsp;</td>
                   <td  class="size">Project Admin </td>
                   <td class="size">
                       <asp:TextBox ID="txtProjectAdmin" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>Punch List From Company </td>
                   <td>
                       <asp:TextBox ID="txtPunchList" runat="server"></asp:TextBox>
                   </td>
               <td>&nbsp;&nbsp;</td>
                   <td>Punch List From Person </td>
                   <td>
                       <asp:TextBox ID="txtPunchListPerson" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>Punch List To Company </td>
                   <td>
                       <asp:TextBox ID="txtPunchListToCompany" runat="server"></asp:TextBox>
                   </td>
              <td>&nbsp;&nbsp;</td>
                   <td>Punch List TO Person </td>
                   <td>
                       <asp:TextBox ID="txtPunchListToPerson" runat="server"></asp:TextBox>
                   </td>
               </tr>
                        </table>
                        </div>
                        <br />    
                 <hr />
                       <br />
                       <div>
                           <table>
               <tr>
                   <td class="headings">Caption For Project Fields </td>
               </tr>
               <tr>
                   <td class="size">Plant</td>
                   <td class="size">
                       <asp:TextBox ID="txtPlant" runat="server"></asp:TextBox>
                   </td>
              <td class="myclass">&nbsp;&nbsp;</td>
                   <td class="size">Area </td>
                   <td  class="size">
                       <asp:TextBox ID="txtArea" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>Location </td>
                   <td>
                       <asp:TextBox ID="txtCaptionLocation" runat="server"></asp:TextBox>
                   </td>
              <td>&nbsp;&nbsp;</td>
                   <td>System </td>
                   <td>
                       <asp:TextBox ID="txtSystem" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>SubSystem </td>
                   <td>
                       <asp:TextBox ID="txtsubsystem" runat="server"></asp:TextBox>
                   </td>
              <td>&nbsp;&nbsp;</td>
                   <td>Misc Manpower Tracking </td>
                   <td>
                       <asp:TextBox ID="txtManPower" runat="server"></asp:TextBox>
                   </td>
               </tr>
                               </table>
                       </div>   
                        <br />    
                       <hr />
                       <br />
                       <div>
                           <table>
               <tr>
                   <td class="headings">Man Hours Related Captions </td>
               </tr>
               <tr>
                   <td class="size">Other Cost1 </td>
                   <td class="size">
                       <asp:TextBox ID="txtOtherCost1" runat="server"></asp:TextBox>
                   </td>
              <td class="myclass">&nbsp;&nbsp;</td>
                   <td class="size">Other Cost2 </td>
                   <td class="size">
                       <asp:TextBox ID="txtOtherCost2" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>Other Cost3 </td>
                   <td>
                       <asp:TextBox ID="txtOtherCost3" runat="server"></asp:TextBox>
                   </td>
               <td>&nbsp;&nbsp;</td>
                   <td>Payment Settings </td>
               </tr>
               <tr>
                   <td >Payment Currency </td>
                   <td>
                       <asp:TextBox ID="txtPaymentCurrency" runat="server"></asp:TextBox>
                   </td>
              <td>&nbsp;&nbsp;</td>
                   <td>Lunch Break Minutes </td>
                   <td>
                       <asp:TextBox ID="txtLunchBreakMinutes" runat="server"></asp:TextBox>
                   </td>
               </tr>
                               </table>
                       </div>
                        <br />    
                       <hr />
                       <br />
                       <div>
                           <table>
               <tr>
                   <td class="headings">Hierarchy Captions </td>
               </tr>
               <tr>
                   <td class="size">Level 1 </td>
                   <td class="size">
                       <asp:TextBox ID="txtLevel1" runat="server"></asp:TextBox>
                   </td>
               <td class="myclass">&nbsp;&nbsp;</td>
                   <td class="size">Level 2 </td>
                   <td class="size">
                       <asp:TextBox ID="txtLevel2" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>Level 3 </td>
                   <td>
                       <asp:TextBox ID="txtLevel3" runat="server"></asp:TextBox>
                   </td>
               </tr>
                               </table>
                       </div>
                        <br />    
                       <hr />
                       <br />
                      <div>
                          <table>
               <tr>
                   <td class="headings">Client Related Captions </td>
               </tr>
               <tr>
                   <td class="size">Client 1 </td>
                   <td class="size">
                       <asp:TextBox ID="txtClient1" runat="server"></asp:TextBox>
                   </td>
              <td class="myclass">&nbsp;&nbsp;</td>
                   <td class="size">Client 2 </td>
                   <td class="size">
                       <asp:TextBox ID="txtClient2" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>Third Party </td>
                   <td>
                       <asp:TextBox ID="txtThirdParty" runat="server"></asp:TextBox>
                   </td>
               </tr>
                              </table>
                      </div>
                  </td>        
               </tr>
           </table>
       

         </telerik:RadPageView>
    
            </telerik:RadMultiPage>
            <div id="modal_dialog"  style="display: none; width:1000px!important; height:700px!important; border-radius:30px; overflow:hidden; overflow-x:hidden; 
">
   
                   <iframe src="AddNewProject.aspx" style="width:1300px;  height:700px;">

    </iframe>
                    
</div>
            </div>
            </div>
</asp:Content>
