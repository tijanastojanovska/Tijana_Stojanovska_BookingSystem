using BookingSystem.DataAccess.Models;

namespace BookingSystem.DataAccess.Interfaces.Clients
{
	public interface IFlightClient
	{
		Task<List<FlightApiResponse>> SearchFlightsAsync(string departureAirport, string arrivalAirport);
	}
}
