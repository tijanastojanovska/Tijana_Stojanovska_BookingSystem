using BookingSystem.DTOs.Auth;

namespace BookingSystem.Business.Interfaces
{
	/// <summary>
	/// Represents the service responsible for handling user authentication
	/// </summary>
	public interface IAuthService
	{
		/// <summary>
		/// Authenticates a user based on login request data and returns a login response
		/// </summary>
		LoginResponse Login(LoginRequest request);
	}
}
