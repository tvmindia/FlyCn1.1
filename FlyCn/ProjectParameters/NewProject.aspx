<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewProject.aspx.cs" Inherits="FlyCn.ProjectParameters.NewProject" %>

<!DOCTYPE html>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script type="text/javascript">
   

</script>
<script type="text/javascript">
    function validate() {
        //try{

       
            var ProjectNo = document.getElementById("<%=txtProjectNo.ClientID %>").value;
       
      <%--  document.getElementById("<%=txtProjectNo.ClientID %>").value;--%>
     //   document.getElementById("txtProjectNo");
        var ProjectName = document.getElementById("<%=txtProjectName.ClientID %>").value;
        var ProjectLocation = document.getElementById("<%=txtProjectLocation.ClientID %>").value;
        var ProjectManager = document.getElementById("<%=txtProjectManager.ClientID %>").value;

        if (ProjectNo == "" || ProjectName == "" || ProjectLocation == "" || ProjectManager == "") 
        {

            document.getElementById("<%=hidddenErrormsg.ClientID %>").value = "Please Fill all the Mandatory fields";
           
        }
                //document.getElementById(<%--"<%=lblerrormsg.ClientID %--%>>").style.display="none"
          <%--      return false;
            }--%>
            else
            {
            document.getElementById("<%=hidddenErrormsg.ClientID %>").value = "";
               
            }

           
        //}
        //catch(X)
        //{
        //    alert(X.message);
        //}
        }
</script>
<script>
    function Finalvalidate() {
        document.getElementById("<%=lblerrormsg.ClientID %>").innerHTML = document.getElementById("<%=hidddenErrormsg.ClientID %>").value;
      
        var lblerror = document.getElementById("<%=lblerrormsg.ClientID %>").innerHTML;
        alert(lblerror);
        if (lblerror == "")
        {

            return true;
        }
        else
        {
            return false;
        }
            

    }
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
           //if((txtProjectNo.Text!="") && (txtProjectName.Text!="")&&(txtProjectManager.Text!="") && (txtProjectLocation.Text!=""))
           //{
               
           //}
           // else
           //{
           //    lblerrormsg.Text = "Please Fill all the Mandatory fields";
               
           //}
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
        MultiView1.EnableViewState = true;
        

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
         //if (Page.IsValid)
         //{
         //    lblvalmsg.Text = "Required field is filled!";
         //}
         //else
         //{
         //    lblvalmsg.Text = "Required field is empty!";
         //}
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
 <%--<script runat="server">

     protected void btnSkipFinish_Click(object sender, EventArgs e)
     {
        
     }
     
     </script>--%>

    
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



.input_text
   {
       border:1px solid #c0c0c0;
        padding:4px;
        font-size:14px;
       color:#000000;
        background-color:#ffffff;
   }

table {
  border-collapse: collapse;
  width: 100%;

 
}
th, td {
 
  text-align: left;
  /*padding-left:2em;*/
  padding-right:2em;
}
th, tr{
    height:50px;
    text-align:left;
  vertical-align:bottom;
}
  td, label 
  { 
        
        min-height: 100%;                
       font-family: 'segoe UI' , Tahoma, Geneva, Verdana, sans-serif;  
       color:white;
      
 }

  td.myclass
{
  text-align:left;
 
  width:410px;
 
}
  tr.label
  {
     
      font-size:10px;
      border-bottom:thin;
      border-bottom-style:dotted;
      border-bottom-color:gray;
      height:1px;
   
  }
  #tdbuttonclass{
      width:50px;
  }

.Clicked
{
 
  border-radius:5px;
    float: left;
  display: block;
  background-color:#B2CCCC;
  padding: 4px 18px 4px 18px;
  
}

.headings
{
   font-family:'segoe UI' , Tahoma, Geneva, Verdana, sans-serif;  
   font-size:18px;
   font-style:normal;
   color:#660033;
}

