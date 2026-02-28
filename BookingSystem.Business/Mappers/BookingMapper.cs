using BookingSystem.Domain.DomainModels;
using BookingSystem.DTOs.Booking;

namespace BookingSystem.Business.Mappers
{
	/// <summary>
	/// Provides extension methods for mapping booking entities to DTOs
	/// </summary>
	public static class BookingMapper
	{
		/// <summary>
		/// Maps a Booking entity to a BookResponse DTO
		/// </summary>
		public static BookResponse ToBookResponse(this Booking booking)
		{
			BookResponse response = new BookResponse
			{
				BookingCode = booking.BookingCode,
				BookingTime = booking.BookingTime
			};

			return response;
		}
	}
}
