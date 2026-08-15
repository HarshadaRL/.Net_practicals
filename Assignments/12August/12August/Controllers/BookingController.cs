using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _12Aug.Data;
using _12Aug.DTOs;
using _12Aug.Models;

namespace _12Aug.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly AppDbContext context;

        public BookingController(AppDbContext context)
        {
            this.context = context;
        }

        // POST: api/Booking
        // Book one or more rooms
        [HttpPost]
        public async Task<IActionResult> CreateBooking(
            BookingRequest request)
        {
            // Validate dates
            if (request.Checkin >= request.Checkout)
            {
                return BadRequest(
                    "Checkout must be after checkin");
            }

            // Validate room list
            if (request.RoomIds == null ||
                request.RoomIds.Count == 0)
            {
                return BadRequest(
                    "Select at least one room");
            }

            // Remove duplicate room IDs
            var roomIds = request.RoomIds
                .Distinct()
                .ToList();

            // Check customer
            var customer = await context.Customers
                .FindAsync(request.CustomerId);

            if (customer == null)
            {
                return NotFound("Customer not found");
            }

            // Get rooms
            var rooms = await context.Rooms
                .Where(r => roomIds.Contains(r.Id))
                .ToListAsync();

            if (rooms.Count != roomIds.Count)
            {
                return BadRequest(
                    "One or more rooms do not exist");
            }

            // Check room availability
            var unavailableRooms = await context.BookingRooms
                .Where(br =>
                    roomIds.Contains(br.RoomId) &&
                    br.Booking!.Status == "Confirmed" &&
                    br.Booking.Checkin < request.Checkout &&
                    br.Booking.Checkout > request.Checkin
                )
                .Select(br => br.RoomId)
                .Distinct()
                .ToListAsync();

            if (unavailableRooms.Count > 0)
            {
                return BadRequest(new
                {
                    message = "Some rooms are already booked",
                    unavailableRooms
                });
            }

            // Calculate total
            decimal totalAmount = rooms.Sum(r => r.Price);

            // Create Booking
            var booking = new Booking
            {
                CustomerId = request.CustomerId,
                Checkin = request.Checkin,
                Checkout = request.Checkout,
                TotalAmt = totalAmount,
                Status = "Confirmed"
            };

            context.Bookings.Add(booking);

            await context.SaveChangesAsync();

            // Add rooms to BookingRoom
            foreach (var room in rooms)
            {
                var bookingRoom = new BookingRoom
                {
                    BookingId = booking.Id,
                    RoomId = room.Id,
                    Price = room.Price
                };

                context.BookingRooms.Add(bookingRoom);
            }

            await context.SaveChangesAsync();

            return Ok(new
            {
                message = "Booking successful",
                bookingId = booking.Id,
                customerId = booking.CustomerId,
                checkin = booking.Checkin,
                checkout = booking.Checkout,
                totalAmount = booking.TotalAmt,
                status = booking.Status,
                roomIds = roomIds
            });
        }

        // GET:
        // api/Booking/customer/1
        // View customer's bookings
        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetCustomerBookings(
            int customerId)
        {
            var customer = await context.Customers
                .FindAsync(customerId);

            if (customer == null)
            {
                return NotFound("Customer not found");
            }

            var bookings = await context.Bookings
                .Where(b => b.CustomerId == customerId)
                .Include(b => b.Customer)
                .Include(b => b.BookingRooms)
                    .ThenInclude(br => br.Room)
                        .ThenInclude(r => r!.Hotel)
                .Select(b => new
                {
                    b.Id,
                    b.Checkin,
                    b.Checkout,
                    b.TotalAmt,
                    b.Status,

                    Customer = new
                    {
                        b.Customer!.Id,
                        b.Customer.Name,
                        b.Customer.Email
                    },

                    Rooms = b.BookingRooms.Select(br => new
                    {
                        br.RoomId,
                        br.Price,
                        RoomNumber = br.Room!.RoomNumber,
                        RoomType = br.Room.RoomType,

                        Hotel = new
                        {
                            br.Room.Hotel!.Id,
                            br.Room.Hotel.Name,
                            br.Room.Hotel.City
                        }
                    })
                })
                .ToListAsync();

            return Ok(bookings);
        }

        // GET: api/Booking/1
        // View one booking
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooking(int id)
        {
            var booking = await context.Bookings
                .Where(b => b.Id == id)
                .Include(b => b.Customer)
                .Include(b => b.BookingRooms)
                    .ThenInclude(br => br.Room)
                        .ThenInclude(r => r!.Hotel)
                .Select(b => new
                {
                    b.Id,
                    b.Checkin,
                    b.Checkout,
                    b.TotalAmt,
                    b.Status,

                    Customer = new
                    {
                        b.Customer!.Id,
                        b.Customer.Name,
                        b.Customer.Email
                    },

                    Rooms = b.BookingRooms.Select(br => new
                    {
                        br.RoomId,
                        br.Price,
                        br.Room!.RoomNumber,
                        br.Room.RoomType,

                        Hotel = new
                        {
                            br.Room.Hotel!.Id,
                            br.Room.Hotel.Name,
                            br.Room.Hotel.City
                        }
                    })
                })
                .FirstOrDefaultAsync();

            if (booking == null)
            {
                return NotFound("Booking not found");
            }

            return Ok(booking);
        }
    }
}