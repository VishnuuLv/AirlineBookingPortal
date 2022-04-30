using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.ScheduleAPI.Models.Dto
{
    public class AirlineDto
    {
        public int FlightId { get; set; }
        public string FlightName { get; set; }
        public string ContactNumber { get; set; }
        public string ContactAddress { get; set; }
        public string LogoURL { get; set; }
    }
}
