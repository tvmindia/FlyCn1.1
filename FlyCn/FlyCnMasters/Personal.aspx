<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="Personal.aspx.cs" Inherits="FlyCn.Personal" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%--<script type="text/javascript">
        function onClientTabSelected(sender, args) {
            var tab = args.get_tab();
            if (tab.get_text() == "New") {
                document.getElementById('divGeneral').style.display = "";
                document.getElementById('divCompanyDetails').style.display = "";
                document.getElementById('divQualification').style.display = "none";
                document.getElementById('<%=Button1.ClientID %>').style.display = "none";
                document.getElementById('<%=Button2.ClientID %>').style.display = "";
                document.getElementById('<%=framediv.ClientID %>').style.display = "none";
                document.getElementById('<%=txtCode.ClientID %>').readOnly = false;
                // document.getElementsByTagName('input').style.display = "none";
                //$("input:text").val('');
                $('input[type=text]').each(function () {
                    $(this).val('');
                });
                $('textarea').empty();

            }
            else if (tab.get_text() == "View") {

                document.getElementById('divQualification').style.display = "";
                document.getElementById('divGeneral').style.display = "none";
                document.getElementById('divCompanyDetails').style.display = "none";
                document.getElementById('<%=Button2.ClientID %>').style.display = "none";
                document.getElementById('<%=Button1.ClientID %>').style.display = "none";

            }
            else if (tab.get_text() == "Edit") {

                document.getElementById('divGeneral').style.display = "";
                document.getElementById('divCompanyDetails').style.display = "";
                document.getElementById('divQualification').style.display = "none";
                document.getElementById('<%=Button1.ClientID %>').style.display = "";
                document.getElementById('<%=Button2.ClientID %>').style.display = "none";
            }

    }


        </script>--%>
    <%--<script>
     function onClientTabSelected(sender,args) {
                var tab = args.get_tab();
          if (tab.get_text() == "View") {
               <%--  var tabStrip = $find("<%= RadTabStrip1.ClientID %>");
                var tab = tabStrip.findTabByText('Edit');
                tab.Name = "New";
                RadTabStrip1.Tabs.FindTabByText("Edit").Selected = false;
                RadTabStrip1.Tabs.FindTabByText("New").Selected = true;--%>
               <%--     document.getElementById('divQualification').style.display = "";
                    document.getElementById('divGeneral').style.display = "none";
                    document.getElementById('divCompanyDetails').style.display = "none";
                    document.getElementById('<%=Button2.ClientID %>').style.display = "none";
                    document.getElementById('<%=Button1.ClientID %>').style.display = "none";--%>

           <%--     }
            }--%>
  <%--  </script>--%>
       <script type="text/javascript">
           function UpdateFunction()
           {

           //  document.getElementById('divGeneral').style.display = "";
            //   document.getElementById('divCompanyDetails').style.display = "";
              // document.getElementById('divQualification').style.display = "none";      
               document.getElementById('<%=Button2.ClientID %>').style.display = "none";
               document.getElementById('<%=Button1.ClientID %>').style.display = "";
             //  document.getElementById("ContentIframe").src = "PersonnelQualification.aspx?id=" + strId;

           }
    </script>

    <script type="text/javascript">
        function validate() {
            var Code = document.getElementById('<%=txtCode.ClientID %>').value;
             var Name = document.getElementById('<%=txtName.ClientID %>').value;
            var Nationality = document.getElementById('<%=txtNationality.ClientID %>').value;
            var Company = document.getElementById('<%=RadComboBox2.ClientID %>').value;
       
            if (Code == "") {
                alert("Enter Your Code");
                return false;
            }

            if (Name == "") {
                alert("Please enter your name");
                return false;
            }

            if (Nationality == "") {
                alert("please enter your nationality");
                return false;
            }

            if (Company == "") {
                alert("Please select your company");
                return false;
            }
           
        }
