using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.DTOs
{
    public class MaliciousPatientDto
    {
        public int Id { get; set; }
        public String FullName { get; set; }
        public String Username { get; set; }
        public String IsBlocked { get; set; }

        public MaliciousPatientDto() { }

        public MaliciousPatientDto(int id, string fullname, string username, String isBlocked)
        {
            Id = id;
            FullName = fullname;
            Username = username;
            IsBlocked = isBlocked;
        }
    }
}
