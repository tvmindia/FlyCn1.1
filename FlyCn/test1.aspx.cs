using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlyCn
{
    public partial class test1 : System.Web.UI.Page
    {
        public int url
        {
            get;
            set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            url = Request.Url.Port;
        }
       
        
    }
}