using FlyCn.FlyCnDAL;
using System;
using System.Collections.Generic;
using System.Data;
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
        string Revisionid,Itemidstring,QueryTimeStatus;
        protected void Page_Load(object sender, EventArgs e)
        {
            UA = (FlyCnDAL.Security.UserAuthendication)Session[Const.LoginSession];
            Revisionid = Request.QueryString["Revisionid"];
            QueryTimeStatus = Request.QueryString["QueryTimeStatus"];
            hdfRevisionId.Value = Revisionid;
            ToolBarBOQDetail.onClick += new RadToolBarEventHandler(ToolBar_onClick);
            ToolBarBOQDetail.OnClientButtonClicking = "OnClientButtonClickingDetail";
            ToolBarVisibility(3);
            if(!IsPostBack)
            {
                if(QueryTimeStatus=="New")
                {
                    RadTab tab = (RadTab)RadTabStripBOQDetail.FindTabByValue("2");
                    tab.Selected = true;
                    tab.Text = "New";
                    RadMultiPageBOQDetail.SelectedIndex = 1;
                    ToolBarVisibility(1);//Save button visible
                }
            }
        }
       
        #region ToolBar_onClick
         protected void ToolBar_onClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            string functionName = e.Item.Value;

             if(e.Item.Value=="Add")
             {
                 var page = HttpContext.Current.CurrentHandler as Page;
                 eObj.ClearMessage(page);
                 RadTab tab = (RadTab)RadTabStripBOQDetail.FindTabByValue("2");
                 tab.Selected = true;
                 tab.Text = "New";
                 RadTabStripBOQDetail.SelectedIndex = 1;
                 ToolBarVisibility(1);
                 ScriptManager.RegisterStartupScript(this, this.GetType(), "ClearTextBox", "ClearTexBox();", true);
                 
             }


            if (e.Item.Value == "Save")
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ClearMessage(page);
                AddBOQDocumentDetails();
                ToolBarVisibility(2);
                dtgBOQDetailGrid.Rebind();
            }
            if (e.Item.Value == "Update")
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ClearMessage(page);
                UpdateBOQDocumentDetails();
                ToolBarVisibility(2);
                dtgBOQDetailGrid.Rebind();
               
            }
            if (e.Item.Value == "Delete")
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ClearMessage(page);
                DeleteBOQDocumentDetails();
                dtgBOQDetailGrid.Rebind();
                ToolBarVisibility(3);
              
            }
        }
        #endregion ToolBar_onClick

         #region ToolBarVisibility
         public void ToolBarVisibility(int order)
         {
             switch (order)
             {
                 case 1:
                     ToolBarBOQDetail.AddButton.Visible = false;
                     ToolBarBOQDetail.SaveButton.Visible = true;
                     ToolBarBOQDetail.UpdateButton.Visible = false;
                     ToolBarBOQDetail.DeleteButton.Visible = false;
                     break;
                 case 2:
                     ToolBarBOQDetail.AddButton.Visible = true;
                     ToolBarBOQDetail.SaveButton.Visible = false;
                     ToolBarBOQDetail.UpdateButton.Visible = true;
                     ToolBarBOQDetail.DeleteButton.Visible = false;
                     break;
                 case 3:
                     ToolBarBOQDetail.AddButton.Visible = true;
                     ToolBarBOQDetail.SaveButton.Visible = false;
                     ToolBarBOQDetail.UpdateButton.Visible = false;
                     ToolBarBOQDetail.DeleteButton.Visible = false;
                     break;


             }

         }
         #endregion ToolBarVisibility
          protected void dtgBOQDetailGrid_PreRender(object sender, EventArgs e)
          {
              try
              {
                  Guid RevID;
                  DataSet ds = new DataSet();
                  bOQHeaderDetails = new BOQHeaderDetails();
                  Revisionid = hdfRevisionId.Value;//Getting revision id from hiddenfield
                  Guid.TryParse(Revisionid, out RevID);
                  bOQHeaderDetails.bOQDetails.RevisionID = RevID;
                  bOQHeaderDetails.bOQDetails.ProjectNo = UA.projectNo;
                  ds = bOQHeaderDetails.bOQDetails.GetAllBOQDetails();
                  dtgBOQDetailGrid.DataSource = ds;
               }
              catch (Exception ex)
              {
                  var page = HttpContext.Current.CurrentHandler as Page;
                  eObj.ErrorData(ex, page);
              }
           
          }
          protected void dtgBOQDetailGrid_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
          {
              try
              {
                  Guid RevID;
                  DataSet ds = new DataSet();
                  bOQHeaderDetails = new BOQHeaderDetails();
                  Revisionid = hdfRevisionId.Value;//Getting revision id from hiddenfield
                  Guid.TryParse(Revisionid, out RevID);
                  bOQHeaderDetails.bOQDetails.RevisionID = RevID;
                  bOQHeaderDetails.bOQDetails.ProjectNo = UA.projectNo;
                  ds = bOQHeaderDetails.bOQDetails.GetAllBOQDetails();
                  dtgBOQDetailGrid.DataSource = ds;
                  //hiddenFiedldProjectno.Value = ds.Tables[0].Rows[0]["ProjectNo"].ToString();
                  //hiddenFieldDocumentID.Value = ds.Tables[0].Rows[0]["DocumentID"].ToString();
                  //hiddenFieldRevisionID.Value = ds.Tables[0].Rows[0]["RevisionID"].ToString();
              }
              catch (Exception ex)
              {
                  var page = HttpContext.Current.CurrentHandler as Page;
                  eObj.ErrorData(ex, page);
              }

          }
          protected void dtgBOQDetailGrid_ItemCommand(object source, GridCommandEventArgs e)
          {
              Guid Itemid;
              bOQHeaderDetails = new BOQHeaderDetails();
              try
              {
                  if (e.CommandName == "EditDoc")//RadGrid Edit
                  {
                      ToolBarVisibility(2);
                      RadTab tab = (RadTab)RadTabStripBOQDetail.FindTabByValue("2");
                      GridDataItem item = e.Item as GridDataItem;
                      tab.Selected = true;
                      tab.Text = "Edit";
                      RadMultiPageBOQDetail.SelectedIndex = 1;
                      string ProjectNo = item.GetDataKeyValue("ProjectNo").ToString();

                      DataSet ds = new DataSet();
                      bOQHeaderDetails = new BOQHeaderDetails();
                     
                      Guid.TryParse(item.GetDataKeyValue("ItemID").ToString(), out Itemid);
                      bOQHeaderDetails.bOQDetails.ItemID = Itemid;
                      ds = bOQHeaderDetails.bOQDetails.GetBOQDetailsByItemID();

                      hdfItemId.Value = ds.Tables[0].Rows[0]["ItemID"].ToString();
                      hdfRevisionId.Value = ds.Tables[0].Rows[0]["RevisionID"].ToString();
                   
                      txtItemDescription.Text = ds.Tables[0].Rows[0]["ItemDescription"].ToString();
                      txtQuantity.Text = ds.Tables[0].Rows[0]["Quantity"].ToString();
                      txtUnit.Text= ds.Tables[0].Rows[0]["Unit"].ToString();
                      txtNormalHours.Text = ds.Tables[0].Rows[0]["NormHours"].ToString();
                      txtLabourRate.Text = ds.Tables[0].Rows[0]["LabourRate"].ToString();
                      txtLabourRateType.Text = ds.Tables[0].Rows[0]["LabourRateType"].ToString();
                      txtMaterialRate.Text = ds.Tables[0].Rows[0]["MaterialRate"].ToString();
                      txtUDFRate1.Text = ds.Tables[0].Rows[0]["UDFRate1"].ToString();
                      txtUDFRateType1.Text = ds.Tables[0].Rows[0]["UDFRateType1"].ToString();
                      txtUDFRate2.Text = ds.Tables[0].Rows[0]["UDFRate2"].ToString();
                      txtUDFRateType2.Text = ds.Tables[0].Rows[0]["UDFRateType2"].ToString();
                      txtUDFRate3.Text = ds.Tables[0].Rows[0]["UDFRate3"].ToString();
                      txtUDFRateType3.Text = ds.Tables[0].Rows[0]["UDFRateType3"].ToString();
                      txtUDFRate4.Text = ds.Tables[0].Rows[0]["UDFRate4"].ToString();
                      txtUDFRateType4.Text = ds.Tables[0].Rows[0]["UDFRateType4"].ToString();
                      txtUDFRate5.Text = ds.Tables[0].Rows[0]["UDFRate5"].ToString();
                      txtUDFRateType5.Text = ds.Tables[0].Rows[0]["UDFRateType5"].ToString();
                      txtGroup1.Text = ds.Tables[0].Rows[0]["Group1"].ToString();
                      txtGroup2.Text = ds.Tables[0].Rows[0]["Group2"].ToString();
                      txtGroup3.Text = ds.Tables[0].Rows[0]["Group3"].ToString();
                      txtGroup4.Text = ds.Tables[0].Rows[0]["Group4"].ToString();
                      txtGroup5.Text = ds.Tables[0].Rows[0]["Group5"].ToString();
                     
                      
                  }
                  else
                  {
                      if (e.CommandName == "DeleteDoc")
                      {
                          GridDataItem item = e.Item as GridDataItem;
                          Guid.TryParse(item.GetDataKeyValue("ItemID").ToString(), out Itemid);
                          bOQHeaderDetails.bOQDetails.DeleteBOQDocumentDetails(Itemid);
                          dtgBOQDetailGrid.Rebind();
                      }
                  }
              }
              catch (Exception ex)
              {
                  var page = HttpContext.Current.CurrentHandler as Page;
                  eObj.ErrorData(ex, page);
              }


          }
      
        
         public void AddBOQDocumentDetails()
         {
          try
             {
                 Guid Revid;
                 Revisionid = hdfRevisionId.Value;
                 bOQHeaderDetails = new BOQHeaderDetails();
                 Guid.TryParse(Revisionid, out Revid);
                 bOQHeaderDetails.bOQDetails.RevisionID = Revid;
                 bOQHeaderDetails.bOQDetails.ProjectNo = UA.projectNo;
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
                 Guid itemid;
                 itemid = bOQHeaderDetails.bOQDetails.AddBOQDetails();
                 if (itemid != Guid.Empty)
                 {
                     hdfItemId.Value = itemid.ToString();//hiddenfield assinging outputparamitemid
                     RadTab tab = (RadTab)RadTabStripBOQDetail.FindTabByValue("1");
                     tab.Selected = true;
                  //   tab.Text = "Edit";
                     RadMultiPageBOQDetail.SelectedIndex = 0;
                 }
                
             }
             catch(Exception ex)
             {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
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

                 Itemidstring = bOQHeaderDetails.bOQDetails.UpdateBOQDocumentDetails(Itemid);
                 hdfItemId.Value = Itemidstring;//hiddenfield assinging outputparamitemid
             }
             catch (Exception ex)
             {
                 var page = HttpContext.Current.CurrentHandler as Page;
                 eObj.ErrorData(ex, page);
                 throw ex;
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
                 bOQHeaderDetails.bOQDetails.DeleteBOQDocumentDetails(Itemid);

             }
             catch(Exception ex)
             {
                 var page = HttpContext.Current.CurrentHandler as Page;
                 eObj.ErrorData(ex, page);
                 throw ex;
             }

         }

    }
}