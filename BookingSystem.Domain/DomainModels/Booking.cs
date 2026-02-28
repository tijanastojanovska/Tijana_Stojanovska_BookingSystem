using BookingSystem.Domain.Enums;

namespace BookingSystem.Domain.DomainModels
{
	/// <summary>
	/// Represents a booking created for a selected search option
	/// </summary>
	public class Booking
	{
		/// <summary>
		/// Unique 6-character alphanumeric code identifying the booking
		/// </summary>
		public string BookingCode { get; set; }

		/// <summary>
		/// The option code selected during the search process
		/// </summary>
		public string OptionCode { get; set; }

		/// <summary>
		/// Date and time when the booking was created
		/// </summary>
		public DateTime BookingTime { get; set; }

		/// <summary>
		/// Artificial processing time in seconds used to simulate booking completion
		/// </summary>
		public int SleepTime { get; set; }

		/// <summary>
		/// Indicates the type of search that produced this booking
		/// </summary>
		public SearchTypeEnum SearchType { get; set; }
	}
}