using BookingSystem.Domain.DomainModels;
using BookingSystem.DTOs.Booking;

namespace BookingSystem.Business.Mappers
{
	public static class BookingMapper
	{
		public static BookResponse ToBookResponse(this Booking booking)
		{
			BookResponse response = new BookResponse();
			response.BookingCode = booking.BookingCode;
			response.BookingTime = booking.BookingTime;

			return response;
		}
	}
}
