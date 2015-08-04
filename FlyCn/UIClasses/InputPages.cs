using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Web.UI;

namespace FlyCn.UIClasses
{
    public class InputPages
    {

        public RadTreeView FindLeftTree(System.Web.UI.Page pg){

            var master = pg.Master.Master;
            var cnt = master.FindControl("MainBody");
            FlyCnDAL.MasterData masters = new FlyCnDAL.MasterData();
            RadTreeView tview = (RadTreeView)cnt.FindControl("rtvLeftMenu");

            return tview;
        }
    }
}