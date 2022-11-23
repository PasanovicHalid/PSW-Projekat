using IntegrationAPI;
using IntegrationAPI.Controllers;
using IntegrationAPI.DTO;
using IntegrationAPITests.Setup;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Service.BloodRequests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Shouldly;
using System;
using System.Text.Json;
using Xunit;

namespace IntegrationAPITests.Tests
{
    public class BloodRequestTests : BaseIntegrationTest
    {
        public BloodRequestTests(TestDatabaseFactory<Startup> factory) : base(factory)
        {
        }

        private static BloodRequestController SetupSettingsController(IServiceScope scope)
        {
            return new BloodRequestController(scope.ServiceProvider.GetRequiredService<IBloodRequestService>());
        }

        [Fact]
        public void Create_request_for_blood()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupSettingsController(scope);

            BloodRequestDTO testCase = new BloodRequestDTO()
            {
                RequiredForDate = DateTime.Now,
                BloodQuantity = 1,
                Reason = "",
                DoctorId = 1,
                RequestState = 0,
                BloodType = 0,
                BloodBankId = 0,
                Id =0
            };

            var result = ((OkObjectResult)controller.Create(testCase))?.Value as BloodRequestDTO;
            result.Id = 0;
            result.ShouldBe(testCase);
            JsonSerializer.Serialize(result).ShouldBe(JsonSerializer.Serialize(testCase));
        }

        [Fact]
        public void Accept_request_for_blood()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupSettingsController(scope);

            var result = ((OkResult)controller.AcceptRequest(1));
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void Decline_request_for_blood()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupSettingsController(scope);

            var result = ((OkResult)controller.DeclineRequest(2));
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void Return_request_for_blood()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupSettingsController(scope);

            var result = ((OkResult)controller.SendBackRequest(2, "reason"));
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void Get_return_requests_for_doctor()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupSettingsController(scope);

            var result = (OkObjectResult)controller.GetReturnedRequestsForDoctor(3);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Update_requests_from_doctor()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupSettingsController(scope);

            BloodRequestDTO r = new BloodRequestDTO(5, new DateTime(2022,12,12), 3, "i need it", 3, RequestState.Returned, BloodType.ABP, "asddaswreqwreqwr", 0);

            var result = (OkResult)controller.UpdateFromDoctor(r);
            Assert.IsType<OkResult>(result);

        }
    }
}
