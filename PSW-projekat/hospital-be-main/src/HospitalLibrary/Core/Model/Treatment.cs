using System;
using HospitalLibrary.Core.Model.Enums;

namespace HospitalLibrary.Core.Model
{
    public class Treatment: BaseModel
    {
        public virtual Patient Patient { get; set; }
        public DateTime DateAdmission { get; set; }
        public DateTime DateDischarge { get; set; }
        public string ReasonForAdmission { get; set; }
        public string ReasonForDischarge { get; set; }
        public TreatmentState TreatmentState { get; set; }
        public virtual Therapy Therapy { get; set; }
        public virtual Room Room { get; set; }
    }
}
