using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace FlyCn.FlycnSecurity
{
    public partial class Object : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadLeftMenu();
        }

        public void LoadLeftMenu()
        {
            UIClasses.InputPages ip = new UIClasses.InputPages();
            FlyCnDAL.ObjectRegistration objRegstr = new FlyCnDAL.ObjectRegistration();
            RadTreeView tview = ip.FindLeftTree(this);
            objRegstr.BindTree(tview);
            ip.DefaultTreeNode(this, 0);

        }
    }
}