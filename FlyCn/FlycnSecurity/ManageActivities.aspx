<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="ManageActivities.aspx.cs" Inherits="FlyCn.FlycnSecurity.ManageActivities" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
         <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../Scripts/jquery.1.9.1.min.js"></script>
         <script src="../Scripts/ToolBar.js"></script>
    <script src="../Scripts/Messages.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script src="../Scripts/jquery-1.11.3.min.js"></script>
     <script src="../Content/themes/FlyCnBlue/js/selectize.js"></script>
    <script src="../Content/themes/FlyCnBlue/js/index.js"></script>
    
  
    <!-----bootstrap js--->
     
    <script src="../Content/themes/FlyCnBlue/js/bootstrap.min.js"></script>
    <script src="../Content/themes/FlyCnBlue/js/bootstrap-datepicker.js"></script>
        <script src="../Scripts/ToolBar.js"></script>
    <style>
        #tabs li a {
            color: white;
            display: block;
            text-decoration: none;
            font-size: small;
            font-weight: lighter;
        }

              .selectbox {
            width: 69%;
            background-color: #FFF;
            height:25px;
            font: 400 12px/18px 'Open Sans', sans-serif;
            color: #000;
            font-weight: normal;
            border: 1px solid #ccc;
            margin: 5px 0 0 0;
            padding: 5px;
        }
    </style>
   <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
</asp:ScriptManager>  

    <div class="container" style="width: 100%;">
         <div class="col-md-12">
               <ul id="tabs">
                    <li><a href="#" onclick="MyTab1(this);" id="tabs1" runat="server">Manage</a></li>
                    <li><a href="#" onclick="MyTab2(this);" id="tabs2" runat="server">New</a></li>
                </ul>
   <div id="content">
         <div id="tab1">
         
                 
        <uc1:ToolBar runat="server" ID="ToolBar" /> 
      
