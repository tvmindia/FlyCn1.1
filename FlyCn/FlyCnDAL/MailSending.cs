using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Web;
 
namespace FlyCn.FlyCnDAL
{
    public class MailSending
    {

        #region GeneralProperties
        public string MsgFrom
        {
            get;
            set;
        }

        public string MsgTo
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        #endregion GeneralProperties

        #region Methods

        #region SendApprovalMail

        public void SendApprovalMail(string DocumentType, string _DocumentNo, string MssgTo, string verifierMailIdName)
        {
            try
            {
                if (MssgTo == "")
                {
                    MailMessage Msg = new MailMessage();
                    // Sender e-mail address.
                    Msg.From = new MailAddress("info.thrithvam@gmail.com");
                    // Recipient e-mail address.
                    Msg.To.Add("info.thrithvam2@gmail.com");
                    Msg.Subject = "Document  For  Approval";
                    Msg.Body = "Please approve " + DocumentType + "document" + _DocumentNo;
                    Msg.IsBodyHtml = true;
                    // your remote SMTP server IP.
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.Credentials = new System.Net.NetworkCredential("info.thrithvam", "thrithvam@2015");
                    smtp.EnableSsl = true;
                    smtp.Send(Msg);
                    Msg = null;
                }
                else
                {
                    MailMessage Msg = new MailMessage();
                    // Sender e-mail address.
                    Msg.From = new MailAddress("info.thrithvam@gmail.com");
                    // Recipient e-mail address.
                    Msg.To.Add(MssgTo);
                    Msg.Subject = "Document  For  Approval" + "" + _DocumentNo;
                    string body= "<div style='margin: 0; padding: 0; min-width: 100%!important;'>"+
   " <div style='margin: 0; padding: 0; min-width: 100%!important;  height:25px; background:lightseagreen;text-align:center;'>" + " <label style='color:white; vertical-align:central'>" + " Document For Approvel</label></div>" +
     "    <div style='background-color:#f6f8f1; text-align:left; height:25px;'>" +
                                            "  <label "+"style='font:bold; font-size:15px;  color:#006666'"+"> Hi"+"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +verifierMailIdName+"</label>"+

        "</div>"+
   " <table width=100% bgcolor=#f6f8f1 border=0" +"cellpadding=0"+" cellspacing="+"0>"+
            "<tr>"+
                "<td>"+
                    "<table class="+"content"+" align=center  cellpadding=0 cellspacing=0 border=0>"+
                        "<tr>"+
                            "<td>"+
                               
                           " </td>"+

                        "</tr>"+
                      
                        "<tr>"+
                            "<td style='height:50px'>"+
                            "" + DocumentType + "  document-" + "&nbsp;&nbsp;" + "" + _DocumentNo + "&nbsp;&nbsp;&nbsp;" + "is closed for approval ." +"&nbsp;&nbsp;&nbsp;" +"Click the below button to approve the document."+
                            "</td>"+
                       " </tr>"+
                        "<tr>"+
                            "<td style='height:50px;padding-left:190px'>"+
                               " <button style='Width:203px; Height:31px;cursor:pointer; background-color:lightseagreen;color:white;align-self:center;border-style:none; margin-left: 0px;'>Click To Approve Document</button>" +
                               
                            "</td>"+
                        "</tr>"+
                    "</table>"+
                "</td>"+
           " </tr>" +
           "   <tr>"+
                "<td style='font-size:10px; color:#2F4F4F;'>" +
                    "This is an automatically generated email – please do not reply to it. If you have any queries please email to <a href="+"'mailto:info.thrithvam@gmail.com'"+"> amrutha@thrithvam.com</a>"+
                "</td>"+
           " </tr>"+
       " </table> "+ 
" </div>";
   
                    Msg.Body =body;
      
                    Msg.IsBodyHtml = true;
                    // your remote SMTP server IP.
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.Credentials = new System.Net.NetworkCredential("info.thrithvam", "thrithvam@2015");
                    smtp.EnableSsl = true;
                    smtp.Send(Msg);
                    Msg = null;
                }
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        #endregion SendApprovalMail

        #region SendMailToNextLevelVarifiers
        public void SendMailToNextLevelVarifiers(string RevisionID, string DocumentType, string projectNo,string DocumentNo)
        {


            ApprovelMaster ApprovelMasterobj = new ApprovelMaster();
            DataTable VarifierdtLevelByRevisionid = new DataTable();
            VarifierdtLevelByRevisionid = ApprovelMasterobj.getDataFromVarifierMasterDetailsByRevisoinId(RevisionID);
            DataTable Varifierdetails = new DataTable();
            int totalrows = VarifierdtLevelByRevisionid.Rows.Count;

            for (int f = 0; f < VarifierdtLevelByRevisionid.Rows.Count; f++)
            {
                int verifierLevels = Convert.ToUInt16(VarifierdtLevelByRevisionid.Rows[0]["VerifierLevel"]);
                if (Convert.ToUInt16(VarifierdtLevelByRevisionid.Rows[f]["VerifierLevel"]) == verifierLevels)
                {
                    string varifierId = VarifierdtLevelByRevisionid.Rows[f]["VerifierID"].ToString();
                    Varifierdetails = ApprovelMasterobj.GetVarifierEmailByIdTosentMail(verifierLevels, DocumentType, projectNo, varifierId);
                    string verifierMailId = Varifierdetails.Rows[0]["VerifierEmail"].ToString();
                    string verifierMailIdName = new String(verifierMailId.Where(c => c != '-' && (c < '0' || c > '9')).ToArray());

                    verifierMailIdName = verifierMailIdName.Replace("@thrithvam.ae", "");
                    verifierMailIdName = verifierMailIdName.Replace("@gmail.com", "");
                    verifierMailIdName = verifierMailIdName.Replace(".", " ");
                    
                    new Thread(delegate()
                    {

                        MailSendingOperation(verifierLevels, varifierId, verifierMailIdName, DocumentType, DocumentNo);
                    }).Start();
                }

            }

            string novalue = "";
          
        }

        #endregion SendMailToNextLevelVarifiers

        #region MailSendingOperation
        public void MailSendingOperation(int Level, string levelId, string verifierMailIdName, string documentType, string documentNo)
        {
            try
            {
                ApprovelMaster ApprovelMasterobj = new ApprovelMaster();
                FlyCn.FlyCnDAL.MailSending MailSendingobj = new MailSending();
                DataTable dtobj = new DataTable();
                dtobj = ApprovelMasterobj.GetVarifierDetailsById(Level, levelId);
                MailSendingobj.MsgFrom = "";
                MailSendingobj.MsgTo = dtobj.Rows[0]["VerifierEmail"].ToString();
                MailSendingobj.Password = "";
                MailSendingobj.SendApprovalMail(documentType, documentNo, MailSendingobj.MsgTo, verifierMailIdName);

            }
            catch
            {
                throw;
            }
        }
        #endregion MailSendingOperation

        #region GeneralEmailSending
        public void GeneralEmailSending(string userName,string subject,string content)
        {  
            Users userobj=new  Users(userName);
           
            string MailTo = userobj.UserEMail;

            MailMessage Msg = new MailMessage();
            // Sender e-mail address.
            Msg.From = new MailAddress("info.thrithvam@gmail.com");
            // Recipient e-mail address.
            Msg.To.Add(MailTo);
            Msg.Subject = subject;
            Msg.Body = content;
            Msg.IsBodyHtml = true;
            // your remote SMTP server IP.
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("info.thrithvam", "thrithvam@2015");
            smtp.EnableSsl = true;
            smtp.Send(Msg);
            Msg = null;
        }

        #endregion GeneralEmailSending

        #endregion Methods
    }
}