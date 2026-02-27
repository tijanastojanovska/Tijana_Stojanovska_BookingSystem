using BookingSystem.Business.Interfaces;
using BookingSystem.DataAccess.Interfaces.Repositories;
using BookingSystem.Domain.DomainModels;
using BookingSystem.DTOs.Auth;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookingSystem.Business.Implementation
{
	public class AuthService : IAuthService
	{
		private readonly IUserRepository _userRepository;

		public AuthService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public LoginResponse Login(LoginRequest request)
		{
			if (request == null)
			{
				throw new ArgumentException("LoginRequest is required");
			}

			if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
			{
				throw new ArgumentException("Username and Password are required");
			}

			User? user = _userRepository.GetUser(request.Username, request.Password);

			if (user == null)
			{
				throw new ArgumentException("Invalid credentials");
			}

			string token = GenerateToken(user);

			LoginResponse response = new LoginResponse();
			response.Token = token;

			return response;
		}

		private static string GenerateToken(User user)
		{
			JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
			var secretKey = Encoding.ASCII.GetBytes("Booking system secret secret key");

			SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
			{
				Expires = DateTime.Now.AddHours(1),
				Subject = new ClaimsIdentity(new[] {
					 new Claim("id", user.Id.ToString()),
			         new Claim(ClaimTypes.Name, user.Username)
				}),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature)
			};

			SecurityToken token = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
			string tokenString = jwtSecurityTokenHandler.WriteToken(token);

			return tokenString;
		}

	}
}
