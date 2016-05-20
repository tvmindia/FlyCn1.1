using FlyCn.FlyCnDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace FlyCn.WorkPacks
{
    public partial class WorkPacks : System.Web.UI.Page
    {
        DALConstants cnsObj = new DALConstants();
        protected void Page_Load(object sender, EventArgs e)
        {
                UIClasses.InputPages ip = new UIClasses.InputPages();
                RadPane radpane = ip.FindContentPane(this);
                radpane.ContentUrl = cnsObj.ConstructionWorkPacks;
        }
    }
}