</script>

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
                   //radTabStrip1.Tabs.Item(0).Selected = True;
                   //radMultiPage1.SelectedIndex = 0;

                 //  alert(tabStrip.SelectedIndex);
                  <%-- var pageView = multiPage.findPageViewByID("RadPageView1");
                   var tabStrip = $find("<%= RadTabStrip1.ClientID %>");
                   var tab = tabStrip.findTabByText('Edit');
                   tab.set_text("New");
                   tabStrip.commitChanges();
                   document.getElementById('<%=Button2.ClientID %>').style.display = "none";
                   document.getElementById('<%=Button1.ClientID %>').style.display = "none";--%>

               }
               else if (tab.get_text() == "Edit")
               {
                   document.getElementById('<%=Button2.ClientID %>').style.display = "none";
                   document.getElementById('<%=Button1.ClientID %>').style.display = "";
               }
               else if (tab.get_text() == "New") {
                   document.getElementById('<%=Button2.ClientID %>').style.display = "";
                   document.getElementById('<%=Button1.ClientID %>').style.display = "none";
                   $('input[type=text]').each(function () {
                       $(this).val('');
                   });
                   $('textarea').empty();
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
             CausesValidation="false"   SelectedIndex="0" Skin="Silk" >
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
            <telerik:RadPageView ID="rpList" runat="server"  >
    <div id="divList">

      
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
            </asp:ScriptManager>

            <telerik:RadGrid ID="RadGrid1" runat="server" OnNeedDataSource="RadGrid1_NeedDataSource" OnItemCommand="RadGrid1_ItemCommand" Skin="Silk"  CssClass="outerMultiPage" OnItemDataBound="RadGrid1_ItemDataBound">
                <MasterTableView DataKeyNames="Code">

                    <Columns>
                        <telerik:GridButtonColumn CommandName="EditData" ButtonType="ImageButton" ImageUrl="~/Images/Icons/Pencil-01.png" Text="Edit" UniqueName="EditData" >   
                        </telerik:GridButtonColumn>
                        <telerik:GridButtonColumn CommandName="Delete"  ButtonType="ImageButton" Text="Delete" UniqueName="Delete" ConfirmDialogType="RadWindow" ConfirmText="Are you sure">
                        </telerik:GridButtonColumn>

                    </Columns>
                </MasterTableView>

            </telerik:RadGrid>
       

    </div>

                    </telerik:RadPageView>
               <telerik:RadPageView ID="rpAddEdit" runat="server">
    <div id="divGeneral" style=" width: 100%;" >
        <div>
            <asp:Label ID="lblGenaral" runat="server" Text="Genaral" ForeColor="Brown"></asp:Label>
        </div>
        <hr />
        <table style="width: 100%;">
            <%--     <tr style="border:dashed; border-bottom-color:blue;">
                <td  class="tabletbody"></td>        
                <td  class="tabletbody">&nbsp;</td>
                <td  class="tabletbody">&nbsp;</td>
                <td  class="tabletbody">&nbsp;</td>
            </tr>
            --%>
            <tr>
                <td class="tabletbody">
                    <asp:Label ID="lblCode" runat="server" Text="Code"></asp:Label>
                </td>
                <td class="tabletbody">
                    <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>

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
                    <telerik:RadDatePicker ID="RadDatePicker1" runat="server"
                        Width="170px" TabIndex="2" AutoPostBack="false">
                        <DateInput DateFormat="dd/MMM/yyyy"  DisplayDateFormat="dd/MMM/yyyy" InvalidStyleDuration="100"
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
                    <asp:TextBox ID="txtName" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
                </td>
                <td class="tabletbody">
                    <asp:Label ID="lblEndDate" runat="server" Text="End Date"></asp:Label>
                </td>
                <td class="tabletbody">
                    <telerik:RadDatePicker ID="RadEndDate" runat="server"
                        Width="170px" TabIndex="2" AutoPostBack="false" MinDate="<%# DateTime.Now.Date %>">
                        <DateInput DateFormat="dd/MMM/yyyy"  DisplayDateFormat="dd/MMM/yyyy"  InvalidStyleDuration="100"
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
                       
           
    <div id="divCompanyDetails" style=" width: 100%;">
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
                    <telerik:RadComboBox ID="RadComboBox2" runat="server" Width="170px"
                        EmptyMessage="Select a Company" EnableLoadOnDemand="True" ShowMoreResultsBox="true"
                        EnableVirtualScrolling="true" OnItemsRequested="RadComboBox2_ItemsRequested">
                    </telerik:RadComboBox>
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

  <div>
        <asp:Button ID="Button2" runat="server" Text="Add" Style="background-color: #008B8B; color: white; display:none" OnClick="Button2_Click" ValidationGroup="Group"  ClientIDMode="Static" OnClientClick="return validate();" />
        <asp:Button ID="Button1" runat="server" Text="Update" Style="background-color: #008B8B; color: white; display:none" OnClick="Button1_Click"  ValidationGroup="Group"  ClientIDMode="Static" />

    </div>

        <hr />        
    <div id="framediv" runat="server">

        <iframe id="ContentIframe" runat="server"
            name="PQualification" width="100%" height="100%" />
    </div>

      </telerik:RadPageView>
  

                    </telerik:RadMultiPage>
    </div>
        </td>
    </tr>
</table>
        
        </div>
   </div>
</asp:Content>

