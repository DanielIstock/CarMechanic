using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMechanic.Models
{
    public class Repair
    {
        public int Id { get; set; }
        public DateTime RepairDate { get; set; }
        public string Description { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public ICollection<Part> Parts { get; set; }
    }
}
