#region namespace
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
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.collapsenode();", true);
            try
            {
           
               
                UA = (FlyCnDAL.Security.UserAuthendication)Session[Const.LoginSession];
                Users userobj = new Users(UA.userName);
                verifierEmail = userobj.UserEMail;

                if (!IsPostBack)
                {
                    dtgPendingApprovalGrid.Rebind();
                    string logIDMail = Request.QueryString["logid"];
                    
                    if (logIDMail != null)//during the call from a mail
                    {
                         ApprovelMaster approvalmasterObj = new ApprovelMaster();
                         string userName = approvalmasterObj.GetUserNameByLogId(logIDMail);//username of mail sent user
                         if (userName != UA.userName)//not the same user logined
                         {
                             RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("1");
                             tab.Selected = true;
                             tab.Text = "Pending";
                             RadMultiPage1.SelectedIndex = 0;//redirecting user to pending grid
                                   
                         }
                        if(userName == UA.userName)
                        {
                            RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("2");
                            tab.Selected = true;
                            tab.Text = "Approval";
                            RadMultiPage1.SelectedIndex = 1;
                            PendingApprovalGridBindByLogID(logIDMail);
                        }
                    
                      
                    }
                }
                ToolBarApprovalDoc.OnClientButtonClicking = "OnClientButtonClickingApproval";
                ToolBarApprovalDoc.onClick += new RadToolBarEventHandler(ToolBar_onClick);
                ToolBarVisibility();
            }
            catch(Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
            }
            finally
            {

            }

        }
        #endregion Page_Load

        #region dtgPendingApprovalGrid_NeedDataSource
        protected void dtgPendingApprovalGrid_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            PendingApprovalGridBind();

        }
        #endregion dtgPendingApprovalGrid_NeedDataSource
        #region dtgPendingApprovalGridBind
        public void PendingApprovalGridBind()
        {
            try
            {
                DataSet ds = new DataSet();
                approvelMaster = new ApprovelMaster();
                ds = approvelMaster.GetAllPendingApprovalsByVerifier(verifierEmail);
                dtgPendingApprovalGrid.DataSource = ds;

            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
            }
        }
        #endregion dtgPendingApprovalGridBind

        #region dtgPendingApprovalGrid_PreRender
        protected void dtgPendingApprovalGrid_PreRender(object sender, EventArgs e)
        {
            dtgPendingApprovalGrid.Rebind();
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
                    ActionItemCommand(e);
                    
                }
                if(e.CommandName=="Details")
                {

                
                }
            }
            catch(Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
            }

        }
        #endregion dtgPendingApprovalGrid_ItemCommand

        #region ActionItemCommand
        public void ActionItemCommand(GridCommandEventArgs e)
        {
           
            GridDataItem item = e.Item as GridDataItem;
            hiddenFieldDocOwner.Value = item.GetDataKeyValue("DocumentOwner").ToString();
            hiddenFiedldProjectno.Value = item.GetDataKeyValue("ProjectNo").ToString();
            hiddenFieldApprovalID.Value = item.GetDataKeyValue("ApprovalID").ToString();
            hiddenFieldDocumentID.Value = item.GetDataKeyValue("DocumentID").ToString();
            hiddenFieldRevisionID.Value = item.GetDataKeyValue("RevisionID").ToString();
            hiddenFieldDocumentType.Value = item.GetDataKeyValue("DocumentType").ToString();
            hiddenFieldDocumentNo.Value = item.GetDataKeyValue("DocumentNo").ToString();
            lblDocumentNo.Text = item.GetDataKeyValue("DocumentNo").ToString();
            lblRevisionNo.Text = item.GetDataKeyValue("RevisionNo").ToString();
            lblCreatedDate.Text = string.Format("{0:dd/MMM/yyyy}", item.GetDataKeyValue("DocCreatedDate"));
            lblProjectno.Text = item.GetDataKeyValue("ProjectNo").ToString();
            lblDocumentType.Text = item.GetDataKeyValue("DocumentType").ToString();
            lblDocumentTitle.Text = item.GetDataKeyValue("DocumentTitle").ToString();
            lblDocumentDate.Text = string.Format("{0:dd/MMM/yyyy}", item.GetDataKeyValue("DocumentDate"));
            lblDocOwner.Text = item.GetDataKeyValue("DocumentOwner").ToString();
            lblCreatedBy.Text = item.GetDataKeyValue("DocCreatedBy").ToString();
            lblClosedDate.Text = string.Format("{0:dd/MMM/yyyy}", item.GetDataKeyValue("CreatedDate"));
            dtgApprovers.Rebind();
        }

        #endregion ActionItemCommand
       
        #region PendingApprovalGridBindByLogID
        public void PendingApprovalGridBindByLogID(string logID)//approval detail bind during login bypass from mail
        {
            try
            {
                DataSet ds = new DataSet();
                approvelMaster = new ApprovelMaster();
                Guid LogID;
                Guid.TryParse(logID, out LogID);
                if (LogID != Guid.Empty)
                {
                    ds = approvelMaster.GetAllPendingApprovalsByLogID(LogID);
                    if (ds.Tables.Count > 0)
                    {
                        DataTable dt = ds.Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            hiddenFieldDocOwner.Value = ds.Tables[0].Rows[0]["DocumentOwner"].ToString();
                            hiddenFiedldProjectno.Value = ds.Tables[0].Rows[0]["ProjectNo"].ToString();
                            hiddenFieldApprovalID.Value = ds.Tables[0].Rows[0]["ApprovalID"].ToString();
                            hiddenFieldDocumentID.Value = ds.Tables[0].Rows[0]["DocumentID"].ToString();
                            hiddenFieldRevisionID.Value = ds.Tables[0].Rows[0]["RevisionID"].ToString();
                            hiddenFieldDocumentType.Value = ds.Tables[0].Rows[0]["DocumentType"].ToString();
                            hiddenFieldDocumentNo.Value = ds.Tables[0].Rows[0]["DocumentNo"].ToString();
                            hiddenFieldRevisionNo.Value = ds.Tables[0].Rows[0]["RevisionNo"].ToString();
                            lblDocumentNo.Text = ds.Tables[0].Rows[0]["DocumentNo"].ToString();
                            lblCreatedDate.Text = string.Format("{0:dd/MMM/yyyy}", ds.Tables[0].Rows[0]["DocCreatedDate"]);
                            lblProjectno.Text = ds.Tables[0].Rows[0]["ProjectNo"].ToString();
                            lblDocumentType.Text = ds.Tables[0].Rows[0]["DocumentType"].ToString();
                            lblDocumentDate.Text = string.Format("{0:dd/MMM/yyyy}", ds.Tables[0].Rows[0]["DocumentDate"]);
                            lblDocOwner.Text = ds.Tables[0].Rows[0]["DocumentOwner"].ToString();
                            lblDocumentTitle.Text = ds.Tables[0].Rows[0]["DocumentTitle"].ToString();
                            lblCreatedBy.Text = ds.Tables[0].Rows[0]["DocCreatedBy"].ToString();
                            lblClosedDate.Text = string.Format("{0:dd/MMM/yyyy}", ds.Tables[0].Rows[0]["CreatedDate"]);
                            lblRevisionNo.Text = ds.Tables[0].Rows[0]["RevisionNo"].ToString();

                        }
                        else
                        {
                            RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("1");
                            tab.Selected = true;
                            tab.Text = "Pending";
                            RadMultiPage1.SelectedIndex = 0;
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
            }

        }
        #endregion PendingApprovalGridBindByLogID

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
                    hiddenFieldClientDocNo.Value =approvelMaster.ClientDocNo;
                    hiddenFieldStatus.Value =Convert.ToString(approvelMaster.LatestStatus);
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

        #region  ToolBarApprovalDoc_onClick
        protected void ToolBar_onClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            string functionName = e.Item.Value;
            string approvid = hiddenFieldApprovalID.Value;
            string revisionid = hiddenFieldRevisionID.Value;
            string DocOwner = hiddenFieldDocOwner.Value;
            if (e.Item.Value == "Approve")
            {
                Approve(approvid, revisionid, DocOwner);
                TabChange();//to change radtab
            }
            if (e.Item.Value == "Decline")
            {
                Decline(approvid, revisionid, DocOwner);
                TabChange();
            }
            if (e.Item.Value == "Reject")
            {
                Reject(approvid, revisionid, DocOwner);
                TabChange();
            }
         
        }
        #endregion ToolBar_onClick
        #region TabChange
        //changing tab to pending tab after action
        public void TabChange()
        {
            RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("1");
            tab.Selected = true;
            tab.Text = "Pending";
            RadMultiPage1.SelectedIndex = 0;
        }

        #endregion TabChange

        #region Reject_method
        public void Reject(string approvid, string revisionid, string DocOwner)
        {
            if (txtRemarks.Text != "")
            {
                approvelMaster = new ApprovelMaster();
              
                try
                {
                    //string approvid = hiddenFieldApprovalID.Value;
                    approvelMaster.ApprovalStatus = 3;//3 means Rejected
                    approvelMaster.ApprovalDate = System.DateTime.Now;
                    approvelMaster.Remarks = txtRemarks.Text;
                    approvelMaster.RevisionID = revisionid;
                    approvelMaster.ApprovalID = approvid;
                    approvelMaster.RejectApprovalMaster(approvid, revisionid, DocOwner,UA.userName);
                   
                }
                catch (Exception ex)
                {
                    var page = HttpContext.Current.CurrentHandler as Page;
                    eObj.ErrorData(ex, page);
                    throw ex;
                }
                finally
                {
                    dtgPendingApprovalGrid.DataBind();
                }
            }

        }
        #endregion Reject_method
        #region Decline_method

        public void Decline(string approvid, string revisionid, string DocOwner)
        {
           if (txtRemarks.Text != "")
            {
                approvelMaster = new ApprovelMaster();
              
               
                try
                {
                    //string approvid = hiddenFieldApprovalID.Value;
                    approvelMaster.ApprovalStatus = 2;//2 means declined
                    approvelMaster.ApprovalDate = System.DateTime.Now;
                    approvelMaster.Remarks = txtRemarks.Text;
                    approvelMaster.RevisionID = revisionid;

                    approvelMaster.DeclineApprovalMaster(approvid, revisionid, DocOwner,UA.userName);
                    
                }
                catch (Exception ex)
                {
                    var page = HttpContext.Current.CurrentHandler as Page;
                    eObj.ErrorData(ex, page);
                    throw ex;
                }

                finally
                {
                    dtgPendingApprovalGrid.Rebind();
                }
            }
        }
        #endregion  Decline_method
        #region Approve_method
        public void Approve(string approvid, string revisionid, string DocOwner)//Approves the document
        {
            approvelMaster = new ApprovelMaster();
                     
            try
            {
                //string approvid = hiddenFieldApprovalID.Value;
                approvelMaster.RevisionID = revisionid;
                approvelMaster.ApprovalID = approvid;
                approvelMaster.ApprovalStatus = 4;//4 means approved
                approvelMaster.ApprovalDate = System.DateTime.Now;
                approvelMaster.Remarks = txtRemarks.Text;
                approvelMaster.UpdateApprovalMaster(approvid, revisionid, DocOwner,UA.userName);
               
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
            }
            finally
            {
                dtgPendingApprovalGrid.Rebind();

            }
        }


        #endregion Approve_method


        #region lnkbtnDetail_Click
        protected void lnkbtnDetail_Click(object sender, EventArgs e)
        {
            string Revisionid;
            Revisionid = hiddenFieldRevisionID.Value;
            string cretedby=lblCreatedBy.Text;
            string date=  lblCreatedDate.Text;
            ContentDocDetails.Attributes["src"] = "DocDetails.aspx?Revisionid=" + Revisionid + "&Documentno=" + hiddenFieldDocumentNo.Value + "&DocumentType=" + hiddenFieldDocumentType.Value + "&CreatedBy=" + cretedby +"&Createddate="  + date + "&LatestStatus=" + hiddenFieldStatus.Value + "&ClientDocNo=" +hiddenFieldClientDocNo.Value;//iframe page BOQDetails.aspx is called with query string revisonid
            ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenNewProjectWizard", "OpenNewProjectWizard();", true);

             
        }
        #endregion lnkbtnDetail_Click

        #region dtgPendingApprovalGrid_ItemDataBound
        protected void dtgPendingApprovalGrid_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                foreach (GridColumn col in dtgPendingApprovalGrid.MasterTableView.AutoGeneratedColumns)
                {
                  
                    if (col.DataType == typeof(DateTime))
                    {
                        ((GridDateTimeColumn)col).DataFormatString = "{0:dd/MM/yyyy}";
                    }
                }
            }
        }
        #endregion dtgPendingApprovalGrid_ItemDataBound

        #region ToolBarVisibility
        public void ToolBarVisibility()
        {
            ToolBarApprovalDoc.AddButton.Visible = false;
            ToolBarApprovalDoc.SaveButton.Visible = false;
            ToolBarApprovalDoc.UpdateButton.Visible = false;
            ToolBarApprovalDoc.DeleteButton.Visible = false;
            ToolBarApprovalDoc.EditButton.Visible = false;
            ToolBarApprovalDoc.ApproveButton.Visible = true;
            ToolBarApprovalDoc.DeclineButton.Visible = true;
            ToolBarApprovalDoc.RejectButton.Visible = true;
        }
        #endregion ToolBarVisibility

       

    }
}

