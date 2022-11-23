using HospitalAPI;
using HospitalAPI.Controllers.PrivateApp;
using HospitalLibrary.Core.DTOs;
using HospitalLibrary.Core.Service;
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
    public class StatisticsTest : IClassFixture<StatisticsTestDatabaseFactory<Startup>>
    {
        protected StatisticsTestDatabaseFactory<Startup> StatisticsFactory { get; }

        public StatisticsTest(StatisticsTestDatabaseFactory<Startup> factory)
        {
            StatisticsFactory = factory;
        }

        private static StatisticsController SetupSettingsController(IServiceScope scope)
        {
            return new StatisticsController(scope.ServiceProvider.GetRequiredService<StatisticsService>());
        }

        [Fact]
        public void Get_correct_statistics()
        {
            //Arrange
            using var scope = StatisticsFactory.Services.CreateScope();
            var controller = SetupSettingsController(scope);

            //Act
            var statistics = ((OkObjectResult)controller.GetStatistics())?.Value as StatisticsDto;

            //Assert 
            Assert.True(statistics.BloodtypePopularity.ContainsKey("A+"));
            Assert.True(statistics.NumberOfFemalesPerAgeGroup[1] == 1);
            Assert.True(statistics.AllergyPopularity.ContainsKey("Polen"));
            Assert.True(statistics.DoctorsAgeGroupDistribution.ContainsKey("Milan Milovanovic"));

        }
    }
}
