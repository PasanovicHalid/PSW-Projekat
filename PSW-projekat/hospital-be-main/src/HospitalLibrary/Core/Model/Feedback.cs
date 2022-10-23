using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class Feedback : BaseModel
    {
        public int FeedbackId { get; set; }

        public String Description { get; set; }

        public Boolean IsAnonimous { get; set; }

        public Boolean IsPublic { get; set; }

        public DateTime DateCreated { get; set; }

        public String UserId { get; set; }
    }
}
