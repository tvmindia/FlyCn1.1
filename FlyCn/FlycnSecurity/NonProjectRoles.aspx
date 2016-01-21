<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="NonProjectRoles.aspx.cs" Inherits="FlyCn.FlycnSecurity.NonProjectRoles" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

 <title>Non Project Roles</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
</asp:ScriptManager>

  <div class="col-md-12">
       <uc1:ToolBar runat="server" ID="ToolBar" />
    <div class="col-md-9 ">
        <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
          
       

              <telerik:RadGrid ID="dtgNonProjectRoles" runat="server" AllowPaging="true" AllowSorting="true"  PageSize="10"
                        OnNeedDataSource="dtgNonProjectRoles_NeedDataSource" OnItemCommand="dtgNonProjectRoles_ItemCommand"
                        Skin="Silk" CssClass="outerMultiPage"
                        OnPreRender="dtgNonProjectRoles_PreRender">
                        <MasterTableView AutoGenerateColumns="false" DataKeyNames="RoleID">
                            
                            <Columns>
                                <telerik:GridButtonColumn CommandName="EditData" ButtonType="ImageButton" ImageUrl="~/Images/Icons/Pencil-01.png" Text="Edit" UniqueName="EditData">
                                </telerik:GridButtonColumn>
                                <telerik:GridButtonColumn CommandName="Delete" ButtonType="ImageButton"  ImageUrl="~/Images/Cancel.png" Text="Delete" UniqueName="Delete" ConfirmDialogType="RadWindow" ConfirmText="Are you sure">
                                </telerik:GridButtonColumn>

                                <telerik:GridBoundColumn HeaderText="Role ID" DataField="RoleID" UniqueName="RoleID"></telerik:GridBoundColumn> 
                                 <telerik:GridBoundColumn HeaderText="Role Name" DataField="RoleName" UniqueName="RoleName"></telerik:GridBoundColumn> 
                                 <telerik:GridBoundColumn HeaderText="Role Type" DataField="RoleType" UniqueName="RoleType"></telerik:GridBoundColumn> 
                                 <telerik:GridBoundColumn HeaderText="Role Scope" DataField="RoleScope" UniqueName="RoleScope"></telerik:GridBoundColumn> 
                                 <telerik:GridBoundColumn HeaderText="Scope Value" DataField="ScopeValue" UniqueName="ScopeValue"></telerik:GridBoundColumn> 
                                 <telerik:GridBoundColumn HeaderText="Project Group1" DataField="ProjectGroup1" UniqueName="ProjectGroup1"></telerik:GridBoundColumn> 
                                 <telerik:GridBoundColumn HeaderText="Project Group2" DataField="ProjectGroup2" UniqueName="ProjectGroup2"></telerik:GridBoundColumn> 
                                 <telerik:GridBoundColumn HeaderText="Project Group3" DataField="ProjectGroup3" UniqueName="ProjectGroup3"></telerik:GridBoundColumn> 
                                 <telerik:GridBoundColumn HeaderText="Access Type" DataField="AccessType" UniqueName="AccessType"></telerik:GridBoundColumn> 
                                 <telerik:GridBoundColumn HeaderText="Created By" DataField="Created_By" UniqueName="Created_By"></telerik:GridBoundColumn> 
                                 <telerik:GridBoundColumn HeaderText="Created Date" DataField="Created_Date" UniqueName="Created_Date"  DataType="System.DateTime"  DataFormatString="{0:M/d/yyyy}"></telerik:GridBoundColumn> 

                            </Columns>
                        </MasterTableView>

                    </telerik:RadGrid>

      </div>

    <div class="col-md-3 ">

<%--Role name--%>
 <div class="form-group required">
          <asp:Label ID="lblRoleName" CssClass="control-label col-md-6 "  runat="server" Text="RoleName">

          </asp:Label>

          <div class="col-md-6">

          <asp:TextBox ID="txtRoleName" runat="server"></asp:TextBox>

          </div>
     </div>

