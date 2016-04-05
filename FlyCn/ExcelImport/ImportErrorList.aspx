<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="ImportErrorList.aspx.cs" Inherits="FlyCn.ExcelImport.ImportErrorList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik"%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
          
        }
        #tabs li a {
	
	

	

	display:block;

	
	text-decoration:none;
	
}
    </style>
    
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
</asp:ScriptManager>
    
<script type="text/javascript">
   
    function RadGrid1_ErrorList_ItemCommandClient() {
      
        //document.getElementById('<%=Divtab1.ClientID %>').style.display = "none";
        //document.getElementById('<%=Divtab2.ClientID %>').style.display = "";
    }
    function MyTab1()
    {
       
        var litab1 = document.getElementById('<%=Divtab1.ClientID %>');
        litab1.style.display = "";
        document.getElementById('<%=Divtab2.ClientID %>').style.display = "none";
       
   }
    
</script>



     <div class="PageHeading">Error List</div>
    <div class="container inputMainContainer"  >
  <div class="col-md-12"   >
         <ul id="tabs">
         <li><a href="#" onclick="MyTab1();" name="tabs1">Error List</a></li>
         <li><a href="#" name="tabs2">Error Details</a></li>
         </ul>
          <div id="content"  >
             <div id="Divtab1" runat="server">
              <div role="tabpanel" class="tab-pane active" id="List">
              <div class="table-responsive">
            <div class="contentTopBar"></div>
             <telerik:radgrid ID="RadGrid1_ErrorList" runat="server"  OnItemCommand="RadGrid1_ItemCommand" OnItemDataBound="RadGrid1_ErrorList_ItemDataBound">
             <HeaderStyle  HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Left" />
                                        <AlternatingItemStyle HorizontalAlign="Left" />
                                        <ClientSettings>
                                            <Selecting AllowRowSelect="true" EnableDragToSelectRows="false" />
                                       
                                        </ClientSettings>
                                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="Status_ID">
                                            <Columns>
                                               

                                                <telerik:GridButtonColumn CommandName="Select" ButtonType="ImageButton" ImageUrl="~/Images/Document Next-WF.png" UniqueName="EditData">
                                                </telerik:GridButtonColumn>

                                                  <telerik:GridBoundColumn HeaderText="Status ID" DataField="Status_ID" UniqueName="Status_ID" Display="false"></telerik:GridBoundColumn>
                                                  <telerik:GridBoundColumn HeaderText="Project No" DataField="ProjNo" UniqueName="ProjNo" ></telerik:GridBoundColumn>
                                                  <telerik:GridBoundColumn HeaderText="File Name" DataField="File_Name" UniqueName="File_Name" ></telerik:GridBoundColumn>
                                                  <telerik:GridBoundColumn HeaderText="Table Name" DataField="Table_Name" UniqueName="Table_Name" ></telerik:GridBoundColumn>
                                                  <telerik:GridBoundColumn HeaderText="Error_Count" DataField="Error_Count" UniqueName="Error_Count" ></telerik:GridBoundColumn>
                                                  <telerik:GridBoundColumn HeaderText="Started Time" DataField="Start_Time" UniqueName="Start_Time"  ></telerik:GridBoundColumn>
                                                
                                            </Columns>
                                        </MasterTableView>
                                    </telerik:radgrid>
                                  </div>
                           </div>
                          </div>
             <div id="Divtab2" runat="server">
              <div role="tabpanel" class="tab-pane active" id="Details">
              <div class="table-responsive">
            <div class="contentTopBar"></div>
                  
             <telerik:radgrid ID="RadGrid1_ErrorDetails" runat="server" Width="100%" OnNeedDataSource="RadGrid1_ErrorDetails_NeedDataSource" OnPreRender="RadGrid1_ErrorDetails_PreRender">
              <HeaderStyle  HorizontalAlign="Center" />
              <ItemStyle HorizontalAlign="Left" />
              <AlternatingItemStyle HorizontalAlign="Left" />
              <ClientSettings>
              <Selecting AllowRowSelect="true" EnableDragToSelectRows="false" />
                 
              </ClientSettings>
              <MasterTableView AutoGenerateColumns="False" DataKeyNames="Status_Id">
              <Columns>                             
                       <telerik:GridBoundColumn HeaderText="Row NO" DataField="Excel_RowNO" UniqueName="Excel_RowNO" ItemStyle-Width="25%" ></telerik:GridBoundColumn>
                       <telerik:GridBoundColumn HeaderText="Key Field" DataField="Key_Field" UniqueName="Key_Field" ItemStyle-Width="25%" ></telerik:GridBoundColumn>
                       <telerik:GridBoundColumn HeaderText="Error Description" DataField="Error_Description" UniqueName="Error_Description" ItemStyle-Width="50%"></telerik:GridBoundColumn>       
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
