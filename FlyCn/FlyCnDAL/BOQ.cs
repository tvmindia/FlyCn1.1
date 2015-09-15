using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Web.UI;

namespace FlyCn.FlyCnDAL
{
    public class BOQ
    {
       public void BindTree(RadTreeView myTree)
       {
           myTree.Nodes.Clear();
       }
       public void LoadInputScreen(RadPane myContentPane)
       {
           myContentPane.ContentUrl = "BOQHeader.aspx";
       }
    }
}