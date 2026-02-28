namespace BookingSystem.Domain.DomainModels
{
	/// <summary>
	/// Represents the search parameters used to find available booking options
	/// </summary>
	public class SearchCriteria
	{
		/// <summary>
		/// Destination location code
		/// </summary>
		public string Destination { get; set; }

		/// <summary>
		/// Departure airport code
		/// If not provided, only hotel options will be searched
		/// </summary>
		public string DepartureAirport { get; set; }

		/// <summary>
		/// Start date of the travel period
		/// </summary>
		public DateTime FromDate { get; set; }

		/// <summary>
		/// End date of the travel period
		/// </summary>
		public DateTime ToDate { get; set; }
	}
}