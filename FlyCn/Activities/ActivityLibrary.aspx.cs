using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace FlyCn.Activities
{
    public partial class ActivityLibrary : System.Web.UI.Page
    {
        FlyCnDAL.Security.UserAuthendication UA;
        protected void Page_Load(object sender, EventArgs e)
        {


            //----------- Register Toolbar Server & Client side events ----------------//
            ToolBar.onClick += new RadToolBarEventHandler(ToolBar_onClick);
            ToolBar.OnClientButtonClicking = "OnClientButtonClicking";
            //-------------------------------------------------------------------------//


            UIClasses.Const c = new UIClasses.Const();
            UA = (FlyCnDAL.Security.UserAuthendication)Session[c.LoginSession];
            if (!IsPostBack) {
                loadModules();
            }

           
        }


        void loadModules() {

            FlyCnDAL.Modules mObj = new FlyCnDAL.Modules();
            rcmbModules.DataSource = mObj.GetModules(UA.projectNo).Tables[0];
            rcmbModules.DataTextField = mObj.cmbTextField;
            rcmbModules.DataValueField = mObj.cmbValueField;
            rcmbModules.DataBind();


        }

        protected void rgActList_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            FlyCnDAL.Activities obj = new FlyCnDAL.Activities();
            rgActList.DataSource = obj.GetActivities(UA.projectNo);
        }

        protected void rgActList_ItemCommand(object source, GridCommandEventArgs e)
        {
            if (e.CommandName == "EditData") {

                RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("2");
                tab.Selected = true;
                tab.Text = "Edit";
                RadMultiPage1.SelectedIndex = 1;

                ToolBar.AddButton.Visible = false;
                ToolBar.SaveButton.Visible=false;
                ToolBar.UpdateButton.Visible = true;
                ToolBar.DeleteButton.Visible = true;
            }
        
        }



        protected void ToolBar_onClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {

            msg.Text = e.Item.Value + " clicked !";
        }

        


    }
}