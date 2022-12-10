using System;

namespace HospitalLibrary.Core.Model
{
    public class Appointment: BaseModel
    {
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime? CancelationDate { get; set; }
    }
}
