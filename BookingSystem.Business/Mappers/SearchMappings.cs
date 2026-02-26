using BookingSystem.Domain.DomainModels;
using BookingSystem.DTOs.Search;

namespace BookingSystem.Business.Mappers
{
	public static class SearchMappings
	{
		public static SearchOptionResponse ToResponse(this Option option)
		{
			SearchOptionResponse dto = new SearchOptionResponse();
			dto.OptionCode = option.OptionCode;
			dto.HotelCode = option.HotelCode;
			dto.FlightCode = option.FlightCode;
			dto.ArrivalAirport = option.ArrivalAirport;
			dto.Price = option.Price;

			return dto;
		}

		public static SearchResponse ToResponse(this List<Option> options)
		{
			SearchResponse response = new SearchResponse();
			response.Options = options.Select(o => o.ToResponse()).ToList();
			return response;
		}
	}
}
