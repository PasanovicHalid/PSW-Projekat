using System;

namespace HospitalLibrary.Core.Model
{
    public class WorkingDay : BaseModel
    {
        public int DayOfWeek { get; set; }
        public DateTime StartTime {get; set;}
        public DateTime EndTime { get; set; }
    }
}
