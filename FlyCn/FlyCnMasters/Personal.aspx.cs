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

namespace FlyCn
{
    public partial class Personal : System.Web.UI.Page
    {
        TabAddEditSettings tabs = new TabAddEditSettings();
        UIClasses.Const Const = new UIClasses.Const();
        FlyCnDAL.Security.UserAuthendication UA;
        FlyCnDAL.MasterPersonal mp = new FlyCnDAL.MasterPersonal();
        DataTable dtable = new DataTable();
        ErrorHandling eObj = new ErrorHandling();

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
            if(functionName=="Save")
            {

                
            InsertData();
            RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("1");
            RadTab tab1 = (RadTab)RadTabStrip1.FindTabByValue("2");
            // TabAddEditSettings tabs = new TabAddEditSettings();
            tabs.ResetTabCaptions(tab, tab1);
            RadMultiPage1.SelectedIndex = 0;

            }
            else if (functionName=="Update")
            {
                UpdateData();   
            }
         else if (functionName=="Delete")
            {
                string code = txtCode.Text;
                int result = mp.DeleteMasterData(code);
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

            DataTable dt = new DataTable();
      
            dt = mp.BindMastersPersonal();
        
            dtgPersonnelGrid.DataSource = dt;

        }
       
        #endregion dtgPersonnelGrid_NeedDataSource

