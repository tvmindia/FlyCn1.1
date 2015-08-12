using FlyCn.FlyCnDAL;
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
        FlyCnDAL.MasterPersonal mp = new FlyCnDAL.MasterPersonal();
        DataTable dtable = new DataTable();
        ErrorHandling eObj = new ErrorHandling();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

            DataTable dt = new DataTable();
            dt = mp.BindMastersPersonal();
            RadGrid1.DataSource = dt;

        }

        protected void RadComboBox2_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable = mp.GetComboBoxDetails();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                RadComboBoxItem item = new RadComboBoxItem();
                item.Text = (string)dataRow["CompName"];
                item.Value = dataRow["Code"].ToString();
                RadComboBox2.Items.Add(item);
                item.DataBind();
            }
        }     
        protected void Button2_Click(object sender, EventArgs e)
        {
          
            InsertData();
            //foreach (GridDataItem item in RadGrid1.MasterTableView.Items)
            //{

            //    string value = item.GetDataKeyValue("Code").ToString();

            //    ContentIframe.Attributes["src"] = "PersonnelQualification.aspx?id=" + value;

            //}
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //RadTab tab = (RadTab)RadTabStrip1.FindTabByText("Edit");
            ////  tab.Selected = false;
            //tab.Text = "New";
            //RadTabStrip1.SelectedIndex = 0;
            UpdateData();
        }
        public void InsertData()
        {
            try
            {


                string val = null;
                mp.Code = txtCode.Text;
                mp.Name = txtName.Text;
                mp.Company = RadComboBox2.SelectedValue;
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
                if (RadDatePicker1.SelectedDate != null)
                {
                    mp.DateStarted = Convert.ToString(RadDatePicker1.SelectedDate);
                }
                if (RadEndDate.SelectedDate != null)
                {
                    mp.DateFinished = Convert.ToString(RadEndDate.SelectedDate);
                }
                mp.Remarks = txtRemarks.Text;
                string ProjNo = "C00001";
                int result = mp.InsertMasterData(ProjNo);
                RadGrid1.Rebind();
                RadTab tab = (RadTab)RadTabStrip1.FindTabByText("View");
                tab.Selected = true;
                RadMultiPage1.SelectedIndex = 0;

            }
            catch(Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.ErrorData(ex, page);
            }
        }
        protected void RadGrid1_ItemCommand(object source, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            string strId = item.GetDataKeyValue("Code").ToString();
            if (e.CommandName == "Delete")
            {
             int result = mp.DeleteMasterData(strId);
                if (result == 1)
                {

                }
            }
            else if (e.CommandName == "EditData")
            {
                RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("2");
                tab.Selected = true;
                tab.Text = "Edit";
                RadMultiPage1.SelectedIndex = 1;
              
                try
                {

                    ContentIframe.Visible = true;
                    DataTable dataTable = new DataTable();
                    dtable = mp.FillMasterData(strId);
                    txtCode.Text = dtable.Rows[0]["Code"].ToString();
                    txtCode.ReadOnly = true;
                    txtName.Text = dtable.Rows[0]["Name"].ToString();
                    RadComboOTEligible.Text = dtable.Rows[0]["OTEligibleYN"].ToString();
                    txtEmpNo.Text = dtable.Rows[0]["Emp_No"].ToString();
                    string CompanyId = dtable.Rows[0]["Company"].ToString();
                    if (CompanyId != "")
                    {
                        dataTable = mp.GetComboBoxDetailsById(CompanyId);
                        RadComboBox2.Text = dataTable.Rows[0]["CompName"].ToString();
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
                        RadDatePicker1.SelectedDate = Convert.ToDateTime(date);
                    }
                    string enddate = dtable.Rows[0]["DateFinished"].ToString();
                    if (enddate != "")
                    {
                        RadEndDate.SelectedDate = Convert.ToDateTime(enddate);
                    }
                    txtRemarks.Text = dtable.Rows[0]["Remarks"].ToString();

                
                   ContentIframe.Attributes["src"] = "PersonnelQualification.aspx?id=" + strId;

                    ScriptManager.RegisterStartupScript(this, GetType(), "EditData", "UpdateFunction();", true);
                }
                catch(Exception ex)
                {
                    var page = HttpContext.Current.CurrentHandler as Page;
                    var master = page.Master;
                    eObj.ErrorData(ex, page);
               
                }
       
            }         
        }
    
        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
            //if (e.Item is GridEditFormItem && e.Item.IsInEditMode)
            //{
              //  GridEditFormItem item = (GridEditFormItem)e.Item;
             //   BoundField someField = new BoundField();
                //someField.DataField = "Price";
                //someField.DataFormatString = "{0:c}"; 
            //e.Item.bo

            //if (e.Item is GridDataItem && e.Item.OwnerTableView.DataSourceID == "dsNotes")
            //{
            //    GridDataItem dataItem = e.Item as GridDataItem;
            //    TableCell cell = dataItem["NoteText"];
            //}
            //if (e.Item is GridDataItem)
            //{
            //    GridDataItem dataItem = e.Item as GridDataItem;
            //       TableCell cell =dataItem["DateStarted"];
            //       //string dateformat = (RadGrid1.MasterTableView.GetColumn("DateStarted") as GridDateTimeColumn).DataFormatString;
            //       //cell = "dd/MMM/yyyy";
               
            //}
            //if (e.Item is GridDataItem)
            //{
            //    GridDataItem item = (GridDataItem)e.Item;
            //   // string dateformat = (RadGrid1.MasterTableView.GetColumn("DateStarted") as GridDateTimeColumn).DataFormatString;
            //   //var value = DataBinder.Eval(item.DataItem, dateformat, "dd/MMM/yyyy");
                
            //}

            if (e.Item is GridDataItem)
            {
                //Get the instance of the right type
                GridDataItem dataBoundItem = e.Item as GridDataItem;
                dataBoundItem["DateStarted"].Style.Add("DisplayDateFormat", "dd/MMM/yyyy");

            }
                //string dateformat = (RadGrid1.MasterTableView.GetColumn("DateStarted") as GridDateTimeColumn).DataFormatString;
                //RadDatePicker1.DateInput.DateFormat = "dd/MMM/yyyy";

            //}
        }
        protected void RadGrid1_ColumnCreating(object sender, GridColumnCreatingEventArgs e)
        {
            if (e.Column.UniqueName == null)
            {
               // e.Column = new MyCustomFilteringColumn();
            }
        }
        protected void RadGrid1_DataBinding(object sender, EventArgs e)
        {
            foreach (GridColumn col in RadGrid1.MasterTableView.RenderColumns)
            {
                if (col is GridDateTimeColumn)
                {
                    ((GridDateTimeColumn)col).DataFormatString = "{0:yyyy MM}";
                }
            }
        }
        //protected void RadDatePicker1_SelectedDateChanged1(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        //{
        //    DateTime dt = Convert.ToDateTime(RadDatePicker1.SelectedDate);
        //    string temp = dt.ToShortDateString();
        //}

        public void UpdateData()
        {
            try
            {


                string val = null;
                mp.Code = txtCode.Text;
                mp.Name = txtName.Text;
                mp.Company = RadComboBox2.SelectedValue;
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
                if (RadDatePicker1.SelectedDate != null)
                {
                    mp.DateStarted = Convert.ToString(RadDatePicker1.SelectedDate);
                }
                if (RadEndDate.SelectedDate != null)
                {
                    mp.DateFinished = Convert.ToString(RadEndDate.SelectedDate);
                }
                mp.Remarks = txtRemarks.Text;
                string ProjNo = "C00001";
                int result = mp.UpdateMasterPersonel(ProjNo);
                if (result == 1)
                {
                    RadGrid1.Rebind();
                    RadTab tab = (RadTab)RadTabStrip1.FindTabByText("View");
                    tab.Selected = true;
                    RadTab tab1 = (RadTab)RadTabStrip1.FindTabByText("Edit");
                    tab1.Text = "New";
                    RadMultiPage1.SelectedIndex = 0;

                }
                ContentIframe.Visible = false;
            }
            catch(Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.ErrorData(ex, page);
            }
        }
    }
}