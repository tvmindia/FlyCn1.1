<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="ManageAccess.aspx.cs" Inherits="FlyCn.FlycnSecurity.ManageAccess" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link href="../Content/themes/FlyCnGreen/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.11.3.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/jquery-1.8.2.js"></script>
    

    <script type="text/javascript">
        $(document).ready(function () {
            EnableButtonsForSave();
            <%=ToolBar.ClientID %>_hideNotification();

        });
        function EnableButtonsForSave() {

            <%=ToolBar.ClientID %>_SetAddVisible(false);
            <%=ToolBar.ClientID %>_SetSaveVisible(true);
            <%=ToolBar.ClientID %>_SetUpdateVisible(false);
            <%=ToolBar.ClientID %>_SetDeleteVisible(false);

        }

    </script>




 <%--<script type=
"text/javascript"
>

     function Checked(btn) {
         alert(btn);
         var grid = $find("<%=RadGrid1.ClientID %>");
        var masterTable = grid.get_masterTableView();
        var btnValue = btn.value;
        for (var i = 0; i < masterTable.get_dataItems().length; i++) {
            var gridItemElement = masterTable.get_dataItems()[i].findElement("Edit");
            if (btnValue == "Check") {
                gridItemElement.checked = true;
                btn.value = "UnCheck";
            }
            else {
                gridItemElement.checked = false;
                btn.value = "Check";
            }
        }
    }
</script>--%> 

     <script>
         function CheckChanged(checkbox, checkboxId, rowindex,tbl) {
             debugger;
            

              var grid = $find("<%=RadGrid1.ClientID %>");
             
            var MasterTable = grid.get_masterTableView();
           
             var len = MasterTable.get_dataItems().length;

             //alert(len);
             

             var Row = MasterTable.get_dataItems()[rowindex];
             

             if (Row._expanded == false) { Row.set_expanded("true"); }

             var childRows = Row.get_nestedViews()[0].get_dataItems();
             //var childRows = MasterTable.get_nestedViews()[0].get_dataItems();
             //var childRows = MasterTable.get_dataItems();


             var dataItems = MasterTable.get_dataItems();
             for (var i = 0; i < childRows.length; i++) {
                                   
                 childRows[i].findElement(checkboxId).checked = checkbox.checked;
                     var nestedView = childRows[i].get_nestedViews()[0];
                     var items =  nestedView.get_dataItems();
                     for (var j = 0; j < items.length; j++) {
                         items[j].findElement(checkboxId).checked = checkbox.checked;
                   
                 }
            }
        }
    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="container" style="width:100%;">

            <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Add Special features</h4>
            
        </div>
        <div class="modal-body" >
            <asp:TextBox ID="txtSpecial" runat="server" TextMode="multiline" Columns="50" Rows="10" Height="100"></asp:TextBox>
        </div>
    <div class="modal-footer">
   <button data-dismiss="modal" class="btn  btn-large"> Close</button>
   <asp:Button runat="server" ID="btnSpecial" Text="Add"  class="btn btn-large"  OnClick="btnSpecial_Click" />
</div>
      </div>
      
    </div>
  </div>

        <div class=" importWizardContainer">
 <div class="col-md-12">
     <uc1:ToolBar runat="server" ID="ToolBar" />
    </div>
           <asp:UpdatePanel ID="updpnl" runat="server">
    <ContentTemplate>
     <div class="demo-container no-bg">
    <asp:DropDownList ID="DropDownListObjReg" runat="server" AutoPostBack="true" AppendDataBoundItems="true"  OnSelectedIndexChanged="DropDownListObjReg_SelectedIndexChanged"></asp:DropDownList>
        <telerik:RadGrid RenderMode="Lightweight" ID="RadGrid1" runat="server" ShowStatusBar="true" AutoGenerateColumns="false"
             AllowSorting="True" AllowMultiRowSelection="true"  OnPageIndexChanged="RadGrid1_PageIndexChanged" OnItemDataBound="RadGrid1_ItemDataBound"
            OnDetailTableDataBind="RadGrid1_DetailTableDataBind" OnNeedDataSource="RadGrid1_NeedDataSource" OnPreRender="RadGrid1_PreRender"
  OnItemCreated="RadGrid1_ItemCreated" RetainExpandStateOnRebind="true"   EnableViewState="false" AutoPostBack="false" Width="100%"  >
             <ClientSettings EnablePostBackOnRowClick="false"  >
    <Resizing AllowColumnResize="false" AllowRowResize="false" ResizeGridOnColumnResize="false"  
     EnableRealTimeResize="false" />
               
  </ClientSettings>
        
         
            <MasterTableView DataKeyNames="LevelID,ObjId,LevelDesc,Add,Edit,Delete,ReadOnly" AllowMultiColumnSorting="True"  HierarchyLoadMode="Client"
                TableLayout="Auto"  EnableViewState="true"  AllowPaging="true" PageSize="9"  ItemStyle-Width="100%"   >

                <Columns>
                             
                                    <telerik:GridBoundColumn SortExpression="LevelDesc" HeaderText="LevelDesc" HeaderButtonType="TextButton"
                                        DataField="LevelDesc"  >
                                          <ItemStyle Width="30%" Wrap="False" />
                                    </telerik:GridBoundColumn>
