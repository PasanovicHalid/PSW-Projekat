using IntegrationLibrary.Core.Model;
using System.ComponentModel.DataAnnotations;

namespace IntegrationAPI.DTO
{
    public class DemandDTO
    {
        [Required]
        public int BloodQuantity { get; set; }
        [Required]
        public BloodType BloodType { get; set; }
    }
}
