﻿using FlyCn.FlyCnDAL;
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

                dt = amObj.GetDocHeaderDetails(revid, type);
                lblDocumntNo.Text = Request.QueryString["Documentno"];
                lblDocumntNo.Attributes["style"] = "font-weight:bold;";
                lblType.Text = Request.QueryString["DocumentType"];
                lblType.Attributes["style"] = "font-weight:bold;";
                lblCreated.Text = Request.QueryString["CreatedBy"];
                lblCreated.Attributes["style"] = "font-weight:bold;";
                lblDate.Text = Request.QueryString["Createddate"];
                lblDate.Attributes["style"] = "font-weight:bold;";
                lblStatus.Text = "Gopika";
                lblClientDocNo.Text = "Gopika";
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

                    if (status == 1)
                    {
                        lblStatus.Text = "Closed";
                    }
                    else
                        if (status == 2)
                        {
                            lblStatus.Text = "Declined";
                        }
                        else
                            if (status == 3)
                            {
                                lblStatus.Text = "Rejected for Amendment";
                            }
                            else
                                if (status == 0)
                                {
                                    lblStatus.Text = "Draft";
                                }

                    lblStatus.Attributes["style"] = "font-weight:bold;";
                }

            }
            catch(Exception ex)
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
          //  string projectNum = Request.QueryString["ProjNum"];
          //  string revId = Request.QueryString["RevNum"];
            try
            {
                string type = "BOQ";
                DataTable dt;
                ApprovelMaster amObj = new ApprovelMaster();
                revid = hiddenFieldRevisionID.Value;
                dt = amObj.GetDocDetailList(revid, type);
                if (dt.Rows.Count > 0)
                {
                    dtDocDetailGrid.DataSource = dt;
                }
            }
            catch(Exception ex)
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