<telerik:GridTemplateColumn UniqueName="CheckTemp" HeaderText="Add"  ItemStyle-Width="14%"  > 
               <ItemTemplate> 
                   <asp:CheckBox ID="ChkAdd" Checked='<%# (DataBinder.Eval(Container.DataItem,"Add") is DBNull ?false:Eval("Add")) %>' runat="server"   /> 
               </ItemTemplate> 
  </telerik:GridTemplateColumn> 
                                                  <telerik:GridTemplateColumn UniqueName="CheckEdit" HeaderText="Edit"  ItemStyle-Width="14%" > 
               <ItemTemplate> 
                   <asp:CheckBox ID="ChkEdit" runat="server" Checked='<%# (DataBinder.Eval(Container.DataItem,"Edit") is DBNull ?false:Eval("Edit")) %>' /> 
               </ItemTemplate>  
                                                      </telerik:GridTemplateColumn> 
                        <telerik:GridTemplateColumn UniqueName="CheckDelete" HeaderText="Delete" ItemStyle-Width="14%" > 
               <ItemTemplate> 
                   <asp:CheckBox ID="ChkDelete" runat="server" Checked='<%# (DataBinder.Eval(Container.DataItem,"Delete") is DBNull ?false:Eval("Delete")) %>' /> 
               </ItemTemplate>  
                                                      </telerik:GridTemplateColumn>    
                  <telerik:GridTemplateColumn UniqueName="CheckReadOnly" HeaderText="ReadOnly" ItemStyle-Width="14%"  > 
               <ItemTemplate> 
                   <asp:CheckBox ID="ChkReadOnly" runat="server" Checked='<%# (DataBinder.Eval(Container.DataItem,"ReadOnly") is DBNull ?false:Eval("ReadOnly")) %>' /> 
               </ItemTemplate>  
                                                      </telerik:GridTemplateColumn>    
                    <telerik:GridTemplateColumn UniqueName="Special" HeaderText="Special"   ItemStyle-Width="14%"> 
               <ItemTemplate> 
                   <img src="../Images/plus1.png"   data-toggle="modal" data-target="#myModal"/>
               </ItemTemplate>  
                                                      </telerik:GridTemplateColumn>
                                </Columns>

                <DetailTables  >
                    <telerik:GridTableView DataKeyNames="LevelID,ObjId,LevelDesc,Add,Edit,Delete,ReadOnly" Name="Child" Width="100%"  
                         EnableHeaderContextMenu="false"   HierarchyLoadMode="Client" ShowHeader="False" EnableViewState="false" ItemStyle-Width="100%" >
                      
                          <Columns>
                             
                                    <telerik:GridBoundColumn SortExpression="LevelDesc" HeaderText="LevelDesc" HeaderButtonType="TextButton"
                                     DataField="LevelDesc" HeaderStyle-Width="28.8%"  >
                                        <ItemStyle Width="28.8%" Wrap="false" />
                                    </telerik:GridBoundColumn>
                              <telerik:GridTemplateColumn UniqueName="CheckTemp" HeaderText="Add"  ItemStyle-Width="14.24%"  HeaderStyle-Width="14.24%"> 
               <ItemTemplate> 
                   <asp:CheckBox ID="ChkAdd" runat="server"  Checked='<%# (DataBinder.Eval(Container.DataItem,"Add") is DBNull ?false:Eval("Add")) %>'  /> 
               </ItemTemplate> 
  </telerik:GridTemplateColumn> 
                                                  <telerik:GridTemplateColumn UniqueName="CheckEdit" HeaderText="Edit" ItemStyle-Width="14.24%" HeaderStyle-Width="14.24%"  > 
               <ItemTemplate> 
                   <asp:CheckBox ID="ChkEdit" runat="server"  Checked='<%# (DataBinder.Eval(Container.DataItem,"Edit") is DBNull ?false:Eval("Edit")) %>'  /> 
               </ItemTemplate>  
                                                      </telerik:GridTemplateColumn> 
                         <telerik:GridTemplateColumn UniqueName="CheckDelete" HeaderText="Delete" ItemStyle-Width="14.24%" HeaderStyle-Width="14.24%" > 
               <ItemTemplate> 
                   <asp:CheckBox ID="ChkDelete" runat="server" Checked='<%# (DataBinder.Eval(Container.DataItem,"Delete") is DBNull ?false:Eval("Delete")) %>' /> 
               </ItemTemplate>  
                                                      </telerik:GridTemplateColumn>    
                  <telerik:GridTemplateColumn UniqueName="CheckReadOnly" HeaderText="ReadOnly" ItemStyle-Width="14.24%"  HeaderStyle-Width="14.24%"> 
               <ItemTemplate> 
                   <asp:CheckBox ID="ChkReadOnly" runat="server" Checked='<%# (DataBinder.Eval(Container.DataItem,"ReadOnly") is DBNull ?false:Eval("ReadOnly")) %>' /> 
               </ItemTemplate>  
                                                      </telerik:GridTemplateColumn>   
                             <telerik:GridTemplateColumn UniqueName="Special" HeaderText="Special"  HeaderStyle-Width="14.24%" ItemStyle-Width="14.24%"> 
               <ItemTemplate> 
                    <img src="../Images/plus1.png"  data-toggle="modal" data-target="#myModal" />
               </ItemTemplate>  
                                                      </telerik:GridTemplateColumn>     
                                </Columns>

                        <DetailTables>

                            <telerik:GridTableView DataKeyNames="LevelID,ObjId,LevelDesc,Add,Edit,Delete,ReadOnly" Name="Child" Width="100%"  
                                 HierarchyLoadMode="Client" EnableHeaderContextMenu="false" ShowHeader="False" EnableViewState="false" 
                                 HeaderStyle-Width="100%" ItemStyle-Width="100%"    >

                                <Columns>
                         
                                    <telerik:GridBoundColumn SortExpression="LevelDesc" HeaderText="LevelDesc" HeaderButtonType="TextButton"
                                        DataField="LevelDesc" HeaderStyle-Width="27.52%"  >
                                            <ItemStyle Width="27.52%" Wrap="False"  />
                                    </telerik:GridBoundColumn>

                                      <telerik:GridTemplateColumn UniqueName="CheckTemp" HeaderText="Add" ItemStyle-Width="14.496%" HeaderStyle-Width="14.496%" > 
               <ItemTemplate> 
                   <asp:CheckBox ID="ChkAdd" runat="server"  Checked='<%# (DataBinder.Eval(Container.DataItem,"Add") is DBNull ?false:Eval("Add")) %>'  /> 
               </ItemTemplate> 
  </telerik:GridTemplateColumn> 
                                                  <telerik:GridTemplateColumn UniqueName="CheckEdit" HeaderText="Edit" ItemStyle-Width="14.496%" HeaderStyle-Width="14.496%"> 
               <ItemTemplate> 
                   <asp:CheckBox ID="ChkEdit" Checked='<%# (DataBinder.Eval(Container.DataItem,"Edit") is DBNull ?false:Eval("Edit")) %>' runat="server" /> 
               </ItemTemplate>  
                                                      </telerik:GridTemplateColumn> 
                    <telerik:GridTemplateColumn UniqueName="CheckDelete" HeaderText="Delete"  ItemStyle-Width="14.496%" HeaderStyle-Width="14.496%"> 
               <ItemTemplate> 
                   <asp:CheckBox ID="ChkDelete" runat="server" Checked='<%# (DataBinder.Eval(Container.DataItem,"Delete") is DBNull ?false:Eval("Delete")) %>' /> 
               </ItemTemplate>  
                                                      </telerik:GridTemplateColumn>    
                  <telerik:GridTemplateColumn UniqueName="CheckReadOnly" HeaderText="ReadOnly" ItemStyle-Width="14.496%" HeaderStyle-Width="14.496%" > 
               <ItemTemplate> 
                   <asp:CheckBox ID="ChkReadOnly" runat="server" Checked='<%# (DataBinder.Eval(Container.DataItem,"ReadOnly") is DBNull ?false:Eval("ReadOnly")) %>' /> 
               </ItemTemplate>  
                                                      </telerik:GridTemplateColumn>    
                                    <telerik:GridTemplateColumn UniqueName="Special" HeaderText="Special"  HeaderStyle-Width="14.496%" ItemStyle-Width="14.496%"> 
               <ItemTemplate> 
                    <img src="../Images/plus1.png"  data-toggle="modal" data-target="#myModal"/>
               </ItemTemplate>  
                                                      </telerik:GridTemplateColumn>
                                </Columns>

                                <DetailTables>

                            <telerik:GridTableView DataKeyNames="LevelID,ObjId,LevelDesc,Add,Edit,Delete,ReadOnly" Name="Child" Width="100%"  
                                 HierarchyLoadMode="Client" EnableHeaderContextMenu="false" ShowHeader="False" EnableViewState="false"  >

                                <Columns>
                         
                                    <telerik:GridBoundColumn SortExpression="LevelDesc" HeaderText="LevelDesc" HeaderButtonType="TextButton"
                                        DataField="LevelDesc" HeaderStyle-Width="27.5%"  >
                                            <ItemStyle Width="27.5%" Wrap="False" />
                                    </telerik:GridBoundColumn>

                                      <telerik:GridTemplateColumn UniqueName="CheckTemp" HeaderText="Add" ItemStyle-Width="14.5%" HeaderStyle-Width="14.5%"> 
               <ItemTemplate> 
                   <asp:CheckBox ID="ChkAdd" runat="server"  Checked='<%# (DataBinder.Eval(Container.DataItem,"Add") is DBNull ?false:Eval("Add")) %>'  /> 
               </ItemTemplate> 
  </telerik:GridTemplateColumn> 
                                                  <telerik:GridTemplateColumn UniqueName="CheckEdit" HeaderText="Edit" ItemStyle-Width="14.5%" HeaderStyle-Width="14.5%"> 
               <ItemTemplate> 
                   <asp:CheckBox ID="ChkEdit" Checked='<%# (DataBinder.Eval(Container.DataItem,"Edit") is DBNull ?false:Eval("Edit")) %>' runat="server" /> 
               </ItemTemplate>  
                                                      </telerik:GridTemplateColumn> 
                    <telerik:GridTemplateColumn UniqueName="CheckDelete" HeaderText="Delete"  ItemStyle-Width="14.5%" HeaderStyle-Width="14.5%"> 
               <ItemTemplate> 
                   <asp:CheckBox ID="ChkDelete" runat="server" Checked='<%# (DataBinder.Eval(Container.DataItem,"Delete") is DBNull ?false:Eval("Delete")) %>' /> 
               </ItemTemplate>  
                                                      </telerik:GridTemplateColumn>    
                  <telerik:GridTemplateColumn UniqueName="CheckReadOnly" HeaderText="ReadOnly" ItemStyle-Width="14.5%" HeaderStyle-Width="14.5%" > 
               <ItemTemplate> 
                   <asp:CheckBox ID="ChkReadOnly" runat="server" Checked='<%# (DataBinder.Eval(Container.DataItem,"ReadOnly") is DBNull ?false:Eval("ReadOnly")) %>' /> 
               </ItemTemplate>  
                                                      </telerik:GridTemplateColumn>    
                                    <telerik:GridTemplateColumn UniqueName="Special" HeaderText="Special"  HeaderStyle-Width="14.5%" ItemStyle-Width="14.5%"> 
               <ItemTemplate> 
                    <img src="../Images/plus1.png" data-toggle="modal" data-target="#myModal"/>
               </ItemTemplate>  
                                                      </telerik:GridTemplateColumn>
                                </Columns>

                            </telerik:GridTableView>
                        </DetailTables>
                            </telerik:GridTableView>
                        </DetailTables>
                        
                    </telerik:GridTableView>
                </DetailTables>
                
            </MasterTableView>
        </telerik:RadGrid>
       
    </div>
           

    </ContentTemplate>
           </asp:UpdatePanel>
            </div>
    <asp:Button ID="Button1" runat="server" Text="SAVE"  OnClick="Button1_Click" BackColor="Blue" ForeColor="White"/>
            <asp:Label ID="lblError" runat="server" Text="" ForeColor="Green"></asp:Label>


         <div></div>
             
  
</div>


</asp:Content>
