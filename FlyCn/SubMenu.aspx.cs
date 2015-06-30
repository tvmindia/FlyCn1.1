using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlyCn
{
    public partial class SubMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UIClasses.DynamicIcons ui = new UIClasses.DynamicIcons();
            string id = Request.Params["id"];

            string myInnerHtml = ui.GenerateImageString(id);
            div2.Controls.Add(new LiteralControl(myInnerHtml));
        }
    }
}