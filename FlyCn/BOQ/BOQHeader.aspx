<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="BOQHeader.aspx.cs" Inherits="FlyCn.BOQ.BOQHeader" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- styles should move to css file, taken from Construction punchlist.aspx  --%>
      <style type="text/css">
        .selectbox {
            width: 52%;
            height: 25px;
            background-color: #FFF;
            font: 400 12px/18px 'Open Sans', sans-serif;
            color: #000;
            font-weight: normal;
            border: 1px solid #ccc;
            margin: 5px 0 0 0;
            padding: 5px;
        }

        .textbox {
            width: 48%;
            height: 10px;
            background-color: #FFF;
            font: 400 12px/18px 'Open Sans', sans-serif;
            color: #000;
            font-weight: normal;
            border: 1px solid #ccc;
            margin: 5px 0 0 0;
            padding: 5px;
        }

        .rediobutton {
            width: 30px;
            height: 18px;
            background-color: #FFF;
            font: 400 12px/18px 'Open Sans', sans-serif;
            color: #000;
            font-weight: normal;
            border: 1px solid #ccc;
            margin: 5px 0 0 0;
            padding: 5px;
        }

        .content {
            border: 1px solid #BDBDBD;
            width: 91%;
            padding: 5px;
            margin: 0px 0 0 5px;
        }

        .textarea {
            margin-top: 250%;
            left: 0%;
            width: 150px;
        }

        .hdnField {
            display: none;
        }

        .tabletd {
            width: 280px;
        }

        .tabletbody {
            width: 400px;
        }
    </style>
     <%-- styles should move to css file  --%>

</asp:Content>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik"%>
<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>
 <%-- second part  --%>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
          function onClientTabSelected(sender, args) {
              debugger;
              var tab = args.get_tab();
              if (tab.get_text() == "View") {

                  var tabStrip = $find("<%= RadTabStrip1.ClientID %>");
                  var tab = tabStrip.findTabByText("View");
                  tab.select();
                  var tab1 = tabStrip.findTabByText("Edit");
                  tab1.set_text("New");
                  $('input[type=text]').each(function () {
                      $(this).val('');
                  });
                
                  $('textarea').empty();
                 

              }
          
                  $('input[type=text]').each(function () {
                      $(this).val('');
                  });
                  $('textarea').empty();
              }
          
              function onClientTabSelected(sender, args) {
                  var tab = args.get_tab();
                  if (tab.get_value() == '2') {
                      //new clicked 
                      $('input[type=text]').each(function () {
                          $(this).val('');
                      });
                     
                     
                      $('textarea').empty();
                      
                      debugger;
                      try {
                          <%=ToolBar.ClientID %>_SetAddVisible(false);
                          <%=ToolBar.ClientID %>_SetSaveVisible(true);
                          <%=ToolBar.ClientID %>_SetUpdateVisible(false);
                          <%=ToolBar.ClientID %>_SetDeleteVisible(false);
                        
                      } catch (x) { alert(x.message); }

                     

                  }

                  if (tab.get_value() == "1") {

                      var tabStrip = $find("<%= RadTabStrip1.ClientID %>");
                      var tab = tabStrip.findTabByValue("1");
                      tab.select();
                      var tab1 = tabStrip.findTabByValue("2");
                      tab1.set_text("New");
                  }

              }
          function OnClientButtonClicking(sender, args) {

              var btn = args.get_item();
              if (btn.get_value() == 'Delete') {

                  args.set_cancel(!confirm('Do you want to delete ?'));
              }


          }
   </script>
    <%-- Html starts here --%>

     <p class="">Bills of Quantity</p>
      <hr/>
    <%-- Top div starts here --%>
    <div class="inputMainContainer">
    <div class="innerDiv">
        <%-- inner div starts here --%>
        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" Width="300px" OnClientTabSelected="onClientTabSelected"
             CausesValidation="false"   SelectedIndex="0" Skin="Silk">
            
            <Tabs>
                 <telerik:RadTab Text="View" PageViewID="rpList" Value="1" Width="150px" runat="server" ImageUrl="~/Images/Icons/ListIcon.png" Selected="True" ></telerik:RadTab>
                 <telerik:RadTab Text="New" PageViewID="rpAddEdit" Value="2" Width="150px" runat="server" ImageUrl="~/Images/Icons/NewIcon.png"  ></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>

        <table style="width:100%">
    <tr>
        <td>
            &nbsp
        </td>
        <td>

        <telerik:RadMultiPage ID="RadMultiPage1" runat="server" Width="100%" SelectedIndex="0" CssClass="outerMultiPage">
            <telerik:RadPageView ID="rpList" runat="server">
               
    <div id="divList" style="width:100%">

      
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
            </asp:ScriptManager>

            
    
             <telerik:RadGrid ID="RadGrid1" runat="server"  CellSpacing="0" GridLines="None" AllowPaging="true" PageSize="10" Width="984px" Skin="Silk" >
             <MasterTableView AutoGenerateColumns="False" DataKeyNames="ProjectNo,IDNo,EILType">
    <Columns>
     <telerik:GridBoundColumn HeaderText="Project No" DataField="ProjectNo" UniqueName="ProjectNo"></telerik:GridBoundColumn> 
     <telerik:GridBoundColumn HeaderText="ID No" DataField="IDNo" UniqueName="IDNo"></telerik:GridBoundColumn>
     <telerik:GridBoundColumn HeaderText="LinkIDNo" DataField="LinkIDNo" UniqueName="LinkIDNo"></telerik:GridBoundColumn> 
     <telerik:GridBoundColumn HeaderText="EILType" DataField="EILType" UniqueName="EILType"></telerik:GridBoundColumn> 
     <telerik:GridBoundColumn HeaderText="OpenBy" DataField="OpenBy" UniqueName="OpenBy"></telerik:GridBoundColumn> 
     <telerik:GridBoundColumn HeaderText="OpenDt" DataField="OpenDt" UniqueName="OpenDt" DataType="System.DateTime"  DataFormatString="{0:M/d/yyyy}"></telerik:GridBoundColumn> 
     <telerik:GridButtonColumn CommandName="EditData" Text="Edit" UniqueName="EditData" ButtonType="ImageButton" ImageUrl="~/Images/Icons/Pencil-01.png"></telerik:GridButtonColumn>     
     <telerik:GridButtonColumn CommandName="DeleteColumn" Text="Delete" UniqueName="DeleteColumn" ButtonType="ImageButton" ImageUrl="~/Images/Cancel.png" ConfirmDialogType="RadWindow" ConfirmText="Are you sure, you want to delete this item ?">
      </telerik:GridButtonColumn>
    </Columns>
  </MasterTableView>            
             </telerik:RadGrid>
     
