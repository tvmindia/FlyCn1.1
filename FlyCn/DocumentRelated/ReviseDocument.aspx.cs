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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ReviseDocumentButton_Click(object sender, EventArgs e)
        {
            FlyCn.FlyCnDAL.ReviseDocument reviseObj = new FlyCnDAL.ReviseDocument();
            //reviseObj.RevisionID = txtRevisionId.Text;
            reviseObj.RevisionStatus = 0;
            reviseObj.Remarks = txtRemarks.Text;
            reviseObj.CreatedDate = txtdatepicker.Value;
            reviseObj.DocumentNo = txtDocumentNo.Text;
            DataTable dtobj = new DataTable();
            dtobj = reviseObj.GetDocumentIdByNo();
            reviseObj.DocumentId = dtobj.Rows[0]["DocumentID"].ToString();
            reviseObj.RevisionID = dtobj.Rows[0]["LatestRevisionID"].ToString();
            int result = reviseObj.InsertReviseDocument();
        }
    }
}