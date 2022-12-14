using IntegrationLibrary.Core.Model.Tender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model.MailRequests
{
    public class TenderLoserMailRequest : MailRequest
    {
        public TenderLoserMailRequest(BloodBank bank, Tender.Tender tender)
        {
            ToEmail = new MailAddress(bank.Email.EmailAddress);
            Subject = "Result on Tender: " + tender.Id;
            Body = "We are sorry to inform you that you lost the bid for Tender: " + tender.Id + " <br>";
        }
    }
}