<%--Role type--%>
 <div class="form-group required">
          <asp:Label ID="lblRoleType" CssClass="control-label col-md-6 "  runat="server" Text="RoleType">

          </asp:Label>

         <div class="col-md-6">

              <asp:DropDownList ID="ddlRoleType" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="ddlRoleType_SelectedIndexChanged"></asp:DropDownList>

          </div>

     </div>

<%--Role scope--%>

 <div class="form-group required">
         <asp:Label ID="lblRoleScope" CssClass="control-label col-md-6 "  runat="server" Text="Role Scope">

          </asp:Label>

         <div class="col-md-6">
           <asp:DropDownList ID="ddlLevel" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="ddlLevel_SelectedIndexChanged"></asp:DropDownList>
         </div>
     </div>

 <%--Scope value--%>  
           
          <asp:Label ID="lblScopeValue" CssClass="control-label col-md-6"   runat="server" Text="Scope Value">

          </asp:Label>

         <div class="col-md-6">

         <asp:ListBox ID="lstRoleScope" runat="server" SelectionMode="Multiple" OnSelectedIndexChanged="lstRoleScope_SelectedIndexChanged"></asp:ListBox>

             </div>
<%--Project group1--%>

          <asp:Label ID="lblProjectGroup1" CssClass="control-label col-md-6"  runat="server" Text="ProjectGroup3">

          </asp:Label>

         <div class="col-md-6">
         <asp:DropDownList ID="ddlProjectGroup1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProjectGroup1_SelectedIndexChanged" ></asp:DropDownList>
         </div>
<%--Project group2--%>

          <asp:Label ID="lblProjectGroup2" CssClass="control-label col-md-6"  runat="server" Text="ProjectGroup3">

          </asp:Label>

         <div class="col-md-6">
        <asp:TextBox ID="txtProjectGroup2" runat="server"></asp:TextBox>
        </div>
<%--Project group3--%>

          <asp:Label ID="lblProjectGroup3" CssClass="control-label col-md-6"  runat="server" Text="ProjectGroup3">

         </asp:Label>

        <div class="col-md-6">
        <asp:TextBox ID="txtProjectGroup3" runat="server"></asp:TextBox>
        </div>

<%--Access type--%>
 <div class="form-group required">
          <asp:Label ID="lblAccessType" CssClass="control-label col-md-6"  runat="server" Text="Access Type">

          </asp:Label>
      
         <div class="col-md-6">
        <asp:TextBox ID="txtAccessType" runat="server"></asp:TextBox>
        </div>
     </div>

<%--Created by--%>

          <asp:Label ID="lblCreatedBy" CssClass="control-label col-md-6"  runat="server" Text="Created By">

          </asp:Label>

         <div class="col-md-6">
        <asp:TextBox ID="txtCreated_By" runat="server"></asp:TextBox>
        </div>

<%--Created date--%>

          <asp:Label ID="lblCreatedDate" CssClass="control-label col-md-6"  runat="server" Text="Created Date">

          </asp:Label>

        <div class="col-md-6">
        <asp:TextBox ID="txtCreated_Date" runat="server"></asp:TextBox>
        </div>

   </div>

  </div>

</asp:Content>


 <%--  <style>

         #maincontainer {
    width:100%;
    height: 100%;
  }



         #leftcolumn {
    float:left;
    display:inline-block;
    width: 60%;
    height: 100%;
     border-right: 1px solid #AD141C;
    /*background: blue;*/
    padding-right:10px;
    /*#AD141C*/
  }

  #contentwrapper {
    float:left;
    display:inline-block;
    /*width: -moz-calc(100% - 100px);
    width: -webkit-calc(100% - 100px);
    width: calc(100% - 100px);*/
    width:25%;
    height:100%;
    padding-left:60px;
   
    /*background-color: red;*/
  }

    </style>--%>

 <%-- <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>--%>

