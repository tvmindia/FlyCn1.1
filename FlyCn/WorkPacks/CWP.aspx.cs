using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using DocStatus = FlyCn.DocumentSettings.DocumentStatusSettings;
using FlyCn.FlyCnDAL;
using System.Web.UI.HtmlControls;

namespace FlyCn.WorkPacks
{
    public partial class CWP : System.Web.UI.Page
    {
        #region Public Properties
        private const int ItemsPerRequest = 10;
        DocumentMaster documentMaster;
        ConstructionWorkPacks cwpObj;
         UIClasses.Const Const = new UIClasses.Const();
            FlyCnDAL.Security.UserAuthendication UA;
            HttpContext context = HttpContext.Current;         
        ErrorHandling eObj = new ErrorHandling();
        #endregion Public Properties

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterToolBox();
            if(!IsPostBack)
            {
               
                //BindModule();
            }
            ToolBarVisibility(1);
           
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.collapsenode();", true);
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.DisableTreeNode('rtMid');", true);
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.DisableTreeNode('rtTop');", true);
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.DisableTreeNode('rtBot');", true);
            string tab = Request.QueryString["pack"];
            //if (tab == "tab")
            //{
            //    //Response.Redirect("CWP.aspx");
            //    // ScriptManager.RegisterStartupScript(this, this.GetType(), " ", "refreshCWPQW();", true);
            //}
        }
        #endregion Page_Load

       
        #region Register ToolBox

        public void RegisterToolBox()
        {
            ToolBar.onClick += new RadToolBarEventHandler(ToolBar_onClick);
            ToolBar.OnClientButtonClicking = "OnClientButtonClicking";
        }
        #endregion Register ToolBox

        #region ToolBarVisibility
        public void ToolBarVisibility(int order)
        {
            switch (order)
            {
                case 1://after adding what should be visible
                    ToolBar.AddButton.Visible = false;
                    ToolBar.SaveButton.Visible = true;
                    ToolBar.UpdateButton.Visible = false;
                    ToolBar.EditButton.Visible = false;
                    ToolBar.DeleteButton.Visible = false;
                    ToolBar.AttachButton.Visible = false;
                    break;
                case 2:
                    ToolBar.AddButton.Visible = true;
                    ToolBar.SaveButton.Visible = false;
                    ToolBar.UpdateButton.Visible = true;
                    ToolBar.EditButton.Visible = false;
                    ToolBar.DeleteButton.Visible = false;
                    ToolBar.AttachButton.Visible = false;
                    break;
                case 3:
                    ToolBar.AddButton.Visible = true;
                    ToolBar.SaveButton.Visible = false;
                    ToolBar.UpdateButton.Visible = false;
                    ToolBar.EditButton.Visible = true;
                    ToolBar.DeleteButton.Visible = false;
                    ToolBar.AttachButton.Visible = false;
                    break;
                case 4://toally invicible
                    ToolBar.AddButton.Visible = false;
                    ToolBar.SaveButton.Visible = false;
                    ToolBar.UpdateButton.Visible = false;
                    ToolBar.EditButton.Visible = false;
                    ToolBar.DeleteButton.Visible = false;
                    ToolBar.AttachButton.Visible = false;
                    break;
            }

        }
        #endregion ToolBarVisibility       

        #region dtgCWPHeaderGrid_NeedDataSource
        protected void dtgCWPHeaderGrid_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
                DataSet ds = new DataSet();
                documentMaster = new DocumentMaster();
                ds = documentMaster.GetAllCWPDocumentHeader(UA.projectNo, "CWP");
               
