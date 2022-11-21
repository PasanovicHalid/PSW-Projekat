using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model.MailRequests
{
    public abstract class MailRequest
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public MailAddress ToEmail { get; set; }
    }
}
