namespace BookingSystem.Domain.Enums
{
	/// <summary>
	/// Represents the current processing status of a booking
	/// </summary>
	public enum BookingStatusEnum
	{
		/// <summary>
		/// The booking is still being processed and not yet completed
		/// </summary>
		Pending,

		/// <summary>
		/// The booking has been successfully completed
		/// </summary>
		Success,

		/// <summary>
		/// The booking processing has failed
		/// </summary>
		Failed
	}
}