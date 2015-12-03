using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace FlyCn.EngineeredDataList
{
    public partial class EnggDataList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
              UIClasses.InputPages ip = new UIClasses.InputPages();
              FlyCnDAL.EnggDataList objBOQ = new FlyCnDAL.EnggDataList();

            RadTreeView tview = ip.FindLeftTree(this);
            //tview.Attributes.Add("onclick", "ClientNodeClicked(event)");
           
            objBOQ.BindTree(tview);

            RadPane radpane = ip.FindContentPane(this);
            objBOQ.LoadInputScreen(radpane);
        }
    }
}