using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace FlyCn.FlyCnDAL
{
    public class MailSending
    {


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

        #region SendingMail
       
        public void SendingMail(string DocumentType,string DocumentID)
        {
            try
            {
                if (MsgTo == ""||MsgFrom==""||Password=="")
                {
                    MailMessage Msg = new MailMessage();
                    // Sender e-mail address.
                    Msg.From = new MailAddress("info.thrithvam@gmail.com");
                    // Recipient e-mail address.
                    Msg.To.Add("info.thrithvam2@gmail.com");
                    Msg.Subject = "Document  For  Approvel";
                    Msg.Body = "Please approve document " + DocumentType+"and document number is"+ DocumentID;
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
                    Msg.From = new MailAddress(MsgFrom);
                    // Recipient e-mail address.
                    Msg.To.Add(MsgTo);
                    Msg.Subject = "Document  For  Approvel";
                    Msg.Body = "Please approve document " + DocumentType + "and document number is" + DocumentID;
                    Msg.IsBodyHtml = true;
                    // your remote SMTP server IP.
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.Credentials = new System.Net.NetworkCredential(MsgFrom, Password);
                    smtp.EnableSsl = true;
                    smtp.Send(Msg);
                    Msg = null;
                }
              
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
        }

        #endregion SendingMail
    }
}