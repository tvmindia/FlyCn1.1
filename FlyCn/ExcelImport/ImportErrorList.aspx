<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="ImportErrorList.aspx.cs" Inherits="FlyCn.ExcelImport.ImportErrorList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik"%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
</asp:ScriptManager>
     <div class="PageHeading">Error List</div>
    <div class="container inputMainContainer"  >
  <div class="col-md-12"   >
         <ul>
      <li><a href="#" name="tab1">Error List</a></li>
             </ul>
    <div id="content"  >
          <div id="tab1"  >
              <div role="tabpanel" class="tab-pane active" id="home">
          <div class="table-responsive">
            <div class="contentTopBar"></div>
             <telerik:radgrid ID="RadGrid1_ErrorList" runat="server"  OnItemCommand="RadGrid1_ItemCommand">
              <HeaderStyle  HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <AlternatingItemStyle HorizontalAlign="Left" />
                                        <ClientSettings>
                                            <Selecting AllowRowSelect="true" EnableDragToSelectRows="false" />
                                       
                                        </ClientSettings>
                                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="Status_Id">
                                            <Columns>
                                               

                                                <telerik:GridButtonColumn CommandName="Select" ButtonType="ImageButton"   Text="Select" UniqueName="EditData">
                                                </telerik:GridButtonColumn>

                                                <telerik:GridBoundColumn HeaderText="Status ID" DataField="Status_ID" UniqueName="Status_ID" Display="false"></telerik:GridBoundColumn>
                                                  <telerik:GridBoundColumn HeaderText="File Name" DataField="File_Name" UniqueName="File_Name" ></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Key Field" DataField="Key_Field" UniqueName="Key_Field" ></telerik:GridBoundColumn>
                                                 <telerik:GridBoundColumn HeaderText="Error Description" DataField="Error_Description" UniqueName="Error_Description" ></telerik:GridBoundColumn>
                                                 <telerik:GridBoundColumn HeaderText="Error_Count" DataField="Error_Count" UniqueName="Error_Count" ></telerik:GridBoundColumn>
                                                 <telerik:GridBoundColumn HeaderText="Start Time" DataField="Start_Time" UniqueName="Start_Time"  ></telerik:GridBoundColumn>
                                                
                                            </Columns>
                                        </MasterTableView>
        </telerik:radgrid>
               </div>
                  </div>
              </div>
        </div>
        </div>
      </div>
</asp:Content>
