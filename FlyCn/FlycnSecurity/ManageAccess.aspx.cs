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

        #region Store CheckBox State

        public void  StoreCheckBoxState()
        {
            
        }

        #endregion  Store CheckBox State




        public void AddObjectAccessForRoles()
        {
             bool isBreak=false;
           
            try
            {
                RadGrid1.AllowPaging = false;
                foreach (GridDataItem item in RadGrid1.Items)
                {
                    DataSet dsFirstLevelObjects = ObjReg.GetAllObjectsWithParentIDNull();
                    
                    string RoleId = DropDownListObjReg.SelectedValue;
                    DataTable  dtObjectAccess = AccsMng.ObjectRegistrationDetails(RoleId);

                    GridDataItem dataitem = (GridDataItem)item;
                    //TableCell cell = dataitem["LevelID"];
                    CheckBox checkBoxAddId = (CheckBox)item.FindControl("ChkAdd");
                    CheckBox checkBoxEditId = (CheckBox)item.FindControl("ChkEdit");
                    CheckBox checkBoxDeleteId = (CheckBox)item.FindControl("ChkDelete");
                    CheckBox checkBoxReadOnlyId = (CheckBox)item.FindControl("ChkReadOnly");

                    //if ((checkBoxAddId != null && checkBoxAddId.Checked) || (checkBoxEditId != null && checkBoxEditId.Checked) || (checkBoxDeleteId != null && checkBoxDeleteId.Checked) || (checkBoxReadOnlyId != null && checkBoxReadOnlyId.Checked))
                    //{


                    //if (checkBoxAddId.Checked == true || checkBoxEditId.Checked == true || checkBoxDeleteId.Checked == true || checkBoxReadOnlyId.Checked == true)
                    //{

                    AccsMng.LevelId = dataitem.GetDataKeyValue("LevelID").ToString(); //Access the checked row using DataKeyNames
                    AccsMng.ObjectId = dataitem.GetDataKeyValue("ObjId").ToString();
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


                     if (dtObjectAccess.Rows.Count > 0)
                     {
                         foreach (DataRow dr in dtObjectAccess.Rows)
                         {
                             string objidWithAccess = dr["ObjId"].ToString();



                         }
                     }
















                    //    int result = AccsMng.AddObjectAccessForRoles();


                    //    if (result == 1)
                    //    {

                    //        lblError.Text = "Successfull";

                    //        eObj.InsertionSuccessData(this, Messages.InsertionSuccessfull);
                    //        RadGrid1.Rebind();

                    //    }

                    //}




                    //for (int i = 0; i < dsFirstLevelObjects.Tables[0].Rows.Count; i++)
                    //{
                    //    string firstLevelObjid = dsFirstLevelObjects.Tables[0].Rows[i]["ObjId"].ToString();

                    //    if (AccsMng.ObjectId == firstLevelObjid)
                    //    {
                    //        if (dtObjectAccess.Rows.Count > 0)
                    //        {
                    //            foreach (DataRow dr in dtObjectAccess.Rows)
                    //            {

                    //                string objidWithAccess = dr["ObjId"].ToString();


                    //                if (AccsMng.ObjectId == objidWithAccess)
                    //                {
                    //                    if ((dr["Add"].ToString() == "True") || (dr["Edit"].ToString() == "True") || (dr["Delete"].ToString() == "True") || (dr["ReadOnly"].ToString() == "True"))
                    //                    {
                    //                        AccsMng.ObjectId = dataitem.GetDataKeyValue("ObjId").ToString();
                    //                        AccsMng.RoleID = Convert.ToInt32(DropDownListObjReg.SelectedValue);

                    //                        int result = AccsMng.DeleteObjectAccessForRoleByObjIdAndRoleId();

                    //                        if (result == 1)
                    //                        {

                                                
                    //                            eObj.InsertionSuccessData(this, Messages.DeletionSuccessfull);
                    //                            RadGrid1.Rebind();
                    //                            lblError.Text = "Successfull delete";

                    //                        }

                    //                        isBreak = true;

                    //                        break;
                    //                    }


                    //                    else
                    //                    {
                    //                            int result = AccsMng.AddObjectAccessForRoles();


                    //                            if (result == 1)
                    //                            {

                    //                                eObj.InsertionSuccessData(this, Messages.InsertionSuccessfull);
                    //                                RadGrid1.Rebind();

                    //                                lblError.Text = "Successfull Add";

                    //                            }

                    //                        }

                    //                    }


                    //                }

                                  
                    //            }


                    //        if (isBreak)
                    //        {
                    //            break;
                    //        }
                    //        }
                    //    if (isBreak)
                    //    {
                    //        break;
                    //    }
                    //    }
                       
                    }

                    

                
                        ////Not the fist level

                        //                            else
                        //                            {
                        //                                if (dtObjectAccess.Rows.Count > 0)
                        //                                {
                        //                                    foreach (DataRow dr in dtObjectAccess.Rows)
                        //                                    {

                        //                                        string objidWithAccess = dr["ObjId"].ToString();


                        //                                        if (AccsMng.ObjectId == objidWithAccess)
                        //                                        {
                        //                                            if ((dr["Add"].ToString() == "True") || (dr["Edit"].ToString() == "True") || (dr["Delete"].ToString() == "True") || (dr["ReadOnly"].ToString() == "True"))
                        //                                            {
                        //                                                AccsMng.ObjectId = dataitem.GetDataKeyValue("ObjId").ToString();
                        //                                                AccsMng.RoleID = Convert.ToInt32(DropDownListObjReg.SelectedValue);

                        //                                                int result = AccsMng.DeleteObjectAccessForRoleByObjIdAndRoleId();

                        //                                                if (result == 1)
                        //                                                {

                        //                                                    lblError.Text = "Successfull delete";

                        //                                                    eObj.InsertionSuccessData(this, Messages.DeletionSuccessfull);
                        //                                                    RadGrid1.Rebind();

                        //                                                }
                        //                                                break;
                        //                                            }


                        //                                            else
                        //                                            {

                        //                                                AccsMng.Add = checkBoxAddId.Checked;
                        //                                                AccsMng.Edit = checkBoxEditId.Checked;
                        //                                                AccsMng.Delete = checkBoxDeleteId.Checked;
                        //                                                AccsMng.ReadOnly = checkBoxReadOnlyId.Checked;

                        //                                                AccsMng.RoleID = Convert.ToInt32(DropDownListObjReg.SelectedValue);
                        //                                                AccsMng.ProjectNo = UA.projectNo;
                        //                                                AccsMng.Created_By = UA.userName;





                        //                                                if (ViewState["Special-Permission"] != null)
                        //                                                {
                        //                                                    AccsMng.Property1 = ViewState["Special-Permission"].ToString();
                        //                                                }


                        //                                                int result = AccsMng.AddObjectAccessForRoles();


                        //                                                if (result == 1)
                        //                                                {

                        //                                                    lblError.Text = "Successfull";

                        //                                                    eObj.InsertionSuccessData(this, Messages.InsertionSuccessfull);
                        //                                                    RadGrid1.Rebind();

                        //                                                }
                        //                                            }



                        //                                        }



                        //                                    }
                        //                                }
                        //                            }
                        //                        }

                        //-------------------

                        //if(dtFirstlevelObjects.Rows.Count >0)
                        //{
                        //    foreach ( DataRow dr in dtFirstlevelObjects.Rows )
                        //    {
                        //        string objid = dr["ObjId"].ToString();

                        //        if (objid == AccsMng.ObjectId)
                        //        {

                        //            ViewState["Add"] = checkBoxAddId.Checked;
                        //           ViewState["Edit"]=  AccsMng.Edit = checkBoxEditId.Checked;
                        //           ViewState["Delete"] = checkBoxDeleteId.Checked;
                        //           ViewState["ReadOnly"] = checkBoxReadOnlyId.Checked;
                        //        }
                        //    }
                        //}



                        //--------------------



                        //if (dataitem.GetDataKeyValue("Add") != DBNull.Value )
                        //{

                        //AccsMng.Add = Convert.ToBoolean(dataitem.GetDataKeyValue("Add")); //Access the checked row using DataKeyNames

                        //AccsMng.Edit = Convert.ToBoolean(dataitem.GetDataKeyValue("Edit"));

                        //AccsMng.Delete = Convert.ToBoolean(dataitem.GetDataKeyValue("Delete"));

                        //AccsMng.ReadOnly = Convert.ToBoolean(dataitem.GetDataKeyValue("ReadOnly"));












                        //}




                        //else
                        //{


                        //string add = checkBoxAddId.Checked.ToString();
                        //string edit = checkBoxEditId.Checked.ToString();
                        //string dlt = checkBoxDeleteId.Checked.ToString();
                        //string rdonly = checkBoxReadOnlyId.Checked.ToString();

                        //string add1 = ViewState["Add"].ToString();
                        //string edit1 = ViewState["Edit"].ToString();
                        //string dlt1 = ViewState["Delete"].ToString();
                        //string rdonly1 = ViewState["ReadOnly"].ToString();

                        //    if (((add1 == "True") && (add == "False")) || ((edit1 == "True") && (edit == "False")) || (((dlt1 == "True") && (dlt == "False")) || ((rdonly1 == "True") && (rdonly == "False"))))
                        //    {
                        //        string d = ViewState["Add"].ToString();

                        //        AccsMng.ObjectId = dataitem.GetDataKeyValue("ObjId").ToString();
                        //        AccsMng.RoleID = Convert.ToInt32(DropDownListObjReg.SelectedValue);

                        //        int result = AccsMng.DeleteObjectAccessForRoleByObjIdAndRoleId();

                        //        if (result == 1)
                        //        {

                        //            lblError.Text = "Successfull update";

                        //            eObj.InsertionSuccessData(this, Messages.DeletionSuccessfull);
                        //            RadGrid1.Rebind();

                        //        }
                        //    }

                        //}


                   
               
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

        #endregion Methods
       

        #region  ToolBar_onClick
        protected void ToolBar_onClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            string functionName = e.Item.Value;

            
                if (functionName == "Save")
                {
                    AddObjectAccessForRoles();

                }

                //if (dtObjectAccess.Rows.Count > 0)
                //{
                //    foreach (DataRow dr in dtObjectAccess.Rows)
                //    {
                //        for (int i = 0; i < dsFirstLevelObjects.Tables[0].Rows.Count; i++)
                //        {

                //            string firstLevelObjid = dsFirstLevelObjects.Tables[0].Rows[i]["ObjId"].ToString();
                //            string objid = dr["ObjId"].ToString();

                //            if (firstLevelObjid == objid)
                //            {


                //                if (objid == AccsMng.ObjectId)
                //                {
                //                }
                //            }
                //        }
                //    }
                //}



            
        }

        #endregion  ToolBar_onClick

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

        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataTable datatableobj = new DataTable();
            string RoleId = DropDownListObjReg.SelectedValue;

            RadGrid1.DataSource = AccsMng.ObjectRegistrationDetails(RoleId);


        }

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

        #region Special Perssion Add Click

        protected void btnSpecial_Click(object sender, EventArgs e)
        {
            if (txtSpecial.Text != string.Empty)
            {
                ViewState["Special-Permission"] = txtSpecial.Text;
            }

        }

        #endregion Special Perssion Add Click

        #region Save Button Click

        /// <summary>
        /// To add or update object access for roles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
          
           

        }

        #endregion Save Button Click


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