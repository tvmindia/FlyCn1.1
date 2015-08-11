<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="ConstructionPunchList.aspx.cs" Inherits="FlyCn.EIL.ConstructionPunchList" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <style type="text/css">
        .selectbox
{
    width: 62%;
    height: 25px;
    background-color: #FFF;
    font: 400 12px/18px 'Open Sans' , sans-serif; 
    color: #000;
    font-weight: normal;
    border: 1px solid #ccc;
    margin: 5px 0 0 0;
    padding: 5px;
}
.textbox
{
    width: 58%;
    height: 10px;
    background-color: #FFF;
    font: 400 12px/18px 'Open Sans' , sans-serif;
    color: #000;
    font-weight: normal;
    border: 1px solid #ccc;
    margin: 5px 0 0 0;
    padding: 5px;
}
.rediobutton
{
    width: 30px;
    height: 18px;
    background-color: #FFF;
    font: 400 12px/18px 'Open Sans' , sans-serif;
    color: #000;
    font-weight: normal;
    border: 1px solid #ccc;
    margin: 5px 0 0 0;
    padding: 5px;
}
.content
{
    border: 1px solid #BDBDBD;
    width: 91%;
    padding: 5px;
    margin: 0px 0 0 5px;
}
        .textarea {
            margin-top:250%;
    left:0%;
    width:150px;
        }
        .hdnField
 {
     display:none;
 }

    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script>
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
        }
     
    //$(function () {
    //    $("[id$=txtOpenDate]").datepicker({
    //        showOn: 'button',
    //        buttonImageOnly: true,
            
    //    });
        //});
    
   
</script>
    <p>
        <br />
    </p>
    <p>
    </p>
    <p>
        Construction Punch List</p>
    <p>
    </p>
    <p>
    </p>
     <hr />
    <div id="button">
        <input id="btnAdd" type="button" value="ADD" onclick="ShowCreate()" />
         <input id="btnList" type="button" value="List" onclick="Navigate()" /></div>
    <div id="display">
          <asp:ScriptManager ID="ScriptManager1" runat="server" >
