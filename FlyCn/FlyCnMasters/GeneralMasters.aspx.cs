using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace FlyCn.FlyCnMasters
{
    public partial class GeneralMasters : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadLeftMenu();
        }


        public void LoadLeftMenu()
        {
            UIClasses.InputPages ip = new UIClasses.InputPages();
            FlyCnDAL.MasterData Masters = new FlyCnDAL.MasterData();

            RadTreeView tview = ip.FindLeftTree(this);
            Masters.BindTree(tview);
            ip.DefaultTreeNode(this, 0);

        }
    }
}