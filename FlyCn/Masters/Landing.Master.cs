using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace FlyCn.Masters
{
    public partial class Landing : System.Web.UI.MasterPage
    {
        UIClasses.Const Const= new UIClasses.Const();
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session[Const.LoginSession] == null) {

                lnkLoginLogout.Attributes.Add("onclick", "return openLogin('slow')");
            }
            else {
                FlyCnDAL.Security.UserAuthendication UA = (FlyCnDAL.Security.UserAuthendication)Session[Const.LoginSession];
                lblUser.Text = UA.userName;
                lnkLoginLogout.Text = "Logout";
                
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, ImageClickEventArgs e)
        {
            FlyCnDAL.Security.UserAuthendication UA = new FlyCnDAL.Security.UserAuthendication(txtUsername.Value , txtPassword.Value);
            if (UA.ValidUser)
            {
                Session.Add(Const.LoginSession, UA);
                Response.Redirect("Menu.aspx");
                lblError.Text = "";
            }
            else
            {
                lblError.Text = "Username/Password wrong !";
               
            
            }


        }

        protected void lnkLoginLogout_Click(object sender, EventArgs e)
        {
            Session.Remove(Const.LoginSession);
            Response.Redirect("Home.aspx");
        }


        
    }
}