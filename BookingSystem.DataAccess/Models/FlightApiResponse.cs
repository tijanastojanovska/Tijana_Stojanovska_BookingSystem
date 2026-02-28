namespace BookingSystem.DataAccess.Models
{
	/// <summary>
	/// Represents the response model received from the external flight API
	/// </summary>
	public class FlightApiResponse
	{
		/// <summary>
		/// Unique identifier of the flight
		/// </summary>
		public int FlightCode { get; set; }

		/// <summary>
		/// Flight number assigned by the airline
		/// </summary>
		public string FlightNumber { get; set; }

		/// <summary>
		/// Departure airport code
		/// </summary>
		public string DepartureAirport { get; set; }

		/// <summary>
		/// Arrival airport code
		/// </summary>
		public string ArrivalAirport { get; set; }
	}
}
