using BookingSystem.Business.Interfaces.Factories;
using BookingSystem.Business.Interfaces.Strategies;
using BookingSystem.Domain.DomainModels;
using BookingSystem.Domain.Enums;

namespace BookingSystem.Business.Implementation.Factories
{
	public class SearchStrategyFactory : ISearchStrategyFactory
	{
		private readonly IEnumerable<ISearchStrategy> _strategies;

		public SearchStrategyFactory(IEnumerable<ISearchStrategy> strategies)
		{
			_strategies = strategies;
		}

		public ISearchStrategy GetStrategy(SearchCriteria criteria)
		{
			bool isLastMinute = criteria.FromDate.Date <= DateTime.UtcNow.Date.AddDays(45);

			if (isLastMinute)
			{
				return _strategies.Single(s => s.Type == SearchTypeEnum.LastMinuteHotels);
			}

			if (!string.IsNullOrWhiteSpace(criteria.DepartureAirport))
			{
				return _strategies.Single(s => s.Type == SearchTypeEnum.HotelAndFlight);
			}

			return _strategies.Single(s => s.Type == SearchTypeEnum.HotelOnly);
		}
	}
}
