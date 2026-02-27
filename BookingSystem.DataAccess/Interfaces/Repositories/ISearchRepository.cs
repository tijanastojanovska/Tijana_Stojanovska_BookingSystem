using BookingSystem.Domain.DomainModels;
using BookingSystem.Domain.Enums;

namespace BookingSystem.DataAccess.Interfaces.Repositories
{
	public interface ISearchRepository
	{
		void SaveInMemory(SearchTypeEnum searchType, List<Option> options);
		Option? GetOption(string optionCode);
		SearchTypeEnum? GetSearchType(string optionCode);
	}
}
