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
        public event Telerik.Web.UI.RadToolBarEventHandler onClick; //for parent page click event

        //------- buttons --------------
        public AddBtn AddButton ;
        public SaveBtn SaveButton ;
        public UpdateBtn UpdateButton  ;
        public DeleteBtn DeleteButton  ;
        public EditBtn EditButton;

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            // assign each button wthin the tool bar
               AddButton = new AddBtn(CommonToolBar);
               SaveButton = new SaveBtn(CommonToolBar);
               UpdateButton = new UpdateBtn(CommonToolBar);
               DeleteButton = new DeleteBtn(CommonToolBar);
              EditButton = new EditBtn(CommonToolBar);
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

        public class AddBtn
        {

            public RadToolBar CommonToolBar;

            public AddBtn(RadToolBar ToolBar)
            {
                this.CommonToolBar = ToolBar;
            }



            //------------------ADD -----------------------------------------------
            public bool Visible
            {

                get
                {
                    if (CommonToolBar.FindItemByValue("Add").Style["display"] == "block" || CommonToolBar.FindItemByValue("Add").Style["display"] == "")
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
                        CommonToolBar.FindItemByValue("Add").Style["display"] = "";
                        CommonToolBar.FindItemByValue("addSaveSeperator").Style["display"] = "";
                    }
                    else
                    {
                        CommonToolBar.FindItemByValue("Add").Style["display"] = "none";
                        CommonToolBar.FindItemByValue("addSaveSeperator").Style["display"] = "none";
                    }


                }


            }

            public void registerScript_onClientClick(string JavaScriptFunction)
            {

                CommonToolBar.FindItemByValue("Add").Attributes.Add("OnClick", JavaScriptFunction);
            }

        }
        public class SaveBtn {
            public SaveBtn(RadToolBar ToolBar)
            {
                this.CommonToolBar = ToolBar;
            
            }
            public RadToolBar CommonToolBar;

            //------------------Save -----------------------------------------------
            public bool  Visible
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

            public void registerScript_onClientClick(string JavaScriptFunction)
            {

                CommonToolBar.FindItemByValue("Save").Attributes.Add("OnClick", JavaScriptFunction);
            }

        }

        public class UpdateBtn {
            public RadToolBar CommonToolBar;
            public UpdateBtn(RadToolBar ToolBar)
            {
                this.CommonToolBar = ToolBar;            
            }
            //------------------ update -----------------------------------------------
            public bool Visible
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
            public void registerScript_onClientClick(string JavaScriptFunction)
            {

                CommonToolBar.FindItemByValue("Update").Attributes.Add("OnClick", JavaScriptFunction);
            }
        
        }

        public class DeleteBtn {
            public RadToolBar CommonToolBar;

            public DeleteBtn(RadToolBar ToolBar)
            {
                this.CommonToolBar = ToolBar;            
            }


            //------------------ Delete  -----------------------------------------------
            public bool  Visible
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
                         CommonToolBar.FindItemByValue("UpdateEditSeperator").Style["display"] = "";
                    }
                    else
                    {
                        CommonToolBar.FindItemByValue("Delete").Style["display"] = "none";
                        CommonToolBar.FindItemByValue("UpdateEditSeperator").Style["display"] = "none";
                    }


                }


            }
            public void registerScript_onClientClick(string JavaScriptFunction)
            {

                CommonToolBar.FindItemByValue("Delete").Attributes.Add("OnClick", JavaScriptFunction);
            }
        
        
        }

        public class EditBtn
        {
            public RadToolBar CommonToolBar;

            public EditBtn(RadToolBar ToolBar)
            {
                this.CommonToolBar = ToolBar;
            }


            //------------------ Edit  -----------------------------------------------
            public bool Visible
            {

                get
                {
                    if (CommonToolBar.FindItemByValue("Edit").Style["display"] == "block" || CommonToolBar.FindItemByValue("Edit").Style["display"] == "")
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
                        CommonToolBar.FindItemByValue("Edit").Style["display"] = "";
                        // CommonToolBar.FindItemByValue("UpdateDeleteSeperator").Style["display"] = "";
                    }
                    else
                    {
                        CommonToolBar.FindItemByValue("Edit").Style["display"] = "none";
                        // CommonToolBar.FindItemByValue("UpdateDeleteSeperator").Style["display"] = "none";
                    }


                }


            }
            public void registerScript_onClientClick(string JavaScriptFunction)
            {

                CommonToolBar.FindItemByValue("Edit").Attributes.Add("OnClick", JavaScriptFunction);
            }


        }


        // register on client click javascript function
        public string  OnClientButtonClicking
        {
           set{
           CommonToolBar.OnClientButtonClicking = value;
           
           } 
        }


        public bool VisibleAll { 

           set {
               this.AddButton.Visible = value;
               this.SaveButton.Visible = value;
               this.UpdateButton.Visible = value;
               this.DeleteButton.Visible = value;
               this.EditButton.Visible = value;
           
           }
        
        }


    }


    

}