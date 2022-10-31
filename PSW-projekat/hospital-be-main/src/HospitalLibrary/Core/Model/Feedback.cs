using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class Feedback : BaseModel
    {
        //public int FeedbackId { get; set; }

        [Required]
        public String Description { get; set; }

        public Boolean IsAnonimous { get; set; }

        public Boolean IsPublic { get; set; }

        public DateTime DateCreated { get; set; }

        public String UserId { get; set; }
    }
}
