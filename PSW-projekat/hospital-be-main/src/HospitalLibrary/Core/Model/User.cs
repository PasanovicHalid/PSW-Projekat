using HospitalLibrary.Core.Model.Enums;
using System;

namespace HospitalLibrary.Core.Model
{
    public class User : BaseModel
    {
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Email { get; set; }
        public Role Role { get; set;}
    }
}
