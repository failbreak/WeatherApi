
using System.ComponentModel.DataAnnotations;

namespace Datalayer.Entities
{
    public class Application
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public ICollection<Features> Features { get; set; }
    }

}