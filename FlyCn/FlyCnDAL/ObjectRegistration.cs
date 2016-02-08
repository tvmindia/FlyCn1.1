#region CopyRight

//All rights are reserved
//Created By   : SHAMILA T P
//Created Date : 14.1.2016

#endregion CopyRight

#region Included Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Web.UI;

#endregion Included Namespaces


namespace FlyCn.FlyCnDAL
{
    public class ObjectRegistration
    {

        DALConstants cnst = new DALConstants();

        #region BindTree

        public void BindTree(RadTreeView myTree)
        {

            myTree.Nodes.Clear();
            RadTreeNode rtn = new RadTreeNode("Registration", "Registration");
            rtn.NavigateUrl = cnst.ObjectRegistration;
            rtn.Target = "contentPane";
            myTree.Nodes.Add(rtn);



            rtn = new RadTreeNode("Non Project Roles", "NonProjectRoles");
            rtn.NavigateUrl = cnst.NonProjectRoles;
            rtn.Target = "contentPane";
            myTree.Nodes.Add(rtn);

            RadTreeNode rtn1 = new RadTreeNode("AssignRoles", "AssignRoles");
            rtn1.NavigateUrl = cnst.AssignRoles;
            rtn1.Target = "contentPane";
            myTree.Nodes.Add(rtn1);

            RadTreeNode rtn2 = new RadTreeNode("Users", "Users");
            rtn2.NavigateUrl = cnst.Users;
            rtn2.Target = "contentPane";
            myTree.Nodes.Add(rtn2);
            RadTreeNode rtn3 = new RadTreeNode("ManageAccess", "ManageAccess");
            rtn3.NavigateUrl = cnst.ManageAccess;
            rtn3.Target = "contentPane";
            myTree.Nodes.Add(rtn3);
        }
        #endregion BindTree()

    }
}