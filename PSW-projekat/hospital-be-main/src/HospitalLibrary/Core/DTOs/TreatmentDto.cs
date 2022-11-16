using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.Enums;

namespace HospitalLibrary.Core.DTOs
{
    public class TreatmentDto
    {
        public int Id { get; set; }
        public virtual PatientDto Patient { get; set; }
        public string ReasonForAdmission { get; set; }
        public DateTime DateAdmission { get; set; }
        public virtual Room Room { get; set; }
        public virtual Therapy Therapy { get; set; }

        public TreatmentDto(int id, PatientDto patientDto, string reasonForAdmission, DateTime dateAdmission, Room room, Therapy therapy)
        {
            Id = id;
            Patient = patientDto;
            ReasonForAdmission = reasonForAdmission;
            DateAdmission = dateAdmission;
            Room = room;
            Therapy = therapy;
        }
    }
}
