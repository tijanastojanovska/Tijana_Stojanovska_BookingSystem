namespace BookingSystem.Domain.Enums
{
	/// <summary>
	/// Represents the type of search to be performed based on the provided search criteria
	/// </summary>
	public enum SearchTypeEnum
	{
		/// <summary>
		/// Search for hotel accommodation only without flights
		/// </summary>
		HotelOnly,

		/// <summary>
		/// Search for combined hotel and flight options
		/// </summary>
		HotelAndFlight,

		/// <summary>
		/// Search for last-minute hotel offers when the travel date is within the defined last-minute period
		/// </summary>
		LastMinuteHotels
	}
}