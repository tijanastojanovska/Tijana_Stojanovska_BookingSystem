using BookingSystem.DataAccess.Models;

namespace BookingSystem.DataAccess.Interfaces.Clients
{
	/// <summary>
	/// Defines the client for interacting with the external hotel API
	/// </summary>
	public interface IHotelClient
	{
		/// <summary>
		/// Searches for available hotels at the specified destination
		/// </summary>
		/// <param name="destinationCode">Destination code (e.g., SKP, BCN, DXB)</param>
		/// <returns>A list of hotel responses from the external API</returns>
		Task<List<HotelApiResponse>> SearchHotelsAsync(string destinationCode);
	}
}
