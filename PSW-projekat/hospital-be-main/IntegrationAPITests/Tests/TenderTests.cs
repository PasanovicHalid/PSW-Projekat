using IntegrationAPI;
using IntegrationAPITests.Setup;
using IntegrationLibrary.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationAPITests.Tests
{
    public class TenderTests : BaseIntegrationTest
    {
        public TenderTests(TestDatabaseFactory<Startup> factory) : base(factory)
        {
        }
        private static TenderController SetupSettingsController(IServiceScope scope)
        {
            return new TenderController(scope.ServiceProvider.GetRequiredService<ITenderService>());
        }

        [Fact]
        public void Create_tender()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupSettingsController(scope);

            List <DemandDTO> demands = CreateDemandList();

            TenderDTO testCase = new TenderDTO()
            {
                DueDate = DateTime.Now,
                Demands = demands

            };

            var result = ((OkObjectResult)controller.Create(testCase))?.Value as TenderDTO;
            result.Id = 0;
            result.ShouldBe(testCase);
        }

        private List<DemandDTO> CreateDemandList()
        {
            List<DemandDTO> demands = new List<DemandDTO>();

            DemandDTO testCase = new DemandDTO()
            {
                BloodType = BloodType.ABN,
                Quantity = 3
            };
            demands.Add(testCase);
            return demands;
        }
    }
}
