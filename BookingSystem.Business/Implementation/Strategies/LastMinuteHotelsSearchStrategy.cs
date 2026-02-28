using BookingSystem.Business.Interfaces.Strategies;
using BookingSystem.DataAccess.Interfaces.Clients;
using BookingSystem.DataAccess.Models;
using BookingSystem.Domain.DomainModels;
using BookingSystem.Domain.Enums;

namespace BookingSystem.Business.Implementation.Strategies
{
	public class LastMinuteHotelsSearchStrategy : ISearchStrategy
	{
		private readonly IHotelClient _hotelClient;

		public LastMinuteHotelsSearchStrategy(IHotelClient hotelClient)
		{
			_hotelClient = hotelClient;
		}
		public SearchTypeEnum Type
		{
			get { return SearchTypeEnum.LastMinuteHotels; }
		}
		public async Task<List<Option>> SearchAsync(SearchCriteria criteria)
		{
			List<HotelApiResponse> hotels = await _hotelClient.SearchHotelsAsync(criteria.Destination);

			List<Option> options = new List<Option>();

			foreach (HotelApiResponse h in hotels)
			{
				//price is calculated as a random number, because the response in both apis did not have a price
				double price = Random.Shared.Next(50, 301);

				Option option = new Option
				{
					OptionCode = Guid.NewGuid().ToString(),
					HotelCode = h.HotelCode.ToString(),
					FlightCode = "",
					ArrivalAirport = criteria.Destination,
					Price = price
				};

				options.Add(option);
			}

			return options;
		}
	}
}
