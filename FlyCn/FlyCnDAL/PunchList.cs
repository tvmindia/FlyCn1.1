using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Web.UI;

namespace FlyCn.FlyCnDAL
{
    public class PunchList
    {
        DALConstants cnst = new DALConstants();
        public void BindTree(RadTreeView myTree)
        {

            myTree.Nodes.Clear();
            RadTreeNode rtn = new RadTreeNode("Construction", "WEIL");
                rtn.NavigateUrl = cnst.ConstructionPunchListURL + "?Mode=" + rtn.Value;
                rtn.Target = "contentPane";
                myTree.Nodes.Add(rtn);


                rtn = new RadTreeNode("Client", "CEIL");
                rtn.NavigateUrl = cnst.ClientPunchListURL + "?Mode=" + rtn.Value;
                rtn.Target = "contentPane";
                myTree.Nodes.Add(rtn);

            rtn = new RadTreeNode("QC", "QEIL");
                rtn.NavigateUrl = cnst.QCPunchListURL + "?Mode=" + rtn.Value;
                rtn.Target = "contentPane";
                myTree.Nodes.Add(rtn);
           

        }


    }
}