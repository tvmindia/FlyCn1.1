using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FlyCn.FlyCnDAL;

namespace FlyCn.ProjectParameters
{
    public partial class ManageProject : System.Web.UI.Page
    {
        FlyCnDAL.ProjectParameters pObj = new FlyCnDAL.ProjectParameters();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region ToolBar_OnClick
        protected void ToolBar_onClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
        
            //if (e.Item.Value == "Update")
            //{
               

            //}
           
        }
        #endregion ToolBar_OnClick
        #region RadGrid1_NeedDataSource1
        protected void RadGrid1_NeedDataSource1(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataTable dt;
            dt = pObj.GetProjectDetails();
            RadGrid1.DataSource = dt;
            // DataTable dts;
            //dts = mObj.GetDEtailsFromPersonal();
            //RadGrid1.DataSource = dts;
        }
        #endregion RadGrid1_NeedDataSource1

        protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if(e.CommandName=="EditData")
            {
                string projno = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ProjectNo"].ToString();
                DataTable dt;
                dt = pObj.GetProjectParameters(projno);
                txtProjName.Text = dt.Rows[0]["ProjectName"].ToString();
                txtProjNo.Text=dt.Rows[0]["ProjectNo"].ToString();
                txtLocation.Text = dt.Rows[0]["ProjectLocation"].ToString();
                txtManager.Text = dt.Rows[0]["Project_Manager"].ToString();
                txtCompanyName.Text = dt.Rows[0]["CompName"].ToString();
                txtAddress1.Text=dt.Rows[0]["CompAdd1"].ToString();
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
            }
        }
    }
}