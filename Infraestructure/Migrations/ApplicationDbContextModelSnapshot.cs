﻿// <auto-generated />
using System;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Domain.Entities.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DriverUserId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Kilometers")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Model")
                        .HasColumnType("INTEGER");

                    b.HasKey("CarId");

                    b.HasIndex("DriverUserId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Domain.Entities.Travel", b =>
                {
                    b.Property<int>("TavelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DriverUserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EndDirection")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StarDirection")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TEXT");

                    b.Property<float>("price")
                        .HasColumnType("REAL");

                    b.HasKey("TavelId");

                    b.HasIndex("DriverUserId");

                    b.ToTable("Travels");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("TEXT");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasDiscriminator().HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("PassengerTravel", b =>
                {
                    b.Property<int>("PassengersUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ReservationsTavelId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PassengersUserId", "ReservationsTavelId");

                    b.HasIndex("ReservationsTavelId");

                    b.ToTable("PassengerTravel");
                });

            modelBuilder.Entity("Domain.Entities.Driver", b =>
                {
                    b.HasBaseType("Domain.Entities.User");

                    b.HasDiscriminator().HasValue("Driver");
                });

            modelBuilder.Entity("Domain.Entities.Passenger", b =>
                {
                    b.HasBaseType("Domain.Entities.User");

                    b.HasDiscriminator().HasValue("Passenger");
                });

            modelBuilder.Entity("Domain.Entities.Car", b =>
                {
                    b.HasOne("Domain.Entities.Driver", null)
                        .WithMany("Cars")
                        .HasForeignKey("DriverUserId");
                });

            modelBuilder.Entity("Domain.Entities.Travel", b =>
                {
                    b.HasOne("Domain.Entities.Driver", "Driver")
                        .WithMany("Travels")
                        .HasForeignKey("DriverUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("PassengerTravel", b =>
                {
                    b.HasOne("Domain.Entities.Passenger", null)
                        .WithMany()
                        .HasForeignKey("PassengersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Travel", null)
                        .WithMany()
                        .HasForeignKey("ReservationsTavelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Driver", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("Travels");
                });
#pragma warning restore 612, 618
        }
    }
}
