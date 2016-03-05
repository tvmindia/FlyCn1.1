<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="ProjectsSwithching.aspx.cs" Inherits="FlyCn.ProjectsSwithching" %>
 <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link href="../Content/themes/base/jquery-ui.css" rel="stylesheet" />

      <asp:ScriptManager ID="scriptmanager" runat="server" EnablePageMethods="true" EnablePartialRendering="true" ></asp:ScriptManager>
         <div id="bodyDiv">
        <div class="contentTopBar" style="width:750px;">&nbsp;</div> 
   
                         <div style="width:750px;">
                     <telerik:RadGrid ID="dtgProjectSwitching" runat="server" AllowPaging="true" OnNeedDataSource="dtgProjectSwitching_NeedDataSource" OnItemCommand="dtgProjectSwitching_ItemCommand" Width="100%" Skin="Silk" CssClass="outerMultiPage" AllowSorting="true"  PageSize="7" >
                           <HeaderStyle  HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <AlternatingItemStyle HorizontalAlign="Left" />
                    <MasterTableView  AutoGenerateColumns="false" ShowHeadersWhenNoRecords="true" ShowHeader="true" NoMasterRecordsText="No project details have been added." DataKeyNames="ProjectNo">
                         <Columns>
                               <telerik:GridButtonColumn CommandName="Select" ButtonType="ImageButton" ImageUrl="~/Images/Document Next-WF.png" UniqueName="EditData">
                                </telerik:GridButtonColumn>
                                 <telerik:GridButtonColumn CommandName="SelectDefault" Text="Set As Default" ItemStyle-ForeColor="#009999" ButtonType="LinkButton" UniqueName="Delete">
                                </telerik:GridButtonColumn>
                              <telerik:GridBoundColumn HeaderText="Project No" DataField="ProjectNo" UniqueName="ProjectNo" ></telerik:GridBoundColumn>
                              <telerik:GridBoundColumn HeaderText="Project Name" DataField="ProjectName" UniqueName="ProjectName"></telerik:GridBoundColumn>
                              <telerik:GridBoundColumn HeaderText="Project Loacation" DataField="ProjectLocation" UniqueName="ProjectLocation"></telerik:GridBoundColumn>
                             
                             
                        </Columns>
                    </MasterTableView>

                </telerik:RadGrid><asp:Label ID="lblProjNo" runat="server" Visible="false"></asp:Label>
                            
                </div>
          </div> 



         
        <asp:HiddenField ID="hdfProjNo" runat="server" ClientIDMode="Static"/>
</asp:Content>
