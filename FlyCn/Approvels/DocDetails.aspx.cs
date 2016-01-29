using FlyCn.FlyCnDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace FlyCn.Content.DocDetailView
{
    public partial class DocDetails : System.Web.UI.Page
    {
        ErrorHandling eObj = new ErrorHandling();
        UIClasses.Const Const = new UIClasses.Const();
        string revid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string projectNum = Request.QueryString["ProjNum"];
                string revId = Request.QueryString["RevNum"];
                string type = "BOQ";
                string revid = Request.QueryString["Revisionid"];
                hiddenFieldRevisionID.Value = revid;
                DataTable dt;
                ApprovelMaster amObj = new ApprovelMaster();
                ReviseDocument revObj=new ReviseDocument();
                dt = amObj.GetDocHeaderDetails(revid, type);
                lblDocumntNo.Text = Request.QueryString["Documentno"];
                lblDocumntNo.Attributes["style"] = "font-weight:bold;";
                lblType.Text = Request.QueryString["DocumentType"];
                lblType.Attributes["style"] = "font-weight:bold;";
                lblCreated.Text = Request.QueryString["CreatedBy"];
                lblCreated.Attributes["style"] = "font-weight:bold;";
                lblDate.Text = Request.QueryString["Createddate"];
                lblDate.Attributes["style"] = "font-weight:bold;";
                lblStatus.Text = Request.QueryString["LatestStatus"];
                lblStatus.Attributes["style"] = "font-weight:bold;";
                lblClientDocNo.Text = Request.QueryString["ClientDocNo"];
                lblClientDocNo.Attributes["style"] = "font-weight:bold;";
                if (dt.Rows.Count > 0)
                {
                    lblDocumntNo.Text = dt.Rows[0]["DocumentNo"].ToString();
                    string docnum = lblDocumntNo.Text;
                    lblDocumntNo.Attributes["style"] = "font-weight:bold;";
                    lblClientDocNo.Text = dt.Rows[0]["ClientDocNo"].ToString();
                    lblClientDocNo.Attributes["style"] = "font-weight:bold;";
                    lblType.Text = dt.Rows[0]["DocumentType"].ToString();
                    lblType.Attributes["style"] = "font-weight:bold;";
                    lblCreated.Text = dt.Rows[0]["CreatedBy"].ToString();
                    lblCreated.Attributes["style"] = "font-weight:bold;";
                    lblDate.Text = dt.Rows[0]["CreatedDate"].ToString();
                    lblDate.Attributes["style"] = "font-weight:bold;";
                    int status = Convert.ToInt32(dt.Rows[0]["LatestStatus"]);
                    List<KeyValuePair<String, int>> Docstatus = new List<KeyValuePair<string, int>>();
                    Docstatus = revObj.GetRevisionStatus();
                    foreach (var keyValuePair in Docstatus)
                    {
                        string value=keyValuePair.Key;
                        int key=keyValuePair.Value;
                        if (key == status)
                    {
                        lblStatus.Text = value;
                    }
                    else
                            if (key == status)
                        {
                            lblStatus.Text = value;
                        }
                        else
                                if (key == status)
                            {
                                lblStatus.Text = value;
                            }
                            else
                                    if (key == status)
                                {
                                    lblStatus.Text = value;
                                }
                }
                    lblStatus.Attributes["style"] = "font-weight:bold;";
                }

            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
            }
        }

        protected void dtDocDetailGrid_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }

        protected void dtDocDetailGrid_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
          
            try
            {
                string type = "BOQ";
                DataTable dt;
                ApprovelMaster amObj = new ApprovelMaster();
                revid = hiddenFieldRevisionID.Value;
                dt = amObj.GetDocDetailList(revid, type,"C00001");
                if (dt.Rows.Count > 0)
                {
                    dtDocDetailGrid.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
            }
        }

        protected void dtDocDetailGrid_PreRender(object sender, EventArgs e)
        {
            dtDocDetailGrid.Rebind();
        }

        protected void dtDocDetailGrid_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                foreach (GridColumn col in dtDocDetailGrid.MasterTableView.AutoGeneratedColumns)
                {
                    dtDocDetailGrid.MasterTableView.GetColumn("RevisionID").Display = false;
                    dtDocDetailGrid.MasterTableView.GetColumn("ProjectNo").Display = false;
                    if (col.DataType == typeof(DateTime))
                    {
                        ((GridDateTimeColumn)col).DataFormatString = "{0:dd/MM/yyyy}";
                    }
                }
            }
        }
    }
}
                
          
       

    
  
