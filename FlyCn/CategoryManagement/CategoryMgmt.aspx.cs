using FlyCn.FlyCnDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace FlyCn.CategoryManagement
{
    public partial class CategoryMgmt : System.Web.UI.Page
    {
        DALConstants cnsObj = new DALConstants();
        UIClasses.InputPages ip = new UIClasses.InputPages();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            FlyCn.EIL.PunchList objPunchList = new FlyCn.EIL.PunchList();         
            FlyCnDAL.CategoryAllocation objCatAll = new FlyCnDAL.CategoryAllocation();
            FlyCn.FlyCnDAL.Modules moduleObj = new FlyCn.FlyCnDAL.Modules();
            RadTreeView tview = ip.FindLeftTree(this);
            //tview.Attributes.Add("onclick", "ClientNodeClicked(event)");

           // objCatAll.LoadRootNodes(tview,TreeNodeExpandMode.ServerSideCallBack);
            DataTable data = new DataTable();
            data = moduleObj.GetAllModuleAndCategory();
            tview.DataFieldParentID = "ModuleDesc";
            tview.DataTextField = "CategoryDesc";
            tview.DataValueField = "ModuleId";
            tview.DataFieldID = "Category";
            tview.DataSource = data;
            tview.DataBind();
            //foreach(RadTreeNode node in tview.Nodes)
            //{
            //    int count = node.GetAllNodes().Count;
            //    if(count==0)
            //    {
            //        node.Remove();
            //    }
            //}
           
            RadPane radpane = ip.FindContentPane(this);         
            objPunchList.LoadCategoryMgmtInputScreen(radpane);
            
            tview.NodeClick += new RadTreeViewEventHandler(Node_Click);
        }

        protected void Node_Click(object sender, RadTreeNodeEventArgs e)
        {
           string moduleId= e.Node.Value;
           string category = e.Node.Text;
           RadPane radpane = ip.FindContentPane(this);
           radpane.ContentUrl = cnsObj.AllocateCategory + "?ModuleId=" + moduleId+"&category="+category;
           e.Node.ExpandParentNodes();
           e.Node.Selected = true;
        }
    }
}