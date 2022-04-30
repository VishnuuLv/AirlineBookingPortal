using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.BookingAPI.Models.Dto
{
    public class PassengerDto
    {
        public int PassengerId { get; set; }
        public int BookingId { get; set; }
        
        public string PassengerName { get; set; }
        public string PassengerGender { get; set; }
        public int PassengerAge { get; set; }
        public char TypeOfSeats { get; set; }
    }
}
