using BookingSystem.Domain.DomainModels;
using BookingSystem.Domain.Enums;

namespace BookingSystem.DataAccess.Interfaces.Repositories
{
	public interface ISearchRepository
	{
		void Save(SearchTypeEnum searchType, List<Option> options);
	}
}
