<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="NewProject.aspx.cs" Inherits="FlyCn.ProjectParameters.NewProject" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
             </asp:ScriptManager>
    <div class="inputMainContainer">
        <div  class="innerDiv">
            <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" Width="300px" OnClientTabSelected="onClientTabSelected"
             CausesValidation="False"   SelectedIndex="0" Skin="Silk" OnTabClick="RadTabStrip1_TabClick" >
            <Tabs>
                <telerik:RadTab Text="Base Details" PageViewID="rpBaseDetails" Value="1" Width="150px" runat="server" ImageUrl="~/Images/Icons/ListIcon.png" Selected="True"  TabIndex="0"  ></telerik:RadTab>
                 <telerik:RadTab Text="Company & Client Details" PageViewID="rpCompany&ClientDetails" Value="2" Width="150px" runat="server" ImageUrl="~/Images/Icons/NewIcon.png"  TabIndex="1"  ></telerik:RadTab>
                 <telerik:RadTab Text="Advanced Info" PageViewID="rpAdvancedInfo" Value="2" Width="150px" runat="server" ImageUrl="~/Images/Icons/NewIcon.png"  TabIndex="1"  ></telerik:RadTab>
           
                 </Tabs>
        </telerik:RadTabStrip>
               
    <uc1:ToolBar runat="server" ID="ToolBar" />

            </div>
        </div>
</asp:Content>
