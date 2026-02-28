namespace BookingSystem.DTOs.Search
{
	/// <summary>
	/// Represents the request model used to search for available travel options
	/// </summary>
	public class SearchRequest
	{
		/// <summary>
		/// Destination code where the user wants to travel
		/// </summary>
		public string Destination { get; set; }

		/// <summary>
		/// Departure airport code for flight searches
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
