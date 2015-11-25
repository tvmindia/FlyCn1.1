using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FlyCn.FlyCnDAL;
using System.Web.UI.HtmlControls;
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
            HtmlTable ht = new HtmlTable();

            ht.Attributes.Add("class", "table table-bordered");
            //ht.Border = 1;
            ht.BorderColor = "#5F9EA0";
            ht.Width="400px";       
            ApprovelMaster apprvlObj = new ApprovelMaster();
            DtverifierDetails = apprvlObj.GetRejectedVarifierDetailsByRevisionId(_RevisionID);
            int totalrows = DtverifierDetails.Rows.Count;
            for (int j = 0; j < totalrows; j++)
            {
                     HtmlTableRow tr1 = new HtmlTableRow();

                     tr1.Attributes.Add("Class", "infoBox");
                //tr1.Attributes.Add("class", "success");
            HtmlTableCell tc1 = new HtmlTableCell();
            tc1.Style.Add("color", "black");
            tc1.Width = "30px";
            tc1.Height = "30px";
            HtmlTableCell tc2 = new HtmlTableCell();
            tc2.Width = "30px";
            tc2.Height = "30px";
            tc2.Style.Add("color", "black");
            tc2.InnerText = "New Table";
                
                tc1.InnerText = DtverifierDetails.Rows[j]["UserName"].ToString();
                tc2.InnerText = DtverifierDetails.Rows[j]["VerifierEmail"].ToString();
                tr1.Controls.Add(tc1);
                tr1.Controls.Add(tc2);
                ht.Controls.Add(tr1);

                label1Id.Controls.Add(ht);
            }

           
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
            hiddenCloseFlag.Value = "1";
            ApprovelMasterobj.InsertApprovalLog();


        }

    }
}