using BookingSystem.Business.Interfaces.Strategies;
using BookingSystem.Domain.DomainModels;

namespace BookingSystem.Business.Interfaces.Factories
{
	/// <summary>
	/// Represents a factory responsible for selecting the appropriate search strategy based on criteria
	/// </summary>
	public interface ISearchStrategyFactory
	{
		/// <summary>
		/// Returns the search strategy that matches the provided search criteria
		/// </summary>
		ISearchStrategy GetStrategy(SearchCriteria criteria);
	}
}
