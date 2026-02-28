namespace BookingSystem.Domain.DomainModels
{
	/// <summary>
	/// Represents a single booking option returned as a result of a search operation
	/// </summary>
	public class Option
	{
		/// <summary>
		/// Unique identifier of the option, generated during the search process
		/// </summary>
		public string OptionCode { get; set; }

		/// <summary>
		/// Identifier of the hotel provided by the external hotel API
		/// </summary>
		public string HotelCode { get; set; }

		/// <summary>
		/// Identifier of the flight provided by the external flight API
		/// Null if the option does not include a flight
		/// </summary>
		public string? FlightCode { get; set; }

		/// <summary>
		/// Code of the arrival airport
		/// </summary>
		public string ArrivalAirport { get; set; }

		/// <summary>
		/// Total price of the option
		/// </summary>
		public double Price { get; set; }
	}
}