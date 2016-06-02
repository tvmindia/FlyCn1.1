using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.IO;
using System.Web.SessionState;
 
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

        public string CommandName
        {
            get;
            set;
        }
        public string Remarks
        {
            get;
            set;
        }
        #endregion GeneralProperties

        #region Methods

        #region SendApprovalMail

        public void SendApprovalMail(string Revisionid, string approvalId, string MssgTo, string verifierMailIdName)
        {
           
            try
            {
                    ApprovelMaster approvalObj = new ApprovelMaster();
                    DocumentMaster domObj = new DocumentMaster();
                    Guid revId;
                    Guid.TryParse(Revisionid, out revId);
                    domObj.GetDocumentDetailsByRevisionID(revId);
                    approvalObj.getDataFromApprovelLevel();
                    
                    DataTable dt = new DataTable();
                    dt = approvalObj.GetApprovalLogId(approvalId);
                    string logId = dt.Rows[0]["LogId"].ToString();
                    Guid logid = new Guid(logId);
                    string userName = approvalObj.GetUserNameByLogId(logId);
                    string localhost = WebConfigurationManager.AppSettings["server name"];
                    approvalObj.GetAllDataFromApprovalMaster(approvalId);
                    int ApprovalLevel = approvalObj.ApprovalLevel;
                    MailMessage Msg = new MailMessage();
                    // Sender e-mail address.
                    Msg.From = new MailAddress("info.thrithvam@gmail.com");
                    // Recipient e-mail address.
                    Msg.To.Add(MssgTo);
                    string fileName = System.Web.Hosting.HostingEnvironment.MapPath("/Templates/ApprovalMailTemplate.html");
                   
                    string body=fileName;

                    string link = "http://" + localhost + "/Approvels/Approvals.aspx?logid=" + logId + "&docType=" + domObj.DocumentType + "";
                    if (System.IO.File.Exists(fileName) == true)
                    {
                        System.IO.StreamReader objReader;
                        objReader = new System.IO.StreamReader(fileName);
                  
                        body = objReader.ReadToEnd();
                        body = body.Replace("$APPROVALLEVEL$", ApprovalLevel.ToString());
                        body=body.Replace("$USERNAME$", verifierMailIdName);
                        body=body.Replace("$DOCTYPE$",domObj.DocumentType);
                        body=body.Replace("$DOCNO$",domObj.DocumentNo);
                        body=body.Replace("$DOCOWNER$",domObj.DocumentOwner);
                        body = body.Replace("$DOCDATE$", domObj.DocDate.ToString("dd -MMM- yyyy"));
                        body = body.Replace("$REVISIONNUM$",domObj.RevNo);
                        body=body.Replace("$LINK$",link);

                    }
                   Msg.Subject = "Document  For  Approval" + " " + domObj.DocumentNo;
   
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
              
            
            catch (Exception ex)
            {
                throw ex;
            }
        }



        #endregion SendApprovalMail

        #region SendMailToNextLevelVarifiers
        public void SendMailToNextLevelVarifiers(string RevisionID)
        {
            DocumentMaster domObj = new DocumentMaster();
            Guid revId;
            Guid.TryParse(RevisionID, out revId);
            domObj.GetDocumentDetailsByRevisionID(revId);
         
            
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
                    Varifierdetails = ApprovelMasterobj.GetVarifierEmailByIdTosentMail(verifierLevels, domObj.DocumentType, domObj.ProjectNo, varifierId);
                    string verifierMailId = Varifierdetails.Rows[0]["VerifierEmail"].ToString();
                    //string verifierMailIdName = new String(verifierMailId.Where(c => c != '-' && (c < '0' || c > '9')).ToArray());
                    //verifierMailIdName = verifierMailIdName.Replace("@thrithvam.ae", "");
                    //verifierMailIdName = verifierMailIdName.Replace("@thrithvam.me", "");
                    //verifierMailIdName = verifierMailIdName.Replace("@gmail.com", "");
                    //verifierMailIdName = verifierMailIdName.Replace(".", " ");
                   

                    Users userObj = new Users(verifierMailId,1);

                    new Thread(delegate()
                    {

                        MailSendingOperation(verifierLevels, varifierId,userObj.UserName, domObj.DocumentType,domObj.DocumentNo, approvalId, RevisionID);
                    }).Start();

                }

            }

            string novalue = "";
          
        }

        #endregion SendMailToNextLevelVarifiers

        #region SendMailToSameLevelVarifiers
        public void SendMailToSameLevelVarifiers(string RevisionID, string ApprovalID)
        {
            DocumentMaster domObj = new DocumentMaster();
            Guid revId;
            Guid.TryParse(RevisionID, out revId);
            domObj.GetDocumentDetailsByRevisionID(revId);


            ApprovelMaster ApprovelMasterobj = new ApprovelMaster();
           
            DataTable VarifierdtLevelByRevisionId = new DataTable();
            VarifierdtLevelByRevisionId = ApprovelMasterobj.getEmailIdFromVarifierMasterDetailsByRevisoinId(RevisionID, ApprovalID);
            DataTable Varifierdetails = new DataTable();
            int totalrows = VarifierdtLevelByRevisionId.Rows.Count;

            int verifierLevels = Convert.ToUInt16(VarifierdtLevelByRevisionId.Rows[0]["VerifierLevel"]);
            for (int f = 0; f < VarifierdtLevelByRevisionId.Rows.Count; f++)
            {
                
                if (Convert.ToUInt16(VarifierdtLevelByRevisionId.Rows[f]["VerifierLevel"]) == verifierLevels)
               {
                   string approvalId = ApprovalID;
                   string verifierMailId = VarifierdtLevelByRevisionId.Rows[0]["VerifierEmail"].ToString();




                   new Thread(delegate()
                   {
                       ApprovedByOthers(verifierMailId, RevisionID, ApprovalID);
                   }).Start();

                   string novalue = "";
               }
            }
        }
        #endregion SendMailToSameLevelVarifiers

        #region MailSendingOperation
        public void MailSendingOperation(int Level, string levelId, string verifierMailIdName, string documentType, string documentNo, string approvalId,string Revisionid)
        
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
               
                    MailSendingobj.SendApprovalMail(Revisionid, approvalId, MailSendingobj.MsgTo, verifierMailIdName);

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion MailSendingOperation

        #region ApprovedByOthers
        public void ApprovedByOthers(string verifierMailIdName, string Revisionid, string ApprovalID)
        {
            try
            {
                Users userobj = new Users(verifierMailIdName, 1);
                DocumentMaster domObj = new DocumentMaster();
                Guid revId;
                Guid.TryParse(Revisionid, out revId);
                domObj.GetDocumentDetailsByRevisionID(revId);
                ApprovelMaster approvalObj = new ApprovelMaster();
                DataTable dt = new DataTable();
                approvalObj.GetAllDataFromApprovalMaster(ApprovalID);
                int ApprovalLevel = approvalObj.ApprovalLevel;

                string MailTo = userobj.UserEMail;
                MailMessage Msg = new MailMessage();
                // Sender e-mail address.
                Msg.From = new MailAddress("info.thrithvam@gmail.com");
                // Recipient e-mail address.
                Msg.To.Add(MailTo);
                string fileName = System.Web.Hosting.HostingEnvironment.MapPath("/Templates/SameLevelVerifierTemplate.html");
                string body = fileName;

                if (System.IO.File.Exists(fileName) == true)
                {
                    System.IO.StreamReader objReader;
                    objReader = new System.IO.StreamReader(fileName);

                    body = objReader.ReadToEnd();
                    body = body.Replace("$APPROVALLEVEL$", ApprovalLevel.ToString());
                    body = body.Replace("$DOCTYPE$", domObj.DocumentType);
                    body = body.Replace("$DOCNO$", domObj.DocumentNo);
                    body = body.Replace("$USERNAME$", userobj.UserName);
                    body = body.Replace("$DOCOWNER$", domObj.DocumentOwner);
                    body = body.Replace("$DOCDATE$", domObj.DocDate.ToString("dd- MMM- yyyy"));
                    body = body.Replace("$REVISIONNUM$",domObj.RevNo);

                }
                Msg.Subject = "Document already approved " + domObj.DocumentNo;

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
        #endregion ApprovedByOthers

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
        public void ChangeOwnershipAcknowledgement(string RevisionID, string MssgTo, string username, string Remarks)
        {
            try
            {
               
                
                    Users userobj = new Users(MssgTo);
                    DocumentMaster domObj = new DocumentMaster();
                    Guid revId;
                    Guid.TryParse(RevisionID, out revId);
                    domObj.GetDocumentDetailsByRevisionID(revId);
                    ApprovelMaster approvalObj = new ApprovelMaster();
                    DataTable dt = new DataTable();
                    
                    string MailTo = userobj.UserEMail;
                    MailMessage Msg = new MailMessage() ;
                    // Sender e-mail address.
                    Msg.From = new MailAddress("info.thrithvam@gmail.com");
                    // Recipient e-mail address.
                    Msg.To.Add(MailTo);
                    string fileName = System.Web.Hosting.HostingEnvironment.MapPath("/Templates/OwnershipChangeTemplate.html");
                    string body = fileName;
                   
                    if (System.IO.File.Exists(fileName) == true)
                    {
                        System.IO.StreamReader objReader;
                        objReader = new System.IO.StreamReader(fileName);

                        body = objReader.ReadToEnd();
                        
                        body = body.Replace("$DOCUMENTTYPE$", domObj.DocumentType);
                        body = body.Replace("$DOCUMENTNUMBER$",domObj.DocumentNo);
                        body = body.Replace("$USERNAME$",MssgTo);
                        body = body.Replace("$DOCUMENTOWNER$",domObj.DocumentOwner);
                        body = body.Replace("$DOCDATE$", domObj.DocDate.ToString("dd- MMM- yyyy"));
                        body = body.Replace("$Remarks$", Remarks);
                        body = body.Replace("$REVISIONNUM$",domObj.RevNo);
                       
                    }
                    Msg.Subject = "Ownership Change " + domObj.DocumentNo ;

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
        public void DocumentApprovalCompleted(string RevisionID, string MssgTo, string username, string ApprovalID)
        {
            try
            {
                Users userobj = new Users(MssgTo);
                DocumentMaster domObj = new DocumentMaster();
                ApprovelMaster approvalObj = new ApprovelMaster();
                Guid revId;
                Guid.TryParse(RevisionID, out revId);
                domObj.GetDocumentDetailsByRevisionID(revId);
                string MailTo = userobj.UserEMail;
                MailMessage Msg = new MailMessage();
                // Sender e-mail address.
                Msg.From = new MailAddress("info.thrithvam@gmail.com");
                // Recipient e-mail address.
                Msg.To.Add(MailTo);
                approvalObj.GetAllDataFromApprovalMaster(ApprovalID);
                int ApprovalLevel = approvalObj.ApprovalLevel;
                string fileName = System.Web.Hosting.HostingEnvironment.MapPath("/Templates/DocumentApprovalCompleteTemplate.html");
                string body = fileName;
                if (System.IO.File.Exists(fileName) == true)
                {
                    System.IO.StreamReader objReader;
                    objReader = new System.IO.StreamReader(fileName);
                    body = objReader.ReadToEnd();
                    body = body.Replace("$USERNAME$", MssgTo);
                    body = body.Replace("$DOCUMENTNUMBER$", domObj.DocumentNo);
                    body = body.Replace("$DOCDATE$", domObj.DocDate.ToString("dd- MMM- yyyy"));
                    body = body.Replace("$APPROVALDATE$", domObj.ApprovedDate.ToString("dd- MMM- yyyy"));
                    body = body.Replace("$DOCUMENTTYPE$", domObj.DocumentType);
                    body = body.Replace("$APPROVALLEVEL$", ApprovalLevel.ToString());
                    body = body.Replace("$REVISIONNUM$", domObj.RevNo);
                }
                Msg.Subject = "Document Approval Completed " + domObj.DocumentNo;

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

        #region RejectMail
        public void RejectMail(string RevisionID, string UserName, string OwnerName, string Reason, string ApprovalID)
        {
            try
            {
                Users userobj = new Users(OwnerName);
                DocumentMaster domObj = new DocumentMaster();
                ApprovelMaster approvalObj = new ApprovelMaster();
                approvalObj.GetAllDataFromApprovalMaster(ApprovalID);
                Guid revId;
                Guid.TryParse(RevisionID, out revId);
                domObj.GetDocumentDetailsByRevisionID(revId);
           
                DataTable dt = new DataTable();

                string MailTo = userobj.UserEMail;
                MailMessage Msg = new MailMessage();
                // Sender e-mail address.
                Msg.From = new MailAddress("info.thrithvam@gmail.com");
                // Recipient e-mail address.
                Msg.To.Add(MailTo);
                string fileName = System.Web.Hosting.HostingEnvironment.MapPath("/Templates/RejectedMailTemplate.html");
                string body = fileName;

              
                int ApprovalLevel = approvalObj.ApprovalLevel;

                if (System.IO.File.Exists(fileName) == true)
                {
                    System.IO.StreamReader objReader;
                    objReader = new System.IO.StreamReader(fileName);

                    body = objReader.ReadToEnd();
                    body = body.Replace("$DOCTYPE$", domObj.DocumentType);
                    body = body.Replace("$DOCNO$", domObj.DocumentNo);
                    body = body.Replace("$USERNAME$", OwnerName);
                    body = body.Replace("$DOCOWNER$", domObj.DocumentOwner);
                    body = body.Replace("$DOCDATE$", domObj.DocDate.ToString("dd- MMM- yyyy"));
                    body = body.Replace("$Reason$", Reason);
                    body = body.Replace("$APPROVALLEVEL$", ApprovalLevel.ToString());
                    body = body.Replace("$REVISIONNUM$", domObj.RevNo);

                }
                Msg.Subject = "Document Rejected " + domObj.DocumentNo;

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
        #endregion RejectMail

        #region SendExcelImportMail

        public void SendExcelImportMail(string StatusID,string userName)
        {
            try
            {
                // Users userobj = new Users(MssgTo);
                ImportFile exObj = new ImportFile();
                DataSet ds = new DataSet();
                ds = exObj.getExcelImportDetailsById(StatusID);
                string MailTo = "AnijaGeorge@gmail.com";
                MailMessage Msg = new MailMessage();
                // Sender e-mail address.
                Msg.From = new MailAddress("info.thrithvam@gmail.com");
                // Recipient e-mail address.
                Msg.To.Add(MailTo);
                string fileName = System.Web.Hosting.HostingEnvironment.MapPath("/Templates/ExcelImportTemplate.html");
                string body = fileName;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (System.IO.File.Exists(fileName) == true)
                    {
                        System.IO.StreamReader objReader;
                        objReader = new System.IO.StreamReader(fileName);

                        body = objReader.ReadToEnd();
                        body = body.Replace("$FileName$", exObj.FileName);
                        body = body.Replace("$TotalCount$", exObj.TotalCount.ToString());
                        body = body.Replace("$InsertCount$", exObj.InsertCount.ToString());
                        body = body.Replace("$CompletedTime$", exObj.LastUpdatedTime.ToString("dd- MMM- yyyy HH:MM:s"));
                        body = body.Replace("$UpdatedCount$", exObj.UpdateCount.ToString());
                        body = body.Replace("$ErrorCount$", exObj.ErrorCount.ToString());
                        body = body.Replace("$USERNAME$", userName);
                        


                    }

                    Msg.Subject = "File Imported " + exObj.ExcelFileName;
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion SendExcelImportMail

        #region DeclineMail   MssgTo
        public void DeclineMail(string Revisionid, string MssgTo, string verifierMailIdName, string ApprovalID)
        {
            try
            {
                Users userobj = new Users(MssgTo);
                DocumentMaster domObj = new DocumentMaster();
                Guid revId;
                Guid.TryParse(Revisionid, out revId);
                domObj.GetDocumentDetailsByRevisionID(revId);
                ApprovelMaster approvalObj = new ApprovelMaster();
                DataTable dt = new DataTable();
                string MailTo = userobj.UserEMail;
                
                MailMessage Msg = new MailMessage();
                // Sender e-mail address.
                Msg.From = new MailAddress("info.thrithvam@gmail.com");
                // Recipient e-mail address.
                Msg.To.Add(MailTo);
                string fileName = System.Web.Hosting.HostingEnvironment.MapPath("/Templates/DeclinedMailTemplate.html");
                string body = fileName;

                approvalObj.GetAllDataFromApprovalMaster(ApprovalID);
                int ApprovalLevel = approvalObj.ApprovalLevel;
                if (System.IO.File.Exists(fileName) == true)
                {
                    System.IO.StreamReader objReader;
                    objReader = new System.IO.StreamReader(fileName);

                    body = objReader.ReadToEnd();
                    body = body.Replace("$DOCTYPE$", domObj.DocumentType);
                 
                    body = body.Replace("$DOCNO$", domObj.DocumentNo);
                    body = body.Replace("$USERNAME$", MssgTo);
                    body = body.Replace("$DOCOWNER$", domObj.DocumentOwner);
                    body = body.Replace("$DOCDATE$", domObj.DocDate.ToString("dd- MMM- yyyy"));
                    body = body.Replace("$APPROVALLEVEL$", ApprovalLevel.ToString());
                    body = body.Replace("$REVISIONNUM$", domObj.RevNo);
                   // body = body.Replace("$Reason$", Remarks);

                }
                Msg.Subject = "Document Declined " + domObj.DocumentNo;

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
        #endregion DeclineMail

        #endregion Methods
    }
}