#Menu1
 {
    text-align: center;
    margin-right:auto;
    margin-left: auto;
  font-family: 'segoe UI' , Tahoma, Geneva, Verdana, sans-serif;  
  font-size:17px;   
}
.Successmsg{
    vertical-align:top;
   
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
        style="left: 0px; position: relative; top: 22px" Height="80px" Width="800px"  >
            <StaticMenuStyle HorizontalPadding="0px" VerticalPadding="0px"   />
            <StaticSelectedStyle BackColor="#C0C0C0"   BorderStyle="Solid"  ForeColor="#006666" BorderColor="#669999" BorderWidth="1px" /><%--BorderColor="#C0C0FF"--%>
           <StaticMenuItemStyle Width="240px" Height="18px"  BackColor="#808080" BorderStyle="Solid" BorderWidth="1px"
                BorderColor="#148BB3"  ForeColor="White"  CssClass="Clicked" /><%--BorderWidth="20px"--%>
           
            <Items>
                <asp:MenuItem Text="Base Details" Value="0" Selected="True" ></asp:MenuItem>
                <asp:MenuItem Text="Company & Client Details" Value="1"></asp:MenuItem>
                <asp:MenuItem Text="Advanced Info" Value="2"></asp:MenuItem>
            </Items>
            <StaticHoverStyle BackColor="Silver" />           
          <%--  <StaticMenuItemStyle  BorderColor="#C0C0FF" BorderStyle="Solid" BorderWidth="1px" /> --%>
        </asp:Menu>
  
         </div>    
                    <asp:Label ID="lblerrormsg" CssClass="Successmsg" runat="server" Text="" ForeColor="Red"  ></asp:Label>
    <asp:HiddenField ID="hidddenErrormsg" runat="server" />
 
      <div style="width:750px; height:500px;background-color:transparent; overflow-y:auto; scrollbar-base-color:rgba(36,85,99,.9)" >

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
                    <asp:TextBox ID="txtProjectNo" runat="server"  ></asp:TextBox>
                    <span id="span2" runat="server" style="color: red; font-size: 15px; font-weight: 500;
font-family: Trebuchet MS;">*</span>
    <%-- <asp:RequiredFieldValidator
                             id="RequiredFieldValidator2"
                             ControlToValidate="txtProjectNo" 
                            
                             Display="Static"
                             Width="100%"
                             Text="*" 
                             runat="server" />--%>
                </td>
               
            </tr>
                                        <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblProjectNoCaption" runat="server" Text="This project number will be reffered through out the application"></asp:Label>
                                                 
                                            </td>
                                            <td>

                                            </td>
                                        </tr>
            <tr>
                <td>
                    <asp:Label ID="lblProjectName" runat="server" Text="Project Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtProjectName" runat="server"></asp:TextBox>
                    <span id="span1" runat="server" style="color: red; font-size: 15px; font-weight: 500;
font-family: Trebuchet MS;">*</span>
                </td>
              
            </tr>
                                           <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblProjectNameCaption" runat="server" Text="Proect name will be used for display and reporting purposes"></asp:Label>
                                                 
                                            </td>
                                            <td>

                                            </td>
                                        </tr>
            <tr>
                <td>
                    <asp:Label ID="lblProjectLocation" runat="server" Text="Project Location"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtProjectLocation" runat="server"></asp:TextBox>
                    <span id="span3" runat="server" style="color: red; font-size: 15px; font-weight: 500;
font-family: Trebuchet MS;">*</span>
                </td>
              
            </tr>
                                           <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblProjectLocationCaption" runat="server" Text="The geo location of the project"></asp:Label>
                                                 
                                            </td>
                                            <td>

                                            </td>
                                        </tr>
            <tr>
                <td>
                    <asp:Label ID="lblProjectManager" runat="server" Text="Project Manager"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtProjectManager" runat="server"></asp:TextBox>
                    <span id="span4" runat="server" style="color: red; font-size: 15px; font-weight: 500;
font-family: Trebuchet MS;">*</span>
                </td>
             
            </tr>
                                         <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblProjectManagerCaption" runat="server" Text="Project manager name"></asp:Label>
                                                 
                                            </td>
                                            <td>

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
                                          <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblBaseProjectCaption" runat="server" Text="To inherit data from existing project/sample data from config project."></asp:Label>
                                                 
                                            </td>
                                            <td>

                                            </td>
                                        </tr>
            <tr>
                <td>
                    <asp:Label ID="lblActive" runat="server" Text="Active"></asp:Label>
                </td>
                <td>
                   <%-- <asp:TextBox ID="txtActive" runat="server"></asp:TextBox>--%>
                       <asp:CheckBox 
            ID="chkActive" 
            runat="server" 
      
          
            AutoPostBack="true"
          
            />
                </td>
              
            </tr>
                                          <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblActiveCaption" runat="server" Text="check to activate this project."></asp:Label>
                                                 
                                            </td>
                                            <td>

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
                                

                                  <asp:Label ID="lblCmpnyDetails" CssClass="headings" runat="server" Text="Company Details" ></asp:Label>
                                      <br />
                                   <table style="width:100%;">
                                       
        <tr>
            <td  class="myclass">
                <asp:Label ID="lblCompanyName" runat="server" Text="Company Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
            </td>
         
        </tr>
                                        <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblCompanyNameCaption" runat="server" Text="company name for display and reporting purpose"></asp:Label>
                                                 
                                            </td>
                                            <td>

                                            </td>
                                        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCmpnyAddress1" runat="server" Text="Address 1"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCmpnyAddress1" runat="server"></asp:TextBox>
            </td>
            
        </tr>
                                           <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblCmpnyAddress1Caption" runat="server" Text="company adress details 1"></asp:Label>
                                                 
                                            </td>
                                            <td>

                                            </td>
                                        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCmpnyAddress2" runat="server" Text="Address 2"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCmpnyAddress2" runat="server"></asp:TextBox>
            </td>
          
        </tr>
                                          <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblCmpnyAddress2Caption" runat="server" Text="company adress details 2"></asp:Label>
                                                 
                                            </td>
                                            <td>

                                            </td>
                                        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCmpnyTelephone" runat="server" Text="Telephone"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCmpnyTelephone" runat="server" TextMode="Phone"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredCmpnyTelephone" runat="server" Enabled="True" TargetControlID="txtCmpnyTelephone" FilterType="Numbers" FilterMode="ValidChars">
</cc1:FilteredTextBoxExtender>
              <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtCmpnyTelephone" runat="server"
                     ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"
                    ValidationGroup="Mama"></asp:RegularExpressionValidator>--%>
            </td>

        </tr>
                                           <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblCmpnyTelephoneCaption" runat="server" Text="company telephone number"></asp:Label>
                                                 
                                            </td>
                                            <td>

                                            </td>
                                        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCmpnyFax" runat="server" Text="Fax"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCmpnyFax" runat="server"></asp:TextBox>
            </td>
           
        </tr>
                                        <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblCmpnyFaxCaption" runat="server" Text="company fax details"></asp:Label>
                                                 
                                            </td>
                                            <td>

                                            </td>
                                        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCmpnyEmail" runat="server" Text="Email"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCmpnyEmail" runat="server" TextMode="Email"></asp:TextBox>
            </td>
          
        </tr>
                                          <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblCmpnyEmailCaption" runat="server" Text="company/responsible email id"></asp:Label>
                                                 
                                            </td>
                                            <td>

                                            </td>
                                        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCmpnyWebsite" runat="server" Text="Website"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCmpnyWebsite" runat="server"></asp:TextBox>
            </td>
           
        </tr>
                                          <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblCmpnyWebsiteCaption" runat="server" Text="company wesite URLs"></asp:Label>
                                                 
                                            </td>
                                            <td>

                                            </td>
                                        </tr>
        
    </table>
                                   <div>
                                  <asp:Label ID="lblClientDetails" runat="server"   CssClass="headings" Text="Client Details"  ></asp:Label>
            <table style="width:100%;">
                
                <tr>
            <td class="myclass">
                <asp:Label ID="lblClientName" runat="server" Text="Client Name"></asp:Label>
            </td>
            <td >
                <asp:TextBox ID="txtClientName" runat="server"></asp:TextBox>
            </td>
           
                </tr>
                  <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblClientNameCaption" runat="server" Text="sample description for this fields"></asp:Label>
                                                 
                                            </td>
                                            <td>

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
                  <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblContractDetailsCaption" runat="server" Text="sample description for this field"></asp:Label>
                                                 
                                            </td>
                                            <td>

                                            </td>
                                        </tr>
              <%--  <tr>--%>
                <tr>
            <td>
                <asp:Label ID="lblClientTelephone" runat="server" Text="Telephone"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtClientTelephone" runat="server" TextMode="Phone"></asp:TextBox>
                  <cc1:FilteredTextBoxExtender ID="FilteredClientTelephone" runat="server" Enabled="True" TargetControlID="txtClientTelephone" FilterType="Numbers" FilterMode="ValidChars">
</cc1:FilteredTextBoxExtender>
            </td>
         
                </tr>
                  <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblClientTelephoneCaption" runat="server" Text="Client Telephone Number"></asp:Label>
                                                 
                                            </td>
                                            <td>

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
                <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblClientFaxCaption" runat="server" Text="Client Fax Details"></asp:Label>
                                                 
                                            </td>
                                            <td>

                                            </td>
                                        </tr>
                <tr>
            <td>
                <asp:Label ID="lblClientEmail" runat="server" Text="Email"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtClientEmail" runat="server" TextMode="Email"></asp:TextBox>
            </td>
            
                </tr>
                  <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblClientEmailCaption" runat="server" Text="Client Email Id"></asp:Label>
                                                 
                                            </td>
                                            <td>

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
                   <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblClientWebsiteCaption" runat="server" Text="sample description for this field"></asp:Label>
                                                 
                                            </td>
                                            <td>

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
    <asp:Label ID="lblAdminHeading" runat="server"  CssClass="headings" Text="Admin Details"></asp:Label>
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
        <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblImplimentationEngineerCaption" runat="server" Text="Person who implements the system for the complany"></asp:Label>
                                                 
                                            </td>
                                            <td>

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
           <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblProjectAdminCaption" runat="server" Text="Person to controll the project ,manage acces etc"></asp:Label>
                                                 
                                            </td>
                                            <td>

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
        <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblPunchListFromCompanyCaption" runat="server" Text="In case of any punch list item ,sent behalf of this company"></asp:Label>
                                                 
                                            </td>
                                            <td>

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
          <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblPunchListFromPersonCaption" runat="server" Text="In case of any punch list item ,the default sender will be this person"></asp:Label>
                                                 
                                            </td>
                                            <td>

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
         <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblPunchListToCompanyCaption" runat="server" Text="Punch list will be sent to this company by default"></asp:Label>
                                                 
                                            </td>
                                            <td>

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
         <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblPunchListToPersonCaption" runat="server" Text="Punch list will be sent to this person by default"></asp:Label>
                                                 
                                            </td>
                                            <td>

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
<%--<hr />--%>
                                <div>
                    <asp:Label ID="lblCaptionforProjectFields" runat="server"   CssClass="headings" Text="Caption for Project Fields"></asp:Label>
           
       
            <table style="width: 100%;">
            <tr>
                <td class="myclass">
                    <asp:Label ID="lblPlant" runat="server" Text="Plant"></asp:Label>
                </td>
                <td >
                    <asp:TextBox ID="txtPlant" runat="server"></asp:TextBox>
                </td>
               
            </tr>
                   <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblPlantCaption" runat="server" Text="sample description for this field"></asp:Label>
                                                 
                                            </td>
                                            <td>

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
                <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblAreaCaption" runat="server" Text="sample description for this field"></asp:Label>
                                                 
                                            </td>
                                            <td>

                                            </td>
                                        </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblLocation" runat="server" Text="Location"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox>
                    </td>
                       <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblLocationCaption" runat="server" Text="sample description for this field"></asp:Label>
                                                 
                                            </td>
                                            <td>

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
 <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblSystemCaption" runat="server" Text="sample description for this field"></asp:Label>
                                                 
                                            </td>
                                            <td>

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
                     <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblSubSystemCaption" runat="server" Text="sample description for this field"></asp:Label>
                                                 
                                            </td>
                                            <td>

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
                     <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblMiscManpowerTrackingCaption" runat="server" Text="sample description for this field"></asp:Label>
                                                 
                                            </td>
                                            <td>

                                            </td>
                                        </tr>
            <tr>
                <td>
                </td>
              
            </tr>
            
        </table>
        </div>
                          <%--     <hr />--%>
<div>

    <asp:Label ID="lblManHoursRelatedCaption" runat="server"  CssClass="headings" Text=" Man Hours Related Captions" ></asp:Label>

            <table style="width: 100%;">
    
                <tr>
                <td class="myclass" >
                    <asp:Label ID="lblOtherCost1" runat="server" Text="Other Cost1"></asp:Label>
                    </td>
                <td >
                    <asp:TextBox ID="txtOtherCost1" runat="server"></asp:TextBox>
                    </td>
               
                </tr>
                <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblOtherCost1Caption" runat="server" Text="sample description for this field"></asp:Label>
                                                 
                                            </td>
                                            <td>

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
                 <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblOtherCost2Caption" runat="server" Text="sample description for this field"></asp:Label>
                                                 
                                            </td>
                                            <td>

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
                    <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblOtherCost3Caption" runat="server" Text="sample description for this field"></asp:Label>
                                                 
                                            </td>
                                            <td>

                                            </td>
                                        </tr>
                <tr>
                <td >
                    <asp:Label ID="lblPaymentsettings" CssClass="headings" runat="server" Text="Payment Settings "></asp:Label>
                    </td>
                <td >
                    &nbsp;</td>
               
                </tr>
                  <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblPaymentsettingsCaption" runat="server" Text="sample description for this field"></asp:Label>
                                                 
                                            </td>
                                            <td>

                                            </td>
                                        </tr>
                <tr>
                <td >
                    <asp:Label ID="lblPaymentCurrency" runat="server" Text="Payment Currency" ></asp:Label>
                    </td>
                <td >
                    <asp:TextBox ID="txtPaymentCurrency" runat="server"></asp:TextBox>
                    </td>
               
                </tr>
                  <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblPaymentCurrencyCaption" runat="server" Text="sample description for this field"></asp:Label>
                                                 
                                            </td>
                                            <td>

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
                <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblLunchBreakMinutesCaption" runat="server" Text="sample description for this field"></asp:Label>
                                                 
                                            </td>
                                            <td>

                                            </td>
                                        </tr>
    <tr>
        <td colspan="2">&nbsp;</td>
      
    </tr>
    
</table>
        </div>
                             <%--  <hr />--%>
                    <div>
            <table  style="width: 100%;">
        <tr>
            <td class="myclass">		
            <asp:Label ID="lblHierarchyCaptions" runat="server"  CssClass="headings" Text="Hierarchy Captions" ></asp:Label>
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
                   <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblLevel1Caption" runat="server" Text="superintendent --- sample description for this field if any"></asp:Label>
                                                 
                                            </td>
                                            <td>

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
                   <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblLevel2Caption" runat="server" Text="supervisor--sample description for this field if any"></asp:Label>
                                                 
                                            </td>
                                            <td>

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
                    <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblLevel3Caption" runat="server" Text="foreman --- sample description for this field if any"></asp:Label>
                                                 
                                            </td>
                                            <td>

                                            </td>
                                        </tr>
                <tr>
                <td >
                    <asp:Label ID="lblClientRealatedCaption" runat="server"  CssClass="headings" Text="Client Related Captions" ></asp:Label>

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
                 <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblClient1Caption" runat="server" Text="sample description for this field"></asp:Label>
                                                 
                                            </td>
                                            <td>

                                            </td>
                                        </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblClient2" runat="server" Text="Client 2"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtClient2" runat="server"></asp:TextBox>
                    </td>
                    <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblClient2Caption" runat="server" Text="sample description for this field"></asp:Label>
                                                 
                                            </td>
                                            <td>

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
                       <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lbl3rdPartyCaption" runat="server" Text="sample description for this field"></asp:Label>
                                                 
                                            </td>
                                            <td>

                                            </td>
                                        </tr>  
        
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
 
        </tr>
    </table>
        </div>

<div>
     <asp:Label ID="lblLogos" runat="server"   CssClass="headings" Text="Logos" ></asp:Label>
    <table>

            <tr>
            <td class="myclass">
                <asp:Label ID="lblCompanyLogo" runat="server" Text="Company Logo"></asp:Label>
            </td>
            <td>
                <asp:FileUpload ID="FileUploadCompanyLogo" runat="server" />
            <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
            </td>
           
        </tr>
           <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblCompanyLogoCaption" runat="server" Text="This logo will be displayed in various screens and reports as per settings"></asp:Label>
                                                 
                                            </td>
                                            <td>

                                            </td>
                                        </tr>
       <tr>
            <td>
                <asp:Label ID="lblClientLogo" runat="server" Text="Client Logo"></asp:Label>
            </td>
            <td>
                               <asp:FileUpload ID="FileUploadClientLogo" runat="server" />
                 <asp:Label ID="lblmsg1" runat="server" Text=""></asp:Label>

            </td>
          
                </tr>
                   <tr class="label" >
                                            <td  >
                                                                    <asp:Label ID="lblClientLogoCaption" runat="server" Text="sample description for this field"></asp:Label>
                                                 
                                            </td>
                                            <td>

                                            </td>
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
        

            <table >
               
            <tr>
               
                <td>
                   <%-- <asp:ValidationSummary id="valSum" 
                             DisplayMode="BulletList"
                             EnableClientScript="true"
                             HeaderText="You must enter a value in the following fields:"
                        ForeColor="Red"
                             runat="server"
                               
                        />--%>
                    
         <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" Height="35px" Width="80px"  OnClientClick="validate()"  />
         <asp:Button ID="btnSkipFinish" runat="server" Text="Skip And Finish" Height="35px" OnClick="btnSkipFinish_Click"  OnClientClick="return Finalvalidate()" />
          <asp:Button ID="btnFinish" runat="server" Text="Finish" OnClick="btnFinish_Click" Width="80px" Height="35px" style="margin-top: 7px"  OnClientClick="return Finalvalidate()"  />
                    <asp:Label ID="lblsuccessmsg" runat="server" Text=""></asp:Label>
                </td>
              
            </tr>
        </table>
      
        </div>
</form>    
    
</body>
</html>


