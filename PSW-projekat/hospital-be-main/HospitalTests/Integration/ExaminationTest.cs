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
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Service;
using HospitalTests.Setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
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

        [Fact]
        public void Generate_pdf_for_examination()
        {
            
            var mockExamination = new Mock<IExaminationRepository>();
            var mockSymptom = new Mock<ISymptomRepository>();
            var mockMedicine = new Mock<IMedicineRepository>();

            ExaminationService service = new ExaminationService(mockExamination.Object, mockSymptom.Object, mockMedicine.Object);
            var res = service.GeneratePdf(exam, true, true, false);

            
            Assert.NotNull(res);
            //Assert.Equal();


        }

        static Symptom symptom = new()
        {
            Id = 5,
            Name = "Polen"
        };
        static ICollection<Symptom> symptoms = new List<Symptom> { symptom };

        static Medicine medicine = new Medicine
        {
            Id = 5,
            Name = "Brufen",
            Quantity = 0,
        };
        static ICollection<Medicine> medicines = new List<Medicine> { medicine };

        static Prescription prescription = new Prescription
        {
            Id = 5,
            Medicines = medicines,
            Description = "aaaa",
       
        };
        static ICollection<Prescription> prescriptions = new List<Prescription> { prescription };

        static Appointment appointment = new()
        {
            Id = 5,
            Deleted = false,
            Patient = null,
            Doctor = null,
            DateTime = new DateTime(),
            CancelationDate = new DateTime(),
        };

        static Examination exam = new Examination(appointment , prescriptions, symptoms, "one gram per day");


        [Fact]
        public void Data_for_pdf()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupSettingsController(scope);

            //Act
            var result = ((OkObjectResult)controller.GetById(1))?.Value as ExaminationDto;
            var symptoms = result.Symptoms;
            var perscriptions = result.Prescriptions;
            var report = result.Report;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(symptoms.Count(), result.Symptoms.Count());
            Assert.Equal(perscriptions.Count(), result.Prescriptions.Count());
            Assert.Equal(report, result.Report);


        }


    }
}
