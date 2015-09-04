<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="ManageProject.aspx.cs" Inherits="FlyCn.ProjectParameters.ManageProject" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik"%>
<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <script type="text/javascript">
          function onClientTabSelected(sender, args) {
              debugger;
              var tab = args.get_tab();
              if (tab.get_text() == "View") {

                  var tabStrip = $find("<%= RadTabStrip1.ClientID %>");
                  var tab = tabStrip.findTabByText("View");
                  tab.select();
                  var tab1 = tabStrip.findTabByText("Edit");
                  tab1.set_text("New");
                  $('input[type=text]').each(function () {
                      $(this).val('');
                  });
                  $('textarea').empty();

                  $('input[type=text]').each(function () {
                      $(this).val('');
                  });
                  $('textarea').empty();
              }

              function onClientTabSelected(sender, args) {
                  var tab = args.get_tab();
                  if (tab.get_value() == '2') {
                      //new clicked 
                      $('input[type=text]').each(function () {
                          $(this).val('');
                      });
                      $('textarea').empty();

                      debugger;
                      try
                      {
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
                  }

              }
          }
         </script>
       <p>
        Manage Project</p>
     
     <hr />

        <div class="inputMainContainer">
        <div class="innerDiv">
        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" Width="300px" OnClientTabSelected="onClientTabSelected"
             CausesValidation="false"   SelectedIndex="0" Skin="Silk" >
            
            <Tabs>
                <telerik:RadTab Text="View" PageViewID="rpList" Value="1" Width="150px" runat="server" ImageUrl="~/Images/Icons/ListIcon.png" Selected="True" ></telerik:RadTab>
                 <telerik:RadTab Text="New" PageViewID="EditData" Value="2" Width="150px" runat="server" ImageUrl="~/Images/Icons/NewIcon.png"  ></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        
            <table style="width:100%">
    <tr>
        <td>
            &nbsp
        </td>
        <td>

        <telerik:RadMultiPage ID="RadMultiPage1" runat="server" Width="100%" SelectedIndex="0" CssClass="outerMultiPage">
            <telerik:RadPageView ID="rpList" runat="server">
               
    <div id="divList" style="width:100%">  
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
            </asp:ScriptManager>    
             <telerik:RadGrid ID="RadGrid1" runat="server"  CellSpacing="0"
    GridLines="None" OnNeedDataSource="RadGrid1_NeedDataSource1" OnItemCommand="RadGrid1_ItemCommand" AllowPaging="true" 
    PageSize="10" Width="984px" Skin="Silk">
                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="ProjectNo">
    <Columns>
     <telerik:GridBoundColumn HeaderText="Project No" DataField="ProjectNo" UniqueName="ProjectNo"></telerik:GridBoundColumn> 
     <telerik:GridBoundColumn HeaderText="Project Name" DataField="ProjectName" UniqueName="ProjectName"></telerik:GridBoundColumn>
     <telerik:GridBoundColumn HeaderText="Location" DataField="ProjectLocation" UniqueName="ProjectLocation"></telerik:GridBoundColumn> 
     <telerik:GridBoundColumn HeaderText="Active" DataField="Active" UniqueName="Active"></telerik:GridBoundColumn> 
     <telerik:GridBoundColumn HeaderText="Company Name" DataField="CompName" UniqueName="CompName"></telerik:GridBoundColumn> 
     <telerik:GridButtonColumn CommandName="EditData" Text="Edit" UniqueName="EditData" ButtonType="ImageButton" ImageUrl="~/Images/Icons/Pencil-01.png"></telerik:GridButtonColumn>     
    </Columns>
  </MasterTableView>            
             </telerik:RadGrid>
      
    
        </div>
                    </telerik:RadPageView>
            </telerik:RadMultiPage>
            </td></tr>
            </table>
            </div>
            </div>
       <telerik:RadPageView ID="EditData" runat="server">
  
         <uc1:ToolBar runat="server" ID="ToolBar" />
       <table>
           <tr><td>
               Project No
               </td>
               <td>
                   <asp:TextBox ID="txtProjNo" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr><td>
               Project Name
               </td><td>
                   <asp:TextBox ID="txtProjName" runat="server"></asp:TextBox>
                    </td></tr>
           <tr><td>
               Project Location
               </td><td>
                   <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox>
                    </td></tr>
           <tr><td>
               Project Manager
               </td><td>
                   <asp:TextBox ID="txtManager" runat="server"></asp:TextBox>
                    </td></tr>
           <tr><td>
               Base Project
               </td>
               <td>
                   <asp:TextBox ID="txtBaseProject" runat="server"></asp:TextBox></td>
           </tr>
           <tr>
               <td>
                   Active
               </td>
               <td>

               </td>
           </tr>
     <tr><td>
         Company Details
         </td></tr>
           <tr><td>
               Company Name
               </td><td>
                   <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
                    </td></tr>
           <tr>
               <td>
                   Address1
               </td>
               <td>
                   <asp:TextBox ID="txtAddress1" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>
                   Address2
               </td>
               <td>
                   <asp:TextBox ID="txtAddress2" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>
                   Telephone
               </td>
               <td>
                   <asp:TextBox ID="txtTelephone" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
            <td>
                Fax
            </td>
               <td>
                   <asp:TextBox ID="txtFax" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>
                   Email
               </td>
               <td>
                   <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>
                   Website
               </td>
               <td>
                   <asp:TextBox ID="txtWebsite" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>
                   Company Logo
               </td>
               <td>
                   <asp:FileUpload ID="fuLogo" runat="server" />
               </td>
           </tr>
           <tr>
               <td>
                   Client Details
               </td>
           </tr>
           <tr>
               <td>
                   Client Name
               </td>
               <td>
                   <asp:TextBox ID="txtClientName" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>
                   Contract Details
               </td>
               <td>
                   <asp:TextBox ID="txtContractDetails" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>
                   Telephone
               </td>
               <td>
                   <asp:TextBox ID="txtClientTelephone" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>
                   Fax
               </td>
               <td>
                   <asp:TextBox ID="txtClientFax" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>
                   Email
               </td>
               <td>
                   <asp:TextBox ID="txtClientEmail" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>
                   Website
               </td>
               <td>
                   <asp:TextBox ID="txtClientWebsite" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>
                   Client Logo
               </td>
               <td>
                   <asp:FileUpload ID="fuClientLogo" runat="server" />
               </td>
           </tr>
           <tr>
               <td>
                   Admin Details
               </td>
           </tr>
           <tr>
               <td>
                   Implementation Engineer
               </td>
               <td>
                   <asp:TextBox ID="txtImplementation" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>
                   Project Admin
               </td>
               <td>
                   <asp:TextBox ID="txtProjectAdmin" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>
                   Punch List From Company
               </td>
               <td>
                   <asp:TextBox ID="txtPunchList" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>
                   Punch List From Person
               </td>
               <td>
                   <asp:TextBox ID="txtPunchListPerson" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>
                   Punch List To Company
               </td>
               <td>
                   <asp:TextBox ID="txtPunchListToCompany" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>
                   Punch List TO Person
               </td>
               <td>
                   <asp:TextBox ID="txtPunchListToPerson" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>
                   Caption For Project Fields
               </td>
             
           </tr>            
           <tr>
               <td>Plant</td>
           <td>
               <asp:TextBox ID="txtPlant" runat="server"></asp:TextBox>
           </td></tr>
           <tr>
               <td>
                   Area
               </td>
               <td>
                   <asp:TextBox ID="txtArea" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>
                   Location
               </td>
               <td>
                   <asp:TextBox ID="txtCaptionLocation" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>
                   System
               </td>
               <td>
                   <asp:TextBox ID="txtSystem" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>
                   SubSystem
               </td>
               <td>
                   <asp:TextBox ID="txtsubsystem" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>
                   Misc Manpower Tracking
               </td>
               <td>
                   <asp:TextBox ID="txtManPower" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>
                   Man Hours Related Captions 
               </td>

           </tr>
           <tr>
               <td>
                   Other Cost1
               </td>
               <td>
                   <asp:TextBox ID="txtOtherCost1" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>
                   Other Cost2
               </td>
               <td>
                   <asp:TextBox ID="txtOtherCost2" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>
                   Other Cost3
               </td>
               <td>
                   <asp:TextBox ID="txtOtherCost3" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>
                   Payment Settings
               </td>
           </tr>
           <tr>
               <td>
                   Payment Currency
               </td>
               <td>
                   <asp:TextBox ID="txtPaymentCurrency" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>
                   Lunch Break Minutes
               </td>
               <td>
                   <asp:TextBox ID="txtLunchBreakMinutes" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>
                   Hierarchy Captions
               </td>
              
           </tr>
           <tr>
               <td>
                   Level 1
               </td>
               <td>
                   <asp:TextBox ID="txtLevel1" runat="server"></asp:TextBox>
               </td>
           </tr>
                   <tr>
               <td>
                   Level 2
               </td>
                       <td>
                           <asp:TextBox ID="txtLevel2" runat="server"></asp:TextBox>
                       </td>
           </tr>
                   <tr>
               <td>
                   Level 3
               </td>
                       <td>
                           <asp:TextBox ID="txtLevel3" runat="server"></asp:TextBox>
                       </td>
           </tr>
           <tr>
               <td>
                   Client Related Captions
               </td>
               
           </tr>
           <tr>
               <td>
                   Client 1
               </td>
               <td>
                   <asp:TextBox ID="txtClient1" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>
                   Client 2
               </td>
               <td>
                   <asp:TextBox ID="txtClient2" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>
                   Third Party
               </td>
               <td>
                   <asp:TextBox ID="txtThirdParty" runat="server"></asp:TextBox>
               </td>
           </tr>
       </table>
       

           </telerik:RadPageView>
</asp:Content>
