using BookingSystem.Business.Interfaces.Strategies;
using BookingSystem.DataAccess.Interfaces.Clients;
using BookingSystem.DataAccess.Models;
using BookingSystem.Domain.DomainModels;
using BookingSystem.Domain.Enums;

namespace BookingSystem.Business.Implementation.Strategies
{
	public class HotelAndFlightSearchStrategy : ISearchStrategy
	{
		private readonly IHotelClient _hotelClient;
		private readonly IFlightClient _flightClient;

		public HotelAndFlightSearchStrategy(IHotelClient hotelClient, IFlightClient flightClient)
		{
			_hotelClient = hotelClient;
			_flightClient = flightClient;
		}

		public SearchTypeEnum Type
		{
			get { return SearchTypeEnum.HotelAndFlight; }
		}
		public async Task<List<Option>> ExecuteAsync(SearchCriteria criteria)
		{
			List<HotelApiResponse> hotels = await _hotelClient.SearchHotelsAsync(criteria.Destination);
			List<FlightApiResponse> flights = await _flightClient.SearchFlightsAsync(criteria.DepartureAirport!, criteria.Destination);

			int count = Math.Min(hotels.Count, flights.Count);
			List<Option> options = new List<Option>(count);

			for (int i = 0; i < count; i++)
			{
				double price = Random.Shared.Next(50, 301);


				Option option = new Option
				{
					OptionCode = Guid.NewGuid().ToString(),
					HotelCode = hotels[i].HotelCode.ToString(),
					FlightCode = flights[i].FlightCode.ToString(),
					ArrivalAirport = criteria.Destination,
					Price = price
				};

				options.Add(option);
			}

			return options;
		}
	}
}
