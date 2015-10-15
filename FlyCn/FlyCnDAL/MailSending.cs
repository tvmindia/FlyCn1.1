using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace FlyCn.FlyCnDAL
{
    public class MailSending
    {
        #region SendingMail
        public void SendingMail()
        {
            try
            {
                MailMessage Msg = new MailMessage();
                // Sender e-mail address.
                Msg.From = new MailAddress("info.thrithvam@gmail.com");
                // Recipient e-mail address.
                Msg.To.Add("info.thrithvam2@gmail.com");
                Msg.Subject = "fgyhfgj";
                Msg.Body = "hjjkkjhkk";
                Msg.IsBodyHtml = true;
                // your remote SMTP server IP.
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("info.thrithvam", "thrithvam@2015");
                smtp.EnableSsl = true;
                smtp.Send(Msg);
                Msg = null;
                // Page.RegisterStartupScript("UserMsg", "<script>alert('Mail sent thank you...');if(alert){ window.location='test1.aspx';}</script>");
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
        }

        #endregion SendingMail
    }
}