using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAPI.DTO
{
    public class BloodBankCreationDTO
    {
        public string Name { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Url]
        [Required]
        public string ServerAddress { get; set; }
    }
}
