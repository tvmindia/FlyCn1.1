using FlyCn.FlyCnDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlyCn.DocumentRelated
{

    public partial class OwnershipChange : System.Web.UI.Page
    {

        ErrorHandling eObj = new ErrorHandling();
        string _DocId;
        string _Username;
        string _Ownername;
        string _Documentno;
        string _RevisionId;
        string _Remarks;
        string _ApprovalId;
        protected void Page_Load(object sender, EventArgs e)
        {
            _DocId = Request.QueryString["DocumentId"];
            _Ownername = Request.QueryString["Ownername"];
            _Username = Request.QueryString["Username"];
            _Documentno = Request.QueryString["DocumentNo"];
            _RevisionId = Request.QueryString["RevisionId"];
            _Remarks = txtRemarks.Text;
        } 

        protected void btnAcquire_Click(object sender, EventArgs e)
        {
            
            DocumentMaster dObj = new DocumentMaster();
            dObj.DocumentID = new Guid(_DocId);
            int result = 0;
           
            try
            {
               result= dObj.EditOwnershipName(dObj.DocumentID, _Username);
               MailSending mObj = new MailSending();
               mObj.ChangeOwnershipAcknowledgement(_RevisionId, _Ownername, _Username, _Remarks);
               if (result == 1)
               {
                   hiddenCloseFlag.Value = "1";
                   var page = HttpContext.Current.CurrentHandler as Page;
                   var master = page.Master;
                   eObj.UpdationSuccessData(page);
               }
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