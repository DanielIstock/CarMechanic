using System;
using System.Collections.Generic;

namespace CarMechanic.Models
{
    public class Repair
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }

        public ICollection<Part> Parts { get; set; } = new List<Part>();
    }
}
