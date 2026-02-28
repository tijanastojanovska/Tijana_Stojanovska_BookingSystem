namespace BookingSystem.DataAccess.Models
{
	/// <summary>
	/// Represents the response model received from the external hotel API
	/// </summary>
	public class HotelApiResponse
	{
		/// <summary>
		/// Identifier of the hotel record
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Unique code identifying the hotel
		/// </summary>
		public int HotelCode { get; set; }

		/// <summary>
		/// Name of the hotel
		/// </summary>
		public string HotelName { get; set; }

		/// <summary>
		/// Destination code associated with the hotel
		/// </summary>
		public string DestinationCode { get; set; }

		/// <summary>
		/// City where the hotel is located
		/// </summary>
		public string City { get; set; }
	}
}
