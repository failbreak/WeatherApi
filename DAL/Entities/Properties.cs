﻿
using System.ComponentModel.DataAnnotations;

namespace Datalayer.Entities
{
    public class Properties
    {
        [Key]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Observed { get; set; }
        public string ParameterId { get; set; }
        public string StationId { get; set; }
        public double Value { get; set; }

    }

}