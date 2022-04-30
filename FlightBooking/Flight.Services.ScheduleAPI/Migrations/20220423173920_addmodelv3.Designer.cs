﻿// <auto-generated />
using System;
using Flight.Services.ScheduleAPI.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Flight.Services.ScheduleAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220423173920_addmodelv3")]
    partial class addmodelv3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Flight.Services.ScheduleAPI.Models.Airline", b =>
                {
                    b.Property<int>("FlightId")
                        .HasColumnType("int");

                    b.Property<string>("ContactAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FlightName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsActive")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("LogoURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("FlightId");

                    b.ToTable("Flight");

                    b.HasData(
                        new
                        {
                            FlightId = 1,
                            ContactAddress = "Mumbai",
                            ContactNumber = "1234567890",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FlightName = "Air India",
                            IsActive = " ",
                            LogoURL = "Null",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            FlightId = 2,
                            ContactAddress = "Delhi",
                            ContactNumber = "1234657890",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FlightName = "Vistara",
                            IsActive = " ",
                            LogoURL = "Null",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            FlightId = 3,
                            ContactAddress = "Bangalore",
                            ContactNumber = "1243657890",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FlightName = "Go Air",
                            IsActive = " ",
                            LogoURL = "Null",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            FlightId = 4,
                            ContactAddress = "Mumbai",
                            ContactNumber = "1243658790",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FlightName = "Indigo",
                            IsActive = " ",
                            LogoURL = "Null",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            FlightId = 5,
                            ContactAddress = "Chennai",
                            ContactNumber = "1253658790",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FlightName = "Spice Jet",
                            IsActive = " ",
                            LogoURL = "Null",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Flight.Services.ScheduleAPI.Models.ScheduleDetail", b =>
                {
                    b.Property<int>("ScheduleDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("BusinessClassCost")
                        .HasColumnType("float");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("EconomyCost")
                        .HasColumnType("float");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FlightId")
                        .HasColumnType("int");

                    b.Property<string>("FromPlace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instrumentused")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsActive")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Meal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NoOfRows")
                        .HasColumnType("int");

                    b.Property<string>("ScheduledDays")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ToPlace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalSeats")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("flightnumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("seatsId")
                        .HasColumnType("int");

                    b.HasKey("ScheduleDetailsId");

                    b.HasIndex("FlightId");

                    b.HasIndex("seatsId");

                    b.ToTable("ScheduleDetails");
                });

            modelBuilder.Entity("Flight.Services.ScheduleAPI.Models.Seat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BusinessClassSeats")
                        .HasColumnType("int");

                    b.Property<int>("EconomyClassSeats")
                        .HasColumnType("int");

                    b.Property<int>("FlightId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("seats");
                });

            modelBuilder.Entity("Flight.Services.ScheduleAPI.Models.ScheduleDetail", b =>
                {
                    b.HasOne("Flight.Services.ScheduleAPI.Models.Airline", "Flight")
                        .WithMany()
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Flight.Services.ScheduleAPI.Models.Seat", "seats")
                        .WithMany()
                        .HasForeignKey("seatsId");

                    b.Navigation("Flight");

                    b.Navigation("seats");
                });
#pragma warning restore 612, 618
        }
    }
}
