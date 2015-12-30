using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using FlyCn.FlyCnDAL;
using Telerik.Web.UI;

namespace FlyCn.ExcelImport
{
    public partial class ImportStatusList : System.Web.UI.Page
    {
        string StatusID;
        FlyCnDAL.Security.UserAuthendication UA;
        UIClasses.Const Const = new UIClasses.Const();
       // string userName = "TestUser";
        protected void Page_Load(object sender, EventArgs e)
        {
            UA = (FlyCnDAL.Security.UserAuthendication)Session[Const.LoginSession];
            if (!IsPostBack)
            {
                BindData();
               
            }

        }
        public void BindData()
        {
            DataSet ds = new DataSet();

            //FlyCnDAL.ExcelImport detailsObj = new FlyCnDAL.ExcelImport();
            ImportFile detailsObj = new ImportFile();

            ds = detailsObj.getAllExcelImportDetails(UA.userName);
             
            RadGrid1.DataSource = ds.Tables[0];
            try
            {
                RadGrid1.DataBind();
            }
            catch (Exception)
            {

            }
        }

        protected void RadGrid1_ItemCommand(object source, GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    GridDataItem item = e.Item as GridDataItem;
                    string StatusId = item.GetDataKeyValue("Status_Id").ToString();
                    Response.Redirect("ImportStatus.aspx?StatusId=" + StatusId);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //protected void RadGrid1_ItemDataBound(object sender, RadMenuEventArgs e)
        //{
          
        //   // e.Item.NavigateUrl = "/ExcelImport/ImportErrorDetails.aspx?StatusID=" + StatusID;
        //}

        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem dataItem = (GridDataItem)e.Item;

                HyperLink lblVisitNo = (HyperLink)e.Item.FindControl("Error_Count1");
                if (lblVisitNo.Text!="0")
                {
                   // RadGrid1.MasterTableView = System.Drawing.Color.Blue;
                    GridDataItem item = e.Item as GridDataItem;
                    item["Error_Count"].ForeColor = System.Drawing.Color.Blue;
                    string StatusId = item.GetDataKeyValue("Status_Id").ToString();
                    //LinkButton lbk = (LinkButton)dataItem.FindControl("Error_Count1");
                    string id = lblVisitNo.Text;
                    lblVisitNo.NavigateUrl = "~/ExcelImport/ImportErrorDetails.aspx?StatusId=" + StatusId;
                   
                }
                else
                {

                }
            }
        }

        protected void RadGrid2_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem dataItem = (GridDataItem)e.Item;
                HyperLink lblVisitNo = (HyperLink)e.Item.FindControl("Error_Count1");
                if (lblVisitNo.Text!="0")
                {
                GridDataItem item = e.Item as GridDataItem;
                    string StatusId = item.GetDataKeyValue("Status_Id").ToString();
                    //LinkButton lbk = (LinkButton)dataItem.FindControl("Error_Count1");
                    lblVisitNo.NavigateUrl = "~/ExcelImport/ImportErrorDetails.aspx?StatusId=" + StatusId;
                }
            }
        }

        protected void RadGrid2_ItemCommand(object source, GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    GridDataItem item = e.Item as GridDataItem;
                    string StatusId = item.GetDataKeyValue("Status_Id").ToString();
                    Response.Redirect("ImportStatus.aspx?StatusId=" + StatusId);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            BindData();
        }

        protected void RadGrid2_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            BindCompletedDetails();
        }

        #region BindCompletedDetails()
        public void BindCompletedDetails()
        {
   
            //FlyCnDAL.ExcelImport detailsObj = new FlyCnDAL.ExcelImport();
            ImportFile detailsObj = new ImportFile();
            DataSet ds = new DataSet();
            ds = detailsObj.getDistictExcelImportDetailsByUserName(UA.userName);
            RadGrid2.DataSource = ds.Tables[0];
            try
            {
                RadGrid1.DataBind();
            }
            catch (Exception)
            {
            //throw;
            }
        }
        #endregion BindCompletedDetails()

        

    }
}