namespace BookingSystem.DTOs.Booking
{
	/// <summary>
	/// Represents the response returned after a booking is successfully created
	/// </summary>
	public class BookResponse
	{
		/// <summary>
		/// Generated unique booking code used to track the booking
		/// </summary>
		public string BookingCode { get; set; }

		/// <summary>
		/// Date and time when the booking was created
		/// </summary>
		public DateTime BookingTime { get; set; }
	}
}
