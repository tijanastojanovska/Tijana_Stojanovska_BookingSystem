using BookingSystem.DataAccess.Interfaces.Clients;
using BookingSystem.DataAccess.Models;
using System.Net.Http.Json;

namespace BookingSystem.DataAccess.Implementation.Clients
{
	public class FlightClient : IFlightClient
	{
		private readonly HttpClient _http;
		public FlightClient(HttpClient http) => _http = http;

		public async Task<List<FlightApiResponse>> SearchFlightsAsync(string departureAirport, string arrivalAirport)
		{
			string url =
				"api/SearchFlights?departureAirport=" + Uri.EscapeDataString(departureAirport) +
				"&arrivalAirport=" + Uri.EscapeDataString(arrivalAirport);

			List<FlightApiResponse>? result = await _http.GetFromJsonAsync<List<FlightApiResponse>>(url);
			return result ?? new List<FlightApiResponse>();
		}
	}
}
