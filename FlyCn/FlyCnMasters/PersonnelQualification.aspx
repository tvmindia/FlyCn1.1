<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Popup.Master" AutoEventWireup="true" CodeBehind="PersonnelQualification.aspx.cs" Inherits="FlyCn.FlyCnMasters.PersonnelQualification" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>

<asp:Content ID="phdPersonnelQualificationMasterHead" ContentPlaceHolderID="head" runat="server">
    <style>
        .myclass
      {
          width: 1050px;
      }
    </style>
    <script src="../Scripts/jquery-1.8.2.min.js"></script>
      <script type="text/javascript">
          function validate() {
              var Qualification = document.getElementById('<%=txtQualification.ClientID %>').value;
                if (Qualification == "") {

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
        function onClientTabSelected(sender, args) {
            var tab = args.get_tab();
            if (tab.get_value() == "2") {
                //new clicked 
                try {               
                    $('input[type=text]').each(function () {
                        $(this).val('');
                    });
                   
                    $('textarea').empty();
                    <%=ToolBarQualification.ClientID %>_SetAddVisible(false);
                    <%=ToolBarQualification.ClientID %>_SetSaveVisible(true);
                    <%=ToolBarQualification.ClientID %>_SetUpdateVisible(false);
                    <%=ToolBarQualification.ClientID %>_SetDeleteVisible(false);           
                }
                catch (x)
                {
                    alert(x.message);
                }

            }
            if (tab.get_value() == "1")
            {
                var tabStrip = $find("<%= RadTabStrip1.ClientID %>");
                var tab = tabStrip.findTabByValue("1");
                tab.select();
                var tab1 = tabStrip.findTabByValue("2");
                tab1.set_text("New");
                tab1.set_imageUrl('../Images/Icons/NewIcon.png');
            }

        }

        function OnClientButtonClicking(sender, args)
        {
            var btn = args.get_item();
            if (btn.get_value() == 'Delete')
            {
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
    
   
   

</asp:Content>

<asp:Content ID="phdPersonnelQualificationMasterContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="inputMainContainer"  >
        <div class="innerDiv">
    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" Width="200px"    OnClientTabSelected="onClientTabSelected"
             CausesValidation="false"   SelectedIndex="0" Skin="Silk" >
            <Tabs>
                <telerik:RadTab Text="View" PageViewID="rpList" Value="1" Width="100px" Height="20px" runat="server" ImageUrl="~/Images/Icons/ListIcon.png"  ></telerik:RadTab>
                 <telerik:RadTab Text="New" PageViewID="rpAddEdit" Value="2" Width="100px" Height="20px" runat="server" ImageUrl="~/Images/Icons/NewIcon.png"  ></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
    
               
           <telerik:RadMultiPage ID="RadMultiPage1" runat="server" Width="100%" SelectedIndex="0" CssClass="outerMultiPage">

               <telerik:RadPageView ID="rpList" runat="server"  >
            
      <div id="divQualification">
       
    
    <div>
       <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" >
</asp:ScriptManager>

<telerik:RadGrid ID="dtgPersonnelQualificationGrid" runat="server" 
     OnNeedDataSource="dtgPersonnelQualificationGrid_NeedDataSource" OnItemCommand="dtgPersonnelQualificationGrid_ItemCommand"
     Skin="Silk" OnPreRender="dtgPersonnelQualificationGrid_PreRender1" CssClass="myclass" >
   <MasterTableView DataKeyNames="EmpCode,Qualification"  CssClass="myclass">
     
    <Columns>
          <telerik:GridButtonColumn CommandName="EditData" Text="Edit" UniqueName="EditData" ButtonType="ImageButton" ImageUrl="~/Images/Icons/Pencil-01.png" >
                    </telerik:GridButtonColumn>
         <telerik:GridButtonColumn CommandName="Delete"  ButtonType="ImageButton"  Text="Delete" UniqueName="Delete" ConfirmDialogType="RadWindow" ConfirmText="Are you sure" >
                    </telerik:GridButtonColumn>
   
    </Columns> 
  </MasterTableView>

   </telerik:RadGrid>
</div>
          </div>                       
                             </telerik:RadPageView>
                   <telerik:RadPageView ID="rpAddEdit" runat="server">
           <asp:Label ID="lblerror" runat="server" Text="" ForeColor="Red"></asp:Label>

                       <uc1:ToolBar runat="server" ID="ToolBarQualification" />
    <div id="divQualificationedit" style="overflow-y:hidden" >
      
        <table style="width: 100%;">
            <tr>
                 <td>
                    <asp:Label ID="lblQualification" runat="server" Text="Qualification"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtQualification" runat="server"></asp:TextBox>
                     <span id="span2" runat="server" style="color: red; font-size: 15px; font-weight: 500;
font-family: Trebuchet MS;">*</span>
                </td>
                   <td>
                    <asp:Label ID="lblQualificationType" runat="server" Text="QualificationType"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtQualificationType" runat="server"></asp:TextBox>
                </td>
            
            </tr>
            <tr>
               
                <td>
                    <asp:Label ID="lblRenewedDate" runat="server" Text="RenewedDate"></asp:Label>
                </td>
                <td>
                    <telerik:RadDatePicker ID="RadDRenewedDate" runat="server"
                       Width="180px" TabIndex="2" AutoPostBack="false" MinDate="<%# DateTime.Now.Date %>">
                        <DateInput DateFormat="dd/MM/yyyy" InvalidStyleDuration="100"
                            runat="server">
                        </DateInput>

                        <Calendar runat="server">
                        </Calendar>
                    </telerik:RadDatePicker>
                </td>
                    <td>
                    <asp:Label ID="lblExpiryDate" runat="server" Text="ExpiryDate"></asp:Label>

                </td>
                <td>
                    <telerik:RadDatePicker ID="RadExpiryDate" runat="server"
                        Width="180px" TabIndex="2" AutoPostBack="false" MinDate="<%# DateTime.Now.Date %>">
                        <DateInput DateFormat="dd/MM/yyyy" InvalidStyleDuration="100"
                            runat="server">
                        </DateInput>

                        <Calendar runat="server">
                        </Calendar>
                    </telerik:RadDatePicker>
                </td>
            </tr>
            <tr>
               <td>
                    <asp:Label ID="lblFirstQualifiedDate" runat="server" Text="FirstQualifiedDate"></asp:Label>
                </td>
                <td>
                    <telerik:RadDatePicker ID="RadFirstQualifiedDate" runat="server"
                        Width="180px" TabIndex="2" AutoPostBack="false" MinDate="<%# DateTime.Now.Date %>">
                        <DateInput DateFormat="dd/MM/yyyy" InvalidStyleDuration="100"
                            runat="server">
                        </DateInput>

                        <Calendar runat="server">
                        </Calendar>
                    </telerik:RadDatePicker>
                </td>
                <td>
                    <asp:Label ID="lblRemarks" runat="server" Text="Remarks"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Width="170px"></asp:TextBox>
                </td>
            </tr>
            <tr>
              
            <td>
                       <asp:HiddenField ID="HiddenField" runat="server" />
                    <asp:Label ID="lblEmpCode" runat="server" Text="EmployeeCode" Visible="false"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmpCode" runat="server"  ReadOnly="true"  Visible="false"></asp:TextBox>


                </td>
            </tr>
        </table>
    </div>

                       
                   </telerik:RadPageView>
            
      
            
                       </telerik:RadMultiPage>
                             
  
   
        </div>
         </div>
</asp:Content>
