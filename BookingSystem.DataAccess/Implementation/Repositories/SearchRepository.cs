using BookingSystem.DataAccess.Interfaces.Repositories;
using BookingSystem.DataAccess.Models;
using BookingSystem.Domain.DomainModels;
using BookingSystem.Domain.Enums;
using System.Collections.Concurrent;

namespace BookingSystem.DataAccess.Implementation.Repositories
{
	public class SearchRepository : ISearchRepository
	{
		private readonly ConcurrentDictionary<string, StoredSearchOption> _storage;

		public SearchRepository()
		{
			_storage = new ConcurrentDictionary<string, StoredSearchOption>();
		}

		public void Save(SearchTypeEnum searchType, List<Option> options)
		{
			foreach (Option option in options)
			{
				StoredSearchOption stored = new StoredSearchOption();
				stored.Option = option;
				stored.SearchType = searchType;

				_storage[option.OptionCode] = stored;
			}
		}
	}
}
