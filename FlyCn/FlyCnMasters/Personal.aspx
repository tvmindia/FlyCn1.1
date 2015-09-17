<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="Personal.aspx.cs" Inherits="FlyCn.Personal" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     
   
 
   
    <script type="text/javascript">
        function validate() {
            var Code = document.getElementById('<%=txtCode.ClientID %>').value;
             var Name = document.getElementById('<%=txtName.ClientID %>').value;
            var Nationality = document.getElementById('<%=txtNationality.ClientID %>').value;
            var Company = document.getElementById('<%=RadComboCompany.ClientID %>').value;
            if (Code == "" || Name == "" || Nationality == "" || Company == "") {

                document.getElementById("<%=lblerror.ClientID %>").innerHTML = "Please Fill all the Mandatory fields";
                return false;

            }
        
            else
            {
                document.getElementById("<%=lblerror.ClientID %>").innerHTML = "";
                return true;
            }
        }
</script>

      <script type="text/javascript">
          function onClientTabSelected(sender, args) {
              //   debugger;
              var tab = args.get_tab();
         
          
      
              if (tab.get_value() == '2') {
            
                  try {

                      $('input[type=text]').each(function () {
                          $(this).val('');
                      });
                      $('textarea').empty();
                      <%=ToolBar.ClientID %>_SetAddVisible(false);
                      <%=ToolBar.ClientID %>_SetSaveVisible(true);
                      <%=ToolBar.ClientID %>_SetUpdateVisible(false);
                      <%=ToolBar.ClientID %>_SetDeleteVisible(false);

                document.getElementById('<%=txtCode.ClientID %>').disabled = false;
                      //var divs = document.getElementById('ContentIframe');
                      //alert(divs);
                      document.getElementById('<%=ContentIframe.ClientID%>').style.display = "none";

                      document.getElementById('<%=lblQualificationframe.ClientID%>').style.display = "none";

                   
                  }
                  catch (x)
                  {
                    
                      alert(x.message);
                  }

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
              if (btn.get_value() == 'Save') {

                  args.set_cancel(!validate());
              }
              if (btn.get_value() == 'Update') {

                  args.set_cancel(!validate());
              }

        }
  </script>
 
    <style>
      table
    {
    	
    	
    }
    table tbody
    {
    	
    }
  .tabletd
    {
    	width:550px;
    }
   .tabletbody
    {
    	width:900px;
    }
  
</style>

    
   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <div class="inputMainContainer">
        <div class="innerDiv">

        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" Width="300px" OnClientTabSelected="onClientTabSelected"
             CausesValidation="false"   SelectedIndex="0" Skin="Silk"  >
            <Tabs>
                <telerik:RadTab Text="View" PageViewID="rpList" Value="1" Width="150px" runat="server" ImageUrl="~/Images/Icons/ListIcon.png" Selected="True" ></telerik:RadTab>
                 <telerik:RadTab Text="New" PageViewID="rpAddEdit" Value="2" Width="150px" runat="server" ImageUrl="~/Images/Icons/NewIcon.png"  ></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>

<table style="width:100%">
    <tr>
        <td>
            &nbsp
        </td>
        <td>
<div>
    <telerik:RadMultiPage ID="RadMultiPage1" runat="server" Width="100%" SelectedIndex="0" CssClass="outerMultiPage">
        <telerik:RadPageView ID="rpList" runat="server">
            <div id="divList">


                <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
                </asp:ScriptManager>

                <telerik:RadGrid ID="PersonnelGrid" runat="server" OnNeedDataSource="PersonnelGrid_NeedDataSource" OnItemCommand="PersonnelGrid_ItemCommand"
                    Skin="Silk" CssClass="outerMultiPage"
                    OnPreRender="PersonnelGrid_PreRender">
                    <MasterTableView DataKeyNames="Code">

                        <Columns>
                            <telerik:GridButtonColumn CommandName="EditData" ButtonType="ImageButton" ImageUrl="~/Images/Icons/Pencil-01.png" Text="Edit" UniqueName="EditData">
                            </telerik:GridButtonColumn>
                            <telerik:GridButtonColumn CommandName="Delete" ButtonType="ImageButton" Text="Delete" UniqueName="Delete" ConfirmDialogType="RadWindow" ConfirmText="Are you sure">
                            </telerik:GridButtonColumn>

                        </Columns>
                    </MasterTableView>

                </telerik:RadGrid>


            </div>

        </telerik:RadPageView>
        <telerik:RadPageView ID="rpAddEdit" runat="server">
           <asp:Label ID="lblerror" runat="server" Text="" ForeColor="Red"></asp:Label>

            <uc1:ToolBar runat="server" ID="ToolBar" />


            <div id="divGeneral" style="width: 100%;">
                <div>
                    <asp:Label ID="lblGenaral" runat="server" Text="Genaral" ForeColor="Brown"></asp:Label>
                </div>
                <hr />
                <table style="width: 100%;">
                    <tr>
                        <td class="tabletbody">
                            <asp:Label ID="lblCode" runat="server" Text="Code"></asp:Label>
                        </td>
                        <td class="tabletbody">
                            <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
                             <span id="span2" runat="server" style="color: red; font-size: 15px; font-weight: 500;
font-family: Trebuchet MS;">*</span>
                            <asp:RequiredFieldValidator ID="rfv" runat="server" ErrorMessage="Enter code."
                                Display="Dynamic" SetFocusOnError="true"
                                ForeColor="Red"
                                ValidationGroup="Group"
                                ControlToValidate="txtCode">
                            </asp:RequiredFieldValidator>

                        </td>
                        <td class="tabletbody">
                            <asp:Label ID="lblStartDate" runat="server" Text="Start Date"></asp:Label>
                        </td>
                        <td class="tabletbody">
                            <telerik:RadDatePicker ID="RadStartDate" runat="server"
                                Width="170px" TabIndex="2" AutoPostBack="false">
                                <DateInput DateFormat="dd/MMM/yyyy" DisplayDateFormat="dd/MMM/yyyy" InvalidStyleDuration="100"
                                    runat="server">
                                </DateInput>
                                <Calendar runat="server">
                                </Calendar>
                            </telerik:RadDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td class="tabletbody">
                            <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                        </td>
                        <td class="tabletbody">
                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                             <span id="span1" runat="server" style="color: red; font-size: 15px; font-weight: 500;
font-family: Trebuchet MS;">*</span>
                        </td>
                        <td class="tabletbody">
                            <asp:Label ID="lblEndDate" runat="server" Text="End Date"></asp:Label>
                        </td>
                        <td class="tabletbody">
                            <telerik:RadDatePicker ID="RadEndDate" runat="server"
                                Width="170px" TabIndex="2" AutoPostBack="false" MinDate="<%# DateTime.Now.Date %>">
                                <DateInput DateFormat="dd/MMM/yyyy" DisplayDateFormat="dd/MMM/yyyy" InvalidStyleDuration="100"
                                    runat="server">
                                </DateInput>
                                <Calendar runat="server">
                                </Calendar>
                            </telerik:RadDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td class="tabletbody">
                            <asp:Label ID="lblNationality" runat="server" Text="Nationality"></asp:Label>
                        </td>
                        <td class="tabletbody">
                            <asp:TextBox ID="txtNationality" runat="server"></asp:TextBox>
                             <span id="span3" runat="server" style="color: red; font-size: 15px; font-weight: 500;
font-family: Trebuchet MS;">*</span>
                        </td>
                        <td class="tabletbody">&nbsp;</td>
                        <td class="tabletbody">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="tabletbody">
                            <asp:Label ID="lblPassportNo" runat="server" Text="Passport No"></asp:Label>
                        </td>
                        <td class="tabletbody">
                            <asp:TextBox ID="txtPassportNo" runat="server"></asp:TextBox>
                        </td>
                        <td class="tabletbody"></td>
                        <td class="tabletbody"></td>
                    </tr>
                    <tr>
                        <td class="tabletbody">
                            <asp:Label ID="lblRemarks" runat="server" Text="Remarks"></asp:Label>
                        </td>
                        <td class="tabletbody">
                            <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Width="170px"></asp:TextBox>
                        </td>
                        <td class="tabletbody">&nbsp;</td>
                        <td class="tabletbody">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="tabletbody">&nbsp;</td>
                        <td class="tabletbody">&nbsp;</td>
                        <td class="tabletbody">&nbsp;</td>
                        <td class="tabletbody">&nbsp;</td>
                    </tr>

                </table>
            </div>


            <div id="divCompanyDetails" style="width: 100%;">
                <div>
                    <asp:Label ID="lblCompanyDetails" runat="server" Text="Company Details" ForeColor="Brown"></asp:Label>
                </div>
                <hr />
                <table style="width: 100%;">

                    <tr>
                        <td class="tabletd">
                            <asp:Label ID="lblCompany" runat="server" Text="Company"></asp:Label>
                        </td>
                        <td class="tabletd">
                            <telerik:RadComboBox ID="RadComboCompany" runat="server" Width="170px"
                                EmptyMessage="Select a Company" EnableLoadOnDemand="True" ShowMoreResultsBox="true"
                                EnableVirtualScrolling="true" OnItemsRequested="RadComboCompany_ItemsRequested">
                            </telerik:RadComboBox>
                             <span id="span4" runat="server" style="color: red; font-size: 15px; font-weight: 500;
font-family: Trebuchet MS;">*</span>
                        </td>
                        <td class="tabletd">
                            <asp:Label ID="lblGenericPosition" runat="server" Text="Generic Position"></asp:Label>
                        </td>
                        <td class="tabletd">
                            <asp:TextBox ID="txtGenericPosition" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="tabletd">
                            <asp:Label ID="lblIsSubcontract" runat="server" Text="Is Subcontract"></asp:Label>
                        </td>
                        <td class="tabletd">
                            <telerik:RadComboBox
                                ID="RadcomboSubcontract"
                                runat="server" Width="170px">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Text="Yes" Value="1" />
                                    <telerik:RadComboBoxItem runat="server" Text="No" Value="0" />
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                        <td class="tabletd">
                            <asp:Label ID="lblContractPosition" runat="server" Text="Contract Position"></asp:Label>
                        </td>
                        <td class="tabletd">
                            <asp:TextBox ID="txtContractPosition" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="tabletd">
                            <asp:Label ID="lblEmpNo" runat="server" Text="Emp No"></asp:Label>
                        </td>
                        <td class="tabletd">
                            <asp:TextBox ID="txtEmpNo" runat="server"></asp:TextBox>
                        </td>
                        <td class="tabletd">
                            <asp:Label ID="lblHierarchyPosition" runat="server" Text="Hierarchy Position"></asp:Label>
                        </td>
                        <td class="tabletd">
                            <asp:TextBox ID="txtHierarchyPosition" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="tabletd">
                            <asp:Label ID="lblWorkHours" runat="server" Text="Work Hours"></asp:Label>
                        </td>
                        <td class="tabletd">
                            <asp:TextBox ID="txtWorkHours" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator
    ID="RegularExpressionValidator6"
    runat="server"
    ControlToValidate="txtWorkHours"
    ValidationExpression="([0-9])[0-9]*[.]?[0-9]*"
    ErrorMessage="Invalid Entry" ForeColor="Red"></asp:RegularExpressionValidator>
                        </td>
                        <td class="tabletd">
                            <asp:Label ID="lblCategory" runat="server" Text="Category"></asp:Label>
                        </td>
                        <td class="tabletd">
                            <asp:TextBox ID="txtCategory" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="tabletd">
                            <asp:Label ID="lblOTEligible" runat="server" Text="OT Eligible"></asp:Label>
                        </td>
                        <td class="tabletd">
                            <telerik:RadComboBox
                                ID="RadComboOTEligible"
                                runat="server" Width="170px">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Text="Yes" Value="1" />
                                    <telerik:RadComboBoxItem runat="server" Text="No" Value="0" />
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                        <td class="tabletd">
                            <asp:Label ID="lblDescipline" runat="server" Text="Descipline"></asp:Label>
                        </td>
                        <td class="tabletd">
                            <asp:TextBox ID="txtDescipline" runat="server"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td class="tabletd"></td>
                    </tr>
                </table>
            </div>



            <br />

            <div>
                <asp:Label ID="lblQualificationframe" runat="server" Text="Qualification" ForeColor="Brown" Style="display: none"></asp:Label>
            </div>
            <hr />

            <div id="framediv" runat="server" style="overflow: hidden;">

                <iframe id="ContentIframe"
                    name="PQualification" style="height: 300px; width: 100%; display: none; overflow: hidden;"
                    runat="server"></iframe>
            </div>

        </telerik:RadPageView>
        <%--<%--  onload="javascript: setSize();" ,onload="autoResize('ContentIframe');"--%>

    </telerik:RadMultiPage>
    </div>
        </td>
    </tr>
</table>
        
        </div>
   </div>
</asp:Content>

