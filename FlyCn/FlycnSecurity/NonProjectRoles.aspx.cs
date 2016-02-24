#region Included Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using FlyCn.FlyCnDAL;
using System.Data;
using System.Data.SqlClient;
using FlyCnSecurity.SecurityDAL;
using Messages = FlyCn.UIClasses.Messages;

#endregion  Included Namespaces 

namespace FlyCn.FlycnSecurity
{
    public partial class NonProjectRoles : System.Web.UI.Page
    {
       
        String ScopeValueText = string.Empty; //seperated by commas 
        string RoleScopeText = string.Empty;


        #region Global Variables

        ErrorHandling eObj = new ErrorHandling();
        DALConstants cnst = new DALConstants();
        SecurityRoles DALObj = new SecurityRoles();
        FlyCnDAL.Security.UserAuthendication UA;
        UIClasses.Const Const = new UIClasses.Const();

        #endregion  Global Variables

        #region Methods

        #region Register ToolBox

        public void RegisterToolBox()
        {
            ToolBar.onClick += new RadToolBarEventHandler(ToolBar_onClick);
            ToolBar.OnClientButtonClicking = "OnClientButtonClickingDetail";

            ToolBar1.onClick += new RadToolBarEventHandler(ToolBar1_onClick);
            ToolBar1.OnClientButtonClicking = "OnClientButtonClicking";
        }
        #endregion Register ToolBox

        #region Insert Role

        public void InsertRole()
        {
            int result = 0;
            string ScopeValue = string.Empty;
            try
            { 
                    DALObj.RoleName = txtRoleName.Text;
                    DALObj.RoleType = ddlRoleType.SelectedItem.Text;
                    DALObj.ProjectGroup1 = ddlProjectGroup1.SelectedItem.Text;
                    DALObj.ProjectGroup2 = txtProjectGroup2.Text;
                    DALObj.ProjectGroup3 = txtProjectGroup3.Text;
                    DALObj.AccessType = txtAccessType.Text;
                    DALObj.Created_By = UA.userName;
                    DALObj.RoleScope = Convert.ToInt32(ddlLevel.SelectedItem.Value);

                    for (int i = 1; i < lstRoleScope.Items.Count; i++)
                    {
                        if (lstRoleScope.Items[i].Selected)
                        {

                            if (ScopeValue == string.Empty)
                            {
                                ScopeValue = lstRoleScope.Items[i].Value;
                                ScopeValueText = lstRoleScope.Items[i].Text;
                            }
                            else
                            {
                                ScopeValue = ScopeValue + "," + lstRoleScope.Items[i].Value;
                                ScopeValueText = ScopeValueText + "," + lstRoleScope.Items[i].Text;
                            }

                        }
                    }


                    DALObj.ScopeValue = ScopeValue;


                   
       result =     DALObj.InsertNonProjectRoles();

       if (result == 1)
       {
           //var page = HttpContext.Current.CurrentHandler as Page;
           //var master = page.Master;
         
           eObj.InsertionSuccessData(this, Messages.InsertionSuccessfull);

       }

                    ClearControls();
        }

               
            

            catch (SqlException ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.ErrorData(ex, page);
            }
            catch (FormatException ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.ErrorData(ex, page);
            }

            
            //catch (Exception)
            //{

            //    lblError.Text = " Some problem while inserting new non project access role";
            //}
        }

        #endregion Insert Role

        #region Update Non Project Role

