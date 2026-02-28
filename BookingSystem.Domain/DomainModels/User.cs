namespace BookingSystem.Domain.DomainModels
{
	/// <summary>
	/// Represents a system user who can access and interact with the booking system
	/// </summary>
	public class User
	{
		/// <summary>
		/// Unique identifier of the user
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Username used for login and identification
		/// </summary>
		public string Username { get; set; }

		/// <summary>
		/// User password used for authentication
		/// </summary>
		public string Password { get; set; }
	}
}