using Flight.Services.ScheduleAPI.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.ScheduleAPI.Repository
{
    public interface IScheduleRepository
    {
        Task<IEnumerable<ScheduleDetailViewDto>> GetSchedule();
        Task<ScheduleDetailDto> CreateUpdateSchedule(ScheduleDetailDto scheduleDetailsDto);
        Task<bool> RemoveSchedule(int ScheduleDetailsId);
        Task<IEnumerable<ScheduleDetailViewDto>> GetScheduleByDate(DateTime startDate);
        Task<IEnumerable<ScheduleDetailViewDto>> GetScheduleBySourceDestination(string source, string destination);
        Task<IEnumerable<ScheduleDetailViewDto>> GetScheduleBySDwithDate(string source, string destination, DateTime traveldate);
        Task<ScheduleDetailViewDto> GetScheduleById(int ScheduleDetailsId);
        Task<bool> AddOrder(AirlineViewDto airline);
    }
}
