using _10Aug.Data;
using _10Aug.Models;
using _10Aug.Repository;

namespace _10Aug.Services
{
    public class BookingService : IBookingService
    {
        private readonly AppDbContext context;

        public BookingService(AppDbContext context)
        {
            this.context = context;
        }

        public Booking CreateBooking(Booking booking)
        {
            if (booking.TravelDate.Date < DateTime.UtcNow.Date)
                throw new ArgumentException("Travel Date cannot be in the past");

            var bus = context.Buses.FirstOrDefault(b => b.Id == booking.BusId);

            if (bus == null)
                throw new ArgumentException("Invalid bus");

            if (booking.SeatNumber < 1 || booking.SeatNumber > bus.TotalSeats)
                throw new ArgumentException("Seat number must be between 1 and " + bus.TotalSeats);

            var state = context.States.FirstOrDefault(s => s.Id == booking.StateId);

            if (state == null)
                throw new ArgumentException("Invalid destination state");

            var seatAlreadyBooked = context.Bookings.Any(b =>
                b.BusId == booking.BusId &&
                b.TravelDate == booking.TravelDate &&
                b.SeatNumber == booking.SeatNumber);

            if (seatAlreadyBooked)
                throw new ArgumentException(
                    "This seat is already booked for the selected date");

            context.Bookings.Add(booking);
            context.SaveChanges();

            return booking;
        }

        public Booking? GetBookingById(int id)
        {
            return context.Bookings.FirstOrDefault(b => b.Id == id);
        }

        public List<Booking> GetBookings()
        {
            return context.Bookings.ToList();
        }
    }
}