using HospitalLibrary.Core.Model.MailRequests;

namespace HospitalLibrary.Core.Service
{
    public interface IEmailService
    {
        void SendEmailAsync(MailRequest mailRequest);

    }
}
