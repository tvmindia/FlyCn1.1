<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="ObjectRegistration.aspx.cs" Inherits="FlyCn.FlycnSecurity.ObjectRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<style>
     /*.textbox {
            width: 48%;
            height: 20px;   
            background-color: #FFF;
            font: 400 12px/18px 'Open Sans', sans-serif;
            color: #000;
            font-weight: normal;
            border: 1px solid #ccc;
            margin: 5px 0 0 0;
            padding: 5px;
        }

      .tabletd {
            width: 1200px;
        }

        .tabletbody {
            width: 1200px;
        }

        .div {
    margin: 10px 0 10px 0;
    padding: 0;
    font-family: Helvetica, arial, sans-serif;
    font-size: 13px;
    color: #454545;
    background: #fff url(../images/bg.png);
    text-shadow: 0 1px 0 rgba(0,0,0,0.02);
    -webkit-font-smoothing: antialiased;
}

.btn{
	margin: 0 10px 0 0;
	padding: 6px 10px;
	color: #606060;
	background: #e0e0e0;
	border: 0 none;
	width: auto;
	display: inline-block;
	-webkit-border-radius: 3px;
	-moz-border-radius: 3px;
	border-radius: 3px;
	-webkit-font-smoothing: antialiased;

	margin: 0 0 25px 0;
}*/



    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >

 <div class="div"> 
     

      <asp:HiddenField ID="hdnBrowserManualOpen" runat="server"   />
    <asp:Label ID="lblError" runat="server" Text=" " ForeColor="Red" Font-Size="Larger">
                     </asp:Label>


<%-- <table class="tabletbody" >
        <tr>
            
            <td class="tabletd">--%>
                <table  style="width:14%" >
                    <tr>
                        <td class="tabletd"><asp:TextBox ID="txtNewObject" runat="server" class="textbox"></asp:TextBox></td>

                        <td class="tabletd"><asp:Button ID="btnRegister" runat="server"   Text="REGISTER" OnClick="btnRegister_Click"  /></td>

           </tr>
                       
                    <tr>
                         <td class="tabletd"><asp:DropDownList ID="ddlParent" runat="server"  AutoPostBack="true"  CssClass="textbox" OnSelectedIndexChanged="ddlParent_SelectedIndexChanged">

                    </asp:DropDownList></td>

                         <td class="tabletd"><asp:DropDownList ID="ddlChild" runat="server" AutoPostBack="true" class="textbox" OnSelectedIndexChanged="ddlChild_SelectedIndexChanged">

                     </asp:DropDownList></td>
                    </tr>
 </table>


                <br />
                <br />
                

     
                <table >
                    <tr>
                      <td> <asp:GridView ID="gvObjectRegistration" GridLines="None" Width="380px" runat="server" >
                          <Columns>
                               <asp:TemplateField>

                                <ItemTemplate>
                                    <asp:ImageButton ID="imgBtnDelete" runat="server"  ImageUrl="~/Images/Trash can - 04.png"  OnClientClick="return confirm('Deletion Confirmation \n\n\n\n\ Are you sure you want to delete this item ?');" OnClick="imgBtnDelete_Click"/>
                                   <asp:ImageButton ID="imgBtnUpdate" runat="server" ImageUrl="~/Images/Icons/editToolBarIcon.png" OnClick="imgBtnUpdate_Click" />
                                
                                </ItemTemplate>

                            </asp:TemplateField>
                          </Columns>


                           </asp:GridView> </td>

                        <td class="tabletd">
 <asp:BulletedList ID="navigation" runat="server"  ></asp:BulletedList>
            </td>

                    </tr>
                </table>
      
           
     
    
     <%--<asp:Button ID="BtnRegister" runat="server" Text="Register" />--%>

    </div>
</asp:Content>
