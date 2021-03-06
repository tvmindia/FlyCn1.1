﻿
#region Namespaces
using FlyCn.FlyCnDAL;
using FlyCn.UIClasses;
using FlyCn.UserControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Telerik.Web.UI;
#endregion Namespaces

namespace FlyCn.EIL
{
    public partial class ConstructionPunchList : System.Web.UI.Page
    {
        public string listFilter = null; 
              //listFilter = null;
        private const int ItemsPerRequest = 10;
        
   
        #region Global Variables
        ErrorHandling eObj = new ErrorHandling();
        DataTable dt = new DataTable();
        FlyCnDAL.PunchList pObj = new FlyCnDAL.PunchList();
        MasterPersonal mObj = new MasterPersonal();
        TabAddEditSettings tabs = new TabAddEditSettings();
        Security sObj = new Security();

        public Guid Id;
        public int IdNo;
        public string EilType = "";
        #endregion Global Variables

        #region Events

        #region Page_Load
        /// <summary>
        /// Event for page load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //----------- Register Toolbar Server & Client side events ----------------//
            ToolBar.onClick += new RadToolBarEventHandler(ToolBar_onClick);
            ToolBar.OnClientButtonClicking = "OnClientButtonClicking";
            //----------- Page Security Checking ----------------//          
           
            //bindpageload();
          
            SecurityCheck();
            //dt = pObj.GetPunchListItemDetails(projno, ID);
            //txtIDno.Text = dt.Rows[0]["IDNo"].ToString();
            //string opndate = dt.Rows[0]["OpenDt"].ToString();

            //-------------------------------------------------------------------------//
            ToolBarVisibility(4);
            if (!IsPostBack)
            {
                 if ((ddlModule.Text != "") && (ddlModule.Text != null))
            {
                Session["module"] = ddlModule.SelectedItem.Value;
                 }
                if ((ddlCategory.Text != "") && (ddlCategory.Text!=null))
            {
                Session["category"] = ddlCategory.SelectedItem.Value;
                }
                //bindpageload();

                BindDropDownModule();
                BindDropdownCategory();
                BindDropdownActivity();
                LoadComboBox();
                if (Request.QueryString["Mode"] != null)
                {              
                    hdnMode.Value = Request.QueryString["Mode"].ToString();
                    EilType=hdnMode.Value;
                }
                string url = Request.Url.Query;
                hdnMode.Value = EilType;
            }
            hdnMode.Value = EilType;
            if(hdnMode.Value!="")
            {
                lblTypeNeed.Text = hdnMode.Value;
            }
            if(txtIDno.Text=="")
            {
                btnsubmit.Enabled = false;
            }
            BindData(IdNo, hdnMode.Value);
            SetTitle();
            if ((ddlModule.Text != "") && (ddlModule.Text != null))
            {
                Session["module"] = ddlModule.SelectedItem.Value;
            }
            if ((ddlCategory.Text != "") && (ddlCategory.Text != null))
            {
                Session["category"] = ddlCategory.SelectedItem.Value;
            }
            if (EilType != "" && EilType != null)
            {
                Session["EilType"] = EilType;
            }
        }
        #endregion Page_Load

        //public string BindModule()
        //{
        //    string moduleId = "";
        //    if ((ddlModule.Text != "") && (ddlModule.Text != null))
        //    {
        //        moduleId = ddlModule.SelectedItem.Value;
        //    }
        //    return moduleId;
        //}
        //public string BindCategory()
        //{
        //    string category = "";
        //    if (ddlCategory.Text != "")
        //    {
        //        category = ddlCategory.SelectedItem.Value;
        //    }
        //    return category;
        //}
        //public void bindpageload()
        //{
        //    listFilter = null;
        //    listFilter = BindName();

        //}
        //public void BindName()
        //{
        //    FlyCnDAL.PunchList punchObj = new FlyCnDAL.PunchList();
        //    UIClasses.Const Const = new UIClasses.Const();
        //    FlyCnDAL.Security.UserAuthendication UA;
        //    HttpContext context = HttpContext.Current;
        //    UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
        //    string project = UA.projectNo;
        //    string moduleId = "";
        //    string category = "";
        //    if ((ddlModule.Text != "") && (ddlCategory.Text != ""))
        //    {
        //        moduleId = ddlModule.SelectedItem.Value;
        //        category = ddlCategory.SelectedItem.Value;

        //    }
        //    //StringBuilder output = new StringBuilder();
        //    //try
        //    //{
        //    string text = "1";
        //    DataTable dt = punchObj.GetTagNo(project, moduleId, category, text);
        //    radTagNo.DataSource = dt;
        //    radTagNo.DataTextField = punchObj.KeyField;

        //    //output.Append("[");

        //    //for (int i = 0; i < dt.Rows.Count; ++i)
        //    //{
        //    //    output.Append("\"" + dt.Rows[i][punchObj.KeyField] + "\"");

        //    //    if (i != (dt.Rows.Count - 1))
        //    //    {
        //    //        output.Append(",");
        //    //    }

        //    //}

        //    //output.Append("]");
        //    radTagNo.DataBind();
        //    //}
        //    //catch(Exception ex)
        //    // {
        //    //     var page = HttpContext.Current.CurrentHandler as Page;
        //    //     eObj.ErrorData(ex, page);
        //    //     throw ex;
        //    // }

        //    //return output.ToString();
        //} 

