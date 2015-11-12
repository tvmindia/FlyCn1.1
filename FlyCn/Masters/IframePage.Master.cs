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
           
  
          
            
        }

   

    }
}