        public void UpdateNonProjectRoleByRoleID()
        {
            int result = 0;
            string ScopeValue = string.Empty;
            int RoleID = Convert.ToInt32(ViewState["RoleID"]);

            DALObj.RoleID = RoleID;
            DALObj.RoleName = txtRoleName.Text;
            DALObj.RoleType = ddlRoleType.SelectedItem.Text;
            DALObj.RoleScope = Convert.ToInt32(Convert.ToInt32(ddlLevel.SelectedItem.Value));

            //DALObj.ProjectGroup1 = txtProjectGroup1.Text;
            DALObj.ProjectGroup1 = ddlProjectGroup1.SelectedItem.Text;

            DALObj.ProjectGroup2 = txtProjectGroup2.Text;
            DALObj.ProjectGroup3 = txtProjectGroup3.Text;
            DALObj.AccessType = txtAccessType.Text;
            DALObj.Created_By = UA.userName;

            for (int i = 1; i < lstRoleScope.Items.Count; i++)
            {
                if (lstRoleScope.Items[i].Selected)
                {

                    if (ScopeValue == string.Empty)
                    {
                        ScopeValue = lstRoleScope.Items[i].Value;
                        ScopeValueText = lstRoleScope.Items[i].Text;

                    }
                    else
                    {
                        ScopeValue = ScopeValue + "," + lstRoleScope.Items[i].Value;
                        ScopeValueText = ScopeValueText + "," + lstRoleScope.Items[i].Text;
                    }

                }
            }
            //DALObj.Created_Date = Convert.ToDateTime(txtCreated_Date.Text);
            DALObj.ScopeValue = ScopeValue;

         result =   DALObj.UpdateNonProjectRolesByRoleID();

         if (result == 1)
         {
             eObj.UpdationSuccessData(this,Messages.UpdationSuccessfull);
            }
        }


        #endregion Update Non Project Role

        #region Delete Role By ID

        public void DeleteRoleByID(string RoleID)
        {
            try
            {

                DALObj.RoleID = Convert.ToInt32(RoleID);
                int result = DALObj.DeleteNonProjectRoleByRoleID();


                if (result == 1)
                {
                    eObj.InsertionSuccessData(this, Messages.DeletionSuccessfull);

                }
            }
            catch (SqlException ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.ErrorData(ex, page);
            }
            catch (FormatException ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.ErrorData(ex, page);
            }

        }

        #endregion Delete Role By ID

        #region Clear Controls

        public void ClearControls()
        {
            //RoleName RoleType RoleScope ProjectGroup1 AccessType Created_By  Created_Date

            txtRoleName.Text = string.Empty;

            BindRoleTypeComboBox(null);

            BindRoleScopeComboBox(null);

            BindProjectGroup1(null);

            lstRoleScope.Items.Clear();
            //txtProjectGroup1.Text = string.Empty;

            txtProjectGroup2.Text = string.Empty;

            txtProjectGroup3.Text = string.Empty;

            txtAccessType.Text = string.Empty;

            //txtCreated_By.Text = string.Empty;

            //txtCreated_Date.Text = string.Empty;


        }
        #endregion Clear Controls

        #region Bind Role Type ComboBox

        public void BindRoleTypeComboBox(string seletedValue)
        {
            DataSet dsRoleType = null;
            try
            {
                dsRoleType = new DataSet();
                dsRoleType = DALObj.GetRoleType();

                ddlRoleType.DataSource = dsRoleType;
                ddlRoleType.DataTextField = "Description";
                ddlRoleType.DataValueField = "ID";
                ddlRoleType.DataBind();

                if (seletedValue != null)
                {
                    if(ddlRoleType.Items.FindByText(seletedValue) != null)
                    {
                        ddlRoleType.Items.FindByText(seletedValue).Selected = true;
                    }
                }

                else
                {
                    ddlRoleType.Items.Insert(0, "--Select--");
                }
              

            }

            catch (SqlException ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.ErrorData(ex, page);
            }
            catch (FormatException ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.ErrorData(ex, page);
            }
            //catch (Exception)
            //{

            //    lblError.Text = "Some problem while populating Role Type combo box !";
            //}
        }

        #endregion Bind Role Type ComboBox

        #region Bind Scope Value

