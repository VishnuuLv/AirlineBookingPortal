using AutoMapper;
using Flight.Services.BookingAPI.Models;
using Flight.Services.BookingAPI.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.BookingAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
               

                config.CreateMap<Booking, BookingDto>().ReverseMap();
                config.CreateMap<Booking, BookingViewDto>().ReverseMap();
                config.CreateMap<Passenger, PassengerDto>().ReverseMap();
                //config.CreateMap<ScheduleDetails, ScheduleDetailsDto>().ReverseMap();
            });
            return mappingConfig;
        }
     }
}
