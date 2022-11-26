using System;
using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.DTOs
{
    public class TreatmentDto
    {
        public int Id { get; set; }
        public virtual PatientDto Patient { get; set; }
        public string ReasonForDischarge { get; set; }
        public string ReasonForAdmission { get; set; }
        public DateTime DateAdmission { get; set; }
        public DateTime DateDischarge { get; set; }
        public virtual RoomDto RoomDto { get; set; }
        public virtual Therapy Therapy { get; set; }

        public TreatmentDto() { }

        public TreatmentDto(int id, PatientDto patient, string reasonForDischarge, string reasonForAdmission, DateTime dateAdmission, DateTime dateDischarge, RoomDto roomDto, Therapy therapy)
        {
            Id = id;
            Patient = patient;
            ReasonForDischarge = reasonForDischarge;
            ReasonForAdmission = reasonForAdmission;
            DateAdmission = dateAdmission;
            DateDischarge = dateDischarge;
            RoomDto = roomDto;
            Therapy = therapy;
        }
    }
}
