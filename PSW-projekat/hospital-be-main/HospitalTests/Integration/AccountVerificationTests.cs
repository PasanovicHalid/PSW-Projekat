using HospitalAPI;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.Enums;
using HospitalLibrary.Core.Model.MailRequests;
using HospitalLibrary.Core.Service;
using HospitalTests.Setup;
using Microsoft.Extensions.Options;
using System;
using Xunit;

namespace HospitalTests.Integration
{
    public class AccountVerificationTests : BaseIntegrationTest
    {
        public AccountVerificationTests(TestDatabaseFactory<Startup> factory) : base(factory)
        { }

        [Fact]
        public void Sending_verification_successful()
        {
            //Arrange
            
            IOptions<MailSettings> mailSettings = Options.Create<MailSettings>(
                new MailSettings()
                {
                    Mail = "zdravocorp2022@outlook.com",
                    DisplayName = "Zdravo Corp",
                    Password = "zdravocorp50",
                    Host = "smtp-mail.outlook.com",
                    Port = 587
                }
            );
            EmailService emailService = new EmailService(mailSettings);
            Person person = new Person()
            {
                Id = 0,
                Name = "Ivan",
                Surname = "Galic",
                Role = Role.patient,
                Email = "ivan500galich@gmail.com",
                Gender = Gender.male,
                BirthDate = new DateTime(),
                Address = new Address()
                {
                    Street = "Ulica",
                    City = "Grad",
                    Number = "A1/2",
                    PostCode = "123453",
                    Township = "Opstina",
                }
            };
            String username = "galicc";
            /*SecUser secUser = new SecUser()
            {
                Id = person.Id,
                Email = person.Email,
                UserName = username,
            };
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(secUser);*/
            var code = "CfDJ8EXewYN8hthHo9W5QX44aLv55c20a0C7mqoCVzjCBuf5oN1ebEj0nvP4r+eFPlX8zu+b5gLiEYIxCayImsZLodneGCxUGLEvmJRTmM/wOWVMgTGvzkaELxqzOKUFlboKTjHeX89q7qULCMCTUTuAL/5lNopJDTeAWBQYXuitUqaXWOVVo0YnppSwgJRLleOhCZ8/dHFxjdVJ0r84j4uTkhKSQVXspgPXh2Ns31YXFAVAFcBtGHJxzaojDiK1fOIyrg==";

            //Act
            emailService.SendEmailAsync(new AccountValidationMailRequest(person, username, code));

            //Assert
        }

    }
}
