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
        protected void Page_Load(object sender, EventArgs e)
        {
            PlaceLandingPageIcons();
        }
         public void PlaceLandingPageIcons()
        {
            Modules moduleObj = new Modules();
            DataSet ds = new DataSet();
            ds = moduleObj.GetModules();
            string tabhtml = "";

            string myInnerHtml = "<div>" +
           "<table class='TileTable'  >" +
           " <tr>" +
                "<td style =" + "width:100%>" +
                    "<div style=" + "width:100%;>" +
                        "<table style=" + "width:100%;>" +
                            "<tr>";

            int rows = 1;
            int cols = 0;

            for (int f = 0; f < ds.Tables[0].Rows.Count; f++)
            {
                tabhtml = " <li style='width:80px;' ><a" + " <a href='EnggDatalistBaseTable.aspx?Id=" + ds.Tables[0].Rows[f]["ModuleID"].ToString() + "'" + "'" + "'" + ">" +"<img" + " src=" + "'" + ds.Tables[0].Rows[f]["ModuleIconURLsmall"].ToString() + "'" + ">" + "<p>" + ds.Tables[0].Rows[f]["ModuleID"].ToString() + "</p>" + "</a></li>";

                horizonaltab.Controls.Add(new LiteralControl(tabhtml));

                //HtmlGenericControl divcontrol = new HtmlGenericControl("div");
                //divcontrol.ID = "div" + ds.Tables[0].Rows[f]["ModuleDesc"].ToString();
                //divcontrol.InnerText = ds.Tables[0].Rows[f]["ModuleIconURLsmall"].ToString();
                //divcontrol.Attributes.Add("class", "tab tab2");
                
                cols = cols + 1;
                myInnerHtml = myInnerHtml + Environment.NewLine;

            
                myInnerHtml = myInnerHtml + "<td class='EnggDatalistIcons" + "'>";
                    string img = ds.Tables[0].Rows[f]["ModuleIconURL"].ToString();
                    string desc = ds.Tables[0].Rows[f]["ModuleDesc"].ToString();
                  
                    myInnerHtml = myInnerHtml + " <table class='TileIcon' style='height:110px'> <tr><td  style='height:100px;border=0' 'vertical-align: bottom;'>" +
                        " <a href='EnggDatalistBaseTable.aspx?Id="+ds.Tables[0].Rows[f]["ModuleID"].ToString() +"'" + "'" + "'" + ">" + "<img" + " src=" + "'" + img
                           + "'" + "','" + desc + "' border=" + "0" + " alt=Submission Form" + "/><p>" + desc + "</p></a></td></tr>" +
                      "</table></td>";
                

                

                if ((f + 1) % 3 == 0)
                {
                    myInnerHtml = myInnerHtml + "</tr>" +
                               "  <tr>";
                    rows = rows + 1;
                    cols = 0;
                }

               
      
            }
                myInnerHtml = myInnerHtml +
                 "</tr>" +
                     " </table>" +
                  "</div>" +
              "</td>" +

          " <td >" +

            "</td>" +
                         " </tr>" +
    "  </table>" +
"  </div> ";
           
                    body.Controls.Add(new LiteralControl(myInnerHtml));
           

          
        }
    }
}