        #region ToolBar_OnClick
        protected void ToolBar_onClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            if (e.Item.Value == "Save")
            {
                if (hdfValidateSave.Value == "1")
                {
                    InserEil();
                }
                else
                {
                    Insert();
                }
                radTagNo.Text = "";
                
            }
            if(e.Item.Value=="Add")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ClearTextBox", "ClearTexBox();", true);
                txtIDno.Enabled = true;
                ddlActivity.Enabled = true;
                ddlModule.Enabled = true;
                ddlCategory.Enabled = true;
                radTagNo.Enabled = true;
                radTagNo.Text = "";
                RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("2");
                tab.Selected = true;
                tab.Text = "New";
            }
            if (e.Item.Value == "Update")
            {
              
                Update();
                ToolBarVisibility(2);
            }
            if (e.Item.Value == "Delete")
            {
                Delete();
            }
        }
        #endregion ToolBar_OnClick

        #region btnSave_Click
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (hdfValidateSave.Value == "1")
            {
                InserEil();
            }
            else
            {
                Insert();
            }
        }
        #endregion btnSave_Click

        #region dtgManageProjectGrid_NeedDataSource1
        protected void dtgManageProjectGrid_NeedDataSource1(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            string eilType = Session["EilType"].ToString();
            DataTable dt;
            dt = pObj.GetPunchList(eilType);
            dtgManageProjectGrid.DataSource = dt;
           

        }
        #endregion dtgManageProjectGrid_NeedDataSource1

        #region dtgManageProjectGrid_DeleteCommand
        private void dtgManageProjectGrid_DeleteCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            string ID = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["IDNo"].ToString();
            DataTable table = (DataTable)Session["DataSource"];
            if (table.Rows.Find(ID) != null)
            {
                table.Rows.Find(ID).Delete();
                table.AcceptChanges();
                Session["DataSource"] = dt;
            }
        }
        #endregion dtgManageProjectGrid_DeleteCommand

        #region dtgManageProjectGrid_ItemCommand
        protected void dtgManageProjectGrid_ItemCommand(object source, GridCommandEventArgs e)
        {
            DataTable dtId,dtAct = new DataTable();
            if (e.CommandName == "EditData")
            {
                ToolBarVisibility(2);
                GridDataItem item = (GridDataItem)e.Item;
                EilType = item.GetDataKeyValue("EILType").ToString();
                lblEliTypeNum.Text = EilType;
                IdNo =Convert.ToInt32(item.GetDataKeyValue("IDNo"));
                lblIDNum.Text = IdNo.ToString();
                BindData(IdNo, EilType);
                //UIClasses.Const Const = new UIClasses.Const();
                //FlyCnDAL.Security.UserAuthendication UA;
                //HttpContext context = HttpContext.Current;
                //UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
                //string usrname = UA.userName;
                //string result;
                //result = sObj.LoginSecurityCheck(hdnMode.Value, usrname, ToolBar);
                //hdnSecurity.Value = result;
                btnsubmit.Enabled = true;
                hdnAccessMode.Value = "EditData";

                RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("2");
                tab.Selected = true;
                tab.Text = "Edit";

                RadMultiPage1.SelectedIndex = 1;
                string ID = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["IDNo"].ToString();
                string projno = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ProjectNo"].ToString();

                dt = pObj.GetPunchListItemDetails(projno, ID);
                if (dt.Rows.Count > 0)
                {
                    string lnkId = dt.Rows[0]["LinkIDNo"].ToString();
                    dtId = pObj.GetIntermediateLog(lnkId);
                    if (dtId.Rows.Count > 0)
                    {
                        ddlModule.Text = dtId.Rows[0]["ModuleID"].ToString();
                        ddlModule.Enabled = false;
                        BindDropdownCategory();
                        string category1 = dtId.Rows[0]["Category"].ToString();
                       // ddlCategory.ClearSelection();
                        ddlCategory.Items.FindByValue(category1).Selected = true;
                        ddlCategory.Enabled = false;
                        string actCode = dtId.Rows[0]["ActCode"].ToString();
                        dtAct = pObj.GetActivityByActCode(actCode,projno, ddlModule.Text, category1);
                        BindDropdownActivity();
                        string activity = dtAct.Rows[0]["FullDesc"].ToString();
                        ddlActivity.Items.FindByValue(activity).Selected = true;
                        ddlActivity.Enabled = false;
                    }
                    //else
                    //{
                    //    ddlModule.Text = "--select module--";
                    //    ddlCategory.Text = "--select category--";
                    //}
                    radTagNo.Text = dt.Rows[0]["LinkIDNo"].ToString();
                    radTagNo.Enabled = false;
                    txtIDno.Text = dt.Rows[0]["IDNo"].ToString();
                    txtIDno.Enabled = false;
                    string opndate = dt.Rows[0]["OpenDt"].ToString();

                    if (opndate != "")
                    {

                        RadOpenDate.SelectedDate = Convert.ToDateTime(opndate);
                    }
                    string opnby = dt.Rows[0]["OpenBy"].ToString();
                    if (opnby != "")
                    {
                        ddlOpenBy.SelectedValue = opnby;

                    }
                    else
                    {
                        ddlOpenBy.SelectedIndex = ddlOpenBy.Items.IndexOf(ddlOpenBy.Items.FindByText("-Select-"));
                    }
                    string reqby = dt.Rows[0]["ReqBy"].ToString();
                    if (reqby != "")
                    {
                        ddlRequestedBy.SelectedValue = reqby;
                    }
                    else
                    {
                        ddlRequestedBy.SelectedIndex = ddlRequestedBy.Items.IndexOf(ddlRequestedBy.Items.FindByText("-Select-"));
                    }
                    string resperson = dt.Rows[0]["ComplRespPerson"].ToString();
                    if (resperson != "")
                    {
                        ddlResponsiblePerson.SelectedValue = resperson;
                    }
                    else
                    {
                        ddlResponsiblePerson.SelectedIndex = ddlResponsiblePerson.Items.IndexOf(ddlResponsiblePerson.Items.FindByText("-Select-"));
                    }
                    string inspector = dt.Rows[0]["Inspector"].ToString();
                    if (inspector != "")
                    {
                        ddlInspector.SelectedValue = inspector;
                    }
                    else
                    {
                        ddlInspector.SelectedIndex = ddlInspector.Items.IndexOf(ddlInspector.Items.FindByText("-Select-"));
                    }
                    string signed = dt.Rows[0]["SignOffBy"].ToString();
                    if (signed != "")
                    {
                        ddlSignedBy.SelectedValue = signed;
                    }
                    else
                    {
                        ddlSignedBy.SelectedIndex = ddlSignedBy.Items.IndexOf(ddlSignedBy.Items.FindByText("-Select-"));
                    }
                    string entrdby = dt.Rows[0]["EnteredBy"].ToString();
                    if (entrdby != "")
                    {
                        ddlEnteredBy.SelectedValue = entrdby;
                    }
                    else
                    {
                        ddlEnteredBy.SelectedIndex = ddlEnteredBy.Items.IndexOf(ddlEnteredBy.Items.FindByText("-Select-"));
                    }

                    string entrdDate = dt.Rows[0]["EnteredDt"].ToString();
                    if (entrdDate != "")
                    {
                        RadEnteredDate.SelectedDate = Convert.ToDateTime(entrdDate);
                    }

                    string displne = dt.Rows[0]["Discipline"].ToString();
                    if (displne != "")
                    {
                        ddlDiscipline.SelectedValue = displne;
                    }
                    else
                    {
                        ddlDiscipline.SelectedIndex = ddlDiscipline.Items.IndexOf(ddlDiscipline.Items.FindByText("-Select-"));
                    }

                    txtItemDescription.Text = dt.Rows[0]["Description"].ToString();
                    string location = dt.Rows[0]["Location"].ToString();
                    if (location != "")
                    {
                        ddlLocation.SelectedValue = location;
                    }
                    else
                    {
                        ddlLocation.SelectedIndex = ddlLocation.Items.IndexOf(ddlLocation.Items.FindByText("-Select-"));
                    }
                    string area = dt.Rows[0]["Area"].ToString();
                    if (area != "")

                    { ddlArea.SelectedValue = area; }
                    else
                    {
                        ddlArea.SelectedIndex = ddlArea.Items.IndexOf(ddlArea.Items.FindByText("-Select-"));
                    }
                    string unit = dt.Rows[0]["Unit"].ToString();
                    if (unit != "")
                    {
                        ddlUnit.SelectedValue = unit;
                    }
                    else
                    {
                        ddlUnit.SelectedIndex = ddlUnit.Items.IndexOf(ddlUnit.Items.FindByText("-Select-"));
                    }
                    string plant = dt.Rows[0]["Plant"].ToString();
                    if (plant != "")
                    {
                        ddlPlant.SelectedValue = plant;
                    }
                    else
                    {
                        ddlPlant.SelectedIndex = ddlPlant.Items.IndexOf(ddlPlant.Items.FindByText("-Select-"));
                    }
                    string schDate = dt.Rows[0]["SchComplDt"].ToString();
                    if (schDate != "")
                    {

                        RadScheduleCompletionDate.SelectedDate = Convert.ToDateTime(schDate);
                    }
                    string rfiDate = dt.Rows[0]["RFIDate"].ToString();
                    if (rfiDate != "")
                    {

                        RadRFIDate.SelectedDate = Convert.ToDateTime(rfiDate);
                    }
                    txtRFINo.Text = dt.Rows[0]["RFINo"].ToString();
                    txtSheet.Text = dt.Rows[0]["Sht"].ToString();
                    txtDrawing.Text = dt.Rows[0]["DwgNo"].ToString();
                    string failcategory = dt.Rows[0]["FailCategory"].ToString();
                    if (failcategory != "")
                    {
                        ddlFailCategory.SelectedValue = failcategory;
                    }
                    else
                    {
                        ddlFailCategory.SelectedIndex = ddlFailCategory.Items.IndexOf(ddlFailCategory.Items.FindByText("-Select-"));
                    }
                    string category = dt.Rows[0]["Category"].ToString();
                    if (category != "")
                    {
                        ddlCategoryList.SelectedValue = category;
                    }
                    else
                    {

                        ddlCategoryList.SelectedIndex = ddlCategoryList.Items.IndexOf(ddlCategoryList.Items.FindByText("-Select-"));
                    }
                    string system = dt.Rows[0]["TO_System"].ToString();
                    if (system != "")
                    {
                        ddlSystem.SelectedValue = system;
                    }
                    else
                    {
                        ddlSystem.SelectedIndex = ddlSystem.Items.IndexOf(ddlSystem.Items.FindByText("-Select-"));
                    }

                    string subsystem = dt.Rows[0]["TO_Subsystem"].ToString();
                    if (subsystem != "")
                    {
                        ddlSubsystem.SelectedValue = subsystem;
                    }
                    else
                    {
                        ddlSubsystem.SelectedIndex = ddlSubsystem.Items.IndexOf(ddlSubsystem.Items.FindByText("-Select-"));
                    }
                    string cntrlsystem = dt.Rows[0]["CTRL_System"].ToString();
                    if (cntrlsystem != "")
                    {
                        ddlControlSystem.SelectedValue = cntrlsystem;
                    }
                    else
                    {
                        ddlControlSystem.SelectedIndex = ddlControlSystem.Items.IndexOf(ddlControlSystem.Items.FindByText("-Select-"));
                    }
                    txtReference.Text = dt.Rows[0]["ChangeReqRef"].ToString();

                    string refDate = dt.Rows[0]["ChangeReqDt"].ToString();
                    if (refDate != "")
                    {
                        RadReferenceDate.SelectedDate = Convert.ToDateTime(refDate);
                    }
                    txtRevision.Text = dt.Rows[0]["Rev"].ToString();

                    string compDate = dt.Rows[0]["ComplDt"].ToString();
                    if (compDate != "")
                    {
                        RadCompletionDate.SelectedDate = Convert.ToDateTime(compDate);
                    }
                    txtCompletionRemarks.Text = dt.Rows[0]["ComplRemarks"].ToString();
                    string organization = dt.Rows[0]["ComplRespOrg"].ToString();
                    if (organization != "")
                    {
                        ddlOrganization.SelectedValue = organization;
                    }
                    else
                    {
                        ddlOrganization.SelectedIndex = ddlOrganization.Items.IndexOf(ddlOrganization.Items.FindByText("-Select-"));
                    }
                    string actionby = dt.Rows[0]["ActionBy"].ToString();
                    if (actionby != "")
                    {
                        ddlActionBy.SelectedValue = actionby;
                    }
                    else
                    {
                        ddlActionBy.SelectedIndex = ddlActionBy.Items.IndexOf(ddlActionBy.Items.FindByText("-Select-"));
                    }
                }
                DataTable dtt;
                dtt = pObj.GetFileFromEILAttachByProjectNoRefEILType(ID);
                grdFileUpload.DataSource = dtt;
                grdFileUpload.DataBind();

            }
            if (e.CommandName == "DeleteColumn")
            {
                string ID = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["IDNo"].ToString();
                string projno = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ProjectNo"].ToString();
                string type = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["EILType"].ToString();
                int val = 0;
                val = pObj.DeleteEILAttach(ID, type);
                int result = 0;
                result = pObj.DeleteEIL(projno, ID);
                if (result == 1)
                {
                    var page = HttpContext.Current.CurrentHandler as Page;
                    var master = page.Master;
                    eObj.DeleteSuccessData(page);

                }
                dtgManageProjectGrid.Rebind();
            }
            //--For Security purpose---
            if (e.CommandName == "ViewDetailColumn")
            {
                ToolBarVisibility(4);
                hdnAccessMode.Value = "ViewDetailColumn";

                RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("2");
                tab.Selected = true;
                tab.Text = "Edit";

                RadMultiPage1.SelectedIndex = 1;
                string ID = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["IDNo"].ToString();
                string projno = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ProjectNo"].ToString();

                dt = pObj.GetPunchListItemDetails(projno, ID);
                txtIDno.Text = dt.Rows[0]["IDNo"].ToString();
                string opndate = dt.Rows[0]["OpenDt"].ToString();

                if (opndate != "")
                {

                    RadOpenDate.SelectedDate = Convert.ToDateTime(opndate);
                }
                string opnby = dt.Rows[0]["OpenBy"].ToString();
                if (opnby != "")
                {
                    ddlOpenBy.SelectedValue = opnby;

                }
                else
                {
                    ddlOpenBy.SelectedIndex = ddlOpenBy.Items.IndexOf(ddlOpenBy.Items.FindByText("-Select-"));
                }
                string reqby = dt.Rows[0]["ReqBy"].ToString();
                if (reqby != "")
                {
                    ddlRequestedBy.SelectedValue = reqby;
                }
                else
                {
                    ddlRequestedBy.SelectedIndex = ddlRequestedBy.Items.IndexOf(ddlRequestedBy.Items.FindByText("-Select-"));
                }
                string resperson = dt.Rows[0]["ComplRespPerson"].ToString();
                if (resperson != "")
                {
                    ddlResponsiblePerson.SelectedValue = resperson;
                }
                else
                {
                    ddlResponsiblePerson.SelectedIndex = ddlResponsiblePerson.Items.IndexOf(ddlResponsiblePerson.Items.FindByText("-Select-"));
                }
                string inspector = dt.Rows[0]["Inspector"].ToString();
                if (inspector != "")
                {
                    ddlInspector.SelectedValue = inspector;
                }
                else
                {
                    ddlInspector.SelectedIndex = ddlInspector.Items.IndexOf(ddlInspector.Items.FindByText("-Select-"));
                }
                string signed = dt.Rows[0]["SignOffBy"].ToString();
                if (signed != "")
                {
                    ddlSignedBy.SelectedValue = signed;
                }
                else
                {
                    ddlSignedBy.SelectedIndex = ddlSignedBy.Items.IndexOf(ddlSignedBy.Items.FindByText("-Select-"));
                }
                string entrdby = dt.Rows[0]["EnteredBy"].ToString();
                if (entrdby != "")
                {
                    ddlEnteredBy.SelectedValue = entrdby;
                }
                else
                {
                    ddlEnteredBy.SelectedIndex = ddlEnteredBy.Items.IndexOf(ddlEnteredBy.Items.FindByText("-Select-"));
                }

                string entrdDate = dt.Rows[0]["EnteredDt"].ToString();
                if (entrdDate != "")
                {
                    RadEnteredDate.SelectedDate = Convert.ToDateTime(entrdDate);
                }

                string displne = dt.Rows[0]["Discipline"].ToString();
                if (displne != "")
                {
                    ddlDiscipline.SelectedValue = displne;
                }
                else
                {
                    ddlDiscipline.SelectedIndex = ddlDiscipline.Items.IndexOf(ddlDiscipline.Items.FindByText("-Select-"));
                }

                txtItemDescription.Text = dt.Rows[0]["Description"].ToString();
                string location = dt.Rows[0]["Location"].ToString();
                if (location != "")
                {
                    ddlLocation.SelectedValue = location;
                }
                else
                {
                    ddlLocation.SelectedIndex = ddlLocation.Items.IndexOf(ddlLocation.Items.FindByText("-Select-"));
                }
                string area = dt.Rows[0]["Area"].ToString();
                if (area != "")

                { ddlArea.SelectedValue = area; }
                else
                {
                    ddlArea.SelectedIndex = ddlArea.Items.IndexOf(ddlArea.Items.FindByText("-Select-"));
                }
                string unit = dt.Rows[0]["Unit"].ToString();
                if (unit != "")
                {
                    ddlUnit.SelectedValue = unit;
                }
                else
                {
                    ddlUnit.SelectedIndex = ddlUnit.Items.IndexOf(ddlUnit.Items.FindByText("-Select-"));
                }
                string plant = dt.Rows[0]["Plant"].ToString();
                if (plant != "")
                {
                    ddlPlant.SelectedValue = plant;
                }
                else
                {
                    ddlPlant.SelectedIndex = ddlPlant.Items.IndexOf(ddlPlant.Items.FindByText("-Select-"));
                }
                string schDate = dt.Rows[0]["SchComplDt"].ToString();
                if (schDate != "")
                {

                    RadScheduleCompletionDate.SelectedDate = Convert.ToDateTime(schDate);
                }
                string rfiDate = dt.Rows[0]["RFIDate"].ToString();
                if (rfiDate != "")
                {

                    RadRFIDate.SelectedDate = Convert.ToDateTime(rfiDate);
                }
                txtRFINo.Text = dt.Rows[0]["RFINo"].ToString();
                txtSheet.Text = dt.Rows[0]["Sht"].ToString();
                txtDrawing.Text = dt.Rows[0]["DwgNo"].ToString();
                string failcategory = dt.Rows[0]["FailCategory"].ToString();
                if (failcategory != "")
                {
                    ddlFailCategory.SelectedValue = failcategory;
                }
                else
                {
                    ddlFailCategory.SelectedIndex = ddlFailCategory.Items.IndexOf(ddlFailCategory.Items.FindByText("-Select-"));
                }
                string category = dt.Rows[0]["Category"].ToString();
                if (category != "")
                {
                    ddlCategoryList.SelectedValue = category;
                }
                else
                {

                    ddlCategoryList.SelectedIndex = ddlCategoryList.Items.IndexOf(ddlCategoryList.Items.FindByText("-Select-"));
                }
                string system = dt.Rows[0]["TO_System"].ToString();
                if (system != "")
                {
                    ddlSystem.SelectedValue = system;
                }
                else
                {
                    ddlSystem.SelectedIndex = ddlSystem.Items.IndexOf(ddlSystem.Items.FindByText("-Select-"));
                }

                string subsystem = dt.Rows[0]["TO_Subsystem"].ToString();
                if (subsystem != "")
                {
                    ddlSubsystem.SelectedValue = subsystem;
                }
                else
                {
                    ddlSubsystem.SelectedIndex = ddlSubsystem.Items.IndexOf(ddlSubsystem.Items.FindByText("-Select-"));
                }
                string cntrlsystem = dt.Rows[0]["CTRL_System"].ToString();
                if (cntrlsystem != "")
                {
                    ddlControlSystem.SelectedValue = cntrlsystem;
                }
                else
                {
                    ddlControlSystem.SelectedIndex = ddlControlSystem.Items.IndexOf(ddlControlSystem.Items.FindByText("-Select-"));
                }
                txtReference.Text = dt.Rows[0]["ChangeReqRef"].ToString();

                string refDate = dt.Rows[0]["ChangeReqDt"].ToString();
                if (refDate != "")
                {
                    RadReferenceDate.SelectedDate = Convert.ToDateTime(refDate);
                }
                txtRevision.Text = dt.Rows[0]["Rev"].ToString();

                string compDate = dt.Rows[0]["ComplDt"].ToString();
                if (compDate != "")
                {
                    RadCompletionDate.SelectedDate = Convert.ToDateTime(compDate);
                }
                txtCompletionRemarks.Text = dt.Rows[0]["ComplRemarks"].ToString();
                string organization = dt.Rows[0]["ComplRespOrg"].ToString();
                if (organization != "")
                {
                    ddlOrganization.SelectedValue = organization;
                }
                else
                {
                    ddlOrganization.SelectedIndex = ddlOrganization.Items.IndexOf(ddlOrganization.Items.FindByText("-Select-"));
                }
                string actionby = dt.Rows[0]["ActionBy"].ToString();
                if (actionby != "")
                {
                    ddlActionBy.SelectedValue = actionby;
                }
                else
                {
                    ddlActionBy.SelectedIndex = ddlActionBy.Items.IndexOf(ddlActionBy.Items.FindByText("-Select-"));
                }

                DataTable dtt;
                dtt = pObj.GetFileFromEILAttachByProjectNoRefEILType(ID);
                grdFileUpload.DataSource = dtt;
                grdFileUpload.DataBind();
            }


        }
        #endregion dtgManageProjectGrid_ItemCommand

        #region btnUpdate_Click
        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }
        #endregion btnUpdate_Click

        #region txtIDno_TextChanged
        protected void txtIDno_TextChanged(object sender, EventArgs e)
        {


        }
        #endregion txtIDno_TextChanged

        #region btnCancel_Click
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConstructionPunchList.aspx");
        }
        #endregion btnCancel_Click

        #region grdFileUpload_RowCommand
        protected void grdFileUpload_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ToolBar.AddButton.Visible = false;
            ToolBar.SaveButton.Visible = false;
            ToolBar.UpdateButton.Visible = true;
            ToolBar.DeleteButton.Visible = true;
            try
            {
                if (e.CommandName == "Delete")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    int result;
                    pObj.Idno = Convert.ToInt32(txtIDno.Text);
                    string type = hdnMode.Value;
                    GridViewRow row = grdFileUpload.Rows[index];
                    HiddenField hdnField = (HiddenField)row.FindControl("hdnField");
                    int slno = Convert.ToInt32(hdnField.Value);
                    pObj.fileUpload = row.Cells[3].Text;
                    result = pObj.DeleteEilAttachByProjectNoRefNoEILTypeSlNo(pObj.Idno, type, slno);
                    FileUploadDelete();

                }
            }
            catch (Exception)
            {

            }

        }
        #endregion grdFileUpload_RowCommand

        #region grdFileUpload_RowDeleting
        public void grdFileUpload_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {

        }
        #endregion grdFileUpload_RowDeleting

        #region grdFileUpload_RowDataBound
        protected void grdFileUpload_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;

        }
        #endregion grdFileUpload_RowDataBound

        #region btnUpload_Click
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            ToolBar.AddButton.Visible = false;
            ToolBar.SaveButton.Visible = false;
            ToolBar.UpdateButton.Visible = true;
            ToolBar.DeleteButton.Visible = true;
            IdUc_FlyCnFileUpload.EILId = Convert.ToInt32(txtIDno.Text);
            IdUc_FlyCnFileUpload.EilType = "WEIL";
            IdUc_FlyCnFileUpload.FileInsert();
            Rebind();
        }
        #endregion btnUpload_Click

        #region imageButtonDownload_Click
        protected void imageButtonDownload_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imgbtn = sender as ImageButton;
            GridViewRow gvrow = imgbtn.NamingContainer as GridViewRow;
            string filePath = grdFileUpload.DataKeys[gvrow.RowIndex].Value.ToString();
            Download(filePath);
        }
        #endregion imageButtonDownload_Click

        #region ToolBarVisibility
        public void ToolBarVisibility(int order)
        {
            switch (order)
            {
                case 1://after adding what should be visible
                    ToolBar.AddButton.Visible = true;
                    ToolBar.SaveButton.Visible = false;
                    ToolBar.UpdateButton.Visible = false;
                    ToolBar.EditButton.Visible = true;
                    ToolBar.DeleteButton.Visible = false;
                    break;
                case 2:
                    ToolBar.AddButton.Visible = true;
                    ToolBar.SaveButton.Visible = false;
                    ToolBar.UpdateButton.Visible = true;
                    ToolBar.EditButton.Visible = false;
                    ToolBar.DeleteButton.Visible = false;
                    break;

                case 3:
                    ToolBar.AddButton.Visible = false;
                    ToolBar.SaveButton.Visible = true;
                    ToolBar.UpdateButton.Visible = false;
                    ToolBar.EditButton.Visible = false;
                    ToolBar.DeleteButton.Visible = false;
                    break;


                case 4://toally invicible
                    ToolBar.AddButton.Visible = false;
                    ToolBar.SaveButton.Visible = true;
                    ToolBar.UpdateButton.Visible = false;
                    ToolBar.EditButton.Visible = false;
                    ToolBar.DeleteButton.Visible = false;
                    break;

            }

        }
        #endregion ToolBarVisibility


        #endregion Events

        #region Methods

        #region ChangeFileName
        //public void ChangeFileName(string id, string name, string type, int sl)
        //{
        //    if (fuAttach.HasFile)
        //    {


        //        UIClasses.Const Const = new UIClasses.Const();

        //        FlyCnDAL.Security.UserAuthendication UA;
        //        HttpContext context = HttpContext.Current;
        //        UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
        //        pObj.Projno = UA.projectNo;
        //        string pNo = pObj.Projno;
        //        string filename = Path.GetFileName(fuAttach.FileName);
        //        string extension = Path.GetExtension(fuAttach.PostedFile.FileName);
        //        string oldFileName = fuAttach.FileName;

        //        int newsl = sl;

        //        string newFileName = (pNo + id + type + (newsl) + name);


        //        pObj.fileUpload = newFileName;
        //        fuAttach.SaveAs(Server.MapPath("~/Content/Fileupload/") + newFileName);

        //        int idno = Convert.ToInt32(id);
        //        int value;
        //        value = pObj.InsertEILAttachment(idno);
        //    }
        //}
        #endregion ChangeFileName

        #region BindFileuploadGrid
        /// <summary>
        /// Method to Bind attachment files
        /// </summary>
        /// <param name="id"></param>
        public void BindFileuploadGrid(string id)
        {

            ToolBar.AddButton.Visible = false;
            ToolBar.SaveButton.Visible = false;
            ToolBar.UpdateButton.Visible = true;
            ToolBar.DeleteButton.Visible = true;
            DataTable dtt;
            dtt = pObj.GetFileFromEILAttachByProjectNoRefEILType(id);
            grdFileUpload.DataSource = dtt;
            grdFileUpload.DataBind();
        }
        #endregion BindFileuploadGrid

        #region Upload
        public void Upload()
        {
            ToolBar.AddButton.Visible = false;
            ToolBar.SaveButton.Visible = false;
            ToolBar.UpdateButton.Visible = true;
            ToolBar.DeleteButton.Visible = true;

            pObj.Idno = Convert.ToInt32(txtIDno.Text);
            pObj.EILType = "WEIL";
        //    if (fuAttach.HasFile)
        //    {
        //        try
        //        {
                   
        //                pObj.Idno = Convert.ToInt32(txtIDno.Text);

        //                if (grdFileUpload.Rows.Count > 0)
        //                {
        //                    HiddenField hdf = (HiddenField)grdFileUpload.Rows[0].FindControl("hdnType");
        //                    pObj.EILType = hdf.Value;
        //                }
        //                else
        //                {

        //                    pObj.EILType = "WEIL";
        //                }

        //                string id = txtIDno.Text;
        //                pObj.fileUpload = Path.GetFileName(fuAttach.FileName);
        //                pObj.FileType = System.IO.Path.GetExtension(fuAttach.FileName);
        //             //   string Image =Convert.ToString(fuAttach.FileContent);
        //                dt = pObj.GetEIL_AttachDetails(id, pObj.fileUpload, pObj.EILType);

        //                string id1 = txtIDno.Text;


        //                // DataTable dt1;

        //                //  dt1 = pObj.GetEIL_AttachDetails(id, pObj.fileUpload, pObj.EILType);

        //                if ((dt.Rows.Count > 0))
        //                {
        //                    btnUpload.Enabled = true;
        //                    foreach (DataRow rows in dt.Rows)
        //                    {
        //                        string name = rows["FileName"].ToString();
        //                        //  pObj.slno = Convert.ToInt32(dt.Rows[0]["SlNo"].ToString());
        //                        DataTable dt1;
        //                        dt1 = pObj.GetSLNo_AttachDetails(id, pObj.fileUpload, pObj.EILType);
        //                        pObj.slno = Convert.ToInt32(dt1.Rows[0]["SlNo"].ToString());


        //                        if (pObj.fileUpload == name)
        //                        {
        //                            ChangeFileName(id1, pObj.fileUpload, pObj.EILType, pObj.slno);

        //                        }



        //                    }
        //                }




        //                else
        //                {

        //                    try
        //                    {
        //                        pObj.fileUpload = Path.GetFileName(fuAttach.FileName);
        //                        string save = Server.MapPath("~/Content/Fileupload/" + pObj.fileUpload);
        //                        fuAttach.SaveAs(save);
        //                        // Label lblStatus=(Label) FindControl("StatusLabel");

        //                        StatusLabel.Text = "Upload status: File uploaded!";
        //                        pObj.Idno = Convert.ToInt32(txtIDno.Text);
        //                        string idno = Convert.ToString(pObj.Idno);
        //                        int value;
        //                        value = pObj.InsertEILAttachment(pObj.Idno);

        //                    }


        //                    catch (Exception ex)
        //                    {
        //                        StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
        //                    }
        //                }


        //                pObj.Idno = Convert.ToInt32(txtIDno.Text);
        //                string idno1 = Convert.ToString(pObj.Idno);
        //                grdFileUpload.Visible = true;
        //                BindFileuploadGrid(idno1);
        //                ScriptManager.RegisterStartupScript(this, GetType(), "Edit", "ShowEdit();", true);
                    
                  
        //        }
        //        catch (Exception ex)
        //        {
        //            StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
        //        }
            
        //    }
        }


        #endregion Upload

        #region Update
        public void Update()
        {
            try
            {
                int result = 0;
                pObj.Idno = Convert.ToInt32(txtIDno.Text);
                pObj.CoveredByProject = 0;
                if (rdbCoveredByYes.Checked)
                {
                    pObj.CoveredByProject = Convert.ToInt32(rdbCoveredByYes.ToolTip);

                }
                else
                {
                    if (rdbCoveredByNo.Checked)
                    {
                        pObj.CoveredByProject = Convert.ToInt32(rdbCoveredByNo.ToolTip);

                    }
                }
                if (ddlOpenBy.SelectedItem.Text != "-Select-")
                {
                    mObj.OpenBy = Convert.ToString(ddlOpenBy.SelectedValue);
                }
                else
                {
                    mObj.OpenBy = null;
                }
                if (RadOpenDate.SelectedDate != null)
                {
                    pObj.OpenDate = Convert.ToString(RadOpenDate.SelectedDate);
                }
                if (ddlRequestedBy.SelectedItem.Text != "-Select-")
                {
                    mObj.RequestedBy = Convert.ToString(ddlRequestedBy.SelectedValue);
                }
                else
                {
                    mObj.RequestedBy = null;
                }
                if (ddlResponsiblePerson.SelectedItem.Text != "-Select-")
                {
                    mObj.ResponsiblePerson = Convert.ToString(ddlResponsiblePerson.SelectedValue);
                }
                else
                {
                    mObj.ResponsiblePerson = null;
                }
                if (ddlInspector.SelectedItem.Text != "-Select-")
                {
                    mObj.Inspector = Convert.ToString(ddlInspector.SelectedValue);
                }
                else
                {
                    mObj.Inspector = null;
                }
                if (ddlSignedBy.SelectedItem.Text != "-Select-")
                {
                    mObj.SignedBy = Convert.ToString(ddlSignedBy.SelectedValue);
                }
                else
                {
                    mObj.SignedBy = null;
                }
                if (ddlEnteredBy.SelectedItem.Text != "-Select-")
                {
                    mObj.EnteredBy = Convert.ToString(ddlEnteredBy.SelectedValue);
                }
                else
                {
                    mObj.EnteredBy = null;
                }


                if (RadEnteredDate.SelectedDate != null)
                {
                    pObj.EnteredDt = Convert.ToString(RadEnteredDate.SelectedDate);
                }
                if (ddlDiscipline.SelectedItem.Text != "-Select-")
                {
                    pObj.Discipline = Convert.ToString(ddlDiscipline.SelectedValue);
                }
                else
                {
                    pObj.Discipline = null;
                }
                pObj.ItemDescription = txtItemDescription.Text;
                if (ddlLocation.SelectedItem.Text != "-Select-")
                {
                    pObj.Location = Convert.ToString(ddlLocation.SelectedValue);
                }
                else
                {
                    pObj.Location = null;
                }
                if (ddlArea.SelectedItem.Text != "-Select-")
                {
                    pObj.Area = Convert.ToString(ddlArea.SelectedValue);
                }
                else
                {
                    pObj.Area = null;
                }
                if (ddlUnit.SelectedItem.Text != "-Select-")
                {
                    pObj.Unit = Convert.ToString(ddlUnit.SelectedValue);
                }
                else
                {
                    pObj.Unit = null;
                }
                if (ddlPlant.SelectedItem.Text != "-Select-")
                {
                    pObj.Plant = Convert.ToString(ddlPlant.SelectedValue);
                }
                else
                {
                    pObj.Unit = null;
                }

                if (RadScheduleCompletionDate.SelectedDate != null)
                {
                    pObj.ScheduledDateCompletion = Convert.ToString(RadScheduleCompletionDate.SelectedDate);
                }
                if (RadRFIDate.SelectedDate != null)
                {
                    pObj.RFIDate = Convert.ToString(RadRFIDate.SelectedDate);
                }
                pObj.RFINo = txtRFINo.Text;
                pObj.Sheet = txtSheet.Text;
                pObj.Drawing = txtDrawing.Text;
                if (ddlFailCategory.SelectedItem.Text != "-Select-")
                {
                    pObj.FailCategory = Convert.ToString(ddlFailCategory.SelectedValue);
                }
                else
                {
                    pObj.FailCategory = null;
                }



                string val = null;
                pObj.QueryRevision = string.IsNullOrEmpty(val) ? 0 : Convert.ToInt32(txtQueryRevision.Text);
                pObj.Reference = txtReference.Text;
                if (RadReferenceDate.SelectedDate != null)
                {
                    pObj.ReferenceDate = Convert.ToString(RadReferenceDate.SelectedDate);
                }


                if (RadCompletionDate.SelectedDate != null)
                {
                    pObj.CompletionDate = Convert.ToString(RadCompletionDate.SelectedDate);
                }
                pObj.CompletionRemarks = txtCompletionRemarks.Text;


                if (ddlOrganization.SelectedItem.Text != "-Select-")
                {
                    pObj.Organization = Convert.ToString(ddlOrganization.SelectedValue);
                }
                else
                {
                    pObj.Organization = null;
                }

                if (ddlActionBy.SelectedItem.Text != "-Select-")
                {
                    pObj.ActionBy = Convert.ToString(ddlActionBy.SelectedValue);
                }
                else
                {
                    pObj.ActionBy = null;
                }
                if (ddlSystem.SelectedItem.Text != "-Select-")
                {
                    pObj.System = Convert.ToString(ddlSystem.SelectedValue);
                }
                else
                {
                    pObj.System = null;
                }
                if (ddlSubsystem.SelectedItem.Text != "-Select-")
                {
                    pObj.Subsystem = Convert.ToString(ddlSubsystem.SelectedValue);
                }
                else
                {

                    pObj.Subsystem = null;
                }
                if (ddlControlSystem.SelectedItem.Text != "-Select-")
                {
                    pObj.ControlSystem = Convert.ToString(ddlControlSystem.SelectedValue);
                }
                else
                {
                    pObj.ControlSystem = null;
                }

                pObj.Idno = Convert.ToInt32(txtIDno.Text);
                pObj.EILType = hdnMode.Value;
                if(pObj.EILType==""||pObj.EILType==null)
                {
                    pObj.EILType =Convert.ToString(Session["EilType"]);
                }


                result = pObj.EditPunchListItems(pObj.Idno, mObj);

                if (result == 1)
                {
                    var page = HttpContext.Current.CurrentHandler as Page;
                    var master = page.Master;
                    eObj.UpdationSuccessData(page);


                }
                dtgManageProjectGrid.Rebind();
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
        #endregion Update

        #region Insert
        public void Insert()
        {

            RadTab tab = (RadTab)RadTabStrip1.FindTabByText("View");
            tab.Selected = true;
            RadMultiPage1.SelectedIndex = 0;
            try
            {

                int result = 0;
                pObj.Idno = Convert.ToInt32(txtIDno.Text);
                pObj.EILType = hdnMode.Value;
                pObj.CoveredByProject = 0;
                //if (ddlCategory.SelectedItem.Text != "--select category--")
                //{
                //    pObj.Category = ddlCategory.SelectedItem.Value;
                //}
                if (rdbCoveredByYes.Checked)
                {
                    pObj.CoveredByProject = Convert.ToInt32(rdbCoveredByYes.ToolTip);

                }
                else
                {
                    if (rdbCoveredByNo.Checked)
                    {
                        pObj.CoveredByProject = Convert.ToInt32(rdbCoveredByNo.ToolTip);

                    }
                }
                if (ddlOpenBy.SelectedItem.Text != "-Select-")
                {
                    mObj.OpenBy = Convert.ToString(ddlOpenBy.SelectedValue);
                }
                else
                {
                    mObj.OpenBy = null;
                }
                if (RadOpenDate.SelectedDate != null)
                {
                    pObj.OpenDate = Convert.ToString(RadOpenDate.SelectedDate);
                }
                if (ddlRequestedBy.SelectedItem.Text != "-Select-")
                {
                    mObj.RequestedBy = Convert.ToString(ddlRequestedBy.SelectedValue);
                }
                else
                {
                    mObj.RequestedBy = Convert.ToString(DBNull.Value);
                }
                if (ddlResponsiblePerson.SelectedItem.Text != "-Select-")
                {
                    mObj.ResponsiblePerson = Convert.ToString(ddlResponsiblePerson.SelectedValue);
                }
                else
                {
                    mObj.ResponsiblePerson = Convert.ToString(DBNull.Value);
                }
                if (ddlInspector.SelectedItem.Text != "-Select-")
                {
                    mObj.Inspector = Convert.ToString(ddlInspector.SelectedValue);
                }
                else
                {
                    mObj.Inspector = Convert.ToString(DBNull.Value);
                }
                if (ddlSignedBy.SelectedItem.Text != "-Select-")
                {
                    mObj.SignedBy = Convert.ToString(ddlSignedBy.SelectedValue);
                }
                else
                {
                    mObj.SignedBy = Convert.ToString(DBNull.Value);
                }
                if (ddlEnteredBy.SelectedItem.Text != "-Select-")
                {
                    mObj.EnteredBy = Convert.ToString(ddlEnteredBy.SelectedValue);

                }
                else
                {
                    mObj.EnteredBy = Convert.ToString(DBNull.Value);
                }

                if (RadEnteredDate.SelectedDate != null)
                {
                    pObj.EnteredDt = Convert.ToString(RadEnteredDate.SelectedDate);
                }
                if (ddlDiscipline.SelectedItem.Text != "-Select-")
                {
                    pObj.Discipline = Convert.ToString(ddlDiscipline.SelectedValue);
                }
                else
                {
                    pObj.Discipline = Convert.ToString(DBNull.Value);
                }
                pObj.ItemDescription = txtItemDescription.Text;
                if (ddlLocation.SelectedItem.Text != "-Select-")
                {
                    pObj.Location = Convert.ToString(ddlLocation.SelectedValue);
                }
                else
                {
                    pObj.Location = Convert.ToString(DBNull.Value);
                }
                if (ddlArea.SelectedItem.Text != "-Select-")
                {
                    pObj.Area = Convert.ToString(ddlArea.SelectedValue);
                }
                else
                {
                    pObj.Area = Convert.ToString(DBNull.Value);
                }
                if (ddlUnit.SelectedItem.Text != "-Select-")
                {
                    pObj.Unit = Convert.ToString(ddlUnit.SelectedValue);
                }
                else
                {
                    pObj.Unit = Convert.ToString(DBNull.Value);
                }
                if (ddlPlant.SelectedItem.Text != "-Select-")
                {
                    pObj.Plant = Convert.ToString(ddlPlant.SelectedValue);
                }
                else
                {
                    pObj.Plant = Convert.ToString(DBNull.Value);
                }
                if (RadScheduleCompletionDate.SelectedDate != null)
                {
                    pObj.ScheduledDateCompletion = Convert.ToString(RadScheduleCompletionDate.SelectedDate);
                }
                if (RadRFIDate.SelectedDate != null)
                {
                    pObj.RFIDate = Convert.ToString(RadRFIDate.SelectedDate);
                }

                pObj.RFINo = txtRFINo.Text;
                pObj.Sheet = txtSheet.Text;
                pObj.Drawing = txtDrawing.Text;
                if (ddlFailCategory.SelectedItem.Text != "-Select-")
                {

                    pObj.FailCategory = Convert.ToString(ddlFailCategory.SelectedValue);

                }
                else
                {
                    pObj.FailCategory = Convert.ToString(DBNull.Value);
                }
                //if (ddlCategory.SelectedItem.Text != "-Select-")
                //{
                //    pObj.Category = Convert.ToString(ddlCategoryList.SelectedValue);
                //}
                //else
                //{
                //    pObj.Category = null;
                //}
                if (ddlSystem.SelectedItem.Text != "-Select-")
                {
                    pObj.System = Convert.ToString(ddlSystem.SelectedValue);
                }
                else
                {
                    pObj.System = Convert.ToString(DBNull.Value);
                }
                if (ddlSubsystem.SelectedItem.Text != "-Select-")
                {
                    pObj.Subsystem = Convert.ToString(ddlSubsystem.SelectedValue);
                }
                else
                {

                    pObj.Subsystem = Convert.ToString(DBNull.Value);
                }

                string val = null;
                pObj.QueryRevision = string.IsNullOrEmpty(val) ? '0' : Convert.ToInt32(txtQueryRevision.Text);
                pObj.Reference = txtReference.Text;
                if (RadReferenceDate.SelectedDate != null)
                {
                    pObj.ReferenceDate = Convert.ToString(RadReferenceDate.SelectedDate);
                }
                pObj.Revison = txtRevision.Text;
                if (RadCompletionDate.SelectedDate != null)
                {
                    pObj.CompletionDate = Convert.ToString(RadCompletionDate.SelectedDate);
                }
                pObj.CompletionRemarks = txtCompletionRemarks.Text;
                if (ddlControlSystem.SelectedItem.Text != "-Select-")
                {
                    pObj.ControlSystem = Convert.ToString(ddlControlSystem.SelectedValue);
                }
                else
                {
                    pObj.ControlSystem = Convert.ToString(DBNull.Value);
                }

                if (ddlOrganization.SelectedItem.Text != "-Select-")
                {
                    pObj.Organization = Convert.ToString(ddlOrganization.SelectedValue);
                }
                else
                {
                    pObj.Organization = Convert.ToString(DBNull.Value);
                }
                // pObj.CoveredByProject=
                // pObj.ChangeReq=
                if (ddlActionBy.SelectedItem.Text != "-Select-")
                {
                    pObj.ActionBy = Convert.ToString(ddlActionBy.SelectedValue);
                }
                else
                {
                    pObj.ActionBy = Convert.ToString(DBNull.Value);

                }
                pObj.ChangeReq = 0;
                if (rdbChangeRequestyes.Checked)
                {
                    pObj.ChangeReq = Convert.ToInt32(rdbChangeRequestyes.ToolTip);

                }
                else
                {
                    if (rdbchangerequestno.Checked)
                    {
                        pObj.CoveredByProject = Convert.ToInt32(rdbchangerequestno.ToolTip);

                    }
                }
                pObj.EILType = lblTypeNeed.Text;
                if ((ddlModule.Text != "") && (ddlModule.Text != null))
                {
                   pObj.moduleId = ddlModule.SelectedItem.Value;
                }
                if ((ddlCategory.Text != "") && (ddlCategory.Text != null))
                {
                    pObj.category = ddlCategory.SelectedItem.Value;
                    pObj.categoryDesc = ddlCategory.SelectedItem.Text;
                }
                if (radTagNo.Text != "")
                {
                    pObj.linkId = radTagNo.Text;
                }

                try
                {
                    result = pObj.AddtoPunchList(mObj);
                   
                        var page = HttpContext.Current.CurrentHandler as Page;
                        var master = page.Master;
                        eObj.InsertionSuccessData(page);
                        dtgManageProjectGrid.Rebind();                 
                  
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


                //Cleartextboxes();
            //    if (fuAttach.HasFile)
            //    {
            //        try
            //        {
            //            pObj.fileUpload = Path.GetFileName(fuAttach.FileName);
            //            string save = Server.MapPath("~/Content/Fileupload/" + pObj.fileUpload);
            //            fuAttach.SaveAs(save);
            //            StatusLabel.Text = "Upload status: File uploaded!";
            //            int id = Convert.ToInt32(txtIDno.Text);
            //            int value = 0;
            //            value = pObj.InsertEILAttachment(id);
            //        }
            //        catch (Exception ex)
            //        {
            //            StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
            //        }
            //    }
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
                RadTab tab1 = (RadTab)RadTabStrip1.FindTabByValue("1");
                RadTab tab2 = (RadTab)RadTabStrip1.FindTabByValue("2");
                tabs.ResetTabCaptions(tab1, tab2);
                RadMultiPage1.SelectedIndex = 0;
            }
        }
        #endregion Insert

        #region InserEil
        public void InserEil()
        {

            RadTab tab = (RadTab)RadTabStrip1.FindTabByText("View");
            tab.Selected = true;
            RadMultiPage1.SelectedIndex = 0;
            try
            {

                int result = 0;
                pObj.Idno = Convert.ToInt32(txtIDno.Text);
                pObj.EILType = hdnMode.Value;
                pObj.CoveredByProject = 0;
                //if (ddlCategory.SelectedItem.Text != "--select category--")
                //{
                //    pObj.Category = ddlCategory.SelectedItem.Value;
                //}
                if (rdbCoveredByYes.Checked)
                {
                    pObj.CoveredByProject = Convert.ToInt32(rdbCoveredByYes.ToolTip);

                }
                else
                {
                    if (rdbCoveredByNo.Checked)
                    {
                        pObj.CoveredByProject = Convert.ToInt32(rdbCoveredByNo.ToolTip);

                    }
                }
                if (ddlOpenBy.SelectedItem.Text != "-Select-")
                {
                    mObj.OpenBy = Convert.ToString(ddlOpenBy.SelectedValue);
                }
                else
                {
                    mObj.OpenBy = null;
                }
                if (RadOpenDate.SelectedDate != null)
                {
                    pObj.OpenDate = Convert.ToString(RadOpenDate.SelectedDate);
                }
                if (ddlRequestedBy.SelectedItem.Text != "-Select-")
                {
                    mObj.RequestedBy = Convert.ToString(ddlRequestedBy.SelectedValue);
                }
                else
                {
                    mObj.RequestedBy = Convert.ToString(DBNull.Value);
                }
                if (ddlResponsiblePerson.SelectedItem.Text != "-Select-")
                {
                    mObj.ResponsiblePerson = Convert.ToString(ddlResponsiblePerson.SelectedValue);
                }
                else
                {
                    mObj.ResponsiblePerson = Convert.ToString(DBNull.Value);
                }
                if (ddlInspector.SelectedItem.Text != "-Select-")
                {
                    mObj.Inspector = Convert.ToString(ddlInspector.SelectedValue);
                }
                else
                {
                    mObj.Inspector = Convert.ToString(DBNull.Value);
                }
                if (ddlSignedBy.SelectedItem.Text != "-Select-")
                {
                    mObj.SignedBy = Convert.ToString(ddlSignedBy.SelectedValue);
                }
                else
                {
                    mObj.SignedBy = Convert.ToString(DBNull.Value);
                }
                if (ddlEnteredBy.SelectedItem.Text != "-Select-")
                {
                    mObj.EnteredBy = Convert.ToString(ddlEnteredBy.SelectedValue);

                }
                else
                {
                    mObj.EnteredBy = Convert.ToString(DBNull.Value);
                }

                if (RadEnteredDate.SelectedDate != null)
                {
                    pObj.EnteredDt = Convert.ToString(RadEnteredDate.SelectedDate);
                }
                if (ddlDiscipline.SelectedItem.Text != "-Select-")
                {
                    pObj.Discipline = Convert.ToString(ddlDiscipline.SelectedValue);
                }
                else
                {
                    pObj.Discipline = Convert.ToString(DBNull.Value);
                }
                pObj.ItemDescription = txtItemDescription.Text;
                if (ddlLocation.SelectedItem.Text != "-Select-")
                {
                    pObj.Location = Convert.ToString(ddlLocation.SelectedValue);
                }
                else
                {
                    pObj.Location = Convert.ToString(DBNull.Value);
                }
                if (ddlArea.SelectedItem.Text != "-Select-")
                {
                    pObj.Area = Convert.ToString(ddlArea.SelectedValue);
                }
                else
                {
                    pObj.Area = Convert.ToString(DBNull.Value);
                }
                if (ddlUnit.SelectedItem.Text != "-Select-")
                {
                    pObj.Unit = Convert.ToString(ddlUnit.SelectedValue);
                }
                else
                {
                    pObj.Unit = Convert.ToString(DBNull.Value);
                }
                if (ddlPlant.SelectedItem.Text != "-Select-")
                {
                    pObj.Plant = Convert.ToString(ddlPlant.SelectedValue);
                }
                else
                {
                    pObj.Plant = Convert.ToString(DBNull.Value);
                }
                if (RadScheduleCompletionDate.SelectedDate != null)
                {
                    pObj.ScheduledDateCompletion = Convert.ToString(RadScheduleCompletionDate.SelectedDate);
                }
                if (RadRFIDate.SelectedDate != null)
                {
                    pObj.RFIDate = Convert.ToString(RadRFIDate.SelectedDate);
                }

                pObj.RFINo = txtRFINo.Text;
                pObj.Sheet = txtSheet.Text;
                pObj.Drawing = txtDrawing.Text;
                if (ddlFailCategory.SelectedItem.Text != "-Select-")
                {

                    pObj.FailCategory = Convert.ToString(ddlFailCategory.SelectedValue);

                }
                else
                {
                    pObj.FailCategory = Convert.ToString(DBNull.Value);
                }
               
                if (ddlSystem.SelectedItem.Text != "-Select-")
                {
                    pObj.System = Convert.ToString(ddlSystem.SelectedValue);
                }
                else
                {
                    pObj.System = Convert.ToString(DBNull.Value);
                }
                if (ddlSubsystem.SelectedItem.Text != "-Select-")
                {
                    pObj.Subsystem = Convert.ToString(ddlSubsystem.SelectedValue);
                }
                else
                {

                    pObj.Subsystem = Convert.ToString(DBNull.Value);
                }

                string val = null;
                pObj.QueryRevision = string.IsNullOrEmpty(val) ? '0' : Convert.ToInt32(txtQueryRevision.Text);
                pObj.Reference = txtReference.Text;
                if (RadReferenceDate.SelectedDate != null)
                {
                    pObj.ReferenceDate = Convert.ToString(RadReferenceDate.SelectedDate);
                }
                pObj.Revison = txtRevision.Text;
                if (RadCompletionDate.SelectedDate != null)
                {
                    pObj.CompletionDate = Convert.ToString(RadCompletionDate.SelectedDate);
                }
                pObj.CompletionRemarks = txtCompletionRemarks.Text;
                if (ddlControlSystem.SelectedItem.Text != "-Select-")
                {
                    pObj.ControlSystem = Convert.ToString(ddlControlSystem.SelectedValue);
                }
                else
                {
                    pObj.ControlSystem = Convert.ToString(DBNull.Value);
                }

                if (ddlOrganization.SelectedItem.Text != "-Select-")
                {
                    pObj.Organization = Convert.ToString(ddlOrganization.SelectedValue);
                }
                else
                {
                    pObj.Organization = Convert.ToString(DBNull.Value);
                }
               
                if (ddlActionBy.SelectedItem.Text != "-Select-")
                {
                    pObj.ActionBy = Convert.ToString(ddlActionBy.SelectedValue);
                }
                else
                {
                    pObj.ActionBy = Convert.ToString(DBNull.Value);

                }
                pObj.ChangeReq = 0;
                if (rdbChangeRequestyes.Checked)
                {
                    pObj.ChangeReq = Convert.ToInt32(rdbChangeRequestyes.ToolTip);

                }
                else
                {
                    if (rdbchangerequestno.Checked)
                    {
                        pObj.CoveredByProject = Convert.ToInt32(rdbchangerequestno.ToolTip);

                    }
                }
                pObj.EILType = lblTypeNeed.Text;
                if ((ddlModule.Text != "") && (ddlModule.Text != null))
                {
                    pObj.moduleId = ddlModule.SelectedItem.Value;
                }
                if ((ddlCategory.Text != "") && (ddlCategory.Text != null))
                {
                    pObj.category = ddlCategory.SelectedItem.Value;
                    pObj.categoryDesc = ddlCategory.SelectedItem.Text;
                }
                if (radTagNo.Text != "")
                {
                    pObj.linkId = radTagNo.Text;
                }

                try
                {
                    result = pObj.EILInsertWithoutTrackingDetails(mObj);
                    
                    var page = HttpContext.Current.CurrentHandler as Page;
                    var master = page.Master;
                    eObj.InsertionSuccessData(page);
                    dtgManageProjectGrid.Rebind();

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
                RadTab tab1 = (RadTab)RadTabStrip1.FindTabByValue("1");
                RadTab tab2 = (RadTab)RadTabStrip1.FindTabByValue("2");
                tabs.ResetTabCaptions(tab1, tab2);
                RadMultiPage1.SelectedIndex = 0;
            }
        }
        #endregion InserEil

        #region LoadComboBox
        /// <summary>
        /// Method to fill in all comboboxes
        /// </summary>
        public void LoadComboBox()
        {

            FlyCnDAL.PunchList pObj = new FlyCnDAL.PunchList();

            dt = mObj.GetDEtailsFromPersonal();

            ddlOpenBy.DataSource = dt;
            ddlOpenBy.DataTextField = "Name";
            ddlOpenBy.DataValueField = "Code";
            ddlOpenBy.DataBind();
            ddlOpenBy.Items.Insert(0, new ListItem("-Select-", "NULL"));

            ddlEnteredBy.DataSource = dt;
            ddlEnteredBy.DataTextField = "Name";
            ddlEnteredBy.DataValueField = "Code";
            ddlEnteredBy.DataBind();
            ddlEnteredBy.Items.Insert(0, new ListItem("-Select-", "NULL"));

            ddlRequestedBy.DataSource = dt;
            ddlRequestedBy.DataTextField = "Name";
            ddlRequestedBy.DataValueField = "Code";
            ddlRequestedBy.DataBind();
            ddlRequestedBy.Items.Insert(0, new ListItem("-Select-", "NULL"));

            ddlInspector.DataSource = dt;
            ddlInspector.DataTextField = "Name";
            ddlInspector.DataValueField = "Code";
            ddlInspector.DataBind();
            ddlInspector.Items.Insert(0, new ListItem("-Select-", "Null"));

            ddlResponsiblePerson.DataSource = dt;
            ddlResponsiblePerson.DataTextField = "Name";
            ddlResponsiblePerson.DataValueField = "Code";
            ddlResponsiblePerson.DataBind();
            ddlResponsiblePerson.Items.Insert(0, new ListItem("-Select-", "Null"));


            ddlSignedBy.DataSource = dt;
            ddlSignedBy.DataTextField = "Name";
            ddlSignedBy.DataValueField = "Code";
            ddlSignedBy.DataBind();
            ddlSignedBy.Items.Insert(0, new ListItem("-Select-", "Null"));
            DataTable dtp = new DataTable();
            dtp = pObj.GetPlatFromM_Plant();
            ddlPlant.DataSource = dtp;
            ddlPlant.DataTextField = "Description";
            ddlPlant.DataValueField = "Code";
            ddlPlant.DataBind();
            ddlPlant.Items.Insert(0, new ListItem("-Select-", "Null"));

            dt = pObj.GetAreaFromM_Area();
            ddlArea.DataSource = dt;
            ddlArea.DataTextField = "Description";
            ddlArea.DataValueField = "Code";
            ddlArea.DataBind();
            ddlArea.Items.Insert(0, new ListItem("-Select-", "Null"));

            dt = pObj.GetLocationFromM_Location();
            ddlLocation.DataSource = dt;
            ddlLocation.DataTextField = "Description";
            ddlLocation.DataValueField = "Code";
            ddlLocation.DataBind();
            ddlLocation.Items.Insert(0, new ListItem("-Select-", "Null"));

            dt = pObj.GetUnitFromM_Unit();
            ddlUnit.DataSource = dt;
            ddlUnit.DataTextField = "Description";
            ddlUnit.DataValueField = "Code";
            ddlUnit.DataBind();
            ddlUnit.Items.Insert(0, new ListItem("-Select-", "Null"));

            dt = pObj.GetUActionByFromM_Company();
            ddlActionBy.DataSource = dt;
            ddlActionBy.DataTextField = "CompName";
            ddlActionBy.DataValueField = "Code";
            ddlActionBy.DataBind();
            ddlActionBy.Items.Insert(0, new ListItem("-Select-", "Null"));


            dt = pObj.GetDisciplineFromM_Discipline();
            ddlDiscipline.DataSource = dt;
            ddlDiscipline.DataTextField = "Description";
            ddlDiscipline.DataValueField = "Code";
            ddlDiscipline.DataBind();
            ddlDiscipline.Items.Insert(0, new ListItem("-Select-", "Null"));

            dt = pObj.GetFailCategoryFromM_FailCategory();
            ddlFailCategory.DataSource = dt;
            ddlFailCategory.DataTextField = "Description";
            ddlFailCategory.DataValueField = "Code";
            ddlFailCategory.DataBind();
            ddlFailCategory.Items.Insert(0, new ListItem("-Select-", "Null"));


            dt = pObj.GetCategoryFromM_Category();
            ddlCategoryList.DataSource = dt;
            ddlCategoryList.DataTextField = "Description";
            ddlCategoryList.DataValueField = "Code";
            ddlCategoryList.DataBind();
            ddlCategoryList.Items.Insert(0, new ListItem("-Select-", "NULL"));

            dt = pObj.GetUActionByFromM_Company();
            ddlOrganization.DataSource = dt;
            ddlOrganization.DataTextField = "CompName";
            ddlOrganization.DataValueField = "Code";
            ddlOrganization.DataBind();
            ddlOrganization.Items.Insert(0, new ListItem("-Select-", "NULL"));

            dt = pObj.GetCTRLSystemDetails();
            ddlControlSystem.DataSource = dt;
            ddlControlSystem.DataTextField = "Description";
            ddlControlSystem.DataValueField = "Code";
            ddlControlSystem.DataBind();
            ddlControlSystem.Items.Insert(0, new ListItem("-Select-", "NULL"));

            dt = pObj.GetSystemDetails();
            ddlSystem.DataSource = dt;
            ddlSystem.DataTextField = "Description";
            ddlSystem.DataValueField = "Code";
            ddlSystem.DataBind();
            ddlSystem.Items.Insert(0, new ListItem("-Select-", "NULL"));

            dt = pObj.GetSubSystemDetails();
            ddlSubsystem.DataSource = dt;
            ddlSubsystem.DataTextField = "Description";
            ddlSubsystem.DataValueField = "Code";
            ddlSubsystem.DataBind();
            ddlSubsystem.Items.Insert(0, new ListItem("-Select-", "NULL"));

        }
        #endregion LoadComboBox

        #region Delete
        /// <summary>
        /// Method to do dellete functionality based on Projectno,id,type
        /// </summary>
        public void Delete()
        {
            string ID = Convert.ToString(txtIDno.Text);
            UIClasses.Const Const = new UIClasses.Const();
            FlyCnDAL.Security.UserAuthendication UA;
            HttpContext context = HttpContext.Current;
            UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
            string projno = UA.projectNo;
            string type = hdnMode.Value;
            int val = 0;
            val = pObj.DeleteEILAttach(ID, type);
            int result;
            result = pObj.DeleteEIL(projno, ID);
            dtgManageProjectGrid.Rebind();
            RadTab tab = (RadTab)RadTabStrip1.FindTabByText("View");
            tab.Selected = true;
            RadTab tab1 = (RadTab)RadTabStrip1.FindTabByText("Edit");
            tab1.Text = "New";
            RadMultiPage1.SelectedIndex = 0;
        }
        #endregion Delete

        #region EditDataCommand
        /// <summary>
        /// Method called during EditData command from grid.
        /// </summary>
        public void EditDataCommand()
        {


        }
        #endregion EditDataCommand

        #region FileUploadDelete
        /// <summary>
        /// Method to delelte the file attachment
        /// </summary>
        public void FileUploadDelete()
        {

            string save = Server.MapPath("~/Content/Fileupload/" + pObj.fileUpload);


            if (File.Exists(save))
            {
                bool deleteSuccess = false;
                File.Delete(save);
                deleteSuccess = true;
            }


            ToolBar.AddButton.Visible = false;
            ToolBar.SaveButton.Visible = false;
            ToolBar.UpdateButton.Visible = true;
            ToolBar.DeleteButton.Visible = true;
            grdFileUpload.Visible = true;
            string id = Convert.ToString(pObj.Idno);
            BindFileuploadGrid(id);
        }
        #endregion FileUploadDelete

        #region Download
        /// <summary>
        /// Method to download a file 
        /// </summary>
        /// <param name="file"></param>
        public void Download(string file)
        {
            string strExtenstion = Path.GetExtension(file);
            string File = Path.GetFileNameWithoutExtension(file);
            string path = ("~/Content/Fileupload/");
            if (strExtenstion == ".doc" || strExtenstion == ".docx")
            {
                Response.ContentType = "application/vnd.ms-word";
                Response.AddHeader("content-disposition",
                                                  "attachment;filename=" + file);
            }
            else if (strExtenstion == ".xls" || strExtenstion == ".xlsx")
            {
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("content-disposition",
                                                "attachment;filename=" + file);
            }
            else if (strExtenstion == ".txt" || strExtenstion == ".pdf")
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition",
                                               "attachment;filename=" + file);
            }

            string filepath = path + file;
            Response.TransmitFile(Server.MapPath(filepath));
            //WebRequest request = WebRequest.Create(filepath);
            //WebResponse response = request.GetResponse();
            //using (Stream responseStream = response.GetResponseStream())
            //{
            //    using (Stream fileStream =("~/Content/Fileupload/"))
            //    {
            //        byte[] buffer = new byte[4096];
            //        int bytesRead = responseStream.Read(buffer, 0, 4096);
            //        while (bytesRead > 0)
            //        {
            //            fileStream.Write(buffer, 0, bytesRead);
            //            DateTime nowTime = DateTime.UtcNow;

            //            bytesRead = responseStream.Read(buffer, 0, 4096);
            //        }
            //    }
            //}

        }



        #endregion Download

        #region Title
        void SetTitle()
        {

            try
            {

                if (hdnMode.Value == "WEIL")
                {
                    lblTitle.Text = "Construction Punch List";
                }
                else if (hdnMode.Value == "CEIL")
                {
                    lblTitle.Text = "Civil Punch List";
                }
                else if (hdnMode.Value == "QEIL")
                {
                    lblTitle.Text = "QC Punch List";
                }

            }
            catch (Exception)
            {


            }

        }
        #endregion Title
        #endregion Methods

        //--For Security purpose--- 
        #region SecurityCheck
        public void SecurityCheck()
        {
            string logicalObject = "ConstructionPunchList";

            FlyCnDAL.Security.PageSecurity PS = new Security.PageSecurity(logicalObject, this);

            if (PS.isWrite == true)
            {
                dtgManageProjectGrid.MasterTableView.GetColumn("ViewDetailColumn").Display = false;
                dtgManageProjectGrid.MasterTableView.GetColumn("DeleteColumn").Display = false;
            }
            else
                if (PS.isEdit == true)
                {
                    dtgManageProjectGrid.MasterTableView.GetColumn("ViewDetailColumn").Display = false;
                    dtgManageProjectGrid.MasterTableView.GetColumn("DeleteColumn").Display = false;
                }
                else if (PS.isAdd == true)
                {
                    dtgManageProjectGrid.MasterTableView.GetColumn("EditData").Display = false;
                }
                else if (PS.isRead == true)
                {
                    dtgManageProjectGrid.MasterTableView.GetColumn("ViewDetailColumn").Display = true;
                    dtgManageProjectGrid.MasterTableView.GetColumn("EditData").Display = false;
                    dtgManageProjectGrid.MasterTableView.GetColumn("DeleteColumn").Display = false;
                }

                else if (PS.isDenied == true)
                {
                    HttpContext.Current.Response.Redirect("~/General/UnderConstruction.aspx?cause=accessdenied", true);
                }
            if (PS.isDelete == true)
            {
                dtgManageProjectGrid.MasterTableView.GetColumn("DeleteColumn").Display = true;
            }

        }
        #endregion SecurityCheck

        #region btnsubmit_Click
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            ToolBar.AddButton.Visible = false;
            ToolBar.SaveButton.Visible = false;
            ToolBar.UpdateButton.Visible = true;
            ToolBar.DeleteButton.Visible = true;
            IdUc_FlyCnFileUpload.EILId = Convert.ToInt32(txtIDno.Text);
            IdUc_FlyCnFileUpload.EilType = lblEliTypeNum.Text;
            IdUc_FlyCnFileUpload.FileInsert();
            Rebind();
        }
        #endregion btnsubmit_Click

        #region Rebind()
        public void Rebind()
        {
            BindData(IdNo,EilType);
        }
        #endregion Rebind() 

        #region BindData()
        public void BindData(int id,string type)
        {

            DataTable ds = new DataTable();
            if (lblEliTypeNum.Text != "")
            {

                pObj.EILType = lblEliTypeNum.Text;
             //   int EILID =Convert.ToInt32(lblEliTypeNum.Text);
                //if (EILID != "")
                //{
                pObj.id =Convert.ToInt32(lblIDNum.Text);
                // boqObj.Type = _Type;
                //}
                ds = pObj.GetEIL_AttachDetails();
                int count = ds.Rows.Count;

                if (count == 0)
                {
                    Label1.Text = "No Attachments..!";
                }
                else
                {
                    Label1.Text = " ";
                }

                GridView1.DataSource = ds;

                try
                {
                    GridView1.DataBind();

                }
                catch (Exception)
                {

                }
            }
        }
        #endregion BindData()

        #region GridView1_SelectedIndexChanged
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable ds = new DataTable();
            pObj.EILType = EilType;
            string EILID = txtIDno.Text;
            if (EILID != "")
            {
                pObj.id = IdNo;
                // boqObj.Type = _Type;
            }
            ds = pObj.GetEIL_AttachDetails();
           
            Id = (Guid)GridView1.SelectedDataKey.Value;
            FileDownload(Id);
        }
        #endregion GridView1_SelectedIndexChanged

        #region FileDownload
        public void FileDownload(Guid Id)
        {

            SqlDataReader reader = null;

            if (Id != Guid.Empty)
            {
                string filePath = Server.MapPath("/Content/Fileupload/");
                string fileName = "";


                try
                {

                    //cmd = new SqlCommand();
                    //cmd.Connection = cntion.GetDBConnection(); ;
                    //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //cmd.CommandText = "GetEILAttachment";
                    //cmd.Parameters.Add("@AttachID", SqlDbType.UniqueIdentifier).Value = Id;
                    //reader = cmd.ExecuteReader();
                    reader = pObj.MakeFile(Id);
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            fileName = reader.GetString(1);
                            DALConstants constObj = new DALConstants();
                            constObj.Extensions.Replace(",", "");
                            string ext = System.IO.Path.GetExtension(filePath + fileName);
                            MakeFile(reader, fileName, filePath);
                            Download(fileName, filePath);

                        }
                    }//reader
                }

                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Dispose();
                    }
                }

            }

        }
        #endregion FileDownload

        #region Download
        public void Download(string fileName, string filePath)
        {
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
            Response.TransmitFile(filePath + fileName);
            // Response.End();
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        #endregion Download

        #region MakeFile
        public void MakeFile(SqlDataReader reader, string fileName, string filePath)
        {
            byte[] buffer = new byte[reader.GetBytes(reader.GetOrdinal("Image"), 0, null, 0, int.MaxValue)];
            reader.GetBytes(reader.GetOrdinal("Image"), 0, buffer, 0, int.MaxValue);

            System.IO.File.WriteAllBytes(filePath + fileName, buffer);
        }
        #endregion MakeFile

        #region GridView1_RowDeleting

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            //string dfd = GridView1.DataKeys[e.RowIndex].Values[1].ToString();
            Id = (Guid)GridView1.DataKeys[e.RowIndex].Value;
            pObj.DeleteEilByID(Id);
            Rebind();
       
        }

        #endregion GridView1_RowDeleting

        #region dtgManageProjectGrid_SelectedIndexChanged
        protected void dtgManageProjectGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        #endregion dtgManageProjectGrid_SelectedIndexChanged

        #region BindTagNo
        public RadComboBoxData GetTag(RadComboBoxContext context)
        {
            FlyCnDAL.PunchList punchObj = new FlyCnDAL.PunchList();
            string moduleId = ddlModule.SelectedItem.Value;
            string category = ddlCategory.SelectedItem.Value; 
            DataTable data = punchObj.GetTagNo(moduleId, category, context.Text);

            RadComboBoxData comboData = new RadComboBoxData();
            int itemOffset = context.NumberOfItems;
            int endOffset = Math.Min(itemOffset + ItemsPerRequest, data.Rows.Count);
            comboData.EndOfItems = endOffset == data.Rows.Count;

            List<RadComboBoxItemData> result = new List<RadComboBoxItemData>(endOffset - itemOffset);

            for (int i = itemOffset; i < endOffset; i++)
            {
                RadComboBoxItemData itemData = new RadComboBoxItemData();
                itemData.Text = data.Rows[i][punchObj.KeyField].ToString();
                result.Add(itemData);
            }

            comboData.Message = GetStatusMessage(endOffset, data.Rows.Count);

            comboData.Items = result.ToArray();
            return comboData;
        }
        #endregion BindTagNo

        #region ValidateIdNo
        [System.Web.Services.WebMethod]
        public static bool ValidateIdNo(int LogID,string EType)
        {
            int IdNo = LogID;
            string type = EType;
            FlyCnDAL.PunchList punchObj = new FlyCnDAL.PunchList();
            if (punchObj.ValidateIdNo(LogID,type))
            {
                return true;
            }
            return false;
        }
         [System.Web.Services.WebMethod(EnableSession=true)]
        public static RadComboBoxData GetAllTagNo(RadComboBoxContext context)
        {
             
            FlyCnDAL.PunchList punchObj = new FlyCnDAL.PunchList();
            string moduleId = HttpContext.Current.Session["module"].ToString();
            string category = HttpContext.Current.Session["category"].ToString();
            DataTable data = punchObj.GetTagNo(moduleId,category,context.Text);

            RadComboBoxData comboData = new RadComboBoxData();
            int itemOffset = context.NumberOfItems;
            int endOffset = Math.Min(itemOffset + ItemsPerRequest, data.Rows.Count);
            comboData.EndOfItems = endOffset == data.Rows.Count;

            List<RadComboBoxItemData> result = new List<RadComboBoxItemData>(endOffset - itemOffset);

            for (int i = itemOffset; i < endOffset; i++)
            {
                RadComboBoxItemData itemData = new RadComboBoxItemData();
                itemData.Text = data.Rows[i][punchObj.KeyField].ToString();
                result.Add(itemData);
            }

            comboData.Message = GetStatusMessage(endOffset, data.Rows.Count);

            comboData.Items = result.ToArray();
            return comboData;
        }
         [System.Web.Services.WebMethod]
        private static string GetStatusMessage(int offset, int total)
        {
            if (total <= 0)
                return "No matches";

            return String.Format("Items <b>1</b>-<b>{0}</b> out of <b>{1}</b>", offset, total);
        }
        #endregion ValidateIdNo

         #region BindDropdownCategory
         public void BindDropdownCategory()
         {
            if(ddlModule.Text!="" && ddlModule.Text!="-1")
            {
                DataTable dtmodules = null;
                FlyCnDAL.PunchList punchObj = new FlyCnDAL.PunchList();

                UIClasses.Const Const = new UIClasses.Const();
                FlyCnDAL.Security.UserAuthendication UA;
                HttpContext context = HttpContext.Current;
                UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
                string project = UA.projectNo;
                string moduleId = ddlModule.SelectedItem.Value;
                try
                {

                    dtmodules = new DataTable();
                    dtmodules = punchObj.GetAllCategory(project, moduleId);
                    ddlCategory.DataSource = dtmodules;
                    ddlCategory.DataTextField = "CategoryDesc";
                    ddlCategory.DataValueField = "Category";
                    ddlCategory.DataBind();
                    ddlCategory.Items.Insert(0, new ListItem("--select category--", "-1"));

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
         }
         #endregion BindDropdownCategory

         #region BindDropdownActivity
         public void BindDropdownActivity()
         {
             if (ddlModule.Text != "" && ddlModule.Text != "-1" && ddlCategory.Text != "" && ddlCategory.Text != "-1")
             {
                 DataTable dtActivity = null;
                 FlyCnDAL.PunchList punchObj = new FlyCnDAL.PunchList();

                 UIClasses.Const Const = new UIClasses.Const();
                 FlyCnDAL.Security.UserAuthendication UA;
                 HttpContext context = HttpContext.Current;
                 UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
                 string project = UA.projectNo;
                 string moduleId = ddlModule.SelectedItem.Value;
                 try
                 {
                     dtActivity = new DataTable();
                     string category = ddlCategory.SelectedItem.Value; 
                     dtActivity = punchObj.GetAllActivitiesFromSys_Activities(project, moduleId, category);

                     ddlActivity.DataSource = dtActivity;
                     ddlActivity.DataTextField = "FullDesc";
                     //ddlActivity.DataValueField = "ShortDesc";
                     ddlActivity.DataBind();
                     ddlActivity.Items.Insert(0, new ListItem("--select Activity--", "-1"));

                 }
                 catch (Exception ex)
                 {
                     throw ex;
                 }
             }
             else
             {
                 ddlActivity.Items.Insert(0, new ListItem("--select Activity--", "-1"));
             }
         }
         #endregion BindDropdownActivity
         #region ddlModule_SelectedIndexChanged
         protected void ddlModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtmodules = null;
            FlyCnDAL.PunchList punchObj = new FlyCnDAL.PunchList();
            
            UIClasses.Const Const = new UIClasses.Const();
            FlyCnDAL.Security.UserAuthendication UA;
            HttpContext context = HttpContext.Current;
            UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
             string project = UA.projectNo;
             string moduleId = ddlModule.SelectedItem.Value;
            try
            {
               
                dtmodules = new DataTable();
                dtmodules = punchObj.GetAllCategory(project,moduleId);
                ddlCategory.DataSource = dtmodules;
                ddlCategory.DataTextField = "CategoryDesc";
                ddlCategory.DataValueField = "Category";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("--select category--", "-1"));
               
            }
            catch(Exception ex)
            {
                throw ex;
            }
            radTagNo.Text = "";
        }
        #endregion ddlModule_SelectedIndexChanged

        #region BindDropDownModule
        public void BindDropDownModule()
        {
            FlyCnDAL.PunchList punchObj = new FlyCnDAL.PunchList();
            DataTable dt = new DataTable();
            dt = punchObj.GetAllModules();
            ddlModule.DataSource = dt;
            ddlModule.DataTextField = "ModuleDesc";
            ddlModule.DataValueField = "ModuleID";
            ddlModule.DataBind();
            ddlModule.Items.Insert(0, new ListItem("--select module--", "-1"));
           
        }
        #endregion BindDropDownModule

        #region ddlCategory_SelectedIndexChanged
        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtActivity = null;
            FlyCnDAL.PunchList punchObj = new FlyCnDAL.PunchList();

            UIClasses.Const Const = new UIClasses.Const();
            FlyCnDAL.Security.UserAuthendication UA;
            HttpContext context = HttpContext.Current;
            UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
            string project = UA.projectNo;
            string moduleId = ddlModule.SelectedItem.Value;
            try
            {
                dtActivity = new DataTable();
                string category = ddlCategory.SelectedItem.Value;
                dtActivity = punchObj.GetAllActivitiesFromSys_Activities(project, moduleId, category);

                ddlActivity.DataSource = dtActivity;
                ddlActivity.DataTextField = "FullDesc";
                ddlActivity.DataBind();
                ddlActivity.Items.Insert(0, new ListItem("--select Activity--", "-1"));

            }
            catch (Exception ex)
            {
                throw ex;

            }
            //try
            //{
            //    BindName();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

        }
        #endregion ddlCategory_SelectedIndexChanged

        protected void dtgManageProjectGrid_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("1");
            tab.Selected = true;
            RadTab tab2 = (RadTab)RadTabStrip1.FindTabByValue("2");
            tab2.Text = "New";
        }
    }
}
        
    
