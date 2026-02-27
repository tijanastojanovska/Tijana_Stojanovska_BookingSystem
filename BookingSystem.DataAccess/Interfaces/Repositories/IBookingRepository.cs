using BookingSystem.Domain.DomainModels;

namespace BookingSystem.DataAccess.Interfaces.Repositories
{
	public interface IBookingRepository
	{
		void Save(Booking booking);
		Booking? Get(string bookingCode);
	}
}
