﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="ImportErrorDetails.aspx.cs" Inherits="FlyCn.ExcelImport.ImportErrorDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik"%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
</asp:ScriptManager>
     <div class="PageHeading">Error Details</div>
    <div class="container inputMainContainer"  >
  <div class="col-md-12"   >
       
    <div id="content"  >
         
             <telerik:radgrid ID="RadGrid1_ErrorDetails" runat="server" >
              <HeaderStyle  HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <AlternatingItemStyle HorizontalAlign="Left" />
                                        <ClientSettings>
                                            <Selecting AllowRowSelect="true" EnableDragToSelectRows="false" />
                                       
                                        </ClientSettings>
                                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="Status_Id">
                                            <Columns>

                                               
                                                  <telerik:GridBoundColumn HeaderText="File Name" DataField="File_Name" UniqueName="File_Name" ></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Key Field" DataField="Key_Field" UniqueName="Key_Field" ></telerik:GridBoundColumn>
                                                 <telerik:GridBoundColumn HeaderText="Error Description" DataField="Error_Description" UniqueName="Error_Description"></telerik:GridBoundColumn>
                                                 <telerik:GridBoundColumn HeaderText="Error_Count" DataField="Error_Count" UniqueName="Error_Count" ></telerik:GridBoundColumn>
                                                 <telerik:GridBoundColumn HeaderText="Start Time" DataField="Start_Time" UniqueName="Start_Time"  ></telerik:GridBoundColumn>
                                                
                                            </Columns>
                                        </MasterTableView>
        </telerik:radgrid>
               </div>
        </div>
      </div>
</asp:Content>