<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="CWP_Detail.aspx.cs" Inherits="FlyCn.WorkPacks.CWP_Detail" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../Scripts/jquery-1.8.2.js"></script>
     <script src="../Scripts/jquery-1.8.2.min.js"></script>
     <script src="../Scripts/jquery-ui-1.8.24.js"></script>
     <script src="../Scripts/jquery-ui-1.8.24.min.js"></script>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
      <style>
     
              .selectbox {
            width: 69%;
            background-color: #FFF;
            height:25px;
            font: 400 12px/18px 'Open Sans', sans-serif;
            color: #000;
            font-weight: normal;
            border: 1px solid #ccc;
            margin: 5px 0 0 0;
            padding: 5px;
        }
 .footer {
  position: relative;
  right: 10px;
  bottom: 0;
  left: 0;
  padding: 1rem;
  background-color: #efefef;
  text-align:right;
} 
    </style>
     <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePartialRendering="true" >
       
    </asp:ScriptManager>
      <div class="contentTopBar" style="width:760px;">&nbsp;</div> 
          <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
       <div style="width:800px;">
          <div style="width:800px;height:50px;">
             
                 
                      <asp:Label ID="lblModule" CssClass="" runat="server" Text="Module" Font-Size="12px"></asp:Label>
                     
                  &nbsp;&nbsp;
                          <asp:DropDownList ID="ddlModule" runat="server" Width="150px" CssClass="" AppendDataBoundItems="true" AutoPostBack="true" Font-Size="12px" OnSelectedIndexChanged="ddlModule_SelectedIndexChanged">
                               <asp:ListItem Text="--select Module--"></asp:ListItem>
                          </asp:DropDownList>
                    
                 &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  
                      <asp:Label ID="lblCategory" CssClass="" runat="server" Text="Category" Font-Size="12px"></asp:Label>
                      &nbsp;&nbsp;
                         <asp:DropDownList ID="ddlCategory" runat="server" Width="150px" CssClass="" AppendDataBoundItems="false" AutoPostBack="true" Font-Size="12px" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
<%--                               <asp:ListItem Text="--select Category--"></asp:ListItem>--%>
                          </asp:DropDownList>
             
           </div>
         
           
            <div style="min-height:320px;max-height:330px;overflow-x:auto;overflow-y:auto;">
           <telerik:RadGrid ID="dtgAddCWP_Detail" runat="server" CellSpacing="0" GridLines="None" AlwaysVisible="true" AllowPaging="true" Width="90%" AllowSorting="true" PageSize="6" OnNeedDataSource="dtgAddCWP_Detail_NeedDataSource" OnPreRender="dtgAddCWP_Detail_PreRender" OnItemCreated="dtgAddCWP_Detail_ItemCreated">
              <HeaderStyle  HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <AlternatingItemStyle HorizontalAlign="Left" />
                                        <ClientSettings>
                                            <Selecting AllowRowSelect="true" EnableDragToSelectRows="false" />                 
                                        </ClientSettings>
             <MasterTableView AutoGenerateColumns="true" DataKeyNames="" ShowHeadersWhenNoRecords="true" ShowHeader="true" NoMasterRecordsText="No Items have been added." InsertItemPageIndexAction="ShowItemOnFirstPage" InsertItemDisplay="Top">
                 <Columns>
                      <telerik:GridCheckBoxColumn HeaderText="SELECT" DataType="System.Boolean" UniqueName="Modulescheck"></telerik:GridCheckBoxColumn>
                 </Columns>
             </MasterTableView>
         </telerik:RadGrid>   
                
         </div> 
           </div>
               <div class="footer" style="width:750px;">
          
            <asp:Button  class="buttonroundCorner" runat="server" Text="Import"/>
             </div>
         
    </ContentTemplate>
</asp:UpdatePanel>   
</asp:Content>
