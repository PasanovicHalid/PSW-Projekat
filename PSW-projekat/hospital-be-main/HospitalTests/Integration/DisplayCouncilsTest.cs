using HospitalAPI;
using HospitalAPI.Controllers.PublicApp;
using HospitalLibrary.Core.DTOs;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using HospitalTests.Setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HospitalTests.Integration
{
    public class DisplayCouncilsTest : BaseIntegrationTest
    {


        public DisplayCouncilsTest(TestDatabaseFactory<Startup> factory) : base(factory)
        {
        }

        private static DoctorController SetupSettingsController(IServiceScope scope)
        {
            return new DoctorController(scope.ServiceProvider.GetRequiredService<IDoctorService>());
        }

        [Fact]
        public void Get_consiliums_for_doctor()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = SetupSettingsController(scope);

            //Act
            var result = ((OkObjectResult)controller.GetAllCouncilByDoctor(1))?.Value as IEnumerable<DoctorsCouncilDto>;
            var coun = result.First();
            var doctor = ((OkObjectResult)controller.GetById(1))?.Value as Doctor;

            DoctorDto doct = new DoctorDto();
            doct.Id = doctor.Id;


            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.True(coun.Doctors.Any());
            Assert.True(result.Any(doct => doct.Id == 1));


        }





    }


}
