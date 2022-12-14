using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Model
{
    [Owned]
    public class Time : ValueObject
    {
        public int Hour { get; }
        public int Minute { get; }

        public Time() { }

        public Time(int hour, int minute)
        {
            if(Validate(hour, minute))
            {
                Hour = hour;
                Minute = minute;
            }
            else
            {
                throw new Exception("Invalid data.");
            }
        }

        private bool Validate(int hour, int minute)
        {
            if(hour>=0 && hour<=23 && minute>=0 && minute <= 59)
            {
                return true;
            }
            return false;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Hour;
            yield return Minute;
        }
        public bool IsBefore(Time otherTime)
        {
            if (otherTime.Hour > Hour)
            {
                return true;
            }
            if (otherTime.Hour == Hour && otherTime.Minute > Minute)
            {
                return true;
            }
            return false;
        }

        public bool IsAfter(Time otherTime)
        {
            if (otherTime.Hour < Hour)
            {
                return true;
            }
            if (otherTime.Hour == Hour && otherTime.Minute < Minute)
            {
                return true;
            }
            return false;
        }

        public static bool operator <(Time a, Time b)
        {
            if (b.Hour > a.Hour)
            {
                return true;
            }
            if (b.Hour == a.Hour && b.Minute > a.Minute)
            {
                return true;
            }
            return false;
        }

        public static bool operator >(Time a, Time b)
        {
            if (b.Hour < a.Hour)
            {
                return true;
            }
            if (b.Hour == a.Hour && b.Minute < a.Minute)
            {
                return true;
            }
            return false;
        }

        public Time AddMinutes(int minutes)
        {
            int newHour = this.Hour;
            int newMinute = this.Minute + minutes;
            while (newMinute > 59)
            {
                newHour += 1;
                newMinute -= 60;
            }

            return new Time(newHour, newMinute);
        }

        public override string ToString()
        {
            string s = Hour.ToString() + ":" + Minute.ToString();
            if (Minute == 0)
            {
                 s += "0";
            }
            if (Hour < 10)
            {
                s = "0" + s;
            }
            return s; 
        }
    }
}
