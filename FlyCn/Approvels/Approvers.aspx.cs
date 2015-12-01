using FlyCn.FlyCnDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlyCn.Approvels
{
    public partial class Approvers : System.Web.UI.Page
    {
        string revid = null;
        ApprovelMaster approvelMaster;
        ErrorHandling eObj = new ErrorHandling();
        DataSet ds=null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Revisionid"] != null)
            {
                revid = Request.QueryString["Revisionid"];//from BOQ header
            }
        }

        #region dtgApprovers_NeedDataSource
        protected void dtgApprovers_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                ApproverBind();

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
                //dtgApprovers.Rebind();

            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
            }
        }
        #endregion dtgApprovers_PreRender

        #region ApproverBind
        public void ApproverBind()
        {
            ds = new DataSet();
            approvelMaster = new ApprovelMaster();
            Guid paramrevisionid;
            Guid.TryParse(revid, out paramrevisionid);
            if (paramrevisionid != Guid.Empty)
            {
              ds = approvelMaster.GetAllPendingApprovalsByVerifierLevel(paramrevisionid);
              dtgApprovers.DataSource = ds;
            }
          
            
        }
        #endregion ApproverBind


    }
}