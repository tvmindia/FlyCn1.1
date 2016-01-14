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
            RadTreeNode rtn1 = new RadTreeNode("Data Import Wizard", "");
            rtn1.NavigateUrl = "../EngineeredDataList/EnggDataListLandingPage.aspx";
            rtn1.Target = "contentPane";
            myTree.Nodes.Add(rtn1);
            RadTreeNode rtn2 = new RadTreeNode("Direct Import", "");
            rtn2.NavigateUrl = "../EngineeredDataList/EnggDatalistBaseTable.aspx?id=ELE";
            rtn2.Target = "contentPane";
            myTree.Nodes.Add(rtn2);
            RadTreeNode rtn3 = new RadTreeNode("View Data", "");
            rtn3.NavigateUrl = "../EngineeredDataList/EnggViewData.aspx";
            rtn3.Target = "contentPane";
            myTree.Nodes.Add(rtn3);
            RadTreeNode rtn4 = new RadTreeNode("Import ErrorList", "");
            rtn4.NavigateUrl = "../ExcelImport/ImportErrorList.aspx";
            rtn4.Target = "contentPane";
            myTree.Nodes.Add(rtn4);
            RadTreeNode rtn5 = new RadTreeNode("Import StatusList", "");
            rtn5.NavigateUrl = "../ExcelImport/ImportStatusList.aspx";
            rtn5.Target = "contentPane";
            myTree.Nodes.Add(rtn5);
            
        }

        public void BindTreeF(RadTreeView myTree)
        {

            UIClasses.Const Const = new UIClasses.Const();
            FlyCnDAL.Security.UserAuthendication UA;
            HttpContext context = HttpContext.Current;
            UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
            myTree.Nodes.Clear();
          

        }


        public void LoadInputScreen(RadPane myContentPane, System.Web.UI.Page pg)
        {
            var master = pg;

            myContentPane.ContentUrl = "EnggDataListLandingPage.aspx?tree=" + pg;
        }
    }
}