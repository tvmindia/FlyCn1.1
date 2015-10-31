﻿#region namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using FlyCn.FlyCnDAL;
using System.Data;
#endregion namespace
namespace FlyCn.Approvels
{
    public partial class ApprovalDocument : System.Web.UI.Page
    {
        #region Global Variables
        ErrorHandling eObj = new ErrorHandling();
        UIClasses.Const Const = new UIClasses.Const();
        FlyCnDAL.Security.UserAuthendication UA;
        string verifierEmail=null;
        ApprovelMaster approvelMaster;
        #endregion Global Variables
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {

            verifierEmail = "albert.thomson@thrithvam.ae";
            if (!IsPostBack)
            {
                dtgPendingApprovalGrid.Rebind();
              

            }
          

        }
        #endregion Page_Load

        #region dtgPendingApprovalGrid_NeedDataSource
        protected void dtgPendingApprovalGrid_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                approvelMaster = new ApprovelMaster();
                ds = approvelMaster.GetAllPendingApprovalsByVerifierLevel(1, verifierEmail);
                dtgPendingApprovalGrid.DataSource = ds;
               
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
            }

        }
        #endregion dtgPendingApprovalGrid_NeedDataSource


        #region dtgPendingApprovalGrid_PreRender
        protected void dtgPendingApprovalGrid_PreRender(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                approvelMaster = new ApprovelMaster();
                ds = approvelMaster.GetAllPendingApprovalsByVerifierLevel(1, verifierEmail);
                dtgPendingApprovalGrid.DataSource = ds;
               
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
            }
        }
        #endregion dtgPendingApprovalGrid_PreRender

        #region dtgPendingApprovalGrid_ItemCommand
        protected void dtgPendingApprovalGrid_ItemCommand(object source, GridCommandEventArgs e)
        {
            try
            {
                if(e.CommandName=="Action")
                {
                    //call ifrma approval screen
                    RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("2");
                    GridDataItem item = e.Item as GridDataItem;
                    tab.Selected = true;
                    tab.Text = "Approval";
                    RadMultiPage1.SelectedIndex = 1;
                    //changing tab
                    hiddenFiedldProjectno.Value = item.GetDataKeyValue("ProjectNo").ToString();
                    hiddenFieldApprovalID.Value = item.GetDataKeyValue("ApprovalID").ToString();
                    hiddenFieldDocumentID.Value = item.GetDataKeyValue("DocumentID").ToString();
                    hiddenFieldRevisionID.Value = item.GetDataKeyValue("RevisionID").ToString();
                    lblCreatedDate.Text = item.GetDataKeyValue("CreatedDate").ToString();
                    lblDocumentNo.Text = item.GetDataKeyValue("DocumentNo").ToString();
                    lblCreatedBy.Text = item.GetDataKeyValue("CreatedBy").ToString();
                    dtgApprovers.Rebind();
                   
                }
                if(e.CommandName=="Details")
                {


                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
        #endregion dtgPendingApprovalGrid_ItemCommand

        #region dtgApprovers_NeedDataSource
        protected void dtgApprovers_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                approvelMaster = new ApprovelMaster();
                string temprevisionid = hiddenFieldRevisionID.Value;
                Guid paramrevisionid;
                Guid.TryParse(temprevisionid, out paramrevisionid);
                if (paramrevisionid!=Guid.Empty)
                {
                    ds = approvelMaster.GetAllPendingApprovalsByVerifierLevel(paramrevisionid);
                    dtgApprovers.DataSource = ds;
                }
               
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
            }

        }

        #endregion dtgApprovers_NeedDataSource

        #region dtgApprovers_PreRender
        protected void dtgApprovers_PreRender(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                approvelMaster = new ApprovelMaster();
                string temprevisionid = hiddenFieldRevisionID.Value;
                Guid paramrevisionid;
                Guid.TryParse(temprevisionid, out paramrevisionid);
                if (paramrevisionid != Guid.Empty)
                {
                    ds = approvelMaster.GetAllPendingApprovalsByVerifierLevel(paramrevisionid);
                    dtgApprovers.DataSource = ds;
                }

            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
            }
        }
        #endregion dtgApprovers_PreRender


        #region BtnApproval
        protected void btnApprove_Click(object sender, EventArgs e)
        {
            approvelMaster = new ApprovelMaster();
           
            try
            {
                string approvid=hiddenFieldApprovalID.Value;
               
                approvelMaster.ApprovalStatus = 4;//4 means approved
                approvelMaster.ApprovalDate = System.DateTime.Now;
                approvelMaster.Remarks = txtRemarks.Text;
                approvelMaster.UpdateApprovalMaster(approvid);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                dtgPendingApprovalGrid.DataBind();

            }

        }
        #endregion BtnApproval
        #region BtnDecline
        protected void btnDecline_Click(object sender, EventArgs e)
        {
            if (txtRemarks.Text != "")
            {
                approvelMaster = new ApprovelMaster();

                try
                {
                    string approvid = hiddenFieldApprovalID.Value;

                    approvelMaster.ApprovalStatus = 2;//2 means declined
                    approvelMaster.ApprovalDate = System.DateTime.Now;
                    approvelMaster.Remarks = txtRemarks.Text;
                    approvelMaster.UpdateApprovalMaster(approvid);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                finally
                {
                    dtgPendingApprovalGrid.DataBind();
                }
            }
            
        }
        #endregion BtnDecline
        #region BtnReject
        protected void btnReject_Click(object sender, EventArgs e)
        {
            if (txtRemarks.Text != "")
            {
                approvelMaster = new ApprovelMaster();
                try
                {
                    string approvid = hiddenFieldApprovalID.Value;
                    approvelMaster.ApprovalStatus = 3;//3 means Rejected
                    approvelMaster.ApprovalDate = System.DateTime.Now;
                    approvelMaster.Remarks = txtRemarks.Text;
                    approvelMaster.UpdateApprovalMaster(approvid);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    dtgPendingApprovalGrid.DataBind();
                }
            }
        }
       
        #endregion BtnReject
        protected void lnkbtnDetail_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenNewProjectWizard", "OpenNewProjectWizard();", true);
        }
    }
}