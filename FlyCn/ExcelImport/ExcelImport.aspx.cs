using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using FlyCn.FlyCnDAL;
namespace FlyCn.ExcelImport
{
    public partial class ExcelImport : System.Web.UI.Page
    {
        #region Page_Load()
        protected void Page_Load(object sender, EventArgs e)
        {
            //Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.showTreeNode();", true);
            UIClasses.InputPages ip = new UIClasses.InputPages();
           // FlyCnDAL.ExcelImport objex = new FlyCnDAL.ExcelImport();
            ImportFile objex = new ImportFile();

            RadTreeView tview = ip.FindLeftTree(this);
            objex.BindTree(tview);

            ip.DefaultTreeNode(this, 1);
        }
        #endregion Page_Load()
    }
}