using BookingSystem.Business.Implementation;
using BookingSystem.Business.Implementation.Factories;
using BookingSystem.Business.Implementation.Strategies;
using BookingSystem.Business.Interfaces;
using BookingSystem.Business.Interfaces.Factories;
using BookingSystem.Business.Interfaces.Strategies;
using Microsoft.Extensions.DependencyInjection;

namespace BookingSystem.Business
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddScoped<ISearchService, SearchService>();
			services.AddScoped<IBookingService, BookingService>();
			services.AddScoped<ISearchStrategy, HotelOnlySearchStrategy>();
			services.AddScoped<ISearchStrategy, HotelAndFlightSearchStrategy>();
			services.AddScoped<ISearchStrategy, LastMinuteHotelsSearchStrategy>();
			services.AddScoped<ISearchStrategyFactory, SearchStrategyFactory>();

			return services;
		}
	}
}
