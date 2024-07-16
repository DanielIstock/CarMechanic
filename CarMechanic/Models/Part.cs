using System;

namespace CarMechanic.Models
{
    /// <summary>
    /// Represents a part in the car mechanic system.
    /// </summary>
    public class Part
    {
        /// <summary>
        /// Gets or sets the unique identifier for the part.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the part.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the price of the part.
        /// </summary>
        public decimal Price { get; set; }
    }
}
