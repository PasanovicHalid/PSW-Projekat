using HospitalAPI;
using HospitalAPI.Controllers.PrivateApp;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service.CouncilOfDoctors;
using HospitalTests.Setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalTests.Integration
{
    public class CouncilOfDoctorsTests : BaseIntegrationTest
    {

        public CouncilOfDoctorsTests(TestDatabaseFactory<Startup> factory) : base(factory)
        {
        }

        private static CouncilOfDoctorsController SetupSettingsController(IServiceScope scope)
        {
            return new CouncilOfDoctorsController(scope.ServiceProvider.GetRequiredService<ICouncilOfDoctorsService>());
        }


        [Fact]
        public void Check_if_can_create_doctors_council()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupSettingsController(scope);


            DoctorsCouncil testCase = new DoctorsCouncil()
            {
            };

            var result = ((OkObjectResult)controller.Create(testCase))?.Value as DoctorsCouncil;
            Assert.NotNull(result);
            result.ShouldBe(testCase);
        }

    }
}
