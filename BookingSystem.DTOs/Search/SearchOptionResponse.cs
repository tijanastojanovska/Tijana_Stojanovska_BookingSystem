namespace BookingSystem.DTOs.Search
{
	/// <summary>
	/// Represents a single search option returned to the client
	/// </summary>
	public class SearchOptionResponse
	{
		/// <summary>
		/// Unique identifier for the search option
		/// </summary>
		public string OptionCode { get; set; }

		/// <summary>
		/// Identifier of the hotel included in the option
		/// </summary>
		public string HotelCode { get; set; }

		/// <summary>
		/// Identifier of the flight included in the option if applicable
		/// </summary>
		public string? FlightCode { get; set; }

		/// <summary>
		/// Destination airport code for the option
		/// </summary>
		public string ArrivalAirport { get; set; }

		/// <summary>
		/// Total price of the option
		/// </summary>
		public double Price { get; set; }
	}
}
