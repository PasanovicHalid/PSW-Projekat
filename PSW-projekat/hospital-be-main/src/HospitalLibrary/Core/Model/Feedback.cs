using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class Feedback : BaseModel
    {
        public string FeedbackId { get; set; }

        public String Description { get; set; }

        private Boolean IsAnonimous { get; set; }

        private Boolean IsPublic { get; set; }

        private DateTime DateCreated { get; set; }

        private String UserId { get; set; }
    }
}
