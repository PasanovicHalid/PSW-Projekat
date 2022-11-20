using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalAPI;
using HospitalAPI.Controllers.PublicApp;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using HospitalTests.Setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace HospitalTests.Integration
{
    public class TreatmentTest : BaseIntegrationTest
    {
        public TreatmentTest(TestDatabaseFactory<Startup> factory) : base(factory)
        { }

        private static TreatmentController SetupSettingsController(IServiceScope scope)
        {
            return new TreatmentController(scope.ServiceProvider.GetRequiredService<ITreatmentService>());
        }

        
        [Fact]
        public void Find_single_treatment()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = SetupSettingsController(scope);
            //Act
            var result = ((ObjectResult)controller.GetById(1))?.Value as Treatment;
            //Assert
            //provera je samo da nije null. inace moze da se proveri da li je to ta koja nam treba
            //da li je odg sprat
            Assert.NotNull(result);
        }
        
        
        [Fact]
        public void Find_a_patient_to_admission()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = SetupSettingsController(scope);

            //Act
            Treatment testCase = new Treatment()
            {
                Id = 1,
                Patient = new Patient(),
                DateAdmission = DateTime.Now,
                DateDischarge = DateTime.Now,
                ReasonForAdmission = "",
                ReasonForDischarge = "",
                TreatmentState = 0,
                Therapy = new Therapy(),
                Room = new Room()
            };

            //Assert
            var result = ((CreatedAtActionResult)controller.Create(testCase))?.Value as Treatment;
            Assert.NotNull(result);
        }
        
    }
}
