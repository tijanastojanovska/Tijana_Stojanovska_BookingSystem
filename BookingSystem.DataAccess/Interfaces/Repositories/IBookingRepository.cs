using BookingSystem.Domain.DomainModels;

namespace BookingSystem.DataAccess.Interfaces.Repositories
{
	/// <summary>
	/// Represents the repository responsible for storing and retrieving booking records in memory
	/// </summary>
	public interface IBookingRepository
	{
		/// <summary>
		/// Saves a booking entity
		/// </summary>
		void Save(Booking booking);

		/// <summary>
		/// Retrieves a booking entity by its booking code
		/// </summary>
		Booking? Get(string bookingCode);
	}
}
