﻿#region Namespaces

using FlyCn.DocumentSettings;//############
using FlyCn.FlyCnDAL;
using FlyCn.UIClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using DocStatus = FlyCn.DocumentSettings.DocumentStatusSettings;
using FlyCn.Approvels;
#endregion Namespaces


namespace FlyCn.BOQ
{
    public partial class BOQHeader : System.Web.UI.Page
    {
        DocumentAttachments doc = new DocumentAttachments();
        public int NumberOfTimesNeedDataSourceCalled = 0;
       
        #region Global Variables
        DocumentMaster documentMaster;
        string _RevisionId;
        BOQHeaderDetails boqHeaderDetails,BOQObj;
       
        ErrorHandling eObj = new ErrorHandling();
       // DocumentStatusSettings dObj;
        UIClasses.Const Const = new UIClasses.Const();
        FlyCnDAL.Security.UserAuthendication UA;
        public string RevId;
    
        #endregion Global Variables

        #region Events
        
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            _RevisionId = Request.QueryString["RevisionId"];


            BOQObj = new BOQHeaderDetails();
            ToolBarVisibility(4);
            SecurityCheck();

            
            UA = (FlyCnDAL.Security.UserAuthendication)Session[Const.LoginSession];
            ToolBar.onClick += new RadToolBarEventHandler(ToolBar_onClick);
            ToolBar.OnClientButtonClicking = "OnClientButtonClicking";
            //GridviewFilter.onClick += new EventHandler(GridviewFilter_onClick);
             BOQObj.RevisionIdFromHiddenfield = hiddenFieldRevisionID.ToString(); 
             BOQObj.DocumentOwner = hiddenDocumentOwner.Value;
            
            //BOQObj.BindTree(RadTreeView tview);
            hiddenFieldDocumentType.Value = "BOQ";
            ContentIframe.Style["display"] = "none";//iframe disabling
            Context.Items["DocumentOwner"] = hiddenDocumentOwner.Value;
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.collapsenode();", true);
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.DisableTreeNode('rtMid');", true);
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.DisableTreeNode('rtTop');", true);
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.DisableTreeNode('rtBot');", true);
            if (_RevisionId != null)
            {
              if(HiddenTabStatus.Value!="1")
              {         
                TabAddEditSettings tabs = new TabAddEditSettings();
                RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("2");
                tabs.EditTab(tab);
                RadMultiPage1.SelectedIndex = 1;
                BOQPopulate(_RevisionId);
              }
                else
              {
                  TabAddEditSettings tabs = new TabAddEditSettings();
                  RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("1");
                  RadTab tab1 = (RadTab)RadTabStrip1.FindTabByValue("2");
                  tabs.ResetTabCaptions(tab, tab1);
                  RadMultiPage1.SelectedIndex = 0;
              }
            }
         }



//**********
//        protected void GridviewFilter_onClick(object sender, EventArgs e)
//        {
//            NumberOfTimesNeedDataSourceCalled = 1;

//            BinddtgBOQGrid();

////To update the gridview after binding filtered data
//            //upGrid.Update();
//        }

        public void DisableBOQHeaderTextBox()
        {
            txtClientdocumentno.Attributes.Add("readonly","readonly");
            txtRevisionno.Attributes.Add("readonly", "readonly");
           // RadDocumentDate.Enabled = !RadDocumentDate.Enabled;
            txtDocumenttitle.Attributes.Add("readonly", "readonly");
            txtRemarks.Attributes.Add("readonly", "readonly");
        }
      
     
        public void EnableBOQHeaderTextBox()
        {
            txtClientdocumentno.Attributes.Remove("readonly");
            txtRevisionno.Attributes.Remove("readonly");
            txtdatepicker.Attributes.Remove("readonly");//bootstrap date picker enable
            txtDocumenttitle.Attributes.Remove("readonly");
            txtRemarks.Attributes.Remove("readonly");
        }
        
        #endregion Page_Load

