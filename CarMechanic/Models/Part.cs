﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMechanic.Models
{
    public class Part
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int RepairId { get; set; }
        public Repair Repair { get; set; }
    }
}