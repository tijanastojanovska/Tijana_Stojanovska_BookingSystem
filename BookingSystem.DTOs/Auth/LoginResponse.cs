namespace BookingSystem.DTOs.Auth
{
	/// <summary>
	/// Represents the result of a successful authentication request
	/// </summary>
	public class LoginResponse
	{
		/// <summary>
		/// Authentication token used to authorize subsequent requests
		/// </summary>
		public string Token { get; set; }
	}
}