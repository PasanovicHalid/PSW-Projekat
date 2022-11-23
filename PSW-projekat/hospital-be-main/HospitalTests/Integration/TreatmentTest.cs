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
    public class TreatmentTest : BaseIntegrationTest
    {

        private ITreatmentService _treatmentService;
        private readonly IPatientService _patientService;

        public TreatmentTest(TestDatabaseFactory<Startup> factory) : base(factory)
        { }

        
        private static TreatmentController SetupSettingsController(IServiceScope scope)
        {
            
            return new TreatmentController(scope.ServiceProvider.GetRequiredService<ITreatmentService>(),
                                           scope.ServiceProvider.GetRequiredService<IPatientService>(),
                                           scope.ServiceProvider.GetRequiredService<IRoomService>(),
                                           scope.ServiceProvider.GetRequiredService<IBedService>(),
                                           scope.ServiceProvider.GetRequiredService<IBloodService>(),
                                           scope.ServiceProvider.GetRequiredService<IMedicineService>(),
                                           scope.ServiceProvider.GetRequiredService<ITherapyService>()
               );
        }
        

        
        [Fact]
        public void Find_single_treatment()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = SetupSettingsController(scope);
            //Act
            var result = ((OkObjectResult)controller.GetById(1))?.Value as Treatment;
            //Assert
            //provera je samo da nije null. inace moze da se proveri da li je to ta koja nam treba
            //da li je odg sprat
            Assert.NotNull(result);
        }
        

        [Fact]
        public void Find_a_patient_to_admission()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = SetupSettingsController(scope);


            //Act
            TreatmentDto testCase = new TreatmentDto()
            {
                Patient = null,
                /*
                Patient = new Patient() { Id = 1,
                                           Deleted = false,
                                           BloodType = BloodType.APlus,
                                           Person = new Person() { Id = 3, Name = "mile", Surname = "milic",
                                            Email = "milica@gmail.com", Address = null, Gender = Gender.male,
                                            BirthDate = DateTime.Now, Role = Role.patient
                                            }, 
                                           Doctor = null},  
                */
                DateAdmission = DateTime.Now,
                DateDischarge = DateTime.Now,
                ReasonForAdmission = "Bol u stomaku",
                ReasonForDischarge = "dobro je",
                Therapy = null,
                RoomDto = null

            };
            //Assert
            //var result = ((CreatedAtActionResult)controller.Create(testCase))?.Value as Treatment;
            //Assert.NotNull(result);
        }

        
        [Fact]
        public void Find_treatment_to_close()
        {
             //Arrange
             using var scope = Factory.Services.CreateScope();
             var controller = SetupSettingsController(scope);

            //Act
            TreatmentDto testCase = new TreatmentDto() 
            { 
                Id = 9 ,
                Patient = new PatientDto(),
                DateAdmission = new DateTime(),
                DateDischarge = new DateTime(),
                ReasonForDischarge = "",
                Therapy = new Therapy(),
                RoomDto = new RoomDto()
            };
            

            //Assert
            var result = ((OkObjectResult)controller.Update(9,testCase))?.Value as TreatmentDto;
            Assert.NotNull(result);
            Assert.Equal(9, result.Id);
            Assert.Equal(testCase.Patient, result.Patient);
            Assert.NotNull(result.Patient);

         
        }
        
    }
}
