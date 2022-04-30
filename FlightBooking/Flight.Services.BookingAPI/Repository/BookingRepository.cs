using AutoMapper;
using Flight.Services.BookingAPI.DbContexts;
using Flight.Services.BookingAPI.Models;
using Flight.Services.BookingAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.BookingAPI.Repository
{
    public class BookingRepository : IBookingRepository
    {

        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public BookingRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<BookingDto> CreateUpdateBooking(BookingDto bookingDto)
        {
            Booking booking = _mapper.Map<BookingDto, Booking>(bookingDto);
            var CreatedDateTemp = await _db.Bookings.Where(u => u.BookingId == booking.BookingId).Select(u => u.CreatedDate).SingleOrDefaultAsync();
            if (booking.BookingId > 0)
            {
                booking.IsActive = 'Y';
                booking.UpdatedDate = DateTime.Now;
                booking.CreatedDate = CreatedDateTemp;
                _db.Bookings.Update(booking);
            }
            else
            {
                booking.IsActive = 'Y';
                booking.CreatedDate = DateTime.Now;
                booking.UpdatedDate = DateTime.Now;
                _db.Bookings.Add(booking);

                //var bookingId = await _db.Bookings.Where(u => u.CreatedDate == booking.CreatedDate).Select(u => u.BookingId).SingleOrDefaultAsync();
                

            }
            await _db.SaveChangesAsync();

            return _mapper.Map<Booking, BookingDto >(booking);
        }

        public async Task<bool> DeleteBooking(int bookingId)
        {
            try
            {
                Booking booking = await _db.Bookings.FirstOrDefaultAsync(x => x.BookingId == bookingId);
                if (booking == null)
                {
                    return false;
                }

                //_db.Bookings.Remove(booking);
                booking.IsActive = 'N';
                await _db.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<BookingViewDto> GetBookingById(int bookingId)
        {
            Booking booking = //await _db.Bookings.Where(x => x.BookingId == bookingId).FirstOrDefaultAsync();
            await _db.Bookings
                           .Where(s => s.BookingId == bookingId)
                           .Include(s => s.Passenger)
                           .FirstOrDefaultAsync();
            return _mapper.Map<BookingViewDto>(booking);
        }

        public async Task<IEnumerable<BookingViewDto>> GetBookingByUserId(int userId)
        {
            //List<Booking> booking = await _db.Bookings.Where(x => x.UserId == userId).ToListAsync();
            List<Booking> store=await _db.Bookings
                           .Where(s => s.UserId == userId)
                           .Include(s => s.Passenger)
                           .ToListAsync();
            return _mapper.Map<List<BookingViewDto>>(store);
        }


        public async Task<IEnumerable<BookingViewDto>> GetBooking()
        {
            List<Booking> BookingList = await _db.Bookings.ToListAsync();
            return _mapper.Map<List<BookingViewDto>>(BookingList);
        }

        public async Task<BookingViewDto> GetBookingByemailId(string emailId)
        {
            Booking booking = await _db.Bookings.Where(x => x.EmailId == emailId).FirstOrDefaultAsync();
            return _mapper.Map<BookingViewDto>(booking);
        }
    }
}
