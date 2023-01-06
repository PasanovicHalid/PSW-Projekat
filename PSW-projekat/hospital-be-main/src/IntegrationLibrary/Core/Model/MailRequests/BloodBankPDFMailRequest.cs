using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model.MailRequests
{
    internal class BloodBankPDFMailRequest : MailRequest
    {
        public BloodBankPDFMailRequest(BloodBank bank, List<IFormFile> pdfs)
        {
            ToEmail = new MailAddress(bank.Email.EmailAddress);
            Subject = "Welcome " + bank.Name;
            Body = "Your blood consumption report<br>" +
                "We hope you like our cooperation";
            Attachments = pdfs;
        }
    }
}
