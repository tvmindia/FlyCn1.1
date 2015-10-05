using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlyCn.Approvels
{
    public partial class CloseDocument : System.Web.UI.Page
    {
        string _id1;
        protected void Page_Load(object sender, EventArgs e)
        {
            _id1 = Request.QueryString["id"];
            //txtEmpCode.Text = _id1;
            hdfRevisionId.Value = _id1;
           lblrevisionid.Text = _id1;

        }
    }
}