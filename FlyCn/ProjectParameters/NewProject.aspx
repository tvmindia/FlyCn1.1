<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewProject.aspx.cs" Inherits="FlyCn.ProjectParameters.NewProject" %>

<!DOCTYPE html>

<script type="text/javascript">
   

</script>
<script>
    function nexttab()
    {
        var CurrentView = <%=  (UpdatePanel1.FindControl("MultiView1") as MultiView).ActiveViewIndex %>
   alert("Current Active View Index Is :" + CurrentView);
        
        var MultiView =  <%= (UpdatePanel1.FindControl("MultiView1") as MultiView).ClientID%>
        alert(MultiView);
        
    }
</script>
<script>
    function SetActiveTab(tabControl, tabNumber)
    {
        var ctrl = $find(tabControl); ctrl.set_activeTab(ctrl.get_tabs()[tabNumber]);
    }

</script> 
  <script runat="server">

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
        int index = Int32.Parse(e.Item.Value);
            
        MultiView1.ActiveViewIndex = index;
            if(index==0)
            {
                btnSkipFinish.Visible = false;
                btnFinish.Visible=false;
                btnNext.Visible = true;
             
             
            }
            else if(index==1)
            {
                btnNext.Visible = true;
                btnFinish.Visible = false;
                btnSkipFinish.Visible = true;
            }
            else if(index==2)
            {
                btnNext.Visible = false;
                btnFinish.Visible = true;
                btnSkipFinish.Visible = false;
            }
      
           
        }


    
</script>


     <script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            //MultiView1.ActiveViewIndex = 0;
            //Tab1.CssClass = "Clicked";
        MultiView1.ActiveViewIndex = 0;
        btnSkipFinish.Visible = false;
        btnFinish.Visible = false;
        
    }
   </script>

   
 <script runat="server">

     protected void btnNext_Click(object sender, EventArgs e)
     {
      //   MultiView1.ActiveViewIndex++;
         
      //var i= Convert.ToString(  Menu1.TabIndex);
      MultiView1.SetActiveView(MultiView1.Views[++MultiView1.ActiveViewIndex]);
         if(MultiView1.ActiveViewIndex == 1)
         {
             btnSkipFinish.Visible = true;
           //  ((Menu)Master.FindControl("NavigationMenu")).Items[0].Selected = true;
             Menu1.Items[1].Selected = true;
           
         }
         if (MultiView1.ActiveViewIndex == 2)
         {
             btnFinish.Visible = true;
             Menu1.Items[2].Selected = true;
             
         }
      ShowViewBtn();
         
      //   var s=i+1;
      //Menu1.Items[].Selected=true;
      //Menu1.SelectedItem.Value = i;
       
     }

    
</script>
<script runat="server">
    private void ShowViewBtn()
    {
        //btnPre.Visible =mvTest.ActiveViewIndex > 0;
        btnNext.Visible = MultiView1.ActiveViewIndex < MultiView1.Views.Count - 1;
        
    }
 
</script>
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 45px;
        }
    </style>
  
     <style type="text/css">
.Initial
{
  display: block;
  padding: 4px 18px 4px 18px;
  float: left;
  background-color:#197575;
  color: Black;
  font-weight: bold;
}
.Initial:hover
{
  color: White;
 background-color:#75ACAC;
}
.Clicked
{
  float: left;
  display: block;
  background-color:#B2CCCC;
  padding: 4px 18px 4px 18px;
  color: Black;
  font-weight: bold;
  color: White;
}

.input_text
   {
       border:1px solid #c0c0c0;
        padding:4px;
        font-size:14px;
       color:#000000;
        background-color:#ffffff;
   }
.table tr  td
{
  
    font-family: 'segoe UI' , Tahoma, Geneva, Verdana, sans-serif;  
font-size: 11px;
font-weight: normal;
color: #333333;

}
table {
  border-collapse: collapse;
  width: 100%;

 
}
th, td {
 
  text-align: left;
  height:50px;
  padding-left:2em;


}
  td, label 
  { 
        height: 40px;
        min-height: 100%;                
       font-family: 'segoe UI' , Tahoma, Geneva, Verdana, sans-serif;  
 }

  td.myclass
{
  text-align:left;
  vertical-align:middle;
  width:300px;
}

  #tdbuttonclass{
      width:50px;
  }

