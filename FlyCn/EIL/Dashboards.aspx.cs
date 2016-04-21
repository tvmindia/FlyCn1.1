using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace FlyCn.EIL
{
    public partial class Dashboards : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            UIClasses.InputPages ip = new UIClasses.InputPages();
            FlyCn.EIL.PunchList objPunchList = new FlyCn.EIL.PunchList();
            FlyCnDAL.PunchList punchObj = new FlyCnDAL.PunchList();
           
            RadTreeView tview = ip.FindLeftTree(this);
            //tview.Attributes.Add("onclick", "ClientNodeClicked(event)");

            punchObj.BindTree(tview);
          
            RadPane radpane = ip.FindContentPane(this);
            objPunchList.LoadPunchListInputScreen(radpane);
        }
    }
}