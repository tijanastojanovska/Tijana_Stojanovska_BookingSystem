using BookingSystem.Business.Implementation;
using BookingSystem.DataAccess.Interfaces.Repositories;
using BookingSystem.Domain.DomainModels;
using BookingSystem.Domain.Enums;
using BookingSystem.DTOs.Booking;
using Moq;

namespace BookingSystem.Test
{
	[TestFixture]
	public class BookingServiceTest
	{
		private Mock<ISearchRepository> _searchRepoMock;
		private Mock<IBookingRepository> _bookingRepoMock;

		private BookingService _bookingService;

		[SetUp]
		public void SetUp()
		{
			_searchRepoMock = new Mock<ISearchRepository>();
			_bookingRepoMock = new Mock<IBookingRepository>();

			_bookingService = new BookingService(
				_searchRepoMock.Object,
				_bookingRepoMock.Object);
		}

		[Test]
		public void Book_WhenRequestIsNull_ThrowsArgumentException()
		{
			Assert.That(() => _bookingService.Book(null),
				Throws.TypeOf<ArgumentException>());
		}

		[Test]
		public void Book_WhenOptionCodeIsEmpty_ThrowsArgumentException()
		{
			BookRequest request = new BookRequest
			{
				OptionCode = " "
			};

			Assert.That(() => _bookingService.Book(request),
				Throws.TypeOf<ArgumentException>());
		}

		[Test]
		public void Book_WhenOptionDoesNotExist_ThrowsKeyNotFound()
		{
			BookRequest request = new BookRequest
			{
				OptionCode = "OPT1"
			};

			_searchRepoMock
				.Setup(r => r.GetOption("OPT1"))
				.Returns((Option)null);

			Assert.That(() => _bookingService.Book(request),
				Throws.TypeOf<KeyNotFoundException>());
		}

		[Test]
		public void Book_WhenValidRequest_SavesBookingAndReturnsResponse()
		{
			BookRequest request = new BookRequest
			{
				OptionCode = "OPT1"
			};

			Option option = new Option { OptionCode = "OPT1" };

			_searchRepoMock
				.Setup(r => r.GetOption("OPT1"))
				.Returns(option);

			_searchRepoMock
				.Setup(r => r.GetSearchType("OPT1"))
				.Returns(SearchTypeEnum.HotelOnly);

			BookResponse response = _bookingService.Book(request);

			_bookingRepoMock.Verify(r => r.Save(It.IsAny<Booking>()), Times.Once);

			Assert.That(response, Is.Not.Null);
			Assert.That(response.BookingCode, Is.Not.Null.And.Not.Empty);
		}


		[Test]
		public void CheckStatus_WhenBookingCodeIsEmpty_ThrowsArgumentException()
		{
			Assert.That(() => _bookingService.CheckStatus(" "),
				Throws.TypeOf<ArgumentException>());
		}

		[Test]
		public void CheckStatus_WhenBookingNotFound_ThrowsKeyNotFound()
		{
			_bookingRepoMock
				.Setup(r => r.Get("ABC123"))
				.Returns((Booking)null);

			Assert.That(() => _bookingService.CheckStatus("ABC123"),
				Throws.TypeOf<KeyNotFoundException>());
		}

		[Test]
		public void CheckStatus_WhenBookingNotReady_ReturnsPending()
		{
			Booking booking = new Booking
			{
				BookingCode = "ABC123",
				BookingTime = DateTime.UtcNow,
				SleepTime = 60,
				SearchType = SearchTypeEnum.HotelOnly
			};

			_bookingRepoMock
				.Setup(r => r.Get("ABC123"))
				.Returns(booking);

			BookingStatusResponse result = _bookingService.CheckStatus("ABC123");

			Assert.That(result.Status, Is.EqualTo(BookingStatusEnum.Pending));
		}

		[Test]
		public void CheckStatus_WhenReadyAndLastMinute_ReturnsFailed()
		{
			Booking booking = new Booking
			{
				BookingCode = "ABC123",
				BookingTime = DateTime.UtcNow.AddMinutes(-5),
				SleepTime = 1,
				SearchType = SearchTypeEnum.LastMinuteHotels
			};

			_bookingRepoMock
				.Setup(r => r.Get("ABC123"))
				.Returns(booking);

			BookingStatusResponse result = _bookingService.CheckStatus("ABC123");

			Assert.That(result.Status, Is.EqualTo(BookingStatusEnum.Failed));
		}

		[Test]
		public void CheckStatus_WhenReadyAndNotLastMinute_ReturnsSuccess()
		{
			Booking booking = new Booking
			{
				BookingCode = "ABC123",
				BookingTime = DateTime.UtcNow.AddMinutes(-5),
				SleepTime = 1,
				SearchType = SearchTypeEnum.HotelOnly
			};

			_bookingRepoMock
				.Setup(r => r.Get("ABC123"))
				.Returns(booking);

			BookingStatusResponse result = _bookingService.CheckStatus("ABC123");

			Assert.That(result.Status, Is.EqualTo(BookingStatusEnum.Success));
		}
	}
}