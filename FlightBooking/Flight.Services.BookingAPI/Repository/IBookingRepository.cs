using Flight.Services.BookingAPI.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.BookingAPI.Repository
{
    public interface IBookingRepository
    {
        Task<IEnumerable<BookingViewDto>> GetBooking();
        Task<BookingViewDto> GetBookingById(int bookingId);
        Task<IEnumerable<BookingViewDto>> GetBookingByUserId(int userId);
        Task<BookingViewDto> GetBookingByemailId(string emailId);
        Task<BookingDto> CreateUpdateBooking(BookingDto bookingDto);
        Task<bool> DeleteBooking(int bookingId);
    }
}
