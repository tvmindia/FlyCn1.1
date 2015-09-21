using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace FlyCn.EIL
{
    public partial class PunchList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadLeftMenu();
           
        }
        public void LoadLeftMenu()
        {
            UIClasses.InputPages ip = new UIClasses.InputPages();
            FlyCnDAL.PunchList PL = new FlyCnDAL.PunchList();

            RadTreeView tview = ip.FindLeftTree(this);
            PL.BindTree(tview);
            ip.DefaultTreeNode(this, 0);

        }
    }
}