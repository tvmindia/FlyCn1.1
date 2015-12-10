using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using FlyCn.FlyCnDAL;
using System.Data;
using System.Configuration;

namespace FlyCn.EngineeredDataList
{
    
    public partial class EnggDatalistBaseTable : System.Web.UI.Page
    {
        string _moduleId;
        string _TableName;
        string _ProjectNo;
       string _tree ;
        UIClasses.Const Const = new UIClasses.Const();
        FlyCnDAL.Security.UserAuthendication UA;
        protected void Page_Load(object sender, EventArgs e)
        {
            UA = (FlyCnDAL.Security.UserAuthendication)Session[Const.LoginSession];
            _moduleId = Request.QueryString["Id"];
            
            if (!Page.IsPostBack)
            {

                //RadTreeView node = new RadTreeView("rvleftmenu");
                //node.ExpandMode = TreeNodeExpandMode.ServerSideCallBack;
                //rvleftmenu.Nodes.Add(node);
            }
            if (_moduleId != null)
            {


                Modules moduleObj = new Modules();
                DataSet dsobj = new DataSet();
                dsobj = moduleObj.GetModule(_moduleId);
                lblModule.Text = dsobj.Tables[0].Rows[0]["ModuleDesc"].ToString();
                _TableName = dsobj.Tables[0].Rows[0]["BaseTable"].ToString();

                DataSet ds = new DataSet();

                ds = moduleObj.GetModules();
                string  tabliFirst = "";
                tabliFirst = " <li style='width:80px;' >" + " <a href='EnggDataListLandingPage.aspx" + "'" + "'" + "'" + ">" + "<img" + " src=" + "'" +
                    ds.Tables[0].Rows[4]["ModuleIconURLsmall"].ToString() + "'" + ">" + "<p>" 
                    + "All" + "</p>" + "</a></li>";
                horizonaltab.Controls.Add(new LiteralControl(tabliFirst));
                string tabhtml = "";

                for (int f = 0; f < ds.Tables[0].Rows.Count; f++)
                {
                    tabhtml = " <li style='width:80px;' >" + " <a href='EnggDatalistBaseTable.aspx?Id=" + ds.Tables[0].Rows[f]["ModuleID"].ToString() + "'" + "'" + "'" + ">" + "<img" + " src=" + "'" + ds.Tables[0].Rows[f]["ModuleIconURLsmall"].ToString() + "'" + ">" + "<p>" + ds.Tables[0].Rows[f]["ModuleID"].ToString() + "</p>" + "</a></li>";

                    horizonaltab.Controls.Add(new LiteralControl(tabhtml));
                }

            }


        }

        

        protected void dtgUploadGrid_ItemCommand(object source, GridCommandEventArgs e)
        {
           
        }

        protected void dtgUploadGrid_PreRender(object sender, EventArgs e)
        {
            dtgUploadGrid.MasterTableView.GetColumn("ProjectNo").Visible = false;
            dtgUploadGrid.MasterTableView.GetColumn("ExcelMustFields").Visible = false;
            dtgUploadGrid.MasterTableView.GetColumn("Field_DataType").Visible = false;
            dtgUploadGrid.MasterTableView.GetColumn("Key_Field").Visible = false;

            
            
        }
        protected void dtgUploadGrid_ItemDataBound(object sender, GridItemEventArgs e)
        {
            //dtgUploadGrid.MasterTableView.GetColumn("PassWord").Visible = false;
            //((e.Item as GridDataItem)["ClientSelectColumn"].Controls[0] as CheckBox).Enabled = false;
            if (e.Item is GridDataItem) //Your condition goes here 
            {
                //((e.Item as GridDataItem)["ExcelMustFields"].Controls[0] as CheckBox).Enabled = false;

            } 
        }
        protected void dtgUploadGrid_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if (_moduleId != null)
            {

                DataSet dsObj = new DataSet();
                CommonDAL cmDalObj = new CommonDAL();
                dsObj = cmDalObj.GetTableDefinition(_TableName);
                DataTable dtobj = new DataTable();
                dtobj = dsObj.Tables[0];
                dtgUploadGrid.DataSource = dtobj;
              
            }
        }

        protected void ToggleRowSelection(object sender, EventArgs e)
        {
            ((sender as CheckBox).NamingContainer as GridItem).Selected = (sender as CheckBox).Checked;
            bool checkHeader = true;
            foreach (GridDataItem dataItem in dtgUploadGrid.MasterTableView.Items)
            {
                if (!(dataItem.FindControl("CheckBox1") as CheckBox).Checked)
                {
                    checkHeader = false;
                    break;
                }
            }
            GridHeaderItem headerItem = dtgUploadGrid.MasterTableView.GetItems(GridItemType.Header)[0] as GridHeaderItem;
            (headerItem.FindControl("headerChkbox") as CheckBox).Checked = checkHeader;
        }


        protected void ToggleSelectedState(object sender, EventArgs e)
        {
            CheckBox headerCheckBox = (sender as CheckBox);
            foreach (GridDataItem dataItem in dtgUploadGrid.MasterTableView.Items)
            {
                (dataItem.FindControl("CheckBox1") as CheckBox).Checked = headerCheckBox.Checked;
                dataItem.Selected = headerCheckBox.Checked;
            }
        }

        protected void btnExcelIimport_Click(object sender, EventArgs e)
        {
            ExcelTemplate eObj = new ExcelTemplate();
            eObj.GenerateExcelTemplate(UA.projectNo,_TableName);
        }

        protected void dtgvalidationErros_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            //DataTable dtObj = new DataTable();
            //ImportFile imlObj = new ImportFile();
            ////dtObj = imlObj.getErrorDetails();


            //dtgvalidationErros.DataSource = dtObj;
        }


    }
}