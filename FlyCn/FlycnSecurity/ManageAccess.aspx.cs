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

#endregion Included Namespaces

namespace FlyCn.FlycnSecurity
{

    public partial class ManageAccess : System.Web.UI.Page
    {
        #region Global Variables

        Security.UserAuthendication UA;

        #endregion Global Variables

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                Session["selectedAddID"] = null;
                Session["selectedIEditID"] = null;
                Session["selectedDeleteID"] = null;
                Session["selectedReadOnlyID"] = null;
                FlyCnSecurity.SecurityDAL.AccessManage AccsMng = new AccessManage();
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
            FlyCnSecurity.SecurityDAL.AccessManage AccsMng = new AccessManage();
            DataTable datatableobj = new DataTable();
            string RoleId = DropDownListObjReg.SelectedValue;


            RadGrid1.DataSource = AccsMng.ObjectRegistrationDetails(RoleId);


        }

        protected void RadGrid1_DetailTableDataBind(object source, Telerik.Web.UI.GridDetailTableDataBindEventArgs e)
        {
            FlyCnSecurity.SecurityDAL.AccessManage AccsMng = new AccessManage();
            GridDataItem dataItem = (GridDataItem)e.DetailTableView.ParentItem;
            string RoleId = DropDownListObjReg.SelectedValue;
            switch (e.DetailTableView.Name)
            {
                case "Child":
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
                CheckBox checkBoxAdd = (CheckBox)item.FindControl("ChkAdd");
             checkBoxAdd.Attributes.Add("onclick", "CheckChanged(this,"+"'"+checkBoxAdd.ID +"'"+ ",'" + item.ItemIndex + "');");
             CheckBox checkBoxEdit = (CheckBox)item.FindControl("ChkEdit");
             checkBoxEdit.Attributes.Add("onclick", "CheckChanged(this," + "'" + checkBoxEdit.ID + "'" + ",'" + item.ItemIndex + "');");
             CheckBox checkBoxDelete = (CheckBox)item.FindControl("ChkDelete");
             checkBoxDelete.Attributes.Add("onclick", "CheckChanged(this," + "'" + checkBoxDelete.ID + "'" + ",'" + item.ItemIndex + "');");
             CheckBox checkBoxReadOnly = (CheckBox)item.FindControl("ChkReadOnly");
             checkBoxReadOnly.Attributes.Add("onclick", "CheckChanged(this," + "'" + checkBoxReadOnly.ID + "'" + ",'" + item.ItemIndex + "');");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            FlyCnSecurity.SecurityDAL.AccessManage AccsMng = new AccessManage();

            RadGrid1.AllowPaging = false;
            foreach (GridDataItem item in RadGrid1.Items)
            {
                GridDataItem dataitem = (GridDataItem)item;
                //TableCell cell = dataitem["LevelID"];
                CheckBox checkBoxAddId = (CheckBox)item.FindControl("ChkAdd");
                CheckBox checkBoxEditId = (CheckBox)item.FindControl("ChkEdit");
                CheckBox checkBoxDeleteId = (CheckBox)item.FindControl("ChkDelete");
                CheckBox checkBoxReadOnlyId = (CheckBox)item.FindControl("ChkReadOnly");

                if ((checkBoxAddId != null && checkBoxAddId.Checked) || (checkBoxEditId != null && checkBoxEditId.Checked) || (checkBoxDeleteId != null && checkBoxDeleteId.Checked) || (checkBoxReadOnlyId != null && checkBoxReadOnlyId.Checked))
                {
                    AccsMng.LevelId= dataitem.GetDataKeyValue("LevelID").ToString(); //Access the checked row using DataKeyNames
                    AccsMng.ObjectId = dataitem.GetDataKeyValue("ObjId").ToString();
                   AccsMng.LevelDecription = dataitem.GetDataKeyValue("LevelDesc").ToString();
                   if (dataitem.GetDataKeyValue("Add") != DBNull.Value )
                   {
                       AccsMng.Add = Convert.ToBoolean(dataitem.GetDataKeyValue("Add")); //Access the checked row using DataKeyNames

                   }
                   if (dataitem.GetDataKeyValue("Edit") != DBNull.Value)
                   {
                       AccsMng.Edit = Convert.ToBoolean(dataitem.GetDataKeyValue("Edit"));
                   }
                   if (dataitem.GetDataKeyValue("Delete") != DBNull.Value)
                   {
                       AccsMng.Delete = Convert.ToBoolean(dataitem.GetDataKeyValue("Delete"));
                   }
                   if (dataitem.GetDataKeyValue("ReadOnly") != DBNull.Value)
                   {
                       AccsMng.ReadOnly = Convert.ToBoolean(dataitem.GetDataKeyValue("ReadOnly"));
                   }


                    


                }

            }
            RadGrid1.AllowPaging = true;
            RadGrid1.Rebind();



        }

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


            FlyCnSecurity.SecurityDAL.AccessManage AccsMng = new AccessManage();
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

        protected void btnSpecial_Click(object sender, EventArgs e)
        {

        }

      
      

        
    }
}