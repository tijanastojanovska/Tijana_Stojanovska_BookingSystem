using BookingSystem.DTOs.Booking;

namespace BookingSystem.Business.Interfaces
{
	public interface IBookingService
	{
		BookResponse Book(BookRequest request);
		BookingStatusResponse CheckStatus(string bookingCode);
	}
}
