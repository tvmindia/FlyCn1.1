using FlyCn.FlyCnDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace FlyCn.EIL
{
    public partial class PunchList : System.Web.UI.Page
    {
        DALConstants cnsObj = new DALConstants();
        protected void Page_Load(object sender, EventArgs e)
        {
            string modeValue = "";
            modeValue = Request.QueryString["Mode"];
            if (Request.QueryString["Mode"] != null)
            {              
                if (modeValue == "QEIL")
                {
                    LoadLeftMenu(2);
                }
                else if(modeValue=="CEIL")
                {
                    LoadLeftMenu(1);
                }
                else
                {
                    LoadLeftMenu(0);
                }
            }
            else
            {
               

            }
            
        }
        public void LoadLeftMenu(int node)
        {
            UIClasses.InputPages ip = new UIClasses.InputPages();
            FlyCnDAL.PunchList PL = new FlyCnDAL.PunchList();

            RadTreeView tview = ip.FindLeftTree(this);
            PL.BindTree(tview);
            ip.DefaultTreeNode(this, node);

        }

        public void LoadPunchListInputScreen(RadPane myContentPane)
        {
            myContentPane.ContentUrl = cnsObj.PunchListSummary;

        }

      
        public void LoadCategoryMgmtInputScreen(RadPane myContentPane)
        {
            myContentPane.ContentUrl = cnsObj.AllocateCategory;

        }
    }
}