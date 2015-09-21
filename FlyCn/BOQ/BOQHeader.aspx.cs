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
            string albert = txtRemarks.Text.Trim().ToString();
            UA = (FlyCnDAL.Security.UserAuthendication)Session[Const.LoginSession];
            //string ding = UA.projectNo;
            //txtDocumentno.Text = "--no--";
            ToolBar.onClick += new RadToolBarEventHandler(ToolBar_onClick);
            ToolBar.OnClientButtonClicking = "OnClientButtonClicking";
           
        }
        #endregion Page_Load
        #region RadGrid1_NeedDataSource
        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

            //DataTable dt = new DataTable();

           // dt = mp.BindMastersPersonal();

            //RadGrid1.DataSource = dt;

        }
        #endregion RadGrid1_NeedDataSource
        #region  ToolBar_onClick
        protected void ToolBar_onClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            string functionName = e.Item.Value;
            if (e.Item.Value == "Save")
            {
                AddNewBoq();
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
        #region insert
        public void AddNewBoq()
        {
            boqHeaderDetails = new BoqHeaderDetails();
            boqHeaderDetails.documentMaster.ProjectNo = "C00005";//project no has to change//nvarchar10
            boqHeaderDetails.documentMaster.DocumentNo = "C00005-BOQ-0001";//nvarchar50
            boqHeaderDetails.documentMaster.ClientDocNo = (txtClientdocumentno.Text.Trim() != "") ? txtClientdocumentno.Text.Trim().ToString() : null;
            boqHeaderDetails.documentMaster.DocumentType = "BOQ";//nvarchar3
            boqHeaderDetails.documentMaster.DocumentOwner = UA.userName;//nvarchar 50
            boqHeaderDetails.documentMaster.CreatedBy = UA.userName;////nvarchar 50
            boqHeaderDetails.documentMaster.CreatedDate = System.DateTime.Now;//smalldatetime
            boqHeaderDetails.documentMaster.CreatedDateGMT = System.DateTime.Now;//smalldatetime
           
            
          //  boqHeaderDetails.documentMaster.ProjectNo = "";

            boqHeaderDetails.RevisionNo = (txtRevisionno.Text.Trim() != "") ? txtRevisionno.Text.Trim().ToString() : null;
            boqHeaderDetails.DocumentDate = System.DateTime.Now;//(txtDocumentdate.Text != null) ? Convert.ToDateTime(txtDocumentdate.Text) : Convert.ToDateTime(null);
            boqHeaderDetails.DocumentTitle = (txtDocumenttitle.Text.Trim() != "") ? txtDocumenttitle.Text.Trim() : null;
            boqHeaderDetails.Remarks = (txtRemarks.Text.Trim() != "") ? txtRemarks.Text.Trim() : null;
            boqHeaderDetails.Insertboq();
                   
         }
        #endregion insert

        #endregion Methods

    }
}