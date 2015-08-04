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
        FlyCnDAL.Security.UserAuthendication UA;
        protected void Page_Load(object sender, EventArgs e)
        {
            UIClasses.Const c = new UIClasses.Const();
            UA = (FlyCnDAL.Security.UserAuthendication)Session[c.LoginSession];
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

        protected void rgActList_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            FlyCnDAL.Activities obj = new FlyCnDAL.Activities();
            rgActList.DataSource = obj.GetActivities(UA.projectNo);
        }

    }
}