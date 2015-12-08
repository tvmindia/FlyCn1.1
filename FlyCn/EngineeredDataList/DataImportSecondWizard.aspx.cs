using FlyCn.FlyCnDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlyCn.EngineeredDataList
{
    public partial class DataImportSecondWizard : System.Web.UI.Page
    {
        string _moduleId;
        protected void Page_Load(object sender, EventArgs e)
        {
            _moduleId = Request.QueryString["Id"];
            Modules moduleObj = new Modules();
            DataSet dsobj = new DataSet();
            dsobj = moduleObj.GetModule(_moduleId);
            //lblModule.Text = dsobj.Tables[0].Rows[0]["ModuleDesc"].ToString();
        }

       
    }
}