.Clicked
{
 
  border-radius:5px;
    
}
.Initial 
{   
              background: rgba(34,34,34,0.75);
}
.headings
{
   font-family:'segoe UI' , Tahoma, Geneva, Verdana, sans-serif;  
   font-size:18px;
   font-style:normal;
}
.selectedmenustyle
{
    background-color:transparent;
    color:#CC3300
}
#Menu1 {
    text-align: center;
    margin-right:auto;
    margin-left: auto;
 
}
</style>

 
</head>
<body>
  
    <form id="form1" runat="server" >   
        <%--<asp:Button ID="btnPopup" runat="server" Text="Show Popup" />--%>
  <asp:ScriptManager ID="ScriptManager1" runat="server">
             </asp:ScriptManager>

        
<div id="bodyDiv">
<div>
        <asp:Menu ID="Menu1" runat="server" CssClass="" OnMenuItemClick="Menu1_MenuItemClick" Orientation="Horizontal" 
        style="left: 0px; position: relative; top: 22px" Height="48px" Width="800px"  >
            <StaticMenuStyle HorizontalPadding="0px" VerticalPadding="0px"   />
            <StaticSelectedStyle BackColor="#C0C0C0"   BorderStyle="Solid" ForeColor="#CC3300" BorderColor="#669999" BorderWidth="1px" /><%--BorderColor="#C0C0FF"--%>
           <StaticMenuItemStyle Width="240px" Height="18px"  BackColor="#808080" BorderStyle="Solid" BorderWidth="1px"
                BorderColor="#148BB3"  ForeColor="White"  CssClass="Clicked" /><%--BorderWidth="20px"--%>
            <DynamicMenuItemStyle BorderColor="Red" BorderStyle="Solid"/>
            <Items>
                <asp:MenuItem Text="Base Details" Value="0" Selected="True"></asp:MenuItem>
                <asp:MenuItem Text="Company & Client Details" Value="1"></asp:MenuItem>
                <asp:MenuItem Text="Advanced Info" Value="2"></asp:MenuItem>
            </Items>
            <StaticHoverStyle BackColor="Silver" />           
          <%--  <StaticMenuItemStyle  BorderColor="#C0C0FF" BorderStyle="Solid" BorderWidth="1px" /> --%>
        </asp:Menu>
    <%--  <asp:Button Text="Tab 1" BorderStyle="None" ID="Tab1" CssClass="Initial" runat="server"
              OnClick="Tab1_Click" />
          <asp:Button Text="Tab 2" BorderStyle="None" ID="Tab2" CssClass="Initial" runat="server"
              OnClick="Tab2_Click" />
          <asp:Button Text="Tab 3" BorderStyle="None" ID="Tab3" CssClass="Initial" runat="server"
              OnClick="Tab3_Click" />
               </td>--%>    
         </div>      
      <div style="width:750px; height:400px; background-color:#DCDCCA; overflow:scroll; background:transparent; overflow-x:hidden; scrollbar-base-color:seagreen" >

             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                   <br /> 
                    <div>
                        <table>
                            <tr>
                                <td>

                                </td>
                                <td>
                                    <table style="width:100%;">
            <tr>
                <td>
                    <asp:Label ID="lblProjectNo" runat="server" Text="Project No"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtProjectNo" runat="server"></asp:TextBox>
                </td>
               
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblProjectName" runat="server" Text="Project Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtProjectName" runat="server"></asp:TextBox>
                </td>
              
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblProjectLocation" runat="server" Text="Project Location"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtProjectLocation" runat="server"></asp:TextBox>
                </td>
              
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblProjectManager" runat="server" Text="Project Manager"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtProjectManager" runat="server"></asp:TextBox>
                </td>
             
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblBaseProject" runat="server" Text="Base Project" ForeColor="Gray"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtBaseProject" runat="server" Enabled="false"></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblAct" runat="server" Text="Active"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtActive" runat="server"></asp:TextBox>
                </td>
              
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
         
            </tr>
          
        </table>
                                </td>
                            </tr>
                        </table>
        
            </div>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <br />
                   <div>
                       <table>
                           <tr>
                               <td>

                               </td>
                               <td>
                                  <asp:Label ID="lblCmpnyDetails" CssClass="headings" runat="server" Text="Company Details"  ForeColor="#CC3300"></asp:Label>
                                   <table style="width:100%;">
                                       
        <tr>
            <td  class="myclass">
                <asp:Label ID="lblCompanyName" runat="server" Text="Company Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
            </td>
         
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblAddress1" runat="server" Text="Address 1"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAddress1" runat="server"></asp:TextBox>
            </td>
            
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblAddress2" runat="server" Text="Address 2"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAddress2" runat="server"></asp:TextBox>
            </td>
          
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTelephone" runat="server" Text="Telephone"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTelephone" runat="server"></asp:TextBox>
            </td>

        </tr>
        <tr>
            <td>
                <asp:Label ID="lblFax" runat="server" Text="Fax"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFax" runat="server"></asp:TextBox>
            </td>
           
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </td>
          
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblWebsite" runat="server" Text="Website"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtWebsite" runat="server"></asp:TextBox>
            </td>
           
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCompanyLogo" runat="server" Text="Company Logo"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCompanyLogo" runat="server"></asp:TextBox>
            </td>
           
        </tr>
        
    </table>
                                   <div>
