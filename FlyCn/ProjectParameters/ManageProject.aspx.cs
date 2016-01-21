using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FlyCn.FlyCnDAL;
using FlyCn.UIClasses;
using Telerik.Web.UI;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Web.UI.HtmlControls;

namespace FlyCn.ProjectParameters
{
    public partial class ManageProject : System.Web.UI.Page
    {
        ErrorHandling eObj = new ErrorHandling();
        FlyCnDAL.ProjectParameters prjctprmtrObj = new FlyCnDAL.ProjectParameters();

        #region  pageload
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.collapsenode();", true);
            ToolBar.onClick += new RadToolBarEventHandler(ToolBar_onClick);
            ToolBar.OnClientButtonClicking = "OnClientButtonClicking";
            if (!IsPostBack)
            {
                AlertData();
            }
        }
        #endregion  pageload

        public void AlertData()
        {


            var pg = HttpContext.Current.CurrentHandler as Page;
            var master = pg.Master;
            ContentPlaceHolder mpContentPlaceHolder;
            //  Label error = (Label)master.FindControl("lblErrorInfo");
            mpContentPlaceHolder = (ContentPlaceHolder)master.FindControl("MainBody");
            HtmlControl divMask = (HtmlControl)master.FindControl("CommonAlertBox");
            HtmlControl divMask1 = (HtmlControl)master.FindControl("Errorbox");
            divMask1.Style.Remove("visibility");
            divMask.Style.Remove("visibility");
            //divMask.Style.Add("display","none");
            divMask.Style["display"] = "none";
            divMask1.Style["display"] = "none";
         //   divMask.Attributes["class"] = "ErrormsgBoxes";
            //  error.Text = ex.Message;

        }
        #region  ToolBar_onClick
        protected void ToolBar_onClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {

            if (e.Item.Value == "Update")
            {

                Update();
            }
            else if (e.Item.Value == "Delete")
            {
                string ProjectNo = txtProjNo.Text;
                int result = prjctprmtrObj.DeleteSYSProjectsData(ProjectNo);
                if (result == 1)
                {
                    dtgManageProjectGrid.Rebind();
                    //RadTab tab = (RadTab)RadTabStrip1.FindTabByText("View");
                    //tab.Selected = true;
                    //RadTab tab1 = (RadTab)RadTabStrip1.FindTabByText("Edit");
                    //tab1.Text = "New";
                    //tab1.ImageUrl = "~/Images/Icons/NewIcon.png";
                    //RadMultiPage1.SelectedIndex = 0;

                }

            }
        }
        #endregion  ToolBar_onClick

        #region dtgManageProjectGrid_NeedDataSource1
        protected void dtgManageProjectGrid_NeedDataSource1(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataTable datatableobj;
            datatableobj = prjctprmtrObj.GetProjectDetails();
            dtgManageProjectGrid.DataSource = datatableobj;
            DataTable dts;
   
        }
        #endregion dtgManageProjectGrid_NeedDataSource1

