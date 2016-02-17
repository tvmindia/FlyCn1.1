<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test1.aspx.cs" Inherits="FlyCn.test1" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
 <head>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title>A Simple Responsive HTML Email</title>
        <style type="text/css">
        /*body {margin: 0; padding: 0; min-width: 100%!important;}
        .content {width: 100%; max-width: 600px;}*/  
        </style>
    </head>
  
    <form id="form1" runat="server">
  
    <div style="margin: 0; padding: 0; min-width: 100%!important;">

         Level Description : 
         <div class="gridContainer HeaderBox" style="overflow-x: auto; width: 1200px; margin-left: 1%">
                            <telerik:RadGrid ID="radgrdOverview" runat="server" 
                                EnableLinqExpressions="False" MasterTableView-HierarchyLoadMode="ServerOnDemand"       CellSpacing="0" GridLines="None" AutoGenerateColumns="False" Skin="Metro">
                                <HierarchySettings SelfCollapseTooltip="close" SelfExpandTooltip="open" />

                                <MasterTableView DataKeyNames="code_display,CodeId, ParentId" Width="100%" NoDetailRecordsText="" TableLayout="Fixed">

                                    <SelfHierarchySettings ParentKeyName="ParentId" KeyName="CodeId" MaximumDepth="5" />

                                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

                                    <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>

                                    <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>

                                    <HeaderStyle  ForeColor="#292929" HorizontalAlign="Center" Width ="130px"/>
                                    <ItemStyle Width="130px"/>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="codeId" UniqueName="codeId" Display="false">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="parentId" UniqueName="parentId" Display="false">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="code_display"  UniqueName="code_display" HeaderText="Cost Code">
                                            <HeaderStyle Width="130px"></HeaderStyle>
                                            <ItemStyle Width="130px"></ItemStyle>
                                        </telerik:GridBoundColumn>

                                        <telerik:GridBoundColumn DataField="Description" HeaderStyle-Width="250px" ItemStyle-Width="250px" UniqueName="Description" HeaderText="Description">

                                            <HeaderStyle Width="250px"></HeaderStyle>

                                            <ItemStyle Width="250px"></ItemStyle>

                                        </telerik:GridBoundColumn>

                                        <telerik:GridBoundColumn DataField="Original_Budget"  UniqueName="budget" ItemStyle-HorizontalAlign="Right" HeaderText="Original Budget" DataFormatString ="{0:###,##0;(###,##0);0}">                                         
                                            <HeaderStyle Width="130"></HeaderStyle>                                           
                                            <ItemStyle Width="130" HorizontalAlign="Right"></ItemStyle>
                                        </telerik:GridBoundColumn>
                                       
                                    </Columns>


                                    <EditFormSettings>
                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                                    </EditFormSettings>

                                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                </MasterTableView>
                                   <HeaderStyle Font-Size="13px" HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="true" />
                                    <ItemStyle Font-Size="12px" />
                                    <FooterStyle  Font-Size="12px"  />
                                    <AlternatingItemStyle Font-Size="12px" VerticalAlign="Middle" />

                                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>

                                <FilterMenu EnableImageSprites="False"></FilterMenu>
                            </telerik:RadGrid>
                        </div>

       
        <asp:TextBox ID="txtLevelDescription" runat="server"></asp:TextBox>
        <br />
    UserName:
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnGo" runat="server"  Text="Go" OnClick="btnGo_Click" />
        <asp:label ID="lblPermission" runat="server" text="Label" ></asp:label>

    <div style="border-style: solid; border-color: inherit; border-width: medium; margin: 0; padding: 0; min-width: 100%!important; height:27px; color:lightseagreen; background:lightseagreen; text-align:center;"> <label style="color:white; vertical-align:central; font-family: 'Segoe UI Light'; font-size:18px"> Document For Approvel</label></div>
        <div style="background-color:#f6f8f1; text-align:left;">
                <label style="font:bold; font-size:15px; font-family:'Segoe UI'; color:#006666; margin-left:20px;" > Hi SSSSS</label>
        </div>
        <table width="100%" bgcolor="#f6f8f1" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <table class="content" align="center" cellpadding="0" cellspacing="0" border="0">
                      
                        <tr>
                            <td style="height:50px; ">
                       <div id="music" class="nav">Music I Like <span id="hyperspan"><a href="Music.html"></a></span></div>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:50px">
                               We will send you another email once the items in your order have been shipped. Meanwhile, you can check the status of your order on Flipkart.com
                            </td>
                        </tr>
                        <tr>
                            <td style="height:50px;padding-left:190px">
                          <a href='http://localhost:40922/Approvels/Approvals.aspx'">Link To Document</a>
                                <br />
                                <asp:Button ID="btn_ExcelMail" runat="server" OnClick="btn_ExcelMail_Click" Text="Send Excel Mail" />
                                <br />
                               
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="font-size:12px; color:seagreen;">
                    This is an automatically generated email – please do not reply to it. If you have any queries please email to <a href="mailto:info.thrithvam@gmail.com"> amrutha@thrithvam.com</a>
                </td>
            </tr>
        </table>
        <asp:button runat="server" text="Button" OnClick="Unnamed1_Click" />
        </div>
   
 </form>

    
</html>