<div class="col-md-12"  >
          <div style="float:left; width:47%;">

                   <div style="margin-left:10px;">
            <asp:Label ID="lblManageActivities" runat="server" Text="Manage Activities" CssClass="PageHeading"></asp:Label>
                  </div> 
             <br />
      <br />
                <div class="col-md-12">
              <div class="col-md-3">
                  <asp:Label ID="lblProject" runat="server" Text="Select Project"></asp:Label>
                  </div>
             <div class="col-md-3">
                 <asp:DropDownList ID="ddlProjects" runat="server" Width="150px" CssClass="selectbox" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlProjects_SelectedIndexChanged">
                       <asp:ListItem Text="--select project--"></asp:ListItem>
                 </asp:DropDownList>
                  
                  </div>
             <div class="col-md-6">
                
                  </div>
             </div>
              <br />
              <br />
                 <div class="col-md-12">
              <div class="col-md-3">
                  <asp:Label ID="lblModule" runat="server" Text="Select Module"></asp:Label>
                  </div>
             <div class="col-md-3">
                 <asp:DropDownList ID="ddlModule" runat="server" Width="150px" CssClass="selectbox" AppendDataBoundItems="false" AutoPostBack="true" OnSelectedIndexChanged="ddlModule_SelectedIndexChanged">
                       <asp:ListItem Text="--select module--" ></asp:ListItem>
                 </asp:DropDownList>
                  
                  </div>
             <div class="col-md-6">
                
                  </div>
             </div>
                     <br />
              <br />
                 <div class="col-md-12">
              <div class="col-md-3">
                  <asp:Label ID="lblManageCategory" runat="server" Text="Select Category"></asp:Label>
                  </div>
             <div class="col-md-3">
                 <asp:DropDownList ID="ddlManageCategory" runat="server" Width="150px" CssClass="selectbox" AppendDataBoundItems="false" AutoPostBack="true" OnSelectedIndexChanged="ddlManageCategory_SelectedIndexChanged">
                       <asp:ListItem Text="--select category--" ></asp:ListItem>
                 </asp:DropDownList>
                  
                  </div>
             <div class="col-md-6">
                
                  </div>
             </div>
              </div>
    <div style="float:left; width:53%; ">
        <br />
        <br />
      

         <div class="col-md-12"  style="border-left: 1px solid #cfc7c0;min-height:400px">
             <br />
             <br />
                                   <div class="contentTopBar" style="width:450px;margin-left:20%;"></div>
                         <div style="width:450px;margin-left:20%;">
                              <telerik:RadGrid ID="dtgManageActivities" runat="server" AllowPaging="true" Width="100%" Skin="Silk" CssClass="outerMultiPage" AllowSorting="true"  PageSize="7" OnNeedDataSource="dtgManageActivities_NeedDataSource" OnItemCreated="dtgManageActivities_ItemCreated" OnPreRender="dtgManageActivities_PreRender" OnItemCommand="dtgManageActivities_ItemCommand">
                                     <HeaderStyle  HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <AlternatingItemStyle HorizontalAlign="Left" />
                    <MasterTableView  AutoGenerateColumns="false" ShowHeadersWhenNoRecords="true" ShowHeader="true" DataKeyNames="FullDesc" NoMasterRecordsText="No Activities have been added.">
                         <Columns>
                           <%--  <telerik:GridBoundColumn HeaderText="Id" DataField="ModuleActID" UniqueName="ModuleActID" Display="false"></telerik:GridBoundColumn> --%>
                              <telerik:GridBoundColumn HeaderText="Activities" DataField="FullDesc" UniqueName="FullDesc"></telerik:GridBoundColumn> 
                             <telerik:GridCheckBoxColumn HeaderText="Delete" DataType="System.Boolean" UniqueName="Modulescheck"></telerik:GridCheckBoxColumn>
                                    <telerik:GridButtonColumn CommandName="Manage" ButtonType="LinkButton" Text="Manage" UniqueName="Manage" ItemStyle-ForeColor="#3399ff">
                                                </telerik:GridButtonColumn>
                              <%--<telerik:GridBoundColumn HeaderText="Access Type" DataField="AccessType" UniqueName="AccessType" ></telerik:GridBoundColumn> --%>
                        </Columns>
                    </MasterTableView>

                </telerik:RadGrid>
                             </div>
             </div>
               </div>
             </div>
       </div>
        <div id="tab2">
              
                  
        <uc1:ToolBar runat="server" ID="ToolBar1" />
             
              <%-- General Details--%>
            <div class="accordion-container">
                <a href="#" class="accordion-toggle" id="IDAccordion">General Details
                              <span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>

                <div class="accordion-content">
                    <div class="col-md-12 Span-One">
                        <div class="col-md-6">

                            <div class="form-group required">

                              <asp:Label ID="lblSelectProject" runat="server"  CssClass="control-label col-md-6 " Text="Select Project"></asp:Label>
                                <div class="col-md-6">
                                      <asp:DropDownList ID="ddlSelectProject" runat="server" Width="150px" CssClass="selectbox" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlSelectProject_SelectedIndexChanged">
                      
                 </asp:DropDownList>
                                </div>
                            </div>
                       
                        </div>

                        <div class="col-md-6">

                            <div class="form-group required">

                                  <asp:Label ID="lblSelectModule" runat="server"  CssClass="control-label col-md-6 " Text="Select Module"></asp:Label>
                                <div class="col-md-6">
                                <asp:DropDownList ID="ddlSelectModule" runat="server" Width="150px" CssClass="selectbox" AppendDataBoundItems="false" AutoPostBack="true" OnSelectedIndexChanged="ddlSelectModule_SelectedIndexChanged">
                     
                 </asp:DropDownList>
                                </div>
                            </div>
                           
                        </div>

                        
                        <div class="col-md-6">

                            <div class="form-group required">

                                  <asp:Label ID="lblCategory" runat="server"  CssClass="control-label col-md-6 " Text="Select Category"></asp:Label>
                                <div class="col-md-6">
                                <asp:DropDownList ID="ddlCategory" runat="server" Width="150px" CssClass="selectbox" AppendDataBoundItems="false" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                       <asp:ListItem Text="--select category--" ></asp:ListItem>
                 </asp:DropDownList>
                                </div>
                            </div>
                           
                        </div>
                         <div class="col-md-6">

                            <div class="form-group required">

                                  <asp:Label ID="lblActivity" runat="server"  CssClass="control-label col-md-6 " Text="Select Activity"></asp:Label>
                                <div class="col-md-6">
                                <asp:DropDownList ID="ddlActivity" runat="server" Width="150px" CssClass="selectbox" AppendDataBoundItems="false" AutoPostBack="true" OnSelectedIndexChanged="ddlActivity_SelectedIndexChanged">
                       <asp:ListItem Text="--select Activity--"></asp:ListItem>
                 </asp:DropDownList>
                                </div>
                            </div>
                           
                        </div>

                    </div>

                </div>

            </div>

              <%-- Descriptions--%>
            <div class="accordion-container">
                <a href="#" class="accordion-toggle" id="IDAccordion">Descriptions
                              <span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>

                <div class="accordion-content">
                    <div class="col-md-12 Span-One">
                        <div class="col-md-6">

                            <div class="form-group">

                                <asp:Label ID="lblFullDesc" runat="server" Text="Full Desc" CssClass="control-label col-md-6 "></asp:Label>
                                <div class="col-md-6">
                                    <table>
                                        <tr>
                                            <td>
                                     <asp:TextBox ID="txtFullDesc" runat="server" CssClass="form-control" onchange="FullDescriptionCheck(this)"></asp:TextBox>
                               </td>  <td>
                        <asp:Image  ID="imgWebLnames" runat="server" ToolTip="Login Name is Available" ImageUrl="~/Images/ProjectImages/Check.png" Width="17px" Height="17px"/></td>
                        <td>   <asp:Image ID="errorLnames" runat="server" ToolTip="This description name is Unavailable" ImageUrl="~/Images/ProjectImages/newClose.png" Width="10px" Height="10px" /></td>
                           </tr> </table>
                                </div>
                            </div>
                           
                        </div>

                        <div class="col-md-6">

                            <div class="form-group">

                                 <asp:Label ID="lblShortDesc" runat="server" Text="Short Desc" CssClass="control-label col-md-6 "></asp:Label>
                                <div class="col-md-6">
                                  <table>
                                        <tr>
                                            <td>
                                      <asp:TextBox ID="txtShortDesc" runat="server" CssClass="form-control" onchange="ShortDescriptionCheck(this)"></asp:TextBox>
                                 </td>  <td>
                        <asp:Image  ID="shortdescTrue" runat="server" ToolTip="Login Name is Available" ImageUrl="~/Images/ProjectImages/Check.png" Width="17px" Height="17px"/></td>
                        <td>   <asp:Image ID="errorShortDesc" runat="server" ToolTip="This description name is Unavailable" ImageUrl="~/Images/ProjectImages/newClose.png" Width="10px" Height="10px" /></td>
                           </tr> </table>
                                      </div>
                            </div>
                         
                        </div>

                    </div>

                </div>

            </div>

            <%-- Captions--%>
            <div class="accordion-container">
                <a href="#" class="accordion-toggle" id="IDAccordion">Captions
                              <span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>

                <div class="accordion-content">
                    <div class="col-md-12 Span-One">
                      
                        <div class="col-md-6  Span-One">
                            <div class="form-group">

                                <asp:Label ID="lblActualStartDateCaption" runat="server" Text="StartDate Caption" CssClass="control-label col-md-6 "></asp:Label>

                                <div class="col-md-6">
                                    <asp:TextBox ID="txtActualStartDateCaption" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <%-- </form>--%>
                        </div>
                                              
                        <div class="col-md-6  Span-One">

                            <div class="form-group">

                                <asp:Label ID="lblStatusCaption" runat="server" Text="Status Caption" CssClass="control-label col-md-6 "></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtStatusCaption" runat="server" CssClass="form-control"></asp:TextBox>

                                </div>
                            </div>
                            <%-- </form>--%>
                        </div>                      
                      
                        <div class="col-md-6 Span-One">

                            <div class="form-group">

                                <asp:Label ID="lblActualCompleteDateCaption" runat="server" Text="CompleteDate Caption" CssClass="control-label col-md-6 "></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtActualCompleteDateCaption" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <%-- </form>--%>
                        </div>
                                             
                        <div class="col-md-6  Span-One">

                            <div class="form-group">
                                <asp:Label ID="lblTotalCaption" runat="server" Text="Total Caption" CssClass="control-label col-md-6 "></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtTotalCaption" runat="server" CssClass="form-control"></asp:TextBox>

                                </div>
                            </div>
                            <%-- </form>--%>
                        </div>                      

                        <div class="col-md-6  Span-One">

                            <div class="form-group">
                                <asp:Label ID="lblPassedCaption" runat="server" Text="Passed Caption" CssClass="control-label col-md-6 "></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtPassedCaption" runat="server" CssClass="form-control"></asp:TextBox>

                                </div>
                            </div>
                            <%-- </form>--%>
                        </div>
                       
                        <div class="col-md-6  Span-One">

                            <div class="form-group">
                                <asp:Label ID="lblFailedCaption" runat="server" Text="Failed Caption" CssClass="control-label col-md-6 "></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtFailedCaption" runat="server" CssClass="form-control"></asp:TextBox>

                                </div>
                            </div>
                            <%-- </form>--%>
                        </div>
                      
                        <div class="col-md-6  Span-One">

                            <div class="form-group">
                                <asp:Label ID="lblInProgressCaption" runat="server" Text="InProgress Caption" CssClass="control-label col-md-6 "></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtInProgressCaption" runat="server" CssClass="form-control"></asp:TextBox>

                                </div>
                            </div>
                            <%-- </form>--%>
                        </div>
                       
                        <div class="col-md-6  Span-One">

                            <div class="form-group">
                                <asp:Label ID="lblTestedCaption" runat="server" Text="Tested Caption" CssClass="control-label col-md-6 "></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtTestedCaption" runat="server" CssClass="form-control"></asp:TextBox>

                                </div>
                            </div>
                            <%-- </form>--%>
                        </div>                        

                        <div class="col-md-6  Span-One">

                            <div class="form-group">
                                <asp:Label ID="lblReadyCaption" runat="server" Text="Ready Caption" CssClass="control-label col-md-6 "></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtReadyCaption" runat="server" CssClass="form-control"></asp:TextBox>

                                </div>
                            </div>
                            <%-- </form>--%>
                        </div>                      

                        <div class="col-md-6  Span-One">

                            <div class="form-group">
                                <asp:Label ID="lblNotReadyCaption" runat="server" Text="Not-Ready Caption" CssClass="control-label col-md-6 "></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtNotReadyCaption" runat="server" CssClass="form-control"></asp:TextBox>

                                </div>
                            </div>
                            <%-- </form>--%>
                        </div>
                       
                        <div class="col-md-6  Span-One">

                            <div class="form-group">
                                <asp:Label ID="lblNotTested" runat="server" Text="Not-Tested Caption" CssClass="control-label col-md-6 "></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtNotTested" runat="server" CssClass="form-control"></asp:TextBox>

                                </div>
                            </div>
                            <%-- </form>--%>
                        </div>
                    
                        <div class="col-md-6  Span-One">

                            <div class="form-group">
                                <asp:Label ID="lblBalanceCaption" runat="server" Text="Balance Caption" CssClass="control-label col-md-6 "></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtBalanceCaption" runat="server" CssClass="form-control"></asp:TextBox>

                                </div>
                            </div>
                            <%-- </form>--%>
                        </div>

                    </div>
                </div>
            </div>

            <%-- Dates--%>
            <div class="accordion-container">
                <a href="#" class="accordion-toggle" id="IDAccordion">Dates
                              <span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>

                <div class="accordion-content">
                    <div class="col-md-12 Span-One">
                        <div class="col-md-6">

                            <div class="form-group">

                                <asp:Label ID="lblActualCompleteDate" runat="server" Text="Actual CompleteDate" CssClass="control-label col-md-6 "></asp:Label>
                                <div class="col-md-6">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="chkActualCompleteDate" runat="server" /></td>
                                            <td>&nbsp;Yes</td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <%-- </form>--%>
                        </div>

                        <div class="col-md-6">

                            <div class="form-group">

                                <asp:Label ID="lblRFIDate" runat="server" Text="RFI Date" CssClass="control-label col-md-6 "></asp:Label>
                                <div class="col-md-6">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="chkRFIDate" runat="server" /></td>
                                            <td>&nbsp;Yes</td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <%-- </form>--%>
                        </div>

                        <div class="col-md-6">

                            <div class="form-group">

                                <asp:Label ID="lblPlannedStartDate" runat="server" Text="Planned StartDate" CssClass="control-label col-md-6 "></asp:Label>
                                <div class="col-md-6">

                                    <table>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="chkPlannedStartDate" runat="server" /></td>
                                            <td>&nbsp;Yes</td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <%-- </form>--%>
                        </div>

                        <div class="col-md-6">

                            <div class="form-group">

                                <asp:Label ID="lblPlannedCmpltDate" runat="server" Text="Planned CompleteDate" CssClass="control-label col-md-6 "></asp:Label>
                                <div class="col-md-6">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="chkPlannedCmpltDate" runat="server" /></td>
                                            <td>&nbsp;Yes</td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <%-- </form>--%>
                        </div>

                        <div class="col-md-6">

                            <div class="form-group">

                                <asp:Label ID="lblForeCastStartDate" runat="server" Text="ForeCast StartDate" CssClass="control-label col-md-6 "></asp:Label>
                                <div class="col-md-6">

                                    <table>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="chkForeCastStartDate" runat="server" /></td>
                                            <td>&nbsp;Yes</td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <%-- </form>--%>
                        </div>

                        <div class="col-md-6">

                            <div class="form-group">

                                <asp:Label ID="lblForeCastEndDate" runat="server" Text="ForeCast EndDate" CssClass="control-label col-md-6 "></asp:Label>
                                <div class="col-md-6">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="chkForeCastEndDate" runat="server" /></td>
                                            <td>&nbsp;Yes</td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <%-- </form>--%>
                        </div>

                        <div class="col-md-6">

                            <div class="form-group">

                                <asp:Label ID="lblActualStartDate" runat="server" Text="Actual StartDate" CssClass="control-label col-md-6 "></asp:Label>
                                <div class="col-md-6">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="chkActualStartDate" runat="server" /></td>
                                            <td>&nbsp;Yes</td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <%-- </form>--%>
                        </div>

                        <div class="col-md-6">

                            <div class="form-group">

                                <asp:Label ID="lblAFIDate" runat="server" Text="AFI Date" CssClass="control-label col-md-6 "></asp:Label>
                                <div class="col-md-6">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="chkAFIDate" runat="server" /></td>
                                            <td>&nbsp;Yes</td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <%-- </form>--%>
                        </div>

                    </div>

                </div>

            </div>       

             <%-- Reference Number--%>
            <div class="accordion-container">
                <a href="#" class="accordion-toggle" id="IDAccordion">Reference Number
                              <span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>

                <div class="accordion-content">
                    <div class="col-md-12 Span-One">
                        <div class="col-md-6">

                            <div class="form-group">

                                 <asp:Label ID="lblRFIRef_No" runat="server" Text="RFI Ref_No" CssClass="control-label col-md-6 "></asp:Label>
                                <div class="col-md-6">
                                    <table>
                              <tr>
                                  <td> <asp:CheckBox ID="chkRFIRef_No" runat="server" /></td>
                                  <td>&nbsp;Yes</td>
                              </tr>
                          </table>
                                </div>
                            </div>
                            <%-- </form>--%>
                        </div>

                        <div class="col-md-6">

                            <div class="form-group required">

                                  <asp:Label ID="lblAFIRef_No" runat="server" Text="AFI Ref_No" CssClass="control-label col-md-6 "></asp:Label>
                                <div class="col-md-6">
                                   <table>
                              <tr>
                                  <td> <asp:CheckBox ID="chkAFIRef_No" runat="server" /></td>
                                  <td>&nbsp;Yes</td>
                              </tr>
                          </table>
                                </div>
                            </div>
                            <%-- </form>--%>
                        </div>

                    </div>

                </div>

            </div>

            <%-- ID--%>
            <div class="accordion-container">
                <a href="#" class="accordion-toggle" id="IDAccordion">ID
                              <span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>

                <div class="accordion-content">
                    <div class="col-md-12 Span-One">
                        <div class="col-md-6">

                            <div class="form-group">

                                <asp:Label ID="lblModuleActId" runat="server" Text="Module ActID" CssClass="control-label col-md-6 "></asp:Label>
                                <div class="col-md-6">
                                     <asp:TextBox ID="txtModuleActId" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                           
                        </div>
                        <div class="col-md-6">

                            <div class="form-group">

                                 <asp:Label ID="lblWBSID" runat="server" Text="WBS ID" CssClass="control-label col-md-6 "></asp:Label>
                                <div class="col-md-6">
                                      <table>
                              <tr>
                                  <td> <asp:CheckBox ID="chkWBSID" runat="server" /></td>
                                  <td>&nbsp;Yes</td>
                              </tr>
                          </table>
                                </div>
                            </div>
                          
                        </div>

                        <div class="col-md-6">

                            <div class="form-group">

                                 <asp:Label ID="lblActivityID" runat="server" Text="Activity ID" CssClass="control-label col-md-6 "></asp:Label>
                                <div class="col-md-6">
                                   <table>
                              <tr>
                                  <td> <asp:CheckBox ID="chkActivityID" runat="server" /></td>
                                  <td>&nbsp;Yes</td>
                              </tr>
                          </table>
                                </div>
                            </div>
                            
                        </div>

                                 

                    </div>

                </div>

            </div>

             <%-- Hours--%>
            <div class="accordion-container">
                <a href="#" class="accordion-toggle" id="IDAccordion">Hours
                              <span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>

                <div class="accordion-content">
                    <div class="col-md-12 Span-One">
                        <div class="col-md-6">

                            <div class="form-group">

                                <asp:Label ID="lblBudgetHours" runat="server" Text="Budget Hours" CssClass="control-label col-md-6 "></asp:Label>
                                <div class="col-md-6">
                                       <table>
                              <tr>
                                  <td> <asp:CheckBox ID="chkBudgetHours" runat="server" /></td>
                                  <td>&nbsp;Yes</td>
                              </tr>
                          </table>
                                </div>
                            </div>
                            <%-- </form>--%>
                        </div>

                        <div class="col-md-6">

                            <div class="form-group">

                                  <asp:Label ID="lblSpentHoursProductive" runat="server" Text="Spent Hours Productive" CssClass="control-label col-md-6 "></asp:Label>
                                <div class="col-md-6">
                                   <table>
                              <tr>
                                  <td> <asp:CheckBox ID="chkSpentHoursProductive" runat="server" /></td>
                                  <td>&nbsp;Yes</td>
                              </tr>
                          </table>
                                </div>
                            </div>
                            <%-- </form>--%>
                        </div>

                        <div class="col-md-6">

                            <div class="form-group">

                                   <asp:Label ID="lblSpentHoursNonProductive" runat="server" Text="Spent Hours Non-Productive" CssClass="control-label col-md-6 "></asp:Label>
                                <div class="col-md-6">
                                  <table>
                              <tr>
                                  <td> <asp:CheckBox ID="chkSpentHoursNonProductive" runat="server" /></td>
                                  <td>&nbsp;Yes</td>
                              </tr>
                          </table>
                                </div>
                            </div>
                            <%-- </form>--%>
                        </div>

                    </div>

                </div>

            </div>
            
             <%-- Quantity--%>
            <div class="accordion-container">
                <a href="#" class="accordion-toggle" id="IDAccordion">Quantity
                              <span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>

                <div class="accordion-content">
                    <div class="col-md-12 Span-One">
                        <div class="col-md-6">

                            <div class="form-group">

                                <asp:Label ID="lblQuantityInstalled" runat="server" Text="Quantity Installed" CssClass="control-label col-md-6 "></asp:Label>
                                <div class="col-md-6">
                                       <table>
                              <tr>
                                  <td> <asp:CheckBox ID="chkQuantityInstalled" runat="server" /></td>
                                  <td>&nbsp;Yes</td>
                              </tr>
                          </table>
                                </div>
                            </div>
                         
                        </div>

                        <div class="col-md-6">

                            <div class="form-group">

                                 <asp:Label ID="lblQtyToInstall" runat="server" Text="Quantity To Install" CssClass="control-label col-md-6 "></asp:Label>
                                <div class="col-md-6">
                                  <table>
                              <tr>
                                  <td> <asp:CheckBox ID="chkQtyToInstall" runat="server" /></td>
                                  <td>&nbsp;Yes</td>
                              </tr>
                          </table>
                                </div>
                            </div>
                          
                        </div>

                        <div class="col-md-6">

                            <div class="form-group">

                                  <asp:Label ID="lblQuantityVerified" runat="server" Text="Quantity Verified" CssClass="control-label col-md-6 "></asp:Label>
                                <div class="col-md-6">
                                  <table>
                              <tr>
                                  <td> <asp:CheckBox ID="chkQuantityVerified" runat="server" /></td>
                                  <td>&nbsp;Yes</td>
                              </tr>
                          </table>
                                </div>
                            </div>
                          
                        </div>

                         <div class="col-md-6">

                            <div class="form-group">

                                  <asp:Label ID="lblKpiQuantity" runat="server" Text="KPI Quantity" CssClass="control-label col-md-6 "></asp:Label>
                                <div class="col-md-6">
                                  <table>
                              <tr>
                                  <td> <asp:CheckBox ID="chkKpiQuantity" runat="server" /></td>
                                  <td>&nbsp;Yes</td>
                              </tr>
                          </table>
                                </div>
                            </div>
                          
                        </div>

                    </div>

                </div>

            </div>

             <%-- Others--%>
            <div class="accordion-container">
                <a href="#" class="accordion-toggle" id="IDAccordion">Others
                              <span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>

                <div class="accordion-content">
                    <div class="col-md-12 Span-One">
                        <div class="col-md-6">

                            <div class="form-group">

