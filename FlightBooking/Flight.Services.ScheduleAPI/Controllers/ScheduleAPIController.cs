using Flight.Services.ScheduleAPI.Models.Dto;
using Flight.Services.ScheduleAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.ScheduleAPI.Controllers
{
    [Route("api/Schedule")]
    public class ScheduleAPIController : Controller
    {
        private readonly IScheduleRepository _scheduleRepository;
        protected ResponseDto _response;

        public ScheduleAPIController(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
            this._response = new ResponseDto();
        }

        [HttpGet("GetSchedule")]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ScheduleDetailViewDto> scheduleDt = await _scheduleRepository.GetSchedule();
                _response.Result = scheduleDt;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };

            }
            return _response;
        }
        [HttpPost]
        [Route("AddSchedule")]

        public async Task<object> AddSchedule([FromBody] ScheduleDetailDto scheduleDetailsDto)
        {
            try
            {
                ScheduleDetailDto scheduleDt = await _scheduleRepository.CreateUpdateSchedule(scheduleDetailsDto);
                _response.Result = scheduleDt;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPut]
        [Route("UpdateSchedule")]
        public async Task<object> UpdateSchedule([FromBody] ScheduleDetailDto scheduleDetailsDto)
        {
            try
            {
                ScheduleDetailDto scheduleDt = await _scheduleRepository.CreateUpdateSchedule(scheduleDetailsDto);
                _response.Result = scheduleDt;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost("RemoveSchedule")]
        public async Task<object> RemoveSchedule( int ScheduleDetailsId)
        {
            try
            {
                bool isSuccess = await _scheduleRepository.RemoveSchedule(ScheduleDetailsId);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpGet]
        [Route("{date:DateTime}")]
        public async Task<object> Get(DateTime date)
        {
            try
            {
                IEnumerable<ScheduleDetailViewDto> scheduleDtos = await _scheduleRepository.GetScheduleByDate(date);
                _response.Result = scheduleDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };

            }
            return _response;
        }
        [HttpGet]
        [Route("{source}/{destination}")]
        public async Task<object> Get(string source,string destination)
        {
            try
            {
                IEnumerable<ScheduleDetailViewDto> scheduleDtos = await _scheduleRepository.GetScheduleBySourceDestination(source, destination);
                _response.Result = scheduleDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };

            }
            return _response;
        }
        [HttpGet]
        [Route("{source}/{destination}/{traveldate:Datetime}")]
        public async Task<object> Get(string source, string destination, DateTime traveldate)
        {
            try
            {
                IEnumerable<ScheduleDetailViewDto> scheduleDtos = await _scheduleRepository.GetScheduleBySDwithDate(source, destination,traveldate);
                _response.Result = scheduleDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };

            }
            return _response;
        }
    }
}