</div>
</telerik:RadPageView>
          
    <telerik:RadPageView ID="rpAddEdit" runat="server">
        <uc1:ToolBar runat="server" ID="ToolBar" />

           <table style="width:100%;">
          <tr><td>    <asp:Label ID="msg" runat="server" Text=""></asp:Label>
          </td></tr>
  
              <tr><td colspan="5" class="tabletbody" style="border-bottom:2px">Tracking Details</td></tr>
               
              <tr>
                  <td class="tabletbody">
                      Document No
                  </td>
                  <td class="tabletbody">
                       <asp:TextBox ID="txtDocumentno" runat="server" CssClass="textbox"></asp:TextBox>
                       </td>
                  <td class="tabletbody">
                      Client Document No
                  </td>
                  <td class="tabletbody">
                     <asp:TextBox ID="txtClientdocno" runat="server" CssClass="textbox" ></asp:TextBox>
                  </td>
                 
              </tr>
              <tr>
                   <td class="tabletbody">Revision No</td>
                  <td class="tabletbody">
                      <asp:TextBox ID="txtRevisionno" runat="server" CssClass="textbox" ></asp:TextBox>
                  </td>
                 
              </tr>
              <tr>
                   <td></td>
                  <td>
                  </td>
                  <td>
                      
                  </td>
                  <td>
                      
                  </td>
              </tr>
             </table>
        <hr />
        <table style="width:100%;">
              <tr>
                   <td  colspan="5" class="sectionHeader" >General Details</td>
              </tr>
        <tr>
            <td class="tabletd">
                Document Date
            </td>
          
            <td class="tabletd">

                <asp:TextBox ID="txtIDocumentdate" runat="server" CssClass="textbox" ></asp:TextBox>
              
             </td>
            
        </tr>
        <tr >
            <td class="tabletd">
             <asp:Label ID="Label5" runat="server" Text="Document Title"></asp:Label>
            </td>
            <td class="tabletd">
                
                 <asp:TextBox ID="txtDocumenttitle" runat="server" CssClass="textbox" ></asp:TextBox>               
            </td>
            <td class="tabletd">Remarks</td>
            <td>
              <asp:TextBox ID="txtRemarks" runat="server" CssClass="textbox" ></asp:TextBox>  
            </td>
        </tr>
       
        <tr>
            <td>
               </td>
            <td>
               </td>
            <td></td>
            <td></td>
        </tr>
            </table>
        <hr />

      
</telerik:RadPageView>  
       
         
</telerik:RadMultiPage>
</td>
</tr>
</table>
   
    </div>
        <%-- inner div ends here --%>
    </div>
    <%-- Top div ends here --%>

</asp:Content>
<%-- Html ends here --%>
