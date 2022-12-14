using System;

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
