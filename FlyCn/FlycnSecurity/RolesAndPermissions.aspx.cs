using FlyCn.FlyCnDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace FlyCn.FlycnSecurity
{
    public partial class RolesAndPermissions : System.Web.UI.Page
    {
        DALConstants cnst = new DALConstants();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadLeftMenu();
        }

        public void LoadLeftMenu()
        {
            UIClasses.InputPages ip = new UIClasses.InputPages();
          //  FlyCnDAL.ObjectRegistration objRegstr = new FlyCnDAL.ObjectRegistration();
            RadTreeView tview = ip.FindLeftTree(this);
            BindTree(tview);
            ip.DefaultTreeNode(this, 0);

        }

        public void BindTree(RadTreeView myTree)
        {

            myTree.Nodes.Clear();

            RadTreeNode rtn = new RadTreeNode("Roles", "NonProjectRoles");
            rtn.NavigateUrl = cnst.NonProjectRoles;
            rtn.Target = "contentPane";
            myTree.Nodes.Add(rtn);

            RadTreeNode rtn1 = new RadTreeNode("AssignRoles", "AssignRoles");
            rtn1.NavigateUrl = cnst.AssignRoles;
            rtn1.Target = "contentPane";
            myTree.Nodes.Add(rtn1);
        }
    }
}