<%--<%--
  <div id="maincontainer">

    <div id="leftcolumn">

   

    <table style="width:25%" >
     
     <tr>
          <td >
             
            <asp:GridView ID="gvNonProjectRole" BackColor="#ffffff" CellSpacing="3" CellPadding="1" runat="server" OnSelectedIndexChanged="gvNonProjectRole_SelectedIndexChanged"  BorderWidth="1px" BorderColor="#AD141C" >
                <Columns>
                

                    <asp:TemplateField>
                        <ItemTemplate>
    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/Images/Trash can - 04.png"  OnClientClick="return confirm('Deletion Confirmation \n\n\n\n\ Are you sure you want to delete this item ?');" OnClick="imgBtnDelete_Click" />   

                                <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/Images/Icons/editToolBarIcon.png" OnClick="imgBtnEdit_Click" />                          
                      

                               
                                   
                                </ItemTemplate>

                            </asp:TemplateField>

                </Columns>
            </asp:GridView>

        </td>
         </tr>
        </table>

         </div>

    <div id="contentwrapper">
   <%-- <table>
        <tr>

         <td style="border-left:1px solid;">--%>
<%--             <table style="width:10%">

         <tr>
         <td>
             <asp:Button ID="btnInsert" runat="server" Text="INSERT" OnClick="btnInsert_Click" BorderColor="#f7434c" BackColor="#fabec1" ForeColor="#5B0B0D"/>
</td>

<td>
             <asp:Button ID="btnUpdate" runat="server" Text="UPDATE" OnClick="btnUpdate_Click" BorderColor="#f7434c" BackColor="#fabec1" ForeColor="#5B0B0D"/> </td>
         

  </tr>

         <tr>
             <td>
               RoleName<span style="color:red">* </span>
              </td>
             <td>  <asp:TextBox ID="txtRoleName" runat="server"></asp:TextBox>
             </td>
        </tr>

        <tr>
            <td>
               RoleType<span style="color:red">* </span>

            </td><td>
               
               
            </td>

        </tr>

        <tr>
         <td> Role Scope<span style="color:red">* </span></td>
         <td>
        <asp:DropDownList ID="ddlLevel" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="ddlLevel_SelectedIndexChanged"></asp:DropDownList>
         </td>
        </tr>

        <tr>
            <td>Scope Value<span style="color:red">* </span></td>
            <td>
                <asp:ListBox ID="lstRoleScope" runat="server" SelectionMode="Multiple" OnSelectedIndexChanged="lstRoleScope_SelectedIndexChanged"></asp:ListBox></td>
              
            

        </tr>

        <tr>
            <td>
               ProjectGroup1</td>
              <td>   <asp:DropDownList ID="ddlProjectGroup1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProjectGroup1_SelectedIndexChanged" ></asp:DropDownList>
                  
            </td>
       </tr>

        <tr>
            <td>
               ProjectGroup2</td>
              <td>  <asp:TextBox ID="txtProjectGroup2" runat="server"></asp:TextBox>
            </td>

        </tr>

        <tr>
            <td>
              ProjectGroup3 </td>
              <td><asp:TextBox ID="txtProjectGroup3" runat="server"></asp:TextBox>
            </td>
       </tr>

        <tr>
            <td>
              AccessType <span style="color:red">* </span>

            </td>
              <td><asp:TextBox ID="txtAccessType" runat="server"></asp:TextBox>
            </td>
       </tr>

        <tr>
           
              <td>
               Created_By</td>
              <td>  <asp:TextBox ID="txtCreated_By" runat="server"></asp:TextBox>
            </td>
         </tr>

        <tr>
            <td>
               Created_Date</td>
              <td> <asp:TextBox ID="txtCreated_Date" runat="server" ReadOnly="true"></asp:TextBox>
            </td>
        </tr>

             </table>--%>

            <%-- </td>  
    </tr>

</table>--%>

   <%--</div>--%>

        <%--</div>--%>