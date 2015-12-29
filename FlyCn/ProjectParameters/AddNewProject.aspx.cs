using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace FlyCn.ProjectParameters
{
    public partial class AddNewProject : System.Web.UI.Page
    {
      
       
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

     

        protected void btnFinish_Click(object sender, EventArgs e)
        {
            InsertData();
        }
      
        public void InsertData()
        {
            FlyCn.FlyCnDAL.ProjectParameters pp = new FlyCnDAL.ProjectParameters();
            pp.ProjectNo = txtProjectNo.Text;
            pp.ProjectName = txtProjectName.Text;
            pp.ProjectLocation = txtProjectLocation.Text;
            pp.BaseProject = txtBaseProject.Text;
            pp.ProjectManager = txtProjectManager.Text;
            if (chkActive.Checked == true)
            {
                pp.Active = Convert.ToByte(true);
            }

            pp.CompName = txtCompanyName.Text;
            pp.CompAdd1 = txtCmpnyAddress1.Text;
            pp.CompAdd2 = txtCmpnyAddress2.Text;
            pp.CompTeleNo = txtCmpnyTelephone.Text;
            pp.CompFaxNo = txtCmpnyFax.Text;
            pp.CompEmailAdd = txtCmpnyEmail.Text;
            pp.CompWebSite = txtCmpnyWebsite.Text;
            pp.ClientName = txtClientName.Text;
            pp.ContractNo = txtContractDetails.Text;


            pp.FromCompCode = txtPunchListFromCompany.Text;
            pp.ToCompCode = txtPunchListToCompany.Text;

            //,[DrumPrefix]
            pp.Plant_Caption = txtPlant.Text;
            pp.Area_Caption = txtArea.Text;
            pp.Location_Caption = txtLocation.Text;

            // ,[Unit_Caption]
            pp.TO_System_Caption = txtSystem.Text;
            pp.TO_SubSystem_Caption = txtSubSystem.Text;
            pp.SchCaptionLevel1 = txtLevel1.Text;
            pp.SchCaptionLevel2 = txtLevel2.Text;
            pp.SchCaptionLevel3 = txtLevel3.Text;
            pp.CaptionForOtherCost1 = txtOtherCost1.Text;
            pp.CaptionForOtherCost2 = txtOtherCost2.Text;
            pp.CaptionForOtherCost3 = txtOtherCost3.Text;
            pp.PaymentCurrency = txtPaymentCurrency.Text;
            // pp.LunchBreak_Minutes=txtLunchBreakMinutes.Text;
            pp.Regional_ImplEngineer = txtImplimentationEngineer.Text;
            pp.Project_Administrator = txtProjectAdmin.Text;
            pp.Weld_Client1Caption = txtClient1.Text;
            pp.Weld_Client2Caption = txtClient2.Text;
            pp.Weld_ThirdPartyCaption = txt3rdParty.Text;
            if (FileUploadCompanyLogo.FileName != "")
            {
                CompanyFileInsertion();
            }
            if (FileUploadClientLogo.FileName != "")
            {
                ClientFileInsertion();
            }
            pp.MiscManpowerTracking_Caption = txtMiscManpowerTracking.Text;
            int result = pp.InsertSYSProjectsData();
            if (result == 1)
            {
                lblsuccessmsg.Text = "Data Inserted successfully";
                lblsuccessmsg.ForeColor = System.Drawing.Color.Green;

            }
            else
            {
                lblsuccessmsg.Text = "Data Not Inserted";
                lblsuccessmsg.ForeColor = System.Drawing.Color.Red;
            }

        }

        public void CompanyFileInsertion()
        {
            FlyCn.FlyCnDAL.ProjectParameters pp = new FlyCnDAL.ProjectParameters();
            string[] validFileTypes = {  "png","PNG"};
            int size = 10;
            string ext = System.IO.Path.GetExtension(FileUploadCompanyLogo.FileName);
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
            int fileSize = Convert.ToInt32(FileUploadCompanyLogo.PostedFile.ContentLength);
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

                if ((FileUploadCompanyLogo.HasFile) && (largerSize == false))
                {
                    //System.IO.Stream mystream;
                    //mystream=ImageUpload.FileContent;
                    //  mystream.Read(pp.Company_Logo,0,ImageUpload.PostedFile.ContentLength);
                    pp.Company_Logo = FileUploadCompanyLogo.FileContent;

                }
            }
        }

        public void ClientFileInsertion()
        {
            FlyCn.FlyCnDAL.ProjectParameters pp = new FlyCnDAL.ProjectParameters();

            string[] validFileTypes1 = { "png","PNG" };
                                  
            int size1 = 10;
            string ext1 = System.IO.Path.GetExtension(FileUploadClientLogo.FileName);
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
            int fileSize1 = Convert.ToInt32(FileUploadClientLogo.PostedFile.ContentLength);
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

                if ((FileUploadClientLogo.HasFile) && (largerSize1 == false))
                {
                    //System.IO.Stream mystream;
                    //mystream=ImageUpload.FileContent;
                    //  mystream.Read(pp.Company_Logo,0,ImageUpload.PostedFile.ContentLength);
                    pp.Client_Logo = FileUploadClientLogo.FileContent;

                }
            }


        }

        protected void btnSkipFinish_Click(object sender, EventArgs e)
        {
            InsertData();
        }


        protected void Page_Init(object sender, EventArgs e)
        {
            AlertData();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AlertData();
            }
        }
    }
}