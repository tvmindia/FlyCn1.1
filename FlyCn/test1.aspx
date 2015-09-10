<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test1.aspx.cs" Inherits="FlyCn.test1" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:WizardID="wizardTest" runat="server" Width="467px"BackColor="#EFF3FB" BorderColor="#B5C7DE"
        BorderWidth="1px"Height="500px" DisplayCancelButton="True"
     >
        <WizardSteps>
            <asp:WizardStepID="WizardStep1" runat="server"Title="Personal">
                <h3>
                    Personal Profile</h3>
                Preferred Programming Language:
                <asp:DropDownListID="lstLanguage" runat="server">
                   <asp:ListItem>C#</asp:ListItem>
                   <asp:ListItem>VB</asp:ListItem>
                    <asp:ListItem>J#</asp:ListItem>
                   <asp:ListItem>Java</asp:ListItem>
                   <asp:ListItem>C++</asp:ListItem>
                   <asp:ListItem>C</asp:ListItem>
                </asp:DropDownList>
                <br />
            </asp:WizardStep>
            <asp:WizardStepID="WizardStep2" runat="server" Title="Company"AllowReturn="False">
                <h3>
                    Company Profile</h3>
                Number of Employees:
                <asp:TextBoxID="txtEmpCount" runat="server" />
                Number of Locations:
                <asp:TextBoxID="txtLocCount" runat="server" />
            </asp:WizardStep>
            <asp:WizardStepID="WizardStep3" runat="server"Title="Software">
                <h3>
                    Software Profile</h3>
                Licenses Required:
                <asp:CheckBoxListID="lstTools" runat="server">
                    <asp:ListItem>VisualStudio 2008</asp:ListItem>
                    <asp:ListItem>Office2007</asp:ListItem>
                    <asp:ListItem>WindowsServer 2008</asp:ListItem>
                    <asp:ListItem>SQLServer 2008</asp:ListItem>
                </asp:CheckBoxList>
            </asp:WizardStep>
            <asp:WizardStepID="Complete" runat="server" Title="Complete">
                <br />
                Thank you for completing thissurvey.<br />
                Your products will be deliveredshortly.<br />
            </asp:WizardStep>
        </WizardSteps>
       
 
        <StartNavigationTemplate>
           <i>StartNavigationTemplate</i><br />
            <asp:ButtonID="StartNextButton" runat="server"Font-Size="35" Text="Start"CommandName="MoveNext" />
        </StartNavigationTemplate>
        <StepNavigationTemplate>
           <i>StepNavigationTemplate</i><br />
            <asp:ButtonID="StepPreviousButton" runat="server"CausesValidation="False" CommandName="MovePrevious"
                Text="Previous" />
            <asp:ButtonID="StepNextButton" runat="server" Text="Next"CommandName="MoveNext" />
        </StepNavigationTemplate>
 
        <FinishNavigationTemplate>
           <i>FinishNavigationTemplate</i><br />
            <asp:ButtonID="FinishPreviousButton" runat="server" CausesValidation="False"Text="Previous"
               CommandName="MovePrevious" />
            <asp:ButtonID="FinishButton" Font-Size="35" runat="server"Text="Finish" CommandName="MoveComplete" />
        </FinishNavigationTemplate>
       

</asp:Wizard>
<</asp:WizardID>
       
    </div>
       
    </form>
</body>
</html>
