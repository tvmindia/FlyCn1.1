using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace FlyCn.Templates
{
    public partial class InputTemplate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UIClasses.InputPages ip = new UIClasses.InputPages();
            FlyCnDAL.Template objBOQ = new FlyCnDAL.Template();

            RadTreeView tview = ip.FindLeftTree(this);
            objBOQ.BindTree(tview);

            ip.DefaultTreeNode(this,1);
        }
    }
}