using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace FlyCn.UIClasses
{
    public class DynamicIcons
    {

        public string GenerateImageString(string id)
        {

            FlyCnDAL.DynamicIcons da = new FlyCnDAL.DynamicIcons();
            DataSet ds;
            if (id == null)
            {

                ds = da.getMenuNames();
            }
            else
            {
                ds = da.getSubMenuNames(id);
            }

            string myInnerHtml = "<div>" +
           "<table class='TileTable'  >" +
           " <tr>" +
                "<td style =" + "width:60%>" +
                    "<div style=" + "width:100%;>" +
                        "<table style=" + "width:100%;>" +
                            "<tr>";

            int rows = 1;
            int cols = 0;

            for (int f = 0; f < ds.Tables[0].Rows.Count; f++)
            {
                cols = cols + 1;
                myInnerHtml = myInnerHtml + Environment.NewLine;
                if (id == null)
                {
                    string colorClass="";
                    if (ds.Tables[0].Rows[f]["theme"] != null)
                    {
                        colorClass = " " + ds.Tables[0].Rows[f]["theme"].ToString();
                    }

                    myInnerHtml = myInnerHtml + "<td class='Tiles" + colorClass + "'  >";
                    string img = ds.Tables[0].Rows[f]["imgUrl"].ToString();                   
                    myInnerHtml = myInnerHtml + " <table class='TileIcon'> <tr><td>" + "<img" + " src=" + "'" + img + "'" + " onclick" + "=" + "bindimage('" + ds.Tables[0].Rows[f]["menuId"].ToString() + "') border=" + "0" + " alt=Submission Form" + "/></td></tr>" +
                    "<tr> <td>  <span class=" + "description" + ">" + ds.Tables[0].Rows[f]["description"].ToString() + "</span> </td> </tr> </table></td>";
                }
                else
                {
                    string colorClass = "";
                    if (ds.Tables[0].Rows[f]["theme"] != null)
                    {
                        colorClass = " " +  ds.Tables[0].Rows[f]["theme"].ToString();
                    }

                    myInnerHtml = myInnerHtml + "<td class='Tiles" + colorClass + "' >";
                    string img = ds.Tables[0].Rows[f]["subimgUrl"].ToString();

                    myInnerHtml = myInnerHtml + " <table class='TileIcon'> <tr><td><img" + " src=" + "'" + img + "'" + " onclick" + "=" + "parent.bindimageLink('" + ds.Tables[0].Rows[f]["subPath"].ToString() + "') border=" + "0" + " alt=Submission Form" + "/></td></tr>" +
                "<tr>" +
                    "<td>" +
                       " <span class=" + "description" + ">" + ds.Tables[0].Rows[f]["subdescription"].ToString() + "</span>" +
                    "</td>" +
                "</tr>" +
           " </table>" + "</td>";



                    //      myInnerHtml = myInnerHtml + "<td style=" + "width:200px;height:200px;>";

                    //      string img = ds.Tables[0].Rows[f]["subimgUrl"].ToString();

                    //      string s = ds.Tables[0].Rows[f]["subdescription"].ToString();
                    //      string pathss = ds.Tables[0].Rows[f]["subPath"].ToString();

                    //       myInnerHtml = myInnerHtml + " <table>" +
                    //           "<tr><td>";
                    //       myInnerHtml = myInnerHtml +
                    // "<" + "img src=" + "'" + img + "'" + " onclick" + "=" + "bindimageLink('" + ds.Tables[0].Rows[f]["subPath"].ToString() + "')  border=" + "'" + 0 + "'" + " alt=Submission Form" + "style: no-repeat center left; display:block; height:84px; width:264px;" + " />" +

                    //      " </td>" +
                    //     "<tr>" +
                    //         "<td>" +
                    //          s +
                    //     "</td>" +
                    //     "</tr>" +
                    //" </table>" + "</td>";

                }

                if ((f + 1) % 3 == 0)
                {
                    myInnerHtml = myInnerHtml + "</tr>" +
                               "  <tr>";
                    rows = rows + 1;
                    cols = 0;
                }
            }

            if (cols > 0)
            {
                for (int m = 0; m < 3 - cols; m++)
                {
                    myInnerHtml = myInnerHtml + "<td></td>";
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
            return myInnerHtml;
        }
    }
}