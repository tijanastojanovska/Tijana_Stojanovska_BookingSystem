using BookingSystem.Domain.Enums;

namespace BookingSystem.DTOs.Booking
{
	/// <summary>
	/// Represents the response returned when checking the status of a booking
	/// </summary>
	public class BookingStatusResponse
	{
		/// <summary>
		/// Current status of the booking
		/// </summary>
		public BookingStatusEnum Status { get; set; }
	}
}