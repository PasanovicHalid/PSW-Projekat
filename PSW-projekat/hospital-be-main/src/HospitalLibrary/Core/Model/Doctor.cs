using HospitalLibrary.Core.Model.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalLibrary.Core.Model
{
    public class Doctor : BaseModel
    {
        public Specialization Specialization { get; set; }

        public virtual Person Person { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }

        [Column(TypeName = "jsonb")]
        public ICollection<DoctorSchedule> DoctorSchedules { get; set; }
    }
}
