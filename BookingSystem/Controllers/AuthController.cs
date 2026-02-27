using BookingSystem.Business.Interfaces;
using BookingSystem.DTOs.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuthService _authService;

		public AuthController(IAuthService authService)
		{
			_authService = authService;
		}

		[AllowAnonymous]
		[HttpPost("login")]
		public ActionResult<LoginResponse> Login([FromBody] LoginRequest request)
		{
			return Ok(_authService.Login(request));
		}
	}
}
