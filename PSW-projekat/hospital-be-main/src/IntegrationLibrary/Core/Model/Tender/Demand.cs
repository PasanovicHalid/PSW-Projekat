using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model.Tender
{
    public class Demand : BaseModel
    {
        [Required]
        public BloodType BloodType { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public virtual Tender Tender { get; set; }
    }
}
