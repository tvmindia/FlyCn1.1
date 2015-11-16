using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.IO;
 
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

        public string Owner
        {
            get;
            set;
        }

        #endregion GeneralProperties

        #region Methods

        #region SendApprovalMail

        public void SendApprovalMail(string DocumentType, string _DocumentNo, string MssgTo, string verifierMailIdName, string approvalId)
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
                    ApprovelMaster approvalObj = new ApprovelMaster();
                    DataTable dt = new DataTable();
                    dt = approvalObj.GetApprovalLogId(approvalId);
                    string logId = dt.Rows[0]["LogId"].ToString();
                    Guid logid = new Guid(logId);
                    string userName = approvalObj.GetUserNameByLogId(logId);
                    string localhost = WebConfigurationManager.AppSettings["server name"];
                    MailMessage Msg = new MailMessage();
                    // Sender e-mail address.
                    Msg.From = new MailAddress("info.thrithvam@gmail.com");
                    // Recipient e-mail address.
                    Msg.To.Add(MssgTo);
                    string fileName = System.Web.Hosting.HostingEnvironment.MapPath("/Templates/ApprovalMailTemplate.html");
                   
                    string body=fileName;
                    string owner = "Anija";
                    string date = "29-01-2015";
                    string link="http://"+localhost+"/Approvels/Approvals.aspx?logid=" + logId + "";
                    if (System.IO.File.Exists(fileName) == true)
                    {
                        System.IO.StreamReader objReader;
                        objReader = new System.IO.StreamReader(fileName);

                  
                        body = objReader.ReadToEnd();
                        body=body.Replace("$USERNAME$", verifierMailIdName);
                        body=body.Replace("$DOCTYPE$",DocumentType);
                        body=body.Replace("$DOCNO$",_DocumentNo);
                        body=body.Replace("$DOCOWNER$",owner);
                        body=body.Replace("$DOCDATE$",date);
                        body=body.Replace("$LINK$",link);

                    }
                   Msg.Subject = "Document  For  Approval" + "" + _DocumentNo;
   
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
        public void SendMailToNextLevelVarifiers(string RevisionID, string DocumentType, string projectNo, string DocumentNo)
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
                    string approvalId = VarifierdtLevelByRevisionid.Rows[f]["ApprovalID"].ToString();
                    string varifierId = VarifierdtLevelByRevisionid.Rows[f]["VerifierID"].ToString();
                    Varifierdetails = ApprovelMasterobj.GetVarifierEmailByIdTosentMail(verifierLevels, DocumentType, projectNo, varifierId);
                    string verifierMailId = Varifierdetails.Rows[0]["VerifierEmail"].ToString();
                    string verifierMailIdName = new String(verifierMailId.Where(c => c != '-' && (c < '0' || c > '9')).ToArray());
                    verifierMailIdName = verifierMailIdName.Replace("@thrithvam.ae", "");
                    verifierMailIdName = verifierMailIdName.Replace("@gmail.com", "");
                    verifierMailIdName = verifierMailIdName.Replace(".", " ");
                    new Thread(delegate()
                    {

                        MailSendingOperation(verifierLevels, varifierId, verifierMailIdName, DocumentType, DocumentNo, approvalId);
                    }).Start();
                }

            }

            string novalue = "";
          
        }

        #endregion SendMailToNextLevelVarifiers

        #region MailSendingOperation
        public void MailSendingOperation(int Level, string levelId, string verifierMailIdName, string documentType, string documentNo, string approvalId)
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
                MailSendingobj.SendApprovalMail(documentType, documentNo, MailSendingobj.MsgTo, verifierMailIdName, approvalId);
            }
            catch(Exception ex)
            {
                throw ex;
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

        #region ChangeOwnershipAcknowledgement
        public void ChangeOwnershipAcknowledgement(string _DocumentNo, string MssgTo,string username)
        {
            try
            {
               
                
                    Users userobj = new Users(MssgTo);
                    ApprovelMaster approvalObj = new ApprovelMaster();
                    DataTable dt = new DataTable();
                    string logId = dt.Rows[0]["LogId"].ToString();
                    Guid logid = new Guid(logId);
                    username = approvalObj.GetUserNameByLogId(logId);
                    string MailTo = userobj.UserEMail;
                    MailMessage Msg = new MailMessage() ;
                    // Sender e-mail address.
                    Msg.From = new MailAddress("info.thrithvam@gmail.com");
                    // Recipient e-mail address.
                    Msg.To.Add(MailTo);
                    string fileName = System.Web.Hosting.HostingEnvironment.MapPath("/Templates/OwnershipChangeTemplate.html");
                    string body = fileName;
                    string owner = "Anija";
                    string date = "29-01-2015";
                    
                    if (System.IO.File.Exists(fileName) == true)
                    {
                        System.IO.StreamReader objReader;
                        objReader = new System.IO.StreamReader(fileName);

                        body = objReader.ReadToEnd();
                        body = 
                        body = body.Replace("$DOCUMENTNUMBER$",_DocumentNo);
                        body = body.Replace("$USERNAME$",username);
                        body = body.Replace("$DOCUMENTOWNER$",owner);
                        body = body.Replace("$DOCDATE$",date);
                       
                    }
                    Msg.Subject = "Ownership Change" + _DocumentNo ;

                    Msg.Body = body;

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

            
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion ChangeOwnershipAcknowledgement

        #region DocumentApprovalCompleted
        public void DocumentApprovalCompleted(string _DocumentNo, string MssgTo, string username)
        {
            try
            {


                Users userobj = new Users(MssgTo);

                string MailTo = userobj.UserEMail;
                MailMessage Msg = new MailMessage();
                // Sender e-mail address.
                Msg.From = new MailAddress("info.thrithvam@gmail.com");
                // Recipient e-mail address.
                Msg.To.Add(MailTo);
                string date = "29-01-2015";
                string ApprovalDate = "20-09-2015";
                string fileName = System.Web.Hosting.HostingEnvironment.MapPath("/Templates/DocumentApprovalCompleteTemplate.html");
                string body = fileName;
                if (System.IO.File.Exists(fileName) == true)
                {
                    System.IO.StreamReader objReader;
                    objReader = new System.IO.StreamReader(fileName);

                    body = objReader.ReadToEnd();
                    body = body.Replace("$USERNAME$", username);
                    body = body.Replace("$DOCUMENTNUMBER$", _DocumentNo);
                    body = body.Replace("$DOCDATE$", date);
                    body = body.Replace("$APPROVALDATE$", ApprovalDate);
                   
                }
                Msg.Subject = "Document Approval Completed" + _DocumentNo;

                Msg.Body = body;

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


            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion DocumentApprovalCompleted
        #endregion Methods
    }
}