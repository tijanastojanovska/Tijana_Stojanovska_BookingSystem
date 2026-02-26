using BookingSystem.DTOs.Search;

namespace BookingSystem.Business.Interfaces
{
	public interface ISearchService
	{
		Task<SearchResponse> SearchAsync(SearchRequest request);
	}
}
