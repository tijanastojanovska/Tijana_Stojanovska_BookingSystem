using BookingSystem.Domain.DomainModels;
using BookingSystem.Domain.Enums;

namespace BookingSystem.Business.Interfaces.Strategies
{
	/// <summary>
	/// Represents a search strategy for handling different types of travel searches
	/// </summary>
	public interface ISearchStrategy
	{
		/// <summary>
		/// The type of search this strategy handles (e.g., HotelOnly, HotelAndFlight, LastMinuteHotels)
		/// </summary>
		SearchTypeEnum Type { get; }

		/// <summary>
		/// Executes the search based on the provided criteria and returns a list of options
		/// </summary>
		Task<List<Option>> SearchAsync(SearchCriteria criteria);
	}
}