        #region  RadComboCompany_ItemsRequested
        protected void RadComboCompany_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable = mp.GetCompanyComboBoxData();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                RadComboBoxItem item = new RadComboBoxItem();
                item.Text = dataRow["CompName"].ToString();
                item.Value = dataRow["Code"].ToString();
                RadComboCompany.Items.Add(item);
                item.DataBind();
            }
        }

        #endregion  RadComboCompany_ItemsRequested

        #region InsertData
        public void InsertData()
        {
            try
            {
                string val = null;
                mp.Code = txtCode.Text;
                mp.Name = txtName.Text;
                mp.Company = RadComboCompany.SelectedValue;
                mp.Emp_No = txtEmpNo.Text;
                mp.OTEligibleYN = Convert.ToByte(RadcomboSubcontract.SelectedValue);
                mp.Generic_Position = txtGenericPosition.Text;
                mp.Contract_Position = txtContractPosition.Text;
                mp.Discipline = txtDescipline.Text;
                mp.Emp_Category = txtCategory.Text;
                mp.HierachyPosition = txtHierarchyPosition.Text;
                mp.OwnEmployeeYN = Convert.ToByte(RadComboOTEligible.SelectedValue);
                mp.PassportNo = txtPassportNo.Text;
                mp.Nationality = txtNationality.Text;
                if (!String.IsNullOrEmpty(txtWorkHours.Text))
                {
                    mp.WorkHours = Convert.ToDecimal(txtWorkHours.Text);
                }
                else
                {
                    mp.WorkHours = 0;
                }
                if (RadStartDate.SelectedDate != null)
                {
                    mp.DateStarted = Convert.ToString(RadStartDate.SelectedDate);
                }
                if (RadEndDate.SelectedDate != null)
                {
                    mp.DateFinished = Convert.ToString(RadEndDate.SelectedDate);
                }
                mp.Remarks = txtRemarks.Text;
                string ProjNo = UA.projectNo;
                int result = mp.InsertMasterData(ProjNo);
                dtgPersonnelGrid.Rebind();

                RadTab tab = (RadTab)RadTabStrip1.FindTabByText("View");
                tab.Selected = true;
                RadMultiPage1.SelectedIndex = 0;
            }
            catch(Exception ex)
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
            string strId = item.GetDataKeyValue("Code").ToString();
            if (e.CommandName == "Delete")
            {
             int result = mp.DeleteMasterData(strId);
            
           
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
                    dtable = mp.FillMasterData(strId);
                    txtCode.Text = dtable.Rows[0]["Code"].ToString();
                    //txtCode.ReadOnly = true;
                    txtCode.Enabled = false;
                    txtName.Text = dtable.Rows[0]["Name"].ToString();
                    RadComboOTEligible.Text = dtable.Rows[0]["OTEligibleYN"].ToString();
                    txtEmpNo.Text = dtable.Rows[0]["Emp_No"].ToString();
                    string CompanyId = dtable.Rows[0]["Company"].ToString();
                    if (CompanyId != "")
                    {
                        dataTable = mp.GetCompanyComboBoxDataById(CompanyId);
                        RadComboCompany.Text = dataTable.Rows[0]["CompName"].ToString();
                    }
                    txtGenericPosition.Text = dtable.Rows[0]["Generic_Position"].ToString();
                    txtContractPosition.Text = dtable.Rows[0]["Contract_Position"].ToString();
                    txtDescipline.Text = dtable.Rows[0]["Discipline"].ToString();
                    txtHierarchyPosition.Text = dtable.Rows[0]["HierachyPosition"].ToString();
                    RadcomboSubcontract.Text = dtable.Rows[0]["OwnEmployeeYN"].ToString();
                    txtPassportNo.Text = dtable.Rows[0]["PassportNo"].ToString();
                    txtNationality.Text = dtable.Rows[0]["Nationality"].ToString();
                    string date = dtable.Rows[0]["DateStarted"].ToString();
                    if (date != "")
                    {
                        RadStartDate.SelectedDate = Convert.ToDateTime(date);
                    }
                    string enddate = dtable.Rows[0]["DateFinished"].ToString();
                    if (enddate != "")
                    {
                        RadEndDate.SelectedDate = Convert.ToDateTime(enddate);
                    }
                    txtRemarks.Text = dtable.Rows[0]["Remarks"].ToString();

                   //lblQualificationframe.Visible = true;

                  lblQualificationframe.Style["display"] = "";
                    ContentIframe.Style["display"] = "";
                   ContentIframe.Attributes["src"] = "PersonnelQualification.aspx?id=" + strId;

                   // ScriptManager.RegisterStartupScript(this, GetType(), "EditData", "UpdateFunction();", true);
                }
                catch(Exception ex)
                {
                    var page = HttpContext.Current.CurrentHandler as Page;
                    var master = page.Master;
                    eObj.ErrorData(ex, page);
               
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


               
                mp.Code = txtCode.Text;
                mp.Name = txtName.Text;
                mp.Company = RadComboCompany.SelectedValue;
                mp.Emp_No = txtEmpNo.Text;
                mp.OTEligibleYN = Convert.ToByte(RadcomboSubcontract.SelectedValue);
                mp.Generic_Position = txtGenericPosition.Text;
                mp.Contract_Position = txtContractPosition.Text;
                mp.Discipline = txtDescipline.Text;
                mp.Emp_Category = txtCategory.Text;
                mp.HierachyPosition = txtHierarchyPosition.Text;
                mp.OwnEmployeeYN = Convert.ToByte(RadComboOTEligible.SelectedValue);
                mp.PassportNo = txtPassportNo.Text;
                mp.Nationality = txtNationality.Text;
                if (!String.IsNullOrEmpty(txtWorkHours.Text))
                {
                    mp.WorkHours = Convert.ToInt16(txtWorkHours.Text);
                }
                else
                {
                    mp.WorkHours = 0;
                }
                if (RadStartDate.SelectedDate != null)
                {
                    mp.DateStarted = Convert.ToString(RadStartDate.SelectedDate);
                }
                if (RadEndDate.SelectedDate != null)
                {
                    mp.DateFinished = Convert.ToString(RadEndDate.SelectedDate);
                }
                mp.Remarks = txtRemarks.Text;
                string ProjNo = UA.projectNo;
                int result = mp.UpdateMasterPersonel(ProjNo);

                ContentIframe.Style["display"] ="none";
                lblQualificationframe.Style["display"] = "none";
            }
            catch(Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.ErrorData(ex, page);
            }
        }

        #endregion  UpdateData

    }
}