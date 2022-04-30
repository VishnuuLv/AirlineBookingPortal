using AutoMapper;
using Flight.Services.ScheduleAPI.Models;
using Flight.Services.ScheduleAPI.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.ScheduleAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<AirlineDto, Airline>().ReverseMap();
                //config.CreateMap<ScheduleHeader, ScheduleHeaderDto>().ReverseMap();
                config.CreateMap<ScheduleDetail, ScheduleDetailDto>().ReverseMap();
                config.CreateMap<ScheduleDetail, ScheduleDetailViewDto>().ReverseMap();
                config.CreateMap<AirlineViewDto, Airline>().ReverseMap();
               
                //config.CreateMap<Schedule, ScheduleDto>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
