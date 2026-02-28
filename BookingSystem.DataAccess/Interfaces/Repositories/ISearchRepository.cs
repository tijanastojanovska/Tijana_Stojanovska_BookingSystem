using BookingSystem.Domain.DomainModels;
using BookingSystem.Domain.Enums;

namespace BookingSystem.DataAccess.Interfaces.Repositories
{
	/// <summary>
	/// Represents the repository responsible for storing and retrieving search options in memory
	/// </summary>
	public interface ISearchRepository
	{
		/// <summary>
		/// Saves a list of search options in memory under the specified search type
		/// </summary>
		void SaveInMemory(SearchTypeEnum searchType, List<Option> options);

		/// <summary>
		/// Retrieves a search option by its unique option code
		/// </summary>
		Option? GetOption(string optionCode);

		/// <summary>
		/// Retrieves the search type associated with a specific option code
		/// </summary>
		SearchTypeEnum? GetSearchType(string optionCode);
	}
}
