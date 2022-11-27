using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model.Tender
{
    public class Tender : BaseModel
    {
        public DateTime DueDate { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public virtual List<Demand> Demands { get; set; }
    }
}
