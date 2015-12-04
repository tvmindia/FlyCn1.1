using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace FlyCn.ExcelImport
{
    public partial class ExcelImport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UIClasses.InputPages ip = new UIClasses.InputPages();
            FlyCnDAL.ExcelImport objex = new FlyCnDAL.ExcelImport();

            RadTreeView tview = ip.FindLeftTree(this);
            objex.BindTree(tview);

            ip.DefaultTreeNode(this, 1);
        }
    }
}