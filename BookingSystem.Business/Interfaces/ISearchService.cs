using BookingSystem.DTOs.Search;

namespace BookingSystem.Business.Interfaces
{
	/// <summary>
	/// Represents the service responsible for handling travel search operations
	/// </summary>
	public interface ISearchService
	{
		/// <summary>
		/// Performs a search for available travel options based on the request
		/// </summary>
		Task<SearchResponse> SearchAsync(SearchRequest request);
	}
}
