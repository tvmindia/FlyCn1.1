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

        public void SendingMail(string DocumentType, string _DocumentNo, string MssgTo)
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
                    Msg.Subject = "Document  For  Approvel";
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
                    Msg.Subject = "Document  For  Approvel";
                    string body= "<div style='margin: 0; padding: 0; min-width: 100%!important;'>"+
   " <div style='margin: 0; padding: 0; min-width: 100%!important;  height:30px; border:solid;color:lightseagreen; background:lightseagreen;text-align:center;'>" + " <label style='color:white; vertical-align:central'>" + " Document For Approvel</label></div>" +
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
                              "  <label> Hi SSSSS</label>"+
                           " </td>"+
                        "</tr>"+
                        "<tr>"+
                            "<td style='height:50px'>"+
                            "Please approve " + DocumentType + "document" +"&nbspnbsp"+ _DocumentNo + "'&nbsp&nbsp'"+ "For next approvel"+
                            "</td>"+
                       " </tr>"+
                        "<tr>"+
                            "<td style='height:50px;padding-left:190px'>"+
                               " <button style='Width:203px; Height:31px; background-color:lightseagreen;color:white;align-self:center; margin-left: 0px;'>Link To Document</button>" +
                               
                            "</td>"+
                        "</tr>"+
                    "</table>"+
                "</td>"+
           " </tr>" +
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

        #endregion SendingMail
    }
}