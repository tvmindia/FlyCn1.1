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
        #region public properties
        public int ErrorNumber
        {
            get;
            set;
        }
        #endregion public properties

        #region ErrorData
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
        #endregion ErrorData

        #region ClearMessage
        public void ClearMessage( Page pg) {

            var master = pg.Master;             
            Label error = (Label)master.FindControl("lblErrorInfo");            
            HtmlControl divMask = (HtmlControl)master.FindControl("Errorbox");
            divMask.Style["visibility"] = "hidden";
            error.Text = ""; 
        }
        #endregion ClearMessage

        #region ClearMessage(MasterPage master)
        public void ClearMessage(MasterPage master)
        {            
            Label error = (Label)master.FindControl("lblErrorInfo");
            HtmlControl divMask = (HtmlControl)master.FindControl("Errorbox");
            divMask.Style["visibility"] = "hidden";
            error.Text = "";
        }
        #endregion ClearMessage(MasterPage master)

        #region AlreadyExistsData
        public void AlreadyExistsData(Page pg)
        {
            var master1 = pg.Master;
            ContentPlaceHolder mpContentPlaceHolder1;
            Label Success = (Label)master1.FindControl("lblErrorInfo");
            mpContentPlaceHolder1 = (ContentPlaceHolder)master1.FindControl("MainBody");
            HtmlControl divMask1 = (HtmlControl)master1.FindControl("Errorbox");
            divMask1.Style["display"] = "";// divMask1.Style["display"] = "";   
            divMask1.Style["visibility"] = "visible";

            divMask1.Attributes["class"] = "ErrormsgBoxes";
            Success.Text = "Insertion failed..RoleName already exists..!!!"; 
 
        }
        #endregion AlreadyExistsData

        #region AlreadyExistsProjectNo
        public void AlreadyExistsProjectNo(Page pg)
        {
            var master1 = pg.Master;
            ContentPlaceHolder mpContentPlaceHolder1;
            Label Success = (Label)master1.FindControl("lblErrorInfo");
            mpContentPlaceHolder1 = (ContentPlaceHolder)master1.FindControl("MainBody");
            HtmlControl divMask1 = (HtmlControl)master1.FindControl("Errorbox");
            divMask1.Style["display"] = "";// divMask1.Style["display"] = "";   
            divMask1.Style["visibility"] = "visible";

            divMask1.Attributes["class"] = "ErrormsgBoxes";
            Success.Text = "Deletion failed..Project No is  already used..!!!";

        }
        #endregion AlreadyExistsProjectNo

        #region InsertionSuccessData
        public void InsertionSuccessData(Page pg)
  
            {

                var master1 = pg.Master;
                ContentPlaceHolder mpContentPlaceHolder1;
                mpContentPlaceHolder1 = (ContentPlaceHolder)master1.FindControl("MainBody");
                   HtmlControl divMask1 = (HtmlControl)master1.FindControl("Errorbox");
                divMask1.Style["display"] = "";// divMask1.Style["display"] = "";   
                divMask1.Style["visibility"] = "visible";
                Label Success = (Label)master1.FindControl("lblErrorInfo");
                divMask1.Attributes["class"] = "Succesmsgboxes";
                Success.Text = "Successfully Inserted..!!!"; 
 
  }
        #endregion InsertionSuccessData

        #region MandatoryFieldsData
        public void MandatoryFieldsData(Page pg)
         {
             var master1 = pg.Master;
             ContentPlaceHolder mpContentPlaceHolder1;
             Label Success = (Label)master1.FindControl("lblErrorInfo");
             mpContentPlaceHolder1 = (ContentPlaceHolder)master1.FindControl("MainBody");
             HtmlControl divMask1 = (HtmlControl)master1.FindControl("Errorbox");
             divMask1.Style["display"] = "";// divMask1.Style["display"] = "";   
             divMask1.Style["visibility"] = "visible";

             divMask1.Attributes["class"] = "ErrormsgBoxes";
             Success.Text = "Please Enter All The Mandatory Fields..!!!";

         }
        #endregion MandatoryFieldsData

        #region AllocateSuccessData
        public void AllocateSuccessData(Page pg)
         {

             var master1 = pg.Master;
             ContentPlaceHolder mpContentPlaceHolder1;
             mpContentPlaceHolder1 = (ContentPlaceHolder)master1.FindControl("MainBody");
             HtmlControl divMask1 = (HtmlControl)master1.FindControl("Errorbox");
             divMask1.Style["display"] = "";// divMask1.Style["display"] = "";   
             divMask1.Style["visibility"] = "visible";
             Label Success = (Label)master1.FindControl("lblErrorInfo");
             divMask1.Attributes["class"] = "Succesmsgboxes";
             Success.Text = "Successfully Allocated..!!!";

         }
        #endregion AllocateSuccessData

        #region ErrorMessage
        public void ErrorMessage(Page pg)
         {

             var master1 = pg.Master;
             ContentPlaceHolder mpContentPlaceHolder1;
             mpContentPlaceHolder1 = (ContentPlaceHolder)master1.FindControl("MainBody");
             HtmlControl divMask1 = (HtmlControl)master1.FindControl("Errorbox");
             divMask1.Style["display"] = "";// divMask1.Style["display"] = "";   
             divMask1.Style["visibility"] = "visible";
             Label Success = (Label)master1.FindControl("lblErrorInfo");
             divMask1.Attributes["class"] = "Succesmsgboxes";
             Success.Text = "Invalid Column..!!!";

         }
        #endregion ErrorMessage

        #region InsertionSuccessData(Page pg,string msg)
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
        #endregion InsertionSuccessData(Page pg,string msg)

        #region UpdationSuccessData(Page pg)
        public void UpdationSuccessData(Page pg)
         {
             var master1 = pg.Master;
             ContentPlaceHolder mpContentPlaceHolder1; 
             mpContentPlaceHolder1 = (ContentPlaceHolder)master1.FindControl("MainBody");
             HtmlControl divMask1 = (HtmlControl)master1.FindControl("Errorbox");
             divMask1.Style["visibility"] = "visible";
             divMask1.Style["display"] = "";
             Label Success = (Label)master1.FindControl("lblErrorInfo");
             divMask1.Attributes["class"] = "Succesmsgboxes";
             Success.Text = "Successfully Updated";

             //ContentPlaceHolder mpContentPlaceHoldertest;
             //mpContentPlaceHoldertest = (ContentPlaceHolder)master1.FindControl("ContentPlaceHolder1");
             //((UpdatePanel)mpContentPlaceHoldertest.FindControl("upsuccessMessage")).Update(); 
             //(master1.FindControl("lblErrorInfo") as Label).Text = "Service Deleted";
             //UpdatePanel upsuccessMessage = (UpdatePanel)master1.FindControl("upsuccessMessage");
             //upsuccessMessage.Update();
         }
        #endregion UpdationSuccessData(Page pg)

        #region UpdationSuccessData(Page pg,string msg)
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
        #endregion UpdationSuccessData(Page pg,string msg)

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

        #region DeleteSuccessData(Page pg)
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
        #endregion DeleteSuccessData(Page pg)

        #region DeAllocateSuccessData(Page pg)
        public void DeAllocateSuccessData(Page pg)
        {
            var master1 = pg.Master;
            ContentPlaceHolder mpContentPlaceHolder1;
            mpContentPlaceHolder1 = (ContentPlaceHolder)master1.FindControl("MainBody");
            HtmlControl divMask1 = (HtmlControl)master1.FindControl("Errorbox");
            divMask1.Style["visibility"] = "visible"; //divMask1.Style["display"] = "";
            Label Success = (Label)master1.FindControl("lblErrorInfo");
            divMask1.Attributes["class"] = "Succesmsgboxes";
            Success.Text = "DeAllocated Successfully..!!!";
        }
        #endregion DeAllocateSuccessData(Page pg)

        #region SqlNoDataError
        public void SqlNoDataError(Exception ex, Page pg)
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
            error.Text = "No Corresponding Data In Database";

        }
        #endregion SqlNoDataError
    }
}