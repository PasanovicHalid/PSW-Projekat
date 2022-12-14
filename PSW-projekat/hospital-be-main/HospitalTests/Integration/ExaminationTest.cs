﻿using System;
using System.Collections.Generic;
using System.Linq;
using HospitalAPI;
using HospitalAPI.Controllers.PublicApp;
using HospitalLibrary.Core.DTOs;
using HospitalLibrary.Core.Model;
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

        [Fact]
        public void Medical_examination_patient_one_prescription()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = SetupSettingsController(scope);

            //appointment, tj pacijent
            Appointment appointment = new Appointment(4);

            //simptomi
            List<Symptom> simptomi = new List<Symptom>();
            simptomi.Add(new Symptom(9, false, "Visual impairment"));
            simptomi.Add(new Symptom(15, false, "Night sweats"));

            //report
            String report = "Saobracajna nezgoda, otvoreni prelom butne kosti";

            //prescriptions
            List<Prescription> recepti = new List<Prescription>();

            List<Medicine> lekovi = new List<Medicine>();
            lekovi.Add(new Medicine(2, false, "Aspirin", 20));
            lekovi.Add(new Medicine(5, false, "Fervex", 1));

            recepti.Add(new Prescription(lekovi, "Uzimanje po potrebi, prilikom bolova 1x na dan"));

            //Act
            Examination examination = new Examination()
            {
                Appointment = appointment,
                Symptoms = simptomi,
                Report = report,
                Prescriptions = recepti

            };
            var result = ((OkResult)controller.Create(examination));

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(examination.Symptoms);
            Assert.NotNull(examination.Report);
            Assert.NotNull(examination.Prescriptions);
        }


        [Fact]
        public void Medical_examination_patient_few_prescriptionss()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = SetupSettingsController(scope);

            //appointment, tj pacijent
            Appointment appointment = new Appointment(6);

            //simptomi
            List<Symptom> simptomi = new List<Symptom>();
            simptomi.Add(new Symptom(7, false, "Muscle spasms"));

            //report
            String report = "Pad sa stepenica, prelom rebra";

            //prescriptions
            List<Prescription> recepti = new List<Prescription>();

            List<Medicine> lekovi1 = new List<Medicine>();
            lekovi1.Add(new Medicine(2, false, "Aspirin", 20));

            List<Medicine> lekovi2 = new List<Medicine>();
            lekovi2.Add(new Medicine(4, false, "Robenan", 5));

            Prescription recept1 = new Prescription(lekovi1, "Uzimanje prilikom bolova");
            Prescription recept2 = new Prescription(lekovi2, "Uzimanje prilikom alergije");

            recepti.Add(recept1);
            recepti.Add(recept2);

            //Act
            Examination examination = new Examination()
            {
                Appointment = appointment,
                Symptoms = simptomi,
                Report = report,
                Prescriptions = recepti

            };
            var result = ((OkResult)controller.Create(examination));

            //Assert
            Assert.NotNull(result);
            Assert.NotSame(examination.Prescriptions.First(), examination.Prescriptions.Skip(1).First());
        }
    }

}
