using Microsoft.Extensions.Configuration;
using HospitalAPI;
using HospitalAPI.Controllers.PublicApp;
using HospitalLibrary.Core.DTOs;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Identity;
using HospitalTests.Setup;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Xunit;

namespace HospitalTests.Integration
{
    public class RegistrationTests : BaseIntegrationTest
    {
        public RegistrationTests(TestDatabaseFactory<Startup> factory) : base(factory)
        { }

        private static AccountController SetupSettingsController(IServiceScope scope)
        {
            return new AccountController(scope.ServiceProvider.GetRequiredService<UserManager<SecUser>>(), scope.ServiceProvider.GetRequiredService<SignInManager<SecUser>>(),
                                         scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>(), scope.ServiceProvider.GetRequiredService<IEmailService>(),
                                         scope.ServiceProvider.GetRequiredService<IConfiguration>(), scope.ServiceProvider.GetRequiredService<IPersonService>(),
                                         scope.ServiceProvider.GetRequiredService<IDoctorService>(), scope.ServiceProvider.GetRequiredService<IPatientService>()
                                         );
        }

        [Fact]
        public void Registration_successful()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = SetupSettingsController(scope);
            RegisterPatientDto regUser = new RegisterPatientDto
            {
                Name = "TestName",
                Surname = "TestSurname",
                BirthDate = "5/11/2000",
                Allergies = new List<Allergy>(),
                BloodType = 0,
                City = "Test City",
                DoctorName = new SimpleDoctorDto { FullName = "TestName TestSurname", Id = 2 },
                Email = "test@gmail.com",
                Gender = 0,
                Number = "12",
                Password = "123",
                PostCode = "123465",
                Street = "Test Street",
                Township = "Test Township",
                Username = "TestUsername"
            };

            //Act
            var result = controller.RegisterPatient(regUser);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Registration_failed_data_missing()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = SetupSettingsController(scope);
            RegisterPatientDto regUser = new RegisterPatientDto
            {
                Name = "TestName",
                Surname = "TestSurname",
                BirthDate = "5/11/2000",
                Allergies = new List<Allergy>(),
                BloodType = 0,
                City = "Test City",
                DoctorName = new SimpleDoctorDto { FullName = "TestName TestSurname", Id = 2 },
                Email = null,
                Gender = 0,
                Number = "12",
                Password = "123",
                PostCode = "123465",
                Street = "Test Street",
                Township = "Test Township",
                Username = "TestUsername"
            };

            //Act
            var result = controller.RegisterPatient(regUser);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Registration_failed_username_taken()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = SetupSettingsController(scope);
            RegisterPatientDto regUser = new RegisterPatientDto
            {
                Name = "TestName",
                Surname = "TestSurname",
                BirthDate = "5/11/2000",
                Allergies = new List<Allergy>(),
                BloodType = 0,
                City = "Test City",
                DoctorName = new SimpleDoctorDto { FullName = "TestName TestSurname", Id = 2 },
                Email = null,
                Gender = 0,
                Number = "12",
                Password = "123",
                PostCode = "123465",
                Street = "Test Street",
                Township = "Test Township",
                Username = "TAKENUSERNAME"
            };

            //Act
            var result = controller.RegisterPatient(regUser);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Doctors_and_allegies()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = SetupSettingsController(scope);

            //Act
            var result = ((OkObjectResult)controller.GetAllergiesAndDoctors())?.Value as AllergiesAndDoctorsForPatientRegistrationDto;

            //Assert
            Assert.NotNull(result);
        }
    }
}
