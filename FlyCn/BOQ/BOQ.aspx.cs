using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace FlyCn.BOQ
{
    public partial class BOQ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UIClasses.InputPages ip = new UIClasses.InputPages();
            FlyCnDAL.BOQHeaderDetails objBOQ = new FlyCnDAL.BOQHeaderDetails();

            RadTreeView tview = ip.FindLeftTree(this);
            objBOQ.BindTree(tview);

            RadPane radpane = ip.FindContentPane(this);
            objBOQ.LoadInputScreen(radpane);



        }
    }
}