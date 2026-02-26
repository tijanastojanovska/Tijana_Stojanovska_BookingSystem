using BookingSystem.DataAccess.Implementation.Clients;
using BookingSystem.DataAccess.Implementation.Repositories;
using BookingSystem.DataAccess.Interfaces.Clients;
using BookingSystem.DataAccess.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BookingSystem.DataAccess
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddDataAccess (this IServiceCollection services)
		{
			services.AddSingleton<ISearchRepository, SearchRepository>();
			services.AddHttpClient<IHotelClient, HotelClient>(c =>
			c.BaseAddress = new Uri("https://tripx-test-functions.azurewebsites.net/"));

			services.AddHttpClient<IFlightClient, FlightClient>(c =>
				c.BaseAddress = new Uri("https://tripx-test-functions.azurewebsites.net/"));
			return services;
		}
	}
}
