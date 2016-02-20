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
        protected void Page_Load(object sender, EventArgs e)
        {
            url = Request.Url.Port;
            if (radgrdObjects.EnableLinqExpressions) {
                radgrdObjects.MasterTableView.FilterExpression = "(Convert.ToInt32(iif(it['ParentID']==Convert.DBNull,null,it['ParentID']))==Convert.DBNull)";
            }
            else {
                radgrdObjects.MasterTableView.FilterExpression = "ParentID is null";
            }
            
            

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

        protected void radgrdObjects_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            FlyCnSecurity.SecurityDAL.SecurityObjects obj = new FlyCnSecurity.SecurityDAL.SecurityObjects();
            radgrdObjects.DataSource = obj.GetRegisteredModules().Tables[0];
        }

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

        protected void radgrdObjects_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            rowSettings(e);
        }

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
            
            }
        
        }
       

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

        private void button1_Click(object sender, System.EventArgs e)
        {
            // Add event handler code here.
            Button btn = (Button)sender;
            if (btn.CssClass == "rgExpand") {
                btn.CssClass = "rgCollapse";
            }
            else{
                btn.CssClass = "rgExpand";
            }
        }

        protected void radgrdObjects_PreRender(object sender, EventArgs e)
        {
            //radgrdObjects.MasterTableView.GetColumn("LevelID").HeaderStyle.Width = Unit.Pixel(200);
        }


        public void removeExpand(GridItem item, string columnname) {
            if (item is GridDataItem) { 
                if (item.FindControl("MyExpBtn") != null) {
                    Button btn = (Button)item.FindControl("MyExpBtn");
                    btn.Attributes.Add("style", "visibility:hidden");
                }
                
            }
        }

    }
}