<asp:Label ID="lblUnitOfMeasure" runat="server" Text="Unit Of Measure" CssClass="control-label col-md-6 "></asp:Label>
                                <div class="col-md-6">
                                   <table>
                              <tr>
                                  <td> <asp:CheckBox ID="chkUnitOfMeasure" runat="server" /></td>
                                  <td>&nbsp;Yes</td>
                              </tr>
                          </table>
                                </div>
                            </div>
                            <%-- </form>--%>
                        </div>

                        <div class="col-md-6">

                            <div class="form-group">

                                 <asp:Label ID="lblCompleted" runat="server" Text="Completed" CssClass="control-label col-md-6 "></asp:Label>
                                <div class="col-md-6">
                                     <table>
                              <tr>
                                  <td> <asp:CheckBox ID="chkCompleted" runat="server" /></td>
                                  <td>&nbsp;Yes</td>
                              </tr>
                          </table>
                                </div>
                            </div>
                            <%-- </form>--%>
                        </div>

                        <div class="col-md-6">

                            <div class="form-group">

                                <asp:Label ID="lblStatus" runat="server" Text="Status" CssClass="control-label col-md-6 "></asp:Label>
                                <div class="col-md-6">
    <table>
                              <tr>
                                  <td> <asp:CheckBox ID="chkStatus" runat="server" /></td>
                                  <td>&nbsp;Yes</td>
                              </tr>
                          </table>
                                </div>
                            </div>
                            <%-- </form>--%>
                        </div>

                        <div class="col-md-6">

                            <div class="form-group">

                               <asp:Label ID="lblFailApplicable" runat="server" Text="Fail Applicable" CssClass="control-label col-md-6 "></asp:Label>
                                <div class="col-md-6">
                                    <table>
                              <tr>
                                  <td> <asp:CheckBox ID="chkIsFailApplicable" runat="server" /></td>
                                  <td>&nbsp;Yes</td>
                              </tr>
                          </table>
                                </div>
                            </div>
                            <%-- </form>--%>
                        </div>

                        <div class="col-md-6">

                            <div class="form-group">

                               <asp:Label ID="lblRemarks" runat="server" Text="Remarks" CssClass="control-label col-md-6 "></asp:Label>
                                <div class="col-md-6">
 <table>
                              <tr>
                                  <td> <asp:CheckBox ID="chkRemarks" runat="server" /></td>
                                  <td>&nbsp;Yes</td>
                              </tr>
                          </table>
                                </div>
                            </div>
                            <%-- </form>--%>
                        </div>

                        <div class="col-md-6">

                            <div class="form-group">

                               <asp:Label ID="lblActivityWeight" runat="server" Text="Activity Weight" CssClass="control-label col-md-6 "></asp:Label>
                                <div class="col-md-6">
                                    <table>
                              <tr>
                                  <td> <asp:CheckBox ID="chkActivityWeight" runat="server" /></td>
                                  <td>&nbsp;Yes</td>
                              </tr>
                          </table>
                                </div>
                            </div>
                            <%-- </form>--%>
                        </div>



                    </div>

                </div>

            </div>


        </div>
   </div>
         </div>
    </div>
     <asp:HiddenField ID="selected_tab" runat="server" />
    <script>
    
   
        $(document).ready(function () {
  
           var LnameImage = document.getElementById('<%=imgWebLnames.ClientID %>');
           LnameImage.style.display = "none";
           var errLname = document.getElementById('<%=errorLnames.ClientID %>');
            errLname.style.display = "none";
            var shortdescTrue = document.getElementById('<%=shortdescTrue.ClientID %>');
            shortdescTrue.style.display = "none";
            var errorShortDesc = document.getElementById('<%=errorShortDesc.ClientID %>');
            errorShortDesc.style.display = "none";

         var myHidden = document.getElementById('<%= selected_tab.ClientID %>');
             document.getElementById("tab1").style.display = "block";
             document.getElementById("tab2").style.display = "none";
             if(myHidden.value==2)
             {
                document.getElementById("tab2").style.display = "block";
                 document.getElementById("tab1").style.display = "none";
             }
             id = document.getElementById('IDAccordion');
            
             OpenDetailAccordion(id);
            
             $('.accordion-toggle').on('click', function (event) {
                
                 event.preventDefault();
                 // create accordion variables
                 var accordion = $(this);
                 var accordionContent = accordion.next('.accordion-content');
                 var accordionToggleIcon = $(this).children('.toggle-icon');

                 // toggle accordion link open class
                 accordion.toggleClass("open");
                 // toggle accordion content
                 accordionContent.slideToggle(250);
                 // change plus/minus icon
                 if (accordion.hasClass("open")) {
                     accordionToggleIcon.html("<i class='fa fa-minus-circle'></i>");
                 } else {
                     accordionToggleIcon.html("<i class='fa fa-plus-circle'></i>");
                 }

             });
        
     });
     function OpenDetailAccordion(id) {
        
         if (id != undefined)//accordion called from accordion click functionjs
         {

             var accordion = $(id);
             var accordionContent = accordion.next('.accordion-content');
             var accordionToggleIcon = accordion.children('.toggle-icon');

             // toggle accordion link open class
             accordion.toggleClass("open");
             // toggle accordion content
             accordionContent.slideToggle(250);

             // change plus/minus icon
             if (accordion.hasClass("open")) {
                 accordionToggleIcon.html("<i class='fa fa-minus-circle'></i>");
             } else {
                 accordionToggleIcon.html("<i class='fa fa-plus-circle'></i>");
             }
         }
     }
    
     function MyTab1(Id)
     {
         var myHidden = document.getElementById('<%= selected_tab.ClientID %>');
         myHidden.value = 1;
         funtab2 = document.getElementById("tab2");
         funtab2.style.display = "none";
         document.getElementById("tab1").style.display = "block";
        
         document.getElementById('<%=tabs2.ClientID%>').innerHTML = 'New';    
         window.location.href = window.location.href;
       
     }
        function MyTab2(Id) {
         var myHidden = document.getElementById('<%= selected_tab.ClientID %>');
         myHidden.value = 2;
         funtab1 = document.getElementById("tab1");
        
         funtab1.style.display = "none";
         document.getElementById("tab2").style.display = "block";
         
        }
        
        function OnClientButtonClicking(sender, args) {
         var btn = args.get_item();
         if (btn.get_value() == 'Save') {
             args.set_cancel(!validate());
         }
        }


        function OnClientButtonClickingDetail(sender, args) {
            var btn = args.get_item();
            if (btn.get_value() == 'Delete') {
                args.set_cancel(!validates());
            }
        }
        function validate() {
         var Module = document.getElementById('<%=ddlSelectModule.ClientID %>').value;
         Module = trimString(Module);
         var Projects = document.getElementById('<%=ddlProjects.ClientID %>').value;
         Projects = trimString(Projects);
         var category = document.getElementById('<%=ddlCategory.ClientID %>').value;
            category = trimString(category);
           
         if (Module != "--select module--" || Projects != "--select project--" || category != "--select category--")
         {
            
             return true;
             
         }
         else
         {
            
             displayMessage(messageType.Error, messages.UserNameNeeded);
             return false;
             
         }
        }
        function validates() {
            var Module = document.getElementById('<%=ddlModule.ClientID %>').value;
            Module = trimString(Module);
            var Projects = document.getElementById('<%=ddlProjects.ClientID %>').value;
            Projects = trimString(Projects);
            var category = document.getElementById('<%=ddlManageCategory.ClientID %>').value;
            category = trimString(category);
            if (Module != "--select module--" || Projects != "--select project--"||category !="--select category--") {

                return true;

            }
            else {

                displayMessage(messageType.Error, messages.UserNameNeeded);
                return false;

            }
        }
        function NavigateManage()
        {
            var myHidden = document.getElementById('<%= selected_tab.ClientID %>');
            myHidden.value = 2;
            funtab1 = document.getElementById("tab1");
            funtab1.style.display = "none";
            document.getElementById("tab2").style.display = "block";
           
         
        }
        function FullDescriptionCheck() {
            var FullDesc = document.getElementById('<%=txtFullDesc.ClientID %>').value;
            var Module = document.getElementById('<%=ddlSelectModule.ClientID %>');
            var selectedModule = Module.options[Module.selectedIndex].innerHTML;
            var Projects = document.getElementById('<%=ddlSelectProject.ClientID %>');
            var selectedProject = Projects.options[Projects.selectedIndex].innerHTML;
            var categories = document.getElementById('<%=ddlCategory.ClientID %>');
            var selectedCategories = categories.options[categories.selectedIndex].innerHTML;

            PageMethods.ValidateFullDescription(FullDesc, selectedModule, selectedProject,selectedCategories, OnSuccess, onError);
            function OnSuccess(response, userContext, methodName) {

                var LnameImage = document.getElementById('<%=imgWebLnames.ClientID %>');
                var errLname = document.getElementById('<%=errorLnames.ClientID %>');
                if (response == false) {

                    LnameImage.style.display = "block";
                    errLname.style.display = "none";

                }
                if (response == true) {
                    errLname.style.display = "block";
                    errLname.style.color = "Red";
                    errLname.innerHTML = "Name Alreay Exists"
                    LnameImage.style.display = "none";

                }
            }
            function onError(response, userContext, methodName) {


            }
        }
        function ShortDescriptionCheck() {
            var ShortDesc = document.getElementById('<%=txtShortDesc.ClientID %>').value;
            var Module = document.getElementById('<%=ddlSelectModule.ClientID %>');
            var selectedModule = Module.options[Module.selectedIndex].innerHTML;
            var Projects = document.getElementById('<%=ddlSelectProject.ClientID %>');
            var selectedProject = Projects.options[Projects.selectedIndex].innerHTML;
            var categories = document.getElementById('<%=ddlCategory.ClientID %>');
            var selectedCategories = categories.options[categories.selectedIndex].innerHTML;
            PageMethods.ValidateShortDescription(ShortDesc, selectedModule, selectedProject, selectedCategories, OnSuccess, onError);
            function OnSuccess(response, userContext, methodName) {

                var LnameImage = document.getElementById('<%=shortdescTrue.ClientID %>');
                var errLname = document.getElementById('<%=errorShortDesc.ClientID %>');
                if (response == false) {

                    LnameImage.style.display = "block";
                    errLname.style.display = "none";

                }
                if (response == true) {
                    errLname.style.display = "block";
                    errLname.style.color = "Red";
                    errLname.innerHTML = "Name Alreay Exists"
                    LnameImage.style.display = "none";

                }
            }
            function onError(response, userContext, methodName) {


            }
        }
    </script>
</asp:Content>
