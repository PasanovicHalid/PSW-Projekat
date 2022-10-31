using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalLibrary.Core.Model
{
    public class Room : BaseModel
    {
        public string Number { get; set; }
        [Range(1, 10)]
        public int Floor { get; set; }
    }
}
