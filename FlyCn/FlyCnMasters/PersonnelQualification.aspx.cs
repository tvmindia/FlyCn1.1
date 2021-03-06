﻿using FlyCn.FlyCnDAL;
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
    public partial class PersonnelQualification : System.Web.UI.Page
    {
        TabAddEditSettings tabs = new TabAddEditSettings();
        ErrorHandling eObj = new ErrorHandling();
        UIClasses.Const Const = new UIClasses.Const();
        FlyCnDAL.Security.UserAuthendication UA;
        FlyCnDAL.MasterPersonnelQualification personnelqualificationobj = new FlyCnDAL.MasterPersonnelQualification();
        DataTable dtable = new DataTable();
        string _id1;


        #region  Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            UA = (FlyCnDAL.Security.UserAuthendication)Session[Const.LoginSession];

            _id1 = Request.QueryString["id"];

            //txtEmpCode.Text = _id1;
            HiddenField.Value = _id1;

            ToolBarQualification.onClick += new RadToolBarEventHandler(ToolBar_onClick);
            ToolBarQualification.OnClientButtonClicking = "OnClientButtonClicking";
        }

        #endregion  Page_Load

        #region  ToolBar_onClick
        protected void ToolBar_onClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            string functionName = e.Item.Value;
            if (functionName == "Save")
            {


                InsertData();
            }
            else if (functionName == "Update")
            {
               
                UpdateData();
            }
            else if (functionName == "Delete")
            {
                string code = HiddenField.Value;
                string qualification = txtQualification.Text;
                string ProjNo = UA.projectNo;
                int result = personnelqualificationobj.DeleteMasterPersonnelQualificationData(code, qualification, ProjNo);
                if (result == 1)
                {
                    dtgPersonnelQualificationGrid.Rebind();
                    RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("1");
                    RadTab tab1 = (RadTab)RadTabStrip1.FindTabByValue("2");
                    TabAddEditSettings tabs = new TabAddEditSettings();
                    tabs.Addtab(tab, tab1);
                    RadMultiPage1.SelectedIndex = 0;

                }
            }
            //msg.Text = e.Item.Value + " clicked !";
        }

        #endregion  ToolBar_onClick

        #region  dtgPersonnelQualificationGrid_NeedDataSource
        protected void dtgPersonnelQualificationGrid_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataTable datatableobj = new DataTable();
            datatableobj = personnelqualificationobj.BindMastersPersonalQualification(_id1);
            dtgPersonnelQualificationGrid.DataSource = datatableobj;

        }

        #endregion  dtgPersonnelQualificationGrid_NeedDataSource

        #region  InsertData
        public void InsertData()
        {
            try
            {
                string val = null;
              
                personnelqualificationobj.EmpCode = _id1;
                personnelqualificationobj.Qualification = txtQualification.Text;
                personnelqualificationobj.QualificationType = txtQualificationType.Text;
                if (RadFirstQualifiedDate.SelectedDate != null)
                {
                    personnelqualificationobj.FirstQualifiedDate = Convert.ToString(RadFirstQualifiedDate.SelectedDate);
                }
                if (RadExpiryDate.SelectedDate != null)
                {
                    personnelqualificationobj.ExpiryDate = Convert.ToString(RadExpiryDate.SelectedDate);
                }

                if (RadDRenewedDate.SelectedDate != null)
                {
                    personnelqualificationobj.RenewedDate = Convert.ToString(RadDRenewedDate.SelectedDate);
                }
                personnelqualificationobj.Remarks = txtRemarks.Text;

                personnelqualificationobj.Updated_By = UA.userName;

                string ProjNo = UA.projectNo;
                int result = personnelqualificationobj.InsertMasterPersonalQualificationData(ProjNo);
                dtgPersonnelQualificationGrid.Rebind();

                RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("1");
                RadTab tab1 = (RadTab)RadTabStrip1.FindTabByValue("2");
                tabs.ResetTabCaptions(tab, tab1);
                //tab.Selected = true;
                RadMultiPage1.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("1");
                RadTab tab1 = (RadTab)RadTabStrip1.FindTabByValue("2");
                // TabAddEditSettings tabs = new TabAddEditSettings();
                tabs.ResetTabCaptions(tab, tab1);
                RadMultiPage1.SelectedIndex = 0;
                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.ErrorData(ex, page);

            }

        }

        #endregion  InsertData

        #region  dtgPersonnelQualificationGrid_ItemCommand
        protected void dtgPersonnelQualificationGrid_ItemCommand(object source, GridCommandEventArgs e)
        {
            string projectNo = UA.projectNo;



            GridDataItem item = e.Item as GridDataItem;
            string strId = item.GetDataKeyValue("EmpCode").ToString();
            string Qualification = item.GetDataKeyValue("Qualification").ToString();
            if (e.CommandName == "Delete")
            {


                int result = personnelqualificationobj.DeleteMasterPersonnelQualificationData(strId, Qualification, projectNo);
                if (result == 1)
                {

                }


            }
            else if (e.CommandName == "EditData")
            {
                txtQualification.ReadOnly = true;

                TabAddEditSettings tabs = new TabAddEditSettings();
                RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("2");
                tabs.EditTab(tab);
                RadMultiPage1.SelectedIndex = 1;

                ToolBarQualification.AddButton.Visible = false;
                ToolBarQualification.SaveButton.Visible = false;
                ToolBarQualification.UpdateButton.Visible = true;
                ToolBarQualification.DeleteButton.Visible = true;

                dtable = personnelqualificationobj.FillMasterData(strId, Qualification, projectNo);
                txtEmpCode.Text = dtable.Rows[0]["EmpCode"].ToString();
                txtQualification.Text = dtable.Rows[0]["Qualification"].ToString();
                txtQualificationType.Text = dtable.Rows[0]["QualificationType"].ToString();
                string FirstQualifiedDate = dtable.Rows[0]["FirstQualifiedDate"].ToString();
                if (FirstQualifiedDate != "")
                {
                    RadFirstQualifiedDate.SelectedDate = Convert.ToDateTime(FirstQualifiedDate);
                }
               
                //RadFirstQualifiedDate.SelectedDate = null;

                string ExpiryDate = dtable.Rows[0]["ExpiryDate"].ToString();

                if (ExpiryDate != "")
                {
                    RadExpiryDate.SelectedDate = Convert.ToDateTime(ExpiryDate);

                }

                //RadExpiryDate.SelectedDate = null;

                string RenewedDate = dtable.Rows[0]["RenewedDate"].ToString();

                if (RenewedDate != "")
                {
                    RadDRenewedDate.SelectedDate = Convert.ToDateTime(RenewedDate);
                }
                txtRemarks.Text = dtable.Rows[0]["Remarks"].ToString(); ;

                //   ScriptManager.RegisterStartupScript(this, GetType(), "EditData", "UpdateFunction();", true);


            }
        }

        #endregion  dtgPersonnelQualificationGrid_ItemCommand

        #region  UpdateData

        public void UpdateData()
        {
            string val = null;
            personnelqualificationobj.EmpCode = HiddenField.Value;
            personnelqualificationobj.Qualification = txtQualification.Text;
            personnelqualificationobj.QualificationType = txtQualificationType.Text;
            personnelqualificationobj.Remarks = txtRemarks.Text;

            //personnelqualificationobj.Updated_By = txtUpdatedBy.Text;

            if (RadFirstQualifiedDate.SelectedDate != null)
            {
                personnelqualificationobj.FirstQualifiedDate = Convert.ToString(RadFirstQualifiedDate.SelectedDate);
            }
            if (RadExpiryDate.SelectedDate != null)
            {
                personnelqualificationobj.ExpiryDate = Convert.ToString(RadExpiryDate.SelectedDate);
            }
            if (RadDRenewedDate.SelectedDate != null)
            {
                personnelqualificationobj.RenewedDate = Convert.ToString(RadDRenewedDate.SelectedDate);
            }

            personnelqualificationobj.Updated_By = UA.userName;
            string ProjNo = UA.projectNo;
            int result = personnelqualificationobj.UpdateMasterPersonelQualificationData(ProjNo);
        
        }

        #endregion  UpdateData

        #region  dtgPersonnelQualificationGrid_PreRender1

        protected void dtgPersonnelQualificationGrid_PreRender1(object sender, EventArgs e)
        {
            dtgPersonnelQualificationGrid.MasterTableView.GetColumn("EmpCode").Visible = false;
            //gvCktMap.MasterTableView.GetColumn("sid").Visible = false;  
            dtgPersonnelQualificationGrid.Rebind();
        }

        #endregion  dtgPersonnelQualificationGrid_PreRender1

    }

}