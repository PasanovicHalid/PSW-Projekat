using HospitalLibrary.Core.Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.DTO
{
    public class BloodForStoringDTO : BaseModelDTO
    {
        [Required]
        public BloodType BloodType { get; set; }
        [Required]
        public int Quantity { get; set; }

        public BloodForStoringDTO(int id, BloodType type, int quantity)
        {
            Id = id;
            BloodType = type;
            Quantity = quantity;
        }
        public BloodForStoringDTO() { }
    }
}
