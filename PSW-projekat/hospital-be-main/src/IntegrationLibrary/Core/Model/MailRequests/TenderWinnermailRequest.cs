using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model.MailRequests
{
    public class TenderWinnermailRequest : MailRequest
    {
        public TenderWinnermailRequest(BloodBank bank, Tender.Tender tender)
        {
            ToEmail = new MailAddress(bank.Email.EmailAddress);
            Subject = "Result on Tender: " + tender.Id;
            Body = "Congratulations! <br>" +
                "You were chosen as the winner of Tender: " + tender.Id + " <br>" +
                "Due date for delivery is " + tender.DueDate + " <br>";
        }
    }
}
