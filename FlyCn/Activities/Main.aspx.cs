using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace FlyCn.Activities
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadLeftMenu();

        }


        public void LoadLeftMenu()
        {
            UIClasses.InputPages ip = new UIClasses.InputPages();
            FlyCnDAL.Activities Activity = new FlyCnDAL.Activities();

            RadTreeView tview = ip.FindLeftTree(this);
            Activity.BindTree(tview);


        }
    }
}