        #region  dtgManageProjectGrid_ItemCommand
        protected void dtgManageProjectGrid_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if(e.CommandName=="EditData")
            {
                TabAddEditSettings tabs = new TabAddEditSettings();//change tab name and icon to edit

                RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("2");
                tabs.EditTab(tab);

                RadMultiPage1.SelectedIndex = 1;
                ToolBar.AddButton.Visible = false;
                ToolBar.SaveButton.Visible = false;
                ToolBar.UpdateButton.Visible = true;
                ToolBar.DeleteButton.Visible = true;
             
                /*---------------------------------------------------*/

                string projno = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ProjectNo"].ToString();

                EditDataMethod(projno);



            }
        }
        #endregion  dtgManageProjectGrid_ItemCommand

        #region EditDataMethod
        public void EditDataMethod(string projno)
        {
            txtProjNo.Enabled = false;
         
            DataTable dtbleobj;
            dtbleobj = prjctprmtrObj.GetProjectParameters(projno);
            txtProjName.Text = dtbleobj.Rows[0]["ProjectName"].ToString();
            txtProjNo.Text = dtbleobj.Rows[0]["ProjectNo"].ToString();
            if (dtbleobj.Rows[0]["Active"].ToString() == "True")
            {
                CheckboxActive.Checked = true;
            
                
            }
            else
            {
                CheckboxActive.Checked = false;
            }
            txtLocation.Text = dtbleobj.Rows[0]["ProjectLocation"].ToString();
            txtManager.Text = dtbleobj.Rows[0]["Project_Manager"].ToString();
            txtCompanyName.Text = dtbleobj.Rows[0]["CompName"].ToString();
            txtAddress1.Text = dtbleobj.Rows[0]["CompAdd1"].ToString();
            txtAddress2.Text = dtbleobj.Rows[0]["CompAdd2"].ToString();
            txtTelephone.Text = dtbleobj.Rows[0]["CompTeleNo"].ToString();
            txtFax.Text = dtbleobj.Rows[0]["CompFaxNo"].ToString();
            txtEmail.Text = dtbleobj.Rows[0]["CompEmailAdd"].ToString();
            txtWebsite.Text = dtbleobj.Rows[0]["CompWebSite"].ToString();
            txtClientName.Text = dtbleobj.Rows[0]["ClientName"].ToString();
            txtContractDetails.Text = dtbleobj.Rows[0]["ContractNo"].ToString();
            //txtClientTelephone.Text = dt.Rows[0][""].ToString();
            // txtClientFax.Text = dt.Rows[0][""].ToString();
            //txtClientWebsite.Text = dt.Rows[0][""].ToString();
            //txtClientEmail.Text = dt.Rows[0][""].ToString();
            txtImplementation.Text = dtbleobj.Rows[0]["Regional_ImplEngineer"].ToString();
            txtProjectAdmin.Text = dtbleobj.Rows[0]["Project_Administrator"].ToString();
            //txtPunchList.Text = dt.Rows[0][""].ToString();
            // txtPunchListPerson.Text = dt.Rows[0][""].ToString();
            // txtPunchListToCompany.Text = dt.Rows[0][""].ToString();
            //txtPunchListToPerson.Text = dt.Rows[0][""].ToString();
            txtPlant.Text = dtbleobj.Rows[0]["Plant_Caption"].ToString();
            txtArea.Text = dtbleobj.Rows[0]["Area_Caption"].ToString();
            txtLocation.Text = dtbleobj.Rows[0]["Location_Caption"].ToString();
            txtSystem.Text = dtbleobj.Rows[0]["TO_System_Caption"].ToString();
            txtsubsystem.Text = dtbleobj.Rows[0]["TO_SubSystem_Caption"].ToString();
            txtManPower.Text = dtbleobj.Rows[0]["MiscManpowerTracking_Caption"].ToString();
            txtOtherCost1.Text = dtbleobj.Rows[0]["CaptionForOtherCost1"].ToString();
            txtOtherCost2.Text = dtbleobj.Rows[0]["CaptionForOtherCost2"].ToString();
            txtOtherCost3.Text = dtbleobj.Rows[0]["CaptionForOtherCost3"].ToString();
            txtPaymentCurrency.Text = dtbleobj.Rows[0]["PaymentCurrency"].ToString();
            txtLunchBreakMinutes.Text = dtbleobj.Rows[0]["LunchBreak_Minutes"].ToString();
            txtLevel1.Text = dtbleobj.Rows[0]["SchCaptionLevel1"].ToString();
            txtLevel2.Text = dtbleobj.Rows[0]["SchCaptionLevel2"].ToString();
            txtLevel3.Text = dtbleobj.Rows[0]["SchCaptionLevel3"].ToString();
            txtClient1.Text = dtbleobj.Rows[0]["Weld_Client1Caption"].ToString();
            txtClient2.Text = dtbleobj.Rows[0]["Weld_Client2Caption"].ToString();
            txtThirdParty.Text = dtbleobj.Rows[0]["Weld_ThirdPartyCaption"].ToString();




            /*-------------image loading-------------------------*/
            if (dtbleobj.Rows[0]["Company_Logo"] != DBNull.Value)
            {
                string CompanyLogofileName = txtProjNo.Text + lblComapnyLogo.Text + ".png";
                string type = "Company_Logo";
                //fuLogo.FileContent=
                MakeFile(dtbleobj.Rows[0], CompanyLogofileName, type);
                imbCompany.ImageUrl = "/Images/ProjectImages/" + CompanyLogofileName;

            }

            if (dtbleobj.Rows[0]["Client_Logo"] != DBNull.Value)
            {
                string ClientLogofileName = txtProjNo.Text + lblClientLogo.Text + ".png";
                string type = "Client_Logo";
                MakeFile(dtbleobj.Rows[0], ClientLogofileName, type);

                imbClientLogo.ImageUrl = "/Images/ProjectImages/" + ClientLogofileName;
            }
  


        }

        #endregion EditDataMethod

        #region MakeFile
        public void MakeFile(DataRow dr, string filename, string type)
        {
            string filePath = Server.MapPath("/Images/ProjectImages/");

          
            byte[] buffer;
            buffer = (byte[])dr[type];
            System.IO.File.WriteAllBytes(filePath + filename, buffer);

        }

        #endregion MakeFile

        #region Update
        public void Update()
        {
           
            try
            {
                int result = 0;
                prjctprmtrObj.ProjectNo = txtProjNo.Text;
                prjctprmtrObj.ProjectName = txtProjName.Text;
                prjctprmtrObj.ProjectLocation = txtLocation.Text;
                prjctprmtrObj.ProjectManager = txtManager.Text;
                prjctprmtrObj.BaseProject = txtBaseProject.Text;
                if (CheckboxActive.Checked == true)
                {
                    prjctprmtrObj.Active = Convert.ToByte(true);
                }
                prjctprmtrObj.CompName = txtCompanyName.Text;
                prjctprmtrObj.CompAdd1 = txtAddress1.Text;
                prjctprmtrObj.CompAdd2 = txtAddress2.Text;
                prjctprmtrObj.CompTeleNo = txtTelephone.Text;
                prjctprmtrObj.CompFaxNo = txtFax.Text;
                prjctprmtrObj.CompEmailAdd = txtEmail.Text;
                prjctprmtrObj.CompWebSite = txtWebsite.Text;
                prjctprmtrObj.ClientName = txtClientName.Text;
                prjctprmtrObj.ContractNo = txtContractDetails.Text;
                prjctprmtrObj.Regional_ImplEngineer = txtImplementation.Text;
                prjctprmtrObj.Project_Administrator = txtProjectAdmin.Text;
                prjctprmtrObj.Plant_Caption = txtPlant.Text;
                prjctprmtrObj.Area_Caption = txtArea.Text;
                prjctprmtrObj.Location_Caption = txtLocation.Text;
                prjctprmtrObj.TO_System_Caption = txtSystem.Text;
                prjctprmtrObj.TO_SubSystem_Caption = txtsubsystem.Text;
                prjctprmtrObj.MiscManpowerTracking_Caption = txtManPower.Text;
                prjctprmtrObj.CaptionForOtherCost1 = txtOtherCost1.Text;
                prjctprmtrObj.CaptionForOtherCost2 = txtOtherCost2.Text;
                prjctprmtrObj.CaptionForOtherCost3 = txtOtherCost3.Text;
                prjctprmtrObj.PaymentCurrency = txtPaymentCurrency.Text;
                prjctprmtrObj.LunchBreak_Minutes = Convert.ToDecimal(txtLunchBreakMinutes.Text);
                prjctprmtrObj.SchCaptionLevel1 = txtLevel1.Text;
                prjctprmtrObj.SchCaptionLevel2 = txtLevel2.Text;
                prjctprmtrObj.SchCaptionLevel3 = txtLevel3.Text;
                prjctprmtrObj.Weld_Client1Caption = txtClient1.Text;
                prjctprmtrObj.Weld_Client2Caption = txtClient2.Text;
                prjctprmtrObj.Weld_ThirdPartyCaption = txtThirdParty.Text;
               
                if (fuLogo.FileName != "")
                {
                    CompanyLogoUpdate();
                }
                if (fuClientLogo.FileName != "")
                {

                    ClientLogoUpdate();
                }
             //   ScriptManager.RegisterStartupScript(this, GetType(), "", "validate();", true);
                result = prjctprmtrObj.EditProjectParameters(prjctprmtrObj.ProjectNo);
                if(result==1)
                {
                    EditDataMethod(prjctprmtrObj.ProjectNo);
                }
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.ErrorData(ex, page);
            }
        }
        #endregion Update

        #region CompanyLogoUpdate
        public void CompanyLogoUpdate()
        {
            string CompanyLogofname = txtProjNo.Text + lblComapnyLogo.Text + ".png";
        
            Byte[] imgByte = null;
            HttpPostedFile File = fuLogo.PostedFile;
            imgByte = new Byte[File.ContentLength];
            string filePath = Server.MapPath("/Images/ProjectImages/");

          
            string Path = filePath + CompanyLogofname;
            FileInfo file = new FileInfo(Path);
            if (file.Exists)
            {
                file.Delete();
            }
         



            string[] validFileTypes = { "png" };
            int size = 10;
            string ext = System.IO.Path.GetExtension(CompanyLogofname);
            bool isValidFile = false;
            bool largerSize = false;
            for (int i = 0; i < validFileTypes.Length; i++)
            {
                if (ext == "." + validFileTypes[i])
                {
                    isValidFile = true;
                    break;
                }
            }
            int fileSize = Convert.ToInt32(fuLogo.PostedFile.ContentLength);
            int fileCal = fileSize / 1000000;//Converting byte into megabyte
            if (fileCal > size)
            {

                largerSize = true;
            }
            if (!isValidFile)
            {
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Text = "Invalid File. Please upload a File with extension " +
                               string.Join(",", validFileTypes);
            }
            else
            {

                if ((fuLogo.HasFile) && (largerSize == false))
                {

                    prjctprmtrObj.Company_Logo = fuLogo.FileContent;

                }
            }
        }

        #endregion CompanyLogoUpdate

        #region ClientLogoUpdate
        public void ClientLogoUpdate()
        {

            string ClientLogofname = txtProjNo.Text + lblClientLogo.Text + ".png";

            Byte[] imgByte = null;
            HttpPostedFile File = fuClientLogo.PostedFile;
            imgByte = new Byte[File.ContentLength];
            string filePath = Server.MapPath("/Images/ProjectImages/");

            string Path = filePath + ClientLogofname;
            FileInfo file = new FileInfo(Path);
            if (file.Exists)
            {
                file.Delete();
            }

            string[] ClientLogovalidFileTypes = { "png" };
            int ClientLogoSize = 10;
            string ClientLogoext = System.IO.Path.GetExtension(ClientLogofname);
            bool ClientLogoisValidFile = false;
            bool largerClientLogoSize = false;
            for (int i = 0; i < ClientLogovalidFileTypes.Length; i++)
            {
                if (ClientLogoext == "." + ClientLogovalidFileTypes[i])
                {
                    ClientLogoisValidFile = true;
                    break;
                }
            }
            int fileClientLogoSize = Convert.ToInt32(fuClientLogo.PostedFile.ContentLength);
            int fileCal1 = fileClientLogoSize / 1000000;//Converting byte into megabyte
            if (fileCal1 > ClientLogoSize)
            {

                largerClientLogoSize = true;
            }
            if (!ClientLogoisValidFile)
            {

                lblmsg1.ForeColor = System.Drawing.Color.Red;
                lblmsg1.Text = "Invalid File. Please upload a File with extension " +
                               string.Join(",", ClientLogovalidFileTypes);
            }
            else
            {

                if ((fuClientLogo.HasFile) && (largerClientLogoSize == false))
                {

                    prjctprmtrObj.Client_Logo = fuClientLogo.FileContent;

                }
            }
        }

        #endregion ClientLogoUpdate

        #region  dtgManageProjectGrid_PreRender
        protected void dtgManageProjectGrid_PreRender(object sender, EventArgs e)
        {

            dtgManageProjectGrid.Rebind();
        }

        #endregion  dtgManageProjectGrid_PreRender
    }
}