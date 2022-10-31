using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model.MailRequests
{
    public class BloodBankCreationMailRequest : MailRequest
    {
        public BloodBankCreationMailRequest(BloodBank bank)
        {
            ToEmail = new MailAddress(bank.Email);
            Subject = "Welcome " + bank.Name;
            Body = "Welcome to our intranet system <br>" +
                "Your password is: " + bank.Password + "<br>" +
                "Your API key is: " + bank.ApiKey + " <br>" +
                "Password reset link: " + "http://localhost:5000/blood-bank-change-password?passKey=" + bank.PasswordResetKey;

        }
    }
}
