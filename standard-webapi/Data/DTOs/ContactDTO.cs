using System.ComponentModel.DataAnnotations;

namespace standard_webapi.Data.DTOs
{
    public class ContactDTO
    {
        [Required(ErrorMessage = "Required field")]
        [MaxLength(32)]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Required field")]
        [MaxLength(16)]
        public string Phone { get; set; }
    }
}