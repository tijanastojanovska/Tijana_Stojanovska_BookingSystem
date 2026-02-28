using BookingSystem.Business.Implementation;
using BookingSystem.Business.Implementation.Factories;
using BookingSystem.Business.Implementation.Strategies;
using BookingSystem.Business.Interfaces;
using BookingSystem.Business.Interfaces.Factories;
using BookingSystem.Business.Interfaces.Strategies;
using Microsoft.Extensions.DependencyInjection;

namespace BookingSystem.Business
{
	/// <summary>
	/// Extension class for registering business services and search strategies in the dependency injection container
	/// </summary>
	public static class DependencyInjection
	{
		/// <summary>
		/// Registers application services, search strategies, and factories
		/// </summary>
		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddScoped<ISearchService, SearchService>();
			services.AddScoped<IBookingService, BookingService>();
			services.AddScoped<IAuthService, AuthService>();

			// Register search strategies
			services.AddScoped<ISearchStrategy, HotelOnlySearchStrategy>();
			services.AddScoped<ISearchStrategy, HotelAndFlightSearchStrategy>();
			services.AddScoped<ISearchStrategy, LastMinuteHotelsSearchStrategy>();

			// Register strategy factory
			services.AddScoped<ISearchStrategyFactory, SearchStrategyFactory>();

			return services;
		}
	}
}
