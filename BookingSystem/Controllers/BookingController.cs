using BookingSystem.Business.Interfaces;
using BookingSystem.DTOs.Booking;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookingController : ControllerBase
	{
		private readonly IBookingService _bookingService;

		public BookingController(IBookingService bookingService)
		{
			_bookingService = bookingService;
		}

		[HttpPost("book")]
		public ActionResult<BookResponse> Book([FromBody] BookRequest request)
		{
			return Ok(_bookingService.Book(request));
		}

		[HttpGet("status/{bookingCode}")]
		public ActionResult<BookingStatusResponse> CheckStatus([FromRoute] string bookingCode)
		{
			return Ok(_bookingService.CheckStatus(bookingCode));
		}
	}
}
