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
            Label error = (Label)master.FindControl("lblErrorInfo");
            mpContentPlaceHolder = (ContentPlaceHolder)master.FindControl("MainBody");
            HtmlControl divMask = (HtmlControl)master.FindControl("Errorbox");
            divMask.Style["visibility"] = "visible";
            divMask.Attributes["class"] = "ErrormsgBoxes";
            error.Text = ex.Message;  

        }


        public void ClearMessage( Page pg) {

            var master = pg.Master;             
            Label error = (Label)master.FindControl("lblErrorInfo");            
            HtmlControl divMask = (HtmlControl)master.FindControl("Errorbox");
            divMask.Style["visibility"] = "hidden";
            error.Text = ""; 
        }

        public void ClearMessage(MasterPage master)
        {            
            Label error = (Label)master.FindControl("lblErrorInfo");
            HtmlControl divMask = (HtmlControl)master.FindControl("Errorbox");
            divMask.Style["visibility"] = "hidden";
            error.Text = "";
        }

         public void InsertionSuccessData(Page pg)
  
            {
                var master1 = pg.Master;
                ContentPlaceHolder mpContentPlaceHolder1;
                mpContentPlaceHolder1 = (ContentPlaceHolder)master1.FindControl("MainBody");
                HtmlControl divMask1 = (HtmlControl)master1.FindControl("Errorbox");
                divMask1.Style["display"] = "none";// divMask1.Style["display"] = "";              
              //  Label Success = (Label)master1.FindControl("lblErrorInfo");
                divMask1.Attributes["class"] = "Succesmsgboxes";
               // Success.Text = "Successfully Inserted";  
            }
         public void InsertionSuccessData(Page pg,string msg)//if insert does not happend becasue of already existing
         {
             var master1 = pg.Master;
             ContentPlaceHolder mpContentPlaceHolder1;
             mpContentPlaceHolder1 = (ContentPlaceHolder)master1.FindControl("MainBody");
             HtmlControl divMask1 = (HtmlControl)master1.FindControl("Errorbox");
             divMask1.Style["visibility"] = "visible";// divMask1.Style["display"] = "";              
             Label Success = (Label)master1.FindControl("lblErrorInfo");
             divMask1.Attributes["class"] = "Succesmsgboxes";
             Success.Text = msg;//message comes from the insert function
         }
        public void UpdationSuccessData(Page pg)
         {
             var master1 = pg.Master;
             ContentPlaceHolder mpContentPlaceHolder1; 
             mpContentPlaceHolder1 = (ContentPlaceHolder)master1.FindControl("MainBody");
             HtmlControl divMask1 = (HtmlControl)master1.FindControl("Errorbox");
             divMask1.Style["visibility"] = "visible";// divMask1.Style["display"] = "";
             Label Success = (Label)master1.FindControl("lblErrorInfo");
             divMask1.Attributes["class"] = "Succesmsgboxes";
             Success.Text = "Successfully Updated";  
         }

        public void UpdationSuccessData(Page pg,string msg)//if update fails
        {
            var master1 = pg.Master;
            ContentPlaceHolder mpContentPlaceHolder1;
            mpContentPlaceHolder1 = (ContentPlaceHolder)master1.FindControl("MainBody");
            HtmlControl divMask1 = (HtmlControl)master1.FindControl("Errorbox");
            divMask1.Style["visibility"] = "visible";// divMask1.Style["display"] = "";
            Label Success = (Label)master1.FindControl("lblErrorInfo");
            divMask1.Attributes["class"] = "Succesmsgboxes";
            Success.Text = msg;
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
        public void DeleteSuccessData(Page pg)
        {
            var master1 = pg.Master;
            ContentPlaceHolder mpContentPlaceHolder1;
            mpContentPlaceHolder1 = (ContentPlaceHolder)master1.FindControl("MainBody");
            HtmlControl divMask1 = (HtmlControl)master1.FindControl("Errorbox");
            divMask1.Style["visibility"] = "visible"; //divMask1.Style["display"] = "";
            Label Success = (Label)master1.FindControl("lblErrorInfo");
            divMask1.Attributes["class"] = "Succesmsgboxes";
            Success.Text = "Deleted Successfully";
        }        
    }
}