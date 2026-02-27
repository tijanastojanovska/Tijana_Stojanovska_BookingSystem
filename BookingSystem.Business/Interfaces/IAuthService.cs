using BookingSystem.DTOs.Auth;

namespace BookingSystem.Business.Interfaces
{
	public interface IAuthService
	{
		LoginResponse Login(LoginRequest request);
	}
}
