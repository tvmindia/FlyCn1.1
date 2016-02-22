#region CopyRight

//All rights are reserved
//Created By   :
//Created Date : 
//Purpose      : 

//Modified BY   : SHAMILA T P
//Modified Date : Feb-12-2016
//Purpose       : To add save functionality 

#endregion CopyRight

#region Included Namespaces

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using FlyCnSecurity.SecurityDAL;
using FlyCn.FlyCnDAL;

using System.Data.SqlClient;
using Messages = FlyCn.UIClasses.Messages;

#endregion Included Namespaces

namespace FlyCn.FlycnSecurity
{

    public partial class ManageAccess : System.Web.UI.Page
    {
        #region Global Variables
       
        Security.UserAuthendication UA;
        UIClasses.Const c = new UIClasses.Const();
        FlyCnSecurity.SecurityDAL.AccessManage AccsMng = new AccessManage();
        FlyCnSecurity.SecurityDAL.SecurityObjects ObjReg = new SecurityObjects();
        ErrorHandling eObj = new ErrorHandling();

         #endregion Global Variables

        #region Methods

        #region Add Object Access For Roles
        
        /// <summary>
        /// Function insert object if it is new , it updates if object already there and deletes all checkboxes are null
        /// </summary>
        public void AddObjectAccessForRoles()
        {
            try
            {
                RadGrid1.AllowPaging = false;

//--------------* loop through each item of gridview *------------//

             foreach (GridDataItem item in RadGrid1.Items)
              {
                    string RoleId = DropDownListObjReg.SelectedValue;
                    //DataTable  dtObjectAccess = AccsMng.ObjectRegistrationDetails(RoleId);

                    DataTable dtObjectAccess = AccsMng.GetAlldetailsOfObjectAccess(RoleId); // Objects having already access
                    GridDataItem dataitem = (GridDataItem)item;
                   
                    CheckBox checkBoxAddId = (CheckBox)item.FindControl("ChkAdd");
                    CheckBox checkBoxEditId = (CheckBox)item.FindControl("ChkEdit");
                    CheckBox checkBoxDeleteId = (CheckBox)item.FindControl("ChkDelete");
                    CheckBox checkBoxReadOnlyId = (CheckBox)item.FindControl("ChkReadOnly");

                    AccsMng.ObjectId = dataitem.GetDataKeyValue("ObjId").ToString();
                    AccsMng.LevelId = dataitem.GetDataKeyValue("LevelID").ToString(); //Access the checked row using DataKeyNames

                    DataRow[] foundRow = dtObjectAccess.Select("Objid = " + AccsMng.ObjectId);

                 if (foundRow.Length == 0) // checks whether object already having access
                 { 
                    
                    if (checkBoxAddId.Checked == true || checkBoxEditId.Checked == true || checkBoxDeleteId.Checked == true || checkBoxReadOnlyId.Checked == true)
                    {
 //------------*Insert the object*-------------//   
       
                        AccsMng.LevelDecription = dataitem.GetDataKeyValue("LevelDesc").ToString();

                        AccsMng.Add = checkBoxAddId.Checked;
                        AccsMng.Edit = checkBoxEditId.Checked;
                        AccsMng.Delete = checkBoxDeleteId.Checked;
                        AccsMng.ReadOnly = checkBoxReadOnlyId.Checked;

                        AccsMng.RoleID = Convert.ToInt32(DropDownListObjReg.SelectedValue);
                        AccsMng.ProjectNo = UA.projectNo;
                        AccsMng.Created_By = UA.userName;


                        if (ViewState["Special-Permission"] != null)
                        {
                            AccsMng.Property1 = ViewState["Special-Permission"].ToString();
                        }


                        int result = AccsMng.AddObjectAccessForRoles();

                        if (result == 1)
                        {
                            eObj.InsertionSuccessData(this, Messages.InsertionSuccessfull);
                            //RadGrid1.Rebind();

                        }
                    }
                }
                    else
                    {

                        DataRow drAccess = foundRow[0];

                    
                        bool drAdd = Convert.ToBoolean(drAccess["Add"]);
                        bool drEdit = Convert.ToBoolean(drAccess["Edit"]);
                        bool drDelete = Convert.ToBoolean(drAccess["Delete"]);
                        bool drRead = Convert.ToBoolean(drAccess["ReadOnly"]);

                        if ((checkBoxAddId.Checked != drAdd) || (checkBoxEditId.Checked != drEdit) || (checkBoxDeleteId.Checked != drDelete) || (checkBoxReadOnlyId.Checked != drRead))
                       
                        {
                            if( (checkBoxAddId.Checked == false) && (checkBoxEditId.Checked == false) && (checkBoxDeleteId.Checked == false) && (checkBoxReadOnlyId.Checked == false )  )
                            {
//------------*Delete the object if all checkbox unticked*-------------//   
                            AccsMng.ObjectId = dataitem.GetDataKeyValue("ObjId").ToString();
                            AccsMng.RoleID = Convert.ToInt32(DropDownListObjReg.SelectedValue);

                            int result = AccsMng.DeleteObjectAccessForRoleByObjIdAndRoleId();

                             if (result == 1)
                                {
                                lblError.Text = "Successfull delete";
                                eObj.InsertionSuccessData(this, Messages.DeletionSuccessfull);
                                //RadGrid1.Rebind();
                                }
                            }
                            else
                            {
                                AccsMng.ObjectId = dataitem.GetDataKeyValue("ObjId").ToString();
                                AccsMng.RoleID = Convert.ToInt32(DropDownListObjReg.SelectedValue);
                                AccsMng.Add = checkBoxAddId.Checked;
                                AccsMng.Edit = checkBoxEditId.Checked;
                                AccsMng.Delete = checkBoxDeleteId.Checked;
                                AccsMng.ReadOnly = checkBoxReadOnlyId.Checked;
                                AccsMng.ProjectNo = UA.projectNo;
                                AccsMng.Created_By = UA.userName;


                                if (ViewState["Special-Permission"] != null)
                                {
                                    AccsMng.Property1 = ViewState["Special-Permission"].ToString();
                                }

                                int result = AccsMng.UpdateObjectAccessByRoleIDAndObjID();

                              if (result == 1)
                                {
                                lblError.Text = "Successfull delete";
                                eObj.InsertionSuccessData(this, Messages.DeletionSuccessfull);
                                //RadGrid1.Rebind();
                                }

                            }
                        }
                 
                    }
                    
                 }
 
                RadGrid1.AllowPaging = true;
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

        #endregion Add Object Access For Roles

        #endregion Methods

        #region Events

        #region  ToolBar_onClick
        protected void ToolBar_onClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            string functionName = e.Item.Value;
            
            if (functionName == "Save")
                {
                    AddObjectAccessForRoles();

                }
        }

        #endregion  ToolBar_onClick

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
           
            UA = (FlyCnDAL.Security.UserAuthendication)Session[c.LoginSession];

            ToolBar.onClick += new RadToolBarEventHandler(ToolBar_onClick);

            if (!IsPostBack)
            {
                Session["selectedAddID"] = null;
                Session["selectedIEditID"] = null;
                Session["selectedDeleteID"] = null;
                Session["selectedReadOnlyID"] = null;
                
                DataTable datatableobj = new DataTable();
                DataTable datatbl = new DataTable();
                datatbl = AccsMng.GetObjRegComboBoxData();
                DropDownListObjReg.DataSource = datatbl;

                DropDownListObjReg.DataTextField = "RoleName";
                DropDownListObjReg.DataValueField = "RoleID";
                DropDownListObjReg.DataBind();
            }


        }
        #endregion Page Load

