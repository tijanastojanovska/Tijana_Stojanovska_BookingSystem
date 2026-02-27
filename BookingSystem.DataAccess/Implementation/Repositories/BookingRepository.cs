using BookingSystem.DataAccess.Interfaces.Repositories;
using BookingSystem.Domain.DomainModels;
using System.Collections.Concurrent;

namespace BookingSystem.DataAccess.Implementation.Repositories
{
	public class BookingRepository : IBookingRepository
	{
		private readonly ConcurrentDictionary<string, Booking> _storage;

		public BookingRepository()
		{
			_storage = new ConcurrentDictionary<string, Booking>();
		}

		public void Save(Booking booking)
		{
			_storage[booking.BookingCode] = booking;
		}

		public Booking? Get(string bookingCode)
		{
			Booking? booking;

			if (_storage.TryGetValue(bookingCode, out booking))
			{
				return booking;
			}

			return null;
		}
	}
}
