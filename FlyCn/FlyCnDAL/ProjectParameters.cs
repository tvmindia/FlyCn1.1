using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Web.UI;


namespace FlyCn.FlyCnDAL
{
    public class ProjectParameters
    {
        public void BindTree(RadTreeView myTree)
        {
            myTree.Nodes.Clear();


            RadTreeNode rtn = new RadTreeNode("Project List", "Project Creation"); //<a href="../FlyCnMasters/DynamicMaster.aspx?Mode=Country" target="contentPane">Country</a>
            rtn.NavigateUrl = "../ProjectParameters/ProjectList.aspx";
            rtn.Target = "contentPane";
            myTree.Nodes.Add(rtn);

        }
    }
}