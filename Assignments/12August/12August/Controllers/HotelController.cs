using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _12Aug.Data;
using _12Aug.Models;

namespace _12Aug.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly AppDbContext context;

        public HotelController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/Hotel
        // View all hotels
        [HttpGet]
        public async Task<IActionResult> GetHotels()
        {
            var hotels = await context.Hotels
                .Include(h => h.Rooms)
                .ToListAsync();

            return Ok(hotels);
        }

        // GET: api/Hotel/1
        // View rooms inside a hotel
        [HttpGet("{hotelId}/rooms")]
        public async Task<IActionResult> GetRooms(int hotelId)
        {
            var hotel = await context.Hotels
                .FirstOrDefaultAsync(h => h.Id == hotelId);

            if (hotel == null)
            {
                return NotFound("Hotel not found");
            }

            var rooms = await context.Rooms
                .Where(r => r.HotelId == hotelId)
                .ToListAsync();

            return Ok(rooms);
        }

        // GET:
        // api/Hotel/1/available-rooms?checkin=2026-08-20&checkout=2026-08-23
        [HttpGet("{hotelId}/available-rooms")]
        public async Task<IActionResult> GetAvailableRooms(
            int hotelId,
            DateTime checkin,
            DateTime checkout)
        {
            if (checkin >= checkout)
            {
                return BadRequest(
                    "Checkout must be after checkin");
            }

            var hotelExists = await context.Hotels
                .AnyAsync(h => h.Id == hotelId);

            if (!hotelExists)
            {
                return NotFound("Hotel not found");
            }

            var rooms = await context.Rooms
                .Where(r => r.HotelId == hotelId)
                .Where(r =>
                    !r.BookingRooms.Any(br =>
                        br.Booking!.Status == "Confirmed" &&
                        br.Booking.Checkin < checkout &&
                        br.Booking.Checkout > checkin
                    )
                )
                .ToListAsync();

            return Ok(rooms);
        }
    }
}