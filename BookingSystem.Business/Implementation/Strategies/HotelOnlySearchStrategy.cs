using BookingSystem.Business.Interfaces.Strategies;
using BookingSystem.DataAccess.Interfaces.Clients;
using BookingSystem.DataAccess.Models;
using BookingSystem.Domain.DomainModels;
using BookingSystem.Domain.Enums;

namespace BookingSystem.Business.Implementation.Strategies
{
	public class HotelOnlySearchStrategy : ISearchStrategy
	{
		private readonly IHotelClient _hotelClient;

		public HotelOnlySearchStrategy(IHotelClient hotelClient)
		{
			_hotelClient = hotelClient;
		}

		public SearchTypeEnum Type
		{
			get { return SearchTypeEnum.HotelOnly; }
		}

		public async Task<List<Option>> SearchAsync(SearchCriteria criteria)
		{
			List<HotelApiResponse> hotels = await _hotelClient.SearchHotelsAsync(criteria.Destination);

			List<Option> options = new List<Option>();

			foreach (HotelApiResponse h in hotels)
			{
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
