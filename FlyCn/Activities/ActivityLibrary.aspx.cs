using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlyCn.Activities
{
    public partial class ActivityLibrary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                loadModules();
            }
        }


        void loadModules() {

            FlyCnDAL.Modules mObj = new FlyCnDAL.Modules();
            rcmbModules.DataSource = mObj.GetModules().Tables[0];
            rcmbModules.DataTextField = mObj.cmbTextField;
            rcmbModules.DataValueField = mObj.cmbValueField;
            rcmbModules.DataBind();


        }

    }
}