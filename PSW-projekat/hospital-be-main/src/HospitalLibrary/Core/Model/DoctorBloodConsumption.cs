using System;

namespace HospitalLibrary.Core.Model
{
    public class DoctorBloodConsumption : BaseModel
    {
        public virtual Blood Blood { get; set; }
        public DateTime Date { get; set; }
        public String Purpose { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
