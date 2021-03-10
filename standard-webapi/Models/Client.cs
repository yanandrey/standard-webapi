using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace standard_webapi.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Required field")]
        [MaxLength(16)]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Required field")]
        [MaxLength(16)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Required field")]
        [MaxLength(8)]
        public string Gender { get; set; }
        
        public ICollection<Contact> Contacts { get; set; }
        
        public ICollection<Address> Addresses { get; set; }
    }
}