<hr />
                                  <asp:Label ID="lblClientDetails" runat="server"   CssClass="headings" Text="Client Details"  ForeColor="#CC3300"></asp:Label>

            <table style="width:100%;">
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                   
                </tr>
                <tr>
            <td class="myclass">
                <asp:Label ID="lblClientName" runat="server" Text="Client Name"></asp:Label>
            </td>
            <td >
                <asp:TextBox ID="txtClientName" runat="server"></asp:TextBox>
            </td>
           
                </tr>
                <tr>
            <td>
                <asp:Label ID="lblContractDetails" runat="server" Text="Contract Details"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtContractDetails" runat="server"></asp:TextBox>
            </td>
           
                </tr>
                <tr>
            <td>
                <asp:Label ID="lblClientTelephone" runat="server" Text="Telephone"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtClientTelephone" runat="server"></asp:TextBox>
            </td>
         
                </tr>
                <tr>
            <td>
                <asp:Label ID="lblClientFax" runat="server" Text="Fax"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtClientFax" runat="server"></asp:TextBox>
            </td>
          
                </tr>
                <tr>
            <td>
                <asp:Label ID="lblClientEmail" runat="server" Text="Email"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtClientEmail" runat="server"></asp:TextBox>
            </td>
            
                </tr>
                <tr>
            <td>
                <asp:Label ID="lblClientWebsite" runat="server" Text="Website"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtClientWebsite" runat="server"></asp:TextBox>
            </td>
          
                </tr>
                <tr>
            <td>
                <asp:Label ID="lblClientLogo" runat="server" Text="Client Logo"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtClientLogo" runat="server"></asp:TextBox>
            </td>
          
                </tr>
                <tr>
                    <td class="auto-style2"></td>
                    <td class="auto-style2"></td>
                   
                </tr>
            </table>

        </div>
                               </td>
                           </tr>
                       </table>   
    </div>
                    <br />
                </asp:View>
                <asp:View ID="View3" runat="server">
                    <br />
                   <table>
                       <tr>
                           <td>

                           </td>
                           <td>
    <asp:Label ID="lblAdminHeading" runat="server"  CssClass="headings" Text="Admin Details" ForeColor="#CC3300"></asp:Label>
                                       <div>
   <table style="width: 100%;">
        
        <tr>
            <td class="myclass">
                <asp:Label ID="lblImplimentationEngineer" runat="server" Text="Implementation Engineer "></asp:Label>
            </td>
            <td >
                <asp:TextBox ID="txtImplimentationEngineer" runat="server"></asp:TextBox>
            </td>
       
                </tr>
        <tr>
            <td >
                <asp:Label ID="lblProjectAdmin" runat="server" Text="Project Admin"></asp:Label>
            </td>
            <td >
                <asp:TextBox ID="txtProjectAdmin" runat="server"></asp:TextBox>
            </td>
           
                </tr>
        <tr>
            <td >
                <asp:Label ID="lblPunchListFromCompany" runat="server" Text="PunchList From Company"></asp:Label>
            </td>
            <td >
                <asp:TextBox ID="txtPunchListFromCompany" runat="server"></asp:TextBox>
            </td>
        
                </tr>
        <tr>
            <td >
                <asp:Label ID="lblPunchListFromPerson" runat="server" Text="PunchList From Person"></asp:Label>
            </td>
            <td >
                <asp:TextBox ID="txtPunchListFromPerson" runat="server"></asp:TextBox>
            </td>
      
                </tr>
        <tr>
            <td >
                <asp:Label ID="lblPunchListToCompany" runat="server" Text="PunchList To Company"></asp:Label>
            </td>
            <td >
                <asp:TextBox ID="txtPunchListToCompany" runat="server"></asp:TextBox>
            </td>

                </tr>
        <tr>
            <td >
                <asp:Label ID="lblPunchListToPerson" runat="server" Text="PunchList To Person"></asp:Label>
            </td>
            <td >
                <asp:TextBox ID="txtPunchListToPerson" runat="server"></asp:TextBox>
            </td>
           
                </tr>
        <tr>
            <td  colspan="2"></td>
        </tr>
        
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
        </div>
