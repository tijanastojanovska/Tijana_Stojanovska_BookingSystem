using BookingSystem.DataAccess.Models;

namespace BookingSystem.DataAccess.Interfaces.Clients
{
	/// <summary>
	/// Defines the client for interacting with the external flight API
	/// </summary>
	public interface IFlightClient
	{
		/// <summary>
		/// Searches for available flights between the specified departure and arrival airports
		/// </summary>
		/// <param name="departureAirport">Code of the departure airport</param>
		/// <param name="arrivalAirport">Code of the arrival airport</param>
		/// <returns>A list of flight responses from the external API</returns>
		Task<List<FlightApiResponse>> SearchFlightsAsync(string departureAirport, string arrivalAirport);
	}
}
