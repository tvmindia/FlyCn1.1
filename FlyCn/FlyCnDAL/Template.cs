using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 
using Telerik.Web.UI;

namespace FlyCn.FlyCnDAL
{
    public class Template
    {

        public void BindTree(RadTreeView myTree)
        {
            myTree.Nodes.Clear();
            RadTreeNode rtn = new RadTreeNode("template1","0");
            rtn.NavigateUrl = "../Templates/InputTemplateContent.aspx";
            rtn.Target = "contentPane";
            myTree.Nodes.Add(rtn);


            rtn = new RadTreeNode("template2", "1");
            rtn.NavigateUrl = "../Templates/InputTemplateContent1.aspx";
            rtn.Target = "contentPane";
            myTree.Nodes.Add(rtn);

            rtn = new RadTreeNode("template3", "2");
            rtn.NavigateUrl = "../Templates/InputTemplateContent2.aspx";
            rtn.Target = "contentPane";
            myTree.Nodes.Add(rtn);

        }
        public void LoadInputScreen(RadPane myContentPane)
        {
            myContentPane.ContentUrl = "InputTemplateContent1.aspx";
        }
    }
}