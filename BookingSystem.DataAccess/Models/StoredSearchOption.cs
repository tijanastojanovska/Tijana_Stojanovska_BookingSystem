using BookingSystem.Domain.DomainModels;
using BookingSystem.Domain.Enums;

namespace BookingSystem.DataAccess.Models
{
	public class StoredSearchOption
	{
		public Option Option { get; set; }
		public SearchTypeEnum SearchType { get; set; }
	}
}
