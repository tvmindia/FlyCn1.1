using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlyCn.FlyCnMasters
{
    public partial class DynamicMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["Mode"] == null) { } else {
                lblmasterName.Text = Request.Params["Mode"].ToString();
            }
        }
    }
}