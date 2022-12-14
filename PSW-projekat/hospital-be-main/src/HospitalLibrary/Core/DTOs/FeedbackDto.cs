using System;

namespace HospitalLibrary.Core.DTOs
{
    public class FeedbackDto
    {
        public int FeedbackId { get; set; }

        public String Description { get; set; }

        public String Username { get; set; }

        public String Public { get; set; }

        public String DateCreated { get; set; }

        public String Status { get; set; }
    }
}
