using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace FlyCn.EngineeredDataList
{
    public partial class EnggDatalistBaseTable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string _RevisionID = Request.QueryString["Id"];
           
            //FlyCnDAL.EnggDataList objBOQ = new FlyCnDAL.EnggDataList();

         
            //tview.Attributes.Add("onclick", "ClientNodeClicked(event)");

            //objBOQ.BindTreeEnggDataList();

           
           
        }
    }
}