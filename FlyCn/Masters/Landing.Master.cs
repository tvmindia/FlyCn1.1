using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FlyCn.FlyCnDAL;


namespace FlyCn.Masters
{
    public partial class Landing : System.Web.UI.MasterPage
    {
        UIClasses.Const Const= new UIClasses.Const();
        public string LogId = "";

        protected void Page_Init(object sender, EventArgs e)
      
        {
           
           // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(userName)", true);

            if (Session[Const.LoginSession] == null) 
            {
                if (GetCurrentPageName() == Const.HomePage || GetCurrentPageName().ToUpper() == Const.Default.ToUpper())
                {
                   
                    imgMenu.Visible = false;
                    lnkLoginLogout.Attributes.Add("onclick", "return openLogin('slow')");
                
                }
                else if (GetCurrentPageName() == Const.ApprovalPageURL)
                {
                    if (Request.QueryString["logid"] != null)
                    {
                        LogId = Request.QueryString["logid"];
                        ApprovelMaster approvalmasterObj = new ApprovelMaster();
                        string userName = approvalmasterObj.GetUserNameByLogId(LogId);
                        if (userName == "No User Found")
                        {
                            Response.Redirect(Const.HomePageURL);
                        }
                        else
                        {
                            FlyCnDAL.Security.UserAuthendication UA = new FlyCnDAL.Security.UserAuthendication(userName, 1);

                            if (UA.ValidUser)
                            {
                                Session.Add(Const.LoginSession, UA);
                                lblError.Text = "";
                                setLogoutAndUserName(UA);
                            }
                            else
                            {
                                Response.Redirect(Const.HomePageURL);
                            }
                        }
                    }
                }
                else
                {

                    Response.Redirect(Const.HomePageURL);
                }

              
            }
            else {
                FlyCnDAL.Security.UserAuthendication UA = (FlyCnDAL.Security.UserAuthendication)Session[Const.LoginSession];
                setLogoutAndUserName(UA);
            }

        }

        public void setLogoutAndUserName(FlyCnDAL.Security.UserAuthendication UA)
        {
            lblUser.Text = UA.userName;
            lnkLoginLogout.Text = "Logout";
            imgMenu.Visible = true;
        }

        public string GetCurrentPageName()
        {
            string sPath = Request.Url.AbsolutePath;
            System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
            string sRet = oInfo.Name;
            return sRet;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            UIClasses.InputPages ip = new UIClasses.InputPages();
            try
            {
                this.head.Controls.Add(ip.GetLandingThemeCss());

            }
            catch(Exception ex)
            {
                
            }
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
            Response.Redirect("~/Home.aspx");
        }
        
    }
}