        public void BindScopeValue(string level, string seletedValue)
        {
            string tableName = string.Empty;

            DataSet dsRoles = null;

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
                    DALObj.TableName = tableName;

                    dsRoles = DALObj.GetAllRoleScope();
                    lstRoleScope.DataTextField = "Description";
                    lstRoleScope.DataValueField = "ID";
                    lstRoleScope.DataSource = dsRoles;
                    lstRoleScope.DataBind();



                    if (seletedValue != null)
                    {
                        string tempSelectedValue = seletedValue;

                        if (tempSelectedValue.Contains(','))
                        {
                            string lastPart = string.Empty;

                            int count = seletedValue.Split(',').Length;

                            for (int i = count; i >= 1; i--)
                            {

                                string str = tempSelectedValue;
                                string ext = string.Empty;
                                if (str.Contains(','))
                                {

                                    ext = str.Substring(0, str.LastIndexOf(","));

                                    lastPart = str.Split(',').Last();

                                    if (lstRoleScope.Items.FindByText(lastPart) != null)
                                    {
                                        lstRoleScope.Items.FindByText(lastPart).Selected = true;
                                    }

                                    tempSelectedValue = ext;
                                }

                                else
                                {
                                    lastPart = str;


                                    if (lstRoleScope.Items.FindByText(lastPart) != null)
                                    {

                                        lstRoleScope.Items.FindByText(lastPart).Selected = true;

                                    }
                                }

                            }
                        }

                        else
                        {
                            if (lstRoleScope.Items.FindByText(seletedValue) != null)
                            {

                                lstRoleScope.Items.FindByText(seletedValue).Selected = true;
                            }
                        }
                    }



                    else
                    {
                        if (level != "1")
                        {
                            lstRoleScope.Items.Insert(0, "--Select--");
                        }
                    }

                }

            }
            catch (SqlException ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.ErrorData(ex, page);
            }
            catch (FormatException ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.ErrorData(ex, page);
            }
            //catch (Exception)
            //{
            //    lblError.Text = "Some problem while populating role scope combobox ";
            //}


        }

        #endregion Bind Scope Value


        #region Bind Role Scope ComboBox


        public void BindRoleScopeComboBox(string seletedValue)
        {
            DataSet dsRoleName = null;

            try
            {
                dsRoleName = new DataSet();
                dsRoleName = DALObj.GetAllRoleName();

                ddlLevel.DataSource = dsRoleName;
                ddlLevel.DataTextField = "Caption";
                ddlLevel.DataValueField = "ID";
                ddlLevel.DataBind();


                if (seletedValue != null)
                {
                    if (ddlLevel.Items.FindByText(seletedValue) != null)
                    {
                        ddlLevel.Items.FindByText(seletedValue).Selected = true;
                    }
                }

                else
                {
                    ddlLevel.Items.Insert(0, "--Select--");
                }

                
            }
            catch (SqlException ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.ErrorData(ex, page);
            }
            catch (FormatException ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.ErrorData(ex, page);
            }
            //catch (Exception)
            //{
            //    lblError.Text = "Some problem while populating Role Scope combo box !";

            //}
        }
        #endregion Bind Role Scope ComboBox

        #region BindProjectGroup1




        public void BindProjectGroup1(string seletedValue)
        {
            DataSet dsProjectGroup1 = null;
            try
            {
                dsProjectGroup1 = new DataSet();
                dsProjectGroup1 = DALObj.GetAllProjectGroup1Details();

                ddlProjectGroup1.DataSource = dsProjectGroup1;
                ddlProjectGroup1.DataTextField = "Value";
                ddlProjectGroup1.DataValueField = "ID";
                ddlProjectGroup1.DataBind();

                if (seletedValue != null)
                {
                    if (ddlProjectGroup1.Items.FindByText(seletedValue) != null)
                    {
                        ddlProjectGroup1.Items.FindByText(seletedValue).Selected = true;
                    }
                }

                else
                {
                    ddlProjectGroup1.Items.Insert(0, "--Select--");
                }
              
               }
            catch (SqlException ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.ErrorData(ex, page);
            }
            catch (FormatException ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.ErrorData(ex, page);
            }
            //catch (Exception)
            //{
            //    lblError.Text = "Some problem while populating project group1 combo box !";
            //}
        }

        #endregion BindProjectGroup1

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

        #endregion Methods

        #region Role Type Selected Index Changed
        protected void ddlRoleType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion Role Type Selected Index Changed

        #region Level Selected Index Changed
        protected void ddlLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            string level = string.Empty;
            DataSet dsRoles = null;

            level = ddlLevel.SelectedItem.Value;
            RoleScopeText = ddlLevel.SelectedItem.Text;

            //--Table name based on level value(based on level dropdown)--//

            BindScopeValue(level,null);

        }

        #endregion Level Selected Index Changed

        #region Role Scope Selected Index Changed
        protected void lstRoleScope_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion Role Scope Selected Index Changed

        #region Project Group1 Selected Index Changed
        protected void ddlProjectGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        #endregion Project Group1 Selected Index Changed

        
        #region Events

        #region dtgNonProjectRoles_NeedDataSource

        protected void dtgNonProjectRoles_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataSet dsNonProjectRoles = null;
            DataTable dtNonProjectRoles = null;

            try
            {
                dsNonProjectRoles = new DataSet();
                dtNonProjectRoles = new DataTable();

                dsNonProjectRoles = DALObj.GetAllDetailsOfNonProjectRoles();
                dtNonProjectRoles = dsNonProjectRoles.Tables[0];

                dtgNonProjectRoles.DataSource = dtNonProjectRoles;

               
            }

            catch (Exception ex)
            {

                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.ErrorData(ex, page);
            }

        }

        #endregion dtgNonProjectRoles_NeedDataSource

        #region  dtgNonProjectRoles_PreRender
        protected void dtgNonProjectRoles_PreRender(object sender, EventArgs e)
        {

            //dtgNonProjectRoles.Rebind();
        }

        #endregion  dtgNonProjectRoles_PreRender

        #region dtgNonProjectRoles_ItemCommand

        protected void dtgNonProjectRoles_ItemCommand(object source, GridCommandEventArgs e)
        {
           
        //-------change bg color to default if any item  is already  highlighted
           
            foreach (GridDataItem item in dtgNonProjectRoles.Items)
            {
               if(item.BackColor == System.Drawing.Color.LightPink)
               {
                  item.BackColor =  System.Drawing.Color.Transparent;
               }
            }

                GridDataItem items = e.Item as GridDataItem;

    //--- Highlight the selected item

                if (items != null)
                {

                    items.BackColor = System.Drawing.Color.LightPink;
                    if (items != null)
                    {
                        string RoleID = items.GetDataKeyValue("RoleID").ToString();
                        ViewState["RoleID"] = RoleID;

                        if (e.CommandName == "Delete")
                        {
                            DeleteRoleByID(RoleID);
                        }


                        else
                        {

                            if (e.CommandName == "EditData")
                            {
                                hdnEditPostBack.Value = "True";
                                ToolbarVisibility(hdnEditPostBack.Value);

                                try
                                {

                                    DataSet dsNonProjectRoles = null;
                                    DataTable dtNonProjectRoles = null;

                                    try
                                    {
                                        dsNonProjectRoles = new DataSet();
                                        dtNonProjectRoles = new DataTable();

                                        int roleId = Convert.ToInt32(items.GetDataKeyValue("RoleID"));

                                        DALObj.RoleID = roleId;
                                        dsNonProjectRoles = DALObj.GetAllDetailsOfNonProjectRoles();
                                        dtNonProjectRoles = dsNonProjectRoles.Tables[0];

                                        int rowCount = dtNonProjectRoles.Rows.Count;


                                        for (int i = 0; i < rowCount; i++)
                                        {
                                            if (dtNonProjectRoles.Columns.Contains("RoleID"))
                                            {


                                                if (dtNonProjectRoles.Rows[i]["RoleID"].ToString() == roleId.ToString())
                                                {
                                                    string roleName = dtNonProjectRoles.Rows[i]["RoleName"].ToString();
                                                    txtRoleName.Text = roleName;

                                                    string roleType = dtNonProjectRoles.Rows[i]["RoleType"].ToString();
                                                    BindRoleTypeComboBox(roleType);
                                                    //ddlRoleType.SelectedItem.Text = roleType;

                                                    string roleScope = dtNonProjectRoles.Rows[i]["RoleScope"].ToString();
                                                    BindRoleScopeComboBox(roleScope);
                                                    //ddlLevel.SelectedItem.Text = roleScope;

                                                    string scopeValue = dtNonProjectRoles.Rows[i]["ScopeValue"].ToString();
                                                    string level = ddlLevel.SelectedItem.Value;
                                                    //string selectedValue = 
                                                    BindScopeValue(level, scopeValue);

                                                    //lstRoleScope.SelectedItem.Text = scopeValue;

                                                    string projectGroup1 = dtNonProjectRoles.Rows[i]["ProjectGroup1"].ToString();
                                                    BindProjectGroup1(projectGroup1);
                                                    //ddlProjectGroup1.SelectedItem.Text = projectGroup1;

                                                    string projectGroup2 = dtNonProjectRoles.Rows[i]["ProjectGroup2"].ToString();
                                                    txtProjectGroup2.Text = projectGroup2;

                                                    string projectGroup3 = dtNonProjectRoles.Rows[i]["ProjectGroup3"].ToString();
                                                    txtProjectGroup3.Text = projectGroup3;

                                                    string accessType = dtNonProjectRoles.Rows[i]["AccessType"].ToString();
                                                    txtAccessType.Text = accessType;
                                                }
                                            }
                                        }



                                    }
                                    catch (SqlException ex)
                                    {
                                        var page = HttpContext.Current.CurrentHandler as Page;
                                        var master = page.Master;
                                        eObj.ErrorData(ex, page);
                                    }
                                    catch (FormatException ex)
                                    {
                                        var page = HttpContext.Current.CurrentHandler as Page;
                                        var master = page.Master;
                                        eObj.ErrorData(ex, page);
                                    }
                                    //catch (Exception)
                                    //{
                                    //    lblError.Text = "Some problem while accessing nonproject roles details";
                                    //}

                                }
                                catch (SqlException ex)
                                {
                                    var page = HttpContext.Current.CurrentHandler as Page;
                                    var master = page.Master;
                                    eObj.ErrorData(ex, page);
                                }
                                catch (FormatException ex)
                                {
                                    var page = HttpContext.Current.CurrentHandler as Page;
                                    var master = page.Master;
                                    eObj.ErrorData(ex, page);
                                }
                                //catch (Exception)
                                //{
                                //    lblError.Text = " Some problem while populating controls ";
                                //}
                            }
                        }
                    }
                }
            
            //catch (Exception)
            //{
            //    lblError.Text = " Some problem while deleting non project role ";
            //   }

        }
           
        #endregion dtgNonProjectRoles_ItemCommand


        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            selected_tab.Value = Request.Form[selected_tab.UniqueID];
            //if(selected_tab.Value=="1")
            //{
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "tabsTwo();", true);
            //}
          //  ScriptManager.RegisterStartupScript(this, this.GetType(), " ", "DisablePopUP();", true);
           
            RegisterToolBox();
           
            UA = (FlyCnDAL.Security.UserAuthendication)Session[Const.LoginSession];

            ToolBar.AddButton.Visible = true;
            ToolBar.EditButton.Visible = false;
            ToolBar.DeleteButton.Visible = false;
            ToolBar.UpdateButton.Visible = false;
            ToolBar.SaveButton.Visible = true;

            //if (lblError.Text != string.Empty)
            //{
            //    lblError.Text = string.Empty;
            //}

            if (!IsPostBack)
            {
                BindRoleTypeComboBox(null);
                BindRoleScopeComboBox(null);
                BindProjectGroup1(null);
                BindDropDownProjectNo();
                TabVisibility();
                //if (selected_tab.Value == "1")
                //{
                //    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "tabsTwo();", true);
                //}
            }

            else
            {
                ToolbarVisibility(hdnEditPostBack.Value);
            }

            //else
            //{

            ////  ---- Dropdown selection causes postback ----

            // if(hdnEditPostBack.Value == "True")
            // {
            //     ToolBar.UpdateButton.Visible = true;
            //     ToolBar.SaveButton.Visible = false;
            // }

            //}

           
        }

        #endregion Page Load

        #region  ToolBar_onClick
        protected void ToolBar_onClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            string functionName = e.Item.Value;


            if (functionName == "Save")
            {
                InsertRole();
                dtgNonProjectRoles.Rebind();
                ClearControls();

                //RegisterToolBox();
            }
            else
            {
                if (functionName == "Update")
                {
                    UpdateNonProjectRoleByRoleID();
                    dtgNonProjectRoles.Rebind();
                    ClearControls();

                    //RegisterToolBox();
                }
                else
                {
                    if (functionName == "Add")
                    {
                        ClearControls();

                        foreach (GridDataItem item in dtgNonProjectRoles.Items)
                        {
                            if (item.BackColor == System.Drawing.Color.LightPink)
                            {
                                item.BackColor = System.Drawing.Color.Transparent;
                            }
                        }
                    }
                }
            }
        }

        #endregion  ToolBar_onClick

        #endregion Events

        #region dtgManageExistingRoles_NeedDataSource
        protected void dtgManageExistingRoles_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (dtgManageExistingRoles.DataSource == null)
            {
                dtgManageExistingRoles.DataSource = new string[] { };
            }
        }
        #endregion dtgManageExistingRoles_NeedDataSource

        #region BindDropDownProjectNo
        public void BindDropDownProjectNo()
        {
            FlyCnDAL.ProjectParameters projectObj = new FlyCnDAL.ProjectParameters();
            DataTable dt = new DataTable();
            dt = projectObj.BindProjectNo();
            ddlProjectNo.DataSource = dt;
            ddlProjectNo.DataTextField = "ProjectNo";
            ddlProjectNo.DataBind();
        }
        #endregion BindDropDownProjectNo

        #region Toolbar visibility for project roles
        public void TabVisibility()
        {
            ToolBar1.UpdateButton.Visible = false;
            ToolBar1.DeleteButton.Visible = false;
            ToolBar1.AddButton.Visible = false;
            ToolBar1.SaveButton.Visible = true;
        }

        #endregion Toolbar visibility for project roles

        #region BindData
        public void BindData()
        {
            FlyCnDAL.ProjectParameters projObj = new FlyCnDAL.ProjectParameters();
            DataTable ds = new DataTable();
            string ProjNo = ddlProjectNo.SelectedValue;
            if (ProjNo != "--select Project No--")
            {
                ds = projObj.GetAllProjectRoles(ProjNo);
                dtgManageExistingRoles.DataSource = ds;
                try
                {
                    dtgManageExistingRoles.DataBind();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        #endregion BindData

        protected void ddlProjectNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
            txtCreateRoleName.Text = "";
            txtDescription.Text = "";
        }

        public void FillUser()
        {
             FlyCnDAL.ProjectParameters projObj = new FlyCnDAL.ProjectParameters();
            
            string ProjNo = ddlProjectNo.SelectedValue;
           
            projObj.RoleName = txtCreateRoleName.Text;
            projObj.Description = txtDescription.Text;
            projObj.InsertProjectRoles(ProjNo);
         
        }

        #region ToolBar_onClick
        protected void ToolBar1_onClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            string functionName = e.Item.Value;

            if (e.Item.Value == "Save")
            {
                FillUser();
               // dtgManageExistingRoles.Rebind();
                BindData();
            }
           
        }
        #endregion ToolBar_onClick

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

    }
}










