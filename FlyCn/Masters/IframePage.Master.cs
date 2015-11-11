using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FlyCn.FlyCnDAL;
using FlyCn.UserControls;
using Telerik.Web.UI;
using System.Windows.Automation;

namespace FlyCn.Masters
{
    public partial class IframePage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorHandling eObj = new ErrorHandling();
            eObj.ClearMessage(this);

            UIClasses.InputPages ip = new UIClasses.InputPages();
            try { this.head.Controls.Add(ip.GetThemeCss()); }
            catch (Exception) { }
            UIClasses.Const Const = new UIClasses.Const();
            FlyCnDAL.Security.UserAuthendication UA;
            Security sObj = new Security();
            HttpContext context = HttpContext.Current;
            UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
            var page = HttpContext.Current.CurrentHandler as Page;
            // Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SecurityOnload(page);", true);
            //Control myControl = new Control();
            //System.Diagnostics.Trace.WriteLine(sender.GetType( ).ToString());

            // if(sender.GetType() == typeof(System.Windows.Forms.TextBox))
            //if (myControl.GetType() == typeof(ToolBar))
            //{
            //    string name = UA.userName; 
                
            //    sObj.LoginSecurityCheck(page, name, myControl);
            //}

    //ControlFinder<RadToolBar> controlFinder = new ControlFinder<RadToolBar>();
    //controlFinder.FindChildControlsRecursive(Master);
    //RadToolBar toolBar = controlFinder.FoundControls.FirstOrDefault();
            ContentPlaceHolder contentPlaceHolder = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
            ControlType myControl = (ControlType)contentPlaceHolder.FindControl("ToolBar");
    string name = UA.userName;

    sObj.LoginSecurityCheck(page, name, toolBar);
  
          
            
        }

        //private class ControlFinder<T> where T : Control
        //{
        //    private readonly List<T> _foundControls = new List<T>();
        //    public IEnumerable<T> FoundControls
        //    {
        //        get { return _foundControls; }
        //    }

        //    public void FindChildControlsRecursive(Control control)
        //    {
                
        //        foreach (Control childControl in control.Controls)
        //        {
        //            if (childControl.GetType() == typeof(T))
        //            {
        //                _foundControls.Add((T)childControl);
        //            }
        //            else
        //            {
        //                FindChildControlsRecursive(childControl);
        //            }
        //        }
        //    }
        //}

    }
}