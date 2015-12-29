<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="ImportStatusList.aspx.cs" Inherits="FlyCn.ExcelImport.ImportStatusList" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
      <script src="../Scripts/jquery-1.8.2.js"></script>
     <script src="../Scripts/jquery-1.8.2.min.js"></script>
     <script src="../Scripts/jquery-ui-1.8.24.js"></script>
     <script src="../Scripts/jquery-ui-1.8.24.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style type="text/css">


        .headings {
            font-family: 'segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            font-size: 15px;
            font-style: normal;
            color: #009933;
        }

        td.myclass {
            text-align: left;
            width: 100px;
        }

        td.size {
            text-align: left;
            width: 200px;
        }

        
        
    </style>
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"> 
    </asp:ScriptManager>

    <div class="container" style="width: 100%">
         <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" Width="300px" OnClientTabSelected="onClientTabSelected" CausesValidation="false" SelectedIndex="0" Skin="FlyCnRed_Rad" EnableEmbeddedSkins="false">

            <Tabs>
                <telerik:RadTab Text="Ongoing" PageViewID="rpList" Value="1" Width="150px" runat="server" Selected="True"></telerik:RadTab>
                <telerik:RadTab Text="Completed" PageViewID="rpApproval" Value="2" Width="150px" runat="server"></telerik:RadTab>
            </Tabs>
          </telerik:RadTabStrip>


        <div id="content">
            <div class="contentTopBar"></div>
               <table style="width: 100%">
                <tr>
                  <td>
                       <telerik:RadMultiPage ID="RadMultiPage1" runat="server" Width="100%" SelectedIndex="0" CssClass="outerMultiPage">
                        <telerik:RadPageView ID="rpList" runat="server">
                        <div id="divList" style="width: 100%;text-align:center">
             <telerik:radgrid ID="RadGrid1" runat="server" OnItemCommand="RadGrid1_ItemCommand" OnNeedDataSource="RadGrid1_NeedDataSource">
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
                        </telerik:RadPageView>


      
         <telerik:RadPageView ID="rpApproval" runat="server">
                                 
        
              <div>
            <div class="contentTopBar"></div>
                  <telerik:radgrid ID="RadGrid2" runat="server" OnNeedDataSource="RadGrid2_NeedDataSource">
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
                          
                    </telerik:RadPageView>
                          
                          </telerik:RadMultiPage>
                        </td>
              </tr>
           </table>
                      </div>
                  </div>
       
    <script type="text/javascript">
        

       
            function onClientTabSelected(sender, args) {
                debugger;
                var tab = args.get_tab();
                if (tab.get_value() == '2') {

                   
                }
                if (tab.get_value() == "1") {

                    
                    var tabStrip = $find("<%= RadTabStrip1.ClientID %>");
                    var tab = tabStrip.findTabByValue("1");
                    tab.select();
                }

            }
    
    
</script>
</asp:Content>
