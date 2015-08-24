using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Web.UI;

namespace FlyCn.UIClasses
{
    public class TabAddEditSettings
    {
        public void Addtab(RadTab tabid1, RadTab tabid2)
        {
            tabid1.Selected = true;
            tabid2.Text = "New";
            tabid2.ImageUrl = "~/Images/Icons/NewIcon.png";

        }
        public void EditTab(RadTab tabid)
        {
            //RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("2");
            tabid.Selected = true;
            tabid.Text = "Edit";
            tabid.ImageUrl = "~/Images/Icons/editIcon.png";
         
        }

        public void ListTab(RadTab tabid1, RadTab tabid2)
        {
            //RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("2");
            tabid1.Selected = true;
            tabid2.Text = "New";
            tabid2.ImageUrl = "~/Images/Icons/NewIcon.png";

        }
    }
}