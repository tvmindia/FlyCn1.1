﻿using FlyCn.FlyCnDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlyCn.Content.DocDetailView
{
    public partial class DocDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string projectNum = Request.QueryString["ProjNum"];
            string revId = Request.QueryString["RevNum"];
            string type="BOQ";

        }

        protected void dtDocDetailGrid_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }

        protected void dtDocDetailGrid_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
          //  string projectNum = Request.QueryString["ProjNum"];
          //  string revId = Request.QueryString["RevNum"];
            string revid="d528a5a9-0049-41d3-b5bb-1bd02ee7f17d";
            string type = "BOQ";
            DataTable dt;
            DocDetailList dObj = new DocDetailList();
            dt=dObj.GetDocDetailList(revid,type);
            dtDocDetailGrid.DataSource = dt;         
        }

        protected void dtDocDetailGrid_PreRender(object sender, EventArgs e)
        {
            dtDocDetailGrid.Rebind();
        }

      

    
    }
}