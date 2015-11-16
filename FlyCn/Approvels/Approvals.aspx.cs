using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
 

namespace FlyCn.Approvels
{
    public partial class Approvals : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UIClasses.InputPages ip = new UIClasses.InputPages();
            FlyCnDAL.ApprovelMaster objApproval = new FlyCnDAL.ApprovelMaster();
            Telerik.Web.UI.RadTreeView tview = ip.FindLeftTree(this);
            objApproval.BindTree(tview);
            RadPane radpane = ip.FindContentPane(this);
            string logIDMail = Request.QueryString["logid"];
            if (logIDMail == null)
            {
                objApproval.LoadInputScreen(radpane);
            }
            if(logIDMail!=null)
            {
                objApproval.LoadInputScreen(radpane, logIDMail);
            }
        }
    }
}