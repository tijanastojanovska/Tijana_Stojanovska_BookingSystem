using BookingSystem.Domain.DomainModels;
using BookingSystem.Domain.Enums;

namespace BookingSystem.Business.Interfaces.Strategies
{
	public interface ISearchStrategy
	{
		SearchTypeEnum Type { get; }
		Task<List<Option>> SearchAsync(SearchCriteria criteria);
	}
}
