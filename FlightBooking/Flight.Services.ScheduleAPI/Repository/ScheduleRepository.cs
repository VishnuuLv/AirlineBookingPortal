using AutoMapper;
using Flight.Services.ScheduleAPI.DbContexts;
using Flight.Services.ScheduleAPI.Models;
using Flight.Services.ScheduleAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.ScheduleAPI.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {

        private readonly ApplicationDbContext _db;
        private IMapper _mapper;
       

        public ScheduleRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ScheduleDetailDto> CreateUpdateSchedule(ScheduleDetailDto scheduleDetailsDto)
        {
            ScheduleDetail schedule = _mapper.Map<ScheduleDetailDto, ScheduleDetail>(scheduleDetailsDto);
            var CreatedDateTemp = await _db.ScheduleDetails.Where(u => u.ScheduleDetailsId == schedule.ScheduleDetailsId).Select(u => u.CreatedDate).SingleOrDefaultAsync();

            if (schedule.ScheduleDetailsId > 0)
            {
                schedule.IsActive = 'Y';
                schedule.UpdatedDate = DateTime.Now;
                schedule.CreatedDate = CreatedDateTemp;                
                _db.ScheduleDetails.Update(schedule);
            }
            else
            {
                schedule.IsActive = 'Y';
                schedule.CreatedDate = DateTime.Now;
                schedule.UpdatedDate = DateTime.Now;                                
                _db.ScheduleDetails.Add(schedule);
            }
            await _db.SaveChangesAsync();

            return _mapper.Map < ScheduleDetail, ScheduleDetailDto>(schedule);
        }

        public async Task<IEnumerable<ScheduleDetailViewDto>> GetSchedule()
        {
            List<ScheduleDetail> scheduleList = await _db.ScheduleDetails.ToListAsync();
            return _mapper.Map<List<ScheduleDetailViewDto>>(scheduleList);
        }

        public async Task<bool> RemoveSchedule(int ScheduleDetailsId)
        {
            try
            {
                ScheduleDetail schedule = await _db.ScheduleDetails.FirstOrDefaultAsync(x => x.ScheduleDetailsId == ScheduleDetailsId);
                if (schedule == null)
                {
                    return false;
                }
                else
                {
                    schedule.IsActive = 'N';
                    await _db.SaveChangesAsync();
                    return true;
                }

                

            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<ScheduleDetailViewDto> GetScheduleById(int scheduleDetailsId)
        {
            ScheduleDetail scheduleDetail = await _db.ScheduleDetails.Where(x => x.ScheduleDetailsId == scheduleDetailsId).FirstOrDefaultAsync();
            return _mapper.Map<ScheduleDetailViewDto>(scheduleDetail);
        }      

        

        public async Task<IEnumerable<ScheduleDetailViewDto>> GetScheduleByDate(DateTime startDate)
        {          

            List<ScheduleDetail> scheduleDetail =
                await _db.ScheduleDetails.Where(x => x.StartDate.Date == startDate.Date).ToListAsync();                
            return _mapper.Map<List<ScheduleDetailViewDto>>(scheduleDetail);
        }

        public async Task<IEnumerable<ScheduleDetailViewDto>> GetScheduleBySourceDestination(string source, string destination)
        {
            List<ScheduleDetail> scheduleDetail =
               await _db.ScheduleDetails.Where(x => x.FromPlace == source && x.ToPlace==destination).ToListAsync();
            return _mapper.Map<List<ScheduleDetailViewDto>>(scheduleDetail);
        }
        public async Task<IEnumerable<ScheduleDetailViewDto>> GetScheduleBySDwithDate(string source, string destination,DateTime traveldate)
        {
            List<ScheduleDetail> scheduleDetail =
               await _db.ScheduleDetails.Where(x => x.FromPlace == source && x.ToPlace == destination && x.StartDate.Date==traveldate.Date).ToListAsync();
            return _mapper.Map<List<ScheduleDetailViewDto>>(scheduleDetail);
        }

        public async Task<bool> AddOrder(AirlineViewDto airline)
        {
            Airline airdto = _mapper.Map<AirlineViewDto, Airline>(airline);
            _db.Flight.Add(airdto);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
