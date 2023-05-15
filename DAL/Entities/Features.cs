
using System.ComponentModel.DataAnnotations;

namespace Datalayer.Entities
{
    public class Features
    {
        [Key]
        public int Featureid { get; set; }

        public Geometry Geometry { get; set; }
        public string Id { get; set; }
        public string Type { get; set; }
        public Properties Properties { get; set; }

    }

}