using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RawERD.Models
{
    public class MailModel
    {
        public String SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public String SmtpUsername { get; set; }
        public String SmtpPassword { get; set; }
        public String SmtpFromEmail { get; set; }
    }
}