</asp:ScriptManager>
    
             <telerik:RadGrid ID="RadGrid1" runat="server"  CellSpacing="0"
    GridLines="None" OnNeedDataSource="RadGrid1_NeedDataSource1" AllowPaging="true" OnItemCommand="RadGrid1_ItemCommand"
    PageSize="10" Width="984px" >
                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="ProjectNo,IDNo">
    <Columns>
     <telerik:GridBoundColumn HeaderText="Project No" DataField="ProjectNo" UniqueName="ProjectNo"></telerik:GridBoundColumn> 
     <telerik:GridBoundColumn HeaderText="ID No" DataField="IDNo" UniqueName="IDNo"></telerik:GridBoundColumn>
     <telerik:GridBoundColumn HeaderText="LinkIDNo" DataField="LinkIDNo" UniqueName="LinkIDNo"></telerik:GridBoundColumn> 
     <telerik:GridBoundColumn HeaderText="EILType" DataField="EILType" UniqueName="EILType"></telerik:GridBoundColumn> 
     <telerik:GridBoundColumn HeaderText="OpenBy" DataField="OpenBy" UniqueName="OpenBy"></telerik:GridBoundColumn> 
     <telerik:GridBoundColumn HeaderText="OpenDt" DataField="OpenDt" UniqueName="OpenDt" DataType="System.DateTime"  DataFormatString="{0:M/d/yyyy}"></telerik:GridBoundColumn> 
     <telerik:GridButtonColumn CommandName="EditData" Text="Edit" UniqueName="EditData"></telerik:GridButtonColumn>     
     <telerik:GridButtonColumn CommandName="DeleteColumn" Text="Delete" UniqueName="DeleteColumn" ConfirmDialogType="RadWindow" ConfirmText="Are you sure, you want to delete this item ?">
      </telerik:GridButtonColumn>
    </Columns>
  </MasterTableView>            
             </telerik:RadGrid>
        </div>
    
    <div id="Create" style="display:none" >
     
      <table style="width:100%;">
  
              <tr><td colspan="5" class="td" style="border-bottom:2px">Tracking Details</td></tr>
              <tr>
                  <td >
                      Module
                  </td>
                  <td>
                      <asp:DropDownList ID="ddlModule" runat="server" CssClass="selectbox"></asp:DropDownList>
                       </td>
                  <td >
                      Category
                  </td>
                  <td>
                      <asp:DropDownList ID="ddlCategory" runat="server" CssClass="selectbox"></asp:DropDownList>
                  </td>
                 
              </tr>
              <tr>
                   <td class="td">Tag</td>
                  <td>
                      <asp:DropDownList ID="ddlTag" runat="server" CssClass="selectbox"></asp:DropDownList>
                  </td>
                  <td >
                      Activity
                      
                  </td>
                  <td>
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
             
              <tr   >
                   <td  colspan="5" class="sectionHeader" >General Details</td>
              </tr>
        <tr>
            <td>
                ID No
            </td>
          
            <td>

                <asp:TextBox ID="txtIDno" runat="server" CssClass="textbox" ></asp:TextBox>
              
                <br />
                  <asp:RequiredFieldValidator ID="ReqIdNo" runat="server" ControlToValidate="txtIDno" ErrorMessage="Please enter Id no" ValidationGroup="dummy" ></asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
            <td>

                &nbsp;</td>
        </tr>
        <tr>
            <td>
             &nbsp;<asp:Label ID="Label5" runat="server" Text="Open By"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlOpenBy" runat="server" CssClass="selectbox">
                </asp:DropDownList>
            </td>
            <td>Entered Date</td>
            <td>
                <%--  <asp:TextBox ID="txtEnteredDate" runat="server"></asp:TextBox>--%><%--<telerik:RadDatePicker ID="RadEnteredDate" runat="server" 
             Width="100px"></telerik:RadDatePicker>--%>
            </td>
        </tr>
        <tr>
            <td>
                Entered By</td>
            <td>
                <asp:DropDownList ID="ddlEnteredBy" runat="server" CssClass="selectbox">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="Label6" runat="server" Text="OpenDate"></asp:Label>
            </td>
            <td>
              
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
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td  colspan="5" class="sectionHeader">
                Location Details</td>
        </tr>
        <tr>
            <td>
                Plant</td>
            <td>
                <asp:DropDownList ID="ddlPlant" runat="server" CssClass="selectbox">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                Area</td>
            <td>
                <asp:DropDownList ID="ddlArea" runat="server" CssClass="selectbox">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                Location</td>
            <td >
                <asp:DropDownList ID="ddlLocation" runat="server" CssClass="selectbox">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                Unit</td>
            <td >
                <asp:DropDownList ID="ddlUnit" runat="server" CssClass="selectbox">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td >
                </td>
            <td>
                </td>
            <td >
                </td>
            <td ></td>
            <td></td>
        </tr>
        <tr>
            <td  colspan="5" class="sectionHeader">
                System</td>
        </tr>
        <tr>
            <td>
                System</td>
            <td >
                <asp:TextBox ID="txtSystem" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td>Control System</td>
            <td>
                <asp:TextBox ID="txtControlSystem" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Sub System</td>
            <td >
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
        <tr>
            <td  colspan="5" class="sectionHeader">
                Item Details</td>
        </tr>
        <tr>
            <td >
                Requested By</td>
            <td >
                <asp:DropDownList ID="ddlRequestedBy" runat="server" CssClass="selectbox">
                </asp:DropDownList>
            </td>
            <td >Inspector</td>
            <td >
                <asp:DropDownList ID="ddlInspector" runat="server" CssClass="selectbox">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td >
                Action By</td>
            <td >
                <asp:DropDownList ID="ddlActionBy" runat="server" CssClass="selectbox">
                </asp:DropDownList>
            </td>
            <td>Discipline</td>
            <td>
                <asp:DropDownList ID="ddlDiscipline" runat="server" CssClass="selectbox">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td >
                Fail Category</td>
            <td >
                <asp:DropDownList ID="ddlFailCategory" runat="server" CssClass="selectbox">
                </asp:DropDownList>
            </td>
            <td >Category</td>
            <td>
                <asp:DropDownList ID="ddlCategoryList" runat="server" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" CssClass="selectbox">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td >
                RFI No</td>
            <td >
                <asp:TextBox ID="txtRFINo" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td>RFI Date</td>
            <td>
               
                
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
        </tr>
        <tr>
            <td >
                Covered By Project</td>
            <td >
                <asp:RadioButton ID="rdbCoveredByYes" runat="server" Text="Yes" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="rdbCoveredByNo" runat="server" Text="No" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                Item Description</td>
            <td>
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
        </tr>
        <tr>
            <td  colspan="5" class="sectionHeader">
                Change Request Details</td>
        </tr>
        <tr>
            <td >
                Reference</td>
            <td >
                <asp:TextBox ID="txtReference" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td >
                Reference Date</td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>
                Change Request</td>
            <td>
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
        <tr>
            <td  colspan="5" class="sectionHeader">
                Drawing Details</td>
        </tr>
        <tr>
            <td >
                Drawing</td>
            <td>
                <asp:TextBox ID="txtDrawing" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                Sheet</td>
            <td >
                <asp:TextBox ID="txtSheet" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                Revision</td>
            <td>
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
        </tr>
        <tr>
            <td colspan="5" class="sectionHeader">
                Query Details</td>
        </tr>
        <tr>
            <td >
                Query</td>
            <td >
                <asp:TextBox ID="txtQuery" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td >
                Query Status</td>
            <td >
                <asp:TextBox ID="txtQueryStatus" runat="server" ReadOnly="True" CssClass="textbox"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                Query Revision</td>
            <td>
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
        <tr>
            <td colspan="5" class="sectionHeader">
                Completion Details</td>
        </tr>
        <tr>
            <td>
                Responsible Person</td>
            <td>
                <asp:DropDownList ID="ddlResponsiblePerson" runat="server" CssClass="selectbox">
                </asp:DropDownList>
            </td>
            <td >Organization</td>
            <td >
                <asp:DropDownList ID="ddlOrganization" runat="server" CssClass="selectbox">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Signed By</td>
            <td>
                <asp:DropDownList ID="ddlSignedBy" runat="server" CssClass="selectbox">
                </asp:DropDownList>
            </td>
            <td>Completion Date</td>
            <td>
                
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
        <tr>
            <td>
                Scheduled Completion Date</td>
            <td >
               
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
            <td>
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
        </tr>
        <tr>
            <td  colspan="5" class="sectionHeader">
                Attach Document</td>
        </tr>
        <tr>
            <td>
                <asp:FileUpload ID="fuAttach" runat="server" AllowMultiple="true" />
 
              &nbsp;
                <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click"/>
                   <br /><br />
    <asp:Label runat="server" id="StatusLabel" text="Upload status: " />
            </td>
            <td>
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
          <tr><td>
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
    <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/Trash can - 04.png" CommandName="Delete" Text="Delete" Visible="True" />
                          <asp:TemplateField>
<ItemTemplate>
  <asp:ImageButton ID="imageButtonDownload" ImageUrl="~/Images/Download.png"  Text="Download" Visible="True" runat="server" OnClick="imageButtonDownload_Click" />
    </ItemTemplate></asp:TemplateField>
                      </Columns>
              </asp:GridView>
          </td></tr>
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
            <td>
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>

            <td>
             <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Width="46px" ValidationGroup="dummy"/>
              &nbsp;<asp:Button  ID="btnUpdate" runat="server" Text="Update"  Onclick="btnUpdate_Click"/>
&nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" Height="27px" Width="49px" OnClick="btnCancel_Click" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
             
          </table>      
          
   
  
        </div>
 
  
</asp:Content>


