using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using Telerik.Web.UI;

namespace FlyCn.UIClasses
{
    public class InputPages
    {
        #region GetDocumentStatusDictionary
        public OrderedDictionary GetDocumentStatusDictionary()
        {
        OrderedDictionary documentStatusDictionary = new OrderedDictionary();


        return documentStatusDictionary;
        }
        #endregion GetDocumentStatusDictionary
        public RadTreeView FindLeftTree(System.Web.UI.Page pg){

            var master = pg.Master.Master;
            var cnt = master.FindControl("MainBody");
            FlyCnDAL.MasterData masters = new FlyCnDAL.MasterData();
            RadTreeView tview = (RadTreeView)cnt.FindControl("rtvLeftMenu");

            return tview;
        }

        public RadPane FindContentPane(System.Web.UI.Page pg)
        {
            var master = pg.Master.Master;
            var cnt = master.FindControl("MainBody");
            FlyCnDAL.MasterData masters = new FlyCnDAL.MasterData();
            RadPane contenpane = (RadPane)cnt.FindControl("contentPane");
            return contenpane;
        }

        public void DefaultTreeNode(System.Web.UI.Page pg,int node) {
            RadTreeView tree = FindLeftTree(pg);
            tree.Nodes[node].Selected = true;
            RadPane radpane = FindContentPane(pg);
            radpane.ContentUrl = tree.Nodes[node].NavigateUrl;
        }


        public string GetCurrentPageName()
        {
            string sPath =HttpContext.Current.Request.Url.AbsolutePath;
            System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
            string sRet = oInfo.Name;
            return sRet;
        }


        public LiteralControl GetThemeCss()
        {
            FlyCnDAL.Security.UserAuthendication UA;
           
            UIClasses.Const Const = new UIClasses.Const();
            HttpContext context = HttpContext.Current;
            UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
            string cssList;

            if(GetCurrentPageName().ToUpper() =="SUBMENU.ASPX"){

                cssList = "<link href='../Content/themes/$THEME$/FlyCnMain.css' rel='stylesheet' /> ";
            
            }else{
               cssList = "<link href='../Content/themes/$THEME$/FlyCnMain.css' rel='stylesheet' /><link href='Content/themes/$THEME$/FlyCnMain.css' rel='stylesheet' />  " +
       "<link href='../Content/themes/$THEME$/css/font-awesome.min.css' rel='stylesheet' />" +
       "<link href='../Content/themes/$THEME$/css/roboto_google_api.css' rel='stylesheet' />" +
       "<link href='Content/themes/$THEME$/css/datepicker.css' rel='stylesheet' type='text/css' />" +
       "<link href='../Content/themes/$THEME$/css/bootstrap.min.css' rel='stylesheet' />" +
       "<link href='../Content/themes/$THEME$/css/stylesheet.css' rel='stylesheet' />" +
       "<link href='../Content/themes/$THEME$/css/selectize.css' rel='stylesheet' type='text/css' />" +
       "<link href='../Content/themes/$THEME$/css/accodin.css' rel='stylesheet' type='text/css' />" +
       "<link href='../Content/themes/$THEME$/css/style.css' rel='stylesheet' type='text/css' />" +
       "<link href='../Content/themes/$THEME$/TabStrip.FlyCnRed_Rad.css' rel='stylesheet' />";
            }

           

            cssList = cssList.Replace("$THEME$", UA.theme);

            LiteralControl Css = new LiteralControl(cssList);

            return Css;

        }

        public LiteralControl GetLandingThemeCss()
        {

            FlyCnDAL.Security.UserAuthendication UA;
            FlyCnDAL.DALConstants DALConst = new FlyCnDAL.DALConstants();
            UIClasses.Const Const = new UIClasses.Const();
            HttpContext context = HttpContext.Current;
            UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];

            string cssList = "<link href='../Content/themes/$THEME$/FlyCnMain.css' rel='stylesheet' />" +
             "<link href='../Content/Site.css' rel='stylesheet' />";

            if (UA != null)
            {

                cssList = cssList.Replace("$THEME$", UA.theme);
            }
            else
            {
                cssList = cssList.Replace("$THEME$", DALConst.DefaultTheme);
            }

            LiteralControl Css = new LiteralControl(cssList);

            return Css;

        }

    }
}