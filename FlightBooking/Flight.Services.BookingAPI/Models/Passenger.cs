using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.BookingAPI.Models
{
    public class Passenger
    {
        [Key]
        public int PassengerId { get; set; }
        public int BookingId { get; set; }       
        public string PassengerName { get; set; }
        public string PassengerGender { get; set; }
        public int PassengerAge { get; set; }
        public char TypeOfSeats { get; set; }
    }
}
