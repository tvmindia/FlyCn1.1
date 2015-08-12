using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
namespace FlyCn.UserControls
{
    public partial class ToolBar : System.Web.UI.UserControl
    {
        public event Telerik.Web.UI.RadToolBarEventHandler onClick;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CommonToolBar_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            if (e.Item.Text == "Delete") {
                if (DeleteCancel.Value == "DeleteCancel")
                {
                    e.Item.Value = "DeleteCancel";
                }
                else {

                    e.Item.Value = "Delete";
                }
            }
            this.onClick(sender, e);
        }

//------------------ADD -----------------------------------------------
        public bool isAddVisible{

            get {
                if (CommonToolBar.FindItemByValue("Add").Style["display"] == "block" || CommonToolBar.FindItemByValue("Add").Style["display"] == "") {
                
                return true;
                }
                else {
                    return false;
                }
            
            }



            set {

                if (value) {
                    CommonToolBar.FindItemByValue("Add").Style["display"] = "";
                    CommonToolBar.FindItemByValue("addSaveSeperator").Style["display"] = "";
                }
                else {
                    CommonToolBar.FindItemByValue("Add").Style["display"] = "none";
                    CommonToolBar.FindItemByValue("addSaveSeperator").Style["display"] = "none";
                }
            
            
            }


        }


        //------------------Save -----------------------------------------------
        public bool isSaveVisible
        {

            get
            {
                if (CommonToolBar.FindItemByValue("Save").Style["display"] == "block" || CommonToolBar.FindItemByValue("Save").Style["display"] == "")
                {

                    return true;
                }
                else
                {
                    return false;
                }

            }



            set
            {

                if (value)
                {
                    CommonToolBar.FindItemByValue("Save").Style["display"] = "";
                    CommonToolBar.FindItemByValue("SaveUpdateSeperator").Style["display"] = "";
                }
                else
                {
                    CommonToolBar.FindItemByValue("Save").Style["display"] = "none";
                    CommonToolBar.FindItemByValue("SaveUpdateSeperator").Style["display"] = "none";
                }


            }


        }


        //------------------ update -----------------------------------------------
        public bool isUpdateVisible
        {

            get
            {
                if (CommonToolBar.FindItemByValue("Update").Style["display"] == "block" || CommonToolBar.FindItemByValue("Update").Style["display"] == "")
                {

                    return true;
                }
                else
                {
                    return false;
                }

            }



            set
            {

                if (value)
                {
                    CommonToolBar.FindItemByValue("Update").Style["display"] = "";
                    CommonToolBar.FindItemByValue("UpdateDeleteSeperator").Style["display"] = "";
                }
                else
                {
                    CommonToolBar.FindItemByValue("Update").Style["display"] = "none";
                    CommonToolBar.FindItemByValue("UpdateDeleteSeperator").Style["display"] = "none";
                }


            }


        }

        //------------------ Delete  -----------------------------------------------
        public bool isDeleteVisible
        {

            get
            {
                if (CommonToolBar.FindItemByValue("Delete").Style["display"] == "block" || CommonToolBar.FindItemByValue("Delete").Style["display"] == "")
                {

                    return true;
                }
                else
                {
                    return false;
                }

            }



            set
            {

                if (value)
                {
                    CommonToolBar.FindItemByValue("Delete").Style["display"] = "";
                   // CommonToolBar.FindItemByValue("UpdateDeleteSeperator").Style["display"] = "";
                }
                else
                {
                    CommonToolBar.FindItemByValue("Delete").Style["display"] = "none";
                   // CommonToolBar.FindItemByValue("UpdateDeleteSeperator").Style["display"] = "none";
                }


            }


        }




        public bool VisibleAll { 

           set {
               this.isAddVisible = value;
               this.isSaveVisible = value;
               this.isUpdateVisible = value;
               this.isDeleteVisible = value;
           
           }
        
        }


        protected override void OnPreRender(EventArgs e)
        {
            CommonToolBar.FindItemByValue("Delete").Attributes.Add("OnClick", "return confirmation('" +  CommonToolBar.ClientID + "');");
        }
    }


    

}