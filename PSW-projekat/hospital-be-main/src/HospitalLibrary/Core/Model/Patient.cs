using HospitalLibrary.Core.Model.Enums;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Model
{
    public class Patient : BaseModel
    {
        public BloodType BloodType { get; set; }
        //public virtual ICollection<Allergy> Allergies { get; set; }
        public virtual Person Doctor { get; set; }
        //public int DoctorId { get; set; }

    }
}
