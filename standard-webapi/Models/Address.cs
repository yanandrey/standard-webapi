using System.ComponentModel.DataAnnotations;

namespace standard_webapi.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Required field")]
        [MaxLength(16)]
        public string City { get; set; }
        
        [Required(ErrorMessage = "Required field")]
        [MaxLength(16)]
        public string Country { get; set; }
    }
}