        #region Need Data Source For RadGrid
        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataTable datatableobj = new DataTable();
            string RoleId = DropDownListObjReg.SelectedValue;

            RadGrid1.DataSource = AccsMng.ObjectRegistrationDetails(RoleId);
       }

        #endregion Need Data Source For RadGrid

        #region Detail Table DataBind Of RadGrrid
        protected void RadGrid1_DetailTableDataBind(object source, Telerik.Web.UI.GridDetailTableDataBindEventArgs e)
        {
            GridDataItem dataItem = (GridDataItem)e.DetailTableView.ParentItem;
            string RoleId = DropDownListObjReg.SelectedValue;
            switch (e.DetailTableView.Name)
            {
                case  "Child" :
                    {
                        string LevelID = dataItem.GetDataKeyValue("LevelID").ToString();
                        e.DetailTableView.DataSource = AccsMng.ObjectRegistrationDetailsBYLevelId(LevelID, RoleId);
                        break;
                    }
                 
            }
        }
        #endregion Detail Table DataBind  Of RadGrrid

        #region Item Created Of RadGrid
        protected void RadGrid1_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                //string ObjId = item.GetDataKeyValue("ObjId").ToString();

                CheckBox checkBoxAdd = (CheckBox)item.FindControl("ChkAdd");
                string ownertbl = e.Item.OwnerTableView.Name;
             checkBoxAdd.Attributes.Add("onclick", "CheckChanged(this,"+"'"+checkBoxAdd.ID +"'"+ ",'" + item.ItemIndex+ "','" + ownertbl + "');");
             CheckBox checkBoxEdit = (CheckBox)item.FindControl("ChkEdit");
             checkBoxEdit.Attributes.Add("onclick", "CheckChanged(this," + "'" + checkBoxEdit.ID + "'" + ",'" + item.ItemIndex + "','" + ownertbl + "');");
             CheckBox checkBoxDelete = (CheckBox)item.FindControl("ChkDelete");
             checkBoxDelete.Attributes.Add("onclick", "CheckChanged(this," + "'" + checkBoxDelete.ID + "'" + ",'" + item.ItemIndex + "','" + ownertbl + "');");
             CheckBox checkBoxReadOnly = (CheckBox)item.FindControl("ChkReadOnly");
             checkBoxReadOnly.Attributes.Add("onclick", "CheckChanged(this," + "'" + checkBoxReadOnly.ID + "'" + ",'" + item.ItemIndex + "','" + ownertbl + "');");

            
            }

        }

        #endregion Item Created Of RadGrid

        #region Special Perssion Add Click
        /// <summary>
        /// Event stores special permission and is used in case of insert and update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSpecial_Click(object sender, EventArgs e)
        {
            if (txtSpecial.Text != string.Empty)
            {
                ViewState["Special-Permission"] = txtSpecial.Text;
            }

        }

        #endregion Special Perssion Add Click

        #endregion Events

