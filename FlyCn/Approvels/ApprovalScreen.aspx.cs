using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlyCn.Approvels
{
    public partial class ApprovalScreen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkbtnDetail_Click(object sender, EventArgs e)
        {
            Response.Redirect("/DocDetailView/DocDetails.aspx");
        }
    }
}