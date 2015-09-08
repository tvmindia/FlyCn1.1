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
            pp.CompAdd1 = txtAddress1.Text;
            pp.CompAdd2 = txtAddress2.Text;
            pp.CompTeleNo = txtTelephone.Text;
            pp.CompFaxNo = txtFax.Text;
            pp.CompEmailAdd = txtEmail.Text;
            pp.CompWebSite = txtWebsite.Text;
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
            pp.Company_Logo = txtCompanyLogo.Text;
            pp.Client_Logo = txtClientLogo.Text;
            pp.MiscManpowerTracking_Caption = txtMiscManpowerTracking.Text;
            int result = pp.InsertSYSProjectsData();
        }
    }
}