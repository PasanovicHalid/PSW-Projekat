using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model.Enums;

namespace HospitalLibrary.Core.DTOs
{
    public class BedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BedState BedState { get; set; }
        public virtual PatientDto PatientDto { get; set; }
        public int Quantity { get; set; }
    }
}
