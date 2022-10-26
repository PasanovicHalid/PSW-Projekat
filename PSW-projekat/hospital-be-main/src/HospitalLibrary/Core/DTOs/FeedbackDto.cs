using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.DTOs
{
    public class FeedbackDto
    {
        public int FeedbackId { get; set; }

        public String Description { get; set; }

        public String Username { get; set; }

        public String Public { get; set; }

        public String DateCreated { get; set; }
    }
}
