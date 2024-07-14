using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMechanic.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public ICollection<Repair>? Repairs { get; set; }
    }
}
