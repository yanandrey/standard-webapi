using System.ComponentModel.DataAnnotations;

namespace standard_webapi.Data.DTOs
{
    public class AddressDTO
    {
        [Required(ErrorMessage = "Required field")]
        [MaxLength(16)]
        public string City { get; set; }
        
        [Required(ErrorMessage = "Required field")]
        [MaxLength(16)]
        public string Country { get; set; }
    }
}