        #region dtgBOQGrid_NeedDataSource
        protected void dtgBOQGrid_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
           
            try
            {
                BinddtgBOQGrid();
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
            }
        }
        #endregion dtgBOQGrid_NeedDataSource

        #region dtgBOQGrid_PreRender
        protected void dtgBOQGrid_PreRender(object sender, EventArgs e)
        {
            try
            {
                dtgBOQGrid.Rebind();
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
            }
        }
        #endregion dtgBOQGrid_PreRender

        #region dtgBOQGrid_ItemCommand
        protected void dtgBOQGrid_ItemCommand(object source, GridCommandEventArgs e)
        {
            //**********
            //HiddenField hdnPostbackOnItemCommand = (HiddenField)GridviewFilter.FindControl("hdnPostbackOnItemCommand");
            //hdnPostbackOnItemCommand.Value = "True";
            //DocumentAttachments doc = new DocumentAttachments();
         
            //if ()
            //{
            //    doc.hideDelete();
            //}
            try
            {//Only Edit functionality is needed in BOQheader so no delete
                if (e.CommandName == "EditDoc")//EditDoc  is named because Radgrid has its own definition for Edit
                {
                    
                    RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("2");
                    GridDataItem item = e.Item as GridDataItem;
                    tab.Selected = true;
                    tab.Text = "Edit";
                    string DocumentNo = hiddenDocumentNo.Value;
                    DataTable docdtObj=new DataTable();
                    FlyCn.FlyCnDAL.DocumentMaster docObj = new DocumentMaster();
                   // BOQObj = new BOQHeaderDetails();  
                  //  docdtObj=  docObj.GetRevisionIdByDocumentNo(DocumentNo);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.expandnode();", true);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.showTreeNode();", true);
                    RadMultiPage1.SelectedIndex = 1;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.RevisionHistory();", true);
                  
                        string revisionid = item.GetDataKeyValue("RevisionID").ToString();
                        hiddenFieldRevisionID.Value = revisionid;
                    BOQPopulate(revisionid);

                 
                    //RadTab node = (RadTab)RadTabStrip1.FindTabByValue("rtn5");
                    //node.Visible = true;
                        //BOQPopulate(revisionid);
                    
                }
                else
                    if (e.CommandName == "ViewDetailColumn")//EditDoc  is named because Radgrid has its own definition for Edit
                    {
                       //a hdnPostbackOnItemCommand.Value = "View";
                        ToolBarVisibility(4);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.HideTreeNode();", true);
                        RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("2");
                        GridDataItem item = e.Item as GridDataItem;
                        tab.Selected = true;
                        tab.Text = "Details";
                        //string DocumentNo = hiddenDocumentNo.Value;
                       // DataTable docdtObj = new DataTable();
                      //  FlyCn.FlyCnDAL.DocumentMaster docObj = new DocumentMaster();
                      //  docdtObj=  docObj.GetRevisionIdByDocumentNo(DocumentNo);

                        RadMultiPage1.SelectedIndex = 1;

                        string revisionid = item.GetDataKeyValue("RevisionID").ToString();
                        BOQPopulate(revisionid);

                    

                    }
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
            }

        }
        #endregion dtgBOQGrid_ItemCommand

        #region  ToolBar_onClick
        protected void ToolBar_onClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            string functionName = e.Item.Value;
            if(e.Item.Value == "Add")//It doesnot add anything but clears
            {
                RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("2");
                tab.Selected = true;
                tab.Text = "New";
                RadMultiPage1.SelectedIndex = 1;
              
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ClearTextBox", "ClearBOQHeaderTexBox();", true);
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.DisableTreeNode('rtBot');", true);
                ToolBarVisibility(3);
                ContentIframe.Style["display"] = "none";

            }
            if (e.Item.Value == "Save")
            {
                AddNewBOQ();
                ToolBarVisibility(1);
                dtgBOQGrid.Rebind();
                //calling js function DisableBOQHeaderTextBox()to make text box readonly
                ScriptManager.RegisterStartupScript(this, this.GetType(), "DisableTextBox", "DisableBOQHeaderTextBox();", true);
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.showTreeNode();", true);
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.expandnode();", true);
            }
            if (e.Item.Value == "Update")
            {
             
                UpdateBOQ();
              
                ToolBarVisibility(1);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "DisableTextBox", "DisableBOQHeaderTextBox();", true);
            }
            if(e.Item.Value == "Edit")
            {
                ToolBarVisibility(2);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "EnableTextBox", "EnableBOQHeaderTextBox();", true);
                RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("2");
                tab.Selected = true;
                tab.Text = "Edit";
                RadMultiPage1.SelectedIndex = 1;
            }
            if (e.Item.Value == "Delete")
            {
                //Delete();
            }

        }
        #endregion ToolBar_onClick

        public void dtReBind()
        {
            dtgBOQGrid.Rebind();
        }
        #endregion Events

        #region Methods

        #region ToolBarVisibility
        public void ToolBarVisibility(int order)
        {
            switch (order)
            {
                   case 1://after adding what should be visible
                    ToolBar.AddButton.Visible = true;
                    ToolBar.SaveButton.Visible = false;
                    ToolBar.UpdateButton.Visible = false;
                    ToolBar.EditButton.Visible = true;
                    ToolBar.DeleteButton.Visible = false;
                    ToolBar.AttachButton.Visible = true;
                   break;
                   case 2:
                    ToolBar.AddButton.Visible = true;
                    ToolBar.SaveButton.Visible = false;
                    ToolBar.UpdateButton.Visible = true;
                    ToolBar.EditButton.Visible = false;
                    ToolBar.DeleteButton.Visible = false;
                    ToolBar.AttachButton.Visible = true;
                   break;
                           
                case 3:
                    ToolBar.AddButton.Visible = false;
                    ToolBar.SaveButton.Visible = true;
                    ToolBar.UpdateButton.Visible = false;
                    ToolBar.EditButton.Visible = false;
                    ToolBar.DeleteButton.Visible = false;
                    ToolBar.AttachButton.Visible = true;
                   break;


                case 4://toally invicible
                    ToolBar.AddButton.Visible = false;
                    ToolBar.SaveButton.Visible = false;
                    ToolBar.UpdateButton.Visible = false;
                    ToolBar.EditButton.Visible = false;
                    ToolBar.DeleteButton.Visible = false;
                    ToolBar.AttachButton.Visible = true;
                   break;
                  
            }

        }
       #endregion ToolBarVisibility

        #region insert
        public void AddNewBOQ()
        {
            DataSet ds;
            string QueryTimeStatus = "";
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
                //boqHeaderDetails.DocumentDate = (RadDocumentDate.SelectedDate != null) ? Convert.ToDateTime(RadDocumentDate.SelectedDate) : Convert.ToDateTime(null);
                boqHeaderDetails.DocumentDate = (txtdatepicker.Value != null) ? Convert.ToDateTime(txtdatepicker.Value) : Convert.ToDateTime(null);
                boqHeaderDetails.DocumentTitle = (txtDocumenttitle.Text.Trim() != "") ? txtDocumenttitle.Text.Trim() : null;
                boqHeaderDetails.Remarks = (txtRemarks.Text.Trim() != "") ? txtRemarks.Text.Trim() : null;
                Guid Revisionid;
                Revisionid = boqHeaderDetails.AddNewBOQ();//Revison id will be returned here
                ds = new DataSet();
                documentMaster = new DocumentMaster();
                //BindBOQHEaderbyRevisonid
                ds = documentMaster.BindBOQHeader(Revisionid);
                //BindBOQHEaderbyRevisonid
                //hiddenField Binding
                if (ds.Tables[0].Rows.Count > 0)
                {
                    hiddenFiedldProjectno.Value = ds.Tables[0].Rows[0]["ProjectNo"].ToString();
                    hiddenFieldDocumentID.Value = ds.Tables[0].Rows[0]["DocumentID"].ToString();
                    hiddenFieldRevisionID.Value = ds.Tables[0].Rows[0]["RevisionID"].ToString();
                    txtDocumentno.Text = ds.Tables[0].Rows[0]["DocumentNo"].ToString();
                    txtDocOwner.Text = ds.Tables[0].Rows[0]["DocumentOwner"].ToString();
                    txtdatepicker.Value = ds.Tables[0].Rows[0]["DocumentDate"].ToString();
                }
                //hiddenField Binding
                if (Revisionid != Guid.Empty)
                {
                    QueryTimeStatus = "New";
                    ContentIframe.Attributes["src"] = "BOQDetails.aspx?Revisionid=" + Revisionid + "&QueryTimeStatus="+ QueryTimeStatus;//iframe page BOQDetails.aspx is called with query string revisonid
                    //ScriptManager.RegisterStartupScript(this.GetType(), "Add", "OpenDetailAccordion();", true);//Accordian calling BOQdetail slide down
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), " ", "DisablePopUP();", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Add", "OpenDetailAccordion();", true);
                }
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
               // boqHeaderDetails.DocumentDate = (RadDocumentDate.SelectedDate != null) ? Convert.ToDateTime(RadDocumentDate.SelectedDate) : Convert.ToDateTime(null);
                boqHeaderDetails.DocumentDate = (txtdatepicker.Value != null) ? Convert.ToDateTime(txtdatepicker.Value) : Convert.ToDateTime(null);
                boqHeaderDetails.DocumentTitle = (txtDocumenttitle.Text != "") ? txtDocumenttitle.Text : null;
                boqHeaderDetails.Remarks = (txtRemarks.Text != "") ? txtRemarks.Text: null;
                boqHeaderDetails.UpdatedBy = UA.userName;
                boqHeaderDetails.UpdatedDate = System.DateTime.Now.ToString();
                boqHeaderDetails.UpdatedDateGMT = System.DateTime.Now;
                boqHeaderDetails.UpdateBOQ();
                if (revisionID != Guid.Empty)
                {
                    ContentIframe.Attributes["src"] = "BOQDetails.aspx?Revisionid=" + revisionID;//iframe page BOQDetails.aspx is called with query string revisonid
                    //ScriptManager.RegisterStartupScript(this.GetType(), "Add", "OpenDetailAccordion();", true);//Accordian calling BOQdetail slide down
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Update", "OpenDetailAccordion();", true);
                }
                
            }
            catch(Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
            }
        }

        #endregion UpdateBOQ

        #region BinddtgBOQGrid
        public void BinddtgBOQGrid()
        {

            //**********
            //int resultReturnedCount=0;
            //try
            //{
            //    DataSet ds = new DataSet();
            //    DataTable dtable = new DataTable();

            //    documentMaster = new DocumentMaster();
            //    ds = documentMaster.GetAllBOQDocumentHeader(UA.projectNo, "BOQ");
            //    dtgBOQGrid.DataSource = ds;

            //    dtable =ds.Tables[0];

            //    string searchQuery = GridviewFilter.WhereCondition;

            //    if (searchQuery != null)
            //    {
            //        DataRow[] test = dtable.Select(searchQuery);
            //        dtgBOQGrid.DataSource = test;
            //        dtgBOQGrid.DataBind();

            //        resultReturnedCount = dtgBOQGrid.Items.Count;

            //    Label lblResultReturnedCount = (Label) GridviewFilter.FindControl("lblResultReturnedCount");

            //    if (0 == resultReturnedCount)
            //    {
            //        lblResultReturnedCount.Text = "No result found!";
            //        lblResultReturnedCount.ForeColor = System.Drawing.Color.Red;
            //    }

            //    else
            //    {
            //        lblResultReturnedCount.Text = "Result Returned : " + resultReturnedCount.ToString();
            //        lblResultReturnedCount.ForeColor = System.Drawing.Color.Gray;
            //    }


              
                    
                   
            //    }

            //    else
            //    {
            //        if (NumberOfTimesNeedDataSourceCalled == 1)
            //        {
            //            dtgBOQGrid.DataBind();
            //        }
            //    }

            //}
            //catch (Exception ex)
            //{
            //    //var page = HttpContext.Current.CurrentHandler as Page;
            //    //eObj.ErrorData(ex, page);

            //    var page = HttpContext.Current.CurrentHandler as Page;
            //    var master = page.Master;
            //    eObj.ErrorData(ex, page);
            //}




            try
            {
               //  string projNo = HttpContext.Current.Session["projectNo"].ToString();
                DataSet ds = new DataSet();
                documentMaster = new DocumentMaster();
                ds = documentMaster.GetAllBOQDocumentHeader(UA.projectNo, "BOQ");
                dtgBOQGrid.DataSource = ds;
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
            }


        }
        #endregion BinddtgBOQGrid

        #region BOQPopulate
        public void BOQPopulate(string revisionID)
        {
            try
            {
                string latestStatus = "";
                DataSet ds = new DataSet();
                documentMaster = new DocumentMaster();
                Guid RevisionID;
                Guid.TryParse(revisionID, out RevisionID);
                ds = documentMaster.BindBOQ(RevisionID);
                UIClasses.Const Const = new UIClasses.Const();
                FlyCnDAL.Security.UserAuthendication UA;
                HttpContext context = HttpContext.Current;
                UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
                hiddenUsername.Value = UA.userName;
                //hiddenfield
                hiddenFiedldProjectno.Value = ds.Tables[0].Rows[0]["ProjectNo"].ToString();
                hiddenFieldDocumentID.Value = ds.Tables[0].Rows[0]["DocumentID"].ToString();
                hiddenFieldRevisionID.Value = ds.Tables[0].Rows[0]["RevisionID"].ToString();
                hiddenDocumentOwner.Value = ds.Tables[0].Rows[0]["DocumentOwner"].ToString();
                //hiddenfield
                txtDocOwner.Text = ds.Tables[0].Rows[0]["DocumentOwner"].ToString();
                txtDocumentno.Text = ds.Tables[0].Rows[0]["DocumentNo"].ToString();
                hiddenDocumentNo.Value = ds.Tables[0].Rows[0]["DocumentNo"].ToString();
                txtClientdocumentno.Text = ds.Tables[0].Rows[0]["ClientDocNo"].ToString();
                txtRevisionno.Text = ds.Tables[0].Rows[0]["RevisionNo"].ToString();
                hiddenRevisionNumber.Value = ds.Tables[0].Rows[0]["RevisionNo"].ToString();
                //RadDocumentDate.SelectedDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["DocumentDate"].ToString());
                txtdatepicker.Value = Convert.ToString(ds.Tables[0].Rows[0]["DocumentDate"]);
                hiddendocumentDate.Value =Convert.ToString(ds.Tables[0].Rows[0]["DocumentDate"]);
                txtDocumenttitle.Text = ds.Tables[0].Rows[0]["DocumentTitle"].ToString();
                txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
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
                lblDocumentStatus.Text = ds.Tables[0].Rows[0]["DocumentStatus"].ToString();
                hiddenStatusValue.Value = ds.Tables[0].Rows[0]["LatestStatus"].ToString();
               
                DataTable docdtObj = new DataTable();
                DataTable docNoObj = new DataTable();
                DataTable RevNoObj = new DataTable();
                FlyCn.FlyCnDAL.DocumentMaster docObj = new DocumentMaster();

                docNoObj = docObj.GetDocumentIdByNo(hiddenDocumentNo.Value);
                String DocumentId = docNoObj.Rows[0]["DocumentID"].ToString();
                docdtObj = docObj.GetRevisionIdByDocumentNo(DocumentId);
                string FieldValueLevel1 = "";
                int totalrows = docdtObj.Rows.Count;
                for (int j = 0; j < totalrows; j++)
                {
                    FieldValueLevel1 = FieldValueLevel1 + docdtObj.Rows[j]["RevisionID"] + ",";
                }
                 string revisionIds= FieldValueLevel1.TrimEnd(',');
                 string revisionNos = "";
                 List<string> revisionId = revisionIds.Split(',').ToList<string>();
                 foreach (var item in revisionId)
                 {


                     RevNoObj = docObj.GetRevisionNumberByRevisionId(item);

                     revisionNos = revisionNos + RevNoObj.Rows[0]["RevisionNo"] + "=" + item + "||";
                 }
                 HiddenRevisionIdCollection.Value = revisionNos;
                string revisionid = docdtObj.Rows[0]["ProjectNo"].ToString();
                Guid Revisionid;
                Guid.TryParse(hiddenFieldRevisionID.Value, out Revisionid);
                //BOQDetail Display accordion
                ContentIframe.Attributes["src"] = "BOQDetails.aspx?Revisionid=" + Revisionid + "&latestStatus=" + latestStatus;//iframe page BOQDetails.aspx is called with query string revisonid
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Add", "OpenDetailAccordion();", true);
                ContentIframe.Style["display"] = "block";
                hdfEditStatus.Value = "GridEdit";//set the hiddenfied to know the edit event comes from radgrid and not from the update toolbar button
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
        #endregion BOQPopulate

        #region SecurityCheck
        public void SecurityCheck()
        {
            string logicalObject = "BOQHeader";

            FlyCnDAL.Security.PageSecurity PS = new Security.PageSecurity(logicalObject, this);

            if (PS.isWrite == true)
            {
                dtgBOQGrid.MasterTableView.GetColumn("ViewDetailColumn").Display = false;
              //  dtgBOQGrid.MasterTableView.GetColumn("DeleteColumn").Display = false;
            }
            else
                if (PS.isEdit == true)
                {
                    dtgBOQGrid.MasterTableView.GetColumn("ViewDetailColumn").Display = false;
                  //  dtgBOQGrid.MasterTableView.GetColumn("DeleteColumn").Display = false;
                }
                else if (PS.isAdd == true)
                {
                    dtgBOQGrid.MasterTableView.GetColumn("EditData").Display = false;
                }
                else if (PS.isRead == true)
                {
                    dtgBOQGrid.MasterTableView.GetColumn("ViewDetailColumn").Display = true;
                    dtgBOQGrid.MasterTableView.GetColumn("EditData").Display = false;
                    ToolBarVisibility(4);
                 //   dtgBOQGrid.MasterTableView.GetColumn("DeleteColumn").Display = false;
                }

                else if (PS.isDenied == true)
                {
                    HttpContext.Current.Response.Redirect("~/General/UnderConstruction.aspx?cause=accessdenied", true);
                }
            if (PS.isDelete == true)
            {
              //  dtgBOQGrid.MasterTableView.GetColumn("DeleteColumn").Display = true;
            }

        }
        #endregion SecurityCheck

        #region GetAttachmentCountWebMethod

       
          [System.Web.Services.WebMethod]

        public static int GetAttachmentCount(String RevisionID)
        {
            int count=0;
            try
            {
                if (RevisionID != "")
                {
                    BOQHeaderDetails boq = new BOQHeaderDetails();
                    DataSet ds = new DataSet();
                    //Guid RevID = new Guid(RevisionID);
                    boq.RevisionID = RevisionID;
                    boq.Type = "BOQHeader";
                    ds = boq.GetAllAttachment();
                    count = ds.Tables[0].Rows.Count;
                    
                }
            }
              catch(Exception ex)
            {
                throw ex;
            }
            return count;
        }
      
        #endregion GetAttachmentCountWebMethod
        #endregion Methods
    }
}