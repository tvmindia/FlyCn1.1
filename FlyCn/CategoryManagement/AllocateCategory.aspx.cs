using FlyCn.FlyCnDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace FlyCn.CategoryManagement
{
    public partial class AllocateCategory : System.Web.UI.Page
    {
        string Key = "";
        string primarykeys = "";
        string moduleId = "";
        string category = "";
        DataTable datatableobj = new DataTable();
        FlyCnDAL.MasterOperations dynamicmasteroperationobj = new FlyCnDAL.MasterOperations();
        FlyCnDAL.SystemDefenitionDetails systabledefenitionobj = new FlyCnDAL.SystemDefenitionDetails();
        FlyCnDAL.CategoryAllocation CategoryAllocationObj = new FlyCnDAL.CategoryAllocation();
        ErrorHandling eObj = new ErrorHandling();
        protected void Page_Load(object sender, EventArgs e)
        { 
            if(!IsPostBack)
            {
              
            }
           //  Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.collapsenode();", true);
            //LoadRootNodes(RadTreeView1, TreeNodeExpandMode.ServerSideCallBack);
            //if(!IsPostBack)
            //{
            //    dtgAvailableTags.Rebind();
            //}
            if (Request.QueryString["ModuleId"] != null)
            {
                moduleId = Request.QueryString["ModuleId"].ToString();
                category = Request.QueryString["category"].ToString();
            }
            RegisterToolBox();
            ToolBar.AddButton.Visible = false;
            ToolBar.EditButton.Visible = false;
            ToolBar.DeleteButton.Visible = false;
            ToolBar.UpdateButton.Visible = false;
            ToolBar.SaveButton.Visible = false;
            ToolBar.DeAllocateButton.Visible = true;

            ToolBar1.AddButton.Visible = false;
            ToolBar1.EditButton.Visible = false;
            ToolBar1.DeleteButton.Visible = false;
            ToolBar1.UpdateButton.Visible = false;
            ToolBar1.SaveButton.Visible = false;
            ToolBar1.AllocateButton.Visible = true;
        }

        #region Register ToolBox

        public void RegisterToolBox()
        { 
            ToolBar.onClick += new RadToolBarEventHandler(ToolBar_onClick);
            ToolBar.OnClientButtonClicking = "OnClientButtonClickingDetail";

            ToolBar1.onClick += new RadToolBarEventHandler(ToolBar1_onClick);
            ToolBar1.OnClientButtonClicking = "OnClientButtonClicking";
        }
        #endregion Register ToolBox

        protected void ToolBar_onClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        { 
            string functionName = e.Item.Value;
            if (e.Item.Value == "DeAllocate")
            {
                foreach (GridDataItem item in dtgAllocateTags.Items)
                {

                    CheckBox checkColumnAdd = item["Allocatecheck"].Controls[0] as CheckBox;
                    if (checkColumnAdd.Checked == true)
                    {
                        string tagNo = item.GetDataKeyValue(hdfAllocatedDataKey.Value).ToString();
                        CategoryAllocationObj.DeleteFromAllocatedTags(moduleId, category, tagNo);
                    }
                }
            }
        }

        protected void ToolBar1_onClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        { 
            try
            {
                string functionName = e.Item.Value;
                if (e.Item.Value == "Allocate")
                {
                    foreach (GridDataItem item in dtgAvailableTags.Items)
                    {
                        CheckBox checkColumnAdd = item["Modulescheck"].Controls[0] as CheckBox;
                        CategoryAllocationObj.moduleId = moduleId;
                        if (checkColumnAdd.Checked == true)
                        {
                            string tagNo = item.GetDataKeyValue(hdfFieldName.Value).ToString();
                            CategoryAllocationObj.InsertCategoryToAllocatedTags(tagNo, category);

                        }
                    }
                }
            }
            catch(Exception ex)
            { 
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
            }
        }
        protected void dtgAllocateTags_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {

            if (moduleId != null && moduleId != "")
            {
                string _tableName = "";
                DataTable dt,df = new DataTable();
                Modules mObj = new Modules();
                DataSet ds = new DataSet();
                ds = mObj.GetModule(moduleId);
                _tableName = mObj.BaseTable;
                dt = CategoryAllocationObj.BindData(_tableName, moduleId,category, true);
                df = CategoryAllocationObj.GetKeyFieldFromBaseTables(_tableName, moduleId, true);
                hdfkeyField.Value =df.Rows.Count.ToString();
                dtgAllocateTags.DataSource = dt;
                if(dt.Rows.Count>0)
                {
                    hdfValue.Value = "1";
                }
            }
            if (dtgAllocateTags.DataSource == null)
            {
                dtgAllocateTags.DataSource = new string[] { };
            }
        }

        protected void dtgAvailableTags_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            string _tableName;

            if (moduleId != null && moduleId != "")
            {
                DataTable datatableobj = new DataTable();
                UIClasses.Const Const = new UIClasses.Const();
                FlyCnDAL.Security.UserAuthendication UA;
                HttpContext context = HttpContext.Current;
                UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
                Modules mObj = new Modules();
                DataSet ds = new DataSet();
                ds = mObj.GetModule(moduleId);
                _tableName = mObj.BaseTable;
                int value = Convert.ToInt32(hdfkeyField.Value);
                datatableobj = CategoryAllocationObj.BindAvailableTags(_tableName, UA.projectNo, moduleId,value, true);//boolean true is used to flag the dynamic sp for current need
                dtgAvailableTags.DataSource = datatableobj;
            }
            if (dtgAvailableTags.DataSource == null)
            {
                dtgAvailableTags.DataSource = new string[] { };
            }

        }

        protected void dtgAvailableTags_PreRender(object sender, EventArgs e)
        {
            dtgAvailableTags.Rebind();
        }

        
        protected void dtgAvailableTags_ItemCommand(object sender, GridCommandEventArgs e)
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

        #region Page_Init
        protected void Page_Init(object sender, System.EventArgs e)
        {
            if (Request.QueryString["ModuleId"] != null)
            {
                moduleId = Request.QueryString["ModuleId"].ToString();
                category = Request.QueryString["category"].ToString();
            }
            
            if (moduleId != null && moduleId != "")
            {
                string _tableName;
                Modules mObj = new Modules();
                DataSet ds = new DataSet();
                ds = mObj.GetModule(moduleId);
                _tableName = mObj.BaseTable;
                string sdw = "";
                //lblTableName.Text=_tableName;
                SystemDefenitionDetails sObj = new SystemDefenitionDetails();
                datatableobj = sObj.GetPrimarykeys(_tableName);
                for (int i = 0; i < datatableobj.Rows.Count; i++)
                {
                    Key = datatableobj.Rows[i]["Field_Name"].ToString();
                    primarykeys = primarykeys + Key + ",";

                    sdw = primarykeys.TrimEnd(',', ' ');
                }
                // string[] test = sdw.Split(",");
                dtgAvailableTags.MasterTableView.DataKeyNames = sdw.Split(',').ToArray();// new string[] { sdw };
                hdfFieldName.Value = sdw;
                dtgAllocateTags.MasterTableView.DataKeyNames = sdw.Split(',').ToArray();
                hdfAllocatedDataKey.Value = sdw;
            }
        }
        #endregion  Page_Init

        protected void dtgAvailableTags_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem dataItem = (GridDataItem)e.Item;
                CheckBox chkBox = (CheckBox)dataItem["Modulescheck"].Controls[0];
                chkBox.Enabled = true; // enable CheckBox
            }
        }

        protected void dtgAllocateTags_PreRender(object sender, EventArgs e)
        {
            dtgAllocateTags.Rebind();
           
        }

        protected void dtgAllocateTags_ItemCommand(object sender, GridCommandEventArgs e)
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

        protected void dtgAllocateTags_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem dataItem = (GridDataItem)e.Item;
                CheckBox chkBox = (CheckBox)dataItem["Allocatecheck"].Controls[0];
                chkBox.Enabled = true; // enable CheckBox
            }
        }

        protected void dtgAllocateTags_DataBound(object sender, EventArgs e)
        {
            if (hdfValue.Value == "1")
            {
                dtgAllocateTags.MasterTableView.GetColumn("KeyField").Display = false;
            }
        }



        //protected void RadTreeView1_NodeClick(object sender, RadTreeNodeEventArgs e)
        //{
        //    dtgAvailableTags.Rebind();
        //}

        //protected void dtgAvailableTags_ItemCreated(object sender, GridItemEventArgs e)
        //{
        //    dtgAvailableTags.Rebind();
        //}

        //protected void dtgAvailableTags_PreRender(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        dtgAvailableTags.Rebind();
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //}



        //private static void BindToDataSet(RadTreeView treeView)
        //{

        //    FlyCnDAL.Users userObj = new FlyCnDAL.Users();
        //    DataTable dtParent = new DataTable();
        //    dtParent = userObj.BindModules();
        //    treeView.DataTextField = "ModuleDesc";
        //   // treeView.DataFieldID = "ModuleDesc";
        //    treeView.DataFieldParentID = "ModuleID";

        //    treeView.DataSource = dtParent;
        //    treeView.DataBind();
        //}
 
    }
}