using FlyCn.FlyCnDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace FlyCn.FlycnSecurity
{
    public partial class ModuleActivities : System.Web.UI.Page
    {
        FlyCn.FlyCnDAL.Users userObj = new FlyCn.FlyCnDAL.Users();
        ErrorHandling eObj = new ErrorHandling();
        protected void Page_Load(object sender, EventArgs e)
        {
            SecurityCheck();
            if(!IsPostBack)
            {
                BindDropDownActivityProjectNo();
                BindDropDownCreateNewProjectNo();
            }
            RegisterToolBox();
            ToolBar.AddButton.Visible = false;
            ToolBar.EditButton.Visible = false;
            ToolBar.DeleteButton.Visible = true;
            ToolBar.UpdateButton.Visible = false;
            ToolBar.SaveButton.Visible = false;

            ToolBar1.AddButton.Visible = false;
            ToolBar1.EditButton.Visible = false;
            ToolBar1.DeleteButton.Visible = false;
            ToolBar1.UpdateButton.Visible = false;
            ToolBar1.SaveButton.Visible = true;
        }

        #region Register ToolBox

        public void RegisterToolBox()
        {
            ToolBar.onClick += new RadToolBarEventHandler(ToolBar_onClick);
            ToolBar.OnClientButtonClicking = "OnClientButtonClickingDetail";

            ToolBar1.onClick += new RadToolBarEventHandler(ToolBar1_onClick);
            ToolBar1.OnClientButtonClicking = "OnClientButtonClicking";
        }
        #endregion Register ToolBox

        protected void ToolBar_onClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            string project = ddlProjects.SelectedItem.Text;
            string module = ddlModule.SelectedItem.Value;
            string functionName = e.Item.Value;
            if(e.Item.Value=="Delete")
            {
                foreach (GridDataItem item in dtgManageActivities.Items)
                {

                    CheckBox checkColumnAdd = item["Modulescheck"].Controls[0] as CheckBox;
                    if (checkColumnAdd.Checked == true)
                    {
                        string fullDesc = item.GetDataKeyValue("FullDesc").ToString();
                       userObj.DeleteModuleActivities(project, module, fullDesc);
                        dtgManageActivities.Rebind();

                    }
                }
            }
           
        }

        protected void ToolBar1_onClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            string functionName = e.Item.Value;
            if (e.Item.Value == "Save")
            {
                FillActivities();
                dtgManageActivities.Rebind();
            }
        }

        protected void dtgManageActivities_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            DataTable dt = new DataTable();
            FlyCnDAL.Users userObj = new FlyCnDAL.Users();
            string module = ddlModule.SelectedValue;
            string project = ddlProjects.SelectedItem.Text;
            if (module != "--select module--")
            {
                dt = userObj.GetAllModuleActivities(project,module);
                dtgManageActivities.DataSource = dt;

            }
            if (dtgManageActivities.DataSource == null)
            {
                dtgManageActivities.DataSource = new string[] { };
            }
        }

        #region SecurityCheck
        public void SecurityCheck()
        {
            string logicalObject = "ModuleActivities";

            FlyCnDAL.Security.PageSecurity PS = new Security.PageSecurity(logicalObject, this);

            if (PS.isWrite == true)
            {
                dtgManageActivities.MasterTableView.GetColumn("Modulescheck").Display = false;
                ToolBar.Visible = false;
                ToolBar1.Visible = true;
                tabs2.Visible = true;
            }
            else
             if (PS.isEdit == true)
                {
                    dtgManageActivities.MasterTableView.GetColumn("Modulescheck").Display = false;
                    ToolBar.Visible = false;
                    ToolBar1.Visible = true;
                    tabs2.Visible = true;
                }
                 if (PS.isAdd == true)
                {
                    dtgManageActivities.MasterTableView.GetColumn("Modulescheck").Display = false;
                    ToolBar.Visible = false;
                    ToolBar1.Visible = true;
                    tabs2.Visible = true;
                }
                 if (PS.isRead == true)
                {
                    dtgManageActivities.MasterTableView.GetColumn("Modulescheck").Display = false;
                    ToolBar.Visible= false;
                    ToolBar1.Visible = false;
                    tabs2.Visible = false;
                }

                if (PS.isDenied == true)
                {
                    HttpContext.Current.Response.Redirect("~/General/UnderConstruction.aspx?cause=accessdenied", true);
                }
            if (PS.isDelete == true)
            {
                dtgManageActivities.MasterTableView.GetColumn("Modulescheck").Display = true;
                ToolBar.Visible = true;
                //ToolBar1.Visible = false;
                //tabs2.Visible = false;
            }

        }
        #endregion SecurityCheck


        #region FillActivities
        public void FillActivities()
        {
            userObj.fullDesc = txtFullDesc.Text;
            userObj.shortDesc = txtShortDesc.Text;
            if(chkIsFailApplicable.Checked==true)
            {
                userObj.failApplicable = true;
            }
            else
            {
                userObj.failApplicable = false;
            }
            userObj.startDateCaption = txtActualStartDateCaption.Text;
            userObj.statusCaption = txtStatusCaption.Text;
            userObj.completeDateCaption = txtActualCompleteDateCaption.Text;
            if(chkPlannedStartDate.Checked==true)
            {
                userObj.plannedStartDate = true;
            }
            else
            {
                userObj.plannedStartDate = false;
            }
            if(chkPlannedCmpltDate.Checked==true)
            {
                userObj.plannedCompleteDate = true;
            }
            else
            {
                userObj.plannedCompleteDate = false;
            }
            if(chkForeCastStartDate.Checked==true)
            {
                userObj.forecastStartDate = true;
            }
            else
            {
                userObj.forecastStartDate = false;
            }
            if(chkForeCastEndDate.Checked==true)
            {
                userObj.forecastEndDate = true;
            }
            else
            {
                userObj.forecastEndDate = false;
            }
            if(chkActualStartDate.Checked==true)
            {
                userObj.ActualStartDate = true;
            }
            else
            {
                userObj.ActualStartDate = false;
            }
            if(chkStatus.Checked==true)
            {
                userObj.status = true;
            }
            else
            {
                userObj.status = false;
            }
            if(chkActualCompleteDate.Checked==true)
            {
                userObj.ActualCompleteDate = true;
            }
            else
            {
                userObj.ActualCompleteDate = false;
            }
            if (chkWBSID.Checked == true)
            {
                userObj.wbsId = true;
            }
            else
            {
                userObj.wbsId = false;
            }
            if(chkActivityID.Checked==true)
            {
                userObj.ActivityId = true;
            }
            else
            {
                userObj.ActivityId = false;
            }
            if(chkBudgetHours.Checked==true)
            {
                userObj.budgetHours = true;
            }
            else
            {
                userObj.budgetHours = false;
            }
            if(chkSpentHoursProductive.Checked==true)
            {
                userObj.spentHoursProductive = true;
            }
            else
            {
                userObj.spentHoursProductive = false;
            }
            if(chkSpentHoursNonProductive.Checked==true)
            {
                userObj.spentHoursNonProductive = true;
            }
            else
            {
                userObj.spentHoursNonProductive = false;
            }
            if(chkActivityWeight.Checked==true)
            {
                userObj.activityWeight = true;
            }
            else
            {
                userObj.activityWeight = false;
            }
            if(chkQtyToInstall.Checked==true)
            {
                userObj.quantitytoInstall = true;
            }
            else
            {
                userObj.quantitytoInstall = false;
            }
            if(chkQuantityInstalled.Checked==true)
            {
                userObj.quantityInstalled = true;
            }
            else
            {
                userObj.quantityInstalled = false;
            }
            if(chkUnitOfMeasure.Checked==true)
            {
                userObj.unitOfMeasure = true;
            }
            else
            {
                userObj.unitOfMeasure = false;
            }
            if(chkCompleted.Checked==true)
            {
                userObj.completedBy = true;
            }
            else
            {
                userObj.completedBy=false;
            }
            if(chkRFIRef_No.Checked==true)
            {
                userObj.rfiRef_No = true;
            }
            else
            {
                userObj.rfiRef_No = false;
            }
            if(chkRFIDate.Checked==true)
            {
                userObj.rfiDate = true;
            }
            else
            {
                userObj.rfiDate = false;
            }
            if(chkAFIRef_No.Checked==true)
            {
                userObj.afiRef_No = true;
            }
            else
            {
                userObj.afiRef_No = false;
            }
            if(chkAFIDate.Checked==true)
            {
                userObj.afiDate = true;
            }
            else
            {
                userObj.afiDate = false;
            }
            if(chkRemarks.Checked==true)
            {
                userObj.remarks = true;
            }
            else
            {
                userObj.remarks = false;
            }
            userObj.totalCaption = txtTotalCaption.Text;
            userObj.passedCaption = txtPassedCaption.Text;
            userObj.failedCapton = txtFailedCaption.Text;
            userObj.inProgressCaption = txtInProgressCaption.Text;
            userObj.testedCaption = txtTestedCaption.Text;
            userObj.readyCaption = txtReadyCaption.Text;
            userObj.notReadyCaption = txtNotReadyCaption.Text;
            userObj.notTestedCaption = txtNotTested.Text;
            userObj.balanceCaption = txtBalanceCaption.Text;
            if(chkQuantityVerified.Checked==true)
            {
                userObj.quantityVerified = true;
            }
            else
            {
                userObj.quantityVerified = false;
            }
            userObj.projectNo = ddlSelectProject.SelectedItem.Text;
            userObj.moduleId = ddlSelectModule.SelectedItem.Value;
            string project = ddlSelectProject.SelectedItem.Text;
            string module = ddlSelectModule.SelectedItem.Value;
            DataTable dt = new DataTable();
            dt = userObj.Getsys_ActLibraryToFindModuleActId(project, module);
            if (dt.Rows.Count > 0)
            {
                int moduleActId = Convert.ToInt32(dt.Rows[0]["ModuleActID"]);
                if (moduleActId == 0)
                {
                    userObj.moduleActId = 10;
                }
                else
                {
                    userObj.moduleActId = moduleActId + 10;
                }
            }
            else
            {
                userObj.moduleActId = 10;
            }
            userObj.InsertModuleActivities();

        }
        #endregion FillActivities

        #region BindDropDownCreateNewProjectNo
        public void BindDropDownCreateNewProjectNo()
        {
            FlyCnDAL.ProjectParameters projectObj = new FlyCnDAL.ProjectParameters();
            DataTable dt = new DataTable();
            dt = projectObj.BindProjectNo();
            ddlSelectProject.DataSource = dt;
            ddlSelectProject.DataTextField = "ProjectNo";
            ddlSelectProject.DataBind();
        }
        #endregion BindDropDownCreateNewProjectNo

        #region BindDropDownActivityProjectNo
        public void BindDropDownActivityProjectNo()
        {
            FlyCnDAL.ProjectParameters projectObj = new FlyCnDAL.ProjectParameters();
            DataTable dt = new DataTable();
            dt = projectObj.BindProjectNo();
            ddlProjects.DataSource = dt;
            ddlProjects.DataTextField = "ProjectNo";
            ddlProjects.DataBind();
        }
        #endregion BindDropDownActivityProjectNo
        protected void ddlSelectProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtmodules = null;
            FlyCnDAL.Users userObj = new FlyCnDAL.Users();
            try
            {
                dtmodules = new DataTable();
                string project = ddlProjects.SelectedValue;
                dtmodules = userObj.GetAllModulesToManage();

                ddlSelectModule.DataSource = dtmodules;
                ddlSelectModule.DataTextField = "ModuleDesc";
                ddlSelectModule.DataValueField = "ModuleID";
                ddlSelectModule.DataBind();
                ddlSelectModule.Items.Insert(0, new ListItem("--select module--", "-1"));

            }
            catch (Exception)
            {


            }
            
        }

        protected void ddlProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtmodules = null;
            FlyCnDAL.Users userObj = new FlyCnDAL.Users();
            try
            {
                dtmodules = new DataTable();
                string project = ddlProjects.SelectedValue;
                dtmodules = userObj.GetAllModulesToManage();

                ddlModule.DataSource = dtmodules;
                ddlModule.DataTextField = "ModuleDesc";
                ddlModule.DataValueField = "ModuleID";
                ddlModule.DataBind();
                ddlModule.Items.Insert(0, new ListItem("--select module--", "-1"));

            }

            catch (Exception)
            {


            }
            if (dtgManageActivities.DataSource == null)
            {
                dtgManageActivities.DataSource = new string[] { };
            }
        }

        protected void ddlModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            FlyCnDAL.Users userObj = new FlyCnDAL.Users();
            DataTable ds = new DataTable();
           
            string module = ddlModule.SelectedValue;
            string project = ddlProjects.SelectedItem.Text;
            if (module != "--select module--")
            {
                ds = userObj.GetAllModuleActivities(project, module);
                dtgManageActivities.DataSource = ds;
                int count = ds.Rows.Count;
                if(count>0)
                {
                    dtgManageActivities.DataBind();
                }
               
            }
            if (dtgManageActivities.DataSource == null)
            {
                dtgManageActivities.DataSource = new string[] { };
            }
        }

        protected void dtgManageActivities_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                CheckBox checkBoxAdd = (CheckBox)item["Modulescheck"].Controls[0];
                checkBoxAdd.Enabled = true;
                
            }
             
        }

        protected void dtgManageActivities_PreRender(object sender, EventArgs e)
        {
            try
            {
                dtgManageActivities.Rebind();
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
            }
        }

        }
    }
