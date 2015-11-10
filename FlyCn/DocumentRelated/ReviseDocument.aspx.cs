using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlyCn.Approvels
{
    public partial class ReviseDocument : System.Web.UI.Page
    {
        string _RevisionID;
        string _DocumentID;
        string _DocumentType;
        string _DocumentNo;
        string _RevisionNumber;
        protected void Page_Load(object sender, EventArgs e)
        {
          
            _RevisionID = Request.QueryString["RevisionID"];
            _DocumentID = Request.QueryString["DocumentID"];
            _DocumentType = Request.QueryString["DocumentType"];
            _DocumentNo = Request.QueryString["DocumentNo"];
             _RevisionNumber = Request.QueryString["RevisionNumber"];
            lblDocumentNo.Text = _DocumentNo;
            lblDocumentTypeValue.Text = _DocumentType;
            FlyCn.FlyCnDAL.ClassRev revisionObj = new FlyCnDAL.ClassRev();
            revisionObj.inputbox = _RevisionNumber; 
            revisionObj.Rev();
            txtRevisionNo.Text = revisionObj.resultbox;
        }

        protected void ReviseDocumentButton_Click(object sender, EventArgs e)
        {
            FlyCn.FlyCnDAL.ReviseDocument reviseObj = new FlyCnDAL.ReviseDocument();
          
            
            //reviseObj.RevisionID = txtRevisionId.Text;
            reviseObj.RevisionStatus = 0;
            reviseObj.Remarks = txtRemarks.Text;
            reviseObj.CreatedDate = txtdatepicker.Value;         
            reviseObj.DocumentNo = _DocumentNo;
            reviseObj.RevisionNo = txtRevisionNo.Text;
            DataTable dtobj = new DataTable();
            dtobj = reviseObj.GetDocumentIdByNo();
            reviseObj.DocumentId = dtobj.Rows[0]["DocumentID"].ToString();
            reviseObj.RevisionID = dtobj.Rows[0]["LatestRevisionID"].ToString();
            reviseObj.InsertReviseDocument();
        }
    }
}