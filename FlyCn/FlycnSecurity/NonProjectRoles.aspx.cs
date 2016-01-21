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

#endregion  Included Namespaces 

namespace FlyCn.FlycnSecurity
{
    public partial class NonProjectRoles : System.Web.UI.Page
    {
       

        DALConstants cnst = new DALConstants();
        SecurityRoles DALObj = new SecurityRoles();
        FlyCnDAL.Security.UserAuthendication UA;

        String ScopeValueText = string.Empty; //seperated by commas 
        string RoleScopeText = string.Empty;


        #region Global Variables

        ErrorHandling eObj = new ErrorHandling();

        #endregion  Global Variables

        #region Methods

        #region Insert Role
      
        public void InsertRole()
        {
            string ScopeValue = string.Empty;
            try
            {
                if (txtRoleName.Text != string.Empty || ddlRoleType.SelectedItem.Text == "--Select--" || txtAccessType.Text != string.Empty)
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
                    DALObj.InsertNonProjectRoles();

                    ClearControls();


                }

                else
                {
                    lblError.Text = " Please fill the mandatory fields !";
                }
            }
            catch (Exception)
            {

                lblError.Text = " Some problem while inserting new non project access role";
            }
        }

        #endregion Insert Role

        #region Update Non Project Role

        public void UpdateNonProjectRoleByRoleID()
        {

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

            DALObj.UpdateNonProjectRolesByRoleID();

        }


        #endregion Update Non Project Role

        #region Clear Controls

        public void ClearControls()
        {
            //RoleName RoleType RoleScope ProjectGroup1 AccessType Created_By  Created_Date

            txtRoleName.Text = string.Empty;

            BindRoleTypeComboBox();

            BindRoleScopeComboBox();

            BindProjectGroup1();

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

        public void BindRoleTypeComboBox()
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

                ddlRoleType.Items.Insert(0, "--Select--");
            }
            catch (Exception)
            {

                lblError.Text = "Some problem while populating Role Type combo box !";
            }
        }

        #endregion Bind Role Type ComboBox

        #region Bind Role Scope ComboBox

        public void BindRoleScopeComboBox()
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

                ddlLevel.Items.Insert(0, "--Select--");
            }
            catch (Exception)
            {
                lblError.Text = "Some problem while populating Role Scope combo box !";

            }
        }
        #endregion Bind Role Scope ComboBox

        #region BindProjectGroup1

        public void BindProjectGroup1()
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

                ddlProjectGroup1.Items.Insert(0, "--Select--");
            }
            catch (Exception)
            {

                lblError.Text = "Some problem while populating project group1 combo box !";
            }
        }

        #endregion BindProjectGroup1

        #endregion Methods

        #region Role Type Selected Index Changed
        protected void ddlRoleType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion Role Type Selected Index Changed

        #region Level Selected Index Changed
        protected void ddlLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            string tableName = string.Empty;
            string level = string.Empty;
            DataSet dsRoles = null;

            level = ddlLevel.SelectedItem.Value;
            RoleScopeText = ddlLevel.SelectedItem.Text;

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
                    DALObj.TableName = tableName;

                    dsRoles = DALObj.GetAllRoleScope();
                    lstRoleScope.DataTextField = "Description";
                    lstRoleScope.DataValueField = "ID";
                    lstRoleScope.DataSource = dsRoles;

                    lstRoleScope.DataBind();

                    lstRoleScope.Items.Insert(0, "--Select--");
                }

            }
            catch (Exception)
            {

                lblError.Text = "Some problem while populating role scope combobox ";
            }



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

            try
            {
                GridDataItem item = e.Item as GridDataItem;
                if (item != null)
                {
                    string RoleID = item.GetDataKeyValue("RoleID").ToString();
                    ViewState["RoleID"] = RoleID;

                    if (e.CommandName == "Delete")
                    {
                        DALObj.RoleID = Convert.ToInt32(RoleID);
                        DALObj.DeleteNonProjectRoleByRoleID();
                    }


                    else
                    {

                        if (e.CommandName == "EditData")
                        {
                            hdnEditPostBack.Value = "True";
                           

                            try
                            {
                            string RoleName = item["RoleName"].Text;
                            txtRoleName.Text = RoleName;

                            string RoleType = item["RoleType"].Text;
                            ddlRoleType.SelectedItem.Text = RoleType;

                            string ProjectGroup2 = item["ProjectGroup2"].Text;
                            txtProjectGroup2.Text = ProjectGroup2;

                            string ProjectGroup3 = item["ProjectGroup3"].Text;
                            txtProjectGroup3.Text = ProjectGroup3;

                            string AccessType = item["AccessType"].Text;
                            txtAccessType.Text = AccessType;

                            string Created_By = item["Created_By"].Text;
                            //txtCreated_By.Text = Created_By;

                            string Created_Date = item["Created_Date"].Text;
                            //txtCreated_Date.Text = Created_Date;

                            //ddlRoleType.Items.FindByText(RoleType).Selected = true;
                            
                            }
                            catch (Exception)
                            {
                                lblError.Text = " Some problem while populating controls ";
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

                lblError.Text = " Some problem while deleting non project role ";
                lblError.Text = " Some problem while deleting non project role ";

            }

           

        }
            


          

        #endregion dtgNonProjectRoles_ItemCommand



        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            ToolBar.onClick += new RadToolBarEventHandler(ToolBar_onClick);
            ToolBar.OnClientButtonClicking = "OnClientButtonClicking";


            ToolBar.AddButton.Visible = false;
            ToolBar.EditButton.Visible = false;
            ToolBar.DeleteButton.Visible = false;
            ToolBar.UpdateButton.Visible = false;


            if (lblError.Text != string.Empty)
            {
                lblError.Text = string.Empty;
            }

            if (!IsPostBack)
            {
                BindRoleTypeComboBox();
                BindRoleScopeComboBox();
                BindProjectGroup1();

            }
           
            else
            {

            //  ---- Dropdown selection causes postback ----

             if(hdnEditPostBack.Value == "True")
             {
                 ToolBar.UpdateButton.Visible = true;
                 ToolBar.SaveButton.Visible = false;
             }

            }


        }

        #endregion Page Load



        #region  ToolBar_onClick
        protected void ToolBar_onClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            string functionName = e.Item.Value;

            if (functionName == "Save")
            {
                InsertRole();
            }
            else
            {
                if (functionName == "Update")
                {
                    UpdateNonProjectRoleByRoleID();
                }

            }
        }

        #endregion  ToolBar_onClick



        #endregion Events
    }
}










