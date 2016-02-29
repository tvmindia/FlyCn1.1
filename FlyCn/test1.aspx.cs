using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FlyCn.FlyCnDAL;
using System.Data.SqlClient;
using System.Data;
using FlyCnSecurity.SecurityDAL;
using System.Configuration;
using Telerik.Web.UI;
namespace FlyCn
{
    public partial class test1 : System.Web.UI.Page
    {

        SecurityUsers DALObj = new SecurityUsers();

        #region Make Check Box Column
        public void MakeCheckBoxColumn()
        {
            
            
               
            
////---------------- Add checkbx
//             GridCheckBoxColumn chkAdd;
//            chkAdd = new GridCheckBoxColumn();
//            chkAdd.UniqueName = "Add";
//            chkAdd.HeaderText = "Add";
//            radgrdObjects.MasterTableView.Columns.Add(chkAdd);

//---------------- Edit checkbx
            // GridCheckBoxColumn chkEdit;
            //chkEdit = new GridCheckBoxColumn();
            //chkEdit.UniqueName = "Edit";
            //chkEdit.HeaderText = "Edit";
            //radgrdObjects.MasterTableView.Columns.Add(chkEdit);

//---------------- Delete checkbx
            //GridCheckBoxColumn chkDelete;
            //chkDelete = new GridCheckBoxColumn();
            //chkDelete.UniqueName = "Delete";
            //chkDelete.HeaderText = "Delete";
            //radgrdObjects.MasterTableView.Columns.Add(chkDelete);

//---------------- ReadOnly checkbx
            //GridCheckBoxColumn chkReadonly;
            //chkReadonly = new GridCheckBoxColumn();
            //chkReadonly.UniqueName = "ReadOnly";
            //chkReadonly.HeaderText = "ReadOnly";
            //radgrdObjects.MasterTableView.Columns.Add(chkReadonly);
        }

        #endregion Make Check Box Column

        public int url
        {
            get;
            set;
        }
        public int url2
        {
            get;
            set;
        }

        protected void btn_ExcelMail_Click(object sender, EventArgs e)
        {
            string StatusID = "4cd93ccc-7c83-4ca7-8641-3cea4b30d3d3";
            MailSending MailObj = new MailSending();
            //FlyCnDAL.ExcelImport detailsObj = new FlyCnDAL.ExcelImport();
            ImportFile detailsObj = new ImportFile();
            DataSet ds = new DataSet();
           
            ds=detailsObj.getExcelImportDetailsById(StatusID);
            
           
                MailObj.SendExcelImportMail(StatusID, detailsObj.UserName);
            
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            ExcelTemplate eObj = new ExcelTemplate();
            eObj.GenerateExcelTemplate("C00001","BASE_Electrical");
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            //DALObj.LevelDesc = txtLevelDescription.Text;
            //DALObj.UserID = txtUserName.Text;
           

            string userAccess = DALObj.GetUserAccess(txtUserName.Text,txtLevelDescription.Text);
            lblPermission.Text = userAccess;
        }

        protected void radgrdObjects_PreRender(object sender, EventArgs e)
        {
            //radgrdObjects.MasterTableView.GetColumn("LevelID").HeaderStyle.Width = Unit.Pixel(200);

            //MakeCheckBoxColumn();
        }


//-----------* Manage Access *----------------//

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            url = Request.Url.Port;
            if (radgrdObjects.EnableLinqExpressions)
            {
                radgrdObjects.MasterTableView.FilterExpression = "(Convert.ToInt32(iif(it['ParentID']==Convert.DBNull,null,it['ParentID']))==Convert.DBNull)";
            }
            else
            {
                radgrdObjects.MasterTableView.FilterExpression = "ParentID is null";
            }
        }

        #endregion Page Load

        #region Need Data Source - RadGrid
        protected void radgrdObjects_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

