using System.ComponentModel.DataAnnotations;

namespace standard_webapi.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Required field")]
        [MaxLength(32)]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Required field")]
        [MaxLength(16)]
        public string Phone { get; set; }
    }
}