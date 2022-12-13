using HospitalAPI;
using HospitalAPI.Controllers.PublicApp;
using HospitalLibrary.Core.Service;
using HospitalTests.Setup;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using HospitalLibrary.Core.Repository;
using System.Collections.Generic;
using HospitalLibrary.Core.DTOs.CreatingAppointmentsDTOs;
using HospitalLibrary.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HospitalTests.Integration
{
    public class CustomAppointmentTests: BaseIntegrationTest
    {
        public CustomAppointmentTests(TestDatabaseFactory<Startup> factory) : base(factory)
        { }

        private static DoctorService SetupSettingsDoctorService(IServiceScope scope)
        {
            return new DoctorService(
                scope.ServiceProvider.GetRequiredService<IDoctorRepository>(), 
                scope.ServiceProvider.GetRequiredService<IPersonRepository>(),
                scope.ServiceProvider.GetRequiredService<AllergyRepository>()
                );
        }

        private static AppointmentService SetupSettingsPublicAppointmentService(IServiceScope scope)
        {
            return new AppointmentService(
                scope.ServiceProvider.GetRequiredService<IAppointmentRepository>(),
                scope.ServiceProvider.GetRequiredService<IWorkingDayRepository>(),
                scope.ServiceProvider.GetRequiredService<IDoctorRepository>(),
                scope.ServiceProvider.GetRequiredService<IPatientRepository>()
                );
        }

        [Fact]
        public void Retrive_all_doctors()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            IDoctorService doctorService = SetupSettingsDoctorService(scope);

            //Act
            List<DoctorForCreatingAppointmentDto> allDoctors = doctorService.GetAllDoctorsForCreatingAppointment();

            //Assert
            Assert.NotNull(allDoctors);
        }

        [Fact]
        public void Appointments_validation_success_all()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            AppointmentService appointmentService = SetupSettingsPublicAppointmentService(scope);
            CheckAvailableAppontmentDto checkAvailableAppontmentDto = new CheckAvailableAppontmentDto();
            checkAvailableAppontmentDto.fromDate = ""; // Sve prazno
            checkAvailableAppontmentDto.toDate = "";
            checkAvailableAppontmentDto.fromTime = "";
            checkAvailableAppontmentDto.toTime = "";
            checkAvailableAppontmentDto.prefer = "";
            checkAvailableAppontmentDto.selectedDoctorID = 1;
            checkAvailableAppontmentDto.personID = 9;

            //Act
            List<AppointmentsAvailableForCreatingAppointment> result = appointmentService.GetAllAvailableAppointmentsForCreatingAppointment(checkAvailableAppontmentDto);


            //Assert
            Assert.Null(result);
        }

        [Fact]
        public void Appointments_validation_success_some()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            AppointmentService appointmentService = SetupSettingsPublicAppointmentService(scope);
            CheckAvailableAppontmentDto checkAvailableAppontmentDto = new CheckAvailableAppontmentDto();
            checkAvailableAppontmentDto.fromDate = "2023-12-12";
            checkAvailableAppontmentDto.toDate = ""; // Prazan parametar
            checkAvailableAppontmentDto.fromTime = "23:19";
            checkAvailableAppontmentDto.toTime = "Koka nije snela jaje xd"; // Random kobasica
            checkAvailableAppontmentDto.prefer = "doctor";
            checkAvailableAppontmentDto.selectedDoctorID = 1;
            checkAvailableAppontmentDto.personID = 9;

            //Act
            List<AppointmentsAvailableForCreatingAppointment> result = appointmentService.GetAllAvailableAppointmentsForCreatingAppointment(checkAvailableAppontmentDto);


            //Assert
            Assert.Null(result);
        }

        [Fact]
        public void Appointments_validation_success_fromdate()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            AppointmentService appointmentService = SetupSettingsPublicAppointmentService(scope);
            CheckAvailableAppontmentDto checkAvailableAppontmentDto = new CheckAvailableAppontmentDto();
            checkAvailableAppontmentDto.fromDate = "";
            checkAvailableAppontmentDto.toDate = "2023-12-13";
            checkAvailableAppontmentDto.fromTime = "23:19";
            checkAvailableAppontmentDto.toTime = "23:40";
            checkAvailableAppontmentDto.prefer = "doctor";
            checkAvailableAppontmentDto.selectedDoctorID = 1;
            checkAvailableAppontmentDto.personID = 9;

            //Act
            List<AppointmentsAvailableForCreatingAppointment> result = appointmentService.GetAllAvailableAppointmentsForCreatingAppointment(checkAvailableAppontmentDto);


            //Assert
            Assert.Null(result);
        }

        [Fact]
        public void Appointments_validation_success_todate()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            AppointmentService appointmentService = SetupSettingsPublicAppointmentService(scope);
            CheckAvailableAppontmentDto checkAvailableAppontmentDto = new CheckAvailableAppontmentDto();
            checkAvailableAppontmentDto.fromDate = "2023-12-12";
            checkAvailableAppontmentDto.toDate = "";
            checkAvailableAppontmentDto.fromTime = "23:19";
            checkAvailableAppontmentDto.toTime = "23:40";
            checkAvailableAppontmentDto.prefer = "doctor";
            checkAvailableAppontmentDto.selectedDoctorID = 1;
            checkAvailableAppontmentDto.personID = 9;

            //Act
            List<AppointmentsAvailableForCreatingAppointment> result = appointmentService.GetAllAvailableAppointmentsForCreatingAppointment(checkAvailableAppontmentDto);


            //Assert
            Assert.Null(result);
        }

        [Fact]
        public void Appointments_validation_success_fromtime()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            AppointmentService appointmentService = SetupSettingsPublicAppointmentService(scope);
            CheckAvailableAppontmentDto checkAvailableAppontmentDto = new CheckAvailableAppontmentDto();
            checkAvailableAppontmentDto.fromDate = "2023-12-12";
            checkAvailableAppontmentDto.toDate = "2023-12-13";
            checkAvailableAppontmentDto.fromTime = "";
            checkAvailableAppontmentDto.toTime = "23:40";
            checkAvailableAppontmentDto.prefer = "doctor";
            checkAvailableAppontmentDto.selectedDoctorID = 1;
            checkAvailableAppontmentDto.personID = 9;

            //Act
            List<AppointmentsAvailableForCreatingAppointment> result = appointmentService.GetAllAvailableAppointmentsForCreatingAppointment(checkAvailableAppontmentDto);


            //Assert
            Assert.Null(result);
        }

        [Fact]
        public void Appointments_validation_success_totime()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            AppointmentService appointmentService = SetupSettingsPublicAppointmentService(scope);
            CheckAvailableAppontmentDto checkAvailableAppontmentDto = new CheckAvailableAppontmentDto();
            checkAvailableAppontmentDto.fromDate = "2023-12-12";
            checkAvailableAppontmentDto.toDate = "2023-12-13";
            checkAvailableAppontmentDto.fromTime = "23:19";
            checkAvailableAppontmentDto.toTime = "";
            checkAvailableAppontmentDto.prefer = "doctor";
            checkAvailableAppontmentDto.selectedDoctorID = 1;
            checkAvailableAppontmentDto.personID = 9;

            //Act
            List<AppointmentsAvailableForCreatingAppointment> result = appointmentService.GetAllAvailableAppointmentsForCreatingAppointment(checkAvailableAppontmentDto);


            //Assert
            Assert.Null(result);
        }

        [Fact]
        public void Appointments_validation_success_prefer()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            AppointmentService appointmentService = SetupSettingsPublicAppointmentService(scope);
            CheckAvailableAppontmentDto checkAvailableAppontmentDto = new CheckAvailableAppontmentDto();
            checkAvailableAppontmentDto.fromDate = "2023-12-12";
            checkAvailableAppontmentDto.toDate = "2023-12-13";
            checkAvailableAppontmentDto.fromTime = "23:19";
            checkAvailableAppontmentDto.toTime = "23:40";
            checkAvailableAppontmentDto.prefer = "";
            checkAvailableAppontmentDto.selectedDoctorID = 1;
            checkAvailableAppontmentDto.personID = 9;

            //Act
            List<AppointmentsAvailableForCreatingAppointment> result = appointmentService.GetAllAvailableAppointmentsForCreatingAppointment(checkAvailableAppontmentDto);


            //Assert
            Assert.Null(result);
        }

        [Fact]
        public void Appointments_validation_success_personid()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            AppointmentService appointmentService = SetupSettingsPublicAppointmentService(scope);
            CheckAvailableAppontmentDto checkAvailableAppontmentDto = new CheckAvailableAppontmentDto();
            checkAvailableAppontmentDto.fromDate = "2023-12-12";
            checkAvailableAppontmentDto.toDate = "2023-12-13";
            checkAvailableAppontmentDto.fromTime = "23:19";
            checkAvailableAppontmentDto.toTime = "23:40";
            checkAvailableAppontmentDto.prefer = "";
            checkAvailableAppontmentDto.selectedDoctorID = 1;
            checkAvailableAppontmentDto.personID = -1;

            //Act
            List<AppointmentsAvailableForCreatingAppointment> result = appointmentService.GetAllAvailableAppointmentsForCreatingAppointment(checkAvailableAppontmentDto);


            //Assert
            Assert.Null(result);
        }

        [Fact]
        public void Appointments_validation_success_selecteddoctorid()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            AppointmentService appointmentService = SetupSettingsPublicAppointmentService(scope);
            CheckAvailableAppontmentDto checkAvailableAppontmentDto = new CheckAvailableAppontmentDto();
            checkAvailableAppontmentDto.fromDate = "2023-12-12";
            checkAvailableAppontmentDto.toDate = "2023-12-13";
            checkAvailableAppontmentDto.fromTime = "23:19";
            checkAvailableAppontmentDto.toTime = "23:40";
            checkAvailableAppontmentDto.prefer = "doctor";
            checkAvailableAppontmentDto.selectedDoctorID = -1;
            checkAvailableAppontmentDto.personID = 9;

            //Act
            List<AppointmentsAvailableForCreatingAppointment> result = appointmentService.GetAllAvailableAppointmentsForCreatingAppointment(checkAvailableAppontmentDto);


            //Assert
            Assert.Null(result);
        }

        [Fact]
        public void Appointments_validation_success_input_error()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            AppointmentService appointmentService = SetupSettingsPublicAppointmentService(scope);
            CheckAvailableAppontmentDto checkAvailableAppontmentDto = new CheckAvailableAppontmentDto();
            checkAvailableAppontmentDto.fromDate = "2023-12-15"; // od do greska
            checkAvailableAppontmentDto.toDate = "2023-12-13";
            checkAvailableAppontmentDto.fromTime = "23:19";
            checkAvailableAppontmentDto.toTime = "23:40";
            checkAvailableAppontmentDto.prefer = "doctor";
            checkAvailableAppontmentDto.selectedDoctorID = 1;
            checkAvailableAppontmentDto.personID = 9;

            //Act
            List<AppointmentsAvailableForCreatingAppointment> result = appointmentService.GetAllAvailableAppointmentsForCreatingAppointment(checkAvailableAppontmentDto);


            //Assert
            Assert.Null(result);
        }

        [Fact]
        public void Appointments_validation_success_none()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            AppointmentService appointmentService = SetupSettingsPublicAppointmentService(scope);
            CheckAvailableAppontmentDto checkAvailableAppontmentDto = new CheckAvailableAppontmentDto();
            checkAvailableAppontmentDto.fromDate = "2023-12-12";
            checkAvailableAppontmentDto.toDate = "2023-12-13";
            checkAvailableAppontmentDto.fromTime = "23:19";
            checkAvailableAppontmentDto.toTime = "23:40";
            checkAvailableAppontmentDto.prefer = "doctor";
            checkAvailableAppontmentDto.selectedDoctorID = 1;
            checkAvailableAppontmentDto.personID = 9;

            //Act
            List<AppointmentsAvailableForCreatingAppointment> result = appointmentService.GetAllAvailableAppointmentsForCreatingAppointment(checkAvailableAppontmentDto);


            //Assert
            Assert.NotNull(result);
        }
    }
}
