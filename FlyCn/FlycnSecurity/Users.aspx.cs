using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FlyCn.FlyCnDAL;
using Telerik.Web.UI;
using FlyCn.UIClasses;
using System.Data.SqlClient;

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

            ToolBar.AddButton.Visible = false;
            ToolBar.EditButton.Visible = false;
            ToolBar.DeleteButton.Visible = false;
            ToolBar.UpdateButton.Visible = false;
            ToolBar.SaveButton.Visible = true;
            SecurityCheck();
           if(!IsPostBack)
              {
               
              
              }
         
        }
        #endregion Page_Load

        #region dtgManageExisting_NeedDataSource
        protected void dtgManageExisting_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            FlyCnDAL.Users userObj = new FlyCnDAL.Users();
           
          
                DataTable ds = new DataTable();
                ds = userObj.GetAllUsers();
                dtgManageExisting.DataSource = ds;
           
                   
            
        }

        #endregion dtgManageExisting_NeedDataSource

        #region SecurityCheck
        public void SecurityCheck()
        {
            string logicalObject = "Users";

            FlyCnDAL.Security.PageSecurity PS = new Security.PageSecurity(logicalObject, this);

            if (PS.isWrite == true)
            {
                dtgManageExisting.MasterTableView.GetColumn("EditData").Display = true;
                dtgManageExisting.MasterTableView.GetColumn("Delete").Display = false;
                ToolBar.Visible = true;
            }
            else
                if (PS.isEdit == true)
                {
                    dtgManageExisting.MasterTableView.GetColumn("EditData").Display = true;
                    dtgManageExisting.MasterTableView.GetColumn("Delete").Display = false;
                    ToolBar.Visible = true;
                }
                else if (PS.isAdd == true)
                {
                    dtgManageExisting.MasterTableView.GetColumn("EditData").Display = false;
                    dtgManageExisting.MasterTableView.GetColumn("Delete").Display = false;
                    ToolBar.Visible = true;
                }
                else if (PS.isRead == true)
                {
                    dtgManageExisting.MasterTableView.GetColumn("EditData").Display = false;
                    dtgManageExisting.MasterTableView.GetColumn("Delete").Display = false;
                    ToolBar.Visible = false;
                }

                else if (PS.isDenied == true)
                {
                    HttpContext.Current.Response.Redirect("~/General/UnderConstruction.aspx?cause=accessdenied", true);
                }
            if (PS.isDelete == true)
            {
                dtgManageExisting.MasterTableView.GetColumn("Delete").Display = true;
            }

        }
        #endregion SecurityCheck

        #region Toolbar visibility for project roles
        public void TabVisibility()
        {
            ToolBar.UpdateButton.Visible = false;
            ToolBar.DeleteButton.Visible = false;
            ToolBar.AddButton.Visible = false;
            ToolBar.SaveButton.Visible = true;
        }

        #endregion Toolbar visibility for project roles


        #region ToolBar_onClick
        protected void ToolBar_onClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
             {
                  string functionName = e.Item.Value;
          
                if (e.Item.Value == "Save")
                {
                    FillUsers();
                    dtgManageExisting.Rebind();
                 }
               
                if (functionName == "Update")
                {
                    UpdateM_user();
                    dtgManageExisting.Rebind();

                    //RegisterToolBox();
                }
                BindData();

             }
        #endregion ToolBar_onClick

        #region UpdateM_user
        public void UpdateM_user()
        {
            FlyCnDAL.Users userObj = new FlyCnDAL.Users();
            string userName = ViewState["UserName"].ToString();
            userObj.Password = txtPassword.Text;
            userObj.UserEMail = txtEmail.Text;
            if (chkIsActive.Checked)
            {
                userObj.Active = true;
            }
            else
            {
                userObj.Active = false;
            }
            int result = userObj.EditM_users(userName);
            if (result == 1)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.UpdationSuccessData(page);

            }
            BindData();
            clearControls();
        }
       #endregion UpdateM_user 

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
                if (chkIsActive.Checked)
                {
                    userObj.Active = true;
                }
                else
                {
                    userObj.Active = false;
                }
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

        protected void dtgManageExisting_ItemCommand(object sender, GridCommandEventArgs e)
        {
           
        }

        #region clearControls
        public void clearControls()
        {
            txtLoginName.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
        }
        #endregion clearControls

        #region Delete from M_User

        public void DeleteUserByUserName(string userName)
        {
            FlyCnDAL.Users userObj = new FlyCnDAL.Users();
            try
            {
               userObj.DeleteM_User(userName);
               eObj.InsertionSuccessData(this, Messages.DeletionSuccessfull);

            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.ErrorData(ex, page);
            }
        }

        #endregion Delete from M_User

        protected void dtgManageExisting_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            GridDataItem items = e.Item as GridDataItem;
            string userName = items.GetDataKeyValue("UserName").ToString();
            if (e.CommandName == "Delete")
            {
                DeleteUserByUserName(userName);
            }
        }

        protected void dtgManageExisting_DeleteCommand1(object sender, GridCommandEventArgs e)
        {

            GridDataItem items = e.Item as GridDataItem;
            string userName = items.GetDataKeyValue("UserName").ToString();
            if (e.CommandName == "Delete")
            {
                DeleteUserByUserName(userName);
            }
        }

        #region Toolbar Visibility

        public void ToolbarVisibility(string EditCase)
        {
            if (EditCase == "True")
            {
                ToolBar.UpdateButton.Visible = true;
                ToolBar.SaveButton.Visible = false;
            }
        }

        #endregion Toolbar Visibility
        protected void dtgManageExisting_ItemCommand1(object sender, GridCommandEventArgs e)
        {
            FlyCnDAL.Users userObj = new FlyCnDAL.Users();
            DataTable dt = new DataTable();
            GridDataItem items = e.Item as GridDataItem;

            if (items != null)
            {
                string userName = items.GetDataKeyValue("UserName").ToString();
                ViewState["UserName"] = userName;

                if (e.CommandName == "Delete")
                {
                    DeleteUserByUserName(userName);
                }
                if (e.CommandName == "EditData")
                {
                    hdnEditPostBack.Value = "True";
                    ToolbarVisibility(hdnEditPostBack.Value);
                    dt = userObj.GetAllUsers();
                    int rowCount = dt.Rows.Count;
                    for (int i = 0; i < rowCount; i++)
                    {
                        if (dt.Columns.Contains("UserName"))
                        {
                            if (dt.Rows[i]["UserName"].ToString() == userName)
                            {
                                txtLoginName.Text = userName;

                                string password = dt.Rows[i]["PassWord"].ToString();
                                txtPassword.Text = password;
                                txtConfirmPassword.Text = password;

                                string emailID = dt.Rows[i]["EmailId"].ToString();
                                txtEmail.Text = emailID;

                                bool active =Convert.ToBoolean(dt.Rows[i]["Active"]);
                                 if(active==true)
                                 {
                                     chkIsActive.Checked = true;
                                 }
                                else
                                 {
                                     chkIsActive.Checked = false;
                                 }

                                string theme = dt.Rows[i]["Theme"].ToString();
                                ddlTheme.SelectedValue = theme;

                                userObj.Password = txtPassword.Text;
                                userObj.UserEMail = txtEmail.Text;
                                if (chkIsActive.Checked)
                                {
                                    userObj.Active = true;
                                }
                                else
                                {
                                    userObj.Active = false;
                                }
                            }   
                        }
                    }
                }
            }
        }
    }
}