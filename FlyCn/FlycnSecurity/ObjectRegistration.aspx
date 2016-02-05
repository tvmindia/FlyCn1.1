<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="ObjectRegistration.aspx.cs" Inherits="FlyCn.FlycnSecurity.ObjectRegistration" %>

<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >

     <script type="text/javascript">
         function myFn(a) {



             window.location.href = window.location.pathname + "?ParentID=" + a;
             var BrowserOpenedOrNot = document.getElementById("<%= hdnBrowserManualOpen.ClientID %>").value;
            //localStorage.myvariable = "True";
            document.getElementById("<%= hdnBrowserManualOpen.ClientID %>").value = "True";
        }


    </script>

     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
</asp:ScriptManager>

     <asp:Label ID="lblTitle" runat="server" Text=" Object Registration " CssClass="PageHeading" ></asp:Label>

<div class="col-md-12 Span-One">
       <asp:Label ID="lblError" runat="server" Text=" " ForeColor="Red" Font-Size="Larger" style="float:left;font-size:large">
                     </asp:Label>
     </div>
 <div class=" importWizardContainer col-md-12" style="width:95%;">

      

      <div class="col-md-3"  >


          <div class="col-md-12 Span-One">
                   

                        <div class="form-group">


                        <asp:Label ID="lblParent" CssClass="control-label col-md-4"   runat="server" Text="Parent">

          </asp:Label>

                            <div class="col-md-8">
                                       <asp:DropDownList ID="ddlParent" runat="server" CssClass="selectbox" AutoPostBack="true"   OnSelectedIndexChanged="ddlParent_SelectedIndexChanged">

                    </asp:DropDownList>

                            </div>
                        </div>
                       
                </div>
     
          <div class="col-md-12 Span-One">
                   

                        <div class="form-group">


                        <asp:Label ID="lblChild" CssClass="control-label col-md-4"   runat="server" Text="Child">

          </asp:Label>

                            <div class="col-md-8">
             <asp:DropDownList ID="ddlChild" runat="server" CssClass="selectbox" AutoPostBack="true" class="textbox" OnSelectedIndexChanged="ddlChild_SelectedIndexChanged">

                     </asp:DropDownList>
                            
                            </div>
                        </div>
                       
                </div>

         <div class="col-md-12 Span-One">
             &nbsp;

         </div>

          <div class="col-md-12 Span-One">
                   

                        <div class="form-group">


                        <asp:Label ID="lblNewObject" CssClass="control-label col-md-4"   runat="server" Text="New Object">

          </asp:Label>

                            <div class="col-md-8">
                                    <asp:TextBox ID="txtNewObject" runat="server" class="textbox"></asp:TextBox>
                                
                               

                            </div>
                        </div>
                        
                </div>

          <div class="col-md-12 Span-One">
                   

                        <div class="form-group">


                        <asp:Label ID="lblScopeValue" CssClass="control-label col-md-4"   runat="server" Text=" ">

          </asp:Label>

                            <div class="col-md-8">
                                      <asp:Button ID="btnRegister" runat="server" BackColor="#AD141C" ForeColor="White" Text="REGISTER" OnClick="btnRegister_Click"  />
                                
                            </div>
                        </div>
                      
                </div>

          </div>

        <div class="col-md-3">
          
          <asp:Label ID="lblNavigation" CssClass="control-label col-md-1"   runat="server" Text="Navigation" ForeColor="#AD141C" Font-Size="Large">

          </asp:Label>
                <br />
            &nbsp;
               
        <asp:BulletedList ID="navigation" runat="server"  ></asp:BulletedList>
                        
        </div>

         <div class="col-md-1"  style="border-left: 1px solid #cfc7c0;min-height:350px">
          &nbsp;
      </div>

         <div class="col-md-4">
     <%--  <div class="contentTopBar" style="width:500px;display:none" id="contentTopBar" runat="server"></div>--%>


     <asp:GridView ID="gvObjectRegistration" GridLines="None" Width="380px"  runat="server" ForeColor="#333333" >
                          <AlternatingRowStyle BackColor="White"/>
                          <Columns>
                               <asp:TemplateField>

                                <ItemTemplate>
                                    <asp:ImageButton ID="imgBtnDelete" runat="server"  ImageUrl="~/Images/Trash can - 04.png"  OnClientClick="return confirm('Deletion Confirmation \n\n\n\n\ Are you sure you want to delete this item ?');" OnClick="imgBtnDelete_Click"/>
                                <%--   <asp:ImageButton ID="imgBtnUpdate" runat="server" ImageUrl="~/Images/Icons/editToolBarIcon.png" OnClick="imgBtnUpdate_Click" />--%>
                                
                                </ItemTemplate>

                            </asp:TemplateField>
                          </Columns>


                           <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                          <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                          <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                          <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                          <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                          <SortedAscendingCellStyle BackColor="#FDF5AC" />
                          <SortedAscendingHeaderStyle BackColor="#4D0000" />
                          <SortedDescendingCellStyle BackColor="#FCF6C0" />
                          <SortedDescendingHeaderStyle BackColor="#820000" />


                           </asp:GridView>
    </div>
    
</div>

    <asp:HiddenField ID="hdnBrowserManualOpen" runat="server"   />





    <%--<div class="div"> 
     

                <table  style="width:14%" >
                    <tr>
                        <td class="tabletd"></td>

                        <td class="tabletd"></td>

           </tr>
                       
                    <tr>
                         <td class="tabletd"></td>

                         <td class="tabletd"></td>
                    </tr>
 </table>


                <br />
                <br />
                

     
                <table >
                    <tr>
                      <td> </td>

                        <td class="tabletd">

            </td>

                    </tr>
                </table>
      
           
     </div>--%>
    
     <%--<asp:Button ID="BtnRegister" runat="server" Text="Register" />--%>

    

</asp:Content>
