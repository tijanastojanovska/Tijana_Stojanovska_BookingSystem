using BookingSystem.Business.Implementation;
using BookingSystem.Business.Interfaces.Factories;
using BookingSystem.Business.Interfaces.Strategies;
using BookingSystem.DataAccess.Interfaces.Repositories;
using BookingSystem.Domain.DomainModels;
using BookingSystem.Domain.Enums;
using BookingSystem.DTOs.Search;
using Moq;

namespace BookSystem.Test;

[TestFixture]
public class SearchServiceTest
{
	private Mock<ISearchStrategyFactory> _factoryMock;
	private Mock<ISearchRepository> _repoMock;

	private SearchService _searchService;

	[SetUp]
	public void SetUp()
	{
		_factoryMock = new Mock<ISearchStrategyFactory>();
		_repoMock = new Mock<ISearchRepository>();

		_searchService = new SearchService(_factoryMock.Object, _repoMock.Object);
	}

	[Test]
	public void SearchAsync_WhenRequestIsNull_ThrowsArgumentException()
	{
		SearchRequest request = null;

		Assert.That(
			async () => await _searchService.SearchAsync(request),
			Throws.TypeOf<ArgumentException>());
	}

	[Test]
	public void SearchAsync_WhenDestinationIsEmpty_ThrowsArgumentException()
	{
		SearchRequest request = new SearchRequest
		{
			Destination = " ",
			FromDate = DateTime.UtcNow.AddDays(10),
			ToDate = DateTime.UtcNow.AddDays(12)
		};

		Assert.That(
			async () => await _searchService.SearchAsync(request),
			Throws.TypeOf<ArgumentException>());
	}

	[Test]
	public void SearchAsync_WhenFromDateIsAfterToDate_ThrowsArgumentException()
	{
		SearchRequest request = new SearchRequest
		{
			Destination = "SKP",
			FromDate = DateTime.UtcNow.AddDays(10),
			ToDate = DateTime.UtcNow.AddDays(5)
		};

		Assert.That(
			async () => await _searchService.SearchAsync(request),
			Throws.TypeOf<ArgumentException>());
	}

	[Test]
	public async Task SearchAsync_WhenValidRequest_CallsStrategyAndSavesAndReturnsResponse()
	{
		SearchRequest request = new SearchRequest
		{
			Destination = "SKP",
			DepartureAirport = "OSL",
			FromDate = DateTime.UtcNow.AddDays(60),
			ToDate = DateTime.UtcNow.AddDays(65)
		};

		var strategyMock = new Mock<ISearchStrategy>();
		strategyMock.SetupGet(s => s.Type)
			.Returns(SearchTypeEnum.HotelAndFlight);

		List<Option> options = new List<Option>
		{
			new Option
			{
				OptionCode = "OPT001",
				HotelCode = "8626",
				FlightCode = "461",
				ArrivalAirport = "SKP",
				Price = 120
			},
			new Option
			{
				OptionCode = "OPT002",
				HotelCode = "8627",
				FlightCode = "462",
				ArrivalAirport = "SKP",
				Price = 130
			}
		};

		strategyMock
			.Setup(s => s.SearchAsync(It.IsAny<SearchCriteria>()))
			.ReturnsAsync(options);

		_factoryMock
			.Setup(f => f.GetStrategy(It.IsAny<SearchCriteria>()))
			.Returns(strategyMock.Object);

		SearchResponse result = await _searchService.SearchAsync(request);

		_repoMock.Verify(
			r => r.SaveInMemory(SearchTypeEnum.HotelAndFlight, options),
			Times.Once);

		Assert.That(result, Is.Not.Null);
		Assert.That(result.Options, Is.Not.Null);
		Assert.That(result.Options.Count, Is.EqualTo(2));
	}
}