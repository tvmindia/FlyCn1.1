<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="ApprovalScreen.aspx.cs" Inherits="FlyCn.Approvels.ApprovalScreen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                               <div>
                                <table>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <table style="width: 100%;">
                                                <tr>
                                                     <td>
                                                        <asp:Label ID="lblProjectNo" runat="server" Text="Project No"></asp:Label>
                                                     </td>
                                                     <td>
                                                        <asp:Label ID="lblCreatedDate" runat="server" Text="CreatedDate"></asp:Label>
                                                     </td>
                                                     <td>
                                                        <asp:Label ID="lblCreatedBy" runat="server" Text="CreatedBy"></asp:Label>
                                                     </td>
                                                </tr>
                                                                          
                                              <tr>
                                                  <td>
                                                    &nbsp;&nbsp;
                                                  </td>
                                                  <td>
                                                      <asp:TextBox ID="txtRemarks" runat="server" Width="250" Height="375"></asp:TextBox>
                                                  </td>
                                              </tr>
                                                <tr>
                                                    <td> <asp:LinkButton ID="lnkbtnDetail" runat="server" OnClick="lnkbtnDetail_Click">Detail</asp:LinkButton></td>
                                                   
                                                </tr>
                                                
                                     
                                             </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
    </asp:Content>
