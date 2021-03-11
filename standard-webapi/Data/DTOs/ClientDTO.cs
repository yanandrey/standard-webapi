using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace standard_webapi.Data.DTOs
{
    public class ClientDTO
    {
        [Required(ErrorMessage = "Required field")]
        [MaxLength(16)]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Required field")]
        [MaxLength(16)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Required field")]
        [MaxLength(8)]
        public string Gender { get; set; }
        
        public ICollection<ContactDTO> Contacts { get; set; }
        
        public ICollection<AddressDTO> Addresses { get; set; }
    }
}