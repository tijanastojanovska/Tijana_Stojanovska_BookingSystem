namespace BookingSystem.DTOs.Booking
{
	/// <summary>
	/// Represents the request model used to create a booking
	/// </summary>
	public class BookRequest
	{
		/// <summary>
		/// Unique code of the selected search option
		/// </summary>
		public string OptionCode { get; set; }
	}
}
