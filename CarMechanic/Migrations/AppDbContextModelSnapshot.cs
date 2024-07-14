﻿// <auto-generated />
using System;
using CarMechanic.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarMechanic.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.32");

            modelBuilder.Entity("CarMechanic.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarMechanic.Models.Part", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("RepairId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RepairId");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("CarMechanic.Models.Repair", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CarId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RepairDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("Repairs");
                });

            modelBuilder.Entity("CarMechanic.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CarMechanic.Models.Car", b =>
                {
                    b.HasOne("CarMechanic.Models.User", "User")
                        .WithMany("Cars")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CarMechanic.Models.Part", b =>
                {
                    b.HasOne("CarMechanic.Models.Repair", "Repair")
                        .WithMany("Parts")
                        .HasForeignKey("RepairId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Repair");
                });

            modelBuilder.Entity("CarMechanic.Models.Repair", b =>
                {
                    b.HasOne("CarMechanic.Models.Car", "Car")
                        .WithMany("Repairs")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("CarMechanic.Models.Car", b =>
                {
                    b.Navigation("Repairs");
                });

            modelBuilder.Entity("CarMechanic.Models.Repair", b =>
                {
                    b.Navigation("Parts");
                });

            modelBuilder.Entity("CarMechanic.Models.User", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
