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
        protected void Page_Load(object sender, EventArgs e)
        {

            FlyCn.FlyCnDAL.MailSending mailobj = new FlyCnDAL.MailSending();
            mailobj.GeneralEmailSending("Gopika", "Hi", "Hello");
        }
    }
}