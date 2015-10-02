#region Namespaces
using FlyCn.FlyCnDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
#endregion Namespaces


namespace FlyCn.BOQ
{
    public partial class BOQHeader : System.Web.UI.Page
    {
        #region Global Variables
        DocumentMaster documentMaster;
        BOQHeaderDetails boqHeaderDetails;
        ErrorHandling eObj = new ErrorHandling(); 
        
        UIClasses.Const Const = new UIClasses.Const();
        FlyCnDAL.Security.UserAuthendication UA;
        #endregion Global Variables
        #region Events
        
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            
            UA = (FlyCnDAL.Security.UserAuthendication)Session[Const.LoginSession];
            ToolBar.onClick += new RadToolBarEventHandler(ToolBar_onClick);
            ToolBar.OnClientButtonClicking = "OnClientButtonClicking";
            
           
        }
        public void DisableBOQHeaderTextBox()
        {
            txtClientdocumentno.Attributes.Add("readonly","readonly");
            txtRevisionno.Attributes.Add("readonly", "readonly");
            RadDocumentDate.Attributes.Add("readonly", "readonly");
            txtDocumenttitle.Attributes.Add("readonly", "readonly");
            txtRemarks.Attributes.Add("readonly", "readonly");
        }
        #endregion Page_Load
        #region dtgBOQGrid_NeedDataSource
        protected void dtgBOQGrid_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                documentMaster = new DocumentMaster();
                ds = documentMaster.GetAllBOQDocumentHeader(UA.projectNo, "BOQ");
                dtgBOQGrid.DataSource = ds;
                hiddenFiedldProjectno.Value = ds.Tables[0].Rows[0]["ProjectNo"].ToString();
                hiddenFieldDocumentID.Value = ds.Tables[0].Rows[0]["DocumentID"].ToString();
                hiddenFieldRevisionID.Value = ds.Tables[0].Rows[0]["RevisionID"].ToString();
            }
            catch(Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
            }

        }
        #endregion dtgBOQGrid_NeedDataSource
        #region dtgBOQGrid_PreRender
        protected void dtgBOQGrid_PreRender(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                documentMaster = new DocumentMaster();
                ds = documentMaster.GetAllBOQDocumentHeader(UA.projectNo, "BOQ");
                dtgBOQGrid.DataSource = ds;
                hiddenFiedldProjectno.Value = ds.Tables[0].Rows[0]["ProjectNo"].ToString();
                hiddenFieldDocumentID.Value = ds.Tables[0].Rows[0]["DocumentID"].ToString();
                hiddenFieldRevisionID.Value = ds.Tables[0].Rows[0]["RevisionID"].ToString();
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
            }
        }
        #endregion dtgBOQGrid_PreRender

        #region dtgBOQGrid_ItemCommand
        protected void dtgBOQGrid_ItemCommand(object source, GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EditDoc")
                {
                    ToolBarVisibility(2);
                    RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("2");
                    GridDataItem item = e.Item as GridDataItem;
                    tab.Selected = true;
                    tab.Text = "Edit";
                    RadMultiPage1.SelectedIndex = 1;
                    string ProjectNo = item.GetDataKeyValue("ProjectNo").ToString();

                    Guid DocumentID;
                    Guid.TryParse(item.GetDataKeyValue("DocumentID").ToString(), out DocumentID);


                    DataSet ds = new DataSet();
                    documentMaster = new DocumentMaster();
                    ds = documentMaster.BindBOQ(DocumentID, ProjectNo);
                    //hiddenfield
                    hiddenFiedldProjectno.Value = ds.Tables[0].Rows[0]["ProjectNo"].ToString();
                    hiddenFieldDocumentID.Value = ds.Tables[0].Rows[0]["DocumentID"].ToString();
                    hiddenFieldRevisionID.Value = ds.Tables[0].Rows[0]["RevisionID"].ToString();
                    //hiddenfield
                    txtDocumentno.Text = ds.Tables[0].Rows[0]["DocumentNo"].ToString();
                    txtClientdocumentno.Text = ds.Tables[0].Rows[0]["ClientDocNo"].ToString();
                    txtRevisionno.Text = ds.Tables[0].Rows[0]["RevisionNo"].ToString();
                    RadDocumentDate.SelectedDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["DocumentDate"].ToString());
                    txtDocumenttitle.Text = ds.Tables[0].Rows[0]["DocumentTitle"].ToString();
                    txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                }
                else
                {
                    if (e.CommandName == "DeleteDoc")
                    {

                    }
                }
            }
            catch(Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
            }

        }
        #endregion dtgBOQGrid_ItemCommand
        #region  ToolBar_onClick
        protected void ToolBar_onClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            string functionName = e.Item.Value;
            if (e.Item.Value == "Save")
            {
                AddNewBOQ();
                ToolBarVisibility(1);
                DisableBOQHeaderTextBox();
                
            }
            if (e.Item.Value == "Update")
            {
               

                UpdateBOQ();
                ToolBarVisibility(2);
            }
            if (e.Item.Value == "Delete")
            {
                //Delete();
            }
        }
        #endregion ToolBar_onClick
       
        #endregion Events


        #region Methods
        #region ToolBarVisibility
        public void ToolBarVisibility(int order)
        {
            switch (order)
            {
                   case 1://after adding what should be visible
                    ToolBar.AddButton.Visible = false;
                    ToolBar.SaveButton.Visible = false;
                    ToolBar.UpdateButton.Visible = true;
                    ToolBar.DeleteButton.Visible = false;
                   break;
                   case 2:
                    ToolBar.AddButton.Visible = false;
                    ToolBar.SaveButton.Visible = false;
                    ToolBar.UpdateButton.Visible = true;
                    ToolBar.DeleteButton.Visible = false;
                   break;
                             
            }

        }
       #endregion ToolBarVisibility

        #region insert
        public void AddNewBOQ()
        {
            try
            {
                boqHeaderDetails = new BOQHeaderDetails();
                boqHeaderDetails.documentMaster.ProjectNo = UA.projectNo;//project no has to change//nvarchar10
                boqHeaderDetails.documentMaster.ClientDocNo = (txtClientdocumentno.Text.Trim() != "") ? txtClientdocumentno.Text.Trim().ToString() : null;
                boqHeaderDetails.documentMaster.DocumentType = "BOQ";//nvarchar3
                boqHeaderDetails.documentMaster.DocumentOwner = UA.userName;//nvarchar 50
                boqHeaderDetails.documentMaster.CreatedBy = UA.userName;////nvarchar 50
                boqHeaderDetails.documentMaster.CreatedDate = System.DateTime.Now;//smalldatetime
                boqHeaderDetails.documentMaster.CreatedDateGMT = System.DateTime.Now;//smalldatetime
                boqHeaderDetails.RevisionNo = (txtRevisionno.Text.Trim() != "") ? txtRevisionno.Text.Trim().ToString() : null;
                boqHeaderDetails.DocumentDate = (RadDocumentDate.SelectedDate != null) ? Convert.ToDateTime(RadDocumentDate.SelectedDate) : Convert.ToDateTime(null);
                boqHeaderDetails.DocumentTitle = (txtDocumenttitle.Text.Trim() != "") ? txtDocumenttitle.Text.Trim() : null;
                boqHeaderDetails.Remarks = (txtRemarks.Text.Trim() != "") ? txtRemarks.Text.Trim() : null;
                Guid Revisionid;
                Revisionid = boqHeaderDetails.AddNewBOQ();//Revison id will be returned here
                txtDocumentno.Text = boqHeaderDetails.documentMaster.DocumentNo.ToString();
                ContentIframe.Attributes["src"] = "BOQDetails.aspx?Revisionid=" + Revisionid;//iframe page BOQDetails.aspx is called with query string revisonid
               // ScriptManager.RegisterStartupScript(this.GetType(), "Add", "OpenDetailAccordion();", true);//Accordian calling BOQdetail slide down
               // ScriptManager.RegisterStartupScript(this.GetType(), "VoteJsFunc", "alert('Hey!You are legible to vote!')", true);
            }
            catch(Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
            }
                   
         }
        #endregion insert
        #region UpdateBOQ
        public void UpdateBOQ()
        {
            try
            {
                boqHeaderDetails = new BOQHeaderDetails();
                boqHeaderDetails.documentMaster.ProjectNo = hiddenFiedldProjectno.Value;
                Guid documentID;
                Guid revisionID;
                Guid.TryParse(hiddenFieldDocumentID.Value, out documentID);//converting string to guid
                boqHeaderDetails.documentMaster.DocumentID = documentID;
                Guid.TryParse(hiddenFieldRevisionID.Value, out revisionID);
                boqHeaderDetails.documentMaster.RevisionID = revisionID;
                boqHeaderDetails.documentMaster.ClientDocNo = (txtClientdocumentno.Text.Trim() != "") ? txtClientdocumentno.Text.Trim().ToString() : null;
                boqHeaderDetails.documentMaster.DocumentOwner = UA.userName;
                boqHeaderDetails.documentMaster.UpdatedDate = System.DateTime.Now.ToString();
                boqHeaderDetails.RevisionNo = (txtRevisionno.Text != "") ? txtRevisionno.Text.Trim().ToString() : null;
                boqHeaderDetails.DocumentDate = (RadDocumentDate.SelectedDate != null) ? Convert.ToDateTime(RadDocumentDate.SelectedDate) : Convert.ToDateTime(null);
                boqHeaderDetails.DocumentTitle = (txtDocumenttitle.Text != "") ? txtDocumenttitle.Text : null;
                boqHeaderDetails.Remarks = (txtRemarks.Text != "") ? txtRemarks.Text: null;
                boqHeaderDetails.UpdatedBy = UA.userName;
                boqHeaderDetails.UpdatedDate = System.DateTime.Now.ToString();
                boqHeaderDetails.UpdatedDateGMT = System.DateTime.Now;
                boqHeaderDetails.UpdateBOQ();
            }
            catch(Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
            }
        }

        #endregion UpdateBOQ

        #endregion Methods

    }
}