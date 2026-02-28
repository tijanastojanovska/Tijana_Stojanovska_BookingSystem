using BookingSystem.Domain.DomainModels;

namespace BookingSystem.DataAccess.Interfaces.Repositories
{
	/// <summary>
	/// Represents the repository responsible for retrieving user information
	/// </summary>
	public interface IUserRepository
	{
		/// <summary>
		/// Retrieves a user by username and password
		/// </summary>
		User? GetUser(string username, string password);
	}
}
