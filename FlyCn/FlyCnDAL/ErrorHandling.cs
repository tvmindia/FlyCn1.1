using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace FlyCn.FlyCnDAL
{
    public class ErrorHandling
    {
          public int ErrorNumber
        {
            get;
            set;
        }
        public void ErrorData(Exception ex,Page pg)
        {
            //defn
            //1 accept page obj
            //2 find its master
            //3 find the div control in master
            //4 assign ex msg to error label
            //5 show div
            var master = pg.Master;
            ContentPlaceHolder mpContentPlaceHolder;

            //Set ContentPlaceHolder = to specific ContentPlaceHolder on your .aspx page
            mpContentPlaceHolder = (ContentPlaceHolder)master.FindControl("MainBody");
            //ContentPlaceHolder myPlaceHolder = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
            //ContentPlaceHolder myContent = (ContentPlaceHolder)pg.Master.FindControl("MainBody");
            //ContentPlaceHolder MainContent = pg.Master.FindControl("Content2") as ContentPlaceHolder;
          //  var div = master.FindControl("Errorbox");   
            //ContentPlaceHolder MainContent = Page..FindControl("MainContent") as ContentPlaceHolder;
            HtmlControl divMask = (HtmlControl)master.FindControl("Errorbox");
            //HtmlControl div1 = (HtmlControl)master.FindControl("masterDiv");
            //div1.Attributes.CssStyle.Add("opacity", "0.1");
         //   div1.Attributes.Add("Disabled", "");   
            //foreach (Control c in pg.Controls)
            //{ 
            //    if (c is TextBox)
                
            //        ((TextBox)(c)).Enabled = false;
                
            //    else
            //        if(c is Button)
            //        ((Button)(c)).Enabled = false;
            //    }
            //DisableAllControls(pg);

      
            divMask.Style["display"] = "";
            Label error = (Label)master.FindControl("lblErrorInfo");
            error.Text = ex.Message;     
        }
        //private void DisableAllControls(Control Page)
        //{
        //    foreach (Control ctrl in Page.Controls)
        //    {
        //        if (ctrl is TextBox) ((TextBox)(ctrl)).Enabled = false;
        //        else if (ctrl is Button) ((Button)(ctrl)).Enabled = false;
        //        else if (ctrl is DropDownList) ((DropDownList)(ctrl)).Enabled = false;
        //        else if (ctrl is ListBox) ((ListBox)(ctrl)).Enabled = false;
        //        else if (ctrl is CheckBox) ((CheckBox)(ctrl)).Enabled = false;
        //        else if (ctrl is CheckBoxList) ((CheckBoxList)(ctrl)).Enabled = false;
        //        else if (ctrl is RadioButton) ((RadioButton)(ctrl)).Enabled = false;
        //        else if (ctrl is RadioButtonList) ((RadioButtonList)(ctrl)).Enabled = false;
        //        else
        //        {
        //            if (ctrl.Controls.Count > 0) DisableAllControls(ctrl);
        //        }
        //    }
        //}


        
    }
}