using System;
using System.Net.Mail;

namespace HospitalLibrary.Core.Model.MailRequests
{
    public class AccountValidationMailRequest : MailRequest
    {
        public AccountValidationMailRequest(Person person, String username, String code)
        {
            ToEmail = new MailAddress(person.Email.Adress.ToString());
            Subject = "Welcome " + person.Name;
            Body = "Welcome to our intranet system <br>" +
                "This message is auto generated, do not responnd on this email. <br>" +
                "Account activation link: " + "http://localhost:4200/account-activation?" + "username=" + username + "&code=" + code;

        }
    }
}
