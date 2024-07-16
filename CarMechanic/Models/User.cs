using System;
using System.Collections.Generic;

namespace CarMechanic.Models
{
    /// <summary>
    /// Represents a user in the car mechanic system.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the collection of cars associated with the user.
        /// </summary>
        public ICollection<Car>? Cars { get; set; }
    }
}
