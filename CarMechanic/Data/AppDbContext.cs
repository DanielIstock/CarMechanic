using Microsoft.EntityFrameworkCore;
using CarMechanic.Models;
using System;
using System.Linq;

namespace CarMechanic.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<Part> Parts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=carmechanic.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Cars)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Car>()
                .HasMany(c => c.Repairs)
                .WithOne(r => r.Car)
                .HasForeignKey(r => r.CarId);

            modelBuilder.Entity<Repair>()
                .HasMany(r => r.Parts)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

        public void Seed()
        {
            Console.WriteLine("Checking if seeding is needed...");

        
                Console.WriteLine("Seeding database...");

                var user1 = new User { Name = "John Doe", Email = "john.doe@example.com" };
                var user2 = new User { Name = "Jane Smith", Email = "jane.smith@example.com" };
                var user3 = new User { Name = "Bob Johnson", Email = "bob.johnson@example.com" };
                var user4 = new User { Name = "Alice Brown", Email = "alice.brown@example.com" };
                var user5 = new User { Name = "Charlie Davis", Email = "charlie.davis@example.com" };

                Users.AddRange(user1, user2, user3, user4, user5);

                var car1 = new Car { Model = "Toyota Camry", LicensePlate = "ABC123", User = user1 };
                var car2 = new Car { Model = "Honda Accord", LicensePlate = "XYZ456", User = user2 };
                var car3 = new Car { Model = "Ford Focus", LicensePlate = "DEF789", User = user3 };
                var car4 = new Car { Model = "Chevrolet Malibu", LicensePlate = "GHI012", User = user4 };
                var car5 = new Car { Model = "Nissan Altima", LicensePlate = "JKL345", User = user5 };

                Cars.AddRange(car1, car2, car3, car4, car5);

                var repair1 = new Repair { Date = DateTime.Now, Description = "Oil change", Car = car1 };
                var repair2 = new Repair { Date = DateTime.Now, Description = "Brake replacement", Car = car2 };
                var repair3 = new Repair { Date = DateTime.Now, Description = "Tire rotation", Car = car3 };
                var repair4 = new Repair { Date = DateTime.Now, Description = "Battery replacement", Car = car4 };
                var repair5 = new Repair { Date = DateTime.Now, Description = "Spark plug replacement", Car = car5 };

                Repairs.AddRange(repair1, repair2, repair3, repair4, repair5);

                var part1 = new Part { Name = "Oil filter", Price = 19.99m };
                var part2 = new Part { Name = "Brake pads", Price = 49.99m };
                var part3 = new Part { Name = "Tire", Price = 99.99m };
                var part4 = new Part { Name = "Battery", Price = 79.99m };
                var part5 = new Part { Name = "Spark plug", Price = 29.99m };

                repair1.Parts.Add(part1);
                repair2.Parts.Add(part2);
                repair3.Parts.Add(part3);
                repair4.Parts.Add(part4);
                repair5.Parts.Add(part5);

                SaveChanges();
                Console.WriteLine("Database seeded successfully.");
            }
       
        }
   }

