using HospitalLibrary.Core.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.DTO
{
    public class BloodConsumptionDTO : BaseModelDTO
    {
        public Blood Blood { get; set; }
        public String Purpose { get; set; }
        public int DoctorId { get; set; }

    }
}
