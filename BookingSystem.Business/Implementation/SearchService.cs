using BookingSystem.Business.Interfaces;
using BookingSystem.Business.Interfaces.Factories;
using BookingSystem.Business.Mappers;
using BookingSystem.DataAccess.Interfaces.Repositories;
using BookingSystem.Domain.DomainModels;
using BookingSystem.DTOs.Search;


namespace BookingSystem.Business.Implementation
{
	public class SearchService : ISearchService
	{
		private readonly ISearchStrategyFactory _searchFactory;
		private readonly ISearchRepository _searchRepository;

		public SearchService(ISearchStrategyFactory searchFactory, ISearchRepository searchRepository)
		{
			_searchFactory = searchFactory;
			_searchRepository = searchRepository;
		}

		public async Task<SearchResponse> SearchAsync(SearchRequest request)
		{
			Validate(request);

			SearchCriteria criteria = new SearchCriteria
			{
				Destination = request.Destination,
				DepartureAirport = request.DepartureAirport,
				FromDate = request.FromDate,
				ToDate = request.ToDate
			};

			var strategy = _searchFactory.GetStrategy(criteria);

			var options = await strategy.ExecuteAsync(criteria);

			_searchRepository
				
				
				
				.Save(strategy.Type, options);


			SearchResponse response = options.ToResponse();

			return response;
		}

		private void Validate(SearchRequest request)
		{
			if (request == null)
			{
				throw new ArgumentException("Request is required.");
			}

			if (string.IsNullOrWhiteSpace(request.Destination))
			{
				throw new ArgumentException("Destination is required.");
			}

			if (request.FromDate >= request.ToDate)
			{
				throw new ArgumentException("FromDate must be before ToDate.");
			}
		}
	}
}
