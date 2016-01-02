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
        public ApproveBtn ApproveButton;
        public DeclineBtn DeclineButton;
        public RejectBtn RejectButton;
        public AttachBtn AttachButton;

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
              ApproveButton = new ApproveBtn(CommonToolBar);
              DeclineButton = new DeclineBtn(CommonToolBar);
              RejectButton = new RejectBtn(CommonToolBar);
              AttachButton = new AttachBtn(CommonToolBar);


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
                        CommonToolBar.FindItemByValue("EditApproveSeperator").Style["display"] = "";
                    }
                    else
                    {
                        CommonToolBar.FindItemByValue("Edit").Style["display"] = "none";
                        CommonToolBar.FindItemByValue("EditApproveSeperator").Style["display"] = "none";
                    }


                }


            }
            public void registerScript_onClientClick(string JavaScriptFunction)
            {

                CommonToolBar.FindItemByValue("Edit").Attributes.Add("OnClick", JavaScriptFunction);
            }


        }

        public class ApproveBtn
        {
            public RadToolBar CommonToolBar;

            public ApproveBtn(RadToolBar ToolBar)
            {
                this.CommonToolBar = ToolBar;
            }


            //------------------ Approve  -----------------------------------------------
            public bool Visible
            {

                get
                {
                    if (CommonToolBar.FindItemByValue("Approve").Style["display"] == "block" || CommonToolBar.FindItemByValue("Approve").Style["display"] == "")
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
                        CommonToolBar.FindItemByValue("Approve").Style["display"] = "";
                        CommonToolBar.FindItemByValue("ApproveDeclineSeperator").Style["display"] = "";
                    }
                    else
                    {
                        CommonToolBar.FindItemByValue("Approve").Style["display"] = "none";
                        CommonToolBar.FindItemByValue("ApproveDeclineSeperator").Style["display"] = "none";
                    }


                }


            }
            public void registerScript_onClientClick(string JavaScriptFunction)
            {

                CommonToolBar.FindItemByValue("Approve").Attributes.Add("OnClick", JavaScriptFunction);
            }


        }

        public class DeclineBtn
        {
            public RadToolBar CommonToolBar;

            public DeclineBtn(RadToolBar ToolBar)
            {
                this.CommonToolBar = ToolBar;
            }


            //------------------ Edit  -----------------------------------------------
            public bool Visible
            {

                get
                {
                    if (CommonToolBar.FindItemByValue("Decline").Style["display"] == "block" || CommonToolBar.FindItemByValue("Decline").Style["display"] == "")
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
                        CommonToolBar.FindItemByValue("Decline").Style["display"] = "";
                         CommonToolBar.FindItemByValue("DeclineRejectSeperator").Style["display"] = "";
                    }
                    else
                    {
                        CommonToolBar.FindItemByValue("Decline").Style["display"] = "none";
                         CommonToolBar.FindItemByValue("DeclineRejectSeperator").Style["display"] = "none";
                    }


                }


            }
            public void registerScript_onClientClick(string JavaScriptFunction)
            {

                CommonToolBar.FindItemByValue("Decline").Attributes.Add("OnClick", JavaScriptFunction);
            }


        }

        public class RejectBtn
        {
            public RadToolBar CommonToolBar;

            public RejectBtn(RadToolBar ToolBar)
            {
                this.CommonToolBar = ToolBar;
            }


            //------------------ Edit  -----------------------------------------------
            public bool Visible
            {

                get
                {
                    if (CommonToolBar.FindItemByValue("Reject").Style["display"] == "block" || CommonToolBar.FindItemByValue("Reject").Style["display"] == "")
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
                        CommonToolBar.FindItemByValue("Reject").Style["display"] = "";
                        CommonToolBar.FindItemByValue("RejectAttachSeperator").Style["display"] = "";
                    }
                    else
                    {
                        CommonToolBar.FindItemByValue("Reject").Style["display"] = "none";
                        CommonToolBar.FindItemByValue("RejectAttachSeperator").Style["display"] = "none";
                    }


                }


            }
            public void registerScript_onClientClick(string JavaScriptFunction)
            {

                CommonToolBar.FindItemByValue("Reject").Attributes.Add("OnClick", JavaScriptFunction);
            }


        }

        public class AttachBtn
        {
            public RadToolBar CommonToolBar;

            public AttachBtn(RadToolBar ToolBar)
            {
                this.CommonToolBar = ToolBar;
            }


            //------------------ Edit  -----------------------------------------------
            public bool Visible
            {

                get
                {
                    if (CommonToolBar.FindItemByValue("Attach").Style["display"] == "block" || CommonToolBar.FindItemByValue("Attach").Style["display"] == "")
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
                        CommonToolBar.FindItemByValue("Attach").Style["display"] = "";
                        // CommonToolBar.FindItemByValue("UpdateDeleteSeperator").Style["display"] = "";
                    }
                    else
                    {
                        CommonToolBar.FindItemByValue("Attach").Style["display"] = "none";
                        // CommonToolBar.FindItemByValue("UpdateDeleteSeperator").Style["display"] = "none";
                    }


                }


            }
            public void registerScript_onClientClick(string JavaScriptFunction)
            {

                CommonToolBar.FindItemByValue("Attach").Attributes.Add("OnClick", JavaScriptFunction);
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
               this.ApproveButton.Visible = value;
               this.DeclineButton.Visible = value;
               this.RejectButton.Visible = value;
               this.AttachButton.Visible = value;
           
           }
        
        }


    }


    

}