<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="AssignRoles.aspx.cs" Inherits="FlyCn.FlycnSecurity.AssignRoles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
    <asp:ScriptManager ID="scriptmanager1" runat="server"></asp:ScriptManager>
          <div id="Heading" runat="server" style="width: 90%; text-align: center; margin: 20px">
        <ul class="list-inline" id="horizonaltab" runat="server" style="width: 100%;">
            <li style="width: 10px;"></li>
                
        </ul>
    </div>
    

    <div class="importWizardContainer" style="height:500px;">
             <div style="float:left; width:53%;">
                
                   <div class="col-md-12">
                       <div class="col-md-4">
            <asp:Label ID="lblCurrentRoles" runat="server" Text="Current Roles" CssClass="PageHeading"></asp:Label>
                   </div>
                    <div class="col-md-8">
        <asp:Label ID="lblUser" runat="server" Text="Please Select User:" CssClass="control-label col-xs-6"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" Width="150px">
        </asp:DropDownList>
                     </div>
                      
                     </div>
   <br />
                 <br />
                 <br />

   <div style="width:550px;">
                     <telerik:RadGrid ID="dtgCurrentRoles" runat="server" OnNeedDataSource="dtgCurrentRoles_NeedDataSource">

                    <MasterTableView  AutoGenerateColumns="false" ShowHeadersWhenNoRecords="true" ShowHeader="true" NoMasterRecordsText="No Categories have been added.">
                         <Columns>
                              <telerik:GridBoundColumn HeaderText="Role ID" Display="true"></telerik:GridBoundColumn>
                              <telerik:GridBoundColumn HeaderText="Role Type" Display="true"></telerik:GridBoundColumn>
                              <telerik:GridBoundColumn HeaderText="Role Name" Display="true"></telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>

                </telerik:RadGrid>
                </div>
                     
               </div>
             <div style="float:right; width:47%; ">
            <div class="col-md-12"  style="border-left: 1px solid #cfc7c0;min-height:400px">
               
            <asp:Label ID="lblAssignRoles" runat="server" Text="Assign Roles" CssClass="PageHeading"></asp:Label>
                   
                <br />
               
                <table style="width:95%">
                    <tr><td>      
                <asp:Label ID="lblSelectRole" runat="server" Text="Select Role Type:"></asp:Label></td>
                        <td  >
       <asp:RadioButton ID="RadioButton1" Text="" runat="server" GroupName="roles"/></td>
                       <td>Project Roles</td><td >
             <asp:RadioButton ID="RadioButton2" runat="server" text="" GroupName="roles"/>

                   </td>    <td>Non-Project Roles</td> </tr>
                </table>
                   
                <asp:Label ID="Label3" runat="server" Text="Select Project/Select Level"></asp:Label>
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="DropDownList2" runat="server"  Width="150px"></asp:DropDownList>
                <br />
            <br /> <div style="width:500px;">
                   <telerik:RadGrid ID="dtgAssignRoles" runat="server"  OnNeedDataSource="dtgAssignRoles_NeedDataSource">

                    <MasterTableView  AutoGenerateColumns="false" ShowHeadersWhenNoRecords="true" ShowHeader="true" NoMasterRecordsText="No Categories have been added.">
                         <Columns>
                              <telerik:GridBoundColumn HeaderText="Role" ></telerik:GridBoundColumn>
                              <telerik:GridBoundColumn HeaderText="Select" ></telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>

                </telerik:RadGrid>
          </div>
                </div>
             </div> 
         </div>
   
</asp:Content>

