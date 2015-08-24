<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="ConstructionPunchList.aspx.cs" Inherits="FlyCn.EIL.ConstructionPunchList" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik"%>
<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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
</asp:Content>

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
                  //radTabStrip1.Tabs.Item(0).Selected = True;
                  //radMultiPage1.SelectedIndex = 0;

                  //  alert(tabStrip.SelectedIndex);
                  <%-- var pageView = multiPage.findPageViewByID("RadPageView1");
                   var tabStrip = $find("<%= RadTabStrip1.ClientID %>");
                   var tab = tabStrip.findTabByText('Edit');
                   tab.set_text("New");
                   tabStrip.commitChanges();
                   document.getElementById('<%=Button2.ClientID %>').style.display = "none";
                   document.getElementById('<%=Button1.ClientID %>').style.display = "none";--%>

              }
            <%--  else if (tab.get_text() == "Edit") {
                  document.getElementById('<%=btnSave.ClientID %>').style.display = "none";
                  document.getElementById('<%=btnUpdate.ClientID %>').style.display = "";
              }
              else if (tab.get_text() == "New") {
                  document.getElementById('<%=btnSave.ClientID %>').style.display = "";
                  document.getElementById('<%=btnUpdate.ClientID %>').style.display = "none";--%>
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

                      try
                      {

                          if(document.getElementById("<%= grdFileUpload.ClientID %>")!=null)
                          document.getElementById("<%= grdFileUpload.ClientID %>").style.display = "none";
                      }
                      catch(x){

                      }

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
   
     <%--<script>
        function ShowCreate() {
            document.getElementById("Create").style.display = "";
            document.getElementById("display").style.display = "none";
            document.getElementById("btnAdd").style.display = "none";
            //document.getElementById("btnUpdate").style.visibility = "hidden";
            document.getElementById('<%=btnUpdate.ClientID %>').style.visibility = "hidden";
            debugger;

        }
        function ShowEdit() {
            document.getElementById("Create").style.display = "";
            document.getElementById("display").style.display = "none";
            document.getElementById("btnUpdate").style.visibility = "visible";
            document.getElementById("<%= grdFileUpload.ClientID %>").style.visibility = "visible";
            document.getElementById("<%= grdFileUpload.ClientID %>").style.display = "";
            debugger;
        }
        function Navigate()
        {
            window.location = "ConstructionPunchList.aspx";
        }--%>
     
 
    
   
<%--</script>--%>
    
    <p class="">
        Construction Punch List</p>
     
     <hr />
  <%--  <div id="button">
        <input id="btnAdd" type="button" value="ADD" onclick="ShowCreate()" />
         <input id="btnList" type="button" value="List" onclick="Navigate()" /></div>
    <div id="display">
          <asp:ScriptManager ID="ScriptManager1" runat="server" >
</asp:ScriptManager>--%>
        <div class="inputMainContainer">
        <div class="innerDiv">
        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" Width="300px" OnClientTabSelected="onClientTabSelected"
             CausesValidation="false"   SelectedIndex="0" Skin="Silk" >
            
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

            
    
             <telerik:RadGrid ID="RadGrid1" runat="server"  CellSpacing="0"
    GridLines="None" OnNeedDataSource="RadGrid1_NeedDataSource1" AllowPaging="true" OnItemCommand="RadGrid1_ItemCommand"
    PageSize="10" Width="984px" Skin="Silk" >
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
                      Module
                  </td>
                  <td class="tabletbody">
                      <asp:DropDownList ID="ddlModule" runat="server" CssClass="selectbox"></asp:DropDownList>
                       </td>
                  <td class="tabletbody">
                      Category
                  </td>
                  <td class="tabletbody">
                      <asp:DropDownList ID="ddlCategory" runat="server" CssClass="selectbox"></asp:DropDownList>
                  </td>
                 
              </tr>
              <tr>
                   <td class="tabletbody">Tag</td>
                  <td class="tabletbody">
                      <asp:DropDownList ID="ddlTag" runat="server" CssClass="selectbox"></asp:DropDownList>
                  </td>
                  <td class="tabletbody">
                      Activity
                      
                  </td>
                  <td class="tabletbody">
                      <asp:DropDownList ID="ddlActivity" runat="server" CssClass="selectbox"></asp:DropDownList>
                      
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
                ID No
            </td>
          
            <td class="tabletd">

                <asp:TextBox ID="txtIDno" runat="server" CssClass="textbox" ></asp:TextBox>
              
               <%-- <br />
                  <asp:RequiredFieldValidator ID="ReqIdNo" runat="server" ControlToValidate="txtIDno" ErrorMessage="Please enter Id no" ValidationGroup="dummy" ></asp:RequiredFieldValidator>
                <br />--%>
                <%--<asp:Label ID="lblError" runat="server"></asp:Label>--%>
            </td>
            
        </tr>
        <tr >
            <td class="tabletd">
             <asp:Label ID="Label5" runat="server" Text="Open By"></asp:Label>
            </td>
            <td class="tabletd">
                <asp:DropDownList ID="ddlOpenBy" runat="server" CssClass="selectbox">
                </asp:DropDownList>
            </td>
            <td class="tabletd">Entered Date</td>
            <td>
             
            </td>
        </tr>
        <tr>
            <td class="tabletd">
                Entered By</td>
            <td class="tabletd">
                <asp:DropDownList ID="ddlEnteredBy" runat="server" CssClass="selectbox">
                </asp:DropDownList>
            </td>
            <td class="tabletd">
                <asp:Label ID="Label6" runat="server" Text="OpenDate"></asp:Label>
            </td>
            <td class="tabletd">
              
                      <telerik:RadDatePicker ID="RadOpenDate" runat="server"  
             Width="100px" TabIndex="2" AutoPostBack="false" >
            <DateInput DateFormat="dd/MM/yyyy" InvalidStyleDuration="100" LabelCssClass="radLabelCss_Office2007" 
                 runat="server">
                
            </DateInput>
             
           
        </telerik:RadDatePicker>
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
        <table style="width:100%;">
        <tr>
            <td  colspan="3" class="sectionHeader">
                Location Details</td>
        </tr>
        <tr>
            <td class="tabletd">
                Plant</td>
            <td class="tabletd">
                <asp:DropDownList ID="ddlPlant" runat="server" CssClass="selectbox">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="tabletd">
                Area</td>
            <td class="tabletd">
                <asp:DropDownList ID="ddlArea" runat="server" CssClass="selectbox">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="tabletd">
                Location</td>
            <td class="tabletd">
                <asp:DropDownList ID="ddlLocation" runat="server" CssClass="selectbox">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="tabletd">
                Unit</td>
            <td class="tabletd">
                <asp:DropDownList ID="ddlUnit" runat="server" CssClass="selectbox">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td >
                </td>
            <td>
                </td>
            <td></td>
        </tr></table>
        <hr />
        <table style="width:100%;">
        <tr>
            <td  colspan="5" class="tabletd">
                System</td>
        </tr>
        <tr>
            <td class="tabletd">
                System</td>
            <td class="tabletd">
                <asp:TextBox ID="txtSystem" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="tabletd">Control System</td>
            <td class="tabletd">
                <asp:TextBox ID="txtControlSystem" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tabletd">
                Sub System</td>
            <td class="tabletd">
                <asp:TextBox ID="txtSubsystem" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>

             </table>
        <hr />
        <table style="width:100%;">
        <tr>
            <td  colspan="5" class="tabletd">
                Item Details</td>
        </tr>
        <tr>
            <td class="tabletd">
                Requested By</td>
            <td class="tabletd">
                <asp:DropDownList ID="ddlRequestedBy" runat="server" CssClass="selectbox">
                </asp:DropDownList>
            </td>
            <td class="tabletd">Inspector</td>
            <td class="tabletd">
                <asp:DropDownList ID="ddlInspector" runat="server" CssClass="selectbox">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="tabletd">
                Action By</td>
            <td class="tabletd">
                <asp:DropDownList ID="ddlActionBy" runat="server" CssClass="selectbox">
                </asp:DropDownList>
            </td>
            <td class="tabletd">Discipline</td>
            <td class="tabletd">
                <asp:DropDownList ID="ddlDiscipline" runat="server" CssClass="selectbox">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="tabletd">
                Fail Category</td>
            <td class="tabletd">
                <asp:DropDownList ID="ddlFailCategory" runat="server" CssClass="selectbox">
                </asp:DropDownList>
            </td>
            <td class="tabletd">Category</td>
            <td class="tabletd">
                <asp:DropDownList ID="ddlCategoryList" runat="server" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" CssClass="selectbox">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="tabletd">
                RFI No</td>
            <td class="tabletd">
                <asp:TextBox ID="txtRFINo" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="tabletd">RFI Date</td>
            <td class="tabletd">
               
                
                  <%--       <telerik:RadDatePicker ID="RadRFINo" runat="server" 
             Width="100px" TabIndex="2" AutoPostBack="false" >
            <DateInput DateFormat="dd/MMM/yyyy" InvalidStyleDuration="100" LabelCssClass="radLabelCss_Office2007" 
                 runat="server">
                
            </DateInput>
             
            
        </telerik:RadDatePicker>--%>
            </td>
        </tr>
        <tr>
            <td >
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr></table>
        <hr />
        <table style="width:100%;">
        <tr>
            <td class="tabletd">
                Covered By Project</td>
       
            <td class="tabletd" >
                <asp:RadioButton ID="rdbCoveredByYes" runat="server" Text="Yes" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="rdbCoveredByNo" runat="server" Text="No" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="tabletd">
                Item Description</td>
            <td class="tabletd">
                <asp:TextBox ID="txtItemDescription" runat="server" TextMode="MultiLine" Height="60px" Width="200px"></asp:TextBox>
                <br />
            </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td >
            </td>
            <td >
            </td>
            <td>
            </td>
            <td></td>
            <td></td>
        </tr></table>
        <hr />
        <table style="width:100%;">
        <tr>
            <td  colspan="5" class="tabletd">
                Change Request Details</td>
        </tr>
        <tr>
            <td class="tabletd">
                Reference</td>
            <td class="tabletd" >
                <asp:TextBox ID="txtReference" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td class="tabletd">
                Reference Date</td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td class="tabletd">
                Change Request</td>
            <td class="tabletd">
                <asp:RadioButtonList ID="rbChangeRequest" runat="server">
                </asp:RadioButtonList>
                <asp:RadioButtonList ID="RadioButtonList2" runat="server">
                </asp:RadioButtonList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
            </table>
        <hr />
        <table style="width:100%;">
        <tr>
            <td  colspan="5" class="tabletd">
                Drawing Details</td>
        </tr>
        <tr>
            <td class="tabletd">
                Drawing</td>
            <td class="tabletd">
                <asp:TextBox ID="txtDrawing" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="tabletd">
                Sheet</td>
            <td class="tabletd">
                <asp:TextBox ID="txtSheet" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="tabletd">
                Revision</td>
            <td class="tabletd">
                <asp:TextBox ID="txtRevision" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td >
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr></table>
        <hr />
        <table style="width:100%;">
        <tr>
            <td colspan="5" class="tabletd">
                Query Details</td>
        </tr>
        <tr>
            <td class="tabletd">
                Query</td>
            <td class="tabletd">
                <asp:TextBox ID="txtQuery" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="tabletd">
                Query Status</td>
            <td class="tabletd">
                <asp:TextBox ID="txtQueryStatus" runat="server" ReadOnly="True" CssClass="textbox"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="tabletd">
                Query Revision</td>
            <td class="tabletd">
                <asp:TextBox ID="txtQueryRevision" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td >
            </td> 
            <td >
            </td>
            <td>
            </td>
            <td></td>
            <td></td>
        </tr>
            </table>
        <hr />
        <table style="width:100%;">
        <tr>
            <td colspan="5" class="tabletd">
                Completion Details</td>
        </tr>
        <tr>
            <td class="tabletd">
                Responsible Person</td>
            <td class="tabletd">
                <asp:DropDownList ID="ddlResponsiblePerson" runat="server" CssClass="selectbox">
                </asp:DropDownList>
            </td>
            <td class="tabletd">Organization</td>
            <td class="tabletd">
                <asp:DropDownList ID="ddlOrganization" runat="server" CssClass="selectbox">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="tabletd">
                Signed By</td>
            <td class="tabletd">
                <asp:DropDownList ID="ddlSignedBy" runat="server" CssClass="selectbox">
                </asp:DropDownList>
            </td>
            <td class="tabletd">Completion Date</td>
            <td class="tabletd">
                
                       <%--  <telerik:RadDatePicker ID="RadCompletionDate" runat="server" Culture="Portuguese (Brazil)"
             Width="100px" TabIndex="2" AutoPostBack="false" >
            <DateInput DateFormat="dd/MM/yyyy" InvalidStyleDuration="100" LabelCssClass="radLabelCss_Office2007" 
                 runat="server">
                
            </DateInput>
             
            <Calendar runat="server">
                    </Calendar>
        </telerik:RadDatePicker>--%>
            </td>
        </tr>
        <tr class="tabletd">
            <td>
                Scheduled Completion Date</td>
            <td class="tabletd">
               
                   <%--      <telerik:RadDatePicker ID="RadScheduleCompletionDate" runat="server" Culture="Portuguese (Brazil)"
             Width="100px" TabIndex="2" AutoPostBack="false" >
            <DateInput DateFormat="dd/MM/yyyy" InvalidStyleDuration="100" LabelCssClass="radLabelCss_Office2007" 
                 runat="server">
                
            </DateInput>
             
            <Calendar runat="server">
                    </Calendar>
        </telerik:RadDatePicker>--%>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="tabletd">
                Completion Remarks</td>
            <td >
                <asp:TextBox ID="txtCompletionRemarks" runat="server" TextMode="MultiLine" Height="60px" Width="200px" ></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td >
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr></table>
        <hr />
        <table style="width:100%;">
        <tr>
            <td  colspan="5" class="tabletd">
                Attach Document</td>
        </tr>
        <tr>
            <td>
                <asp:FileUpload ID="fuAttach" runat="server" AllowMultiple="true" />
 
              &nbsp;
                <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" Enabled="False"/>
                   <br /><br />
    <asp:Label runat="server" id="StatusLabel" text="Upload status: " />
            </td>
            <td>
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr></table>

        <table style="width:100%;">
          <tr><td class="tabletd">
              <asp:GridView ID="grdFileUpload" DataKeyNames="FileName"  runat ="server" AutoGenerateColumns="false" style="width:100%" OnRowCommand="grdFileUpload_RowCommand" OnRowDeleting="grdFileUpload_RowDeleting" OnRowDataBound="grdFileUpload_RowDataBound">
                      <Columns>
                       <asp:TemplateField>
            <HeaderTemplate>
            Serial No.</HeaderTemplate>
            <ItemTemplate>
            <asp:Label ID="lblSRNO" runat="server" 
                Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
            </ItemTemplate>
                           </asp:TemplateField>
                     <asp:TemplateField >              
                           <ItemTemplate>
     <asp:HiddenField ID="hdnField" runat="server" Value='<%# Bind("SlNo") %>' />
 </ItemTemplate></asp:TemplateField>
                         <asp:TemplateField >              
                           <ItemTemplate>
     <asp:HiddenField ID="hdnType" runat="server" Value='<%# Bind("EILType") %>' />
 </ItemTemplate></asp:TemplateField>
                          <asp:BoundField HeaderText="FileName" DataField="FileName" />
                      
<%--<ItemTemplate>--%>
<%--<asp:ImageButton ID="imageButtonDelete" ImageUrl="~/Images/Trash can - 04.png" 
Text="Delete" CommandName="Delete" runat="server" />--%>
    <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/Cancel.png" CommandName="Delete" Text="Delete" Visible="True" />
                          <asp:TemplateField>
<ItemTemplate>
  <asp:ImageButton ID="imageButtonDownload" ImageUrl="~/Images/Download.png"  Text="Download" Visible="True" runat="server" OnClick="imageButtonDownload_Click" />
    </ItemTemplate></asp:TemplateField>
                      </Columns>
              </asp:GridView>
          </td></tr>
            </table>

        <table style="width:100%;">
        <tr>
            <td >
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td >
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td >
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>

        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>

           <%-- <td>
             <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Width="46px" ValidationGroup="dummy"/>
              &nbsp;<asp:Button  ID="btnUpdate" runat="server" Text="Update"  Onclick="btnUpdate_Click"/>
&nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" Height="27px" Width="49px" OnClick="btnCancel_Click" />
            </td>--%>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
                </table>

      
 </telerik:RadPageView>  
       
         
                </telerik:RadMultiPage>
             </td>
    </tr>
</table>
                

         </div>
            </div>
           
     
</asp:Content>


