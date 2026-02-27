using BookingSystem.Domain.DomainModels;

namespace BookingSystem.DataAccess.Interfaces.Repositories
{
	public interface IUserRepository
	{
		User? GetUser(string username, string password);
	}
}
