using BookingSystem.Business.Interfaces;
using BookingSystem.DTOs.Booking;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers
{
	/// <summary>
	/// API controller responsible for handling booking-related requests
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class BookingController : ControllerBase
	{
		private readonly IBookingService _bookingService;

		/// <summary>
		/// Initializes a new instance of the BookingController with the provided booking service
		/// </summary>
		public BookingController(IBookingService bookingService)
		{
			_bookingService = bookingService;
		}

		/// <summary>
		/// Creates a new booking based on the provided request
		/// </summary>
		[Authorize]
		[HttpPost("book")]
		public ActionResult<BookResponse> Book([FromBody] BookRequest request)
		{
			return Ok(_bookingService.Book(request));
		}

		/// <summary>
		/// Checks the status of a booking using its booking code
		/// </summary>
		[Authorize]
		[HttpGet("status/{bookingCode}")]
		public ActionResult<BookingStatusResponse> CheckStatus([FromRoute] string bookingCode)
		{
			return Ok(_bookingService.CheckStatus(bookingCode));
		}
	}
}
