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
                RequestState =0,
                BloodType = 0,
            };

            var result = ((CreatedAtActionResult)controller.Create(testCase))?.Value as BloodRequest;
            result.Id = 0;
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
    }
}
