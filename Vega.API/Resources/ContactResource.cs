using System.ComponentModel.DataAnnotations;

namespace Vega.API.Resources
{
    public class ContactResource
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string Phone { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }
    }
}