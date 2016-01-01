using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace FlyCn.UIClasses
{
    public class DynamicIcons
    {
        string Large = "Large";
        string Small = "Small";
        string Tiny = "Tiny";

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
                    string desc = ds.Tables[0].Rows[f]["description"].ToString();
                    myInnerHtml = myInnerHtml + " <table class='TileIcon'> <tr><td>" + "<img" + " src=" + "'" + img + "'" + " onclick" + "=" + "bindimage('" + ds.Tables[0].Rows[f]["menuId"].ToString() + "','" + desc + "') border=" + "0" + " alt=Submission Form" + "/></td></tr>" +
                    "<tr> <td>  <span class=" + "description" + ">" + desc + "</span> </td> </tr> </table></td>";
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

        public string generateTopMenuImages(string id) {
            string result="";
            try
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

                result = result + "<div class='row'>";
                for (int f = 0; f < ds.Tables[0].Rows.Count; f++)
                {
                    string colorClass = GetTheme(ds, f);
                    string img = ds.Tables[0].Rows[f]["imgUrl"].ToString();
                    string desc = ds.Tables[0].Rows[f]["description"].ToString();
                    string imgStr = "<img " + "tinyImg" + " src=" + "'" + img + "'" + " onclick" + "=" + "bindimage('" + ds.Tables[0].Rows[f]["menuId"].ToString() + "','" + desc + "','" + colorClass.Trim() + "') border=" + "0" + " alt=Submission Form" + "/>";

                    result = result + "<div class='col-xs-3 Tiles " + colorClass + " smallTile'>" + desc +imgStr + "</div>";
                    if ((f+1) % 4 == 0) {
                        result = result + "</div><div class='row'>";
                    }
                
                }
                result = result + "</div>";



                return result;
            }
            catch (Exception)
            {

                return "";
            }

        
        }


        public string GenerateMultiSizeImageString(string id)
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
                "<td style =" + "width:470px>" +
                    "<div style=" + "width:100%;>" +
                        "<table class='TileTableMain'><tr><td width='25%'></td><td width='25%'></td><td width='25%'></td><td width='25%'></td></tr>" +
                            "<tr>";

            int rows = 1;
            int cols = 0;

            for (int f = 0; f < ds.Tables[0].Rows.Count; f++)
            {
                cols = cols + 1;               

                myInnerHtml = myInnerHtml + Environment.NewLine;
                
                    string  colorClass = GetTheme(ds,f);
                    string sizeClass = GetSize(ds,f);
                    
                    //--------Tiny level1-----------------
                    if (sizeClass == Tiny)
                    {


                        myInnerHtml = myInnerHtml + "<td class='TinyTileContainer'><table class='TinyTable' ><tr>";//<tr><td width='50%'></td><td width='50%'></tr>

                        myInnerHtml = myInnerHtml + GetTileString(id,ds, f, colorClass, sizeClass,Tiny);
                        if (GetSize(ds, f + 1) != Tiny) {
                            myInnerHtml = myInnerHtml + "<td class='" + Tiny + "'>&nbsp;</td></tr><tr><td class='" + Tiny + "'>&nbsp;</td><td class='" + Tiny + "'>&nbsp;</td>";
                        }
                        else {
                            //--------Tiny level2-----------------
                            f = f + 1;
                            colorClass = GetTheme(ds, f);
                            sizeClass = GetSize(ds, f);
                            myInnerHtml = myInnerHtml + GetTileString(id,ds, f, colorClass, sizeClass, Tiny);


                            if (GetSize(ds, f + 1) != Tiny)
                            {
                                myInnerHtml = myInnerHtml + "</tr><tr><td class='" + Tiny + "'>&nbsp;</td><td class='" + Tiny + "'>&nbsp;</td>";
                            }
                            else
                            {
                                //--------Tiny level3-----------------
                                f = f + 1;
                                colorClass = GetTheme(ds, f);
                                sizeClass = GetSize(ds, f);
                                myInnerHtml = myInnerHtml + "</tr><tr>";
                                myInnerHtml = myInnerHtml + GetTileString(id, ds, f, colorClass, sizeClass, Tiny);

                                if (GetSize(ds, f + 1) != Tiny)
                                {
                                    myInnerHtml = myInnerHtml + "<td class='" + Tiny + "'>&nbsp;</td>";
                                }
                                else
                                {
                                    //--------Tiny level4-----------------
                                    f = f + 1;
                                    colorClass = GetTheme(ds, f);
                                    sizeClass = GetSize(ds, f);
                                    myInnerHtml = myInnerHtml + GetTileString(id, ds, f, colorClass, sizeClass, Tiny);



                                }

                            }

                        
                        }


                        myInnerHtml = myInnerHtml + "</tr></table></td>";
                    }
                    else
                    {
                        //----- small tile ---
                        if (sizeClass == Small)
                        {
                            myInnerHtml = myInnerHtml + GetTileString(id, ds, f, colorClass, sizeClass, "");
                        }
                            //--- large tile --
                        else {
                            if (cols == 4) {
                                myInnerHtml = myInnerHtml + "<td></td></tr>";
                                cols = 1;
                                rows = rows + 1;
                            }
                            myInnerHtml = myInnerHtml + GetTileString(id, ds, f, colorClass, sizeClass, Large);
                            cols = cols + 1;
                        }
                    }
                

                if ((cols) ==4)
                {
                    myInnerHtml = myInnerHtml + "</tr>" +
                               "  <tr>";
                    rows = rows + 1;
                    cols = 0;
                }
            }

            if (cols > 0)
            {
                for (int m = 0; m < 4 - cols; m++)
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

        public string GetTileString(string id,DataSet ds, int row, string colorClass, string sizeClass, string type) {

            if (id == null) {
                return GetMainTileString(ds, row, colorClass, sizeClass, type);
            
            } else {

                return GetSubTileString(ds, row, colorClass, sizeClass, type);
            }
        
        }

        public string GetMainTileString(DataSet ds,int row,string colorClass,string sizeClass,string type ) {
            string myInnerHtml="";
            string colspan = "";
            string tinyImgClass = "";

            if (type == Large) { colspan = " colspan='2'"; }
            if (type == Tiny) { tinyImgClass = " class='tinyImg'"; }

            if (colorClass != "") { colorClass=" " + colorClass;}
            if (sizeClass != "") { sizeClass = " " + sizeClass; }
            if (row < ds.Tables[0].Rows.Count){
            myInnerHtml = myInnerHtml + "<td class='Tiles" + colorClass +  sizeClass + "' " +  colspan + " >";
            string img = ds.Tables[0].Rows[row]["imgUrl"].ToString();
            string desc = ds.Tables[0].Rows[row]["description"].ToString();
            myInnerHtml = myInnerHtml + " <table class='TileIcon'> <tr><td>" + "<img " + tinyImgClass + " src=" + "'" + img + "'" + " onclick" + "=" + "bindimage('" + ds.Tables[0].Rows[row]["menuId"].ToString() + "','" + desc + "','" + colorClass.Trim() + "') border=" + "0" + " alt=Submission Form" + "/></td></tr>" +
            "<tr> <td>  <span class=" + type + "description" + ">" + desc + "</span> </td> </tr> </table></td>";
        }
            return myInnerHtml;
        }


        public string GetSubTileString(DataSet ds, int row, string colorClass, string sizeClass, string type) {

             string myInnerHtml="";
            string colspan = "";
            string tinyImgClass = "";

            if (type == Large) { colspan = " colspan='2'"; }
            if (type == Tiny) { tinyImgClass = " class='tinyImg'"; }

            if (colorClass != "") { colorClass=" " + colorClass;}
            if (sizeClass != "") { sizeClass = " " + sizeClass; }
            if (row < ds.Tables[0].Rows.Count)
            {

                myInnerHtml = myInnerHtml + "<td class='Tiles" + colorClass + sizeClass + "' " + colspan + " >";
                string img = ds.Tables[0].Rows[row]["subimgUrl"].ToString();

                myInnerHtml = myInnerHtml + " <table class='TileIcon'> <tr><td><img" + tinyImgClass +   " src=" + "'" + img + "'" + " onclick" + "=" + "parent.bindimageLink('" + ds.Tables[0].Rows[row]["subPath"].ToString() + "') border=" + "0" + " alt=Submission Form" + "/></td></tr>" +
            "<tr>" +
                "<td>" +
                   " <span class=" + "description" + ">" + ds.Tables[0].Rows[row]["subdescription"].ToString() + "</span>" +
                "</td>" +
            "</tr>" +
       " </table>" + "</td>";
            }

            return myInnerHtml;
        }




        public string GetTheme(DataSet ds, int row)
        {
            string colorClass = "";
            if (row < ds.Tables[0].Rows.Count)
            {
                if (ds.Tables[0].Rows[row]["theme"] != null)
                {
                    colorClass = ds.Tables[0].Rows[row]["theme"].ToString();
                }
            }
            return colorClass;
        }

        public string GetSize(DataSet ds, int row)
        {
            string size = "";
            if (row < ds.Tables[0].Rows.Count)
            {
                if (ds.Tables[0].Rows[row]["Size"] != null)
                {
                    size = ds.Tables[0].Rows[row]["Size"].ToString();
                }
            }
            return size;
        }
    }
}