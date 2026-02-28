using BookingSystem.DTOs.Booking;

namespace BookingSystem.Business.Interfaces
{
	/// <summary>
	/// Represents the service responsible for handling booking operations
	/// </summary>
	public interface IBookingService
	{
		/// <summary>
		/// Creates a new booking based on the provided request
		/// </summary>
		BookResponse Book(BookRequest request);

		/// <summary>
		/// Checks the current status of a booking using its booking code
		/// </summary>
		BookingStatusResponse CheckStatus(string bookingCode);
	}
}