<hr />
                    <asp:Label ID="lblCaptionforProjectFields" runat="server"   CssClass="headings" Text="Caption for Project Fields" ForeColor="#CC3300"></asp:Label>
           
        <div>
            <table style="width: 100%;">
            <tr>
                <td class="myclass">
                    <asp:Label ID="lblPlant" runat="server" Text="Plant"></asp:Label>
                </td>
                <td >
                    <asp:TextBox ID="txtPlant" runat="server"></asp:TextBox>
                </td>
               
            </tr>
                <tr>
                <td >
                    <asp:Label ID="lblArea" runat="server" Text="Area"></asp:Label>
                    </td>
                <td >
                    <asp:TextBox ID="txtArea" runat="server"></asp:TextBox>
                    </td>
               
                </tr>
                <tr>
                <td >
                    <asp:Label ID="lblLocation" runat="server" Text="Location"></asp:Label>
                    </td>
                <td >
                    <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox>
                    </td>
               
                </tr>
                <tr>
                <td >
                    <asp:Label ID="lblSystem" runat="server" Text="System"></asp:Label>
                    </td>
                <td >
                    <asp:TextBox ID="txtSystem" runat="server"></asp:TextBox>
                    </td>
               
                </tr>
                <tr>
                <td >
                    <asp:Label ID="lblSubSystem" runat="server" Text="Sub System"></asp:Label>
                    </td>
                <td >
                    <asp:TextBox ID="txtSubSystem" runat="server"></asp:TextBox>
                    </td>
               
                </tr>
                <tr>
                <td >
                    <asp:Label ID="lblMiscManpowerTracking" runat="server" Text="Misc Manpower Tracking"></asp:Label>
                    </td>
                <td >
                    <asp:TextBox ID="txtMiscManpowerTracking" runat="server"></asp:TextBox>
                    </td>
               
                </tr>
            <tr>
                <td>
                </td>
              
            </tr>
            
        </table>
        </div>
                               <hr />
