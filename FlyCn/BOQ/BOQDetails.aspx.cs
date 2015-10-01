using FlyCn.FlyCnDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace FlyCn.BOQ
{
    public partial class BOQDetails : System.Web.UI.Page
    {
        BOQHeaderDetails bOQHeaderDetails;
        UIClasses.Const Const = new UIClasses.Const();
        ErrorHandling eObj = new ErrorHandling(); 
        FlyCnDAL.Security.UserAuthendication UA;
        string Revisionid,Itemidstring;
        protected void Page_Load(object sender, EventArgs e)
        {
            UA = (FlyCnDAL.Security.UserAuthendication)Session[Const.LoginSession];
            Revisionid = Request.QueryString["Revisionid"];

            hdfRevisionId.Value = Revisionid;
            ToolBar1.onClick += new RadToolBarEventHandler(ToolBar_onClick);
            ToolBar1.OnClientButtonClicking = "OnClientButtonClickingDetail";
            ToolBarVisibility(1);
        }
       
        #region ToolBar_onClick
         protected void ToolBar_onClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            string functionName = e.Item.Value;

             if(e.Item.Value=="Add")
             {
                 AddBOQDocumentDetails();
                 ToolBarVisibility(2);
             }


            if (e.Item.Value == "Save")
            {
                AddBOQDocumentDetails();
                ToolBarVisibility(2);
            }
            if (e.Item.Value == "Update")
            {
                UpdateBOQDocumentDetails();
                ToolBarVisibility(2);
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ClearMessage(page);
            }
            if (e.Item.Value == "Delete")
            {
                DeleteBOQDocumentDetails();
                ToolBarVisibility(3);
            }
        }
        #endregion ToolBar_onClick

         #region ToolBarVisibility
         public void ToolBarVisibility(int order)
         {
             switch (order)
             {
                 case 1://after adding what should be visible
                     ToolBar1.AddButton.Visible = false;
                     ToolBar1.SaveButton.Visible = true;
                     ToolBar1.UpdateButton.Visible = false;
                     ToolBar1.DeleteButton.Visible = false;
                     break;
                 case 2:
                     ToolBar1.AddButton.Visible = true;
                     ToolBar1.SaveButton.Visible = false;
                     ToolBar1.UpdateButton.Visible = true;
                     ToolBar1.DeleteButton.Visible = true;
                     break;
                 case 3:
                     ToolBar1.AddButton.Visible = true;
                     ToolBar1.SaveButton.Visible = false;
                     ToolBar1.UpdateButton.Visible = false;
                     ToolBar1.DeleteButton.Visible = false;
                     break;


             }

         }
         #endregion ToolBarVisibility

         public void AddBOQDocumentDetails()
         {
             string ItemId = "";
             try
             {
                 Guid Revid;
                 Revisionid = hdfRevisionId.Value;
                 bOQHeaderDetails = new BOQHeaderDetails();
                 Guid.TryParse(Revisionid, out Revid);
                 bOQHeaderDetails.bOQDetails.RevisionID = Revid;
                 bOQHeaderDetails.bOQDetails.ProjectNo = UA.projectNo;
                 bOQHeaderDetails.bOQDetails.ItemNo = Int16.Parse(txtItemNo.Text);
                 bOQHeaderDetails.bOQDetails.ItemDescription = (txtItemDescription.Text.Trim() != "") ? txtItemDescription.Text.Trim().ToString() : null;



                 bOQHeaderDetails.bOQDetails.Quantity = (txtQuantity.Text.Trim() != "") ? Convert.ToSingle(txtQuantity.Text.Trim()) : Convert.ToSingle(null);
                 bOQHeaderDetails.bOQDetails.Unit = (txtUnit.Text.Trim() != "") ? txtUnit.Text.Trim().ToString() : null;
                 bOQHeaderDetails.bOQDetails.NormHours = (txtNormalHours.Text.Trim() != "") ? Convert.ToSingle(txtNormalHours.Text.Trim()) : Convert.ToSingle(null);
                 bOQHeaderDetails.bOQDetails.LabourRate = (txtLabourRate.Text.Trim() != "") ? Convert.ToSingle(txtLabourRate.Text.Trim()) : Convert.ToSingle(null);
                 bOQHeaderDetails.bOQDetails.LabourRateType = (txtLabourRateType.Text.Trim() != "") ? (txtLabourRateType.Text.Trim().ToString()) : null;
                 bOQHeaderDetails.bOQDetails.MaterialRate = (txtMaterialRate.Text.Trim() != "") ? Convert.ToSingle(txtMaterialRate.Text.Trim()) : Convert.ToSingle(null);
                 bOQHeaderDetails.bOQDetails.UDFRate1 = (txtUDFRate1.Text.Trim() != "") ? Convert.ToSingle(txtUDFRate1.Text.Trim()) : Convert.ToSingle(null);
                 bOQHeaderDetails.bOQDetails.UDFRateType1 = (txtUDFRateType1.Text.Trim() != "") ? (txtUDFRateType1.Text.Trim().ToString()) : null;

                 bOQHeaderDetails.bOQDetails.UDFRate2 = (txtUDFRate2.Text.Trim() != "") ? Convert.ToSingle(txtUDFRate2.Text.Trim()) : Convert.ToSingle(null);
                 bOQHeaderDetails.bOQDetails.UDFRateType2 = (txtUDFRateType2.Text.Trim() != "") ? (txtUDFRateType2.Text.Trim().ToString()) : null;

                 bOQHeaderDetails.bOQDetails.UDFRate3 = (txtUDFRate3.Text.Trim() != "") ? Convert.ToSingle(txtUDFRate3.Text.Trim()) : Convert.ToSingle(null);
                 bOQHeaderDetails.bOQDetails.UDFRateType3 = (txtUDFRateType3.Text.Trim() != "") ? (txtUDFRateType3.Text.Trim().ToString()) : null;

                 bOQHeaderDetails.bOQDetails.UDFRate4 = (txtUDFRate4.Text.Trim() != "") ? Convert.ToSingle(txtUDFRate4.Text.Trim()) : Convert.ToSingle(null);
                 bOQHeaderDetails.bOQDetails.UDFRateType4 = (txtUDFRateType4.Text.Trim() != "") ? (txtUDFRateType4.Text.Trim().ToString()) : null;

                 bOQHeaderDetails.bOQDetails.UDFRate5 = (txtUDFRate5.Text.Trim() != "") ? Convert.ToSingle(txtUDFRate5.Text.Trim()) : Convert.ToSingle(null);
                 bOQHeaderDetails.bOQDetails.UDFRateType5 = (txtUDFRateType5.Text.Trim() != "") ? (txtUDFRateType5.Text.Trim().ToString()) : null;


                 bOQHeaderDetails.bOQDetails.Group1 = (txtGroup1.Text.Trim() != "") ? (txtGroup1.Text.Trim().ToString()) : null;
                 bOQHeaderDetails.bOQDetails.Group2 = (txtGroup2.Text.Trim() != "") ? (txtGroup2.Text.Trim().ToString()) : null;
                 bOQHeaderDetails.bOQDetails.Group3 = (txtGroup3.Text.Trim() != "") ? (txtGroup3.Text.Trim().ToString()) : null;
                 bOQHeaderDetails.bOQDetails.Group4 = (txtGroup4.Text.Trim() != "") ? (txtGroup4.Text.Trim().ToString()) : null;
                 bOQHeaderDetails.bOQDetails.Group5 = (txtGroup5.Text.Trim() != "") ? (txtGroup5.Text.Trim().ToString()) : null;

                 ItemId = bOQHeaderDetails.bOQDetails.AddBOQDetails();
                 hdfItemId.Value = ItemId;//hiddenfield assinging outputparamitemid
             }
             catch(Exception ex)
             {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
             }
         }
         public void UpdateBOQDocumentDetails()
         {
             
             try
             {
                 Guid Revid,Itemid;
                 Revisionid = hdfRevisionId.Value;
                 Itemidstring = hdfItemId.Value;
                 bOQHeaderDetails = new BOQHeaderDetails();
                 Guid.TryParse(Revisionid, out Revid);//string to guid conversion
                 Guid.TryParse(Itemidstring, out Itemid);
                 bOQHeaderDetails.bOQDetails.RevisionID = Revid;
                 bOQHeaderDetails.bOQDetails.ProjectNo = UA.projectNo;
                 bOQHeaderDetails.bOQDetails.ItemID = Itemid;
                 bOQHeaderDetails.bOQDetails.ItemNo = Int16.Parse(txtItemNo.Text);
                 bOQHeaderDetails.bOQDetails.ItemDescription = (txtItemDescription.Text.Trim() != "") ? txtItemDescription.Text.Trim().ToString() : null;

                 bOQHeaderDetails.bOQDetails.Quantity = (txtQuantity.Text.Trim() != "") ? Convert.ToSingle(txtQuantity.Text.Trim()) : Convert.ToSingle(null);
                 bOQHeaderDetails.bOQDetails.Unit = (txtUnit.Text.Trim() != "") ? txtUnit.Text.Trim().ToString() : null;
                 bOQHeaderDetails.bOQDetails.NormHours = (txtNormalHours.Text.Trim() != "") ? Convert.ToSingle(txtNormalHours.Text.Trim()) : Convert.ToSingle(null);
                 bOQHeaderDetails.bOQDetails.LabourRate = (txtLabourRate.Text.Trim() != "") ? Convert.ToSingle(txtLabourRate.Text.Trim()) : Convert.ToSingle(null);
                 bOQHeaderDetails.bOQDetails.LabourRateType = (txtLabourRateType.Text.Trim() != "") ? (txtLabourRateType.Text.Trim().ToString()) : null;
                 bOQHeaderDetails.bOQDetails.MaterialRate = (txtMaterialRate.Text.Trim() != "") ? Convert.ToSingle(txtMaterialRate.Text.Trim()) : Convert.ToSingle(null);
                 bOQHeaderDetails.bOQDetails.UDFRate1 = (txtUDFRate1.Text.Trim() != "") ? Convert.ToSingle(txtUDFRate1.Text.Trim()) : Convert.ToSingle(null);
                 bOQHeaderDetails.bOQDetails.UDFRateType1 = (txtUDFRateType1.Text.Trim() != "") ? (txtUDFRateType1.Text.Trim().ToString()) : null;

                 bOQHeaderDetails.bOQDetails.UDFRate2 = (txtUDFRate2.Text.Trim() != "") ? Convert.ToSingle(txtUDFRate2.Text.Trim()) : Convert.ToSingle(null);
                 bOQHeaderDetails.bOQDetails.UDFRateType2 = (txtUDFRateType2.Text.Trim() != "") ? (txtUDFRateType2.Text.Trim().ToString()) : null;

                 bOQHeaderDetails.bOQDetails.UDFRate3 = (txtUDFRate3.Text.Trim() != "") ? Convert.ToSingle(txtUDFRate3.Text.Trim()) : Convert.ToSingle(null);
                 bOQHeaderDetails.bOQDetails.UDFRateType3 = (txtUDFRateType3.Text.Trim() != "") ? (txtUDFRateType3.Text.Trim().ToString()) : null;

                 bOQHeaderDetails.bOQDetails.UDFRate4 = (txtUDFRate4.Text.Trim() != "") ? Convert.ToSingle(txtUDFRate4.Text.Trim()) : Convert.ToSingle(null);
                 bOQHeaderDetails.bOQDetails.UDFRateType4 = (txtUDFRateType4.Text.Trim() != "") ? (txtUDFRateType4.Text.Trim().ToString()) : null;

                 bOQHeaderDetails.bOQDetails.UDFRate5 = (txtUDFRate5.Text.Trim() != "") ? Convert.ToSingle(txtUDFRate5.Text.Trim()) : Convert.ToSingle(null);
                 bOQHeaderDetails.bOQDetails.UDFRateType5 = (txtUDFRateType5.Text.Trim() != "") ? (txtUDFRateType5.Text.Trim().ToString()) : null;


                 bOQHeaderDetails.bOQDetails.Group1 = (txtGroup1.Text.Trim() != "") ? (txtGroup1.Text.Trim().ToString()) : null;
                 bOQHeaderDetails.bOQDetails.Group2 = (txtGroup2.Text.Trim() != "") ? (txtGroup2.Text.Trim().ToString()) : null;
                 bOQHeaderDetails.bOQDetails.Group3 = (txtGroup3.Text.Trim() != "") ? (txtGroup3.Text.Trim().ToString()) : null;
                 bOQHeaderDetails.bOQDetails.Group4 = (txtGroup4.Text.Trim() != "") ? (txtGroup4.Text.Trim().ToString()) : null;
                 bOQHeaderDetails.bOQDetails.Group5 = (txtGroup5.Text.Trim() != "") ? (txtGroup5.Text.Trim().ToString()) : null;

                 Itemidstring = bOQHeaderDetails.bOQDetails.UpdateBOQDocumentDetails();
                 hdfItemId.Value = Itemidstring;//hiddenfield assinging outputparamitemid
             }
             catch (Exception ex)
             {
                 var page = HttpContext.Current.CurrentHandler as Page;
                 eObj.ErrorData(ex, page);
             }
         }
         public void DeleteBOQDocumentDetails()
         {
             try
             {
                 Guid Revid, Itemid;
                 Revisionid = hdfRevisionId.Value;
                 Itemidstring = hdfItemId.Value;
                 bOQHeaderDetails = new BOQHeaderDetails();
                 Guid.TryParse(Revisionid, out Revid);//string to guid conversion
                 Guid.TryParse(Itemidstring, out Itemid);
                 bOQHeaderDetails.bOQDetails.RevisionID = Revid;
                 bOQHeaderDetails.bOQDetails.ItemID = Itemid;
                 bOQHeaderDetails.bOQDetails.DeleteBOQDocumentDetails();

             }
             catch(Exception ex)
             {

             }

         }

    }
}