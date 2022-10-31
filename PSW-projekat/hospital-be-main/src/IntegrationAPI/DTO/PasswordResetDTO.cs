using System.ComponentModel.DataAnnotations;

namespace IntegrationAPI.DTO
{
    public class PasswordResetDTO
    {
        [Required]
        public string Password { get; set; }
    }
}