            FlyCnSecurity.SecurityDAL.SecurityObjects obj = new FlyCnSecurity.SecurityDAL.SecurityObjects();
            obj.RoleID = 119;
            radgrdObjects.DataSource = obj.GetRegisteredModules().Tables[0];


        }

        #endregion Need Data Source - RadGrid

        #region Column Created -Radgrid
        protected void radgrdObjects_ColumnCreated(object sender, Telerik.Web.UI.GridColumnCreatedEventArgs e)
        {
            if (e.Column is GridExpandColumn)
            {
                e.Column.Visible = false;
            }
             if (e.Column is GridBoundColumn)
            {
                e.Column.HeaderStyle.Width = Unit.Pixel(200);
                e.Column.ItemStyle.Width = Unit.Pixel(200);
            }

             if (e.Column is GridGroupSplitterColumn)
             {
                 e.Column.HeaderStyle.Width = Unit.Pixel(200);
             }
        }

        #endregion Column Created -Radgrid

        #region Item Created -RadGrid
        protected void radgrdObjects_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            rowSettings(e);
            if (e.Item is GridHeaderItem && e.Item.OwnerTableView != radgrdObjects.MasterTableView)
            {
                e.Item.Style["display"] = "none";
            }
            if(e.Item is GridNestedViewItem) {
                e.Item.Cells[0].Visible = false;
            }
        }

        #endregion Item Created -RadGrid

        #region Item Data Bound - RadGrid
        protected void radgrdObjects_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        
        {
            rowSettings(e);

        }

        #endregion  Item Data Bound - RadGrid

        #region Row Settings
        public void rowSettings(GridItemEventArgs e) {

            if (e.Item is GridNoRecordsItem) {
                GridDataItem parentname = (GridDataItem)e.Item.OwnerTableView.ParentItem;
                if (parentname.FindControl("MyExpBtn") != null) {
                    Button btn = (Button)parentname.FindControl("MyExpBtn");
                    btn.Attributes.Add("style","visibility:hidden");
                    btn.Width = Unit.Pixel(35);
                }
            }

            if (e.Item is GridDataItem) {

                GridDataItem gitem=(GridDataItem)e.Item;

                createExpandButton(e.Item, "LevelID");
               
                if (gitem["isChildExist"].Text.Trim()=="0"){
                    removeExpand(e.Item, "");
                }else{
                    createExpandButton(e.Item, "LevelID");
                }

//------------- *Enable All the checkbox columns*----------------//

                CheckBox chkAdd = (CheckBox)gitem["Add"].Controls[0];
                chkAdd.Enabled = true;

                CheckBox chkEdit = (CheckBox)gitem["Edit"].Controls[0];
                chkEdit.Enabled = true;

                CheckBox chkDelete = (CheckBox)gitem["Delete"].Controls[0];
                chkDelete.Enabled = true;

                CheckBox chkReadonly = (CheckBox)gitem["ReadOnly"].Controls[0];
                chkReadonly.Enabled = true;
            }
        
        }

        #endregion Row Settings

        #region Create Expand
        public void createExpandButton(GridItem item,string columnname){

            if (item is GridDataItem) {
                GridDataItem gitem = (GridDataItem) item;
                if (item.FindControl("MyExpBtn") == null) {
                    Button btn = new Button();
                    btn.Click += new EventHandler(button1_Click);
                    btn.CommandName = "ExpandCollapse";
                    if (item.Expanded)
                    {
                        btn.CssClass = "rgCollapse";
                    }
                    else {
                        btn.CssClass = "rgExpand";                    
                    }
                    btn.ID = "MyExpBtn";

                    if (item.OwnerTableView.HierarchyLoadMode == GridChildLoadMode.Client) { 

                        string script=string.Format("$find('{0}')._toggleExpand(this,event);return false;",item.Parent.Parent.ClientID);
                        btn.OnClientClick = script;


                    }

                    int level = item.ItemIndexHierarchical.Split(':').Length;
                    if (level > 1) { 
                    btn.Style["margin-left"]=((level)+20) + "px";
                    }

                    TableCell cell=new TableCell();
                    cell=(TableCell)gitem[columnname];
                    cell.Controls.Add(btn);
                    cell.Controls.Add(new LiteralControl(" "));
                    cell.Controls.Add(new LiteralControl(gitem.GetDataKeyValue(columnname).ToString()));

                    
                  

                }
            
            
            }
        
        }

        #endregion Create Expand

        #region Remove Expand
        public void removeExpand(GridItem item, string columnname)
        {
            if (item is GridDataItem)
            {
                if (item.FindControl("MyExpBtn") != null)
                {
                    Button btn = (Button)item.FindControl("MyExpBtn");
                    btn.Attributes.Add("style", "visibility:hidden;margin-right: 0.5cm");
                }

            }
        }

        #endregion  Remove Expand

        #region Button Click -Expand
        private void button1_Click(object sender, System.EventArgs e)
        {
            //MakeCheckBoxColumn();
            // Add event handler code here.
            Button btn = (Button)sender;
            if (btn.CssClass == "rgExpand") {
                btn.CssClass = "rgCollapse";
            }
            else{
                btn.CssClass = "rgExpand";
               
            }
        }

        #endregion Button Click -Expand

       
    }
}