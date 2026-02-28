using BookingSystem.DataAccess.Implementation.Clients;
using BookingSystem.DataAccess.Implementation.Repositories;
using BookingSystem.DataAccess.Interfaces.Clients;
using BookingSystem.DataAccess.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BookingSystem.DataAccess
{
	public static class DependencyInjection
	{
		/// <summary>
		/// Extension method to register data access services and HTTP clients in the dependency injection container
		/// </summary>
		public static IServiceCollection AddDataAccess(this IServiceCollection services)
		{
			// Register in-memory repositories as singletons
			services.AddSingleton<ISearchRepository, SearchRepository>();
			services.AddSingleton<IBookingRepository, BookingRepository>();
			services.AddSingleton<IUserRepository, UserRepository>();

			// Register HTTP client for hotel API
			services.AddHttpClient<IHotelClient, HotelClient>(c =>
				c.BaseAddress = new Uri("https://tripx-test-functions.azurewebsites.net/"));

			// Register HTTP client for flight API
			services.AddHttpClient<IFlightClient, FlightClient>(c =>
				c.BaseAddress = new Uri("https://tripx-test-functions.azurewebsites.net/"));

			return services;
		}
	}
}
