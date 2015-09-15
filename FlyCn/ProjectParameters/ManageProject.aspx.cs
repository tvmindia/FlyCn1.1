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

namespace FlyCn.ProjectParameters
{
    public partial class ManageProject : System.Web.UI.Page
    {
        ErrorHandling eObj = new ErrorHandling();
        FlyCnDAL.ProjectParameters pObj = new FlyCnDAL.ProjectParameters();
        protected void Page_Load(object sender, EventArgs e)
        {
            ToolBar.onClick += new RadToolBarEventHandler(ToolBar_onClick);
            ToolBar.OnClientButtonClicking = "OnClientButtonClicking";
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
                int result = pObj.DeleteSYSProjectsData(ProjectNo);
                if (result == 1)
                {
                    RadGrid1.Rebind();
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
        #region RadGrid1_NeedDataSource1
        protected void RadGrid1_NeedDataSource1(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataTable dt;
            dt = pObj.GetProjectDetails();
            RadGrid1.DataSource = dt;
            DataTable dts;
        //    dts = mObj.GetDEtailsFromPersonal();
         //   RadGrid1.DataSource = dts;
        }
        #endregion RadGrid1_NeedDataSource1

        protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if(e.CommandName=="EditData")
            {
                TabAddEditSettings tabs = new TabAddEditSettings();

                RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("2");
                tabs.EditTab(tab);

                RadMultiPage1.SelectedIndex = 1;
                ToolBar.AddButton.Visible = false;
                ToolBar.SaveButton.Visible = false;
                ToolBar.UpdateButton.Visible = true;
                ToolBar.DeleteButton.Visible = true;
                txtProjNo.Enabled = false;
                string projno = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ProjectNo"].ToString();
                DataTable dt;
                dt = pObj.GetProjectParameters(projno);
               txtProjName.Text = dt.Rows[0]["ProjectName"].ToString();
               txtProjNo.Text=dt.Rows[0]["ProjectNo"].ToString();
                
                txtLocation.Text = dt.Rows[0]["ProjectLocation"].ToString();
                txtManager.Text = dt.Rows[0]["Project_Manager"].ToString();
                txtCompanyName.Text = dt.Rows[0]["CompName"].ToString();
                txtAddress1.Text = dt.Rows[0]["CompAdd1"].ToString();
                txtAddress2.Text = dt.Rows[0]["CompAdd2"].ToString();
                txtTelephone.Text = dt.Rows[0]["CompTeleNo"].ToString();
                txtFax.Text = dt.Rows[0]["CompFaxNo"].ToString();
                txtEmail.Text = dt.Rows[0]["CompEmailAdd"].ToString();
                txtWebsite.Text = dt.Rows[0]["CompWebSite"].ToString();
                txtClientName.Text = dt.Rows[0]["ClientName"].ToString();
                txtContractDetails.Text = dt.Rows[0]["ContractNo"].ToString();
                //txtClientTelephone.Text = dt.Rows[0][""].ToString();
                // txtClientFax.Text = dt.Rows[0][""].ToString();
                //txtClientWebsite.Text = dt.Rows[0][""].ToString();
                //txtClientEmail.Text = dt.Rows[0][""].ToString();
                txtImplementation.Text = dt.Rows[0]["Regional_ImplEngineer"].ToString();
                txtProjectAdmin.Text = dt.Rows[0]["Project_Administrator"].ToString();
                //txtPunchList.Text = dt.Rows[0][""].ToString();
                // txtPunchListPerson.Text = dt.Rows[0][""].ToString();
                // txtPunchListToCompany.Text = dt.Rows[0][""].ToString();
                //txtPunchListToPerson.Text = dt.Rows[0][""].ToString();
                txtPlant.Text = dt.Rows[0]["Plant_Caption"].ToString();
                txtArea.Text = dt.Rows[0]["Area_Caption"].ToString();
                txtLocation.Text = dt.Rows[0]["Location_Caption"].ToString();
                txtSystem.Text = dt.Rows[0]["TO_System_Caption"].ToString();
                txtsubsystem.Text = dt.Rows[0]["TO_SubSystem_Caption"].ToString();
                txtManPower.Text = dt.Rows[0]["MiscManpowerTracking_Caption"].ToString();
                txtOtherCost1.Text = dt.Rows[0]["CaptionForOtherCost1"].ToString();
                txtOtherCost2.Text = dt.Rows[0]["CaptionForOtherCost2"].ToString();
                txtOtherCost3.Text = dt.Rows[0]["CaptionForOtherCost3"].ToString();
                txtPaymentCurrency.Text = dt.Rows[0]["PaymentCurrency"].ToString();
                txtLunchBreakMinutes.Text = dt.Rows[0]["LunchBreak_Minutes"].ToString();
                txtLevel1.Text = dt.Rows[0]["SchCaptionLevel1"].ToString();
                txtLevel2.Text = dt.Rows[0]["SchCaptionLevel2"].ToString();
                txtLevel3.Text = dt.Rows[0]["SchCaptionLevel3"].ToString();
                txtClient1.Text = dt.Rows[0]["Weld_Client1Caption"].ToString();
                txtClient2.Text = dt.Rows[0]["Weld_Client2Caption"].ToString();
                txtThirdParty.Text = dt.Rows[0]["Weld_ThirdPartyCaption"].ToString();
              
                


                /*-------------image loading-------------------------*/
if( dt.Rows[0]["Company_Logo"]!=DBNull.Value)
{
    string CompanyLogofileName = txtProjNo.Text + lblComapnyLogo.Text + ".png";
    string type = "Company_Logo";
    //fuLogo.FileContent=
    MakeFile(dt.Rows[0], CompanyLogofileName,type);
    imbCompany.ImageUrl = "/Images/ProjectImages/" + CompanyLogofileName;
  
}

if (dt.Rows[0]["Client_Logo"] != DBNull.Value)
{
    string ClientLogofileName = txtProjNo.Text + lblClientLogo.Text + ".png";
    string type = "Client_Logo";
    MakeFile(dt.Rows[0], ClientLogofileName,type);

    imbClientLogo.ImageUrl = "/Images/ProjectImages/" + ClientLogofileName;
}
  


                /*---------------------------------------------------*/







            }
        }


        public void MakeFile(DataRow dr, string filename, string type)
        {
            string filePath = Server.MapPath("/Images/ProjectImages/");

          
            byte[] buffer;
            buffer = (byte[])dr[type];
            System.IO.File.WriteAllBytes(filePath + filename, buffer);

        }

        public void Update()
        {
            try
            {
                int result = 0;
                pObj.ProjectNo = txtProjNo.Text;
                pObj.ProjectName = txtProjName.Text;
                pObj.ProjectLocation = txtLocation.Text;
                pObj.ProjectManager = txtManager.Text;
                pObj.BaseProject = txtBaseProject.Text;
                if (CheckboxActive.Checked == true)
                {
                    pObj.Active = Convert.ToByte(true);
                }
                pObj.CompName = txtCompanyName.Text;
                pObj.CompAdd1 = txtAddress1.Text;
                pObj.CompAdd2 = txtAddress2.Text;
                pObj.CompTeleNo = txtTelephone.Text;
                pObj.CompFaxNo = txtFax.Text;
                pObj.CompEmailAdd = txtEmail.Text;
                pObj.CompWebSite = txtWebsite.Text;
                pObj.ClientName = txtClientName.Text;
                pObj.ContractNo = txtContractDetails.Text;
                pObj.Regional_ImplEngineer = txtImplementation.Text;
                pObj.Project_Administrator = txtProjectAdmin.Text;
                pObj.Plant_Caption = txtPlant.Text;
                pObj.Area_Caption = txtArea.Text;
                pObj.Location_Caption = txtLocation.Text;
                pObj.TO_System_Caption = txtSystem.Text;
                pObj.TO_SubSystem_Caption = txtsubsystem.Text;
                pObj.MiscManpowerTracking_Caption = txtManager.Text;
                pObj.CaptionForOtherCost1 = txtOtherCost1.Text;
                pObj.CaptionForOtherCost2 = txtOtherCost2.Text;
                pObj.CaptionForOtherCost3 = txtOtherCost3.Text;
                pObj.PaymentCurrency = txtPaymentCurrency.Text;
                pObj.LunchBreak_Minutes = Convert.ToDecimal(txtLunchBreakMinutes.Text);
                pObj.SchCaptionLevel1 = txtLevel1.Text;
                pObj.SchCaptionLevel2 = txtLevel2.Text;
                pObj.SchCaptionLevel3 = txtLevel3.Text;
                pObj.Weld_Client1Caption = txtClient1.Text;
                pObj.Weld_Client2Caption = txtClient2.Text;
                pObj.Weld_ThirdPartyCaption = txtThirdParty.Text;

                string name = fuLogo.FileName;
            //    System.IO.FileInfo file = new System.IO.FileInfo(fuLogo.PostedFile.FileName);
                if (fuLogo.FileName != "")
                {
                  
                    string filenameCheck = fuLogo.FileName;
                    fuLogo.PostedFile.Equals(Server.MapPath("~\\Images\\ProjectImages\\" + filenameCheck));
                    string path = "~\\Images\\ProjectImages\\" + filenameCheck;
                    if (File.Exists(path))
                    {
                        File.Delete(path);

                    }
 
                    string[] validFileTypes = {  "png" };
                    int size = 10;
                    string ext = System.IO.Path.GetExtension(fuLogo.FileName);
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
                            //System.IO.Stream mystream;
                            //mystream=ImageUpload.FileContent;
                            //  mystream.Read(pp.Company_Logo,0,ImageUpload.PostedFile.ContentLength);
                            pObj.Company_Logo = fuLogo.FileContent;

                        }
                    }
                }
                if (fuClientLogo.FileName != "")
                {
                    string[] validFileTypes1 = { "png"};
                    int size1 = 10;
                    string ext1 = System.IO.Path.GetExtension(fuClientLogo.FileName);
                    bool isValidFile1 = false;
                    bool largerSize1 = false;
                    for (int i = 0; i < validFileTypes1.Length; i++)
                    {
                        if (ext1 == "." + validFileTypes1[i])
                        {
                            isValidFile1 = true;
                            break;
                        }
                    }
                    int fileSize1 = Convert.ToInt32(fuClientLogo.PostedFile.ContentLength);
                    int fileCal1 = fileSize1 / 1000000;//Converting byte into megabyte
                    if (fileCal1 > size1)
                    {

                        largerSize1 = true;
                    }
                    if (!isValidFile1)
                    {

                        lblmsg1.ForeColor = System.Drawing.Color.Red;
                        lblmsg1.Text = "Invalid File. Please upload a File with extension " +
                                       string.Join(",", validFileTypes1);
                    }
                    else
                    {

                        if ((fuClientLogo.HasFile) && (largerSize1 == false))
                        {
                            //System.IO.Stream mystream;
                            //mystream=ImageUpload.FileContent;
                            //  mystream.Read(pp.Company_Logo,0,ImageUpload.PostedFile.ContentLength);
                            pObj.Client_Logo = fuClientLogo.FileContent;

                        }
                    }


                }
                result = pObj.EditProjectParameters(pObj.ProjectNo);
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.ErrorData(ex, page);
            }
        }

        #region  RadGrid1_PreRender
        protected void RadGrid1_PreRender(object sender, EventArgs e)
        {

            RadGrid1.Rebind();
        }

        #endregion  RadGrid1_PreRender
    }
}