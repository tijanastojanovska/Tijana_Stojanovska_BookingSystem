using BookingSystem.Domain.DomainModels;
using BookingSystem.Domain.Enums;

namespace BookingSystem.DataAccess.Models
{
	/// <summary>
	/// Represents a search option stored in memory along with its search type
	/// </summary>
	public class StoredSearchOption
	{
		/// <summary>
		/// The option details
		/// </summary>
		public Option Option { get; set; }

		/// <summary>
		/// Type of search that generated this option
		/// </summary>
		public SearchTypeEnum SearchType { get; set; }
	}
}
