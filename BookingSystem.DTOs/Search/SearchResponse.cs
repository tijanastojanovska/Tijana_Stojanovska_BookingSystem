namespace BookingSystem.DTOs.Search
{
	/// <summary>
	/// Represents the response returned after performing a search for travel options
	/// </summary>
	public class SearchResponse
	{
		/// <summary>
		/// Collection of available travel options matching the search criteria
		/// </summary>
		public List<SearchOptionResponse> Options { get; set; }
	}
}
