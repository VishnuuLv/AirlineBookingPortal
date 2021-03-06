using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.ScheduleAPI.Models
{
    public class ScheduleDetail
    {
        [Key]
        public int ScheduleDetailsId { get; set; }
        public int FlightId { get; set; }
        [ForeignKey("FlightId")]
        public virtual Airline Flight { get; set; }
        public string flightnumber { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        //public TimeSpan Starttime { get; set; }
        //public TimeSpan Endtime { get; set; }
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public string ScheduledDays { get; set; }
        public string Instrumentused { get; set; }
        public int EconomySeats { get; set; }
        public int BusinessClassSeats { get; set; }
        public int TotalSeats { get; set; }
        public double EconomyCost { get; set; }
        public double BusinessClassCost { get; set; }
        public int NoOfRows { get; set; }
        public string Meal { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        [DefaultValue('Y')]
        public char IsActive { get; set; }
    }
}
