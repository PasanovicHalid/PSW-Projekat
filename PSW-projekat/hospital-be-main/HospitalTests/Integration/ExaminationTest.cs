using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalAPI;
using HospitalAPI.Controllers.PublicApp;
using HospitalLibrary.Core.DTOs;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.Enums;
using HospitalLibrary.Core.Service;
using HospitalTests.Setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
namespace HospitalTests.Integration
{
    public class ExaminationTest : BaseIntegrationTest
    {
        private IExaminationService _examinationService;
  
        public ExaminationTest(TestDatabaseFactory<Startup> factory) : base(factory)
        { }


        private static ExaminationController SetupSettingsController(IServiceScope scope)
        {

            return new ExaminationController(scope.ServiceProvider.GetRequiredService<IExaminationService>(),
                                            scope.ServiceProvider.GetRequiredService<IAppointmentService>(),
                                            scope.ServiceProvider.GetRequiredService<ISymptomService>(),
                                            scope.ServiceProvider.GetRequiredService<IMedicineService>());
        }

        [Fact]
        public void Find_single_examination()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = SetupSettingsController(scope);
            //Act
            var result = ((OkObjectResult)controller.GetById(1))?.Value as ExaminationDto;
            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Find_patient_which_being_examined_by_doctor()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = SetupSettingsController(scope);
            //Act
            var result = ((OkObjectResult)controller.GetById(1))?.Value as ExaminationDto;
            var patient = result.AppointmentDto.Patient;

            //Assert
            Assert.NotNull(patient);
            Assert.Equal(patient.Id, result.AppointmentDto.Patient.Id);
            Assert.Equal(patient.Name, result.AppointmentDto.Patient.Name);
            Assert.Equal(patient.Surname, result.AppointmentDto.Patient.Surname);

        }
    }
}
