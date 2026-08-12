using _10Aug.Models;
using _10Aug.Repository;
using Microsoft.AspNetCore.Mvc;

namespace _10Aug.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService bookingService;

        public BookingController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        // GET: api/Booking
        [HttpGet]
        public ActionResult<List<Booking>> GetBookings()
        {
            return Ok(bookingService.GetBookings());
        }

        // GET: api/Booking/1
        [HttpGet("{id}")]
        public ActionResult<Booking> GetBookingById(int id)
        {
            var booking = bookingService.GetBookingById(id);

            if (booking == null)
                return NotFound("Booking not found");

            return Ok(booking);
        }

        // POST: api/Booking
        [HttpPost]
        public ActionResult<Booking> CreateBooking(Booking booking)
        {
            try
            {
                var createdBooking = bookingService.CreateBooking(booking);

                return Ok(createdBooking);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}