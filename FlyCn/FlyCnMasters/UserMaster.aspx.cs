using FlyCn.FlyCnDAL;
using FlyCn.UIClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


namespace FlyCn.FlyCnMasters
{
    public partial class UserMaster : System.Web.UI.Page
    {
       
        public int NumberOfTimesNeedDataSourceCalled = 0;


        UIClasses.Const Const = new UIClasses.Const();
        FlyCnDAL.Security.UserAuthendication UA;
        ErrorHandling eObj = new ErrorHandling();
        protected void Page_Load(object sender, EventArgs e)
        {
            UA = (FlyCnDAL.Security.UserAuthendication)Session[Const.LoginSession];
            ToolBar.onClick += new RadToolBarEventHandler(ToolBar_onClick);
            ToolBar.OnClientButtonClicking = "OnClientButtonClicking";
            //if (IsPostBack)
            //    LoadGrid();

            GridviewFilter.onClick += new EventHandler(GridviewFilter_onClick);
            //GridviewFilter.searchClickFromAddClick += new EventHandler(GridviewFilter_onClick);

        }



   protected void   GridviewFilter_onClick(object sender, EventArgs e)
        {
            NumberOfTimesNeedDataSourceCalled = 1;
            LoadGrid();
            upGrid.Update();
        }



           #region  ToolBar_onClick
        protected void ToolBar_onClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            string functionName = e.Item.Value;
            if (functionName == "Save")
            {
                InsertUserData();
            }
        }
        #endregion  ToolBar_onClick

        #region dtgUserMaster_NeedDataSource

        protected void dtgUserMaster_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
           
            LoadGrid();
       
        }

        void LoadGrid()
        {
            Security securityObj = new Security();
            DataTable dtable = new DataTable();
            try
            {
                dtable = securityObj.GetUser();
                string searchQuery = GridviewFilter.WhereCondition;

                if (searchQuery != null)
                {
                    DataRow[] test = dtable.Select(searchQuery);
                    dtgUserMaster.DataSource = test;

                    //int rowLength = test.Length;
           
                    //if(rowLength == 0)
                    //{
                    //    lblSearchErrorMsg.Text = "Sorry! Searched item not found";
                    //}


                    dtgUserMaster.DataBind();

                }
                else {
                    dtgUserMaster.DataSource = dtable;

                    if (NumberOfTimesNeedDataSourceCalled == 1)
                    {

                        dtgUserMaster.DataBind();
                    }
                }

            }
            catch (Exception ex)
            {
                //lblSearchErrorMsg.Text = "Error";

                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.ErrorData(ex, page);
            }
        }

        #endregion dtgUserMaster_NeedDataSource

        public void InsertUserData()
        {
            Security securityObj = new Security();
            securityObj.UserName = txtUserName.Text;
            securityObj.PassWord =txtPassWord.Text;
            securityObj.ConfirmPassWord = txtConfirmPassWord.Text;
            securityObj.EmailId = txtEmailId.Text;
            securityObj.CreatedBy = UA.userName;
            int result = securityObj.InsertUser();
            if (result == 1)
            {
            }
            else
            {

            }
           
        }

         public void DeleteUserData()
        {

        }

         #region  dtgUserMaster_PreRender
         protected void dtgUserMaster_PreRender(object sender, EventArgs e)
         {
             try
             {

                 dtgUserMaster.MasterTableView.GetColumn("PassWord").Visible = false;



                 dtgUserMaster.Rebind();
             }
             catch (Exception exc)
             {
                 ErrorHandling ObjError = new ErrorHandling();
                 ObjError.ErrorData(exc, this);
                // throw;
             }
            
           
         
         }

         #endregion  dtgUserMaster_PreRender

         protected void dtgUserMaster_ItemCommand(object source, GridCommandEventArgs e)
         {
            

             if (e.CommandName == "Delete")
             {

                 Security securityObj = new Security();
                 GridDataItem item = e.Item as GridDataItem;
                 string strId = item.GetDataKeyValue("UserName").ToString();

                 string UserName = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UserName"].ToString();
                 string PassWord = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["PassWord"].ToString();

                 int result = securityObj.DeleteUser(UserName, PassWord);


             }
         }
    }
}