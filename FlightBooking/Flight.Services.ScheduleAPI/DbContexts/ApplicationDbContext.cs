using Flight.Services.ScheduleAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.ScheduleAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Airline> Flight { get; set; }

        public DbSet<ScheduleDetail> ScheduleDetails { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Airline>().HasData(new Airline
            {
                FlightId = 1,
                FlightName = "Air India",
                ContactNumber = "1234567890",
                ContactAddress = "Mumbai",
                LogoURL = "Null"
            });
            modelBuilder.Entity<Airline>().HasData(new Airline
            {
                FlightId = 2,
                FlightName = "Vistara",
                ContactNumber = "1234657890",
                ContactAddress = "Delhi",
                LogoURL = "Null"
            });
            modelBuilder.Entity<Airline>().HasData(new Airline
            {
                FlightId = 3,
                FlightName = "Go Air",
                ContactNumber = "1243657890",
                ContactAddress = "Bangalore",
                LogoURL = "Null"
            });
            modelBuilder.Entity<Airline>().HasData(new Airline
            {
                FlightId = 4,
                FlightName = "Indigo",
                ContactNumber = "1243658790",
                ContactAddress = "Mumbai",
                LogoURL = "Null"
            });
            modelBuilder.Entity<Airline>().HasData(new Airline
            {
                FlightId = 5,
                FlightName = "Spice Jet",
                ContactNumber = "1253658790",
                ContactAddress = "Chennai",
                LogoURL = "Null"
            });
        }

    }
}
