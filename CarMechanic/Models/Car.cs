using System;
using System.Collections.Generic;

namespace CarMechanic.Models
{
    /// <summary>
    /// Represents a car in the car mechanic system.
    /// </summary>
    public class Car
    {
        /// <summary>
        /// Gets or sets the unique identifier for the car.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the model of the car.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the license plate of the car.
        /// </summary>
        public string LicensePlate { get; set; }

        /// <summary>
        /// Gets or sets the user ID associated with the car.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the user associated with the car.
        /// </summary>
        public User? User { get; set; }

        /// <summary>
        /// Gets or sets the collection of repairs associated with the car.
        /// </summary>
        public ICollection<Repair>? Repairs { get; set; }
    }
}