//#region Insert Button Click

///// <summary>
/////  To insert new non project role
///// </summary>
///// <param name="sender"></param>
///// <param name="e"></param>
//protected void btnInsert_Click(object sender, EventArgs e)
//{
//    string ScopeValue = string.Empty;
//    try
//    {
//        if (txtRoleName.Text != string.Empty || ddlRoleType.SelectedItem.Text == "--Select--" || txtAccessType.Text != string.Empty)
//        {
//            //if (txtProjectGroup1.Text != string.Empty || txtProjectGroup2.Text != string.Empty || txtProjectGroup3.Text != string.Empty || txtCreated_By.Text != string.Empty || txtCreated_Date.Text != string.Empty)
//            //{
//            //DALObj.RoleID = Convert.ToInt32(txtRoleID.Text);
//            DALObj.RoleName = txtRoleName.Text;
//            DALObj.RoleType = ddlRoleType.SelectedItem.Text;
//            //DALObj.RoleScope = Convert.ToInt32(ddlRoleScope.SelectedItem.Text);
//            //DALObj.ProjectGroup1 = txtProjectGroup1.Text;

//            DALObj.ProjectGroup1 = ddlProjectGroup1.SelectedItem.Text;
//            DALObj.ProjectGroup2 = txtProjectGroup2.Text;
//            DALObj.ProjectGroup3 = txtProjectGroup3.Text;
//            DALObj.AccessType = txtAccessType.Text;
//            DALObj.Created_By = txtCreated_By.Text;
//            DALObj.RoleScope = Convert.ToInt32(ddlLevel.SelectedItem.Value);

