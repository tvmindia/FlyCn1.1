
#region CopyRight

//All rights are reserved
//Created By   :
//Created Date : 
//Purpose      : 

//Modified BY   : SHAMILA T P
//Modified Date : 6.2.2016
//Purpose       : To add web method (to implement security for subtiles)

#endregion CopyRight

#region Included Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using FlyCn.FlyCnDAL;
using FlyCnSecurity.SecurityDAL;

#endregion Included Namespaces

namespace FlyCn
{
    public partial class Menu : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            UIClasses.DynamicIcons ui = new UIClasses.DynamicIcons();

            string myInnerHtml = ui.GenerateMultiSizeImageString(null);//ui.GenerateImageString(null);

            //if (myInnerHtml.Contains("Access Denied"))
            //{
            //    lblAccessDenied.Text = "Access Denied";
            //}
            
            

            div1.Controls.Add(new LiteralControl(myInnerHtml));
        }


        #region GetPermissionOfSubTiles
        [WebMethod]
        public static bool GetPermissionOfSubTiles(string objName)
        {

             bool isRead = false;
             bool isWrite = false; ;
             bool isDelete = false; ;
             bool isEdit = false;
             bool isAdd = false; ;

             UIClasses.Const Const = new UIClasses.Const();
             FlyCnDAL.Security.UserAuthendication UA;
             var page = HttpContext.Current.CurrentHandler as Page;
             HttpContext context = HttpContext.Current;

             UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
             string usrname = UA.userName;


            bool SubTilePermissionDenied = false;
            SecurityUsers securityUsrObj = new SecurityUsers();
            string userAccess = securityUsrObj.GetUserAccess(usrname,objName);


            if (userAccess.Contains("w"))
                isWrite = true;
            else
                if (userAccess.Contains("e"))
                    isEdit = true;
                else
                    if (userAccess.Contains("a"))
                    {
                        isAdd = true;

                    }
                    else
                        if (userAccess.Contains("r"))
                            isRead = true;
                        else
                            
                       if (userAccess.Contains("d"))
                isDelete = true;


            if (isWrite == false && isAdd == false && isDelete == false && isEdit == false && isRead == false)
            {
                SubTilePermissionDenied = true;
            }

            if (userAccess == "")
            {
                 SubTilePermissionDenied = false;
            }


            //Security.PageSecurity PS;
            //PS = new Security.PageSecurity(pageName, objPage);
            //if (PS.isWrite != true && PS.isAdd != true && PS.isDelete != true && PS.isEdit != true && PS.isRead != true)
            //{
            //    SubTilePermissionDenied = true;
            //}

            return SubTilePermissionDenied;
        }

        #endregion GetPermissionOfSubTiles


        //#region SecurityCheck
          //public void SecurityCheck(string pageName, Page objPage)
          //{
          //    string logicalObject = pageName;

          //    PS = new Security.PageSecurity(pageName, objPage);

          //    if (PS.isWrite == true)
          //    {
                 
          //    }
          //    else
          //    {

          //    }

          //}
          //#endregion SecurityCheck




    }
}