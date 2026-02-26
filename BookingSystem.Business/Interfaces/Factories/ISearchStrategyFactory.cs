using BookingSystem.Business.Interfaces.Strategies;
using BookingSystem.Domain.DomainModels;

namespace BookingSystem.Business.Interfaces.Factories
{
	public interface ISearchStrategyFactory
	{
		ISearchStrategy GetStrategy(SearchCriteria criteria);
	}
}
