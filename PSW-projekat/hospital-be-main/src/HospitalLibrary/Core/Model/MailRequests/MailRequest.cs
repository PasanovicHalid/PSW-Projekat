using System.Net.Mail;

namespace HospitalLibrary.Core.Model.MailRequests
{
    public abstract class MailRequest
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public MailAddress ToEmail { get; set; }
    }
}
