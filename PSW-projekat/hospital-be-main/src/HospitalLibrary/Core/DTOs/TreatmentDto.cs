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
        public string ReasonForDischarge { get; set; }
        public DateTime DateAdmission { get; set; }
        public DateTime DateDischarge { get; set; }
        public virtual Room Room { get; set; }
        public virtual Therapy Therapy { get; set; }

        public TreatmentDto() { }

        public TreatmentDto(int id, PatientDto patient, string reasonForDischarge, DateTime dateAdmission, DateTime dateDischarge, Room room, Therapy therapy)
        {
            Id = id;
            Patient = patient;
            ReasonForDischarge = reasonForDischarge;
            DateAdmission = dateAdmission;
            DateDischarge = dateDischarge;
            Room = room;
            Therapy = therapy;
        }
    }
}
