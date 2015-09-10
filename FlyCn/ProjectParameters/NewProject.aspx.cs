using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlyCn.ProjectParameters
{
    public partial class NewProject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RadTabStrip1_TabClick(object sender, Telerik.Web.UI.RadTabStripEventArgs e)
        {

        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {

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
            pp.ProjectLocation = lblProjectLocation.Text;
            pp.BaseProject = txtBaseProject.Text;

            //   pp.Active=txtActive.Text;
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
              string[] validFileTypes = { "bmp", "gif", "png", "jpg", "jpeg", "doc", "docx", "xls", "xlsx","pdf"};
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
                    int fileCal=fileSize/1000000 ;//Converting byte into megabyte
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
            
                  string[] validFileTypes1 = { "bmp", "gif", "png", "jpg", "jpeg", "doc", "docx", "xls", "xlsx","pdf"};
                    int size1 = 10;
                    string ext1 = System.IO.Path.GetExtension(FileUploadClientLogo.FileName);
                    bool isValidFile1 = false;
                    bool largerSize1 = false;
                    for (int i = 0; i < validFileTypes.Length; i++)
                    {
                        if (ext == "." + validFileTypes[i])
                        {
                            isValidFile1 = true;
                            break;
                        }
                    }
                    int fileSize1 = Convert.ToInt32(FileUploadClientLogo.PostedFile.ContentLength);
                    int fileCal1=fileSize/1000000 ;//Converting byte into megabyte
                    if (fileCal1 > size1)
                    {

                        largerSize1 = true;
                    }
                    if (!isValidFile1)
                    {

                        lblmsg1.ForeColor = System.Drawing.Color.Red;
                        lblmsg1.Text = "Invalid File. Please upload a File with extension " +
                                       string.Join(",", validFileTypes);
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
            
            pp.MiscManpowerTracking_Caption = txtMiscManpowerTracking.Text;
            int result = pp.InsertSYSProjectsData();
        }

        protected void btnSkipFinish_Click(object sender, EventArgs e)
        {
            InsertData();
        }
    }
}