using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using FlyCn.FlyCnDAL;
using System.Data;

namespace FlyCn.EngineeredDataList
{
    
    public partial class EnggDatalistBaseTable : System.Web.UI.Page
    {
        string _moduleId;
        protected void Page_Load(object sender, EventArgs e)
        {
             _moduleId = Request.QueryString["Id"];

            Modules moduleObj = new Modules();
            DataSet dsobj = new DataSet();
            dsobj = moduleObj.GetModule(_moduleId);
            lblModule.Text = dsobj.Tables[0].Rows[0]["ModuleDesc"].ToString();
            DataSet ds = new DataSet();

            ds = moduleObj.GetModules();
            string tabhtml = "";
            for (int f = 0; f < ds.Tables[0].Rows.Count; f++)
            {
                tabhtml = " <li style='width:80px;' ><a" + " <a href='EnggDatalistBaseTable.aspx?Id=" + ds.Tables[0].Rows[f]["ModuleID"].ToString() + "'" + "'" + "'" + ">" + "<img" + " src=" + "'" + ds.Tables[0].Rows[f]["ModuleIconURLsmall"].ToString() + "'" + ">" + "<p>" + ds.Tables[0].Rows[f]["ModuleID"].ToString() + "</p>" + "</a></li>";

                horizonaltab.Controls.Add(new LiteralControl(tabhtml));
            }
            //FlyCnDAL.EnggDataList objBOQ = new FlyCnDAL.EnggDataList();

         
            //tview.Attributes.Add("onclick", "ClientNodeClicked(event)");

            //objBOQ.BindTreeEnggDataList();

           
           
        }
    }
}