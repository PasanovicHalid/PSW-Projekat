using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    [Owned]
    public class TimeRange : ValueObject
    {
        public Time StartTime { get; }
        public Time EndTime { get; }

        public TimeRange(Time startTime, Time endTime)
        {
            if(Validation(startTime, endTime))
            {
                StartTime = startTime;
                EndTime = endTime;
            }
            throw Exception("Invalid data.");
        }

        private Exception Exception(string message)
        {
            throw Exception(message);
        }

        private bool Validation(Time startTime, Time endTime)
        {
            return StartTime < endTime && EndTime > startTime;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return StartTime;
            yield return EndTime;
        }

        public bool IsDuring(Time time)
        {
            return time > StartTime && time < EndTime;
        }
    }
}
