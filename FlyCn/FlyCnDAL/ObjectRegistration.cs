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
        }
        #endregion BindTree()

    }
}