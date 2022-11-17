using HospitalAPI.DTO;
using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Adapters
{
    public class BloodConsumptionAdapter
    {
        public static DoctorBloodConsumption FromDTO(BloodConsumptionDTO entity)
        {
            return new DoctorBloodConsumption()
            {
                Blood = entity.Blood,
                Date = DateTime.Today, 
                Purpose = entity.Purpose,
                Doctor = new Doctor()
    };
        }

        public static BloodConsumptionDTO ToDTO(DoctorBloodConsumption entity)
        {
            return new BloodConsumptionDTO()
            {
                Blood = entity.Blood,
                DoctorId = entity.Doctor.Id,
                Purpose = entity.Purpose
            };
        }
    }
}
