#region Namespaces
using FlyCn.FlyCnDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
#endregion Namespaces


namespace FlyCn.BOQ
{
    public partial class BOQHeader : System.Web.UI.Page
    {
        #region Global Variables
        DocumentMaster documentMaster;
        BoqHeaderDetails boqHeaderDetails;
        ErrorHandling eObj;
        
        UIClasses.Const Const = new UIClasses.Const();
        FlyCnDAL.Security.UserAuthendication UA;
        #endregion Global Variables
        #region Events
        
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            
            UA = (FlyCnDAL.Security.UserAuthendication)Session[Const.LoginSession];
            ToolBar.onClick += new RadToolBarEventHandler(ToolBar_onClick);
            ToolBar.OnClientButtonClicking = "OnClientButtonClicking";
            
           
        }
        #endregion Page_Load
        #region dtgBOQGrid_NeedDataSource
        protected void dtgBOQGrid_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataSet ds = new DataSet();
            documentMaster = new DocumentMaster();

            ds = documentMaster.BindBOQ(UA.projectNo,"BOQ");
            dtgBOQGrid.DataSource = ds;

        }
        #endregion dtgBOQGrid_NeedDataSource
        #region dtgBOQGrid_PreRender
        protected void dtgBOQGrid_PreRender(object sender, EventArgs e)
        { 
        }
        #endregion dtgBOQGrid_PreRender

        #region dtgBOQGrid_ItemCommand
        protected void dtgBOQGrid_ItemCommand(object source, GridCommandEventArgs e)
        {

            if (e.CommandName == "EditDoc")
            {
              ToolBarVisibility(2);
              RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("2");
              GridDataItem item = e.Item as GridDataItem;
              tab.Selected = true;
              tab.Text = "Edit";
              RadMultiPage1.SelectedIndex = 1;
              string ProjectNo = item.GetDataKeyValue("ProjectNo").ToString();
             
              DataSet ds = new DataSet();
              documentMaster = new DocumentMaster();
              ds = documentMaster.BindBOQ(ProjectNo,"BOQ");
              txtDocumentno.Text = ds.Tables[0].Rows[0]["DocumentNo"].ToString();
              txtClientdocumentno.Text = ds.Tables[0].Rows[0]["ClientDocNo"].ToString();
              txtRevisionno.Text = ds.Tables[0].Rows[0]["RevisionNo"].ToString();
              RadDocumentDate.SelectedDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["DocumentDate"].ToString());
              txtDocumenttitle.Text = ds.Tables[0].Rows[0]["DocumentTitle"].ToString();
              txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
            }
            else
            {
               if(e.CommandName == "DeleteDoc")
               {

               }
            }

        }
        #endregion dtgBOQGrid_ItemCommand
        #region  ToolBar_onClick
        protected void ToolBar_onClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            string functionName = e.Item.Value;
            if (e.Item.Value == "Save")
            {
                AddNewBOQ();
                ToolBarVisibility(1);
                
                
            }
            if (e.Item.Value == "Update")
            {
                

            }
            if (e.Item.Value == "Delete")
            {
                //Delete();
            }
        }
        #endregion ToolBar_onClick
        #endregion Events


        #region Methods
        #region ToolBarVisibility
        public void ToolBarVisibility(int order)
        {
            switch (order)
            {
                   case 1://after adding what should be visible
                    ToolBar.AddButton.Visible = false;
                    ToolBar.SaveButton.Visible = false;
                    ToolBar.UpdateButton.Visible = true;
                    ToolBar.DeleteButton.Visible = true;
                   break;
                   case 2:
                    ToolBar.AddButton.Visible = false;
                    ToolBar.SaveButton.Visible = false;
                    ToolBar.UpdateButton.Visible = true;
                    ToolBar.DeleteButton.Visible = true;
                   break;
               case 3:
                   break;

                
            }

        }
       #endregion ToolBarVisibility

        #region insert
        public void AddNewBOQ()
        {
            boqHeaderDetails = new BoqHeaderDetails();
            boqHeaderDetails.documentMaster.ProjectNo = UA.projectNo;//project no has to change//nvarchar10
            boqHeaderDetails.documentMaster.DocumentNo = "C00005-BOQ-0001";//nvarchar50
            boqHeaderDetails.documentMaster.ClientDocNo = (txtClientdocumentno.Text.Trim() != "") ? txtClientdocumentno.Text.Trim().ToString() : null;
            boqHeaderDetails.documentMaster.DocumentType = "BOQ";//nvarchar3
            boqHeaderDetails.documentMaster.DocumentOwner = UA.userName;//nvarchar 50
            boqHeaderDetails.documentMaster.CreatedBy = UA.userName;////nvarchar 50
            boqHeaderDetails.documentMaster.CreatedDate = System.DateTime.Now;//smalldatetime
            boqHeaderDetails.documentMaster.CreatedDateGMT = System.DateTime.Now;//smalldatetime
            //boqHeaderDetails.documentMaster.ProjectNo = "";
            boqHeaderDetails.RevisionNo = (txtRevisionno.Text.Trim() != "") ? txtRevisionno.Text.Trim().ToString() : null;
            boqHeaderDetails.DocumentDate = (RadDocumentDate.SelectedDate != null) ? Convert.ToDateTime(RadDocumentDate.SelectedDate) : Convert.ToDateTime(null);
            boqHeaderDetails.DocumentTitle = (txtDocumenttitle.Text.Trim() != "") ? txtDocumenttitle.Text.Trim() : null;
            boqHeaderDetails.Remarks = (txtRemarks.Text.Trim() != "") ? txtRemarks.Text.Trim() : null;
            boqHeaderDetails.AddNewBOQ();
                   
         }
        #endregion insert
        #region UpdateBOQ
        public void UpdateBOQ(string projectNo)
        {
            boqHeaderDetails = new BoqHeaderDetails();
            boqHeaderDetails.documentMaster.ProjectNo = projectNo;
            boqHeaderDetails.documentMaster.ClientDocNo = (txtClientdocumentno.Text.Trim() != "") ? txtClientdocumentno.Text.Trim().ToString() : null;
            boqHeaderDetails.documentMaster.DocumentOwner = UA.userName;
            boqHeaderDetails.documentMaster.UpdatedDate = System.DateTime.Now.ToString();
            boqHeaderDetails.RevisionNo = (txtRevisionno.Text.Trim() != "") ? txtRevisionno.Text.Trim().ToString() : null;
            boqHeaderDetails.DocumentDate = (RadDocumentDate.SelectedDate != null) ? Convert.ToDateTime(RadDocumentDate.SelectedDate) : Convert.ToDateTime(null);
            boqHeaderDetails.DocumentTitle = (txtDocumenttitle.Text.Trim() != "") ? txtDocumenttitle.Text.Trim() : null;
            boqHeaderDetails.Remarks = (txtRemarks.Text.Trim() != "") ? txtRemarks.Text.Trim() : null;
            boqHeaderDetails.UpdateBOQ();
        }

        #endregion UpdateBOQ

        #endregion Methods

    }
}