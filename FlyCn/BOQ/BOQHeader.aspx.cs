using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlyCn.BOQ
{
    public partial class BOQHeader : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //txtDocumentno.Text = "--no--";
        }
        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

            DataTable dt = new DataTable();

           // dt = mp.BindMastersPersonal();

            //RadGrid1.DataSource = dt;

        }

    }
}