using System;

namespace HospitalLibrary.Core.Model
{
    public class Address : BaseModel
    {
        public String Street { get; set; }
        public String Number { get; set; }
        public String City { get; set; }
        public String Township { get; set; } //opština?
        public String PostCode { get; set; }
    }
}
