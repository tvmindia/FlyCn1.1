<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="ImportStatusList.aspx.cs" Inherits="FlyCn.ExcelImport.ImportStatusList" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <meta name="viewport" content="width=device-width, initial-scale=1" />
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
</asp:ScriptManager>
     <div class="PageHeading">Status List</div>
    <div class="container inputMainContainer"  >
  <div class="col-md-12"   >
        <ul id="tabs">
      <li><a href="#" name="tab1">Ongoing</a></li>
      <li><a href="#" name="tab2">Completed</a></li>
             </ul>
    <div id="content"  >
         <div id="tab1"  >
          <div role="tabpanel" class="tab-pane active" id="home">
          <div class="table-responsive">
            <div class="contentTopBar"></div>
             <telerik:radgrid ID="RadGrid1" runat="server" >
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

                                                <telerik:GridBoundColumn HeaderText="Status ID" DataField="Status_Id" UniqueName="Status_Id" Display="false"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Project Number" DataField="ProjNo" UniqueName="ProjNo" Display="false"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="File Name" DataField="File_Name" UniqueName="File_Name" ></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Table Name" DataField="Table_Name" UniqueName="Table_Name" ></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Start Time" DataField="Start_Time" UniqueName="Start_Time" Display="false" ></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Total Count" DataField="Total_Count" UniqueName="Total_Count"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Insert Count" DataField="Insert_Count" UniqueName="Insert_Count" Display="false"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Update_Count" DataField="Update_Count" UniqueName="Update_Count" Display="false"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Error_Count" DataField="Error_Count" UniqueName="Error_Count" Display="false"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="User_Name" DataField="User_Name" UniqueName="User_Name" Display="false"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="InsertStatus" DataField="InsertStatus" UniqueName="InsertStatus"> </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Remarks" DataField="Remarks" UniqueName="Remarks" Display="false"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Last Updated Time" DataField="Last_Updated_Time" UniqueName="Last_Updated_Time" DataType="System.DateTime" DataFormatString="{0:dd/MMM/yyyy}"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Processed Count" DataField="Processed_Count" UniqueName="Processed_Count"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Is Deleted" DataField="IsDeleted" UniqueName="IsDeleted" Display="false"></telerik:GridBoundColumn>
                                                 <telerik:GridBoundColumn HeaderText="Time Remaining" DataField="Time_Remaining" UniqueName="Time_Remaining" Display="false"></telerik:GridBoundColumn>
                                            </Columns>
                                        </MasterTableView>
        </telerik:radgrid>
               </div>
        </div>
      </div>
         <div id="tab2"  > 
        <div role="tabpanel" class="tab-pane active" id="Div1">
              <div class="table-responsive">
            <div class="contentTopBar"></div>
                  <telerik:radgrid ID="RadGrid2" runat="server" >
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

                                                <telerik:GridBoundColumn HeaderText="Status ID" DataField="Status_Id" UniqueName="Status_Id" Display="false"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Project Number" DataField="ProjNo" UniqueName="ProjNo" Display="false"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="File Name" DataField="File_Name" UniqueName="File_Name" ></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Table Name" DataField="Table_Name" UniqueName="Table_Name" ></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Start Time" DataField="Start_Time" UniqueName="Start_Time" Display="false" ></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Total Count" DataField="Total_Count" UniqueName="Total_Count"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Insert Count" DataField="Insert_Count" UniqueName="Insert_Count" Display="false"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Update_Count" DataField="Update_Count" UniqueName="Update_Count" Display="false"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Error_Count" DataField="Error_Count" UniqueName="Error_Count" Display="false"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="User_Name" DataField="User_Name" UniqueName="User_Name" Display="false"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="InsertStatus" DataField="InsertStatus" UniqueName="InsertStatus"> </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Remarks" DataField="Remarks" UniqueName="Remarks" Display="false"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Last Updated Time" DataField="Last_Updated_Time" UniqueName="Last_Updated_Time" DataType="System.DateTime" DataFormatString="{0:dd/MMM/yyyy}"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Processed Count" DataField="Processed_Count" UniqueName="Processed_Count"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Is Deleted" DataField="IsDeleted" UniqueName="IsDeleted" Display="false"></telerik:GridBoundColumn>
                                                 <telerik:GridBoundColumn HeaderText="Time Remaining" DataField="Time_Remaining" UniqueName="Time_Remaining" Display="false"></telerik:GridBoundColumn>
                                            </Columns>
                                        </MasterTableView>
        </telerik:radgrid>
                  </div>
            </div>
             </div>
        </div>
      </div>
        </div>
     <script>
       $(document).ready(function () {
           $("#content").find("[id^='tab']").hide(); // Hide all content
           $("#tabs li:first").attr("id", "current"); // Activate the first tab
           $("#content #tab1").fadeIn(); // Show first tab's content

           $('#tabs a').click(function (e) {
               e.preventDefault();
               if ($(this).closest("li").attr("id") == "current") { //detection for current tab
                   return;
               }
               else {
                   $("#content").find("[id^='tab']").hide(); // Hide all content
                   $("#tabs li").attr("id", ""); //Reset id's
                   $(this).parent().attr("id", "current"); // Activate this
                   $('#' + $(this).attr('name')).fadeIn(); // Show content for the current tab
               }
           });
       });
</script> 
</asp:Content>
