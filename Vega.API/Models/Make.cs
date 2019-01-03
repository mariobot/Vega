using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Vega.API.Models
{
    public class Make
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public List<Model> Models { get; set; }

        public Make()
        {
            Models = new List<Model>();
        }
    }
}