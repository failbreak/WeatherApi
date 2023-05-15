
using System.ComponentModel.DataAnnotations;

namespace Datalayer.Entities
{
    public class Cords
    {
        [Key]
        public int Id { get; set; }
        public double Value { get; set; }
    }

}