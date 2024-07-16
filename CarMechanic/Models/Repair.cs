using System;
using System.Collections.Generic;

namespace CarMechanic.Models
{
    /// <summary>
    /// Represents a repair in the car mechanic system.
    /// </summary>
    public class Repair
    {
        /// <summary>
        /// Gets or sets the unique identifier for the repair.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the description of the repair.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date of the repair.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the car associated with the repair.
        /// </summary>
        public int CarId { get; set; }

        /// <summary>
        /// Gets or sets the car associated with the repair.
        /// </summary>
        public Car Car { get; set; }

        /// <summary>
        /// Gets or sets the collection of parts used in the repair.
        /// </summary>
        public ICollection<Part> Parts { get; set; } = new List<Part>();
    }
}
