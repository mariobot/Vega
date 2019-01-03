using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Vega.API.Models
{
    public class Make
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Model> Models { get; set; }

        public Make()
        {
            Models = new Collection<Model>();
        }
    }
}