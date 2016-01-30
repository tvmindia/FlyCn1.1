using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlyCn.FlycnSecurity
{
    public partial class AssignRoles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void dtgCurrentRoles_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if (dtgCurrentRoles.DataSource == null)
            {
                dtgCurrentRoles.DataSource = new string[] { };
            }  
        }

        protected void dtgAssignRoles_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if (dtgAssignRoles.DataSource == null)
            {
                dtgAssignRoles.DataSource = new string[] { };
            }  
        }


    }
}