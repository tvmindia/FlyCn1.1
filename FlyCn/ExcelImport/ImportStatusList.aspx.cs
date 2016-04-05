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
       // string StatusID;
        FlyCnDAL.Security.UserAuthendication UA;
        UIClasses.Const Const = new UIClasses.Const();
        // string userName = "TestUser";
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            UA = (FlyCnDAL.Security.UserAuthendication)Session[Const.LoginSession];
            if (!IsPostBack)
            {
                BindData();
               
            }

        }
        #endregion Page_Load

        #region BindData()
        public void BindData()
        {
            DataSet ds = new DataSet();
            ImportFile detailsObj = new ImportFile();
            ds = detailsObj.getAllExcelImportDetails(UA.userName,UA.projectNo);
            RadGrid1.DataSource = ds.Tables[0];
            try
            {
                RadGrid1.DataBind();
            }
            catch (Exception)
            {

            }
        }
        #endregion BindData

        #region RadGrid1_ItemCommand
        protected void RadGrid1_ItemCommand(object source, GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    GridDataItem item = e.Item as GridDataItem;
                    string StatusId = item.GetDataKeyValue("Status_Id").ToString();
                    //Response.Redirect("ImportStatus.aspx?StatusId=" + StatusId);
                    hdfselected_tab.Value = "4";
                    idimportdStatusIframe.Attributes["src"] = "ImportStatus.aspx?StatusId=" + StatusId;//loading import status page in iframe
                    //idimportdStatusIframe.Style["display"] = "block";//fdfdfdfdf
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion RadGrid1_ItemCommand
       
        #region RadGrid1_ItemDataBound
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
        #endregion RadGrid1_ItemDataBound

        #region RadGrid2_ItemDataBound
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
        #endregion RadGrid2_ItemDataBound

        #region RadGrid2_ItemCommand
        protected void RadGrid2_ItemCommand(object source, GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    GridDataItem item = e.Item as GridDataItem;
                    string StatusId = item.GetDataKeyValue("Status_Id").ToString();
                    //Response.Redirect("ImportStatus.aspx?StatusId=" + StatusId);
                    idimportdStatusIframe.Attributes["src"] = "ImportStatus.aspx?StatusId=" + StatusId;//loading import status page in iframe
                    hdfselected_tab.Value = "4";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ChangeTab", "ChangeTab();", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion RadGrid2_ItemCommand

        #region RadGrid1_NeedDataSource
        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            BindData();
        }
        #endregion RadGrid1_NeedDataSource

        #region RadGrid2_NeedDataSource
        protected void RadGrid2_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            BindCompletedDetails();
        }
        #endregion RadGrid2_NeedDataSource

        #region BindCompletedDetails()
        public void BindCompletedDetails()
        {
            ImportFile detailsObj = new ImportFile();
            DataSet ds = new DataSet();
            ds = detailsObj.getDistictExcelImportDetailsByUserName(UA.userName,UA.projectNo,true);
            RadGrid2.DataSource = ds.Tables[0];
            try
            {
                RadGrid1.DataBind();
            }
            catch (Exception)
            {
           
            }
        }
        #endregion BindCompletedDetails()

        #region BindAbortedDetails
        public void BindAbortedDetails()
        {
            ImportFile detailsObj = new ImportFile();
            DataSet ds = new DataSet();
            ds = detailsObj.getDistictExcelImportDetailsByUserName(UA.userName, UA.projectNo, false);
            RadGrid3.DataSource = ds.Tables[0];
            try
            {
              RadGrid1.DataBind();
            }
            catch (Exception)
            {
                //
            }
        }
        #endregion BindAbortedDetails

        protected void RadGrid3_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            BindAbortedDetails();
        }
        #region RadGrid3_ItemCommand
        protected void RadGrid3_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    GridDataItem item = e.Item as GridDataItem;
                    string StatusId = item.GetDataKeyValue("Status_Id").ToString();
                    //Response.Redirect("ImportStatus.aspx?StatusId=" + StatusId);
                    idimportdStatusIframe.Attributes["src"] = "ImportStatus.aspx?StatusId=" + StatusId;//loading import status page in iframe
                    hdfselected_tab.Value ="4";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ChangeTab", "ChangeTab();", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion RadGrid3_ItemCommand


    }
}