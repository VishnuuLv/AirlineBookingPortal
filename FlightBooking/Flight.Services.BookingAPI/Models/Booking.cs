using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.BookingAPI.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public int ScheduleDetailsId { get; set; }        
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Passenger> Passenger { get; set; }
        
        //public string Gender { get; set; }
        //public int Age { get; set; }
        public string EmailId { get; set; }
        //public int NoOfSeats { get; set; }
        public string OptForMeal { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        [DefaultValue('Y')]
        public char IsActive { get; set; }

    }
}
