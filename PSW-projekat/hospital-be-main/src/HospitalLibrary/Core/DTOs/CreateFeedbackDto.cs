using HospitalLibrary.Core.Model.Enums;
using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.DTOs
{
    public class CreateFeedbackDto
    {
        public String Description { get; set; }

        public Boolean IsAnonimous { get; set; }

        public Boolean IsPublic { get; set; }

        public string UserId { get; set; }
    }
}
