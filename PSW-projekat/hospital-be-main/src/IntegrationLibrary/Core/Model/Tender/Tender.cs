using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model.Tender
{
    public class Tender : EntityClass
    {
        public DateTime DueDate { get; set; }
        [Required]
        public TenderState State { get; set; }
        public virtual List<Demand> Demands { get; set; }
        public Tender() { }
    }
}