//Not using now   
        protected void RadGrid1_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            //     RememberSelected();

        }

        protected void RadGrid1_PreRender(object sender, EventArgs e)
        {

            // CheckBoxStatePreserving();
        }
        public void CheckBoxStatePreserving()
        {
            string strAddIds = ",";
            string strEditIds = ",";
            string strDeleteIds = ",";
            string strReadOnlyIds = ",";
            if (Session["selectedAddID"] != null)
            {
                strAddIds = Convert.ToString(Session["selectedAddID"]);
            }
            if (Session["selectedIEditID"] != null)
            {
                strEditIds = Convert.ToString(Session["selectedIEditID"]);
            }
            if (Session["selectedDeleteID"] != null)
            {
                strDeleteIds = Convert.ToString(Session["selectedDeleteID"]);
            }
            if (Session["selectedReadOnlyID"] != null)
            {
                strReadOnlyIds = Convert.ToString(Session["selectedReadOnlyID"]);
            }
            foreach (GridDataItem item in RadGrid1.Items)
            {
                CheckBox checkColumnAdd = item["Add"].Controls[0] as CheckBox;
                CheckBox checkColumnEdit = item["Edit"].Controls[0] as CheckBox;
                CheckBox checkColumnDelete = item["Delete"].Controls[0] as CheckBox;
                CheckBox checkColumnReadOnly = item["ReadOnly"].Controls[0] as CheckBox;
                string Id = item.GetDataKeyValue("ObjId").ToString();

                if (checkColumnAdd != null)
                {
                    if (strAddIds.IndexOf("," + Id.ToString() + ",") >= 0)
                    {
                        checkColumnAdd.Checked = true;
                    }
                    else if (checkColumnAdd.Checked == true)
                    {
                        checkColumnAdd.Checked = true;
                    }
                    else
                    {
                        checkColumnAdd.Checked = false;
                    }
                }
                if (checkColumnEdit != null)
                {
                    if (strEditIds.IndexOf("," + Id.ToString() + ",") >= 0)
                    {
                        checkColumnEdit.Checked = true;
                    }
                    else if (checkColumnEdit.Checked == true)
                    {
                        checkColumnEdit.Checked = true;
                    }
                    else
                    {
                        checkColumnEdit.Checked = false;
                    }
                }

                if (checkColumnDelete != null)
                {
                    if (strDeleteIds.IndexOf("," + Id.ToString() + ",") >= 0)
                    {
                        checkColumnDelete.Checked = true;
                    }
                    else if (checkColumnDelete.Checked == true)
                    {
                        checkColumnDelete.Checked = true;
                    }
                    else
                    {
                        checkColumnDelete.Checked = false;
                    }
                }
                if (checkColumnReadOnly != null)
                {
                    if (strReadOnlyIds.IndexOf("," + Id.ToString() + ",") >= 0)
                    {
                        checkColumnReadOnly.Checked = true;
                    }
                    else if (checkColumnReadOnly.Checked == true)
                    {
                        checkColumnReadOnly.Checked = true;
                    }
                    else
                    {
                        checkColumnReadOnly.Checked = false;
                    }
                }
            }
        }
        private void RememberSelected()
        {
            string strAddIds = ",";
            string strEditIds = ",";
            string strDeleteIds = ",";
            string strReadOnlyIds = ",";

            if (Session["selectedAddID"] != null)
            {
                strAddIds = Convert.ToString(Session["selectedAddID"]);
            }
            if (Session["selectedIEditID"] != null)
            {
                strEditIds = Convert.ToString(Session["selectedIEditID"]);
            }
            if (Session["selectedDeleteID"] != null)
            {
                strDeleteIds = Convert.ToString(Session["selectedDeleteID"]);
            }
            if (Session["selectedReadOnlyID"] != null)
            {
                strReadOnlyIds = Convert.ToString(Session["selectedReadOnlyID"]);
            }
            foreach (GridDataItem item in RadGrid1.Items)
            {
                CheckBox checkColumnAdd = item["Add"].Controls[0] as CheckBox;
                CheckBox checkColumnEdit = item["Edit"].Controls[0] as CheckBox;
                CheckBox checkColumnDelete = item["Delete"].Controls[0] as CheckBox;
                CheckBox checkColumnReadOnly = item["ReadOnly"].Controls[0] as CheckBox;
                string Id = item.GetDataKeyValue("ObjId").ToString();

                if (checkColumnAdd != null && checkColumnAdd.Checked)
                {
                    strAddIds += Id + ",";
                }
                else
                {
                    strAddIds = strAddIds.Replace("," + Id + ",", ",");
                }
                if (checkColumnEdit != null && checkColumnEdit.Checked)
                {
                    strEditIds += Id + ",";
                }
                else
                {
                    strEditIds = strEditIds.Replace("," + Id + ",", ",");
                }

                if (checkColumnDelete != null && checkColumnDelete.Checked)
                {
                    strDeleteIds += Id + ",";
                }
                else
                {
                    strDeleteIds = strDeleteIds.Replace("," + Id + ",", ",");
                }
                if (checkColumnReadOnly != null && checkColumnReadOnly.Checked)
                {
                    strReadOnlyIds += Id + ",";
                }
                else
                {
                    strReadOnlyIds = strReadOnlyIds.Replace("," + Id + ",", ",");
                }
            }

            Session["selectedAddID"] = strAddIds;
            Session["selectedIEditID"] = strEditIds;
            Session["selectedDeleteID"] = strDeleteIds;
            Session["selectedReadOnlyID"] = strReadOnlyIds;
        }

        protected void DropDownListObjReg_SelectedIndexChanged(object sender, EventArgs e)
        {
            string RoleId = DropDownListObjReg.SelectedValue;

            RadGrid1.DataSource = AccsMng.ObjectRegistrationDetails(RoleId);
            RadGrid1.DataBind();
            foreach (GridDataItem item in RadGrid1.Items)
            {
                // Parent item
                // Access current row column
                switch (item.OwnerTableView.Name)
                {
                    case "Child":
                        {
                            string LevelID = item.GetDataKeyValue("LevelID").ToString();
                            item.OwnerTableView.DataSource = AccsMng.ObjectRegistrationDetailsBYLevelId(LevelID, RoleId);
                            break;
                        }

                }

            }


        }

        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {

            //if (e.Item is GridEditableItem && e.Item.OwnerTableView.IsItemInserted && e.Item.OwnerTableView.Name == "Child")
            //{
            //    GridEditableItem insertItem = e.Item as GridEditableItem;
            //    CheckBox child = (CheckBox)insertItem["Add"].Controls[0]; // accessing the child GridCheckboxColumn
            //    GridDataItem parentItem = e.Item.OwnerTableView.ParentItem;
            //    CheckBox parent = (CheckBox)parentItem["Add"].Controls[0]; //accessing the parent GridCheckboxColumn
            //    if (parent.Checked == true)
            //    {
            //        child.Checked = true;
            //    }
            //}
        }

    }
}