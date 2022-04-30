using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.BookingAPI.Models.Dto
{
    public class BookingViewDto
    {
       
        public int BookingId { get; set; }
        public int ScheduleDetailsId { get; set; }
        public int UserId { get; set; }
      
        public string Name { get; set; }
        public List<PassengerDto> Passenger { get; set; }

        //public string Gender { get; set; }
        //public int Age { get; set; }
        public string EmailId { get; set; }
        //public int NoOfSeats { get; set; }
        public string OptForMeal { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
       
        public char IsActive { get; set; }
    }
}