//            //DALObj.Created_Date = Convert.ToDateTime(txtCreated_Date.Text);

//            //}

//            for (int i = 1; i < lstRoleScope.Items.Count; i++)
//            {
//                if (lstRoleScope.Items[i].Selected)
//                {

//                    if (ScopeValue == string.Empty)
//                    {
//                        ScopeValue = lstRoleScope.Items[i].Value;
//                        ScopeValueText = lstRoleScope.Items[i].Text;

//                    }
//                    else
//                    {
//                        ScopeValue = ScopeValue + "," + lstRoleScope.Items[i].Value;
//                        ScopeValueText = ScopeValueText + "," + lstRoleScope.Items[i].Text;
//                    }

//                }
//            }



//            DALObj.ScopeValue = ScopeValue;
//            DALObj.InsertNonProjectRoles();

//            BindGridview();
//            ClearControls();


//        }

//        else
//        {
//            lblError.Text = " Please fill the mandatory fields !";
//        }
//    }
//    catch (Exception)
//    {

//        lblError.Text = " Some problem while inserting new non project access role";
//    }

//}

//#endregion Insert Button Click

//#region Update Button Click

//protected void btnUpdate_Click(object sender, EventArgs e)
//{

//}

//#endregion Update Button Click











//#region Delete Image Button Click
//protected void imgBtnDelete_Click(object sender, ImageClickEventArgs e)
//{
//    GridViewRow clickedRow = ((ImageButton)sender).NamingContainer as GridViewRow;
//    ImageButton imgBtnDelete = (ImageButton)clickedRow.FindControl("imgBtnDelete");



//    try
//    {
//        string selectedRow = clickedRow.Cells[1].Text;

//        DALObj.RoleID = Convert.ToInt32(selectedRow);
//        DALObj.DeleteNonProjectRoleByRoleID();

//        BindGridview();
//    }
//    catch (Exception)
//    {

//        lblError.Text = " Some problem while deleting non project role ";
//    }
//}

//#endregion Delete Image Button Click

//#region Update Image Button Click
//protected void imgBtnEdit_Click(object sender, ImageClickEventArgs e)
//{

//    string ScopeValue = string.Empty;
//    //RoleName RoleType RoleScope ProjectGroup1 AccessType Created_By  Created_Date

//    DALObj.RoleID = Convert.ToInt32(ViewState["RoleID"]);
//    DALObj.RoleName = txtRoleName.Text;
//    DALObj.RoleType = ddlRoleType.SelectedItem.Text;
//    DALObj.RoleScope = Convert.ToInt32(Convert.ToInt32(ddlLevel.SelectedItem.Value));

//    //DALObj.ProjectGroup1 = txtProjectGroup1.Text;
//    DALObj.ProjectGroup1 = ddlProjectGroup1.SelectedItem.Text;

//    DALObj.ProjectGroup2 = txtProjectGroup2.Text;
//    DALObj.ProjectGroup3 = txtProjectGroup3.Text;
//    DALObj.AccessType = txtAccessType.Text;
//    DALObj.Created_By = txtCreated_By.Text;

//    for (int i = 1; i < lstRoleScope.Items.Count; i++)
//    {
//        if (lstRoleScope.Items[i].Selected)
//        {

//            if (ScopeValue == string.Empty)
//            {
//                ScopeValue = lstRoleScope.Items[i].Value;
//                ScopeValueText = lstRoleScope.Items[i].Text;

//            }
//            else
//            {
//                ScopeValue = ScopeValue + "," + lstRoleScope.Items[i].Value;
//                ScopeValueText = ScopeValueText + "," + lstRoleScope.Items[i].Text;
//            }

//        }
//    }
//    //DALObj.Created_Date = Convert.ToDateTime(txtCreated_Date.Text);
//    DALObj.ScopeValue = ScopeValue;

//    DALObj.UpdateNonProjectRolesByRoleID();

//    BindGridview();

//    gvNonProjectRole.EditIndex = -1;
//    ClearControls();

//}

//#endregion Update Image Button Click

//protected void gvNonProjectRole_SelectedIndexChanged(object sender, EventArgs e)
//{

//}

