using HospitalAPI;
using HospitalAPI.Controllers.PrivateApp;
using HospitalAPI.DTO;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service.BloodConsumption;
using HospitalTests.Setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalTests.Integration
{
    public class BloodConsumptionTest : BaseIntegrationTest
    {
        public BloodConsumptionTest(TestDatabaseFactory<Startup> factory) : base(factory)
        {
        }

        private static BloodConsumptionController SetupSettingsController(IServiceScope scope)
        {
            return new BloodConsumptionController(scope.ServiceProvider.GetRequiredService<IBloodConsumptionService>());
        }

        [Fact]
        public void Check_if_can_create_blood_consumption()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupSettingsController(scope);

            BloodConsumptionDTO testCase = new BloodConsumptionDTO()
            {
               
            };

            var result = ((OkObjectResult)controller.Create(testCase))?.Value as DoctorBloodConsumption;
            Assert.NotNull(result);
        }

    }
}
