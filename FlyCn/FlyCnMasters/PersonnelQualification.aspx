<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Popup.Master" AutoEventWireup="true" CodeBehind="PersonnelQualification.aspx.cs" Inherits="FlyCn.FlyCnMasters.PersonnelQualification" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery-1.8.2.min.js"></script>

    <script type="text/javascript">
        function onClientTabSelected(sender, args) {
            var tab = args.get_tab();
            if (tab.get_text() == "New") {
                document.getElementById('divQualificationedit').style.display = "";
                document.getElementById('divQualification').style.display = "none";
                document.getElementById('<%=Button1.ClientID %>').style.display = "none";
                document.getElementById('<%=Button2.ClientID %>').style.display = "";
                $("input:text").val('');
                $('textarea').empty()
                var hiddenStatusFlag = document.getElementById('<%= HiddenField.ClientID%>').value;   
             
                document.getElementById('<%=txtEmpCode.ClientID %>').value = hiddenStatusFlag;
            }
            else if (tab.get_text() == "View") {


                document.getElementById('divQualification').style.display = "";
                document.getElementById('divQualificationedit').style.display = "none";
                document.getElementById('<%=Button2.ClientID %>').style.display = "none";
            }

        }


        </script>
         <%--<script type="text/javascript">

             function DisplayFunction() {



                 document.getElementById('divQualification').style.display = "";
                 document.getElementById('divQualificationedit').style.display = "none";
                 document.getElementById('<%=Button2.ClientID %>').style.visibility = "hidden";
                 document.getElementById('Display').style.backgroundColor = "#00CDCD";
                 document.getElementById('Display').style.color = "#FFFFFF";
                 document.getElementById('ADD').style.backgroundColor = "";
                 document.getElementById('ADD').style.color = "";
             }
    </script>--%>
     <%--<script type="text/javascript">
         function ADDFunction()
         {

             document.getElementById('divQualificationedit').style.display = "";
             document.getElementById('divQualification').style.display = "none";
             document.getElementById('Button1').style.display = "none";
             document.getElementById('Button2').style.display = "";
             document.getElementById('ADD').style.backgroundColor = "#00CDCD";
             document.getElementById('Display').style.backgroundColor = "";
             document.getElementById('ADD').style.color = "#FFFFFF";
             document.getElementById('Display').style.color = "";
             document.getElementById('<%=Button1.ClientID %>').style.visibility = "hidden";
             document.getElementById('<%=Button2.ClientID %>').style.visibility = "visible";
             $("input:text").val('');
             $('textarea').empty()

            
           


         }
    </script>--%>
       <script type="text/javascript">
           function UpdateFunction() {

               document.getElementById('divQualificationedit').style.display = "";
               document.getElementById('divQualification').style.display = "none";
               document.getElementById('<%=Button2.ClientID %>').style.display="none"
               document.getElementById('<%=Button1.ClientID %>').style.display = "";
           }
    </script>

        <script type="text/javascript">
            function validate()
            {
                var Qualification = document.getElementById('<%=txtQualification.ClientID %>').value;

                if (Qualification == "") {
                    alert("Enter Your Qualification");
                    return false;
                }

            }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
  <%--  <div>
        <input id="Display" type="button" value="List" style="background-color: #00CDCD; color: white;" align="left" onclick="DisplayFunction()" />
        <input id="ADD" type="button" value="New" align="left" onclick="ADDFunction()" />
    </div>--%>

    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" Width="300px" OnClientTabSelected="onClientTabSelected"
             CausesValidation="false"   SelectedIndex="0" >
            <Tabs>
                <telerik:RadTab Text="View" PageViewID="rpList" Value="1" Width="150px" runat="server" ImageUrl="~/Images/Icons/ListIcon.png"  ></telerik:RadTab>
                 <telerik:RadTab Text="New" PageViewID="rpAddEdit" Value="2" Width="150px" runat="server" ImageUrl="~/Images/Icons/NewIcon.png"  ></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>

    <div id="divQualificationedit" style="display: none">
        <table style="width: 100%;">
            <tr>
                <td>
                       <asp:HiddenField ID="HiddenField" runat="server" />
                    <asp:Label ID="lblEmpCode" runat="server" Text="EmployeeCode"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmpCode" runat="server"  enabled="false" ></asp:TextBox>


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
                    <asp:Label ID="lblQualification" runat="server" Text="Qualification"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtQualification" runat="server"></asp:TextBox>
                </td>
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
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblQualificationType" runat="server" Text="QualificationType"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtQualificationType" runat="server"></asp:TextBox>
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
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
      <div>
                                 <asp:Button ID="Button2" runat="server" Text="Add"  style="background-color:#008B8B; color:white; display:none;"  OnClick="Button2_Click" ClientIDMode="Static" ValidationGroup="Submit" OnClientClick="return validate();" />
                                <asp:Button ID="Button1" runat="server" Text="Update" style="background-color:#008B8B; color:white; display:none;"  OnClick="Button1_Click" ClientIDMode="Static" />

            </div>
      <div id="divQualification">
        Qualification

        <br />
        <br />

    
    <div>
       <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" >
</asp:ScriptManager>

<telerik:RadGrid ID="RadGrid1" runat="server"  OnNeedDataSource="RadGrid1_NeedDataSource" OnItemCommand="RadGrid1_ItemCommand">
   <MasterTableView DataKeyNames="EmpCode,Qualification">
     
    <Columns>
          <telerik:GridButtonColumn CommandName="EditData" Text="Edit" UniqueName="EditData">
                    </telerik:GridButtonColumn>
         <telerik:GridButtonColumn CommandName="Delete" Text="Delete" UniqueName="Delete" ConfirmDialogType="RadWindow" ConfirmText="Are you sure" >
                    </telerik:GridButtonColumn>
   
    </Columns> 
  </MasterTableView>

   </telerik:RadGrid>
</div>
          </div>
</asp:Content>
