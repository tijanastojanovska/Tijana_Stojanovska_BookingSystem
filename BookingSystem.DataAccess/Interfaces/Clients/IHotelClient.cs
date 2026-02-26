using BookingSystem.DataAccess.Models;

namespace BookingSystem.DataAccess.Interfaces.Clients
{
	public interface IHotelClient
	{
		Task<List<HotelApiResponse>> SearchHotelsAsync(string destinationCode);
	}
}
