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



            rtn = new RadTreeNode("Roles", "NonProjectRoles");
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

            RadTreeNode rtn4 = new RadTreeNode("ManageModules", "ManageModules");
            rtn4.NavigateUrl = cnst.ManageModules;
            rtn4.Target = "contentPane";
            myTree.Nodes.Add(rtn4);

            RadTreeNode rtn5 = new RadTreeNode("ManageCategory", "ManageCategory");
            rtn5.NavigateUrl = cnst.ManageCategory;
            rtn5.Target = "contentPane";
            myTree.Nodes.Add(rtn5);

            RadTreeNode rtn6 = new RadTreeNode("Activity Library", "ModuleActivities");
            rtn6.NavigateUrl = cnst.ModuleActivities;
            rtn6.Target = "contentPane";
            myTree.Nodes.Add(rtn6);

            RadTreeNode rtn7 = new RadTreeNode("Manage Activity", "ManageActivities");
            rtn7.NavigateUrl = cnst.ManageActivities;
            rtn7.Target = "contentPane";
            myTree.Nodes.Add(rtn7);
        }
        #endregion BindTree()

    }
}