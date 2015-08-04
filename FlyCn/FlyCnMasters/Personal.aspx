<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="Personal.aspx.cs" Inherits="FlyCn.Personal" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

       <script type="text/javascript">

           function DisplayFunction()
           {



               document.getElementById('divQualification').style.display = "";
               document.getElementById('divGeneral').style.display = "none";
               document.getElementById('divCompanyDetails').style.display = "none";
               document.getElementById('Button2').style.display = "none";
               document.getElementById('Display').style.backgroundColor = "#00CDCD";
               document.getElementById('Display').style.color = "#FFFFFF";
               document.getElementById('ADD').style.backgroundColor = "";
               document.getElementById('ADD').style.color = "";
           }
    </script>
     <script type="text/javascript">
         function ADDFunction()
         {

             document.getElementById('divGeneral').style.display = "";
             document.getElementById('divCompanyDetails').style.display = "";
             document.getElementById('divQualification').style.display = "none";
             document.getElementById('Button1').style.display = "none";
             document.getElementById('Button2').style.display = "";
             document.getElementById('ADD').style.backgroundColor = "#00CDCD";
             document.getElementById('Display').style.backgroundColor = "";
             document.getElementById('ADD').style.color = "#FFFFFF";
             document.getElementById('Display').style.color = "";
             document.getElementById('<%=Button1.ClientID %>').style.visibility = "hidden";
             document.getElementById('<%=Button2.ClientID %>').style.visibility = "visible";
             document.getElementById('<%=framediv.ClientID %>').style.visibility = "hidden";
             document.getElementById('<%=txtCode.ClientID %>').readOnly = false;
             $("input:text").val('');
            
             $('textarea').empty()

         }
    </script>
       <script type="text/javascript">
           function UpdateFunction()
           {

               document.getElementById('divGeneral').style.display = "";
               document.getElementById('divCompanyDetails').style.display = "";
               document.getElementById('divQualification').style.display = "none";
               document.getElementById('ADD').style.backgroundColor = "#00CDCD";
               document.getElementById('Display').style.backgroundColor = "";
               document.getElementById('ADD').style.color = "#FFFFFF";
               document.getElementById('Display').style.color = "";
               document.getElementById('Button1').style.display = "";
               document.getElementById('<%=Button2.ClientID %>').style.visibility = "hidden";
               document.getElementById('<%=Button1.ClientID %>').style.visibility = "visible";
             //  document.getElementById("ContentIframe").src = "PersonnelQualification.aspx?id=" + strId;

           }
    </script>
    <script type="text/javascript">
        function validate() {
            var Code = document.getElementById('<%=txtCode.ClientID %>').value;
             var Name = document.getElementById('<%=txtName.ClientID %>').value;
            var Nationality = document.getElementById('<%=txtNationality.ClientID %>').value;
          //  var PassportNo = document.getElementById('<%=txtPassportNo.ClientID %>').value;
            var Company = document.getElementById('<%=RadComboBox2.ClientID %>').value;
           // var OTEligible = document.getElementById('<%=RadComboOTEligible.ClientID %>').value;
            //var boSubcontract = document.getElementById('<%=RadcomboSubcontract.ClientID %>').value;
           
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

    <div>
        <input id="Display" type="button" value="List" style="background-color: #00CDCD; color: white;" align="left" onclick="DisplayFunction()" />
        <input id="ADD" type="button" value="New" align="left" onclick="ADDFunction()" />
    </div>

    <div>
    </div>

    <div id="divGeneral" style="display: none; width: 100%;">
        <div>
            <asp:Label ID="lblGenaral" runat="server" Text="Genaral" ForeColor="SpringGreen"></asp:Label>
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
                        <DateInput DateFormat="dd/MM/yyyy" InvalidStyleDuration="100"
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
                        <DateInput DateFormat="dd/MM/yyyy" InvalidStyleDuration="100"
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

    <div id="divCompanyDetails" style="display: none; width: 100%;">
        <div>
            <asp:Label ID="lblCompanyDetails" runat="server" Text="Company Details" ForeColor="SpringGreen"></asp:Label>
        </div>
        <hr />
        <table style="width: 100%;">
            <%--     <tr>
                <td  class="tabletd"></td>             
                <td  class="tabletd">&nbsp;</td>
                <td  class="tabletd">&nbsp;</td>
                <td  class="tabletd">&nbsp;</td>
            </tr>
            --%>
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
        <asp:Button ID="Button2" runat="server" Text="Add" Style="background-color: #008B8B; color: white; display: none;" OnClick="Button2_Click" ClientIDMode="Static" ValidationGroup="Group" OnClientClick="return validate();" />
        <asp:Button ID="Button1" runat="server" Text="Update" Style="background-color: #008B8B; color: white; display: none;" OnClick="Button1_Click" ClientIDMode="Static" ValidationGroup="Group" />

    </div>

    <div id="divQualification">

        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
            </asp:ScriptManager>

            <telerik:RadGrid ID="RadGrid1" runat="server" OnNeedDataSource="RadGrid1_NeedDataSource" OnItemCommand="RadGrid1_ItemCommand">
                <MasterTableView DataKeyNames="Code">

                    <Columns>
                        <telerik:GridButtonColumn CommandName="EditData" Text="Edit" UniqueName="EditData">
                        </telerik:GridButtonColumn>
                        <telerik:GridButtonColumn CommandName="Delete" Text="Delete" UniqueName="Delete" ConfirmDialogType="RadWindow" ConfirmText="Are you sure">
                        </telerik:GridButtonColumn>

                    </Columns>
                </MasterTableView>

            </telerik:RadGrid>
        </div>

    </div>

    <div id="framediv" runat="server">

        <iframe id="ContentIframe" runat="server"
            name="PQualification" width="100%" height="100%" />
    </div>

</asp:Content>

