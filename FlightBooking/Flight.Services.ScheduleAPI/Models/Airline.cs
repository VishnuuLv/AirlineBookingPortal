using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.ScheduleAPI.Models
{
    public class Airline
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FlightId { get; set; }
        [Required]
        public string FlightName { get; set; }
        public string ContactNumber { get; set; }
        public string ContactAddress { get; set; }
        public string LogoURL { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        [DefaultValue('Y')]
        public char IsActive { get; set; }
    }
}
