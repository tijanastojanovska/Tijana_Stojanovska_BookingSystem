using BookingSystem.Business.Interfaces;
using BookingSystem.DTOs.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers
{
	/// <summary>
    /// API controller responsible for handling user authentication requests
    /// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuthService _authService;

		/// <summary>
		/// Initializes a new instance of the AuthController with the provided authentication service
		/// </summary>
		public AuthController(IAuthService authService)
		{
			_authService = authService;
		}

		/// <summary>
		/// Authenticates a user and returns a login response
		/// </summary>
		[AllowAnonymous]
		[HttpPost("login")]
		public ActionResult<LoginResponse> Login([FromBody] LoginRequest request)
		{
			return Ok(_authService.Login(request));
		}
	}
}
