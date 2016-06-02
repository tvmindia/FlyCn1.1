using FlyCn.FlyCnDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace FlyCn.WorkPacks
{
    public partial class CWP_Detail : System.Web.UI.Page
    {
        #region Properties
        DocumentMaster documentMaster;
        ConstructionWorkPacks cwpObj;
        ErrorHandling eObj = new ErrorHandling();
        FlyCnDAL.Modules moduleObj = new FlyCnDAL.Modules();
       // FlyCnDAL.CategoryAllocation CategoryAllocationObj = new FlyCnDAL.CategoryAllocation();
        FlyCnDAL.ConstructionWorkPacks cwpHeaderObj = new FlyCnDAL.ConstructionWorkPacks();
        FlyCnDAL.SystemDefenitionDetails systabledefenitionobj = new FlyCnDAL.SystemDefenitionDetails();
        UIClasses.Const Const = new UIClasses.Const();
        FlyCnDAL.Security.UserAuthendication UA;
        HttpContext context = HttpContext.Current;
        string moduleId, category = "";
        DataTable datatableobj = new DataTable();
        string Revisionid;
        #endregion Properties

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindModule();
                ddlCategory.Items.Insert(0, new ListItem("--select Category--", "-1"));
            }
            Revisionid = Request.QueryString["Revisionid"];
        
            if(Revisionid!=null)
            {
                Session["revID"] =Revisionid;
                hdfRevisionID.Value=Revisionid;
            }
        }
        #endregion Page_Load

        #region BindModule
        public void BindModule()
        {

            UIClasses.Const Const = new UIClasses.Const();
            FlyCnDAL.Security.UserAuthendication UA;
            HttpContext context = HttpContext.Current;
            UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
            DataSet dtmodules = null;
          
            try
            {
                dtmodules = new DataSet();
                dtmodules = moduleObj.GetModules(UA.projectNo);

                ddlModule.DataSource = dtmodules;
                ddlModule.DataTextField = "ModuleDesc";
                ddlModule.DataValueField = "ModuleID";
                ddlModule.DataBind();
                //ddlModule.Items.Insert(0, new ListItem("--select module--", "-1"));

            }

            catch (Exception)
            {


            }
        }
        #endregion BindModule

        #region ddlModule_SelectedIndexChanged
        protected void ddlModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            UIClasses.Const Const = new UIClasses.Const();
            FlyCnDAL.Security.UserAuthendication UA;
            HttpContext context = HttpContext.Current;
            UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
            DataTable dtCategory = null;
            FlyCnDAL.Users userObj = new FlyCnDAL.Users();
            try
            {
                if (ddlModule.SelectedItem.Text == "--select Module--")
                {
                    ddlCategory.SelectedItem.Text = "--select Category--";
                }
                if (ddlModule.SelectedItem.Text != "--select Module--")
                {
                    Session["Module"] = ddlModule.SelectedItem.Value;
                }
                dtCategory = new DataTable();
                string project = UA.projectNo;
                string module = ddlModule.SelectedItem.Value;
                dtCategory = userObj.GetAllCategory(project, module);

                ddlCategory.DataSource = dtCategory;
                ddlCategory.DataTextField = "CategoryDesc";
                ddlCategory.DataValueField = "Category";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("--select Category--", "-1"));

            }
            catch (Exception)
            {


            }
        }
        #endregion ddlModule_SelectedIndexChanged

        #region dtgAddCWP_Detail_NeedDataSource
        protected void dtgAddCWP_Detail_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            string moduleId = ddlModule.SelectedItem.Value;
            string category = ddlCategory.SelectedItem.Value;
            if (category != null && category != "-1" && moduleId != null && moduleId != "--select Module--")
            {
                string _tableName = "";
                DataTable dt, df = new DataTable();
                DataSet ds = new DataSet();
                ds = moduleObj.GetModule(moduleId);
                _tableName = moduleObj.BaseTable;
                dt = cwpHeaderObj.BindCWPData(_tableName, moduleId, category, true);
                dtgAddCWP_Detail.DataSource = dt;
            }
            if(dtgAddCWP_Detail.DataSource==null)
            {
                dtgAddCWP_Detail.DataSource = new string[] { };
            }
        }
        #endregion dtgAddCWP_Detail_NeedDataSource

        #region ddlCategory_SelectedIndexChanged
        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedItem.Text != "--select Category--")
            {
                Session["Category"] = ddlCategory.SelectedItem.Value;
            }
            dtgAddCWP_Detail.Rebind();
        }
        #endregion ddlCategory_SelectedIndexChanged

        #region dtgAddCWP_Detail_PreRender
        protected void dtgAddCWP_Detail_PreRender(object sender, EventArgs e)
        {
            dtgAddCWP_Detail.Rebind();
        }
        #endregion dtgAddCWP_Detail_PreRender

        //#region Page_Init
        //protected void Page_Init(object sender, System.EventArgs e)
        //{
        //    string sdw = "";

        //    if (HttpContext.Current.Session["Module"] != null && HttpContext.Current.Session["Module"] != "")
        //    {
        //        moduleId = HttpContext.Current.Session["Module"].ToString();
               

        //        if (HttpContext.Current.Session["Category"] != null && HttpContext.Current.Session["Category"] != "--select Category--")
        //        {
        //            category = HttpContext.Current.Session["Category"].ToString();
        //            string _tableName;
        //            Modules mObj = new Modules();
        //            DataSet ds = new DataSet();
        //            ds = mObj.GetModule(moduleId);
        //            _tableName = mObj.BaseTable;
        //            string Key, primarykeys = "";
        //            SystemDefenitionDetails sObj = new SystemDefenitionDetails();
        //            datatableobj = sObj.GetPrimarykeys(_tableName);
        //            for (int i = 0; i < datatableobj.Rows.Count; i++)
        //            {
        //                Key = datatableobj.Rows[i]["Field_Name"].ToString();
        //                primarykeys = primarykeys + Key + ",";

        //                sdw = primarykeys.TrimEnd(',', ' ');
        //            }
        //            dtgAddCWP_Detail.MasterTableView.DataKeyNames = sdw.Split(',').ToArray();
        //            hdfFieldName.Value = sdw;
        //            if (hdfFieldName.Value != "" && hdfFieldName.Value!=null)
        //            {
        //                Session["key"] = hdfFieldName.Value;
        //            }
        //        }
        //    }
        //}
        //#endregion  Page_Init


        #region btnImport_Click
        protected void btnImport_Click(object sender, EventArgs e)
        {
            string tagNo = "";
            string keyField = "";
            try
            {
                hdfRevisionID.Value = HttpContext.Current.Session["revID"].ToString();
                CWPDetailPopulate();
                UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
                Guid Revid;
                Revisionid = hdfRevisionID.Value;
                cwpObj = new ConstructionWorkPacks();
                Guid.TryParse(Revisionid, out Revid);
                cwpObj.cwpDetailsObj.revisionID = Revid;
                cwpObj.cwpDetailsObj.projectNo = UA.projectNo;
                cwpObj.cwpDetailsObj.moduleId = (hdfModuleID.Value.Trim() != "") ? hdfModuleID.Value.Trim().ToString() : null;
                cwpObj.cwpDetailsObj.category = (hdfCategory.Value.Trim() != "") ? hdfCategory.Value.Trim().ToString() : null;
                cwpObj.cwpDetailsObj.keyField = (hdfKeyField.Value.Trim() != "") ? hdfKeyField.Value.Trim().ToString() : null;
                cwpObj.cwpDetailsObj.createBy = (hdfCreatedBy.Value.Trim() != "") ? hdfCreatedBy.Value.Trim().ToString() : null;
                cwpObj.cwpDetailsObj.updatedBy = (hdfUpdatedBy.Value.Trim() != "") ? hdfUpdatedBy.Value.Trim().ToString() : null;
                cwpObj.cwpDetailsObj.createdDate = (hdfCreatedDate.Value != null) ? Convert.ToDateTime(hdfCreatedDate.Value) : Convert.ToDateTime(null);
                cwpObj.cwpDetailsObj.updatedDate = (hdfUpdatedDate.Value != null) ? Convert.ToDateTime(hdfUpdatedDate.Value) : Convert.ToDateTime(null);
                foreach (GridDataItem item in dtgAddCWP_Detail.MasterTableView.Items)
                {

                    CheckBox checkColumnAdd = item["Modulescheck"].Controls[0] as CheckBox;
                    if (checkColumnAdd.Checked == true)
                    {
                        if (hdfFieldName.Value == "")
                        {
                            
                            //string key = HttpContext.Current.Session["key"].ToString();
                            //String[] keyArrray = key.Split(',');
                            //dtgAddCWP_Detail.MasterTableView.DataKeyNames = keyArrray;
                            keyField = item.GetDataKeyValue("KeyField").ToString();
                            tagNo = item[keyField].Text.ToString();
                        }
                        //else
                        //{
                        //    tagNo = item.GetDataKeyValue(hdfFieldName.Value).ToString();
                            
                        //}
                        cwpObj.cwpDetailsObj.keyValue = (tagNo.Trim() != "") ? tagNo.Trim().ToString() : null;
                        Guid itemid;
                        itemid = cwpObj.cwpDetailsObj.AddCWPDetails();
                        if (itemid != Guid.Empty)
                        {
                            hdfItemID.Value = itemid.ToString();
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
        #endregion btnImport_Click

        public void CWPDetailPopulate()
        {
            try
            {
                cwpObj = new ConstructionWorkPacks();
                UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
                string _tableName = "";
                DataTable dt, dtKeys = new DataTable();
                DataSet ds = new DataSet();
                ds = moduleObj.GetModule(ddlModule.SelectedValue);
                _tableName = moduleObj.BaseTable;
                dt = cwpHeaderObj.BindCWPData(_tableName, ddlModule.SelectedItem.Value, ddlCategory.SelectedItem.Value, true);
                dtKeys = cwpObj.cwpDetailsObj.GetKeyFieldFromSys_Categories(UA.projectNo, ddlModule.SelectedValue, ddlCategory.SelectedValue);
                hdfProjectNo.Value = UA.projectNo;
                hdfModuleID.Value = ddlModule.SelectedItem.Value;
                hdfCategory.Value = ddlCategory.SelectedItem.Value;
                hdfKeyField.Value = dtKeys.Rows[0]["KeyField"].ToString();
                hdfKeyValue.Value = dt.Rows[0][hdfKeyField.Value].ToString();
                hdfCreatedBy.Value = UA.userName;
                hdfCreatedDate.Value = System.DateTime.Now.ToString();
                hdfUpdatedBy.Value = UA.userName;
                hdfUpdatedDate.Value = System.DateTime.Now.ToString();
            }
            catch(Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
            }
        }

        protected void dtgAddCWP_Detail_ItemCommand(object sender, GridCommandEventArgs e)
        {
            string _tableName;
            Modules mObj = new Modules();
            DataSet ds = new DataSet();
            ds = mObj.GetModule(moduleId);
            _tableName = mObj.BaseTable;
            datatableobj = systabledefenitionobj.GetComboBoxDetails(_tableName);

            //string sdw = dt.Rows[0][0].ToString();
            GridDataItem item = e.Item as GridDataItem;
            //string strId = item.GetDataKeyValue(sdw).ToString();
            if (item != null)
            {
                DataTable datatbl = new DataTable();
                string Key = "";
                string primarykeys = "";
                string ID = "";
                string KeyValue = "";

                datatbl = systabledefenitionobj.GetPrimarykeys(_tableName);
                if ((datatbl.Rows.Count > 0 && datatbl != null))
                {
                    for (int i = 0; i < datatbl.Rows.Count; i++)
                    {
                        Key = datatbl.Rows[i]["Field_Name"].ToString();
                        primarykeys = primarykeys + Key + ",";

                        ID = item.GetDataKeyValue(Key).ToString();
                        KeyValue = KeyValue + ID + ",";



                    }
                }
            }
        }

        protected void dtgAddCWP_Detail_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                CheckBox checkBoxAdd = (CheckBox)item["Modulescheck"].Controls[0];
                checkBoxAdd.Enabled = true;

            }
        }

        //protected void dtgAddCWP_Detail_DataBinding(object sender, EventArgs e)
        //{
          
            
        //}
    }
}