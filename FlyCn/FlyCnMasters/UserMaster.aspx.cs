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
        UIClasses.Const Const = new UIClasses.Const();
        FlyCnDAL.Security.UserAuthendication UA;
        ErrorHandling eObj = new ErrorHandling();
        protected void Page_Load(object sender, EventArgs e)
        {
            UA = (FlyCnDAL.Security.UserAuthendication)Session[Const.LoginSession];
            ToolBar.onClick += new RadToolBarEventHandler(ToolBar_onClick);
            ToolBar.OnClientButtonClicking = "OnClientButtonClicking";
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
            Security securityObj = new Security();
            DataTable dtable = new DataTable();
            try
            {
                dtable = securityObj.GetUser();

                dtgUserMaster.DataSource = dtable;

            }
            catch(Exception ex)
            {
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
             dtgUserMaster.MasterTableView.GetColumn("PassWord").Visible = false;

             dtgUserMaster.Rebind();
         }

         #endregion  dtgUserMaster_PreRender

         protected void dtgUserMaster_ItemCommand(object source, GridCommandEventArgs e)
         {
             Security securityObj = new Security();
             GridDataItem item = e.Item as GridDataItem;
             string strId = item.GetDataKeyValue("UserName").ToString();

             if (e.CommandName == "Delete")
             {
                 string UserName = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UserName"].ToString();
                 string PassWord = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["PassWord"].ToString();

                 int result = securityObj.DeleteUser(UserName, PassWord);


             }
         }
    }
}