<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="DynamicMaster.aspx.cs" Inherits="FlyCn.FlyCnMasters.DynamicMaster" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
    <style type="text/css">
  .RadWindow .rwDialogPopup
   {
    color:Blue !important;// customizing popup window
   }
  .RadWindow .rwWindowContent .rwPopupButton .rwInnerSpan
  {
     color:Red !important;// customizing the text in popup window
  }
</style>
    <script ></script>
    
      <%--<script type="text/javascript">

          function DisplayFunction() {



              document.getElementById('div2').style.display = "";
              document.getElementById('div1').style.display = "none";
              document.getElementById('Display').style.backgroundColor = "#00CDCD";
              document.getElementById('Display').style.color = "#FFFFFF";
              document.getElementById('ADD').style.backgroundColor = "";
              document.getElementById('ADD').style.color = "";
          }
    </script>--%>
     <%--<script type="text/javascript">
         function ADDFunction() {


             document.getElementById('div1').style.display = "";
             document.getElementById('div2').style.display = "none";
             document.getElementById('ADD').style.backgroundColor = "#00CDCD";
             document.getElementById('Display').style.backgroundColor = "";
             document.getElementById('ADD').style.color = "#FFFFFF";
             document.getElementById('Display').style.color = "";
             document.getElementById('<%=Button1.ClientID %>').style.visibility = "hidden";
             document.getElementById('<%=Button2.ClientID %>').style.visibility = "visible";
             $("input:text").val('');


         }
    </script>--%>

    <script type="text/javascript">
        function onClientTabSelected(sender, args) {
            var tab = args.get_tab();
            if (tab.get_text() == "New") {
                document.getElementById('div1').style.display = "";
                document.getElementById('div2').style.display = "none";
                document.getElementById('<%=Button1.ClientID %>').style.visibility = "hidden";
                document.getElementById('<%=Button2.ClientID %>').style.visibility = "visible";
               // document.getElementsByTagName('input').style.display = "none";
                $("input:text").val('');
                //$('input[type=text]').each(function () {
                //    $(this).val('');
                //});
              <%--  $find("<%="input:text" %>").val('');--%>


            }
            else if (tab.get_text() == "View") {

                document.getElementById('div2').style.display = "";
                document.getElementById('div1').style.display = "none";
            }

        }


        </script>

       <script type="text/javascript">
           function UpdateFunction() {


               document.getElementById('div1').style.display = "";
               document.getElementById('div2').style.display = "none";
               document.getElementById('<%=Button2.ClientID %>').style.visibility = "hidden";
               document.getElementById('<%=Button1.ClientID %>').style.visibility = "visible";


           }
    </script>
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <p>
        <br />
    </p>

    <p>
        &nbsp;</p>
    <%--class="HomeBox2"--%>
    <div  class="inputMainContainer" style="width:100%;text-align:center;vertical-align:middle"  >
        <asp:Label ID="lblmasterName" runat="server" Text="Label" CssClass="title"></asp:Label>  Master
        <br/>
        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" Width="300px" OnClientTabSelected="onClientTabSelected"
             CausesValidation="false"   SelectedIndex="0" >
            <Tabs>
                <telerik:RadTab Text="View" PageViewID="rpList" Value="1" Width="150px" runat="server" ImageUrl="~/Images/Icons/ListIcon.png"  ></telerik:RadTab>
                 <telerik:RadTab Text="New" PageViewID="rpAddEdit" Value="2" Width="150px" runat="server" ImageUrl="~/Images/Icons/NewIcon.png"  ></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
     <%--   <div align="left" >
           <input id="Display" type="button" value="List" style="background-color:#00CDCD; color:white;" align="left" onclick="DisplayFunction()"/>
           <input id="ADD" type="button" value="New"  align="left"  onclick="ADDFunction()"/>
        </div>--%>
        <div  id="div1" style ="display:none;">
        <div id="placeholder" runat="server" style="text-align:left"></div>
            <br />
            <br />
            <div>
                                 <asp:Button ID="Button2" runat="server" Text="Add"  style="background-color:#008B8B; color:white;"  OnClick="Button2_Click" ClientIDMode="Static" ValidationGroup="Submit" />
                                <asp:Button ID="Button1" runat="server" Text="Update" style="background-color:#008B8B; color:white;"  OnClick="Button1_Click" ClientIDMode="Static" />

            </div>
            </div>
    <!-- here is where the dinamically created elements will be placed -->
         <div id="div2" >
         <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
</asp:ScriptManager>
             <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="0"
                 GridLines="None" OnNeedDataSource="RadGrid1_NeedDataSource1" AllowPaging="true" ItemStyle-HorizontalAlign="Left" AlternatingItemStyle-HorizontalAlign="Left"
                 PageSize="10" AllowAutomaticDeletes="True" OnItemCommand="RadGrid1_ItemCommand"  AllowMultiRowEdit="true"  DataKeyNames="Code"  CommandItemDisplay="Right">
<MasterTableView   >
     
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
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
