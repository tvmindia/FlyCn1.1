using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace FlyCn.CategoryManagement
{
    public partial class CategoryMgmt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UIClasses.InputPages ip = new UIClasses.InputPages();
            FlyCn.EIL.PunchList objPunchList = new FlyCn.EIL.PunchList();         
            FlyCnDAL.CategoryAllocation objCatAll = new FlyCnDAL.CategoryAllocation();

            RadTreeView tview = ip.FindLeftTree(this);
            //tview.Attributes.Add("onclick", "ClientNodeClicked(event)");

            objCatAll.LoadRootNodes(tview,TreeNodeExpandMode.ServerSideCallBack);

            RadPane radpane = ip.FindContentPane(this);
           
            objPunchList.LoadCategoryMgmtInputScreen(radpane);
        }
    }
}