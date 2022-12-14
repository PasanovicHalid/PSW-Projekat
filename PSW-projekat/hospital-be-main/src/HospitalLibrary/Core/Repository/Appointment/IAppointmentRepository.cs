﻿using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Repository
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        IEnumerable<Appointment> GetAllByDoctor(int doctorId);
        IEnumerable<Appointment> GetAllForPatient(int patientId);
        IEnumerable<Patient> GetAllMaliciousPatients();
        IEnumerable<Appointment> GetAllByDoctorInDateRange(
            int doctorId,
            DateTime fromDate,
            DateTime toDate
        );
        IEnumerable<Appointment> GetAllByPatientInDateRange(
            int patientId,
            DateTime fromDate,
            DateTime toDate
        );
        IEnumerable<Appointment> GetAllForDoctorByDate(int doctorId, DateTime scheduledDate);
        bool CheckIfExists(Appointment appointment);
    }
}