                dtgCWPHeaderGrid.DataSource = ds;
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
            }
            if (dtgCWPHeaderGrid.DataSource == null)
            {
                dtgCWPHeaderGrid.DataSource = new string[] { };
            }
        }
        #endregion dtgCWPHeaderGrid_NeedDataSource

        public void reloadWindow()
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), " ", "refreshCWP();", true);
        }

        #region dtgCWPDetailGrid_NeedDataSource
        protected void dtgCWPDetailGrid_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
               
                cwpObj=new ConstructionWorkPacks();
                UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
                Guid revisionID;
                Guid.TryParse(hiddenFieldRevisionID.Value, out revisionID);
                DataTable ds = new DataTable();
                ds = cwpObj.cwpDetailsObj.GetAllCWPDetail(revisionID,UA.projectNo);
                dtgCWPDetailGrid.DataSource = ds;
                if(ds.Rows.Count>0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Add", "OpenDetailAccordion();", true);
                }
               if(hdfValue.Value=="1")
               {
                   Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.expandnode();", true);
                   Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.showTreeNode();", true);
                   Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.RevisionHistory();", true);
                   Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.HideReviseDocument('rtn3');", true);
               }
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
            }
            if (dtgCWPDetailGrid.DataSource == null)
            {
                dtgCWPDetailGrid.DataSource = new string[] { };
            }
        }
        #endregion dtgCWPDetailGrid_NeedDataSource

        #region ToolBar_onClick
        protected void ToolBar_onClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            string functionName = e.Item.Value;
            if (e.Item.Value == "Save")
            {
                AddNewCWP();
                dtgCWPHeaderGrid.Rebind();
                ToolBarVisibility(2);
            }
            if(e.Item.Value=="Update")
            {
                UpdateCWPHeader();
                dtgCWPHeaderGrid.Rebind();
                ToolBarVisibility(3);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "DisableTextBox", "DisableCWPHeaderTextBox();", true);
                radPlanner.Enabled = false;
            }
            if(e.Item.Value=="Edit")
            {
                ToolBarVisibility(2);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "EnableTextBox", "EnableCWPHeaderTextBox();", true);
                radPlanner.Enabled = true;
                RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("2");
                tab.Selected = true;
                tab.Text = "Edit";
                RadMultiPage1.SelectedIndex = 1;
            }
        }
        #endregion ToolBar_onClick

        #region AddCWPHeader
        public void AddNewCWP()
        {
            DataSet ds = new DataSet();
            documentMaster = new DocumentMaster();
            UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
            try
            {
                cwpObj = new ConstructionWorkPacks();
                cwpObj.documentMaster.ProjectNo = UA.projectNo;
                cwpObj.documentMaster.ClientDocNo = (txtClientDocumentNo.Text.Trim() != "") ? txtClientDocumentNo.Text.Trim().ToString() : null;
                cwpObj.documentMaster.DocumentType = "CWP";
                cwpObj.documentMaster.DocumentOwner = UA.userName;
                cwpObj.documentMaster.CreatedBy = UA.userName;
                cwpObj.documentMaster.CreatedDate = System.DateTime.Now;
                cwpObj.revisionNo = (txtRevisionNo.Text.Trim() != "") ? txtRevisionNo.Text.Trim().ToString() : null;
                cwpObj.documentDate = (txtdatepicker.Value != null) ? Convert.ToDateTime(txtdatepicker.Value) : Convert.ToDateTime(null);
                cwpObj.documentTitle = (txtDocumentTitle.Text.Trim() != "") ? txtDocumentTitle.Text.Trim() : null;
                cwpObj.remarks = (txtRemarks.Text.Trim() != "") ? txtRemarks.Text.Trim() : null;
                cwpObj.planner = (radPlanner.Text.Trim() != "") ? radPlanner.Text.Trim() : null;
                Guid Revisionid;
                Revisionid = cwpObj.AddNewCWPHeader();
                ds = documentMaster.BindCWPHeader(Revisionid);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    hdfProjectNo.Value = ds.Tables[0].Rows[0]["ProjectNo"].ToString();
                    hiddenFieldDocumentID.Value = ds.Tables[0].Rows[0]["DocumentID"].ToString();
                    hiddenFieldRevisionID.Value = ds.Tables[0].Rows[0]["RevisionID"].ToString();
                    txtDocumentNo.Text = ds.Tables[0].Rows[0]["DocumentNo"].ToString();
                    txtDocumentOwner.Text = ds.Tables[0].Rows[0]["DocumentOwner"].ToString();
                    txtdatepicker.Value = ds.Tables[0].Rows[0]["DocumentDate"].ToString();
                }
                if (Revisionid != Guid.Empty)
                {
                    IframeContent.Attributes["src"] = "CWP_Detail.aspx?Revisionid=" + Revisionid;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Add", "OpenDetailAccordion();", true);
                }
            }
            catch(Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
            }
        }
        #endregion AddCWPHeader

        #region UpdateCWPHeader
        public void UpdateCWPHeader()
        {
            try
            {
                UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
                cwpObj = new ConstructionWorkPacks();
                cwpObj.documentMaster.ProjectNo = hdfProjectNo.Value;
                Guid documentID;
                Guid revisionID;
                Guid.TryParse(hiddenFieldDocumentID.Value, out documentID);//converting string to guid
                cwpObj.documentMaster.DocumentID = documentID;
                Guid.TryParse(hiddenFieldRevisionID.Value, out revisionID);
                cwpObj.documentMaster.RevisionID = revisionID;
                cwpObj.documentMaster.ClientDocNo = (txtClientDocumentNo.Text.Trim() != "") ? txtClientDocumentNo.Text.Trim().ToString() : null;
                cwpObj.documentMaster.DocumentOwner = UA.userName;
                cwpObj.documentMaster.UpdatedDate = System.DateTime.Now.ToString();
                cwpObj.revisionNo = (txtRevisionNo.Text != "") ? txtRevisionNo.Text.Trim().ToString() : null;
                cwpObj.documentDate = (txtdatepicker.Value != null) ? Convert.ToDateTime(txtdatepicker.Value) : Convert.ToDateTime(null);
                cwpObj.documentTitle = (txtDocumentTitle.Text != "") ? txtDocumentTitle.Text : null;
                cwpObj.remarks = (txtRemarks.Text != "") ? txtRemarks.Text : null;
                cwpObj.updatedBy = UA.userName;
                cwpObj.updatedDate = System.DateTime.Now.ToString();
                cwpObj.planner = (radPlanner.Text != "") ? radPlanner.Text : null;
                cwpObj.UpdateCWPHeader();
                if (revisionID != Guid.Empty)
                {
                    IframeContent.Attributes["src"] = "CWP_Detail.aspx?Revisionid=" + revisionID;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Add", "OpenDetailAccordion();", true);
                }

            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
            }
        }

        #endregion UpdateCWPHeader

        #region dtgCWPHeaderGrid_ItemCommand
        protected void dtgCWPHeaderGrid_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                 if (e.CommandName == "EditDoc")
                 {
                     RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("2");
                     GridDataItem item = e.Item as GridDataItem;
                     tab.Selected = true;
                     tab.Text = "Edit";
                     RadMultiPage1.SelectedIndex = 1;
                     ToolBarVisibility(2);
                     Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.expandnode();", true);
                     Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.showTreeNode();", true);
                     Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.RevisionHistory();", true);
                     Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.HideReviseDocument('rtn3');", true);
                     string revisionid = item.GetDataKeyValue("RevisionID").ToString();
                     hiddenFieldRevisionID.Value = revisionid;
                     CWPPopulate(revisionid);
                     dtgCWPDetailGrid.Rebind();
                    radPlanner.Width=190;
                 }
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
            }
        }
        #endregion dtgCWPHeaderGrid_ItemCommand

        #region CWPPopulate
        public void CWPPopulate(string revisionID)
        {
            try
            {
                string latestStatus = "";
                DataSet ds = new DataSet();
                documentMaster = new DocumentMaster();
                Guid RevisionID;
                Guid.TryParse(revisionID, out RevisionID);
                ds = documentMaster.BindCWPHeader(RevisionID);
                UIClasses.Const Const = new UIClasses.Const();
                FlyCnDAL.Security.UserAuthendication UA;
                HttpContext context = HttpContext.Current;
                UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
                hiddenUsername.Value = UA.userName;
                //hiddenfield
                hdfProjectNo.Value = ds.Tables[0].Rows[0]["ProjectNo"].ToString();
                hiddenFieldDocumentID.Value = ds.Tables[0].Rows[0]["DocumentID"].ToString();
                hiddenFieldRevisionID.Value = ds.Tables[0].Rows[0]["RevisionID"].ToString();
                hiddenDocumentOwner.Value = ds.Tables[0].Rows[0]["DocumentOwner"].ToString();
                hiddenFieldDocumentType.Value = ds.Tables[0].Rows[0]["DocumentType"].ToString();
                //hiddenfield
                txtDocumentOwner.Text = ds.Tables[0].Rows[0]["DocumentOwner"].ToString();
                txtDocumentNo.Text = ds.Tables[0].Rows[0]["DocumentNo"].ToString();
                hiddenDocumentNo.Value = ds.Tables[0].Rows[0]["DocumentNo"].ToString();
                txtClientDocumentNo.Text = ds.Tables[0].Rows[0]["ClientDocNo"].ToString();
                txtRevisionNo.Text = ds.Tables[0].Rows[0]["RevisionNo"].ToString();
                hiddenRevisionNumber.Value = ds.Tables[0].Rows[0]["RevisionNo"].ToString();
                //RadDocumentDate.SelectedDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["DocumentDate"].ToString());
                txtdatepicker.Value = Convert.ToString(ds.Tables[0].Rows[0]["DocumentDate"]);
                hiddendocumentDate.Value = Convert.ToString(ds.Tables[0].Rows[0]["DocumentDate"]);
                txtDocumentTitle.Text = ds.Tables[0].Rows[0]["DocumentTitle"].ToString();
                txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                radPlanner.Text = ds.Tables[0].Rows[0]["Planner"].ToString();
                if ((ds.Tables[0].Rows[0]["LatestStatus"].ToString() == DocStatus.Closed) || (ds.Tables[0].Rows[0]["LatestStatus"].ToString() == DocStatus.Approved))
                {//1-closed and 4 approved 
                    latestStatus = ds.Tables[0].Rows[0]["LatestStatus"].ToString();
                    ToolBarVisibility(4);//Disable display of Toolbar
                }
                else
                {
                    latestStatus = ds.Tables[0].Rows[0]["LatestStatus"].ToString();
                    ToolBarVisibility(2);//Normal display of Toolbar
                }
                if (UA.userName == hiddenDocumentOwner.Value)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.DisableTreeNode('rtMid');", true);

                }
                if ((ds.Tables[0].Rows[0]["LatestStatus"].ToString() == DocStatus.Closed) || (ds.Tables[0].Rows[0]["LatestStatus"].ToString() == DocStatus.Approved))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.DisableTreeNode('rtMid');", true);

                }
                if (UA.userName != hiddenDocumentOwner.Value)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.EnableTreeNode('rtMid');", true);
                }
                if ((UA.userName == hiddenDocumentOwner.Value) && (ds.Tables[0].Rows[0]["LatestStatus"].ToString() == DocStatus.Draft))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.EnableTreeNode('rtTop');", true);
                }
                if ((UA.userName == hiddenDocumentOwner.Value) && (ds.Tables[0].Rows[0]["LatestStatus"].ToString() == DocStatus.Approved))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.EnableTreeNode('rtBot');", true);
                }
                lblDocumentStatus.Text = ds.Tables[0].Rows[0]["StatusDescription"].ToString();
                hiddenStatusValue.Value = ds.Tables[0].Rows[0]["LatestStatus"].ToString();
               // ToolBarVisibility(2);
                Guid Revisionid;
                Guid.TryParse(hiddenFieldRevisionID.Value, out Revisionid);
                if (Revisionid != Guid.Empty)
                {
                    IframeContent.Attributes["src"] = "CWP_Detail.aspx?Revisionid=" + Revisionid;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Add", "OpenDetailAccordion();", true);
                }
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
            }
            finally
            {

            }
        }
        #endregion CWPPopulate

        #region WebMethodToBindPlanners
        [System.Web.Services.WebMethod]
        public static RadComboBoxData GetAllNames(RadComboBoxContext context)
        {

            FlyCnDAL.MasterPersonal personalObj = new FlyCnDAL.MasterPersonal();
            DataTable data = personalObj.GetM_PersonnelNamesByProjectNo(context.Text);

            RadComboBoxData comboData = new RadComboBoxData();
            int itemOffset = context.NumberOfItems;
            int endOffset = Math.Min(itemOffset + ItemsPerRequest, data.Rows.Count);
            comboData.EndOfItems = endOffset == data.Rows.Count;

            List<RadComboBoxItemData> result = new List<RadComboBoxItemData>(endOffset - itemOffset);

            for (int i = itemOffset; i < endOffset; i++)
            {
                RadComboBoxItemData itemData = new RadComboBoxItemData();
                itemData.Text = data.Rows[i]["Name"].ToString();
                result.Add(itemData);
            }

            comboData.Message = GetStatusMessage(endOffset, data.Rows.Count);

            comboData.Items = result.ToArray();
            return comboData;
        }
        [System.Web.Services.WebMethod]
        private static string GetStatusMessage(int offset, int total)
        {
            if (total <= 0)
                return "No matches";

            return String.Format("Items <b>1</b>-<b>{0}</b> out of <b>{1}</b>", offset, total);
        }
        #endregion WebMethodToBindPlanners

        #region dtgCWPDetailGrid_DeleteCommand
        protected void dtgCWPDetailGrid_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            var page = HttpContext.Current.CurrentHandler as Page;
            var master = page.Master;
            HtmlControl divMask = (HtmlControl)master.FindControl("Errorbox");
            divMask.Style["visibility"] = "Hidden";
            cwpObj = new ConstructionWorkPacks();
            GridDataItem items = e.Item as GridDataItem;
            string keyItem = items.GetDataKeyValue("ItemID").ToString();
            Guid itemID;
            Guid.TryParse(keyItem, out itemID);
            if (e.CommandName == "Delete")
            {
                cwpObj.cwpDetailsObj.DeleteFromCWPDetail(itemID);
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Add", "OpenDetailAccordion();", true);
            ToolBarVisibility(2);
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.expandnode();", true);
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.showTreeNode();", true);
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.RevisionHistory();", true);
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.HideReviseDocument('rtn3');", true);
        }
        #endregion dtgCWPDetailGrid_DeleteCommand
    }
}