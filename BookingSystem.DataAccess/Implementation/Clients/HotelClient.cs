using BookingSystem.DataAccess.Interfaces.Clients;
using BookingSystem.DataAccess.Models;
using System.Net.Http.Json;

namespace BookingSystem.DataAccess.Implementation.Clients
{
	public class HotelClient : IHotelClient
	{
		private readonly HttpClient _http;

		public HotelClient(HttpClient http)
		{
			_http = http;
		}

		public async Task<List<HotelApiResponse>> SearchHotelsAsync(string destinationCode)
		{
			string url = "api/SearchHotels?destinationCode=" + Uri.EscapeDataString(destinationCode);

			List<HotelApiResponse>? result =
				await _http.GetFromJsonAsync<List<HotelApiResponse>>(url);

			return result ?? new List<HotelApiResponse>();
		}
	}
}
