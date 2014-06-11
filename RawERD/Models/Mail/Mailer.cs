using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net;
using System.Net.Mail;

namespace RawERD.Models
{
    public sealed class Mailer
    {
        readonly static String _fromName = "RawERD";
        static volatile MailModel _mailer = null;
        static Object _lock = new Object();

        public static Boolean SendMail(String receiver, String message)
        {
            if (_mailer == null)
            {
                lock (_lock)
                {
                    if (_mailer == null)
                    {
                        _mailer = MailLoadConfiguration.Load();
                    }
                }
            }
            //Prepare Message
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(_mailer.SmtpFromEmail, _fromName);
            mail.To.Add(receiver);
            mail.Subject = "Registration Confirmation Email";
            mail.Body = message;

            //Send Message
            SmtpClient smtp = new SmtpClient(_mailer.SmtpServer);
            smtp.Port = _mailer.SmtpPort;
            smtp.Credentials = new NetworkCredential(_mailer.SmtpUsername, _mailer.SmtpPassword);
            smtp.EnableSsl = true;
            smtp.Send(mail);
            mail.Dispose();
            smtp.Dispose();
            return true;
        }
    }
}