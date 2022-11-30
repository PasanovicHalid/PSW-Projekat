using IntegrationAPI;
using IntegrationAPITests.Setup;
using IntegrationLibrary.Core.Repository.BloodBanks;
using IntegrationLibrary.Core.Service.EmergencyBloodRequests;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationAPITests.Tests
{
    public class EmergencyBloodRequestsTests : BaseIntegrationTest
    {
        public EmergencyBloodRequestsTests(TestDatabaseFactory<Startup> factory) : base(factory)
        {
        }

        private static EmergencyBloodRequestService SetupEmergencyBloodRequestService(IServiceScope scope)
        {
            return new EmergencyBloodRequestService(scope.ServiceProvider.GetRequiredService<IBloodBankRepository>());
        }

        [Fact]
        public void Request_emergency_blood_and_it_is_available()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void Request_emergency_blood_and_blood_is_not_available()
        {
            throw new NotImplementedException();
        }
    }
}
