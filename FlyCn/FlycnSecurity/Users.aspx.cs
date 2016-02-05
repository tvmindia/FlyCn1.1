using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FlyCn.FlyCnDAL;
using Telerik.Web.UI;

namespace FlyCn.FlycnSecurity
{
    public partial class Users : System.Web.UI.Page
    {
        #region private variables
        ErrorHandling eObj = new ErrorHandling();
        #endregion private variables

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            
            ToolBar.onClick += new RadToolBarEventHandler(ToolBar_onClick);
            ToolBar.OnClientButtonClicking = "OnClientButtonClicking";
           if(!IsPostBack)
              {
                BindData();
              
              }
           BindData();
        }
        #endregion Page_Load

        #region dtgManageExisting_NeedDataSource
        protected void dtgManageExisting_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if (dtgManageExisting.DataSource == null)
            {
                dtgManageExisting.DataSource = new string[] { };
            }  
        }

        #endregion dtgManageExisting_NeedDataSource

        #region ToolBar_onClick
        protected void ToolBar_onClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
             {
                  string functionName = e.Item.Value;
          
                if (e.Item.Value == "Save")
                {
                    FillUsers();
                    dtgManageExisting.Rebind();
                 }
                BindData();
             }
        #endregion ToolBar_onClick

        #region BindData
        public void BindData()
        {
           FlyCnDAL.Users userObj = new FlyCnDAL.Users();
           DataTable ds = new DataTable();
            ds = userObj.GetAllUsers();
            dtgManageExisting.DataSource = ds;
            try
            {
                dtgManageExisting.DataBind();
               
            }
            catch(Exception ex)
            {

            }
            
        }
        #endregion BindData

        #region FillUsers
        public void FillUsers()
        {
           
            FlyCnDAL.Users userObj = new FlyCnDAL.Users();
            try
            {
                userObj.UserName = txtLoginName.Text;
                userObj.Password = txtPassword.Text;
                userObj.UserEMail = txtEmail.Text;
                userObj.Active = Convert.ToBoolean(txtActive.Text);
                userObj.Theme = ddlTheme.Text;
                userObj.InsertM_Users();
            }
            catch(Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
            }
        }
        #endregion FillUsers

        #region ValidateLoginName
        [System.Web.Services.WebMethod]
        public static bool ValidateLoginName(string LogName)
        {
            string loginName =LogName;
           
            FlyCnDAL.Users userObj = new FlyCnDAL.Users();  
            if(userObj.ValidateUsername(loginName))

            {
                return true;
            }
            return false;
        }

        #endregion ValidateLoginName
    }
}