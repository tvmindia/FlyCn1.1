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
            DataTable dt = new DataTable();
            documentMaster = new DocumentMaster();

            dt = documentMaster.BindBOQ(UA.projectNo,"BOQ");
            dtgBOQGrid.DataSource = dt;

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
                //Update();

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
           
            
          //  boqHeaderDetails.documentMaster.ProjectNo = "";

            boqHeaderDetails.RevisionNo = (txtRevisionno.Text.Trim() != "") ? txtRevisionno.Text.Trim().ToString() : null;
            boqHeaderDetails.DocumentDate = (RadDocumentDate.SelectedDate != null) ? Convert.ToDateTime(RadDocumentDate.SelectedDate) : Convert.ToDateTime(null);
            boqHeaderDetails.DocumentTitle = (txtDocumenttitle.Text.Trim() != "") ? txtDocumenttitle.Text.Trim() : null;
            boqHeaderDetails.Remarks = (txtRemarks.Text.Trim() != "") ? txtRemarks.Text.Trim() : null;
            boqHeaderDetails.AddNewBOQ();
                   
         }
        #endregion insert

        #endregion Methods

    }
}