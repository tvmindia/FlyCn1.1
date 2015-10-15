using System;
using System.Collections.Generic;
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

        }

        protected void dtDocDetailGrid_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }

        protected void dtDocDetailGrid_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
               
            
        }

      

    
    }
}