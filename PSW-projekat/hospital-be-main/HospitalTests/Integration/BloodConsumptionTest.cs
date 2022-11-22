using HospitalAPI;
using HospitalAPI.Controllers.PrivateApp;
using HospitalAPI.DTO;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.Enums;
using HospitalLibrary.Core.Service;
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
            return new BloodConsumptionController(scope.ServiceProvider.GetRequiredService<IBloodConsumptionService>(), scope.ServiceProvider.GetRequiredService<IDoctorService>());
        }

        [Fact]
        public void Check_if_can_create_blood_consumption()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupSettingsController(scope);

            
            BloodConsumptionDTO testCase = new BloodConsumptionDTO()
            {
                Id  = 1,
                Blood = new Blood 
                {Id=1, Deleted=false,BloodType = 0,
                Quantity = 10
                },
                Purpose ="Potrebno za novu operaciju",
                DoctorId = 1

            };

            var result = ((ObjectResult)controller.Create(testCase))?.Value as DoctorBloodConsumption;
            Assert.NotNull(result);
            Assert.NotNull(result.Doctor);
          //  Assert.Equal(testCase.Blood.Quantity, result.Blood.Quantity);
           // Assert.Equal(testCase.Blood.BloodType, result.Blood.BloodType);
           // Assert.Equal(testCase.DoctorId, result.Doctor.Id);
           // Assert.Equal(testCase.Purpose, result.Purpose);


        }

    }
}
