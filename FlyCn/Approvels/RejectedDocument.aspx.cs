using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FlyCn.FlyCnDAL;
namespace FlyCn.Approvels
{
    public partial class RejectedDocument : System.Web.UI.Page
    {
        UIClasses.Const Const = new UIClasses.Const();
        FlyCnDAL.Security.UserAuthendication UA;
        string _RevisionID;
        string _DocumentID;
        string _DocumentType;
        string _DocumentNo;
        string _HiddenFieldOwner;
        string _HiddendocumentDate;
        protected void Page_Load(object sender, EventArgs e)
        {
            UA = (FlyCnDAL.Security.UserAuthendication)Session[Const.LoginSession];
            _RevisionID = Request.QueryString["RevisionID"];
            _DocumentID = Request.QueryString["DocumentID"];
            _DocumentType = Request.QueryString["DocumentType"];
            _DocumentNo = Request.QueryString["DocumentNo"];
            _HiddenFieldOwner = Request.QueryString["hiddenFieldOwner"];
            _HiddendocumentDate = Request.QueryString["hiddendocumentDate"];
            DataTable DtverifierDetails = new DataTable();

            ApprovelMaster apprvlObj = new ApprovelMaster();
            DtverifierDetails = apprvlObj.GetRejectedVarifierDetailsByRevisionId(_RevisionID);
            string FieldValueLevel1 = "";
            int totalrows = DtverifierDetails.Rows.Count;
            for (int j = 0; j < totalrows; j++)
            {
                FieldValueLevel1 = FieldValueLevel1 + DtverifierDetails.Rows[j]["UserName"] + ",";
            }
            lblApproversName.Text = FieldValueLevel1.TrimEnd(',');
        }

        protected void btnCloseDocument_Click(object sender, EventArgs e)
        {

            DataTable DtverifierDetails = new DataTable();

            ApprovelMaster apprvlObj = new ApprovelMaster();
            DtverifierDetails = apprvlObj.GetRejectedVarifierDetailsByRevisionId(_RevisionID);
           
            int totalrows = DtverifierDetails.Rows.Count;
            for (int j = 0; j < totalrows; j++)
            {
             string verifierId=   DtverifierDetails.Rows[j]["VerifierID"].ToString();
            int Level=Convert.ToInt16( DtverifierDetails.Rows[j]["VerifierLevel"]);
              byte  IsLevelMandatory=Convert.ToByte( DtverifierDetails.Rows[j]["IsLevelMandatory"]);
            InsertOperation(verifierId, Level,IsLevelMandatory);
            }

          
            //InsertOperation();
        }
        public void InsertOperation(string levelId, int Level, byte isLevelManadatory)
        {
            ApprovelMaster ApprovelMasterobj = new ApprovelMaster();

            string documentType = _DocumentType;
            
            System.Guid guid = System.Guid.NewGuid();
            ApprovelMasterobj.ApprovalID = guid.ToString();
            ApprovelMasterobj.DocumentID = _DocumentID;
            ApprovelMasterobj.RevisionID = _RevisionID;
            ApprovelMasterobj.VerifierID = levelId;
            ApprovelMasterobj.VerifierLevel = Level;
            ApprovelMasterobj.CreatedBy = UA.userName;
            ApprovelMasterobj.ApprovalStatus = 1;
            string projectNo = UA.projectNo;
            ApprovelMasterobj.IsLevelManadatory = isLevelManadatory;
            ApprovelMasterobj.InsertApprovelMaster();
            ApprovelMasterobj.InsertApprovalLog();


        }

    }
}