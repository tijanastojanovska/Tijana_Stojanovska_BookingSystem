using BookingSystem.DataAccess.Interfaces.Repositories;
using BookingSystem.Domain.DomainModels;

namespace BookingSystem.DataAccess.Implementation.Repositories
{
	public class UserRepository : IUserRepository
	{
		private static readonly List<User> _users = new List<User>
			{
				new User { Id = Guid.NewGuid(), Username = "petkop", Password = "P@ssw0rd" },
				new User { Id = Guid.NewGuid(), Username = "trajkot", Password = "Test123!" }
			};

		public User? GetUser(string username, string password)
		{
			return _users.FirstOrDefault(u => u.Username == username && u.Password == password);
		}

	}
}
