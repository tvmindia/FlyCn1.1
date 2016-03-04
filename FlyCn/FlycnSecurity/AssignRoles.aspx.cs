using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;

namespace FlyCn.FlycnSecurity
{
    public partial class AssignRoles : System.Web.UI.Page
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            ToolBar.onClick += new RadToolBarEventHandler(ToolBar_onClick);
            ToolBar.OnClientButtonClicking = "OnClientButtonClicking";
            if (!IsPostBack)
            {
                BindDropDownUser();
                BindCurrentRoles();
               
                BindRoleScopeComboBox();
               
                BindAssignRoles();
            }
        }
        #endregion Page_Load

        #region ToolBar_onClick
        protected void ToolBar_onClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            FlyCnDAL.Users userObj = new FlyCnDAL.Users();
            FlyCn.FlyCnDAL.ErrorHandling eObj = new FlyCn.FlyCnDAL.ErrorHandling();
            DataTable ds = new DataTable();
            try
            {
                string functionName = e.Item.Value;
                int RoleID = 0;
               // if (DropDownList2.SelectedValue != "--select level--")
            //    {
                    int rolescope = Convert.ToInt32(DropDownList2.SelectedValue);
                    string scopeValue = DropDownList3.SelectedValue;

                    ds = userObj.AssignUserRoles(rolescope, scopeValue);
                    int count = ds.Rows.Count;
                    if (e.Item.Value == "Save")
                    {
                        foreach (GridDataItem item in dtgAssignRoles.Items)
                        {

                            CheckBox checkColumnAdd = item["Assignrolescheck"].Controls[0] as CheckBox;
                            if (checkColumnAdd.Checked == true)
                            {

                                string Id = item.GetDataKeyValue("RoleName").ToString();
                                for (int i = 0; i <= count; i++)
                                {
                                    foreach (GridDataItem row in dtgAssignRoles.Items)
                                    {

                                        string RoleName = row.GetDataKeyValue("RoleName").ToString();


                                        if (RoleName == Id)
                                        {
                                            RoleID = Convert.ToInt32(ds.Rows[i]["RoleID"]);
                                        }
                                        i = i + 1;
                                    }
                                }
                                userObj.UserId = DropDownList1.SelectedItem.Value;
                                userObj.RoleID = RoleID;
                                userObj.InsertAssignedRoles();

                            }

                            if (checkColumnAdd.Checked == false)
                            {
                                int i = 0;
                                foreach (GridDataItem row in dtgAssignRoles.Items)
                                {
                                    string Id = item.GetDataKeyValue("RoleName").ToString();
                                    string RoleName = row.GetDataKeyValue("RoleName").ToString();
                                    string userID = DropDownList1.SelectedItem.Value;

                                    if (RoleName == Id)
                                    {
                                        RoleID = Convert.ToInt32(ds.Rows[i]["RoleID"]);
                                        userObj.DeleteUser(userID, RoleID);
                                    }
                                    i = i + 1;
                                }
                                // userObj.DeleteUser();
                                //  BindCurrentRoles();
                            }
                        }
                    }
                    BindCurrentRoles();
              //  }
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
               // throw ex;
            }
        }
        #endregion ToolBar_onClick

        #region dtgCurrentRoles_NeedDataSource
        protected void dtgCurrentRoles_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if (dtgCurrentRoles.DataSource == null)
            {
                dtgCurrentRoles.DataSource = new string[] { };
            }
        }
        #endregion dtgCurrentRoles_NeedDataSource

        #region dtgAssignRoles_NeedDataSource
        protected void dtgAssignRoles_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if (dtgAssignRoles.DataSource == null)
            {
                dtgAssignRoles.DataSource = new string[] { };
            }
           
        }
        #endregion dtgAssignRoles_NeedDataSource

        #region BindDropDownUser
        public void BindDropDownUser()
        {
            FlyCnDAL.Users userObj = new FlyCnDAL.Users();
            DataTable dt = new DataTable();
            dt = userObj.SelectUsersToDropDown();
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = "UserID";
            DropDownList1.DataBind();
        }
        #endregion BindDropDownUser

        #region BindCurrentRoles
        public void BindCurrentRoles()
        {
            FlyCnDAL.Users userObj = new FlyCnDAL.Users();
            DataTable ds = new DataTable();
            string userID = DropDownList1.SelectedItem.Value;
            ds = userObj.CurrentUserRoles(userID);
            dtgCurrentRoles.DataSource = ds;
            try
            {
                dtgCurrentRoles.DataBind();
            }
            catch (Exception ex)
            {

            }

        }
        #endregion BindCurrentRoles

        #region BindAssignRoles
        public void BindAssignRoles()
        {
            if (DropDownList3.SelectedValue != "--select--")
            {
                int rolescope = Convert.ToInt32(DropDownList2.SelectedValue);
                string scopeValue = DropDownList3.SelectedValue;
                FlyCnDAL.Users userObj = new FlyCnDAL.Users();
                DataTable ds = new DataTable();
                 DataTable dt = new DataTable();
                ds = userObj.AssignUserRoles(rolescope, scopeValue);
                dtgAssignRoles.DataSource = ds;
                try
                {
                    dtgAssignRoles.DataBind();
                    string userID = DropDownList1.SelectedItem.Value;
                    dt = userObj.CurrentUserRoles(userID);
                  int count = ds.Rows.Count;
                    string Id, AssignRole = "";
                 for (int i = 0; i <= count; i++)
                   {
                     foreach (GridDataItem colName in dtgCurrentRoles.Items)
                            {
                        foreach (GridDataItem item in dtgAssignRoles.Items)
                        {
                            CheckBox checkColumnAdd = item["Assignrolescheck"].Controls[0] as CheckBox;
                            
                                AssignRole = item.GetDataKeyValue("RoleName").ToString();

                                Id = colName.GetDataKeyValue("RoleName").ToString();

                                if (Id.Contains(AssignRole))
                                {
                                    checkColumnAdd.Checked = true;
                                }
                            }
                        }
                    }
               
              }

                catch (Exception ex)
                {

                }
            }
            else 
            {
                dtgAssignRoles.DataSource = new string[] { };
            }

        }
        #endregion BindAssignRoles

        #region dtgAssignRoles_ItemCreated
        protected void dtgAssignRoles_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {

            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                CheckBox checkBoxAdd = (CheckBox)item["Assignrolescheck"].Controls[0];
                checkBoxAdd.Enabled = true;
            }


        }
        #endregion dtgAssignRoles_ItemCreated

        #region DropDownList1_SelectedIndexChanged
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCurrentRoles();
            lblCurrentRoles.Visible = false;
            lblAssignRoleName.Text = "select following levels for assigning roles to "+DropDownList1.SelectedValue;
            lblCurrentRoleDescription.Text = "Current roles of " + DropDownList1.SelectedValue;
            DropDownList2.ClearSelection();
            DropDownList3.Items.Clear();
            
            dtgAssignRoles.DataSource = new string[] { };
            dtgAssignRoles.DataBind();
        }

        #endregion DropDownList1_SelectedIndexChanged

        #region Bind Role Scope ComboBox

        public void BindRoleScopeComboBox()
        {
            DataSet dsRoleName = null;
            FlyCnDAL.Users userObj = new FlyCnDAL.Users();
            try
            {
                dsRoleName = new DataSet();
                dsRoleName = userObj.GetAllRoleName();

                DropDownList2.DataSource = dsRoleName;
                DropDownList2.DataTextField = "Caption";
                DropDownList2.DataValueField = "ID";
                DropDownList2.DataBind();

                
            }
            catch (Exception)
            {
              

            }
        }
        #endregion Bind Role Scope ComboBox

        #region DropDownList2_SelectedIndexChanged
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList3.Items.Clear();
            string RoleScopeText = string.Empty;
            string tableName = string.Empty;
            string level = string.Empty;
            DataSet dsRoles = null;
            FlyCnDAL.Users userObj = new FlyCnDAL.Users();
            level = DropDownList2.SelectedItem.Value;
            RoleScopeText = DropDownList2.SelectedItem.Text;

            //--Table name based on level value(based on level dropdown)--//

            switch (level)
            {
                case "1": tableName = "SYS_RoleScopeLevel1";
                    break;

                case "2": tableName = "SYS_RoleScopeLevel2";
                    break;

                case "3": tableName = "SYS_RoleScopeLevel3";
                    break;

                case "4": tableName = "SYS_RoleScopeLevel4";
                    break;

                case "5": tableName = "SYS_RoleScopeLevel5";
                    break;
            }
            try
            {

                if (tableName != string.Empty)
                {
                    userObj.TableName = tableName;

                    dsRoles = userObj.GetAllRoleScope();
                    DropDownList3.DataTextField = "Description";
                    DropDownList3.DataValueField = "ID";
                    DropDownList3.DataSource = dsRoles;

                    DropDownList3.DataBind();

                    
                }

            }
            catch (Exception)
            {

              //  lblError.Text = "Some problem while populating role scope combobox ";
            }
           
        }
        #endregion DropDownList2_SelectedIndexChanged

        #region DropDownList3_SelectedIndexChanged
        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {

            BindAssignRoles();

        }
        #endregion DropDownList3_SelectedIndexChanged
    }
}