using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Web.UI;

namespace FlyCn.FlyCnDAL
{
    public class EnggDataList
    {
        public void BindTree(RadTreeView myTree)
        {

            UIClasses.Const Const = new UIClasses.Const();
            FlyCnDAL.Security.UserAuthendication UA;
            HttpContext context = HttpContext.Current;
            UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
            myTree.Nodes.Clear();
            //RadTreeNode rtn1 = new RadTreeNode("sample", "");
            //rtn1.Target = "contentPane";
            //myTree.Nodes.Add(rtn1);
            
        }

        public void LoadInputScreen(RadPane myContentPane)
        {
            myContentPane.ContentUrl = "EnggDataListLandingPage.aspx";
        }
    }
}