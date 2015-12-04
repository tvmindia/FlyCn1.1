using FlyCn.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using FlyCn.UserControls;
using FlyCn.FlyCnDAL;
using System.Data;
using FlyCn.UIClasses;


namespace FlyCn.EngineeredDataList
{
    public partial class EnggViewData : System.Web.UI.Page
    {
        string _id;
        TabAddEditSettings tabs = new TabAddEditSettings();
        ErrorHandling eObj = new ErrorHandling();
        DataTable datatableobj = new DataTable();
        UIClasses.Const Const = new UIClasses.Const();
        FlyCnDAL.Security.UserAuthendication UA;
        FlyCnDAL.SystemDefenitionDetails systabledefenitionobj = new FlyCnDAL.SystemDefenitionDetails();
        FlyCnDAL.MasterOperations dynamicmasteroperationobj = new FlyCnDAL.MasterOperations();

        protected void Page_Load(object sender, EventArgs e)
        {
            //--------------------------------------------------------
            ToolBar.onClick += new RadToolBarEventHandler(ToolBar_onClick);
            ToolBar.OnClientButtonClicking = "OnClientButtonClicking";
          
            //---------------------------------------------------------
        }

        protected void dtgEnggDataList_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {


        }

        protected void dtgEnggDataList_PreRender(object sender, EventArgs e)
        {
            dtgEnggDataList.Rebind();
        }

        protected void dtgEnggDataList_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            datatableobj = dynamicmasteroperationobj.BindMasters(_id, UA.projectNo);
            dtgEnggDataList.DataSource = datatableobj;
        }

        #region Page_Init
        protected void Page_Init(object sender, System.EventArgs e)
        {
          
            if (Request.Params["ID"] == null) { }
            else
            {
                _id = Request.QueryString["ID"];
               
            }
           
            string Key = "";
            string primarykeys = "";
            string sdw = "";
            Modules mObj = new Modules();
            DataSet ds = new DataSet();
            ds=mObj.GetModule(_id);
            string tableName = mObj.BaseTable;
            lblTableName.Text=tableName;
            SystemDefenitionDetails sObj = new SystemDefenitionDetails();
            datatableobj=sObj.GetPrimarykeys(tableName);
            for (int i = 0; i < datatableobj.Rows.Count; i++)
            {
                Key = datatableobj.Rows[i]["Field_Name"].ToString();
                primarykeys = primarykeys + Key + ",";

                sdw = primarykeys.TrimEnd(',', ' ');
            }
            // string[] test = sdw.Split(",");
            dtgEnggDataList.MasterTableView.DataKeyNames = sdw.Split(',').ToArray();// new string[] { sdw };
        }

        #endregion  Page_Init

        #region ToolBar_OnClick
        protected void ToolBar_onClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            if (e.Item.Value == "Save")
            {
                Insert();
            }
            if (e.Item.Value == "Update")
            {
                Update();

            }
        
        }
        #endregion ToolBar_OnClick

        #region Insert
        public void Insert()
        {

        }

        #endregion Insert

        #region Update
        public void Update()
        {

        }
        #endregion Update




    }
}