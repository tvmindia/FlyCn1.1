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
        FlyCnDAL.MasterPersonnelQualification pq = new FlyCnDAL.MasterPersonnelQualification();
        DataTable dtable = new DataTable();
   string  _id1;
        protected void Page_Load(object sender, EventArgs e)
        {
          _id1 = Request.QueryString["id"];
          //txtEmpCode.Text = _id1;
          HiddenField.Value = _id1;

        }
        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = pq.BindMastersPersonalQualification(_id1);
            RadGrid1.DataSource = dt;

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

          InsertData(); 
            // Add

          //Server.Transfer("Personal.aspx");

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
           
            string val = null;
            // mp.ProjectNo      = txt
            pq.EmpCode = _id1;
            pq.Qualification = txtQualification.Text;
            pq.QualificationType = txtQualificationType.Text;
            if (RadFirstQualifiedDate.SelectedDate != null)
            {
                pq.FirstQualifiedDate = Convert.ToString(RadFirstQualifiedDate.SelectedDate);
            }
            if (RadExpiryDate.SelectedDate != null)
            {
                pq.ExpiryDate = Convert.ToString(RadExpiryDate.SelectedDate);
            }

            if (RadDRenewedDate.SelectedDate != null)
            {
                pq.RenewedDate = Convert.ToString(RadDRenewedDate.SelectedDate);
            }
            pq.Remarks = txtRemarks.Text;
            string ProjNo = "C00001";
            int result = pq.InsertMasterPersonalQualificationData(ProjNo);
            RadGrid1.Rebind();
            RadTab tab = (RadTab)RadTabStrip1.FindTabByText("View");
            tab.Selected = true;
            //RadTab tab1 = (RadTab)RadTabStrip1.FindTabByText("Edit");
            //tab1.Text = "New";
            RadMultiPage1.SelectedIndex = 0;
            }
      
    
       protected void RadGrid1_ItemCommand(object source, GridCommandEventArgs e)
        {
            string ProjNo = "C00001";

            GridDataItem item = e.Item as GridDataItem;
            string strId = item.GetDataKeyValue("EmpCode").ToString();
            string Qualification = item.GetDataKeyValue("Qualification").ToString();
            if (e.CommandName == "Delete")
            {

                int result = pq.DeleteMasterPersonnelQualificationData(strId,Qualification,ProjNo);
                if (result == 1)
                {

                }


            }
            else if (e.CommandName == "EditData")
            {

                RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("2");
                tab.Selected = true;
                tab.Text = "Edit";
                tab.ImageUrl = "~/Images/Icons/editIcon.png";

                RadMultiPage1.SelectedIndex = 1;

                dtable = pq.FillMasterData(strId, Qualification,ProjNo);
                txtEmpCode.Text = dtable.Rows[0]["EmpCode"].ToString();
                txtQualification.Text = dtable.Rows[0]["Qualification"].ToString();
                txtQualificationType.Text = dtable.Rows[0]["QualificationType"].ToString();
                string FirstQualifiedDate = dtable.Rows[0]["FirstQualifiedDate"].ToString();
                if (FirstQualifiedDate != "")
                {
                    RadFirstQualifiedDate.SelectedDate = Convert.ToDateTime(FirstQualifiedDate);
                }
                string ExpiryDate =  dtable.Rows[0]["ExpiryDate"].ToString();

                if (ExpiryDate != "")
                {
                    RadExpiryDate.SelectedDate = Convert.ToDateTime(ExpiryDate);
                }
                string RenewedDate = dtable.Rows[0]["RenewedDate"].ToString();

                if (RenewedDate != "")
                {
                    RadDRenewedDate.SelectedDate = Convert.ToDateTime(RenewedDate);
                }
                txtRemarks.Text = dtable.Rows[0]["Remarks"].ToString(); ;

                ScriptManager.RegisterStartupScript(this, GetType(), "EditData", "UpdateFunction();", true);
          

            }
        }

       public void UpdateData()
       {
           string val = null;
    pq.EmpCode=txtEmpCode.Text;
    pq.Qualification=txtQualification.Text;
    pq.QualificationType=txtQualificationType.Text;
    pq.Remarks = txtRemarks.Text;
    if (RadFirstQualifiedDate.SelectedDate != null)

            {
                pq.FirstQualifiedDate = Convert.ToString(RadFirstQualifiedDate.SelectedDate);
            }
    if (RadExpiryDate.SelectedDate != null)
    {
        pq.ExpiryDate = Convert.ToString(RadExpiryDate.SelectedDate);
    }
    if (RadDRenewedDate.SelectedDate != null)
    {
        pq.RenewedDate= Convert.ToString(RadDRenewedDate.SelectedDate);
    }
           string ProjNo = "C00001";
           int result = pq.UpdateMasterPersonelQualificationData(ProjNo);
           //if (result == 1)
           //{
               RadGrid1.Rebind();
               RadTab tab = (RadTab)RadTabStrip1.FindTabByText("View");
               tab.Selected = true;
               RadTab tab1 = (RadTab)RadTabStrip1.FindTabByText("Edit");
               tab1.Text = "New";
               tab1.ImageUrl = "~/Images/Icons/NewIcon.png";

               RadMultiPage1.SelectedIndex = 0;

           //}

       }
    }

}