<div>

    <asp:Label ID="lblManHoursRelatedCaption" runat="server"  CssClass="headings" Text=" Man Hours Related Captions" ForeColor="#CC3300"></asp:Label>

            <table style="width: 100%;">
    
                <tr>
                <td class="myclass" >
                    <asp:Label ID="lblOtherCost1" runat="server" Text="Other Cost1"></asp:Label>
                    </td>
                <td >
                    <asp:TextBox ID="txtOtherCost1" runat="server"></asp:TextBox>
                    </td>
               
                </tr>
                <tr>
                <td >
                    <asp:Label ID="lblOtherCost2" runat="server" Text="Other Cost2"></asp:Label>
                    </td>
                <td >
                    <asp:TextBox ID="txtOtherCost2" runat="server"></asp:TextBox>
                    </td>
               
                </tr>
                <tr>
                <td >
                    <asp:Label ID="lblOtherCost3" runat="server" Text="Other Cost3"></asp:Label>
                    </td>
                <td >
                    <asp:TextBox ID="txtOtherCost3" runat="server"></asp:TextBox>
                    </td>
               
                </tr>
                <tr>
                <td >
                    <asp:Label ID="lblPaymentsettings" runat="server" Text="Payment Settings "></asp:Label>
                    </td>
                <td >
                    &nbsp;</td>
               
                </tr>
                <tr>
                <td >
                    <asp:Label ID="lblPaymentCurrency" runat="server" Text="Payment Currency" ForeColor="#CC3300"></asp:Label>
                    </td>
                <td >
                    <asp:TextBox ID="txtPaymentCurrency" runat="server"></asp:TextBox>
                    </td>
               
                </tr>
                <tr>
                <td >
                    <asp:Label ID="lblLunchBreakMinutes" runat="server" Text="Lunch Break Minutes"></asp:Label>
                    </td>
                <td >
                    <asp:TextBox ID="txtLunchBreakMinutes" runat="server"></asp:TextBox>
                    </td>
               
                </tr>
    <tr>
        <td colspan="2">&nbsp;</td>
      
    </tr>
    
</table>
        </div>
                               <hr />
                    <div>
            <table  style="width: 100%;">
        <tr>
            <td class="myclass">		
            <asp:Label ID="lblHierarchyCaptions" runat="server"  CssClass="headings" Text="Hierarchy Captions" ForeColor="#CC3300"></asp:Label>
</td>
       
        </tr>
                <tr>
                <td >
                    <asp:Label ID="lblLevel1" runat="server" Text="Level 1"></asp:Label>
                    </td>
                <td >
                    <asp:TextBox ID="txtLevel1" runat="server"></asp:TextBox>
                    </td>
               
                </tr>
                <tr>
                <td >
                    <asp:Label ID="lblLevel2" runat="server" Text="Level 2"></asp:Label>
                    </td>
                <td >
                    <asp:TextBox ID="txtLevel2" runat="server"></asp:TextBox>
                    </td>
               
                </tr>
                <tr>
                <td >
                    <asp:Label ID="lblLevel3" runat="server" Text="Level 3"></asp:Label>
                    </td>
                <td >
                    <asp:TextBox ID="txtLevel3" runat="server"></asp:TextBox>
                    </td>
               
                </tr>
                <tr>
                <td >
                    <asp:Label ID="lblClientRealatedCaption" runat="server"  CssClass="headings" Text="Client Related Captions" ForeColor="#CC3300"></asp:Label>

                    </td>
                <td >
                    &nbsp;</td>
               
                </tr>
                <tr>
                <td >
                    <asp:Label ID="lblClient1" runat="server" Text="Client 1"></asp:Label>
                    </td>
                <td >
                    <asp:TextBox ID="txtClient1" runat="server"></asp:TextBox>
                    </td>
               
                </tr>
                <tr>
                <td >
                    <asp:Label ID="lblClient2" runat="server" Text="Client 2"></asp:Label>
                    </td>
                <td >
                    <asp:TextBox ID="txtClient2" runat="server"></asp:TextBox>
                    </td>
               
                </tr>
                <tr>
                <td >
                    <asp:Label ID="lbl3rdParty" runat="server" Text="3rd Party"></asp:Label>
                    </td>
                <td >
                    <asp:TextBox ID="txt3rdParty" runat="server"></asp:TextBox>
                    </td>
               
                </tr>
        
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
 
        </tr>
    </table>
        </div>
                           </td>
                       </tr>
                   </table>
                        
        
        	
            


                </asp:View>
            </asp:MultiView>
      </ContentTemplate>
                 </asp:UpdatePanel>
     


            </div>
        
          
           <%--  //<input id="Button1" type="button" value="button" onclick="nexttab()" />--%>
        <table  >
            <tr>
                <td>
         <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" Height="40px" Width="80px" />
                    <asp:Button ID="btnSkipFinish" runat="server" Text="Skip And Finish" Height="40px" />
          <asp:Button ID="btnFinish" runat="server" Text="Finish" OnClick="btnFinish_Click" Width="80px" Height="40px"  />

                </td>
               
            </tr>
        </table>
      
        </div>
</form>    
    
</body>
</html>


