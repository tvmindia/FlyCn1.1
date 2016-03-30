using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FlyCn.FlyCnDAL;
using System.Web.UI.HtmlControls;
namespace FlyCn.EngineeredDataList
{
    public partial class EnggDataListLandingPage : System.Web.UI.Page
    {
        string _tree;
        int maxTilesPerRow = 4;
        UIClasses.Const Const = new UIClasses.Const();
        FlyCnDAL.Security.UserAuthendication UA;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.collapsenode();", true);
            UA = (FlyCnDAL.Security.UserAuthendication)Session[Const.LoginSession];

            PlaceLandingPageIcons();
        }

        public string getBorderClass(int col,int row,int totrow){

            if (row == totrow && col == maxTilesPerRow)
                return "";
            if (row == totrow)
                return "borderR";
            if(col<maxTilesPerRow)
                return "borderRB";
            if (col == maxTilesPerRow)
                return "borderB";




            return "";
        }

         public void PlaceLandingPageIcons()
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.HideTreeNode();", true);
            Modules moduleObj = new Modules();
            DataSet ds = new DataSet();
            ds = moduleObj.GetModules(UA.projectNo);
             if((ds.Tables[0].Rows.Count>0)&&(ds!=null))
             {
            string tabhtml = "";
            string tabliFirst = "";
            tabliFirst = " <li style='width:80px;' >" + " <a href='EnggDataListLandingPage.aspx"+ "'" + "'" + "'" + ">" + "<img" + " src=" + "'" +
                ds.Tables[0].Rows[4]["ModuleIconURLsmall"].ToString() + "'" + ">" + "<p>"
                + "All" + "</p>" + "</a></li>";

            string myInnerHtml = "<div class='EnggTilesContainerDiv'>" +
           "<table class='EnggTilesContainerTBL'>" +
           " <tr>";

            int rows = 1;
            int cols = 0;
            int totRows = 0;
            if ((ds.Tables[0].Rows.Count) % maxTilesPerRow==0) {

                totRows = (ds.Tables[0].Rows.Count) / maxTilesPerRow;
            } else {
                totRows = (ds.Tables[0].Rows.Count) / maxTilesPerRow;
                totRows = totRows + 1;
            }

            horizonaltab.Controls.Add(new LiteralControl(tabliFirst));
            for (int f = 0; f < ds.Tables[0].Rows.Count; f++)
            {
                tabhtml = " <li style='width:80px;' ><a" + " <a href='EnggDatalistBaseTable.aspx?Id=" + ds.Tables[0].Rows[f]["ModuleID"].ToString() + "'" + "'" + "'" + ">" +"<img" + " src=" + "'" + ds.Tables[0].Rows[f]["ModuleIconURLsmall"].ToString() + "'" + ">" + "<p>" + ds.Tables[0].Rows[f]["ModuleID"].ToString() + "</p>" + "</a></li>";

                horizonaltab.Controls.Add(new LiteralControl(tabhtml));                 
                
                cols = cols + 1;

                string borderClass = getBorderClass(cols, rows, totRows);
                myInnerHtml = myInnerHtml + "<td class='EnggDatalistIcons  " + borderClass + "" + "'>";
                string img = ds.Tables[0].Rows[f]["ModuleIconURL"].ToString();
                string desc = ds.Tables[0].Rows[f]["ModuleDesc"].ToString();
                string url = "EnggDatalistBaseTable.aspx?Id=" + ds.Tables[0].Rows[f]["ModuleID"].ToString();
              

                myInnerHtml = myInnerHtml + " <table class='EnggTileInnerTable'> <tr><td>" +
                " <a href='"+ url +"'>" + "<img" + " src=" + "'" + img
                + "'" + "','" + desc + "' border=" + "0" + " alt=Submission Form" + "/></a></td></tr><tr><td style='padding:5px;'>" + desc + "</td></tr>" +
                "</table></td>";




                if ((f + 1) % maxTilesPerRow == 0)
                {
                    myInnerHtml = myInnerHtml + "</tr>" +
                               "  <tr>";
                    rows = rows + 1;
                    cols = 0;
                }

               
      
            }
            myInnerHtml = myInnerHtml +
             "</tr>" +
                 " </table></div>";
               
              
           
                    body.Controls.Add(new LiteralControl(myInnerHtml));
           
             }//ds check if
          
        }
    }
}