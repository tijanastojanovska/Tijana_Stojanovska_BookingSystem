using BookingSystem.Domain.DomainModels;
using BookingSystem.DTOs.Search;

namespace BookingSystem.Business.Mappers
{
	/// <summary>
	/// Provides extension methods for mapping Option entities to search-related DTOs
	/// </summary>
	public static class SearchMappings
	{
		/// <summary>
		/// Maps a single Option entity to a SearchOptionResponse DTO
		/// </summary>
		public static SearchOptionResponse ToResponse(this Option option)
		{
			SearchOptionResponse dto = new SearchOptionResponse
			{
				OptionCode = option.OptionCode,
				HotelCode = option.HotelCode,
				FlightCode = option.FlightCode,
				ArrivalAirport = option.ArrivalAirport,
				Price = option.Price
			};

			return dto;
		}

		/// <summary>
		/// Maps a list of Option entities to a SearchResponse DTO
		/// </summary>
		public static SearchResponse ToResponse(this List<Option> options)
		{
			SearchResponse response = new SearchResponse
			{
				Options = options.Select(o => o.ToResponse()).ToList()
			};
			return response;
		}
	}
}
