using FlyCn.FlyCnDAL;
using FlyCn.UIClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using FlyCn.UserControls;
namespace FlyCn
{
    public partial class Personal : System.Web.UI.Page
    {
        #region Global Variables
        TabAddEditSettings tabs = new TabAddEditSettings();
        UIClasses.Const Const = new UIClasses.Const();
        FlyCnDAL.Security.UserAuthendication UA;
        FlyCnDAL.MasterPersonal materpersonnelobj = new FlyCnDAL.MasterPersonal();
        DataTable dtableobj = new DataTable();
        ErrorHandling eObj = new ErrorHandling();
        #endregion Global Variables

       

        #region  Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            UA = (FlyCnDAL.Security.UserAuthendication)Session[Const.LoginSession];
            ToolBar.onClick += new RadToolBarEventHandler(ToolBar_onClick);
            ToolBar.OnClientButtonClicking = "OnClientButtonClicking";
        }

        #endregion  Page_Load

        #region  ToolBar_onClick
        protected void ToolBar_onClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            string functionName = e.Item.Value;
            if (functionName == "Save")
            {


                InsertData();
                RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("1");
                RadTab tab1 = (RadTab)RadTabStrip1.FindTabByValue("2");
                // TabAddEditSettings tabs = new TabAddEditSettings();
                tabs.ResetTabCaptions(tab, tab1);
                RadMultiPage1.SelectedIndex = 0;

            }
            else if (functionName == "Update")
            {
                UpdateData();
            }
            else if (functionName == "Delete")
            {
                string code = txtCode.Text;
                int result = materpersonnelobj.DeleteMasterData(code);
                if (result == 1)
                {
                    dtgPersonnelGrid.Rebind();
                    RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("1");
                    RadTab tab1 = (RadTab)RadTabStrip1.FindTabByValue("2");

                    tabs.ResetTabCaptions(tab, tab1);
                    RadMultiPage1.SelectedIndex = 0;

                }
                else
                {
                    ToolBar.DeleteButton.Visible = false;
                    RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("1");
                    RadTab tab1 = (RadTab)RadTabStrip1.FindTabByValue("2");

                    tabs.ResetTabCaptions(tab, tab1);
                    RadMultiPage1.SelectedIndex = 0;

                }

            }

        }

        #endregion  ToolBar_onClick

        #region dtgPersonnelGrid_NeedDataSource

        protected void dtgPersonnelGrid_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

            DataTable dtable = new DataTable();

            dtable = materpersonnelobj.BindMastersPersonal();

            dtgPersonnelGrid.DataSource = dtable;


        }

        #endregion dtgPersonnelGrid_NeedDataSource

        #region  RadComboCompany_ItemsRequested
        protected void RadComboCompany_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {

            //RadComboCompany.Items.Clear();

            //DataTable dataTable = new DataTable();
            //dataTable = materpersonnelobj.GetCompanyComboBoxData();
            //foreach (DataRow dataRow in dataTable.Rows)
            //{
            //    RadComboBoxItem item = new RadComboBoxItem();
           
            //    item.Text = dataRow["CompName"].ToString();
            //    item.Value = dataRow["Code"].ToString();

            //    RadComboCompany.Items.Add(item);

            //    item.DataBind();
            //}
        }

        #endregion  RadComboCompany_ItemsRequested

        #region InsertData
        public void InsertData()
        {
            try
            {

                HiddenField hd = (MasterPopup).FindControl("hdnCode") as HiddenField;
                string hiddenCode = hd.Value;
                materpersonnelobj.Company = hiddenCode;
  
                string val = null;
              
               
                materpersonnelobj.Code = txtCode.Text;
                materpersonnelobj.Name = txtName.Text;

                //materpersonnelobj.Company = MasterPopup.selectedRowCode;

                materpersonnelobj.Emp_No = txtEmpNo.Text;
                materpersonnelobj.OTEligibleYN = Convert.ToByte(RadcomboSubcontract.SelectedValue);
                materpersonnelobj.Generic_Position = txtGenericPosition.Text;
                materpersonnelobj.Contract_Position = txtContractPosition.Text;
                materpersonnelobj.Discipline = txtDescipline.Text;
                materpersonnelobj.Emp_Category = txtCategory.Text;
                materpersonnelobj.HierachyPosition = txtHierarchyPosition.Text;
                materpersonnelobj.OwnEmployeeYN = Convert.ToByte(RadComboOTEligible.SelectedValue);
                materpersonnelobj.PassportNo = txtPassportNo.Text;
                materpersonnelobj.Nationality = txtNationality.Text;

                materpersonnelobj.Updated_By = UA.userName;

                if (!String.IsNullOrEmpty(txtWorkHours.Text))
                {
                    materpersonnelobj.WorkHours = Convert.ToDecimal(txtWorkHours.Text);
                }
                else
                {
                    materpersonnelobj.WorkHours = 0;
                }
                if (RadStartDate.SelectedDate != null)
                {
                    materpersonnelobj.DateStarted = Convert.ToString(RadStartDate.SelectedDate);
                }
                if (RadEndDate.SelectedDate != null)
                {
                    materpersonnelobj.DateFinished = Convert.ToString(RadEndDate.SelectedDate);
                }
                materpersonnelobj.Remarks = txtRemarks.Text;
                string projectNo = UA.projectNo;
                int result = materpersonnelobj.InsertMasterData(projectNo);
                dtgPersonnelGrid.Rebind();

                RadTab tab = (RadTab)RadTabStrip1.FindTabByText("View");
                tab.Selected = true;
                RadMultiPage1.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ToolBar.AddButton.Visible = false;
                ToolBar.SaveButton.Visible = true;
                ToolBar.UpdateButton.Visible = false;
                ToolBar.DeleteButton.Visible = false;
                RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("1");
                RadTab tab1 = (RadTab)RadTabStrip1.FindTabByValue("2");
                tabs.ResetTabCaptions(tab, tab1);
                RadMultiPage1.SelectedIndex = 0;
                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.ErrorData(ex, page);
            }
        }

        #endregion InsertData

        #region  dtgPersonnelGrid_ItemCommand
        protected void dtgPersonnelGrid_ItemCommand(object source, GridCommandEventArgs e)
        {
           
                GridDataItem item = e.Item as GridDataItem;
                if (item != null)
                {
                string strId = item.GetDataKeyValue("Code").ToString();
                if (e.CommandName == "Delete")
                {
                    int result = materpersonnelobj.DeleteMasterData(strId);


                }
                else if (e.CommandName == "EditData")
                {
                    //take tab name and change the tab text to Edit and change the New button icon to edit button icon
                    TabAddEditSettings tabs = new TabAddEditSettings();
                    RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("2");
                    tabs.EditTab(tab);
                    RadMultiPage1.SelectedIndex = 1;
                    ToolBar.AddButton.Visible = false;
                    ToolBar.SaveButton.Visible = false;
                    ToolBar.UpdateButton.Visible = true;
                    ToolBar.DeleteButton.Visible = true;

                    try
                    {
                        ContentIframe.Style["display"] = "";
                        DataTable dataTable = new DataTable();
                        dtableobj = materpersonnelobj.FillMasterData(strId);
                        txtCode.Text = dtableobj.Rows[0]["Code"].ToString();
                        //txtCode.ReadOnly = true;
                        txtCode.Enabled = false;
                        txtName.Text = dtableobj.Rows[0]["Name"].ToString();
                        RadComboOTEligible.Text = dtableobj.Rows[0]["OTEligibleYN"].ToString();
                        txtEmpNo.Text = dtableobj.Rows[0]["Emp_No"].ToString();
                        string CompanyId = dtableobj.Rows[0]["Company"].ToString();
                        if (CompanyId != "")
                        {
                            dataTable = materpersonnelobj.GetCompanyComboBoxDataById(CompanyId);

                            HiddenField hd = (MasterPopup).FindControl("hdnCode") as HiddenField;
                            hd.Value = dataTable.Rows[0]["Code"].ToString(); 
                           
                            TextBox txtBoxName = (MasterPopup).FindControl("txtName") as TextBox;
                            txtBoxName.Text = dataTable.Rows[0]["CompName"].ToString();
                            
                            //RadComboCompany.Text = dataTable.Rows[0]["CompName"].ToString();
                            //RadComboCompany.SelectedValue = dataTable.Rows[0]["Code"].ToString();

                        }
                        else
                        {
                            //RadComboCompany.Text = "";
                            TextBox txtBoxName = (MasterPopup).FindControl("txtName") as TextBox;
                            //string textBoxValue = txtBoxName.Text;
                            txtBoxName.Text = "";
                        }



                        txtWorkHours.Text = dtableobj.Rows[0]["WorkHours"].ToString();

                        txtCategory.Text = dtableobj.Rows[0]["Emp_Category"].ToString();

                        //txtUpdatedBy.Text = dtableobj.Rows[0]["Updated_By"].ToString();
                  

                        txtGenericPosition.Text = dtableobj.Rows[0]["Generic_Position"].ToString();
                        txtContractPosition.Text = dtableobj.Rows[0]["Contract_Position"].ToString();
                        txtDescipline.Text = dtableobj.Rows[0]["Discipline"].ToString();
                        txtHierarchyPosition.Text = dtableobj.Rows[0]["HierachyPosition"].ToString();
                        RadcomboSubcontract.Text = dtableobj.Rows[0]["OwnEmployeeYN"].ToString();
                        txtPassportNo.Text = dtableobj.Rows[0]["PassportNo"].ToString();
                        txtNationality.Text = dtableobj.Rows[0]["Nationality"].ToString();
                        string date = dtableobj.Rows[0]["DateStarted"].ToString();
                        if (date != "")
                        {
                            RadStartDate.SelectedDate = Convert.ToDateTime(date);
                        }
                        string enddate = dtableobj.Rows[0]["DateFinished"].ToString();
                        if (enddate != "")
                        {
                            RadEndDate.SelectedDate = Convert.ToDateTime(enddate);
                        }
                        txtRemarks.Text = dtableobj.Rows[0]["Remarks"].ToString();

                        //lblQualificationframe.Visible = true;

                        lblQualificationframe.Style["display"] = "none";
                        ContentIframe.Style["display"] = "";
                        ContentIframe.Attributes["src"] = "PersonnelQualification.aspx?id=" + strId;

                        //ContentIframe.Attributes["src"] = "PersonnelQualification.aspx?id=" + strId + "&updatedBy=" + UA.userName;

                        // ScriptManager.RegisterStartupScript(this, GetType(), "EditData", "UpdateFunction();", true);
                    }
                    catch (Exception ex)
                    {
                        var page = HttpContext.Current.CurrentHandler as Page;
                        var master = page.Master;
                        eObj.ErrorData(ex, page);

                    }

                }
            }
        }

        #endregion  dtgPersonnelGrid_ItemCommand

        #region  dtgPersonnelGrid_PreRender
        protected void dtgPersonnelGrid_PreRender(object sender, EventArgs e)
        {

            dtgPersonnelGrid.Rebind();
        }

        #endregion  dtgPersonnelGrid_PreRender

        #region  UpdateData
        public void UpdateData()
        {
            try
            {

                HiddenField hd = (MasterPopup).FindControl("hdnCode") as HiddenField;
                string hiddenCode = hd.Value;
                materpersonnelobj.Company = hiddenCode;

                materpersonnelobj.Code = txtCode.Text;
                materpersonnelobj.Name = txtName.Text;

                //materpersonnelobj.Company = RadComboCompany.SelectedValue;
               
                materpersonnelobj.Emp_No = txtEmpNo.Text;
                materpersonnelobj.OTEligibleYN = Convert.ToByte(RadcomboSubcontract.SelectedValue);
                materpersonnelobj.Generic_Position = txtGenericPosition.Text;
                materpersonnelobj.Contract_Position = txtContractPosition.Text;
                materpersonnelobj.Discipline = txtDescipline.Text;
                materpersonnelobj.Emp_Category = txtCategory.Text;
                materpersonnelobj.HierachyPosition = txtHierarchyPosition.Text;
                materpersonnelobj.OwnEmployeeYN = Convert.ToByte(RadComboOTEligible.SelectedValue);
                materpersonnelobj.PassportNo = txtPassportNo.Text;
                materpersonnelobj.Nationality = txtNationality.Text;

                materpersonnelobj.Updated_By = UA.userName;

                if (!String.IsNullOrEmpty(txtWorkHours.Text))
                {
                    materpersonnelobj.WorkHours = Convert.ToInt16(txtWorkHours.Text);
                }
                else
                {
                    materpersonnelobj.WorkHours = 0;
                }
                if (RadStartDate.SelectedDate != null)
                {
                    materpersonnelobj.DateStarted = Convert.ToString(RadStartDate.SelectedDate);
                }
                if (RadEndDate.SelectedDate != null)
                {
                    materpersonnelobj.DateFinished = Convert.ToString(RadEndDate.SelectedDate);
                }
                materpersonnelobj.Remarks = txtRemarks.Text;
                string ProjNo = UA.projectNo;
                int result = materpersonnelobj.UpdateMasterPersonel(ProjNo);

                ContentIframe.Style["display"] = "";
                //  lblQualificationframe.Style["display"] = "none";
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.ErrorData(ex, page);
            }
        }

        #endregion  UpdateData

    }
}