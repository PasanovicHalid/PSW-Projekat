using HospitalLibrary.Core.Model.Enums;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Model
{
    public class Doctor : BaseModel
    {
        public Specialization Specialization { get; set; }

        public virtual Person Person { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }

        public virtual ICollection<DoctorsCouncil> Councils { get; set; }
    }
}
