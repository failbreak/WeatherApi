using System.ComponentModel.DataAnnotations;

namespace Datalayer.Entities
{
    public class Geometry
    {
        public ICollection<Cords> Coordinates { get; set; }
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
    }
}