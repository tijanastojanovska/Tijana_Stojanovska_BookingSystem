using BookingSystem.Business.Helpers;
using BookingSystem.Business.Interfaces;
using BookingSystem.Business.Mappers;
using BookingSystem.DataAccess.Interfaces.Repositories;
using BookingSystem.Domain.DomainModels;
using BookingSystem.Domain.Enums;
using BookingSystem.DTOs.Booking;

namespace BookingSystem.Business.Implementation
{
	public class BookingService : IBookingService
	{
		private readonly ISearchRepository _searchRepository;
		private readonly IBookingRepository _bookingRepository;

		public BookingService(ISearchRepository searchRepository, IBookingRepository bookingRepository)
		{
			_searchRepository = searchRepository;
			_bookingRepository = bookingRepository;
		}

		public BookResponse Book(BookRequest request)
		{
			ValidateBookingRequest(request);

			Option? option = _searchRepository.GetOption(request.OptionCode);
			if (option == null)
			{
				throw new ArgumentException("Option not found. Please search again");
			}

			SearchTypeEnum? searchType = _searchRepository.GetSearchType(request.OptionCode);
			if (searchType == null)
			{
				throw new ArgumentException("Search type not found for this option");
			}

			Booking booking = new Booking();
			booking.BookingCode = BookingCodeGenerator.Generate(6);
			booking.OptionCode = request.OptionCode;
			booking.SearchType = searchType.Value;
			booking.BookingTime = DateTime.UtcNow;
			booking.SleepTime = Random.Shared.Next(30, 60); 

			_bookingRepository.Save(booking);

			return booking.ToBookResponse();
		}

		public BookingStatusResponse CheckStatus(string bookingCode)
		{
			if (string.IsNullOrWhiteSpace(bookingCode))
			{
				throw new ArgumentException("BookingCode is required");
			}

			Booking? booking = _bookingRepository.Get(bookingCode);
			if (booking == null)
			{
				throw new ArgumentException("Booking not found");
			}

			DateTime readyAt = booking.BookingTime.AddSeconds(booking.SleepTime);

			BookingStatusEnum status;
			if (DateTime.UtcNow < readyAt)
			{
				status = BookingStatusEnum.Pending;
			}
			else
			{
				if (booking.SearchType == SearchTypeEnum.LastMinuteHotels)
				{
					status = BookingStatusEnum.Failed;
				}
				else
				{
					status = BookingStatusEnum.Success;
				}
			}

			BookingStatusResponse response = new BookingStatusResponse();
			response.Status = status;

			return response;
		}

		private void ValidateBookingRequest(BookRequest request)
		{
			if (request == null)
			{
				throw new ArgumentException("BookRequest is required");
			}

			if (string.IsNullOrWhiteSpace(request.OptionCode))
			{
				throw new ArgumentException("OptionCode is required");
			}
		}
	}
}
