namespace BookingSystem.DTOs.Auth
{
	/// <summary>
	/// Represents the data required to authenticate a user in the system
	/// </summary>
	public class LoginRequest
	{
		/// <summary>
		/// Username used to identify the user
		/// </summary>
		public string Username { get; set; }

		/// <summary>
		/// Password associated with the user account
		/// </summary>
		public string Password { get; set; }
	}
}